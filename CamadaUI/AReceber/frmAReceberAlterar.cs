using CamadaDTO;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.AReceber
{
	public partial class frmAReceberAlterar : CamadaUI.Modals.frmModFinBorder
	{
		objAReceber _areceber;
		BindingSource bind = new BindingSource();
		Form _formOrigem;

		#region SUB NEW | CONSTRUCTOR
		public frmAReceberAlterar(objAReceber pag, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_areceber = pag;

			bind.DataSource = _areceber;
			BindingCreator();

			HandlerKeyDownControl(this);
			_areceber.PropertyChanged += (a, b) => btnAlterar.Enabled = true;

			if (_areceber.IDEntradaForma != 3)
			{
				txtValorLiquido.KeyPress += (a, e) => e.Handled = true;
			}

		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDINGS

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAReceber", true);
			lblEntradaForma.DataBindings.Add("Text", bind, "EntradaForma", true);
			lblContaProvisoria.DataBindings.Add("Text", bind, "Conta", true);
			txtValorRecebido.DataBindings.Add("Text", bind, "ValorRecebido", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorBruto.DataBindings.Add("Text", bind, "ValorBruto", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorLiquido.DataBindings.Add("Text", bind, "ValorLiquido", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpCompensacaoData.DataBindings.Add("Value", bind, "CompensacaoData", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtValorLiquido.DataBindings["Text"].Format += FormatCurrency;
			txtValorRecebido.DataBindings["Text"].Format += FormatCurrency;
			txtValorBruto.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			if (e.Value == DBNull.Value || e.Value == null)
			{
				e.Value = "NOVO";
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

		#endregion // DATABINDINGS --- END

		#region BUTTONS FUNCTION

		// CLOSE | CANCELAR
		//------------------------------------------------------------------------------------------------------------
		private void btnClose_Click(object sender, EventArgs e)
		{
			AutoValidate = AutoValidate.Disable;
			DialogResult = DialogResult.Cancel;
		}

		// ALTERAR | OK
		//------------------------------------------------------------------------------------------------------------
		private void btnAlterar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		#endregion // BUTTONS FUNCTION --- END

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

		#endregion // DESIGN FORM FUNCTIONS --- END

		#region VALIDA VALOR LIQUIDO

		private void txtValorLiquido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			decimal newValor = decimal.Parse(txtValorLiquido.Text, NumberStyles.Currency);

			//--- verifica se o novo valor liquido é menor que o valor bruto
			if (newValor > _areceber.ValorBruto)
			{
				AbrirDialog("O Valor LÍQUIDO a receber não pode ser maior que o VALOR BRUTO...",
							"Alterar Valor Líquido",
							DialogType.OK,
							DialogIcon.Exclamation);
				e.Cancel = true;
			}

			//--- verifica se o novo valor liquido é maior que o valor recebido
			if (newValor <= _areceber.ValorRecebido)
			{
				AbrirDialog("O Valor LÍQUIDO a receber deve ser menor que o VALOR RECEBIDO...",
							"Alterar Valor Líquido",
							DialogType.OK,
							DialogIcon.Exclamation);
				e.Cancel = true;
			}

		}

		#endregion // VALIDA DESCONTO --- END

	}
}
