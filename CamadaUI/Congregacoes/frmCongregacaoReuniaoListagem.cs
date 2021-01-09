using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Congregacoes
{
	public partial class frmCongregacaoReuniaoListagem : CamadaUI.Modals.frmModFinBorder
	{
		private ReuniaoBLL rBLL = new ReuniaoBLL();
		private List<objReuniao> listReuniao = new List<objReuniao>();
		private Form _formOrigem;
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;

		#region NEW | OPEN FUNCTIONS

		public frmCongregacaoReuniaoListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;
			CarregaCmbAtivo();
			ObterDados();
			FormataListagem();

			//--- get dados
			cmbAtivo.SelectedValueChanged += (a, b) => ObterDados();
			dgvListagem.CellDoubleClick += btnEditar_Click;
			txtProcura.TextChanged += (a, b) => FiltrarListagem();
			txtProcuraCongregacao.TextChanged += (a, b) => FiltrarListagem();
			HandlerKeyDownControl(this);
		}

		//--- PROPRIEDADE DE ESCOLHA
		public objReuniao propEscolha { get; set; }

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				listReuniao = rBLL.GetListReuniao("", Convert.ToBoolean(cmbAtivo.SelectedValue));
				dgvListagem.DataSource = listReuniao;
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
			dtAtivo.Rows.Add(new object[] { false, "Inativa" });
			dtAtivo.Rows.Add(new object[] { true, "Ativa" });

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
			clnID.DataPropertyName = "IDReuniao";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "Reuniao";
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
			clnImage.Name = "Ativa";
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
				objReuniao item = (objReuniao)dgvListagem.Rows[e.RowIndex].DataBoundItem;
				if (item.Ativa) e.Value = ImgAtivo;
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

		// FECHAR FORMULARIO
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		// ADICIONAR CONTA
		//------------------------------------------------------------------------------------------------------------
		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			if (_formOrigem == null)
			{
				frmCongregacaoReuniao frm = new frmCongregacaoReuniao(new objReuniao(null));
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				DesativaMenuPrincipal();
				Close();
				frm.Show();
			}
			else
			{
				propEscolha = new objReuniao(null);
				DialogResult = DialogResult.Yes;
			}
		}

		// EDITAR CONTA ESCOLHIDA
		//------------------------------------------------------------------------------------------------------------
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
			objReuniao item = (objReuniao)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- open edit form
			if (_formOrigem == null)
			{
				frmCongregacaoReuniao frm = new frmCongregacaoReuniao(item);
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				DesativaMenuPrincipal();
				Close();
				frm.Show();
			}
			else
			{
				propEscolha = item;
				DialogResult = DialogResult.Yes;
			}
		}

		#endregion

		#region FILTRAGEM PROCURA

		private void FiltrarListagem()
		{
			if (txtProcura.TextLength > 0)
			{
				// filter
				if (!int.TryParse(txtProcura.Text, out int i))
				{
					// declare function
					Func<objReuniao, bool> FiltroItem = c => c.Reuniao.ToLower().Contains(txtProcura.Text.ToLower());

					// aply filter using function
					dgvListagem.DataSource = listReuniao.FindAll(c => FiltroItem(c));
				}
				else
				{
					// declare function
					Func<objReuniao, bool> FiltroID = c => c.IDReuniao == i;

					// aply filter using function
					dgvListagem.DataSource = listReuniao.FindAll(c => FiltroID(c));
				}
			}
			else
			{
				dgvListagem.DataSource = listReuniao;
			}

			if (txtProcuraCongregacao.TextLength > 0)
			{
				// get actual DataSource
				List<objReuniao> list = dgvListagem.DataSource as List<objReuniao>;

				// declare function
				Func<objReuniao, bool> FiltroItem = c => c.Congregacao.ToLower().Contains(txtProcuraCongregacao.Text.ToLower());

				// aply filter using function
				dgvListagem.DataSource = list.FindAll(c => FiltroItem(c));
			}
		}

		#endregion // FILTRAGEM PROCURA --- END

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
				objReuniao Reuniao = (objReuniao)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

				if (Reuniao.Ativa == true)
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

		private void AtivarDesativar_Reuniao_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Verifica o item
			objReuniao setor = (objReuniao)dgvListagem.SelectedRows[0].DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(setor.Ativa ? "DESATIVAR " : "ATIVAR")} essa Reuniao?\n" +
									  setor.Reuniao.ToUpper(), (setor.Ativa ? "DESATIVAR " : "ATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			setor.Ativa = !setor.Ativa;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				rBLL.UpdateReuniao(setor);

				//--- altera a imagem
				FiltrarListagem();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar Reuniao..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// DELETE REUNIAO
		//------------------------------------------------------------------------------------------------------------
		private void mnuExcluir_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Verifica o item
			objReuniao reuniao = (objReuniao)dgvListagem.SelectedRows[0].DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente REMOVER definitavamente essa Reuniao?" +
									  $"\n{reuniao.Reuniao.ToUpper()} " +
									  $"\n{reuniao.Congregacao.ToUpper()}",
									  "Excluir Reunião",
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				rBLL.DeleteReuniao(reuniao);

				//--- altera a imagem
				ObterDados();
				FiltrarListagem();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar Reuniao..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuEditar_Click(object sender, EventArgs e)
		{
			btnEditar_Click(sender, e);
		}

		#endregion // ATIVAR DESATIVAR MENU --- END

		#region CONTROLS FUNCTION

		// ESC TO CLOSE || KEYDOWN TO DOWNLIST || KEYUP TO UPLIST
		//------------------------------------------------------------------------------------------------------------
		private void frmCongregacaoReuniaoListagem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
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


	}
}
