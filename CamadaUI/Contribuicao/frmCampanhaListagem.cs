﻿using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Contribuicao
{
	public partial class frmCampanhaListagem : CamadaUI.Modals.frmModFinBorder
	{
		private CampanhaBLL cBLL = new CampanhaBLL();
		private List<objCampanha> listCampanha = new List<objCampanha>();
		private BindingSource bind = new BindingSource();
		private Form _formOrigem;
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;

		#region NEW | OPEN FUNCTIONS

		public frmCampanhaListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;
			CarregaCmbAtivo();
			ObterDados(this, new EventArgs());
			FormataListagem();

			//--- get dados
			cmbAtivo.SelectedValueChanged += ObterDados;
			dgvListagem.CellDoubleClick += btnEditar_Click;
			txtProcura.TextChanged += FiltrarListagem;
			HandlerKeyDownControl(this);
		}

		//--- PROPRIEDADE DE ESCOLHA
		public objCampanha propEscolha { get; set; }

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listCampanha = cBLL.GetListCampanha("", Convert.ToBoolean(cmbAtivo.SelectedValue));
				bind.DataSource = listCampanha;
				dgvListagem.DataSource = bind;
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
			dtAtivo.Rows.Add(new object[] { true, "Ativas" });
			dtAtivo.Rows.Add(new object[] { false, "Concluídas" });

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
			clnID.DataPropertyName = "IDCampanha";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "Campanha";
			clnCadastro.Visible = true;
			clnCadastro.ReadOnly = true;
			clnCadastro.Resizable = DataGridViewTriState.False;
			clnCadastro.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCadastro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCadastro.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) COLUNA OBJETIVO VALOR
			clnObjetivoValor.DataPropertyName = "ObjetivoValor";
			clnObjetivoValor.Visible = true;
			clnObjetivoValor.ReadOnly = true;
			clnObjetivoValor.Resizable = DataGridViewTriState.False;
			clnObjetivoValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnObjetivoValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnObjetivoValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnObjetivoValor.DefaultCellStyle.Format = "C";

			//--- (4) COLUNA SALDO
			clnCampanhaSaldo.DataPropertyName = "CampanhaSaldo";
			clnCampanhaSaldo.Visible = true;
			clnCampanhaSaldo.ReadOnly = true;
			clnCampanhaSaldo.Resizable = DataGridViewTriState.False;
			clnCampanhaSaldo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCampanhaSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnCampanhaSaldo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnCampanhaSaldo.DefaultCellStyle.Format = "C";

			//--- (5) Coluna da imagem
			clnImage.Name = "Ativa";
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnID, clnCadastro, clnObjetivoValor, clnCampanhaSaldo, clnImage);
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnImage.Index)
			{
				objCampanha item = (objCampanha)dgvListagem.Rows[e.RowIndex].DataBoundItem;
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
			frmCampanha frm = new frmCampanha(new objCampanha(null));
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
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
			objCampanha item = (objCampanha)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- open edit form
			if (_formOrigem == null)
			{
				frmCampanha frm = new frmCampanha(item);
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

		private void FiltrarListagem(object sender, EventArgs e)
		{
			if (txtProcura.TextLength > 0)
			{
				// filter
				if (!int.TryParse(txtProcura.Text, out int i))
				{
					// declare function
					Func<objCampanha, bool> FiltroItem = c => c.Campanha.ToLower().Contains(txtProcura.Text.ToLower());

					// aply filter using function
					dgvListagem.DataSource = listCampanha.FindAll(c => FiltroItem(c));
				}
				else
				{
					// declare function
					Func<objCampanha, bool> FiltroID = c => c.IDCampanha == i;

					// aply filter using function
					dgvListagem.DataSource = listCampanha.FindAll(c => FiltroID(c));
				}
			}
			else
			{
				dgvListagem.DataSource = listCampanha;
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
				objCampanha Campanha = (objCampanha)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

				if (Campanha.Ativa == true)
				{
					mnuConcluir.Text = "Concluir/Finalizar Campanha";
				}
				else
				{
					mnuConcluir.Text = "Reativar Campanha";
				}

				// revela menu
				MenuListagem.Show(c.PointToScreen(e.Location));

			}
		}

		private void AtivarDesativar_Campanha_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Verifica o item
			objCampanha camp = (objCampanha)dgvListagem.SelectedRows[0].DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(camp.Ativa ? "CONCLUIR | FINALIZAR" : "REATIVAR")} essa Campanha?\n" +
									  camp.Campanha.ToUpper(), (camp.Ativa ? "CONCLUIR " : "REATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			if (camp.Ativa)
			{
				camp.Ativa = false;
				camp.ConclusaoData = DateTime.Today;
			}
			else
			{
				camp.Ativa = true;
				camp.ConclusaoData = null;
			}

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				cBLL.UpdateCampanha(camp);

				//--- obter listagem
				ObterDados(sender, e);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar Campanha..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuRecalcularSaldo_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Verifica o item
			objCampanha camp = (objCampanha)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				decimal SaldoAtual = cBLL.GetCampanhaSaldo((int)camp.IDCampanha);

				if (SaldoAtual != camp.CampanhaSaldo)
				{
					camp.CampanhaSaldo = cBLL.GetCampanhaSaldo((int)camp.IDCampanha);
					cBLL.UpdateCampanha(camp);
					AbrirDialog("O Saldo Atual da Campanha foi alterado...", "Saldo Atual");
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter o Saldo da Campanha..." + "\n" +
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

		// ESC TO CLOSE || KEYDOWN TO DOWNLIST || KEYUP TO UPLIST
		//------------------------------------------------------------------------------------------------------------
		private void frmCampanhaListagem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
			else if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;
				btnAdicionar_Click(sender, e);
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
