using CamadaBLL;
using CamadaDTO;
using CamadaUI.Contas;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Transferencias
{
	public partial class frmTransferencia : Modals.frmModFinBorder
	{
		TransferenciaBLL tBLL = new TransferenciaBLL();
		private objTransfConta _transf;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private objConta contaEntrada;
		private objConta contaSaida;

		private ErrorProvider EP = new ErrorProvider(); // default error provider
		private Form _formOrigem;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmTransferencia(objTransfConta transferencia, Form formOrigem = null)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			ConstructorContinue(transferencia);
		}

		public frmTransferencia(long IDTransfConta)
		{
			InitializeComponent();
			var cont = GetTransfByID(IDTransfConta);

			if (cont == null) return;

			ConstructorContinue(cont);
		}

		// CONTRUCTOR CONTINUE
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objTransfConta transferencia)
		{
			_transf = transferencia;

			// binding
			bind.DataSource = typeof(objTransfConta);
			bind.Add(_transf);
			BindingCreator();

			if (_transf.IDTransfConta == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// define DEFAULT DATE
			_transf.Transferencia.TransferenciaData = DataPadrao();

			// handlers
			HandlerKeyDownControl(this);

			numTransferenciaAno.KeyDown += Numeric_KeyDown;
			numTransferenciaAno.Enter += Numeric_Enter;
			numTransferenciaDia.KeyDown += Numeric_KeyDown;
			numTransferenciaDia.Enter += Numeric_Enter;

		}

		// SHOW FORM
		//------------------------------------------------------------------------------------------------------------
		private void frmTransferencia_Shown(object sender, EventArgs e)
		{
			if (_transf == null)
			{
				Close();
				return;
			}

			txtDescricao.Enter += text_Enter;
			txtContaEntrada.Enter += text_Enter;
			txtContaSaida.Enter += text_Enter;

		}

		// GET CONTRIBUICAO BY ID
		//------------------------------------------------------------------------------------------------------------
		private objTransfConta GetTransfByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return tBLL.GetTransfContaByID(ID);
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
					numTransferenciaAno.Maximum = _transf.Transferencia.TransferenciaData.Year;
					numTransferenciaAno.Minimum = _transf.Transferencia.TransferenciaData.Year;
					numTransferenciaDia.Maximum = _transf.Transferencia.TransferenciaData.Day;
					numTransferenciaDia.Minimum = _transf.Transferencia.TransferenciaData.Day;
				}

				// btnSET
				btnSetContaSaida.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetContaEntrada.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDTransfConta", true);
			txtTransferenciaValor.DataBindings.Add("Text", bind, "Transferencia.TransferenciaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtContaEntrada.DataBindings.Add("Text", bind, "ContaEntrada", true, DataSourceUpdateMode.OnPropertyChanged);
			txtContaSaida.DataBindings.Add("Text", bind, "ContaSaida", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDescricao.DataBindings.Add("Text", bind, "Descricao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtTransferenciaValor.DataBindings["Text"].Format += FormatCurrency;

			// CARREGA COMBO
			CarregaComboMes();

			// ADD NAMED BINDINGS TO CONTROL ERROS
			//------------------------------------------------------------------------------------------------------------
			Binding bndEntradaMes = cmbTransferenciaMes.DataBindings.Add("SelectedValue", bind, "Transferencia.TransferenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaDia = numTransferenciaDia.DataBindings.Add("Text", bind, "Transferencia.TransferenciaDia", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaAno = numTransferenciaAno.DataBindings.Add("Text", bind, "Transferencia.TransferenciaAno", true, DataSourceUpdateMode.OnPropertyChanged);

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
				new frmTransferenciasListagem().Show();
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
				long newID = tBLL.InsertTranferenciaConta(_transf, ContaSaldoLocalUpdate);
				_transf.IDTransfConta = newID;
				bind.ResetBindings(false);
				bind.EndEdit();
				Sit = EnumFlagEstado.RegistroSalvo;

				//--- INFORM SUCESS ask user NEW REGISTRY
				var resp = AbrirDialog("Transferência Efetuada com sucesso!\n" +
					"Deseja Realizar outra Transferência entre contas?", "Tranferência Efetuada",
					DialogType.SIM_NAO, DialogIcon.Question);

				btnFechar_Click(sender, e);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Efetuar a Transferência..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				txtContaSaida.Focus();
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
			if (!VerificaDadosClasse(txtContaEntrada, "Setor de Entrada", _transf, EP)) return false;
			if (!VerificaDadosClasse(txtContaSaida, "Conta de Entrada", _transf, EP)) return false;

			// check VALOR
			if (!VerificaDadosClasse(txtTransferenciaValor, "Valor da Transferência", _transf.Transferencia, EP)) return false;

			if (_transf.Transferencia.TransferenciaValor <= 0)
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
			if (_transf.Transferencia.TransferenciaData > DateTime.Today)
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

			// CHECK CONTA ENTRADA BLOCK DATE
			if (contaEntrada == null || contaEntrada.BloqueioData != null)
			{
				if (contaEntrada.BloqueioData > _transf.Transferencia.TransferenciaData)
				{
					AbrirDialog("A Conta de ENTRADA está Bloqueada para movimentação até:\n" +
							$"{((DateTime)contaEntrada.BloqueioData).ToShortDateString()}",
							"Data de Bloqueio",
							DialogType.OK, DialogIcon.Exclamation);
					// error provider
					EP.SetError(txtContaEntrada, "Data de Bloqueio");
					// select
					txtContaEntrada.Focus();
					// return
					return false;
				}
			}

			// CHECK CONTA SAIDA BLOCK DATE
			if (contaSaida == null || contaSaida.BloqueioData != null)
			{
				if (contaSaida.BloqueioData > _transf.Transferencia.TransferenciaData)
				{
					AbrirDialog("A Conta de SAÍDA está Bloqueada para movimentação até:\n" +
							$"{((DateTime)contaSaida.BloqueioData).ToShortDateString()}",
							"Data de Bloqueio",
							DialogType.OK, DialogIcon.Exclamation);
					// error provider
					EP.SetError(txtContaSaida, "Data de Bloqueio");
					// select
					txtContaSaida.Focus();
					// return
					return false;
				}
			}

			// CHECK DESCRICAO
			if (!VerificaDadosClasse(txtDescricao, "Descrição da Origem", _transf, EP)) return false;

			// check SALDO VALOR
			if (contaSaida.ContaSaldo < _transf.Transferencia.TransferenciaValor)
			{
				AbrirDialog("A Conta de SAÍDA não possui SALDO suficiente para realização dessa transferência...\n" +
							$"Valor Máximo: {contaSaida.ContaSaldo:c}",
							"Data de Bloqueio",
							DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtTransferenciaValor, "Valor excede o Saldo da Conta");
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
					txtContaSaida,
					txtContaEntrada,
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
					case "txtContaSaida":
						btnSetContaSaida_Click(sender, new EventArgs());
						break;
					case "txtContaEntrada":
						btnSetContaEntrada_Click(sender, new EventArgs());
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
					txtContaSaida,
					txtContaEntrada };

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

			if (string.IsNullOrEmpty(_transf.ContaEntrada) || string.IsNullOrEmpty(_transf.ContaSaida))
			{
				AbrirDialog("FAvor preencher a Conta de ENTRADA e a Conta de SAÍDA",
					"Preencher campo", DialogType.OK, DialogIcon.Information);
				return;
			}

			string descricao = $"Transferência de {_transf.ContaSaida} para {_transf.ContaEntrada}";
			txtDescricao.Text = descricao;
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void cmbEntradaMes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				cmbTransferenciaMes.SelectedValue = _transf.Transferencia.TransferenciaMes;
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
		private void btnSetContaSaida_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContaProcura frm = new frmContaProcura(this, _transf.IDContaSaida);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					// check same CONTA ENTRADA SAIDA
					if (frm.propEscolha.IDConta == _transf.IDContaEntrada)
					{
						AbrirDialog("A conta de Saída não pode ser igual à conta de Entrada...",
							"Conta de Saída", DialogType.OK, DialogIcon.Exclamation);
						return;
					}

					if (Sit != EnumFlagEstado.NovoRegistro && _transf.IDContaSaida != frm.propEscolha.IDConta)
						Sit = EnumFlagEstado.Alterado;

					_transf.IDContaSaida = (int)frm.propEscolha.IDConta;
					txtContaSaida.Text = frm.propEscolha.Conta;
					contaSaida = frm.propEscolha;
					lblContaSaidaDetalhe.Text = $"Saldo da Conta: {frm.propEscolha.ContaSaldo.ToString("c")} \n" +
									$"Data de Bloqueio até: {frm.propEscolha.BloqueioData?.ToString() ?? ""}";
				}

				//--- select
				txtContaSaida.Focus();
				txtContaSaida.SelectAll();
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

		private void btnSetContaEntrada_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContaProcura frm = new frmContaProcura(this, _transf.IDContaEntrada);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					// check same CONTA ENTRADA SAIDA
					if (frm.propEscolha.IDConta == _transf.IDContaSaida)
					{
						AbrirDialog("A conta de Entrada não pode ser igual à conta de Saída...",
							"Conta de Entrada", DialogType.OK, DialogIcon.Exclamation);
						return;
					}

					if (Sit != EnumFlagEstado.NovoRegistro && _transf.IDContaEntrada != frm.propEscolha.IDConta)
						Sit = EnumFlagEstado.Alterado;

					_transf.IDContaEntrada = (int)frm.propEscolha.IDConta;
					txtContaEntrada.Text = frm.propEscolha.Conta;
					contaEntrada = frm.propEscolha;
					lblContaEntradaDetalhe.Text = $"Saldo da Conta: {frm.propEscolha.ContaSaldo.ToString("c")} \n" +
							$"Data de Bloqueio até: {frm.propEscolha.BloqueioData?.ToString() ?? ""}";
				}

				//--- select
				txtContaEntrada.Focus();
				txtContaEntrada.SelectAll();
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
