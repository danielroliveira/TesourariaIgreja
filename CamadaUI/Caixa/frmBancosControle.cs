﻿using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaBLL;
using System.Diagnostics;

namespace CamadaUI.Caixa
{
	public partial class frmBancosControle : CamadaUI.Modals.frmModFinBorder
	{
		private List<classBanco> list;
		private BindingSource bindList = new BindingSource();
		BancoBLL bBLL = new BancoBLL();

		private Form _formOrigem;

		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;
		private Image ImgNew = Properties.Resources.novo_peq_24;

		private EnumFlagEstado _Sit;

		public objBanco propEscolhido { get; set; }

		//=================================================================================================
		// SUB NEW
		//=================================================================================================
		#region CONSTRUCTOR | SUB NEW

		public frmBancosControle(Form formOrigem = null)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			AtivarToolStripMenuItem.Text = "Ativar Banco";
			DesativarToolStripMenuItem.Text = "Desativar Banco";

			bindList.DataSource = typeof(classBanco);
			ObterDados();
			FormataListagem();

			if (dgvListagem.RowCount > 0)
				Sit = EnumFlagEstado.RegistroSalvo;
			else
			{
				bindList.AddNew();
				Sit = EnumFlagEstado.NovoRegistro;
			}
		}

		// ON SHOW GOTO CONTROL COLLUN CADASTRO
		private void frmBancosControle_Shown(object sender, EventArgs e)
		{
			if (list.Count == 0)
			{
				dgvListagem.CurrentCell = dgvListagem.Rows[dgvListagem.CurrentRow.Index].Cells[1];
				dgvListagem.BeginEdit(false);
			}

			dgvListagem.CellEnter += DgvListagem_CellEnter;

		}

		private class classBanco : objBanco
		{
			public EnumFlagEstado RowSit { get; set; }

			public static List<classBanco> convertFrom(List<objBanco> lstBanco)
			{
				var novaClasse = new List<classBanco>();

				foreach (var banco in lstBanco)
				{
					var cl = new classBanco()
					{
						BancoNome = banco.BancoNome,
						Ativo = banco.Ativo,
						IDBanco = banco.IDBanco,
						Sigla = banco.Sigla,
						RowSit = banco.IDBanco == null ? EnumFlagEstado.NovoRegistro : EnumFlagEstado.RegistroSalvo
					};

					novaClasse.Add(cl);
				}

				return novaClasse;
			}

		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public EnumFlagEstado Sit
		{
			get { return _Sit; }
			set
			{
				_Sit = value;
				switch (value)
				{
					case EnumFlagEstado.RegistroSalvo:
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						btnNovo.Enabled = true;
						lblAcao.Visible = false;
						lblAcao.Text = "";
						break;
					case EnumFlagEstado.Alterado:
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						btnNovo.Enabled = false;
						lblAcao.Visible = true;
						lblAcao.Text = $"Editando {dgvListagem.CurrentRow.Cells[1].Value}";
						break;
					case EnumFlagEstado.NovoRegistro:
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						btnNovo.Enabled = false;
						lblAcao.Visible = true;
						lblAcao.Text = "Adicionando Novo Registro";
						break;
					default:
						break;
				}
			}
		}

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				list = classBanco.convertFrom(bBLL.GetListBanco());
				bindList.DataSource = list;
				dgvListagem.DataSource = bindList;

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

		#endregion // CONSTRUCTOR | SUB NEW --- END

