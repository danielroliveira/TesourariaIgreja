using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.AReceber
{
	public partial class frmAReceberQuitar : CamadaUI.Modals.frmModFinBorder
	{
		private List<objAReceber> _recList;
		private Form _formOrigem;
		private objConta ContaPadrao;
		private objConta ContaDefinida;
		private objSetor SetorPadrao;
		private decimal doValor;
		private decimal vlBruto;
		private decimal vlLiquido;
		private decimal vlRecebido;
		private decimal vlEmAberto;
		private decimal maxValue;
		private DateTime _entradaData;
		private ErrorProvider eP = new ErrorProvider();

		// property to response
		public List<objEntrada> entradasList = new List<objEntrada>();

		#region SUB NEW | CONSTRUCTOR
		public frmAReceberQuitar(List<objAReceber> recList, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_recList = recList;
			if (_recList.Count > 1) lblTitulo.Text = "Gerar Entradas - A Receber (em LOTE)";

			CarregaComboMes();
			numEntradaAno.KeyDown += control_KeyDown;
			numEntradaAno.Enter += Control_Enter;

			// get default Conta and Setor
			ContaPadrao = ((frmPrincipal)Application.OpenForms[0]).propContaPadrao;
			SetorPadrao = ((frmPrincipal)Application.OpenForms[0]).propSetorPadrao;

			if (ContaPadrao == null | SetorPadrao == null) return;

			ContaDefinida = ContaPadrao.GetCopyOf();

			HandlerKeyDownControl(this);
			DefineValoresIniciais();
			DefineEntradasList();
		}

		// ON SHOW CHECK CONTA AND SETOR
		//------------------------------------------------------------------------------------------------------------
		private void frmAReceberQuitar_Shown(object sender, EventArgs e)
		{
			if (ContaPadrao == null | SetorPadrao == null)
			{
				AbrirDialog("Conta padrão ou Setor padrão precisam ser definidos...", "Conta | Setor",
					DialogType.OK, DialogIcon.Exclamation);

				DialogResult = DialogResult.Cancel;
			}
		}

		// DEFINE ENTRADAS ITENS
		//------------------------------------------------------------------------------------------------------------
		private void DefineEntradasList()
		{
			foreach (objAReceber rec in _recList)
			{
				entradasList.Add(new objEntrada(null)
				{
					Conta = ContaPadrao.Conta,
					IDConta = (int)ContaPadrao.IDConta,
					IDSetor = rec.IDSetor,
					IDOrigem = (int)rec.IDAReceber,
					Origem = 2,
					EntradaData = _entradaData,
					EntradaValor = rec.ValorLiquido - rec.ValorRecebido,
				});
			}
		}

		// DEFINE OS VALORES INICIAIS
		//------------------------------------------------------------------------------------------------------------
		private void DefineValoresIniciais()
		{
			// define a pagar values
			lblEntradaForma.Text = _recList.First().EntradaForma;
			lblContaProvisoria.Text = _recList.First().Conta;
			txtConta.Text = ContaPadrao.Conta;
			lblContaDetalhe.Text = $"Saldo da Conta: {ContaPadrao.ContaSaldo.ToString("c")} \n" +
				$"Data de Bloqueio até: {ContaPadrao.BloqueioData?.ToString() ?? ""}";

			// define data padrao
			DateTime datePadrao = ((frmPrincipal)Application.OpenForms[0]).propDataPadrao;
			txtEntradaDia.Text = datePadrao.Day.ToString("D2");
			cmbEntradaMes.SelectedValue = datePadrao.Month;
			numEntradaAno.Value = datePadrao.Year;

			// define MAX and MIN years numeric
			int actualYear = DateTime.Today.Year;
			if (numEntradaAno.Value > actualYear) numEntradaAno.Value = actualYear;
			numEntradaAno.Maximum = DateTime.Today.Year;
			if (numEntradaAno.Value < 2000) numEntradaAno.Value = 2000;
			numEntradaAno.Minimum = 2000;

			// define labels values
			vlBruto = _recList.Sum(r => r.ValorBruto);
			lblValorBruto.Text = vlBruto.ToString("c");
			vlLiquido = _recList.Sum(r => r.ValorLiquido);
			lblValorLiquido.Text = vlLiquido.ToString("c");
			vlRecebido = _recList.Sum(r => r.ValorRecebido);
			lblValorRecebido.Text = vlRecebido.ToString("c");
			vlEmAberto = vlLiquido - vlRecebido;
			lblValorEmAberto.Text = vlEmAberto.ToString("c");
			maxValue = vlBruto - vlRecebido;

			// define default value to pay
			doValor = vlLiquido - vlRecebido;
			txtDoValor.Text = doValor.ToString("c");
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
			cmbEntradaMes.DataSource = dtMeses;
			cmbEntradaMes.ValueMember = "ID";
			cmbEntradaMes.DisplayMember = "Mes";
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTONS FUNCTION

		private void btnReceber_Click(object sender, EventArgs e)
		{
			//check AReceber Value
			if (doValor <= 0)
			{
				AbrirDialog("O Valor total a Receber não pode ficar vazio ou ser igual a Zero...\n" +
					"Favor preencher esse campo...", "Valor a Receber Vazio",
					DialogType.OK, DialogIcon.Exclamation);
				txtDoValor.Focus();
				eP.SetError(txtDoValor, "Valor precisa ser maior que Zero...");
				return;
			}
			else if (doValor > maxValue)
			{
				AbrirDialog($"O Valor total a Receber não pode ser maior que o Valor Bruto " +
					$"subtraído do Valor Recebido: {maxValue:c}\n" +
					"Favor preencher esse campo...", "Valor a Receber Inválido",
					DialogType.OK, DialogIcon.Exclamation);
				txtDoValor.Focus();
				eP.SetError(txtDoValor, "Valor não pode ser maior que o Valor Bruto...");
				return;
			}
			else if (doValor < vlEmAberto)
			{
				AbrirDialog($"O Valor total a Receber não pode ser menor que o " +
					$"Valor Em aberto: {vlEmAberto:c}\n" +
					"Favor preencher esse campo...", "Valor a Receber Inválido",
					DialogType.OK, DialogIcon.Exclamation);
				txtDoValor.Focus();
				eP.SetError(txtDoValor, "Valor não pode ser menor que o Valor Em Aberto...");
				return;
			}

			// valida Data
			ValidaData();

			// calc percent of value
			decimal perc = (doValor - vlLiquido) / vlLiquido;

			// define value of each objEntrada
			foreach (objEntrada entrada in entradasList)
			{
				entrada.EntradaValor += entrada.EntradaValor * perc;
				entrada.EntradaData = _entradaData;

				// change AReceber List
				var rec = _recList.First(r => r.IDAReceber == entrada.IDOrigem);
				rec.ValorRecebido += entrada.EntradaValor;
				rec.IDSituacao = 2;
				rec.Situacao = "Recebido";
			}

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

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, ContaDefinida.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					entradasList.ForEach(ent => ent.IDConta = (int)frm.propEscolha.IDConta);
					ContaDefinida = frm.propEscolha;
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
			numEntradaAno.Select(0, 4);
		}

		// CHECK MAX VALUE OF A APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void txtDoValor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string strDoValor = txtDoValor.Text == string.Empty ? 0.ToString("c") : txtDoValor.Text;
			decimal newValor = decimal.Parse(strDoValor, NumberStyles.Currency);

			if (newValor > maxValue)
			{
				AbrirDialog($"O valor do recebimento não pode ser maior que o valor BRUTO subtraído do valor RECEBIDO: {maxValue.ToString("c")}\n",
					"Valor Maior...", DialogType.OK, DialogIcon.Exclamation);
				e.Cancel = true;
				txtDoValor.Text = maxValue.ToString("c");
			}
			else if (newValor != doValor)
			{
				doValor = newValor;
				txtDoValor.Text = doValor.ToString("c");
			}
		}

		// DATE VALIDATING
		//------------------------------------------------------------------------------------------------------------
		private void txtData_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !ValidaData();
		}

		private bool ValidaData()
		{
			// format new Date
			string testDate = $"{txtEntradaDia.Text}/{cmbEntradaMes.SelectedValue}/{numEntradaAno.Value}";

			// check new date
			if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
			{
				_entradaData = newDate;
				return true;
			}
			else
			{
				AbrirDialog($"Data inválida:\n" +
					$"{ testDate }\n" +
					$"Favor verificar o dia, mês e ano e inserir uma data válida.",
					"Data Inválida", DialogType.OK, DialogIcon.Exclamation);
				return false;
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
