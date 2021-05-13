using CamadaBLL;
using CamadaDTO;
using CamadaUI.Contas;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmEntrada : Modals.frmModFinBorder
	{
		EntradaBLL entBLL = new EntradaBLL();
		private objEntrada _entrada;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private Form _formOrigem = null;

		private List<objEntradaTipo> listTipos;

		private objConta contaSelected; // is a COPY of default
		private objSetor setorSelected; // is a COPY of default

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmEntrada(objEntrada entrada)
		{
			InitializeComponent();
			ConstructorContinue(entrada);
		}

		public frmEntrada(long IDEntrada, Form formOrigem = null)
		{
			InitializeComponent();
			var cont = GetEntradaByID(IDEntrada);

			if (cont == null) return;

			//--- Form origem
			_formOrigem = formOrigem;

			this.Shown += (a, b) => DesativaPanel(formOrigem);
			this.FormClosed += (a, b) => AtivaPanel(formOrigem);

			ConstructorContinue(cont);
		}

		// CONTRUCTOR CONTINUE
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objEntrada entrada)
		{
			_entrada = entrada;
			GetTipos();

			// Define Conta and Setor padrao
			contaSelected = ContaPadrao();
			setorSelected = SetorPadrao();

			// binding
			bind.DataSource = typeof(objEntrada);
			bind.Add(_entrada);
			BindingCreator();

			if (_entrada.IDEntrada == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// define DEFAULT DATE
			DefineDataPadrao();

			// handlers
			_entrada.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);

			txtEntradaTipo.Enter += text_Enter;
			txtEntradaOrigem.Enter += text_Enter;
			txtEntradaDescricao.Enter += text_Enter;

			numEntradaAno.KeyDown += Numeric_KeyDown;
			numEntradaAno.Enter += Numeric_Enter;
			numEntradaDia.KeyDown += Numeric_KeyDown;
			numEntradaDia.Enter += Numeric_Enter;
		}

		// SHOW FORM
		//------------------------------------------------------------------------------------------------------------
		private void frmEntrada_Shown(object sender, EventArgs e)
		{
			if (_entrada == null)
			{
				Close();
				return;
			}

			// if frmListagem is ENABLED then exit
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}

			// block keyDown then Sit = Alterado
			txtEntradaValor.KeyDown += control_KeyDown_Block;
			numEntradaDia.KeyDown += control_KeyDown_Block;
			numEntradaAno.KeyDown += control_KeyDown_Block;
			cmbEntradaMes.KeyDown += control_KeyDown_Block;
		}

		// GET ENTRADA BY ID
		//------------------------------------------------------------------------------------------------------------
		private objEntrada GetEntradaByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return entBLL.GetEntrada(ID);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Entrada..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF ENTRADA FORMAS AND TIPOS
		//------------------------------------------------------------------------------------------------------------
		private void GetTipos()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listTipos = new List<objEntradaTipo>()
				{
					new objEntradaTipo()
					{
						EntradaTipo = "Investimento",
						IDEntradaTipo = 1
					}
				};
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Tipos e Formas..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public EnumFlagEstado Sit
		{
			get { return _Sit; }
			set
			{
				_Sit = value;

				if (value == EnumFlagEstado.NovoRegistro)
				{
					btnSalvar.Visible = true;
					btnCancelar.Text = "&Cancelar";
					btnCancelar.Image = Properties.Resources.delete_page_30;

					btnNovo.Enabled = false;
					btnSalvar.Enabled = true;
					btnCancelar.Enabled = true;
					lblSitBlock.Visible = false;

					DefineConta(contaSelected);
					DefineSetor(setorSelected);

					numEntradaAno.Maximum = DateTime.Today.Year;
					numEntradaAno.Minimum = DateTime.Today.Year - 30;
					numEntradaDia.Maximum = 31;
					numEntradaDia.Minimum = 1;
				}
				else
				{
					btnSalvar.Visible = false;
					btnCancelar.Text = "&Excluir Entrada";
					btnCancelar.Image = Properties.Resources.lixeira_24;

					btnNovo.Enabled = true;
					lblSitBlock.Visible = true;

					numEntradaAno.Maximum = _entrada.EntradaData.Year;
					numEntradaAno.Minimum = _entrada.EntradaData.Year;
					numEntradaDia.Maximum = _entrada.EntradaData.Day;
					numEntradaDia.Minimum = _entrada.EntradaData.Day;
				}

				// btnSET
				btnSetConta.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetOrigem.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetEntradaTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// DEFINE A DATA PADRAO DA ENTRADA DATA
		//------------------------------------------------------------------------------------------------------------
		private void DefineDataPadrao()
		{
			if (contaSelected.BloqueioData != null)
			{
				if (DataPadrao() < contaSelected.BloqueioData)
				{
					_entrada.EntradaData = (DateTime)contaSelected.BloqueioData;
				}
				else
				{
					_entrada.EntradaData = DataPadrao();
				}
			}
			else
			{
				_entrada.EntradaData = DataPadrao();
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDEntrada", true);
			txtEntradaValor.DataBindings.Add("Text", bind, "EntradaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEntradaTipo.DataBindings.Add("Text", bind, "EntradaTipo.EntradaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtConta.DataBindings.Add("Text", bind, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEntradaOrigem.DataBindings.Add("Text", bind, "EntradaOrigem.OrigemDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEntradaDescricao.DataBindings.Add("Text", bind, "EntradaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtEntradaValor.DataBindings["Text"].Format += FormatCurrency;

			// CARREGA COMBO
			CarregaComboMes();

			// ADD NAMED BINDINGS TO CONTROL ERROS
			//------------------------------------------------------------------------------------------------------------
			Binding bndEntradaMes = cmbEntradaMes.DataBindings.Add("SelectedValue", bind, "EntradaMes", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaDia = numEntradaDia.DataBindings.Add("Text", bind, "EntradaDia", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaAno = numEntradaAno.DataBindings.Add("Text", bind, "EntradaAno", true, DataSourceUpdateMode.OnPropertyChanged);

			Action<object, BindingCompleteEventArgs, Control> bindComplete = (o, e, c) =>
			{
				if (e.BindingCompleteState != BindingCompleteState.Success)
				{
					AbrirDialog(e.Exception.Message, "Data Inválida", DialogType.OK, DialogIcon.Exclamation);
					numEntradaDia.DataBindings["Text"].ReadValue();
					cmbEntradaMes.DataBindings["SelectedValue"].ReadValue();
					numEntradaAno.DataBindings["Text"].ReadValue();

					if (c.GetType() == typeof(CamadaUC.ucOnlyNumbers)) ((TextBox)c).SelectAll();
				}
			};

			// HANDLERS TO CONTROL ERROS
			bndEntradaDia.BindingComplete += (a, b) => bindComplete(a, b, numEntradaDia);
			bndEntradaMes.BindingComplete += (a, b) => bindComplete(a, b, cmbEntradaMes);
			bndEntradaAno.BindingComplete += (a, b) => bindComplete(a, b, numEntradaAno);
		}


		private void FormatID(object sender, ConvertEventArgs e)
		{
			if (e.Value == DBNull.Value || e.Value == null)
			{
				e.Value = "NOVA";
			}
			else
			{
				e.Value = $"{e.Value: 0000}";
			}
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}

			EP.Clear();
		}

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaComboMes()
		{
			//--- Create DataTable
			DataTable dtMeses = new DataTable();
			dtMeses.Columns.Add("ID", typeof(int));
			dtMeses.Columns.Add("Mes");

			// get values of EnumAgendaRecorrencia
			string[] EnumValues = new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.MonthNames;
			int i = 1;

			// insert all item of EnumAgendaRecorrencia in datatable
			foreach (var mes in EnumValues)
			{
				if (string.IsNullOrEmpty(mes)) continue;
				dtMeses.Rows.Add(new object[] { i, mes });
				i++;
			}

			//--- Set DataTable
			cmbEntradaMes.DataSource = dtMeses;
			cmbEntradaMes.ValueMember = "ID";
			cmbEntradaMes.DisplayMember = "Mes";
		}

		#endregion

		#region BUTTONS

		// FECHAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				AbrirDialog("Esse registro ainda não foi salvo... \n" +
					"Favor SALVAR ou CANCELAR a edição do registro atual antes de fechar.",
					"Registro Novo", DialogType.OK, DialogIcon.Exclamation);
				return;
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				AbrirDialog("Esse registro de Entrada não pode ser alterado... \n" +
							"O formulário será fechado, e não será salvo.",
							"Registro Alterado", DialogType.OK, DialogIcon.Exclamation);
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			if (!Modal)
				new frmEntradaListagem() { MdiParent = Application.OpenForms[0] }.Show();

			Close();
		}

		// CANCELAR ALTERACAO
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				CancelarFunc();
			}
			else
			{
				ExcluirFunc();
			}
		}

		// CANCELAR ALTERACAO FUNCTION
		//------------------------------------------------------------------------------------------------------------
		private void CancelarFunc()
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de um novo registro?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					var frmList = new frmEntradaListagem();
					frmList.MdiParent = Application.OpenForms[0];
					frmList.Show();
					Close();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		// EXCLUIR ENTRADA FUNCTION
		//------------------------------------------------------------------------------------------------------------
		private void ExcluirFunc()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// --- ask USER
				var resp = AbrirDialog("Você deseja realmente EXCLUIR definitivamente a Entrada ATUAL?\n" +
					$"\nREG: {_entrada.IDEntrada:D4}\nDATA: {_entrada.EntradaData.ToShortDateString()}\nVALOR: {_entrada.EntradaValor:c}",
					"Excluir Entrada", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				//--- EXECUTE DELETE
				entBLL.DeleteEntrada((long)_entrada.IDEntrada, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

				//--- CLOSE FORM
				Close();

				//--- INFORM
				AbrirDialog("Registro removido com sucesso!", "Exclusão");
			}
			catch (AppException ex)
			{
				AbrirDialog("A Entrada está protegida de exclusão porque:\n" +
							ex.Message, "Bloqueio de Exclusão", DialogType.OK, DialogIcon.Exclamation);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir Entrada..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			// if frmAPagarListagem is ENABLED then exit
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}

			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_entrada = new objEntrada(null);

			// define DEFAULT DATE
			DefineDataPadrao();

			Sit = EnumFlagEstado.NovoRegistro;
			bind.DataSource = _entrada;
			txtConta.Focus();
		}

		#endregion

		#region SAVE REGISTRY

		// SALVAR REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnSalvar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- check data
				if (!CheckSaveData()) return;

				//--- SAVE: INSERT
				if (_entrada.IDEntrada == null) //--- save | Insert
				{
					long ID = entBLL.InsertEntrada(_entrada, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

					//--- define newID
					_entrada.IDEntrada = ID;
					lblID.DataBindings["Text"].ReadValue();
				}
				else //--- update
				{
					AbrirDialog("Não é possível atualizar uma Entrada...", "Atualização",
						DialogType.OK, DialogIcon.Exclamation);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;

				//--- emit massage
				var resp = AbrirDialog("Registro Salvo com sucesso!" +
										"\nDeseja inserir uma NOVA Entrada?",
										"Registro Salvo",
										DialogType.SIM_NAO,
										DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					btnNovo_Click(sender, e);
				}
				else
				{
					btnFechar_Click(sender, e);
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Entrada..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				txtConta.Focus();
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// CHECK INSERTED DATA
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtEntradaTipo, "Tipo de Entrada", _entrada, EP)) return false;
			if (!VerificaDadosClasse(txtSetor, "Setor de Entrada", _entrada, EP)) return false;
			if (!VerificaDadosClasse(txtConta, "Conta de Entrada", _entrada, EP)) return false;
			if (!VerificaDadosClasse(txtEntradaOrigem, "Origem da Entrada", _entrada, EP)) return false;

			// check VALOR BRUTO
			if (!VerificaDadosClasse(txtEntradaValor, "Valor da Entrada", _entrada, EP)) return false;

			if (_entrada.EntradaValor <= 0)
			{
				// message
				AbrirDialog("O valor da Entrada não pode ser igual a zero...\n" +
					"Favor preecher esse campo com um valor maior que zero.", "Valor da Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtEntradaValor, "Preencha o valor desse campo!");
				// select
				txtEntradaValor.Focus();
				// return
				return false;
			}

			//--- check DATA FUTURA
			if (_entrada.EntradaData > DateTime.Today)
			{
				AbrirDialog("A Data da Entrada não pode ser maior que a Data de hoje\n" +
						"Favor reinserir a Data da Entrada corretamente.", "Data da Entrada",
						DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(numEntradaDia, "Valor incorreto...");
				numEntradaDia.Focus();
				return false;
			}

			// CHECK DESCRICAO
			if (!VerificaDadosClasse(txtEntradaDescricao, "Descrição da Origem", _entrada, EP)) return false;

			if (_entrada.EntradaDescricao.Length > 100)
			{
				// message
				AbrirDialog("O Texto da Descrição não pode conter mais do que 200 caracteres...\n" +
					"Favor preecher esse campo com até 200 caracteres.", "Descrição da Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtEntradaDescricao, "Máximo de 200 caracteres!");
				// select
				txtEntradaDescricao.Focus();
				// return
				return false;
			}

			return true;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtConta,
					txtEntradaOrigem,
					txtEntradaTipo,
					txtSetor,
					txtEntradaDescricao
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmEntrada_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtEntradaTipo":
						btnSetEntradaTipo_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtEntradaOrigem":
						btnSetOrigem_Click(sender, new EventArgs());
						break;
					case "txtEntradaDescricao":
						defineDescricao();
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;
			}
			else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesLiberados = {
					txtEntradaTipo,
				};

				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesID = {
					txtConta,
					txtSetor,
				};

				if (controlesLiberados.Contains(ctr))
				{
					e.Handled = false;
				}
				else if (controlesID.Contains(ctr))
				{
					if (!string.IsNullOrEmpty(ctr.Text) && !int.TryParse(ctr.Text, out _))
					{
						ctr.Text = string.Empty;
					}

					e.Handled = false;
				}
				else
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			else if (ctr.Name == "txtEntradaOrigem" && ((e.KeyCode == Keys.D0) | (e.KeyCode >= Keys.NumPad0)))
			{
				e.Handled = false;
			}
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtConta,
					txtEntradaOrigem,
					txtEntradaTipo,
					txtSetor };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// CREATE SHORTCUT TO TEXTBOX LIST VALUES
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar))
			{
				Control ctr = (Control)sender;
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtEntradaTipo":

						if (listTipos.Count > 0)
						{
							var tipo = listTipos.FirstOrDefault(x => x.IDEntradaTipo == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDEntradaTipo != _entrada.EntradaTipo.IDEntradaTipo)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_entrada.EntradaTipo.IDEntradaTipo = (byte)tipo.IDEntradaTipo;
								txtEntradaTipo.Text = tipo.EntradaTipo;
							}
						}
						break;

					default:
						break;
				}
			}
		}

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void text_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= text_Enter;
		}

		// DEFINE CRIA UM TEXTO AUTOMATICA PARA DESCRICAO
		//------------------------------------------------------------------------------------------------------------
		private void defineDescricao()
		{
			if (!string.IsNullOrEmpty(_entrada.EntradaDescricao)) return;
			txtEntradaDescricao.Text = $"{_entrada.EntradaTipo.EntradaTipo} - {_entrada.EntradaOrigem.OrigemDescricao}";
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void cmbEntradaMes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				cmbEntradaMes.SelectedValue = _entrada.EntradaMes;
			}
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void control_KeyDown_Block(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------
		}

		// CONTROLING NUMERIC UP/DOWN
		//------------------------------------------------------------------------------------------------------------
		private void Numeric_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			};
		}

		private void Numeric_Enter(object sender, EventArgs e)
		{
			((NumericUpDown)sender).Select(0, 4);
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContaProcura frm = new frmContaProcura(this, _entrada.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _entrada.IDConta != frm.propEscolha.IDConta)
						Sit = EnumFlagEstado.Alterado;

					DefineConta(frm.propEscolha);

				}

				//--- select
				txtConta.Focus();
				txtConta.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetEntradaTipo_Click(object sender, EventArgs e)
		{
			if (listTipos == null || listTipos.Count == 0)
			{
				AbrirDialog("Não há Tipos de Entrada cadastrados...", "Tipos de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listTipos.ToDictionary(x => (int)x.IDEntradaTipo, x => x.EntradaTipo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtEntradaTipo, _entrada.EntradaTipo.IDEntradaTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_entrada.EntradaTipo.IDEntradaTipo = (byte)frm.propEscolha.Key;
				txtEntradaTipo.Text = frm.propEscolha.Value;
				txtEntradaDescricao.Clear();
			}

			//--- select
			txtEntradaTipo.Focus();
			txtEntradaTipo.SelectAll();
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _entrada.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _entrada.IDSetor != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					DefineSetor(frm.propEscolha);
				}

				//--- select
				txtSetor.Focus();
				txtSetor.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetOrigem_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new frmEntradaOrigemProcura(this, _entrada.EntradaOrigem.IDEntradaOrigem);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH ORIGEM
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _entrada.EntradaOrigem.IDEntradaOrigem != frm.propEscolha.IDEntradaOrigem)
						Sit = EnumFlagEstado.Alterado;

					_entrada.EntradaOrigem.IDEntradaOrigem = (int)frm.propEscolha.IDEntradaOrigem;
					txtEntradaOrigem.Text = frm.propEscolha.OrigemDescricao;
				}
				else if (frm.DialogResult == DialogResult.Yes) // ADD NEW ORIGEM
				{
					/*
					frmContribuinte frmNovo = new frmContribuinte(new objContribuinte(null), this);
					frmNovo.ShowDialog();

					if (frmNovo.DialogResult == DialogResult.OK)
					{
						if (Sit != EnumFlagEstado.NovoRegistro && _entrada.IDContribuinte != frmNovo.propEscolha.IDContribuinte)
							Sit = EnumFlagEstado.Alterado;

						_entrada.IDContribuinte = (int)frmNovo.propEscolha.IDContribuinte;
						txtEntradaOrigem.Text = frmNovo.propEscolha.Contribuinte;
					}
					*/
				}

				//--- select
				txtEntradaOrigem.Focus();
				txtEntradaOrigem.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS PROCURA --- END

		#region DEFINE CONTA | SETOR BY ID

		// DEFINE CONTA VALIDATING
		//------------------------------------------------------------------------------------------------------------
		private void txtConta_Validating(object sender, CancelEventArgs e)
		{
			Control control = (Control)sender;

			if (int.TryParse(control.Text, out int IDConta)) // check is numeric
			{
				if (!DefineContaByID(IDConta))
				{
					e.Cancel = true;
				}
			}
			else if (string.IsNullOrEmpty(control.Text)) // se for vazio
			{
				return;
			}
		}

		// DEFINE CONTA BY ID
		//------------------------------------------------------------------------------------------------------------
		private bool DefineContaByID(int IDConta)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var conta = new ContaBLL().GetConta(IDConta);

				//--- check valid return
				if (conta == null)
				{
					AbrirDialog("ID da conta não encontrado...",
						"Conta", DialogType.OK, DialogIcon.Information);
					return false;
				}

				//--- check conta Cartao
				if (conta.OperadoraCartao)
				{
					AbrirDialog("Conta tipo OPERADORA não é valida para realização de Entrada...",
						"Conta Operadora", DialogType.OK, DialogIcon.Information);
					return false;
				}

				DefineConta(conta);
				return true;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter a Conta Pelo ID..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// DEFINE CONTA
		//------------------------------------------------------------------------------------------------------------
		private void DefineConta(objConta conta)
		{
			contaSelected = conta;
			_entrada.IDConta = (int)conta.IDConta;
			_entrada.Conta = conta.Conta;
			txtConta.DataBindings["Text"].ReadValue();
			DefineDataPadrao();
			lblContaDetalhe.Text = $"Saldo da Conta: {conta.ContaSaldo:c} \n" +
								   $"Data de Bloqueio até: {conta.BloqueioData?.ToShortDateString() ?? ""}";
		}

		// DEFINE SETOR VALIDATING
		//------------------------------------------------------------------------------------------------------------
		private void txtSetor_Validating(object sender, CancelEventArgs e)
		{
			Control control = (Control)sender;

			if (int.TryParse(control.Text, out int IDSetor)) // check is numeric
			{
				if (!DefineSetorByID(IDSetor))
				{
					e.Cancel = true;
				}
			}
			else if (string.IsNullOrEmpty(control.Text)) // se for vazio
			{
				return;
			}
		}

		// DEFINE SETOR BY ID
		//-----------------------------------------------------------------------------------------------------------
		private bool DefineSetorByID(int IDSetor)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var setor = new SetorBLL().GetSetor(IDSetor);

				//--- check valid return
				if (setor == null)
				{
					AbrirDialog("ID do setor não encontrado...",
						"Setor", DialogType.OK, DialogIcon.Information);
					return false;
				}

				DefineSetor(setor);
				return true;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter a Conta Pelo ID..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private void DefineSetor(objSetor setor)
		{
			setorSelected = setor;
			_entrada.IDSetor = (int)setor.IDSetor;
			_entrada.Setor = setor.Setor;
			txtSetor.DataBindings["Text"].ReadValue();
		}

		#endregion // DEFINE CONTA BY ID --- END

		#region TOOLTIP

		private void ShowToolTip(Control controle)
		{
			//Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip()
			{
				AutoPopDelay = 2000, // Define o delay para a ToolTip
				InitialDelay = 2000,
				ReshowDelay = 500,
				IsBalloon = true,
				UseAnimation = true,
				UseFading = true
			};

			if (controle.Tag == null)
			{
				toolTip1.Show("Clique aqui...", controle, controle.Width - 30, -40, 2000);
			}
			else
			{
				toolTip1.Show(controle.Tag.ToString(), controle, controle.Width - 30, -40, 2000);
			}
		}

		#endregion
	}
}
