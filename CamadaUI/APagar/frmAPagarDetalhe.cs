using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using CamadaBLL;
using CamadaUI.Caixa;

namespace CamadaUI.APagar
{
	public partial class frmAPagarDetalhe : CamadaUI.Modals.frmModFinBorder
	{
		objAPagar _apagar;
		BindingSource bind = new BindingSource();
		List<objCobrancaForma> listFormas = new List<objCobrancaForma>();
		Form _formOrigem;

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarDetalhe(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			Size = new Size(530, 536);
			_formOrigem = formOrigem;
			_apagar = pag;

			CheckEditing();
		}

		// VERIFY IF IS EDITING FORM OR NOT EDIT
		//------------------------------------------------------------------------------------------------------------
		private void CheckEditing()
		{
			if (_apagar.IDAPagar == null)
			{
				pnlEditar.Visible = true;
				pnlVisualizar.Visible = false;
				GetFormasList();

				bind.DataSource = _apagar;
				BindingCreatorEditing();
			}
			else
			{
				pnlEditar.Visible = false;
				pnlVisualizar.Visible = true;
				pnlVisualizar.Location = new Point(12, 132);

				bind.DataSource = _apagar;
				BindingCreatorNotEditing();
			}
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
		private void BindingCreatorEditing()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagar", true);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true);
			txtIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			numParcela.DataBindings.Add("Value", bind, "Parcela", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCobrancaForma.DataBindings.Add("Text", bind, "CobrancaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpVencimento.DataBindings.Add("Value", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			numReferenciaAno.DataBindings.Add("Value", bind, "ReferenciaAno", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtAPagarValor.DataBindings["Text"].Format += FormatCurrency;
			numParcela.DataBindings["Value"].Format += FormatD2;

			// CARREGA COMBO
			CarregaComboMes();
			cmbReferenciaMes.DataBindings.Add("SelectedValue", bind, "ReferenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreatorNotEditing()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagar", true);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true);
			lblIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			lblParcela.DataBindings.Add("Text", bind, "Parcela", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCobrancaForma.DataBindings.Add("Text", bind, "CobrancaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			lblBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			lblVencimento.DataBindings.Add("Text", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			lblAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblReferencia.DataBindings.Add("Text", bind, "Referencia", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblAPagarValor.DataBindings["Text"].Format += FormatCurrency;
			lblParcela.DataBindings["Text"].Format += FormatD2;

			// CARREGA COMBO
			//CarregaComboMes();
			//cmbReferenciaMes.DataBindings.Add("SelectedValue", bind, "ReferenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
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
			cmbReferenciaMes.DataSource = dtMeses;
			cmbReferenciaMes.ValueMember = "ID";
			cmbReferenciaMes.DisplayMember = "Mes";
		}

		#endregion // DATABINDINGS --- END

		#region BUTTONS FUNCTION

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
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
	}
}
