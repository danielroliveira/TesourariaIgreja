using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using System.Linq;

namespace CamadaUI.Registres
{
	public partial class frmContribuinteListagem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objContribuinte> _sourceList = new List<objContribuinte>();
		private bool _isProcura;
		private Form _formOrigem;
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;

		#region NEW | OPEN FUNCTIONS

		public frmContribuinteListagem(bool IsProcura, Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;
			_isProcura = IsProcura;

			if (IsProcura)
			{
				btnEscolher.Enabled = true;
				btnEditar.Enabled = false;
			}
			else
			{
				btnEscolher.Enabled = false;
				btnEditar.Enabled = true;
			}


			CarregaCmbAtivo();
			FormataListagem();

			//--- get dados
			cmbAtivo.SelectedValueChanged += ObterDados;
			HandlerKeyDownControl(this);
		}

		//--- PROPRIEDADE DE ESCOLHA
		public objContribuinte propEscolha { get; set; }

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados(object sender, EventArgs e)
		{
			try
			{
				// --- Check txtProcura text
				if (txtProcura.Text.Trim().Length == 0) return;

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ContribuinteBLL cBLL = new ContribuinteBLL();
				_sourceList = cBLL.GetListContribuinte(txtProcura.Text, Convert.ToBoolean(cmbAtivo.SelectedValue));
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

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaCmbAtivo()
		{
			//--- Create DataTable
			DataTable dtAtivo = new DataTable();
			dtAtivo.Columns.Add("Ativo");
			dtAtivo.Columns.Add("Texto");
			dtAtivo.Rows.Add(new object[] { false, "Inativo" });
			dtAtivo.Rows.Add(new object[] { true, "Ativo" });

			//--- Set DataTable
			cmbAtivo.DataSource = dtAtivo;
			cmbAtivo.ValueMember = "Ativo";
			cmbAtivo.DisplayMember = "Texto";
			cmbAtivo.SelectedValue = true;
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
			clnID.DataPropertyName = "IDContribuinte";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "Contribuinte";
			clnCadastro.Visible = true;
			clnCadastro.ReadOnly = true;
			clnCadastro.Resizable = DataGridViewTriState.False;
			clnCadastro.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCadastro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCadastro.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) COLUNA CONGREGACAO
			clnCongregacao.DataPropertyName = "Congregacao";
			clnCongregacao.Visible = true;
			clnCongregacao.ReadOnly = true;
			clnCongregacao.Resizable = DataGridViewTriState.False;
			clnCongregacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCongregacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCongregacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (4) Coluna da imagem
			clnImage.Name = "Ativo";
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnID, clnCadastro, clnCongregacao, clnImage);
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 3)
			{
				objContribuinte item = (objContribuinte)dgvListagem.Rows[e.RowIndex].DataBoundItem;
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

				if (dgvListagem.Rows.Count > 0)
				{
					if (_isProcura)
					{
						btnEscolher_Click(sender, null);
					}
					else
					{
						btnEditar_Click(sender, new EventArgs());
					}
				}
				else
				{
					SendKeys.Send("{TAB}");
				}

			}
		}

		// ON CELL DOUBLE CLICK
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (_isProcura) // if procura ESCOLHER
				btnEscolher_Click(sender, null);
			else // If NOT procura EDITAR
				btnEditar_Click(sender, new EventArgs());
		}

		// ON DATA SOURCE CHANGE CHECK LABEL: REGISTROS ENCONTRADOS
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_DataSourceChanged(object sender, EventArgs e)
		{
			AtualizaRegistrosEncontradosLabel();
		}

		#endregion

		#region BUTTONS FUNCTION

		// BTN FECHAR
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		// BTN ADICIONAR
		//------------------------------------------------------------------------------------------------------------
		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			if (_formOrigem.GetType() == typeof(frmPrincipal))
			{
				frmContribuinte frm = new frmContribuinte(new objContribuinte(null), null);
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
			//--- check formOrigem
			if (_formOrigem.GetType() != typeof(frmPrincipal)) return;

			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Editar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objContribuinte item = (objContribuinte)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- open edit form
			frmContribuinte frm = new frmContribuinte(item, null);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// BTN ESCOLHER
		//------------------------------------------------------------------------------------------------------------
		private void btnEscolher_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Escolher...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objContribuinte item = (objContribuinte)dgvListagem.SelectedRows[0].DataBoundItem;

			propEscolha = item;
			DialogResult = DialogResult.OK;
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
					objContribuinte contribuinte = (objContribuinte)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

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
			objContribuinte contribuinte = (objContribuinte)dgvListagem.SelectedRows[0].DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(contribuinte.Ativo ? "DESATIVAR " : "ATIVAR")} esse Contribuinte?\n" +
									  contribuinte.Contribuinte.ToUpper(), (contribuinte.Ativo ? "DESATIVAR " : "ATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			contribuinte.Ativo = !contribuinte.Ativo;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				ContribuinteBLL cBLL = new ContribuinteBLL();
				cBLL.UpdateContribuinte(contribuinte);

				//--- altera a imagem
				ObterDados(sender, null);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar Contribuinte..." + "\n" +
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
		private void frmContribuinteListagem_KeyDown(object sender, KeyEventArgs e)
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
				case Keys.PageUp:
					e.Handled = true;

					if (cmbAtivo.SelectedIndex > 0)
						cmbAtivo.SelectedIndex -= 1;
					else
						cmbAtivo.SelectedIndex = cmbAtivo.Items.Count - 1;
					break;

				case Keys.PageDown:
					e.Handled = true;
					int maxIndex = cmbAtivo.Items.Count - 1;

					if (cmbAtivo.SelectedIndex < maxIndex)
						cmbAtivo.SelectedIndex += 1;
					else
						cmbAtivo.SelectedIndex = 0;
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

		#region PROCURA FUNCTIONS

		// PROPERTY PREENCHIDO
		//------------------------------------------------------------------------------------------------------------
		private bool? _propPreenchido;

		public bool? propPreenchido
		{
			get => _propPreenchido;
			set
			{
				if (value == null)
				{
					lblProc.Visible = false;
					//-- btnProcurar
					btnProcurar.Visible = false;
					btnProcurar.Enabled = false;
				}
				else if (value == true)
				{
					lblProc.SendToBack();
					int x = txtProcura.Location.X + 110;
					int y = txtProcura.Location.Y - 17;
					Point newPoint = new Point(x, y);
					lblProc.Location = newPoint;

					lblProc.Font = new Font("Calibri Light", 8F, FontStyle.Bold);
					lblProc.Text = "Pressione ENTER...";
					lblProc.ForeColor = Color.DarkBlue;
					lblProc.BackColor = Color.Transparent;
					lblProc.Visible = true;
					//-- btnProcurar
					btnProcurar.Visible = true;
					btnProcurar.Enabled = true;
				}
				else if (value == false)
				{
					int x = txtProcura.Location.X + 107;
					int y = txtProcura.Location.Y + 3;
					Point newPoint = new Point(x, y);
					lblProc.Location = newPoint;

					lblProc.Font = new Font("Calibri Light", 11.25F, FontStyle.Italic);
					lblProc.Text = "Digite algo para procurar...";
					lblProc.ForeColor = Color.Black;
					lblProc.BackColor = Color.White;
					lblProc.BringToFront();
					lblProc.Visible = true;
					//-- btnProcurar
					btnProcurar.Visible = true;
					btnProcurar.Enabled = false;

					dgvListagem.DataSource = null;

				}

				_propPreenchido = value;
			}
		}

		// BTN PROCURAR
		//------------------------------------------------------------------------------------------------------------
		private void btnProcurar_Click(object sender, EventArgs e)
		{
			if (propPreenchido == true)
			{
				ObterDados(sender, null);

				if (_sourceList.Count > 0)
				{
					dgvListagem.Focus();
				}
				else
				{
					txtProcura.Focus();
					txtProcura.SelectAll();
				}
			}

		}

		private void txtProcura_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;

				if (propPreenchido == true)
				{
					ObterDados(sender, null);
				}
				else if (propPreenchido == null)
				{
					if (dgvListagem.SelectedRows.Count > 0)
						btnEditar_Click(sender, new EventArgs());
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;
				txtProcura.Clear();
				propPreenchido = false;
				_sourceList.Clear();
				dgvListagem.DataSource = null;
			}
		}

		private void AtualizaRegistrosEncontradosLabel()
		{
			if (propPreenchido == true)
			{
				int i = dgvListagem.Rows.Count;

				if (i == 0)
				{
					lblRegistrosEncontrados.Text = "Nenhum registro encontrado...";
				}
				else
				{
					if (i == 1)
						lblRegistrosEncontrados.Text = $"{i} registro encontrado...";
					else
						lblRegistrosEncontrados.Text = $"{i} registros encontrados...";
				}

				lblRegistrosEncontrados.Visible = true;
			}
			else
			{
				lblRegistrosEncontrados.Visible = false;
			}
		}

		private void lblProc_Click(object sender, EventArgs e)
		{
			txtProcura.Focus();
		}

		private void txtProcura_TextChanged(object sender, EventArgs e)
		{
			if (txtProcura.Text.Length > 0)
				propPreenchido = true;
			else
				propPreenchido = false;
		}

		#endregion // PROCURA FUNCTIONS --- END
	}
}
