using CamadaBLL;
using CamadaDTO;
using CamadaUI.Caixa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarAlterar : CamadaUI.Modals.frmModFinBorder
	{
		objAPagar _apagar;
		BindingSource bind = new BindingSource();
		List<objCobrancaForma> listFormas = new List<objCobrancaForma>();
		Form _formOrigem;
		decimal ValorAnterior;

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarAlterar(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_apagar = pag;

			GetFormasList();

			bind.DataSource = _apagar;
			BindingCreator();

			// If Origem = Periodica enable change valor
			if (_apagar.DespesaOrigem == 2) btnAlterarValor.Visible = true;

			HandlerKeyDownControl(this);
			_apagar.PropertyChanged += (a, b) => btnAlterar.Enabled = true;

		}

		// GET LIST OF FORMAS DE COBRANCA
		//------------------------------------------------------------------------------------------------------------
		private void GetFormasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listFormas = new CobrancaFormaBLL().GetListCobrancaForma(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Formas de Cobrança..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
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
			txtIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCobrancaForma.DataBindings.Add("Text", bind, "CobrancaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpVencimento.DataBindings.Add("Value", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorDesconto.DataBindings.Add("Text", bind, "ValorDesconto", true, DataSourceUpdateMode.OnPropertyChanged);
			numReferenciaAno.DataBindings.Add("Value", bind, "ReferenciaAno", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtValorDesconto.DataBindings["Text"].Format += FormatCurrency;
			txtAPagarValor.DataBindings["Text"].Format += FormatCurrency;

			// CARREGA COMBO
			CarregaComboMes();
			cmbReferenciaMes.DataBindings.Add("SelectedValue", bind, "ReferenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
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

		private void FormatD2(object sender, ConvertEventArgs e)
		{
			e.Value = $"{e.Value: 00}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
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
			cmbReferenciaMes.DataSource = dtMeses;
			cmbReferenciaMes.ValueMember = "ID";
			cmbReferenciaMes.DisplayMember = "Mes";
		}

		#endregion // DATABINDINGS --- END

		#region BUTTONS FUNCTION

		// CLOSE | CANCELAR
		//------------------------------------------------------------------------------------------------------------
		private void btnClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		// ALTERAR | OK
		//------------------------------------------------------------------------------------------------------------
		private void btnAlterar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnSetForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...", "Formas de Cobrança",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDCobrancaForma, x => x.CobrancaForma);
			var textBox = txtCobrancaForma;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _apagar.IDCobrancaForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_apagar.IDCobrancaForma = (int)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmBancoProcura frm = new frmBancoProcura(this, _apagar.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					_apagar.IDBanco = (int)frm.propEscolha.IDBanco;
					txtBanco.Text = frm.propEscolha.BancoNome;
				}

				//--- select
				txtBanco.Focus();
				txtBanco.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
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

		#region VALIDA DESCONTO

		private void txtValorDesconto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			decimal newDesconto = decimal.Parse(txtValorDesconto.Text, System.Globalization.NumberStyles.Currency);

			//--- verifica se o novo valor do desconto é menor que o valor do APagar
			if (newDesconto >= _apagar.APagarValor - _apagar.ValorPago)
			{
				AbrirDialog("Não é possível conceder um valor de DESCONTO MAIOR ou IGUAL ao valor EM ABERTO desse A PAGAR...",
							"Conceder Desconto",
							DialogType.OK,
							DialogIcon.Exclamation);
				e.Cancel = true;
			}
		}

		#endregion // VALIDA DESCONTO --- END

		#region EDIT VALOR

		private void btnAlterarValor_Click(object sender, EventArgs e)
		{
			ValorAnterior = decimal.Parse(txtAPagarValor.Text, NumberStyles.Currency);
			txtAPagarValor.BackColor = SystemColors.Highlight;
			txtAPagarValor.ForeColor = Color.White;
			txtAPagarValor.ReadOnly = false;
			txtAPagarValor.Focus();
			txtAPagarValor.SelectAll();
		}

		private void txtAPagarValor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			}
		}

		private void txtAPagarValor_Leave(object sender, EventArgs e)
		{
			txtAPagarValor.ReadOnly = true;
			txtAPagarValor.BackColor = SystemColors.Control;
			txtAPagarValor.ForeColor = Color.Black;

			//--- verifica se o valor foi alterado
			decimal newValor = decimal.Parse(txtAPagarValor.Text, NumberStyles.Currency);

			if (ValorAnterior != newValor)
			{
				var resp = AbrirDialog($"O valor da Despesa Periódica Original será alterada para {newValor:c}\n" +
					"Você deseja continuar?",
					"Despesa Periódica - Alterar Valor",
					DialogType.SIM_NAO,
					DialogIcon.Question,
					DialogDefaultButton.Second);

				if (resp != DialogResult.Yes)
				{
					_apagar.CancelEdit();
					txtAPagarValor.DataBindings["text"].ReadValue();
					btnAlterar.Enabled = false;
					txtValorDesconto.Focus();
					return;
				}

				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;
					new DespesaPeriodicaBLL().UpdateDespesaValor(_apagar.IDDespesa, newValor);
					_apagar.EndEdit();
					txtAPagarValor.DataBindings["text"].ReadValue();
				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Alterar o Valor da Despesa..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
			}
		}

		private void txtAPagarValor_OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
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