		//=================================================================================================
		// LISTAGEM | DATAGRIDVIEW
		//=================================================================================================
		#region LISTAGEM | DATAGRIDVIEW

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagem()
		{
			dgvListagem.Columns.Clear();
			dgvListagem.AutoGenerateColumns = false;
			dgvListagem.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgvListagem.MultiSelect = false;
			dgvListagem.ColumnHeadersVisible = true;
			dgvListagem.AllowUserToResizeRows = false;
			dgvListagem.AllowUserToResizeColumns = false;
			dgvListagem.RowHeadersWidth = 36;
			dgvListagem.RowTemplate.Height = 30;
			dgvListagem.StandardTab = false;
			dgvListagem.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDBanco";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "BancoNome";
			clnCadastro.Visible = true;
			clnCadastro.ReadOnly = false;
			clnCadastro.Resizable = DataGridViewTriState.False;
			clnCadastro.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCadastro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCadastro.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) COLUNA SIGLA
			clnSigla.DataPropertyName = "Sigla";
			clnSigla.Visible = true;
			clnSigla.ReadOnly = false;
			clnSigla.Resizable = DataGridViewTriState.False;
			clnSigla.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSigla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSigla.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (4) Coluna da imagem
			clnImage.Name = "Ativo";
			clnImage.ReadOnly = true;
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnID, clnCadastro, clnSigla, clnImage);
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnImage.Index)
			{
				objBanco item = (objBanco)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (item.IDBanco == null)
				{
					e.Value = ImgNew;
				}
				else
				{
					if (item.Ativo) e.Value = ImgAtivo;
					else e.Value = ImgInativo;
				}
			}
		}

		#endregion // LISTAGEM | DATAGRIDVIEW --- END

		//=================================================================================================
		// EDITING DATAGRID ITENS
		//=================================================================================================
		#region EDITING DATAGRID ITENS

		private void dgvListagem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			//--- impede alteracoes nas colunas
			if (e.ColumnIndex == clnID.Index || e.ColumnIndex == clnImage.Index)
			{
				e.Cancel = true;
				return;
			}

			classBanco currentItem = (classBanco)dgvListagem.Rows[e.RowIndex].DataBoundItem;

			if (Sit != EnumFlagEstado.RegistroSalvo && currentItem.RowSit == EnumFlagEstado.RegistroSalvo)
			{
				e.Cancel = true;
				return;
			}

			if (currentItem.IDBanco == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				currentItem.RowSit = EnumFlagEstado.NovoRegistro;
				dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
			}
			else
			{
				Sit = EnumFlagEstado.Alterado;
				currentItem.RowSit = EnumFlagEstado.Alterado;
				dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
			}
		}

		//--- AO PRESSIONAR A TECLA (ENTER) ENVIAR (TAB) NO DATAGRID
		private void dgvListagem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int iColumn = dgvListagem.CurrentCell.ColumnIndex;
				int iRow = dgvListagem.CurrentCell.RowIndex;

				e.SuppressKeyPress = true;
				e.Handled = true;

				try
				{
					if (iColumn == dgvListagem.ColumnCount - 2)
					{
						if (dgvListagem.RowCount > (iRow + 1))
						{
							dgvListagem.CurrentCell = dgvListagem[1, iRow + 1];
						}
						else
						{
							SelectNextControl(dgvListagem, true, false, true, true);
						}
					}
					else
					{
						dgvListagem.CurrentCell = dgvListagem[iColumn + 1, iRow];
					}
				}
				catch
				{

				}

			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;

				classBanco myItem = (classBanco)dgvListagem.CurrentRow.DataBoundItem;

				if (myItem.RowSit == EnumFlagEstado.NovoRegistro)
				{
					dgvListagem.Rows.Remove(dgvListagem.CurrentRow);
				}

				if (!list.Exists(x => x.RowSit != EnumFlagEstado.RegistroSalvo))
				{
					Sit = EnumFlagEstado.RegistroSalvo;
				}

			}
		}

		// VALIDA CELL | PROCURA DUPLICADO
		private void dgvListagem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			//--- verifica se a currenteCELL is Dirty
			if (!dgvListagem.IsCurrentCellDirty) return;

			if (e.ColumnIndex == 1)
			{
				if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
				{
					e.Cancel = false;
					return;
				}

				if (ProcuraBancoDuplicado(e.FormattedValue.ToString()) == false)
				{
					dgvListagem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Empty;
					e.Cancel = true;
					return;
				}
			}

			if (e.ColumnIndex == 2)
			{
				if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
				{
					e.Cancel = false;
					return;
				}

				if (ProcuraSiglaDuplicado(e.FormattedValue.ToString()) == false)
				{
					dgvListagem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Empty;
					e.Cancel = true;
					return;
				}
			}
		}

		// PROCURA DUPLICADO BANCO NOME & BANCO NUMERO
		private bool ProcuraBancoDuplicado(string valor)
		{
			foreach (classBanco banco in bindList.List)
			{
				if (banco.BancoNome?.ToUpper() == valor.ToUpper())
				{
					AbrirDialog($"Banco duplicado...\n O banco {valor.ToUpper()} já foi inserido.",
						"Duplicado",
						DialogType.OK,
						DialogIcon.Exclamation);
					return false;
				}
			}

			return true;
		}

		private bool ProcuraSiglaDuplicado(string valor)
		{
			foreach (classBanco banco in bindList.List)
			{
				if (banco.Sigla?.ToUpper() == valor.ToUpper())
				{
					AbrirDialog($"O número do Banco precisa ser exclusivo...\n O número {valor.ToUpper()} já foi inserido.",
						"Duplicado",
						DialogType.OK,
						DialogIcon.Exclamation);
					return false;
				}
			}

			return true;
		}

		// ON CELL ENTER GOTO NEXT CELL
		private void DgvListagem_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				SendKeys.Send("{TAB}");
			}
			else if (e.ColumnIndex == 3)
			{
				SendKeys.Send("+{TAB}");
			}
		}


		#endregion // EDITING DATAGRID ITENS --- END

		//=================================================================================================
		// BUTTONS FUNCTION
		//=================================================================================================
		#region BUTTONS FUNCTION

		// FECHAR
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		// ADD NEW
		private void btnNovo_Click(object sender, EventArgs e)
		{
			bindList.AddNew();
			Sit = EnumFlagEstado.NovoRegistro;
			dgvListagem.CurrentCell = dgvListagem.CurrentRow.Cells[0];
			//dgvListagem.CurrentCell = dgvListagem.CurrentRow.Cells[1];
			dgvListagem.BeginEdit(false);
		}

		// CANCEL
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			ObterDados();
			Sit = EnumFlagEstado.RegistroSalvo;
			if (list.Count > 0)
			{
				dgvListagem.CurrentCell = dgvListagem.Rows[dgvListagem.CurrentRow.Index].Cells[1];
			}
		}

		#endregion // BUTTONS FUNCTION --- END

		//=================================================================================================
		// SALVAR REGISTRO
		//=================================================================================================
		#region SALVAR REGISTRO

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			//--- Verifica os valores inseridos
			if (VerificaItems() == false) return;

			//--- verifica se é um ROW editado ou novo
			classBanco myItem;
			bool everyOK = true;

			foreach (DataGridViewRow row in dgvListagem.Rows)
			{
				try
				{
					myItem = (classBanco)row.DataBoundItem;

					if (myItem.RowSit == EnumFlagEstado.NovoRegistro || myItem.RowSit == EnumFlagEstado.Alterado)
					{
						if (myItem.RowSit == EnumFlagEstado.NovoRegistro)
						{
							var newItem = ItemInserir(myItem);
							myItem.IDBanco = newItem;
							bindList.ResetBindings(false);
						}
						else if (myItem.RowSit == EnumFlagEstado.Alterado)
						{
							ItemAlterar(myItem);
						}

						myItem.RowSit = EnumFlagEstado.RegistroSalvo;
					}
				}
				catch
				{
					everyOK = false;
					continue;
				}

			}

			if (everyOK)
			{
				ObterDados();
				Sit = EnumFlagEstado.RegistroSalvo;
				AbrirDialog("Registros salvos com sucesso!", "Registros Salvos");
			}
		}

		//--- VERIFICACAO SE O ITEM ESTA PRONTO PARA SER INSERIDO OU ALTERADO
		private bool VerificaItems()
		{
			classBanco Item = null;

			foreach (DataGridViewRow row in dgvListagem.Rows)
			{
				dgvListagem.EndEdit();

				try
				{
					Item = (classBanco)row.DataBoundItem;
				}
				catch
				{
					continue;
				}

				if (string.IsNullOrEmpty(Item.BancoNome))
				{
					dgvListagem.CurrentCell = row.Cells[1];
					MessageBox.Show("A descrição do Banco não pode ficar vazia...",
									"Campo Vazio",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return false;
				}

				if (string.IsNullOrEmpty(Item.Sigla))
				{
					dgvListagem.CurrentCell = row.Cells[2];
					MessageBox.Show("O número do Banco não pode ficar vazio...",
									"Campo Vazio",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return false;
				}
			}

			return true;
		}

		//--- INSERE NOVO ITEM NO TBL BANCO
		public int ItemInserir(objBanco banco)
		{
			try
			{
				//--- Ampulheta ON
				Cursor = Cursors.WaitCursor;

				int newID = bBLL.InsertBanco(banco);
				banco.IDBanco = newID;
				return newID;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu uma exceção ao inserir um novo banco\n" +
								ex.Message, "Exceção",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw ex;
			}
			finally
			{
				//--- Ampulheta OFF
				Cursor = Cursors.Default;

			}
		}

		//--- INSERE NOVO ITEM NO TBL BANCO
		public void ItemAlterar(objBanco banco)
		{
			try
			{
				//--- Ampulheta ON
				Cursor = Cursors.WaitCursor;

				bBLL.UpdateBanco(banco);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu uma exceção ao atualizar o banco/n" +
								ex.Message, "Exceção",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw ex;
			}
			finally
			{
				//--- Ampulheta OFF
				Cursor = Cursors.Default;

			}
		}

		#endregion // SALVAR REGISTRO --- END

		//=================================================================================================
		// TOOLSTRIP MENU
		//=================================================================================================
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
					objBanco banco = (objBanco)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

					if (banco.Ativo == true)
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
			if (dgvListagem.SelectedCells.Count == 0) return;

			//--- Verifica o item
			objBanco banco = (objBanco)dgvListagem.SelectedCells[0].OwningRow.DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(banco.Ativo ? "DESATIVAR " : "ATIVAR")} esse Banco?\n" +
									  banco.BancoNome.ToUpper(), (banco.Ativo ? "DESATIVAR " : "ATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			banco.Ativo = !banco.Ativo;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				bBLL.UpdateBanco(banco);

				//--- altera a imagem
				dgvListagem.Refresh();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar Taxa de Operadora..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}















		#endregion // ATIVAR DESATIVAR MENU --- END

		//=================================================================================================
		// FORM SELECTED APPARENCE
		//=================================================================================================
		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void frmContribuinteListagem_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmContribuinteListagem_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;

			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END
	}
}
