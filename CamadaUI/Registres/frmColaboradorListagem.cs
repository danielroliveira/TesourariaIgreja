using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Registres
{
	public partial class frmColaboradorListagem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objCredor> _sourceList = new List<objCredor>();
		private bool _isProcura;
		private Form _formOrigem;
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;

		#region NEW | OPEN FUNCTIONS

		public frmColaboradorListagem(bool IsProcura, Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;
			_isProcura = IsProcura;

			// IsProcura?
			btnAdicionar.Enabled = !IsProcura;
			btnEditar.Text = IsProcura ? "&Escolher" : "&Editar";
			btnEditar.Image = IsProcura ? Properties.Resources.accept_16 : Properties.Resources.editar_16;

			FormataListagem();
			ObterDados();

			//--- get dados
			rbtAtivo.CheckedChanged += (a, b) => ObterDados();
			HandlerKeyDownControl(this);
		}

		//--- PROPRIEDADE DE ESCOLHA
		public objCredor propEscolha { get; set; }

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				CredorBLL cBLL = new CredorBLL();
				_sourceList = cBLL.GetListCredor(string.Empty, rbtAtivo.Checked, 6);
				dgvListagem.DataSource = _sourceList;
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

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDCredor";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "Credor";
			clnCadastro.Visible = true;
			clnCadastro.ReadOnly = true;
			clnCadastro.Resizable = DataGridViewTriState.False;
			clnCadastro.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCadastro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCadastro.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) COLUNA CADASTRO
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (4) Coluna da imagem
			clnImage.Name = "Ativo";
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnID, clnCadastro, clnSetor, clnImage);
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnImage.Index)
			{
				objCredor item = (objCredor)dgvListagem.Rows[e.RowIndex].DataBoundItem;
				if (item.Ativo) e.Value = ImgAtivo;
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

				//--- check formOrigem
				btnEditar_Click(sender, new EventArgs());

			}
		}

		// ON CELL DOUBLE CLICK
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			btnEditar_Click(sender, new EventArgs());
		}

		#endregion

		#region BUTTONS FUNCTION

		// BTN FECHAR
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();

			if (Application.OpenForms.Count == 1)
			{
				MostraMenuPrincipal();
			}
		}

		// BTN ADICIONAR
		//------------------------------------------------------------------------------------------------------------
		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			if (_formOrigem.GetType() == typeof(frmPrincipal))
			{
				frmCredor frm = new frmCredor(new objCredor(null), null);
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				DesativaMenuPrincipal();
				Close();
				frm.Show();
			}
			else
			{
				DialogResult = DialogResult.Yes; // return to Origem that is new Contribuinte
			}
		}

		// BTN EDITAR
		//------------------------------------------------------------------------------------------------------------
		private void btnEditar_Click(object sender, EventArgs e)
		{
			//--- get Selected item
			objCredor item = (objCredor)dgvListagem.SelectedRows[0].DataBoundItem;

			if (!_isProcura) // EDITAR
			{
				//--- check selected item
				if (dgvListagem.SelectedRows.Count == 0)
				{
					AbrirDialog("Favor selecionar um registro para Editar...",
						"Selecionar Registro", DialogType.OK, DialogIcon.Information);
					return;
				}

				//--- open edit form
				frmCredor frm = new frmCredor(item, null);
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				DesativaMenuPrincipal();
				Close();
				frm.Show();
			}
			else // ESCOLHER
			{
				propEscolha = item;
				DialogResult = DialogResult.OK;
			}
		}

		#endregion

		#region ATIVAR DESATIVAR MENU

		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Control c = (Control)sender;
				DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
				dgvListagem.ClearSelection();

				//---VERIFICAÇÕES NECESSARIAS
				if (hit.Type != DataGridViewHitTestType.Cell) return;

				// seleciona o ROW
				dgvListagem.Rows[hit.RowIndex].Cells[0].Selected = true;
				dgvListagem.Rows[hit.RowIndex].Selected = true;

				// mostra o MENU ativar e desativar
				if (dgvListagem.Columns[hit.ColumnIndex].Name == "Ativo")
				{
					objCredor contribuinte = (objCredor)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

					if (contribuinte.Ativo == true)
					{
						AtivarToolStripMenuItem.Enabled = false;
						DesativarToolStripMenuItem.Enabled = true;
					}
					else
					{
						AtivarToolStripMenuItem.Enabled = true;
						DesativarToolStripMenuItem.Enabled = false;
					}

					// revela menu
					MenuListagem.Show(c.PointToScreen(e.Location));
				}
			}
		}

		private void AtivarDesativar_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Verifica o item
			objCredor credor = (objCredor)dgvListagem.SelectedRows[0].DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(credor.Ativo ? "DESATIVAR " : "ATIVAR")} esse Credor?\n" +
									  credor.Credor.ToUpper(), (credor.Ativo ? "DESATIVAR " : "ATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			credor.Ativo = !credor.Ativo;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				CredorBLL cBLL = new CredorBLL();
				cBLL.UpdateCredor(credor);

				//--- altera a imagem
				ObterDados();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar Credor..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // ATIVAR DESATIVAR MENU --- END

		#region CONTROLS FUNCTION

		/*------------------------------------------------------------------------------------------------
		 TECLAS DE ATALHO:
		
		--- ESC --> FECHA FORM
		--- ADD --> ADICIONAR REGISTRO
		--- SETA CIMA E BAIXO --> NAVEGA ENTRE OS ITENS DA LISTAGEM
		--- PGDOWN E PGUP --> ALTERA ATIVO
		------------------------------------------------------------------------------------------------*/
		private void frmColaboradorListagem_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					e.Handled = true;
					btnFechar_Click(sender, new EventArgs());
					break;
				case Keys.Add:
					e.Handled = true;
					btnAdicionar_Click(sender, new EventArgs());
					break;
				case Keys.Up:
					if (ActiveControl.GetType().BaseType.Name != "ComboBox")
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
					break;
				case Keys.Down:
					if (ActiveControl.GetType().BaseType.Name != "ComboBox")
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
					break;
				default:
					e.Handled = false;
					break;
			}
		}


		#endregion // CONTROLS FUNCTION --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void frmColaboradorListagem_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmColaboradorListagem_FormClosed(object sender, FormClosedEventArgs e)
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

		#endregion // DESIGN FORM FUNCTIONS --- END

	}
}
