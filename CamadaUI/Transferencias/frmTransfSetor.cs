using CamadaBLL;
using CamadaDTO;
using CamadaUI.Setores;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Transferencias
{
	public partial class frmTransfSetor : Modals.frmModFinBorder
	{
		TransfSetorBLL tBLL = new TransfSetorBLL();
		private objTransfSetor _transf;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private objSetor setorEntrada;
		private objSetor setorSaida;

		private ErrorProvider EP = new ErrorProvider(); // default error provider
		private Form _formOrigem;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmTransfSetor(objTransfSetor transferencia, Form formOrigem = null)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			ConstructorContinue(transferencia);
		}

		public frmTransfSetor(long IDTransfSetor)
		{
			InitializeComponent();
			var cont = GetTransfByID(IDTransfSetor);

			if (cont == null) return;

			ConstructorContinue(cont);
		}

		// CONTRUCTOR CONTINUE
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objTransfSetor transferencia)
		{
			_transf = transferencia;

			// binding
			bind.DataSource = typeof(objTransfSetor);
			bind.Add(_transf);
			BindingCreator();

			if (_transf.IDTransfSetor == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// define DEFAULT DATE
			_transf.TransfData = DataPadrao();

			// handlers
			HandlerKeyDownControl(this);

			numTransferenciaAno.KeyDown += Numeric_KeyDown;
			numTransferenciaAno.Enter += Numeric_Enter;
			numTransferenciaDia.KeyDown += Numeric_KeyDown;
			numTransferenciaDia.Enter += Numeric_Enter;

		}

		// SHOW FORM
		//------------------------------------------------------------------------------------------------------------
		private void frmTransfSetor_Shown(object sender, EventArgs e)
		{
			if (_transf == null)
			{
				Close();
				return;
			}

			txtDescricao.Enter += text_Enter;
			txtSetorEntrada.Enter += text_Enter;
			txtSetorSaida.Enter += text_Enter;
		}

		// GET CONTRIBUICAO BY ID
		//------------------------------------------------------------------------------------------------------------
		private objTransfSetor GetTransfByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return tBLL.GetTransfSetorByID(ID);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Transferência..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
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
					btnSalvar.Enabled = true;
					btnCancelar.Enabled = true;
					lblSitBlock.Visible = false;
				}
				else
				{
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					lblSitBlock.Visible = true;
					numTransferenciaAno.Maximum = _transf.TransfData.Year;
					numTransferenciaAno.Minimum = _transf.TransfData.Year;
					numTransferenciaDia.Maximum = _transf.TransfData.Day;
					numTransferenciaDia.Minimum = _transf.TransfData.Day;
				}

				// btnSET
				btnSetSetorSaida.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetorEntrada.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDTransfSetor", true);
			txtTransferenciaValor.DataBindings.Add("Text", bind, "TransfValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetorEntrada.DataBindings.Add("Text", bind, "SetorEntrada", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetorSaida.DataBindings.Add("Text", bind, "SetorSaida", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDescricao.DataBindings.Add("Text", bind, "Descricao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtTransferenciaValor.DataBindings["Text"].Format += FormatCurrency;

			// CARREGA COMBO
			CarregaComboMes();

			// ADD NAMED BINDINGS TO CONTROL ERROS
			//------------------------------------------------------------------------------------------------------------
			Binding bndEntradaMes = cmbTransferenciaMes.DataBindings.Add("SelectedValue", bind, "TransfMes", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaDia = numTransferenciaDia.DataBindings.Add("Text", bind, "TransfDia", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaAno = numTransferenciaAno.DataBindings.Add("Text", bind, "TransfAno", true, DataSourceUpdateMode.OnPropertyChanged);

			Action<object, BindingCompleteEventArgs, Control> bindComplete = (o, e, c) =>
			{
				if (e.BindingCompleteState != BindingCompleteState.Success)
				{
					AbrirDialog(e.Exception.Message, "Data Inválida", DialogType.OK, DialogIcon.Exclamation);
					numTransferenciaDia.DataBindings["Text"].ReadValue();
					cmbTransferenciaMes.DataBindings["SelectedValue"].ReadValue();
					numTransferenciaAno.DataBindings["Text"].ReadValue();

					if (c.GetType() == typeof(CamadaUC.ucOnlyNumbers)) ((TextBox)c).SelectAll();
				}
			};

			// HANDLERS TO CONTROL ERROS
			bndEntradaDia.BindingComplete += (a, b) => bindComplete(a, b, numTransferenciaDia);
			bndEntradaMes.BindingComplete += (a, b) => bindComplete(a, b, cmbTransferenciaMes);
			bndEntradaAno.BindingComplete += (a, b) => bindComplete(a, b, numTransferenciaAno);
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

		private void RegistroAlterado(bool Alterado)
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
			cmbTransferenciaMes.DataSource = dtMeses;
			cmbTransferenciaMes.ValueMember = "ID";
			cmbTransferenciaMes.DisplayMember = "Mes";
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
				AbrirDialog("Esse registro de Transferência não pode ser alterado... \n" +
							"O formulário será fechado, e não será salvo.",
							"Registro Alterado", DialogType.OK, DialogIcon.Exclamation);
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			if (_formOrigem == null)
			{
				new frmTransfSetorListagem().Show();
			}

			Close();
		}

		// CANCELAR ALTERACAO
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de uma nova Transferência?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					Sit = EnumFlagEstado.RegistroSalvo;
					btnFechar_Click(sender, e);
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

				//--- save Data
				long newID = tBLL.InsertTransferenciaSetor(_transf, SetorSaldoLocalUpdate);
				_transf.IDTransfSetor = newID;
				bind.ResetBindings(false);
				bind.EndEdit();
				Sit = EnumFlagEstado.RegistroSalvo;

				//--- INFORM SUCESS ask user NEW REGISTRY
				var resp = AbrirDialog("Transferência Efetuada com sucesso!\n" +
					"Deseja Realizar outra Transferência entre setores?", "Transferência Efetuada",
					DialogType.SIM_NAO, DialogIcon.Question);

				btnFechar_Click(sender, e);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Efetuar a Transferência..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				txtSetorSaida.Focus();
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
			if (!VerificaDadosClasse(txtSetorEntrada, "Setor de Entrada", _transf, EP)) return false;
			if (!VerificaDadosClasse(txtSetorSaida, "Setor de Entrada", _transf, EP)) return false;

			// check VALOR
			if (!VerificaDadosClasse(txtTransferenciaValor, "Valor da Transferência", _transf, EP)) return false;

			if (_transf.TransfValor <= 0)
			{
				// message
				AbrirDialog("O valor da transferência não pode ser igual a zero...\n" +
					"Favor preecher esse campo com um valor maior que zero.", "Valor da Transferência",
					DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtTransferenciaValor, "Preencha o valor desse campo!");
				// select
				txtTransferenciaValor.Focus();
				// return
				return false;
			}

			// CHECK DATA DA TRANSFERENCIA
			if (_transf.TransfData > DateTime.Today)
			{
				// message
				AbrirDialog("A Data da Transferência não pode ser posterior a data de hoje...\n" +
					"Favor preecher esse com a Data de hoje ou Data anterior",
					"Data da Transferência",
					DialogType.OK,
					DialogIcon.Exclamation);
				// error provider
				EP.SetError(numTransferenciaDia, "Inserir data passada!");
				// select
				numTransferenciaDia.Focus();
				// return
				return false;
			}


			// CHECK DESCRICAO
			if (!VerificaDadosClasse(txtDescricao, "Descrição da Origem", _transf, EP)) return false;

			// check SALDO VALOR
			if (setorSaida.SetorSaldo < _transf.TransfValor)
			{
				AbrirDialog("A Setor de SAÍDA não possui SALDO suficiente para realização dessa transferência...\n" +
							$"Valor Máximo: {setorSaida.SetorSaldo:c}",
							"Data de Bloqueio",
							DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtTransferenciaValor, "Valor excede o Saldo da Setor");
				// select
				txtTransferenciaValor.Focus();
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
					txtSetorSaida,
					txtSetorEntrada,
					txtDescricao
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
					case "txtSetorSaida":
						btnSetSetorSaida_Click(sender, new EventArgs());
						break;
					case "txtSetorEntrada":
						btnSetSetorEntrada_Click(sender, new EventArgs());
						break;
					case "txtDescricao":
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
					default:
						break;
				}
			}
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtSetorSaida,
					txtSetorEntrada };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
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

			if (string.IsNullOrEmpty(_transf.SetorEntrada) || string.IsNullOrEmpty(_transf.SetorSaida))
			{
				AbrirDialog("FAvor preencher a Setor de ENTRADA e a Setor de SAÍDA",
					"Preencher campo", DialogType.OK, DialogIcon.Information);
				return;
			}

			string descricao = $"Transferência de {_transf.SetorSaida} para {_transf.SetorEntrada}";
			txtDescricao.Text = descricao;
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void cmbEntradaMes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				cmbTransferenciaMes.SelectedValue = _transf.TransfMes;
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
		private void btnSetSetorSaida_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _transf.IDSetorSaida);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					// check same SETOR ENTRADA SAIDA
					if (frm.propEscolha.IDSetor == _transf.IDSetorEntrada)
					{
						AbrirDialog("A setor de Saída não pode ser igual à setor de Entrada...",
							"Setor de Saída", DialogType.OK, DialogIcon.Exclamation);
						return;
					}

					if (Sit != EnumFlagEstado.NovoRegistro && _transf.IDSetorSaida != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					_transf.IDSetorSaida = (int)frm.propEscolha.IDSetor;
					txtSetorSaida.Text = frm.propEscolha.Setor;
					setorSaida = frm.propEscolha;
					lblSetorSaidaDetalhe.Text = $"Saldo do Setor: {frm.propEscolha.SetorSaldo.ToString("c")}";
				}

				//--- select
				txtSetorSaida.Focus();
				txtSetorSaida.SelectAll();
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

		private void btnSetSetorEntrada_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _transf.IDSetorEntrada);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					// check same SETOR ENTRADA SAIDA
					if (frm.propEscolha.IDSetor == _transf.IDSetorSaida)
					{
						AbrirDialog("A setor de Entrada não pode ser igual à setor de Saída...",
							"Setor de Entrada", DialogType.OK, DialogIcon.Exclamation);
						return;
					}

					if (Sit != EnumFlagEstado.NovoRegistro && _transf.IDSetorEntrada != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					_transf.IDSetorEntrada = (int)frm.propEscolha.IDSetor;
					txtSetorEntrada.Text = frm.propEscolha.Setor;
					setorEntrada = frm.propEscolha;
					lblSetorEntradaDetalhe.Text = $"Saldo da Setor: {frm.propEscolha.SetorSaldo.ToString("c")}";
				}

				//--- select
				txtSetorEntrada.Focus();
				txtSetorEntrada.SelectAll();
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

		#region TOOLTIP

		private void ShowToolTip(Control controle)
		{
			//Cria a ToolTip e associa com o Form setoriner.
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

		#region VISUAL EFFECTS

		//-------------------------------------------------------------------------------------------------
		//---  CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//-------------------------------------------------------------------------------------------------
		private void frmDateGet_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmDateGet_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // VISUAL EFFECTS --- END

	}
}
