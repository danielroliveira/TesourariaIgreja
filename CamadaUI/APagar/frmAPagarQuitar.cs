using CamadaBLL;
using CamadaDTO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarQuitar : CamadaUI.Modals.frmModFinBorder
	{
		private objAPagar _apagar;
		private Form _formOrigem;
		private objConta ContaPadrao;
		private objSetor SetorPadrao;
		private decimal maxValue;
		private decimal doValor;
		public objSaida propSaida { get; set; }

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarQuitar(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_apagar = pag;
			propSaida = new objSaida(null);

			CarregaComboMes();
			HandlerKeyDownControl(this);
			numSaidaAno.KeyDown += control_KeyDown;
			numSaidaAno.Enter += Control_Enter;

			// get default Conta and Setor
			ContaPadrao = ((frmPrincipal)Application.OpenForms[0]).propContaPadrao.ShallowCopy();

			// get SETOR
			if (((frmPrincipal)Application.OpenForms[0]).propSetorPadrao.IDSetor == pag.IDSetor)
			{
				SetorPadrao = ((frmPrincipal)Application.OpenForms[0]).propSetorPadrao.ShallowCopy();
			}
			else
			{
				SetorPadrao = GetSetor(pag.IDSetor);
			}

			if (ContaPadrao == null | SetorPadrao == null) return;

			DefineValoresIniciais();
		}

		// ON SHOW CHECK CONTA AND SETOR
		//------------------------------------------------------------------------------------------------------------
		private void frmAPagarQuitar_Shown(object sender, EventArgs e)
		{
			if (ContaPadrao == null | SetorPadrao == null)
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

		// DEFINE OS VALORES INICIAIS
		//------------------------------------------------------------------------------------------------------------
		private void DefineValoresIniciais()
		{
			// define a pagar values
			lblCredor.Text = _apagar.Credor;
			lblDespesaDescricao.Text = _apagar.DespesaDescricao;
			propSaida.IDConta = (int)ContaPadrao.IDConta;
			propSaida.Conta = ContaPadrao.Conta;
			txtConta.Text = ContaPadrao.Conta;
			propSaida.IDSetor = (int)SetorPadrao.IDSetor;
			propSaida.Setor = SetorPadrao.Setor;
			lblSetor.Text = SetorPadrao.Setor;
			lblContaDetalhe.Text = $"Saldo da Conta: {ContaPadrao.ContaSaldo.ToString("c")} \n" +
				$"Data de Bloqueio até: {ContaPadrao.BloqueioData?.ToString() ?? ""}";

			// define data padrao
			propSaida.SaidaData = ((frmPrincipal)Application.OpenForms[0]).propDataPadrao;
			txtSaidaDia.Text = propSaida.SaidaData.Day.ToString("D2");
			cmbSaidaMes.SelectedValue = propSaida.SaidaData.Month;
			numSaidaAno.Value = propSaida.SaidaData.Year;

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
			propSaida.SaidaValor = maxValue;

			txtDoValor.Validated += (a, b) => DefineSaidaValor();
			txtAcrescimo.Validated += (a, b) => DefineSaidaValor();

			lblAPagarValor.Text = _apagar.APagarValor.ToString("c");
			lblValorDesconto.Text = _apagar.ValorDesconto.ToString("c");
			lblValorPago.Text = _apagar.ValorPago.ToString("c");
			lblValorEmAberto.Text = maxValue.ToString("c");
		}

		private void DefineSaidaValor()
		{
			propSaida.SaidaValor = doValor + (propSaida.AcrescimoValor == null ? 0 : (decimal)propSaida.AcrescimoValor);
			lblSaidaValor.Text = propSaida.SaidaValor.ToString("c");
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
			//propSaida.AcrescimoValor = 
			//propSaida.IDConta = 
			//propSaida.IDSetor =
			//propSaida.SaidaData =
			//propSaida.SaidaValor = 

			propSaida.Conta = txtConta.Text;
			propSaida.Setor = lblSetor.Text;
			propSaida.Origem = 1; // ORIGEM DESPESA
			propSaida.IDOrigem = (long)_apagar.IDAPagar;
			propSaida.Imagem = false;
			propSaida.Observacao = txtObservacao.Text.Length == 0 ? null : txtObservacao.Text;

			DialogResult = DialogResult.OK;
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
					txtConta,
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
				Control[] controlesBloqueados = { txtConta, };

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
			txtAcrescimo.Text = newValor.ToString("c");
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
				propSaida.SaidaData = newDate;
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
