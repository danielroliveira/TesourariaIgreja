using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarSaidas : CamadaUI.Modals.frmModFinBorder
	{
		objAPagar _apagar;
		BindingSource bind = new BindingSource();
		BindingSource bindSaida = new BindingSource();
		List<objSaida> listSaidas = new List<objSaida>();
		Form _formOrigem;
		decimal DescontoAnterior;

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarSaidas(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_apagar = pag;
			bind.DataSource = _apagar;
			BindingCreator();

			DefineValueLabels();
		}

		// GET LIST OF SAIDAS
		//------------------------------------------------------------------------------------------------------------
		private void GetSaidaList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//listFormas = new CobrancaFormaBLL().GetListCobrancaForma(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Saídas/Pagamentos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void DefineValueLabels()
		{
			int atraso = (DateTime.Today - _apagar.Vencimento).Days;
			lblAtrasoDias.Text = atraso < 1 ? "Em Dia" : atraso.ToString("D2") + " dia(s)";
			lblValorEmAberto.Text = (_apagar.APagarValor - _apagar.ValorDesconto - _apagar.ValorPago).ToString("c");
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDINGS

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagar", true);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true);
			lblIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCobrancaForma.DataBindings.Add("Text", bind, "CobrancaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			lblBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			lblVencimento.DataBindings.Add("Text", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			lblAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorDesconto.DataBindings.Add("Text", bind, "ValorDesconto", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorPago.DataBindings.Add("Text", bind, "ValorPago", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorAcrescimo.DataBindings.Add("Text", bind, "ValorAcrescimo", true, DataSourceUpdateMode.OnPropertyChanged);
			lblReferencia.DataBindings.Add("Text", bind, "Referencia", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += (a, e) => e.Value = $"{e.Value: 0000}";
			lblAPagarValor.DataBindings["Text"].Format += FormatCurrency;
			txtValorDesconto.DataBindings["Text"].Format += FormatCurrency;
			lblValorPago.DataBindings["Text"].Format += FormatCurrency;
			lblValorAcrescimo.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		#endregion // DATABINDINGS --- END

		#region BUTTONS FUNCTION

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
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

		#region EDIT DESCONTO

		private void btnConcederDesconto_Click(object sender, EventArgs e)
		{
			DescontoAnterior = decimal.Parse(txtValorDesconto.Text, NumberStyles.Currency);
			txtValorDesconto.BackColor = Color.White;
			txtValorDesconto.ReadOnly = false;
			txtValorDesconto.Focus();
			txtValorDesconto.SelectAll();
		}

		private void txtValorDesconto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			}
		}

		private void txtValorDesconto_Leave(object sender, EventArgs e)
		{
			txtValorDesconto.ReadOnly = true;
			txtValorDesconto.BackColor = Color.FromArgb(225, 232, 240);

			//--- verifica se o desconto foi alterado
			decimal newDesconto = decimal.Parse(txtValorDesconto.Text, NumberStyles.Currency);

			if (DescontoAnterior != newDesconto)
			{
				//--- verifica se o novo valor do desconto é menor que o valor do APagar
				if (newDesconto >= _apagar.APagarValor - _apagar.ValorPago)
				{
					AbrirDialog("Não é possível conceder um valor de DESCONTO MAIOR ou IGUAL ao valor EM ABERTO desse A PAGAR...",
								"Conceder Desconto",
								DialogType.OK,
								DialogIcon.Exclamation);
					_apagar.ValorDesconto = DescontoAnterior;
					txtValorDesconto.DataBindings["Text"].ReadValue();
					return;
				}

				txtValorDesconto.DataBindings["Text"].ReadValue();

				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;
					new APagarBLL().UpdateAPagar(_apagar);

					//--- recalcula o valor em aberto
					DefineValueLabels();

				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Alterar o Desconto..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
			}
		}

		private void UcOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '.')
			{
				txtValorDesconto.SelectedText = ",";
				e.Handled = true;
			}
			else if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		#endregion // EDIT DESCONTO --- END
	}
}
