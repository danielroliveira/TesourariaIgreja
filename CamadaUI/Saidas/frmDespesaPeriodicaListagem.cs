using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmDespesaPeriodicaListagem : CamadaUI.Modals.frmModFinBorder
	{
		private DespesaPeriodicaBLL dBLL = new DespesaPeriodicaBLL();
		private List<objDespesaPeriodica> listCont = new List<objDespesaPeriodica>();
		private Form _formOrigem;
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;
		private Image ImgAccept = Properties.Resources.accept_16;

		private bool _Alterado = false;
		private int? IDSetor;
		private int? IDCredor;
		private int? IDTipo;
		private bool Ativa = true;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaPeriodicaListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- get dados
			dgvListagem.CellDoubleClick += btnVisualizar_Click;

			//--- Handlers
			HandlerKeyDownControl(this);
			AddHandlersRadioButSituacao();
		}


		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// define list
				listCont = dBLL.GetListDespesaPeriodica(
					Ativa,
					IDSetor,
					IDTipo,
					IDCredor);

				dgvListagem.DataSource = listCont;
				CalculaTotais();
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

		public bool propAlterado
		{
			get => _Alterado;
			set
			{
				if (value != _Alterado && value == true)
				{
					ShowToolTip(btnProcurar);
				}

				_Alterado = value;
				btnProcurar.Enabled = value;
			}
		}

		//--- CALCULA OS TOTAIS E ALTERA AS LABELS
		//----------------------------------------------------------------------------------
		private void CalculaTotais()
		{
			decimal vlTotal = listCont.Sum(x => x.DespesaValor);
			lblValorTotal.Text = vlTotal.ToString("C");

			decimal vlMensal = listCont.Sum(x => x.DespesaValorMensal);
			lblValorMensal.Text = vlMensal.ToString("C");
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

			// DEFINE COLUMN FONT
			Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDDespesa";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;
			colList.Add(clnID);

			//--- (2) COLUNA DATA
			clnData.DataPropertyName = "DespesaData";
			clnData.Visible = true;
			clnData.ReadOnly = true;
			clnData.Resizable = DataGridViewTriState.False;
			clnData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.DefaultCellStyle.Font = clnFont;
			colList.Add(clnData);

			//--- (3) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnSetor);

			//--- (4) COLUNA TIPO
			clnTipo.DataPropertyName = "DespesaTipo";
			clnTipo.Visible = true;
			clnTipo.ReadOnly = true;
			clnTipo.Resizable = DataGridViewTriState.False;
			clnTipo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.DefaultCellStyle.Font = clnFont;
			colList.Add(clnTipo);

			//--- (5) COLUNA CREDOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnCredor);

			//--- (6) COLUNA DOCUMENTO TIPO
			clnRecorrencia.DataPropertyName = "RecorrenciaTipoDescricao";
			clnRecorrencia.Visible = true;
			clnRecorrencia.ReadOnly = true;
			clnRecorrencia.Resizable = DataGridViewTriState.False;
			clnRecorrencia.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnRecorrencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnRecorrencia.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnRecorrencia.DefaultCellStyle.Font = clnFont;
			colList.Add(clnRecorrencia);

			//--- (7) COLUNA VALOR
			clnValor.DataPropertyName = "DespesaValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnValor);

			//--- (7) COLUNA VALOR MENSAL
			clnValorMensal.DataPropertyName = "DespesaValorMensal";
			clnValorMensal.Visible = true;
			clnValorMensal.ReadOnly = true;
			clnValorMensal.Resizable = DataGridViewTriState.False;
			clnValorMensal.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorMensal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorMensal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorMensal.DefaultCellStyle.Font = clnFont;
			colList.Add(clnValorMensal);

			//--- (9) COLUNA ATIVO IMAGE
			clnAtivo.ReadOnly = true;
			clnAtivo.Resizable = DataGridViewTriState.False;
			clnAtivo.HeaderText = "Ativa";
			clnAtivo.Resizable = DataGridViewTriState.False;
			clnAtivo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnAtivo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			colList.Add(clnAtivo);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnAtivo.Index)
			{
				objDespesaPeriodica item = (objDespesaPeriodica)dgvListagem.Rows[e.RowIndex].DataBoundItem;

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
				btnVisualizar_Click(sender, new EventArgs());
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

		// ADICIONAR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			frmDespesaPeriodica frm = new frmDespesaPeriodica(new objDespesaPeriodica(null));
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// EDITAR DESPESA ESCOLHIDA
		//------------------------------------------------------------------------------------------------------------
		private void btnVisualizar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Editar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objDespesaPeriodica item = (objDespesaPeriodica)dgvListagem.SelectedRows[0].DataBoundItem;

			frmDespesaPeriodica frm = new frmDespesaPeriodica(item);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// PROCURAR
		//------------------------------------------------------------------------------------------------------------
		private void btnProcurar_Click(object sender, EventArgs e)
		{
			ObterDados();
			propAlterado = false;
		}

		// LIMPAR
		//------------------------------------------------------------------------------------------------------------
		private void btnLimpar_Click(object sender, EventArgs e)
		{
			if (IDSetor != null || IDCredor != null || IDTipo != null)
			{
				txtSetor.Clear();
				IDSetor = null;
				txtCredor.Clear();
				IDCredor = null;
				txtDespesaTipo.Clear();
				IDTipo = null;
				ObterDados();
			}
		}

		#endregion

		#region CONTROL FUNCTIONS

		// ESC TO CLOSE || KEYDOWN TO DOWNLIST || KEYUP TO UPLIST
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyDown(object sender, KeyEventArgs e)
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

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtDespesaTipo,
					txtSetor,
					txtCredor
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtDespesaTipo":
						btnSetTipo_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtCredor":
						btnSetCredor_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtDespesaTipo":
						if (IDTipo != null) propAlterado = true;
						txtDespesaTipo.Clear();
						IDTipo = null;
						break;
					case "txtSetor":
						if (IDSetor != null) propAlterado = true;
						txtSetor.Clear();
						IDSetor = null;
						break;
					case "txtCredor":
						if (IDCredor != null) propAlterado = true;
						txtCredor.Clear();
						IDCredor = null;
						break;
					default:
						break;
				}
			}
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtDespesaTipo,
					txtSetor,
					txtCredor };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}
		#endregion // CONTROL FUNCTIONS --- END

		#region CONTROL SITUACAO

		private void AddHandlersRadioButSituacao()
		{
			rbtAtivas.CheckedChanged += rbtSit_CheckedChanged;
			rbtInativas.CheckedChanged += rbtSit_CheckedChanged;
		}

		private void rbtSit_CheckedChanged(object sender, EventArgs e)
		{
			bool newSit = bool.Parse(((Control)sender).Tag.ToString());

			if (Ativa != newSit)
			{
				Ativa = newSit;
				ObterDados();

				if (Ativa)
				{
					rbtAtivas.Image = ImgAccept;
					rbtInativas.Image = null;
				}
				else
				{
					rbtAtivas.Image = null;
					rbtInativas.Image = ImgAccept;
				}

			}
		}

		#endregion // CONTROL SITUACAO --- END

		#region BUTTONS PROCURA

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetTipo_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmDespesaTipoProcura frm = new frmDespesaTipoProcura(this, IDTipo);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (IDTipo != (int)frm.propEscolha.IDDespesaTipo) propAlterado = true;

					IDTipo = (int)frm.propEscolha.IDDespesaTipo;
					txtDespesaTipo.Text = frm.propEscolha.DespesaTipo;
				}

				//--- select
				txtDespesaTipo.Focus();
				txtDespesaTipo.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Setores.frmSetorProcura frm = new Setores.frmSetorProcura(this, IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (IDSetor != (int)frm.propEscolha.IDSetor) propAlterado = true;

					IDSetor = (int)frm.propEscolha.IDSetor;
					txtSetor.Text = frm.propEscolha.Setor;
				}

				//--- select
				txtSetor.Focus();
				txtSetor.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetCredor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Registres.frmCredorListagem frm = new Registres.frmCredorListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CONTRIBUINTE
				{
					if (IDCredor != (int)frm.propEscolha.IDCredor) propAlterado = true;

					IDCredor = (int)frm.propEscolha.IDCredor;
					txtCredor.Text = frm.propEscolha.Credor;
				}

				//--- select
				txtCredor.Focus();
				txtCredor.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS PROCURA --- END

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
				if (dgvListagem.Columns[hit.ColumnIndex].Name == "clnAtivo")
				{
					objDespesaPeriodica desp = (objDespesaPeriodica)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

					if (desp.Ativa == true)
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
			objDespesaPeriodica desp = (objDespesaPeriodica)dgvListagem.SelectedRows[0].DataBoundItem;

			//---pergunta ao usuário
			var reponse = AbrirDialog($"Deseja realmente {(desp.Ativa ? "DESATIVAR " : "ATIVAR")} essa Despesa Periódica?\n" +
									  desp.DespesaTipo.ToUpper(), (desp.Ativa ? "DESATIVAR " : "ATIVAR"),
									  DialogType.SIM_NAO, DialogIcon.Question);
			if (reponse == DialogResult.No) return;

			//--- altera o valor
			desp.Ativa = !desp.Ativa;

			//--- Salvar o Registro
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				dBLL.UpdateDespesaPeriodicaAtiva((long)desp.IDDespesa, desp.Ativa);

				//--- altera a imagem
				ObterDados();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Alterar a Despesa Periódica..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // ATIVAR DESATIVAR MENU --- END

		#region TOOLTIP

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void Control_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= Control_Enter;
		}

		private void ShowToolTip(Control controle)
		{
			//Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip()
			{
				AutoPopDelay = 2000, // Define o delay para a ToolTip
				InitialDelay = 2000,
				ReshowDelay = 500,
				IsBalloon = true,
				UseAnimation = true,
				UseFading = true
			};

			if (controle.Tag == null)
			{
				toolTip1.Show("Clique aqui...", controle, controle.Width - 30, -40, 2000);
			}
			else
			{
				toolTip1.Show(controle.Tag.ToString(), controle, controle.Width - 30, -40, 2000);
			}
		}


		#endregion

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			AbrirDialog("Em Implementação, fale com o administrador do sistema...", "Implementando");
		}
	}
}
