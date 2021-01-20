using CamadaBLL;
using CamadaDTO;
using CamadaUI.Saidas.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmProvisoriaListagem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objDespesaProvisoria> listTipo = new List<objDespesaProvisoria>();
		private Image ImgInativo = Properties.Resources.accept_24;
		private Image ImgAtivo = Properties.Resources.edit_page_24;
		private DespesaProvisoriaBLL dBLL = new DespesaProvisoriaBLL();

		#region NEW | OPEN FUNCTIONS

		public frmProvisoriaListagem()
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			CarregaCmbAtivo();
			ObterDados();
			FormataListagem();

			//--- get dados
			cmbAtivo.SelectedValueChanged += (a, b) => ObterDados();
			dgvListagem.CellDoubleClick += btnEditar_Click;
			txtProcura.TextChanged += FiltrarListagem;
			HandlerKeyDownControl(this);
		}

		//--- PROPRIEDADE DE ESCOLHA
		public objDespesaProvisoria propEscolha { get; set; }

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados()
		{
			// define buttons enabled from Ativo
			bool concluida = bool.Parse(cmbAtivo.SelectedValue.ToString());
			DefineButtons(concluida);

			// get list data
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				DateTime? dtInicial = null;
				DateTime? dtFinal = null;

				if (concluida && rbtUltimosDias.Checked)
				{
					dtInicial = DateTime.Today.AddDays(-30);
					dtFinal = DateTime.Today;
				}

				listTipo = dBLL.GetListDespesaProvisoria(null, null, dtInicial, dtFinal, concluida);
				dgvListagem.DataSource = listTipo;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter os Dados da listagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaCmbAtivo()
		{
			//--- Create DataTable
			DataTable dtAtivo = new DataTable();
			dtAtivo.Columns.Add("Ativo");
			dtAtivo.Columns.Add("Texto");
			dtAtivo.Rows.Add(new object[] { false, "Ativas" });
			dtAtivo.Rows.Add(new object[] { true, "Concluídas" });

			//--- Set DataTable
			cmbAtivo.DataSource = dtAtivo;
			cmbAtivo.ValueMember = "Ativo";
			cmbAtivo.DisplayMember = "Texto";
			cmbAtivo.SelectedValue = false;
		}

		private void DefineButtons(bool concluida)
		{
			btnExcluir.Enabled = !concluida;
			btnRecibo.Enabled = !concluida;
			btnEditar.Text = concluida ? "Abrir" : "Editar";
			btnEditar.Image = concluida ? Properties.Resources.search_24 : Properties.Resources.editar_16;

			pnlDias.Visible = concluida;

		}

		#endregion

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

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDProvisorio";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			colList.Add(clnID);

			//--- (2) COLUNA DATA
			clnRetiradaData.DataPropertyName = "RetiradaData";
			clnRetiradaData.Visible = true;
			clnRetiradaData.ReadOnly = true;
			clnRetiradaData.Resizable = DataGridViewTriState.False;
			clnRetiradaData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnRetiradaData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnRetiradaData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnRetiradaData);

			//--- (2) COLUNA FINALIDADE
			clnFinalidade.DataPropertyName = "Finalidade";
			clnFinalidade.Visible = true;
			clnFinalidade.ReadOnly = true;
			clnFinalidade.Resizable = DataGridViewTriState.False;
			clnFinalidade.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnFinalidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnFinalidade.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnFinalidade);

			//--- (3) COLUNA VALOR
			clnValorProvisorio.DataPropertyName = "ValorProvisorio";
			clnValorProvisorio.Visible = true;
			clnValorProvisorio.ReadOnly = true;
			clnValorProvisorio.Resizable = DataGridViewTriState.False;
			clnValorProvisorio.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorProvisorio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorProvisorio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorProvisorio.DefaultCellStyle.Format = "C"; //"#,##0.00";
			colList.Add(clnValorProvisorio);

			//--- (3) Coluna da imagem
			clnImage.Name = "Ativo";
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			colList.Add(clnImage);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnImage.Index)
			{
				objDespesaProvisoria item = (objDespesaProvisoria)dgvListagem.Rows[e.RowIndex].DataBoundItem;
				if (!item.Concluida) e.Value = ImgAtivo;
				else e.Value = ImgInativo;
			}
		}

		// ON ENTER SELECT ITEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				btnEditar_Click(sender, new EventArgs());
			}
		}

		#endregion

		#region BUTTONS FUNCTION

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			frmProvisorio frm = new frmProvisorio(new objDespesaProvisoria(null), this);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Editar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objDespesaProvisoria item = (objDespesaProvisoria)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- open edit form
			frmProvisorio frm = new frmProvisorio(item, this);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		private void btnRecibo_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Imprimir o Recibo...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objDespesaProvisoria item = (objDespesaProvisoria)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new frmProvisorioReciboReport(item);
				frm.ShowDialog();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir Relatório..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}




		}

		#endregion

		#region FILTRAGEM PROCURA

		private void FiltrarListagem(object sender, EventArgs e)
		{
			if (txtProcura.TextLength > 0)
			{
				// declare function
				Func<objDespesaProvisoria, bool> FiltroItem = c => c.Finalidade.ToLower().Contains(txtProcura.Text.ToLower());

				// aply filter using function
				dgvListagem.DataSource = listTipo.FindAll(c => FiltroItem(c));
			}
			else
			{
				dgvListagem.DataSource = listTipo;
			}
		}

		#endregion // FILTRAGEM PROCURA --- END

		#region CONTROLS FUNCTION

		// ESC TO CLOSE || KEYDOWN TO DOWNLIST || KEYUP TO UPLIST
		//------------------------------------------------------------------------------------------------------------
		private void frmProvisoriaListagem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
			else if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;
				btnAdicionar_Click(sender, new EventArgs());
			}
			else if (e.KeyCode == Keys.Up && ActiveControl.GetType().BaseType.Name != "ComboBox")
			{
				e.Handled = true;

				if (dgvListagem.Rows.Count > 0)
				{
					if (dgvListagem.SelectedRows.Count > 0)
					{
						int i = dgvListagem.SelectedRows[0].Index;
						dgvListagem.Rows[i].Selected = false;
						if (i == 0) i = dgvListagem.Rows.Count;
						dgvListagem.Rows[i - 1].Selected = true;
					}
					else
					{
						dgvListagem.Rows[0].Selected = true;
					}

					dgvListagem.FirstDisplayedScrollingRowIndex = dgvListagem.SelectedRows[0].Index;
					dgvListagem.SelectedRows[0].Cells[0].Selected = true;
				}
			}
			else if (e.KeyCode == Keys.Down && ActiveControl.GetType().BaseType.Name != "ComboBox")
			{
				e.Handled = true;

				if (dgvListagem.Rows.Count > 0)
				{
					if (dgvListagem.SelectedRows.Count > 0)
					{
						int i = dgvListagem.SelectedRows[0].Index;
						dgvListagem.Rows[i].Selected = false;
						if (i == dgvListagem.Rows.Count - 1) i = -1;
						dgvListagem.Rows[i + 1].Selected = true;
					}
					else
					{
						dgvListagem.Rows[0].Selected = true;
					}

					dgvListagem.FirstDisplayedScrollingRowIndex = dgvListagem.SelectedRows[0].Index;
					dgvListagem.SelectedRows[0].Cells[0].Selected = true;
				}
			}
		}

		#endregion // CONTROLS FUNCTION --- END

		private void rbtUltimosDias_CheckedChanged(object sender, EventArgs e)
		{
			ObterDados();
		}
	}
}
