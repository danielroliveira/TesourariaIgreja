using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Caixa
{
	public partial class frmAjusteCaixa : CamadaUI.Modals.frmModFinBorder
	{
		private Form _formOrigem;
		private decimal _maxValue;
		public decimal propAjusteValue { get; set; }

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmAjusteCaixa(decimal maxValue, string conta, Form formOrigem)
		{
			InitializeComponent();

			_maxValue = maxValue;
			_formOrigem = formOrigem;
			lblConta.Text = conta;

			txtAjusteValue.Text = maxValue.ToString("c");

			HandlerKeyDownControl(this);
		}

		#endregion

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (decimal.TryParse(txtAjusteValue.Text, NumberStyles.Currency, new CultureInfo("pt-BR"), out decimal ajuste))
			{
				if (ajuste == _maxValue || ajuste < 0)
				{
					AbrirDialog($"O valor do ajuste deve ser diferente de: {_maxValue:c}",
						"Ajuste de Caixa",
						DialogType.OK,
						DialogIcon.Exclamation);
					return;
				}

				propAjusteValue = ajuste - _maxValue;
				DialogResult = DialogResult.OK;
			}
			else
			{
				AbrirDialog("Favor entrar com um valor válido para o ajuste de Caixa...",
					"Ajuste de Caixa");
			}
		}

		// FECHAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region DESIGN FORM FUNCTIONS

		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END

	}
}
