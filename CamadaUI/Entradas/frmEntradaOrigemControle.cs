using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmEntradaOrigemControle : CamadaUI.Modals.frmModFinBorder
	{
		private List<classTitular> list;
		private BindingSource bindList = new BindingSource();
		DespesaBLL bBLL = new DespesaBLL();

		private Form _formOrigem;

		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;
		private Image ImgNew = Properties.Resources.novo_peq_24;

		private EnumFlagEstado _Sit;

		public objDespesaTitular propEscolhido { get; set; }

		//=================================================================================================
		// SUB NEW
		//=================================================================================================
		#region CONSTRUCTOR | SUB NEW

		public frmEntradaOrigemControle(Form formOrigem = null)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			AtivarToolStripMenuItem.Text = "Ativar Titular";
			DesativarToolStripMenuItem.Text = "Desativar Titular";

			bindList.DataSource = typeof(classTitular);
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
		private void frmEntradaOrigemControle_Shown(object sender, EventArgs e)
		{
			if (list.Count == 0)
			{
				dgvListagem.CurrentCell = dgvListagem.Rows[dgvListagem.CurrentRow.Index].Cells[1];
				dgvListagem.BeginEdit(false);
			}

			dgvListagem.CellEnter += DgvListagem_CellEnter;

		}

		private class classTitular : objDespesaTitular
		{
			public classTitular() : base()
			{
				Ativo = true;
			}

			public EnumFlagEstado RowSit { get; set; }

			public static List<classTitular> convertFrom(List<objDespesaTitular> lstTitular)
			{
				var novaClasse = new List<classTitular>();

				foreach (var titular in lstTitular)
				{
					var cl = new classTitular()
					{
						Titular = titular.Titular,
						Ativo = titular.Ativo,
						IDTitular = titular.IDTitular,
						CNP = CNPConvert(titular.CNP),
						RowSit = titular.IDTitular == null ? EnumFlagEstado.NovoRegistro : EnumFlagEstado.RegistroSalvo
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
				list = classTitular.convertFrom(bBLL.GetTitularList());
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
			clnID.DataPropertyName = "IDTitular";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "Titular";
			clnCadastro.Visible = true;
			clnCadastro.ReadOnly = false;
			clnCadastro.Resizable = DataGridViewTriState.False;
			clnCadastro.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCadastro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCadastro.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) COLUNA SIGLA
			clnCNP.DataPropertyName = "CNP";
			clnCNP.Visible = true;
			clnCNP.ReadOnly = false;
			clnCNP.Resizable = DataGridViewTriState.False;
			clnCNP.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCNP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCNP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (4) Coluna da imagem
			clnImage.Name = "Ativo";
			clnImage.ReadOnly = true;
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnID, clnCadastro, clnCNP, clnImage);
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnImage.Index)
			{
				objDespesaTitular item = (objDespesaTitular)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (item.IDTitular == null)
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

			classTitular currentItem = (classTitular)dgvListagem.Rows[e.RowIndex].DataBoundItem;

			if (Sit != EnumFlagEstado.RegistroSalvo && currentItem.RowSit == EnumFlagEstado.RegistroSalvo)
			{
				e.Cancel = true;
				return;
			}

			if (currentItem.IDTitular == null)
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

				classTitular myItem = (classTitular)dgvListagem.CurrentRow.DataBoundItem;

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

				if (ProcuraTitularDuplicado(e.FormattedValue.ToString()) == false)
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

		// PROCURA DUPLICADO TITULAR NOME & TITULAR NUMERO
		private bool ProcuraTitularDuplicado(string valor)
		{
			foreach (classTitular titular in bindList.List)
			{
				if (titular.Titular?.ToUpper() == valor.ToUpper())
				{
					AbrirDialog($"Nome de Titular duplicado...\n O titular {valor.ToUpper()} já foi inserido.",
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
			foreach (classTitular titular in bindList.List)
			{
				if (titular.CNP?.ToUpper() == valor.ToUpper())
				{
					AbrirDialog($"O CNP do titular precisa ser exclusivo...\n O CNP {valor.ToUpper()} já foi inserido.",
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

			if (Application.OpenForms.Count == 1)
			{
				MostraMenuPrincipal();
			}
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
			classTitular myItem;
			bool everyOK = true;

			foreach (DataGridViewRow row in dgvListagem.Rows)
			{
				try
				{
					myItem = (classTitular)row.DataBoundItem;
					myItem.CNP = CNPConvert(myItem.CNP);

					if (myItem.RowSit == EnumFlagEstado.NovoRegistro || myItem.RowSit == EnumFlagEstado.Alterado)
					{
						if (myItem.RowSit == EnumFlagEstado.NovoRegistro)
						{
							var newItem = ItemInserir(myItem);
							myItem.IDTitular = newItem;
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
			classTitular Item = null;

			foreach (DataGridViewRow row in dgvListagem.Rows)
			{
				dgvListagem.EndEdit();

				try
				{
					Item = (classTitular)row.DataBoundItem;
				}
				catch
				{
					continue;
				}

				if (string.IsNullOrEmpty(Item.Titular))
				{
					dgvListagem.CurrentCell = row.Cells[1];
					MessageBox.Show("A descrição/nome do Titular não pode ficar vazia...",
									"Campo Vazio",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return false;
				}

				if (string.IsNullOrEmpty(Item.CNP))
				{
					dgvListagem.CurrentCell = row.Cells[2];
					MessageBox.Show("O número do CNP: CNPJ ou CPF do titular não pode ficar vazio...",
									"Campo Vazio",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					return false;
				}
			}

			return true;
		}

		//--- INSERE NOVO ITEM NO TBL TITULAR
		public int ItemInserir(objDespesaTitular titular)
		{
			try
			{
				//--- Ampulheta ON
				Cursor = Cursors.WaitCursor;

				int newID = bBLL.InsertTitutar(titular);
				titular.IDTitular = newID;
				return newID;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu uma exceção ao inserir um novo titular\n" +
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

		//--- INSERE NOVO ITEM NO TBL TITULAR
		public void ItemAlterar(objDespesaTitular titular)
		{
			try
			{
				//--- Ampulheta ON
				Cursor = Cursors.WaitCursor;

				bBLL.UpdateTitular(titular);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocorreu uma exceção ao atualizar o titular/n" +
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
					objDespesaTitular titular = (objDespesaTitular)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

					if (titular.Ativo == true)
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
			objDespesaTitular titular = (objDespesaTitular)dgvListagem.SelectedCells[0].OwningRow.DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(titular.Ativo ? "DESATIVAR " : "ATIVAR")} esse Titular?\n" +
									  titular.Titular.ToUpper(), (titular.Ativo ? "DESATIVAR " : "ATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			titular.Ativo = !titular.Ativo;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				bBLL.UpdateTitular(titular);

				//--- altera a imagem
				dgvListagem.Refresh();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar o registro do Titular..." + "\n" +
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
		private void frm_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frm_FormClosed(object sender, FormClosedEventArgs e)
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
