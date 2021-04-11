using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.DespesaCartao
{
	public partial class frmDespesaCartaoProcurar : CamadaUI.Modals.frmModFinBorder
	{
		public objAPagar SelectedItem { get { return (objAPagar)bindPag.Current; } }
		private BindingSource bindPag = new BindingSource();
		private List<objAPagar> _ItensList = new List<objAPagar>();
		private Form _formOrigem;

		#region SUB NEW | CONSTRUCTOR

		public frmDespesaCartaoProcurar(List<objAPagar> ItensList, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			_ItensList = ItensList;

			// format Datagridview
			bindPag.DataSource = _ItensList;
			dgvListagem.DataSource = bindPag;
			FormataListagem();

		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATAGRID LIST FUNCTIONS

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagem()
		{
			dgvListagem.Columns.Clear();
			dgvListagem.AutoGenerateColumns = false;
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListagem.MultiSelect = false;
			dgvListagem.ColumnHeadersVisible = true;
			dgvListagem.AllowUserToResizeRows = false;
			dgvListagem.AllowUserToResizeColumns = false;
			dgvListagem.RowHeadersWidth = 36;
			dgvListagem.RowTemplate.Height = 30;
			dgvListagem.StandardTab = true;
			dgvListagem.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			// DEFINE COLUMN FONT
			Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

			//--- (0) COLUNA CREDOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;

			//--- (1) COLUNA DESCRICAO
			clnDescricao.DataPropertyName = "DespesaDescricao";
			clnDescricao.Visible = true;
			clnDescricao.ReadOnly = true;
			clnDescricao.Resizable = DataGridViewTriState.False;
			clnDescricao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDescricao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDescricao.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA ID
			clnIdentificador.DataPropertyName = "Identificador";
			clnIdentificador.Visible = true;
			clnIdentificador.ReadOnly = true;
			clnIdentificador.Resizable = DataGridViewTriState.False;
			clnIdentificador.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIdentificador.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA VENCIMENTO
			clnVencimento.DataPropertyName = "Vencimento";
			clnVencimento.Visible = true;
			clnVencimento.ReadOnly = true;
			clnVencimento.Resizable = DataGridViewTriState.False;
			clnVencimento.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnVencimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.DefaultCellStyle.Font = clnFont;

			//--- (4) COLUNA VALOR
			clnValor.DataPropertyName = "APagarValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Format = "#,##0.00";
			clnValor.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnCredor, clnDescricao, clnIdentificador, clnVencimento, clnValor);
		}

		#endregion

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

		private void btnFechar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnSelecionar_Click(object sender, EventArgs e)
		{
			if (bindPag.Current == null)
			{
				AbrirDialog("Favor escolher um registro na listagem antes de selecionar...",
					"Escolher Registro", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			DialogResult = DialogResult.OK;
		}

		private void dgvListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			btnSelecionar_Click(sender, null);
		}



	}
}
