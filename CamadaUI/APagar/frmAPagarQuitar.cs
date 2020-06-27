using CamadaBLL;
using CamadaDTO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using System.Collections.Generic;

namespace CamadaUI.APagar
{
	public partial class frmAPagarQuitar : CamadaUI.Modals.frmModFinBorder
	{
		private objAPagar _apagar;
		private Form _formOrigem;
		private objConta ContaSelected;
		private objSetor SetorSelected;
		private decimal maxValue;
		private decimal doValor;
		private List<objAcrescimoMotivo> listMotivos;
		public objMovimentacao propSaida { get; set; }

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarQuitar(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_apagar = pag;
			propSaida = new objMovimentacao(null);

			CarregaComboMes();
			HandlerKeyDownControl(this);
			numSaidaAno.KeyDown += control_KeyDown;
			numSaidaAno.Enter += Control_Enter;

			// get default Conta and Setor
			ContaSelected = ContaPadrao();

			// get SETOR
			if (SetorPadrao().IDSetor == pag.IDSetor)
			{
				SetorSelected = SetorPadrao();
			}
			else
			{
				SetorSelected = GetSetor(pag.IDSetor);
			}

			if (ContaSelected == null | SetorSelected == null) return;

			DefineValoresIniciais();
		}

		// ON SHOW CHECK CONTA AND SETOR
		//------------------------------------------------------------------------------------------------------------
		private void frmAPagarQuitar_Shown(object sender, EventArgs e)
		{
			if (ContaSelected == null | SetorSelected == null)
			{
				AbrirDialog("Conta padrão ou Setor padrão precisam ser definidos...", "Conta | Setor",
					DialogType.OK, DialogIcon.Exclamation);

				DialogResult = DialogResult.Cancel;
			}
		}

