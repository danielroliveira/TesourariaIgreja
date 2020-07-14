using CamadaBLL;
using CamadaDTO;
using CamadaUI.Congregacoes;
using CamadaUI.Contas;
using CamadaUI.Registres;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmContribuicao : Modals.frmModFinBorder
	{
		ContribuicaoBLL contBLL = new ContribuicaoBLL();
		private objContribuicao _contribuicao;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objContribuicaoTipo> listTipos;
		private List<objEntradaForma> listFormas;

		private objConta contaSelected; // is a COPY of default
		private objSetor setorSelected; // is a COPY of default

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuicao(objContribuicao contribuicao)
		{
			InitializeComponent();
			ConstructorContinue(contribuicao);
		}

		public frmContribuicao(long IDContribuicao)
		{
			InitializeComponent();
			var cont = GetContribuicaoByID(IDContribuicao);

			if (cont == null) return;

			ConstructorContinue(cont);
		}

		// CONTRUCTOR CONTINUE
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objContribuicao contribuicao)
		{
			_contribuicao = contribuicao;
			GetTiposAndFormas();

			// Define Conta and Setor padrao
			contaSelected = ContaPadrao();
			setorSelected = SetorPadrao();

			// binding
			bind.DataSource = typeof(objContribuicao);
			bind.Add(_contribuicao);
			BindingCreator();

			defContribuicaoTipo(_contribuicao.IDContribuicaoTipo);

			if (_contribuicao.IDContribuicao == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// define DEFAULT DATE
			_contribuicao.ContribuicaoData = DataPadrao();

			// handlers
			_contribuicao.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);

			txtContribuicaoTipo.Enter += text_Enter;
			txtReuniao.Enter += text_Enter;
			txtContribuinte.Enter += text_Enter;
			txtCampanha.Enter += text_Enter;
			txtOrigemDescricao.Enter += text_Enter;
			txtEntradaForma.Enter += text_Enter;

			numEntradaAno.KeyDown += Numeric_KeyDown;
			numEntradaAno.Enter += Numeric_Enter;
			numEntradaDia.KeyDown += Numeric_KeyDown;
			numEntradaDia.Enter += Numeric_Enter;

		}

		// SHOW FORM
		//------------------------------------------------------------------------------------------------------------
		private void frmContribuicao_Shown(object sender, EventArgs e)
		{
			if (_contribuicao == null)
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

		}

		// GET CONTRIBUICAO BY ID
		//------------------------------------------------------------------------------------------------------------
		private objContribuicao GetContribuicaoByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return contBLL.GetContribuicao(ID);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Contribuicao..." + "\n" +
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
		private void GetTiposAndFormas()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				EntradaFormaBLL entradaBLL = new EntradaFormaBLL();
				listFormas = entradaBLL.GetEntradaFormasList();
				listTipos = contBLL.GetContribuicaoTiposList();
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
					btnNovo.Enabled = false;
					btnSalvar.Enabled = true;
					btnCancelar.Enabled = true;
					lblSitBlock.Visible = false;

					DefineConta(contaSelected);
					DefineSetor(setorSelected);


					btnSetEntradaForma.Image = null;
					btnSetEntradaForma.Text = "n";
				}
				else
				{
					btnNovo.Enabled = true;
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					lblSitBlock.Visible = true;

					if (_contribuicao.IDEntradaForma != 1)
					{
						btnSetEntradaForma.Image = Properties.Resources.search_16;
						btnSetEntradaForma.ImageAbsolutePosition = new Point(7, 4);
						btnSetEntradaForma.ImageAlign = ContentAlignment.TopCenter;
						btnSetEntradaForma.Text = "";
					}
					else
					{
						btnSetEntradaForma.Enabled = false;
					}
				}

				// btnSET
				btnSetConta.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetContribuinte.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetCampanha.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetReuniao.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetEntradaTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// PROPERTY CONTRIBUICAO TIPO
		//------------------------------------------------------------------------------------------------------------
		private void defContribuicaoTipo(byte IDTipo)
		{
			_contribuicao.IDContribuicaoTipo = IDTipo;

			if (listTipos.Count > 0)
			{
				objContribuicaoTipo tipo = listTipos.Find(x => x.IDContribuicaoTipo == IDTipo);

				if (tipo.ComAtividade)
				{
					txtReuniao.Enabled = true;
					btnSetReuniao.Enabled = true;
				}
				else
				{
					txtReuniao.Enabled = false;
					btnSetReuniao.Enabled = false;
					txtReuniao.Clear();
					_contribuicao.IDReuniao = null;
				}

				if (tipo.ComCampanha)
				{
					txtCampanha.Enabled = true;
					btnSetCampanha.Enabled = true;
				}
				else
				{
					txtCampanha.Enabled = false;
					btnSetCampanha.Enabled = false;
					txtCampanha.Clear();
					_contribuicao.IDCampanha = null;
				}

				if (tipo.ComOrigem)
				{
					txtContribuinte.Enabled = true;
					btnSetContribuinte.Enabled = true;
				}
				else
				{
					txtContribuinte.Enabled = false;
					btnSetContribuinte.Enabled = false;
					txtContribuinte.Clear();
					_contribuicao.IDContribuinte = null;
				}
			}

			// change labels color
			Action<Control, Label> ChangeLblColor = (ctrl, lbl) =>
			{
				lbl.ForeColor = ctrl.Enabled ? Color.Black : Color.Silver;
			};

			ChangeLblColor(txtReuniao, lblReuniao);
			ChangeLblColor(txtCampanha, lblCampanha);
			ChangeLblColor(txtContribuinte, lblContribuinte);

		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDContribuicao", true);
			txtEntradaForma.DataBindings.Add("Text", bind, "EntradaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorBruto.DataBindings.Add("Text", bind, "ValorBruto", true, DataSourceUpdateMode.OnPropertyChanged);
			txtContribuicaoTipo.DataBindings.Add("Text", bind, "ContribuicaoTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtConta.DataBindings.Add("Text", bind, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			txtContribuinte.DataBindings.Add("Text", bind, "Contribuinte", true, DataSourceUpdateMode.OnPropertyChanged);
			txtOrigemDescricao.DataBindings.Add("Text", bind, "OrigemDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtReuniao.DataBindings.Add("Text", bind, "Reuniao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCampanha.DataBindings.Add("Text", bind, "Campanha", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtValorBruto.DataBindings["Text"].Format += FormatCurrency;

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
				AbrirDialog("Esse registro de Contribuição não pode ser alterado... \n" +
							"O formulário será fechado, e não será salvo.",
							"Registro Alterado", DialogType.OK, DialogIcon.Exclamation);
				bind.CancelEdit();
				defContribuicaoTipo(_contribuicao.IDContribuicaoTipo);
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			if (!Modal)
				new frmContribuicaoListagem() { MdiParent = Application.OpenForms[0] }.Show();

			Close();
		}

		// CANCELAR ALTERACAO
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de um novo registro?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					var frmList = new frmContribuicaoListagem();
					frmList.MdiParent = Application.OpenForms[0];
					frmList.Show();
					Close();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bind.CancelEdit();
				defContribuicaoTipo(_contribuicao.IDContribuicaoTipo);
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
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

			_contribuicao = new objContribuicao(null);

			// define DEFAULT DATE
			_contribuicao.ContribuicaoData = contaSelected.BloqueioData ?? DateTime.Today;

			Sit = EnumFlagEstado.NovoRegistro;
			bind.DataSource = _contribuicao;
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

				//--- define FORMA
				object forma = null;

				//--- check Cartao | Cheque
				if (_contribuicao.IDEntradaForma == 3) // cartao
				{
					var cartao = new objContribuicaoCartao(null);
					var frm = new frmContribuicaoCartao(ref cartao, this);

					frm.ShowDialog();
					if (frm.DialogResult == DialogResult.Cancel) return;

					forma = cartao;
				}
				else if (_contribuicao.IDEntradaForma == 2) // cheque 
				{
					var cheque = new objContribuicaoCheque(null);
					var frm = new frmContribuicaoCheque(ref cheque, this);

					frm.ShowDialog();
					if (frm.DialogResult == DialogResult.Cancel) return;

					forma = cheque;
				}

				ContribuicaoBLL sBLL = new ContribuicaoBLL();

				//--- SAVE: INSERT
				if (_contribuicao.IDContribuicao == null) //--- save | Insert
				{
					long ID = sBLL.InsertContribuicao(_contribuicao, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate, forma);

					//--- define newID
					_contribuicao.IDContribuicao = ID;
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
										"\nDeseja inserir uma NOVA contribuição?",
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
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Contribuicao..." + "\n" +
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
			if (!VerificaDadosClasse(txtEntradaForma, "Forma da Entrada", _contribuicao, EP)) return false;
			if (!VerificaDadosClasse(txtContribuicaoTipo, "Tipo de Entrada", _contribuicao, EP)) return false;
			if (!VerificaDadosClasse(txtSetor, "Setor de Entrada", _contribuicao, EP)) return false;
			if (!VerificaDadosClasse(txtConta, "Conta de Entrada", _contribuicao, EP)) return false;

			// check VALOR BRUTO
			if (!VerificaDadosClasse(txtValorBruto, "Valor Bruto", _contribuicao, EP)) return false;

			if (_contribuicao.ValorBruto <= 0)
			{
				// message
				AbrirDialog("O valor da contribuição não pode ser igual a zero...\n" +
					"Favor preecher esse campo com um valor maior que zero.", "Valor da Contribuição",
					DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtValorBruto, "Preencha o valor desse campo!");
				// select
				txtValorBruto.Focus();
				// return
				return false;
			}

			// CHECK CONTA BLOCK DATE


			// check CAMPANHA
			bool ComCampanha = listTipos.First(x => x.IDContribuicaoTipo == _contribuicao.IDContribuicaoTipo).ComCampanha;

			if (ComCampanha)
			{
				if (!VerificaDadosClasse(txtCampanha, "Campanha", _contribuicao, EP)) return false;
			}
			else
			{
				_contribuicao.IDCampanha = null;
			}

			// CHECK ATIVIDADE REUNIAO
			bool ComAtividade = listTipos.First(x => x.IDContribuicaoTipo == _contribuicao.IDContribuicaoTipo).ComAtividade;

			if (ComAtividade)
			{
				if (!VerificaDadosClasse(txtReuniao, "Reunião", _contribuicao, EP)) return false;
			}
			else
			{
				_contribuicao.IDReuniao = null;
			}

			// CHECK ORIGEM | CONTRIBUINTE
			bool ComOrigem = listTipos.First(x => x.IDContribuicaoTipo == _contribuicao.IDContribuicaoTipo).ComOrigem;

			if (ComOrigem)
			{
				if (_contribuicao.IDContribuinte == null)
				{
					var resp = AbrirDialog("É necessário informar o CONTRIBUINTE..." +
						"\nDeseja informar Contribuinte ANÔNIMO?",
						"Contribuinte Vazio",
						DialogType.SIM_NAO,
						DialogIcon.Question,
						DialogDefaultButton.Second);

					if (resp == DialogResult.Yes)
					{
						_contribuicao.IDContribuinte = 0;
						txtContribuinte.Text = "Anônimo";
					}
					else
					{
						return false;
					}
				}
			}
			else
			{
				_contribuicao.IDContribuinte = null;
			}

			// CHECK DESCRICAO
			if (!VerificaDadosClasse(txtOrigemDescricao, "Descrição da Origem", _contribuicao, EP)) return false;

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
					txtEntradaForma,
					txtCampanha,
					txtConta,
					txtContribuinte,
					txtContribuicaoTipo,
					txtReuniao,
					txtSetor,
					txtOrigemDescricao
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

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtEntradaForma":
						btnSetEntradaForma_Click(sender, new EventArgs());
						break;
					case "txtContribuicaoTipo":
						btnSetContribuicaoTipo_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtContribuinte":
						btnSetContribuinte_Click(sender, new EventArgs());
						break;
					case "txtReuniao":
						btnSetReuniao_Click(sender, new EventArgs());
						break;
					case "txtCampanha":
						btnSetCampanha_Click(sender, new EventArgs());
						break;
					case "txtOrigemDescricao":
						defineDescricao();
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtContribuinte":
						if (_contribuicao.IDContribuinte != null) Sit = EnumFlagEstado.Alterado;
						txtContribuinte.Clear();
						_contribuicao.IDContribuinte = null;
						break;
					case "txtReuniao":
						if (_contribuicao.IDReuniao != null) Sit = EnumFlagEstado.Alterado;
						txtReuniao.Clear();
						_contribuicao.IDReuniao = null;
						break;
					case "txtCampanha":
						if (_contribuicao.IDCampanha != null) Sit = EnumFlagEstado.Alterado;
						txtCampanha.Clear();
						_contribuicao.IDCampanha = null;
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesLiberados = {
					txtEntradaForma,
					txtContribuicaoTipo,
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
			else if (ctr.Name == "txtContribuinte" && ((e.KeyCode == Keys.D0) | (e.KeyCode >= Keys.NumPad0)))
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
					txtEntradaForma,
					txtCampanha,
					txtConta,
					txtContribuinte,
					txtContribuicaoTipo,
					txtReuniao,
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
					case "txtEntradaForma":

						if (listFormas.Count > 0)
						{
							var forma = listFormas.FirstOrDefault(x => x.IDEntradaForma == int.Parse(e.KeyChar.ToString()));

							if (forma == null) return;

							if (forma.IDEntradaForma != _contribuicao.IDEntradaForma)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_contribuicao.IDEntradaForma = (byte)forma.IDEntradaForma;
								txtEntradaForma.Text = forma.EntradaForma;
							}

						}
						break;

					case "txtContribuicaoTipo":

						if (listTipos.Count > 0)
						{
							var tipo = listTipos.FirstOrDefault(x => x.IDContribuicaoTipo == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDContribuicaoTipo != _contribuicao.IDContribuicaoTipo)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_contribuicao.IDContribuicaoTipo = (byte)tipo.IDContribuicaoTipo;
								defContribuicaoTipo(_contribuicao.IDContribuicaoTipo);
								txtContribuicaoTipo.Text = tipo.ContribuicaoTipo;
							}
						}
						break;

					case "txtContribuinte":

						if (int.Parse(e.KeyChar.ToString()) == 0)
						{
							txtContribuinte.Text = "Anônimo";
							_contribuicao.IDContribuinte = 0;
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
			if (!string.IsNullOrEmpty(_contribuicao.OrigemDescricao)) return;

			// Oferta:   TIPO + REUNIAO + DATA
			// dizimo:   TIPO + CONTRIBUINTE
			// CAMPANHA: TIPO + CAMPANHA

			string descricao = _contribuicao.ContribuicaoTipo + " - ";

			if (!string.IsNullOrEmpty(_contribuicao.Contribuinte))
			{
				descricao += _contribuicao.Contribuinte;

				if (!string.IsNullOrEmpty(_contribuicao.Campanha))
					descricao += " - " + _contribuicao.Campanha;
			}
			else if (!string.IsNullOrEmpty(_contribuicao.Campanha))
				descricao += _contribuicao.Campanha;
			else
				descricao += _contribuicao.Reuniao + " - " + _contribuicao.ContribuicaoData.ToShortDateString();

			txtOrigemDescricao.Text = descricao;
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void cmbEntradaMes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				cmbEntradaMes.SelectedValue = _contribuicao.EntradaMes;
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

				frmContaProcura frm = new frmContaProcura(this, _contribuicao.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDConta != frm.propEscolha.IDConta)
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

		private void btnSetEntradaForma_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				if (listFormas.Count == 0)
				{
					AbrirDialog("Não há Formas de Entradas cadastradas...", "Formas de Entrada",
						DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				var dic = listFormas.ToDictionary(x => (int)x.IDEntradaForma, x => x.EntradaForma);

				Main.frmComboLista frm = new Main.frmComboLista(dic, txtEntradaForma, _contribuicao.IDEntradaForma);

				// show form
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					_contribuicao.IDEntradaForma = (byte)frm.propEscolha.Key;
					txtEntradaForma.Text = frm.propEscolha.Value;
				}

				//--- select
				txtEntradaForma.Focus();
				txtEntradaForma.SelectAll();
			}
			else
			{
				//--- check Cartao | Cheque
				if (_contribuicao.IDEntradaForma == 3) // cartao
				{
					var cartao = new objContribuicaoCartao(_contribuicao.IDContribuicao);
					var frm = new frmContribuicaoCartao(ref cartao, this);

					frm.ShowDialog();
				}
				else if (_contribuicao.IDEntradaForma == 2) // cheque 
				{
					var cheque = new objContribuicaoCheque(_contribuicao.IDContribuicao);
					var frm = new frmContribuicaoCheque(ref cheque, this);

					frm.ShowDialog();
				}
			}
		}

		private void btnSetContribuicaoTipo_Click(object sender, EventArgs e)
		{
			if (listFormas == null || listFormas.Count == 0)
			{
				AbrirDialog("Não há Tipos de Entrada cadastrados...", "Tipos de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listTipos.ToDictionary(x => (int)x.IDContribuicaoTipo, x => x.ContribuicaoTipo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtContribuicaoTipo, _contribuicao.IDContribuicaoTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_contribuicao.IDContribuicaoTipo = (byte)frm.propEscolha.Key;
				txtContribuicaoTipo.Text = frm.propEscolha.Value;
				defContribuicaoTipo(_contribuicao.IDContribuicaoTipo);
				txtOrigemDescricao.Clear();
			}

			//--- select
			txtContribuicaoTipo.Focus();
			txtContribuicaoTipo.SelectAll();
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _contribuicao.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDSetor != frm.propEscolha.IDSetor)
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

		private void btnSetContribuinte_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContribuinteListagem frm = new frmContribuinteListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CONTRIBUINTE
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDContribuinte != frm.propEscolha.IDContribuinte)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDContribuinte = (int)frm.propEscolha.IDContribuinte;
					txtContribuinte.Text = frm.propEscolha.Contribuinte;
				}
				else if (frm.DialogResult == DialogResult.Yes) // ADD NEW CONTRIBUINTE
				{
					frmContribuinte frmNovo = new frmContribuinte(new objContribuinte(null), this);
					frmNovo.ShowDialog();

					if (frmNovo.DialogResult == DialogResult.OK)
					{
						if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDContribuinte != frmNovo.propEscolha.IDContribuinte)
							Sit = EnumFlagEstado.Alterado;

						_contribuicao.IDContribuinte = (int)frmNovo.propEscolha.IDContribuinte;
						txtContribuinte.Text = frmNovo.propEscolha.Contribuinte;
					}
				}

				//--- select
				txtContribuinte.Focus();
				txtContribuinte.SelectAll();
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

		private void btnSetReuniao_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- create filter congregacao
				var filter = new KeyValuePair<int, string>((int)contaSelected.IDCongregacao, contaSelected.Congregacao);

				frmCongregacaoReuniaoProcura frm = new frmCongregacaoReuniaoProcura(this, _contribuicao.IDReuniao, filter);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDReuniao != frm.propEscolha.IDReuniao)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDReuniao = (int)frm.propEscolha.IDReuniao;
					txtReuniao.Text = frm.propEscolha.Reuniao;
				}

				//--- select
				txtReuniao.Focus();
				txtReuniao.SelectAll();
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

		private void btnSetCampanha_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmCampanhaProcura frm = new frmCampanhaProcura(this, _contribuicao.IDCampanha);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDCampanha != frm.propEscolha.IDCampanha)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDCampanha = (int)frm.propEscolha.IDCampanha;
					txtCampanha.Text = frm.propEscolha.Campanha;
				}

				//--- select
				txtCampanha.Focus();
				txtCampanha.SelectAll();
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
					AbrirDialog("Conta tipo OPERADORA não é valida para realização de contribuição...",
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
			_contribuicao.IDConta = (int)conta.IDConta;
			_contribuicao.Conta = conta.Conta;
			txtConta.DataBindings["Text"].ReadValue();
			_contribuicao.ContribuicaoData = conta.BloqueioData ?? DateTime.Today;
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
			_contribuicao.IDSetor = (int)setor.IDSetor;
			_contribuicao.Setor = setor.Setor;
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