		// GET SETOR BY ID
		//------------------------------------------------------------------------------------------------------------
		private objSetor GetSetor(int IDSetor)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				return new SetorBLL().GetSetor(IDSetor);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter o Setor pelo ID..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF MOTIVOS
		//------------------------------------------------------------------------------------------------------------
		private void GetMotivosList()
		{
			try
			{
				if (listMotivos != null) return;

				listMotivos = new List<objAcrescimoMotivo>();

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				listMotivos = new APagarBLL().GetListMotivo(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Motivos de Acréscimo..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// DEFINE OS VALORES INICIAIS
		//------------------------------------------------------------------------------------------------------------
		private void DefineValoresIniciais()
		{
			// define a pagar values
			lblCredor.Text = _apagar.Credor;
			lblDespesaDescricao.Text = _apagar.DespesaDescricao;
			propSaida.IDConta = (int)ContaSelected.IDConta;
			propSaida.Conta = ContaSelected.Conta;
			txtConta.Text = ContaSelected.Conta;
			propSaida.IDSetor = (int)SetorSelected.IDSetor;
			propSaida.Setor = SetorSelected.Setor;
			lblSetor.Text = SetorSelected.Setor;
			lblContaDetalhe.Text = $"Saldo da Conta: {ContaSelected.ContaSaldo.ToString("c")} \n" +
				$"Data de Bloqueio até: {ContaSelected.BloqueioData?.ToString() ?? ""}";

			// define data padrao
			propSaida.MovData = DataPadrao(); ;
			txtSaidaDia.Text = propSaida.MovData.Day.ToString("D2");
			cmbSaidaMes.SelectedValue = propSaida.MovData.Month;
			numSaidaAno.Value = propSaida.MovData.Year;

			// define year dates
			int actualYear = DateTime.Today.Year;
			if (numSaidaAno.Value > actualYear) numSaidaAno.Value = actualYear;
			numSaidaAno.Maximum = DateTime.Today.Year;
			if (numSaidaAno.Value < 2000) numSaidaAno.Value = 2000;
			numSaidaAno.Minimum = 2000;

			// define maxvalue and acrescimo
			txtAcrescimo.Text = 0.ToString("c");
			maxValue = _apagar.APagarValor - _apagar.ValorDesconto - _apagar.ValorPago;
			doValor = maxValue;
			txtDoValor.Text = maxValue.ToString("c");
			lblSaidaValor.Text = maxValue.ToString("c");
			propSaida.MovValor = maxValue;

			txtDoValor.Validated += (a, b) => DefineMovValor();
			txtAcrescimo.Validated += (a, b) => DefineMovValor();

			lblAPagarValor.Text = _apagar.APagarValor.ToString("c");
			lblValorDesconto.Text = _apagar.ValorDesconto.ToString("c");
			lblValorPago.Text = _apagar.ValorPago.ToString("c");
			lblValorEmAberto.Text = maxValue.ToString("c");
		}

		private void DefineMovValor()
		{
			propSaida.MovValor = doValor + (propSaida.AcrescimoValor == null ? 0 : (decimal)propSaida.AcrescimoValor);
			lblSaidaValor.Text = propSaida.MovValor.ToString("c");
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
			string[] EnumValues = new CultureInfo("pt-BR").DateTimeFormat.MonthNames;
			int i = 1;

			// insert all item of EnumAgendaRecorrencia in datatable
			foreach (var mes in EnumValues)
			{
				if (string.IsNullOrEmpty(mes)) continue;
				dtMeses.Rows.Add(new object[] { i, mes });
				i++;
			}

			//--- Set DataTable
			cmbSaidaMes.DataSource = dtMeses;
			cmbSaidaMes.ValueMember = "ID";
			cmbSaidaMes.DisplayMember = "Mes";
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTONS FUNCTION

		private void btnQuitar_Click(object sender, EventArgs e)
		{
			if (VerificaValores()) return;

			propSaida.MovTipo = 2;
			propSaida.Conta = txtConta.Text;
			propSaida.Setor = lblSetor.Text;
			propSaida.Origem = EnumMovOrigem.APagar; // ORIGEM DESPESA
			propSaida.IDOrigem = (long)_apagar.IDAPagar;
			propSaida.ImagemPath = null;
			propSaida.Observacao = txtObservacao.Text.Length == 0 ? null : txtObservacao.Text;

			DialogResult = DialogResult.OK;
		}

		private bool VerificaValores()
		{
			// Check conta e setor values
			if (SetorSelected == null || ContaSelected == null)
			{
				AbrirDialog("Favor definir a Conta e o Setor de Débito para o pagamento...",
					"Conta e Setor", DialogType.OK, DialogIcon.Exclamation);
				txtConta.Focus();
				return false;
			}

			// Check conta Saldo
			if (propSaida.MovValor + (propSaida.AcrescimoValor ?? 0) > ContaSelected.ContaSaldo)
			{
				AbrirDialog("A Conta de Débito selecionada não possui saldo suficiente para realização do pagamento...",
							"Saldo da Conta", DialogType.OK, DialogIcon.Exclamation);
				txtConta.Focus();
				return false;
			}

			// Check conta Data Bloqueio
			if (ContaSelected.BloqueioData != null && propSaida.MovData < ContaSelected.BloqueioData)
			{
				AbrirDialog("A Conta de Débito se encontra bloqueada na Data de pagamento selecionada...",
							"Data de Bloqueio", DialogType.OK, DialogIcon.Exclamation);
				txtConta.Focus();
				return false;
			}

			return true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, propSaida.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					propSaida.IDConta = (int)frm.propEscolha.IDConta;
					propSaida.Conta = frm.propEscolha.Conta;
					txtConta.Text = frm.propEscolha.Conta;
					lblContaDetalhe.Text = $"Saldo da Conta: {frm.propEscolha.ContaSaldo.ToString("c")} \n" +
						$"Data de Bloqueio até: {frm.propEscolha.BloqueioData?.ToString() ?? ""}";
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

		private void btnSetMotivo_Click(object sender, EventArgs e)
		{
			// get list
			GetMotivosList();

			if (listMotivos == null || listMotivos.Count == 0)
			{
				AbrirDialog("Não há Motivos de Acréscimo cadastrados...", "Motivos de Acréscimo",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listMotivos.ToDictionary(x => (int)x.IDAcrescimoMotivo, x => x.AcrescimoMotivo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtAcrescimoMotivo, propSaida.IDAcrescimoMotivo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				propSaida.IDAcrescimoMotivo = (byte)frm.propEscolha.Key;
				propSaida.AcrescimoMotivo = frm.propEscolha.Value;
				txtAcrescimoMotivo.Text = frm.propEscolha.Value;
			}

			//--- select
			txtAcrescimoMotivo.Focus();
			txtAcrescimoMotivo.SelectAll();
		}

		#endregion // BUTTONS FUNCTION --- END

		#region CONTROLS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtConta, txtAcrescimoMotivo
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtAcrescimoMotivo":
						btnSetMotivo_Click(sender, new EventArgs());
						break;
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
				Control[] controlesBloqueados = { txtConta, txtAcrescimoMotivo };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		private void control_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			};
		}

		private void Control_Enter(object sender, EventArgs e)
		{
			numSaidaAno.Select(0, 4);
		}

		// CHECK MAX VALUE OF A APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void txtDoValor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			decimal newValor = decimal.Parse(txtDoValor.Text, NumberStyles.Currency);

			if (newValor > maxValue)
			{
				AbrirDialog($"O valor do pagamento não pode ser maior que o valor EM ABERTO da despesa: {maxValue.ToString("c")}\n" +
					$"O valor excedente será inserido automativamente nos acrescimos cobrados.",
					"Valor Maior...", DialogType.OK, DialogIcon.Exclamation);
				e.Cancel = true;
				txtDoValor.Text = maxValue.ToString("c");
				txtAcrescimo.Text = (newValor - maxValue).ToString("c");
				txtAcrescimo.Focus();
			}
			else if (newValor != doValor)
			{
				doValor = newValor;
				txtDoValor.Text = doValor.ToString("c");
			}
		}

		// CHECK ACRESCIMO AND FORMAT UPDATED VALUE
		//------------------------------------------------------------------------------------------------------------
		private void txtAcrescimo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			decimal newValor = decimal.Parse(txtAcrescimo.Text, NumberStyles.Currency);
			propSaida.AcrescimoValor = newValor;

			if (newValor != 0)
			{
				txtAcrescimoMotivo.Enabled = true;
				btnSetMotivo.Enabled = true;
				lblAcrescimoMotivo.ForeColor = Color.Black;
			}
			else
			{
				txtAcrescimoMotivo.Enabled = false;
				btnSetMotivo.Enabled = false;
				lblAcrescimoMotivo.ForeColor = Color.Silver;
			}
		}

		// DATE VALIDATING
		//------------------------------------------------------------------------------------------------------------
		private void txtData_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// format new Date
			string testDate = $"{txtSaidaDia.Text}/{cmbSaidaMes.SelectedValue}/{numSaidaAno.Value}";

			// check new date
			if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
			{
				propSaida.MovData = newDate;
			}
			else
			{
				AbrirDialog($"Data inválida:\n" +
					$"{ testDate }\n" +
					$"Favor verificar o dia, mês e ano e inserir uma data válida.",
					"Data Inválida", DialogType.OK, DialogIcon.Exclamation);
				e.Cancel = true;
			}
		}

		#endregion // CONTROLS --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;

			}
		}

		// CONTROLA TOOLTIP
		//------------------------------------------------------------------------------------------------------------
		private void ShowToolTip(Control control)
		{
			//--- Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip();

			//--- Define o delay para a ToolTip.
			toolTip1.AutoPopDelay = 2000;
			toolTip1.InitialDelay = 2000;
			toolTip1.ReshowDelay = 500;
			toolTip1.IsBalloon = true;
			toolTip1.UseAnimation = true;
			toolTip1.UseFading = true;

			if (string.IsNullOrEmpty(control.Tag.ToString()))
				toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000);
			else
				toolTip1.Show(control.Tag.ToString(), control, control.Width - 30, -40, 2000);
		}

		private void btnProcurar_EnabledChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;

			if (control.Enabled == true)
				ShowToolTip(control);
		}







		#endregion // DESIGN FORM FUNCTIONS --- END
	}
}
