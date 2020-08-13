using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Setores
{
	public partial class frmSetorMovimentacao : CamadaUI.Modals.frmModFinBorder
	{
		private List<objMovimentacao> listMov = new List<objMovimentacao>();
		private BindingSource bindMov = new BindingSource();
		private MovimentacaoBLL mBLL = new MovimentacaoBLL();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos
		private objSetor SetorSelected;
		private Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmSetorMovimentacao(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter conta
			DefineSetor(SetorPadrao());

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- Handlers
			HandlerKeyDownControl(this);
			rbtPorMes.CheckedChanged += rbt_CheckedChanged;
			rbtPorPeriodo.CheckedChanged += rbt_CheckedChanged;
			rbtTodas.CheckedChanged += rbt_CheckedChanged;
		}

		// CONTROLA O MES
		//------------------------------------------------------------------------------------------------------------
		public DateTime propMes
		{
			get
			{
				return _myMes;
			}
			set
			{
				_myMes = value;

				// define data inicial e data final
				_dtInicial = new DateTime(_myMes.Year, _myMes.Month, 1);
				_dtFinal = new DateTime(_myMes.Year, _myMes.Month, DateTime.DaysInMonth(_myMes.Year, _myMes.Month));

				lblPeriodo.Text = _myMes.ToString("MMMM | yyyy");
				lblDtInicial.Text = _dtInicial.ToString("dd/MM");
				lblDtFinal.Text = _dtFinal.ToString("dd/MM");

				// habilita, desabilita btnPeriodoPosterior caso mes futuro
				//btnPeriodoPosterior.Enabled = !(_myMes.Year >= DateTime.Today.Year && _myMes.Month >= DateTime.Today.Month);
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

				// define list
				listMov = mBLL.GetMovimentacaoList(null, null, SetorSelected.IDSetor,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null);

				bindMov.DataSource = listMov;
				dgvListagem.DataSource = bindMov;

				// recalc totais labels
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

		//--- CALCULA OS TOTAIS E ALTERA AS LABELS
		//----------------------------------------------------------------------------------
		private void CalculaTotais()
		{
			decimal vlEntrada = listMov.Where(x => x.MovTipoDescricao == "ENTRADA").Sum(x => x.MovValor);
			lblValorEntradas.Text = vlEntrada.ToString("C");

			decimal vlSaida = listMov.Where(x => x.MovTipoDescricao == "SAIDA").Sum(x => x.MovValor);
			lblValorSaidas.Text = vlSaida.ToString("C");

			decimal vlTransf = listMov.Where(x => x.MovTipoDescricao == "TRANSFERENCIA").Sum(x => x.MovValor);
			lblValorTransferido.Text = vlTransf.ToString("C");
		}

		// DFEFINE CONTA SELECTED
		//------------------------------------------------------------------------------------------------------------
		private void DefineSetor(objSetor conta)
		{
			SetorSelected = conta;
			txtSetor.Text = conta.Setor;
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

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (0) COLUNA DATA
			clnMovData.DataPropertyName = "MovData";
			clnMovData.Visible = true;
			clnMovData.ReadOnly = true;
			clnMovData.Resizable = DataGridViewTriState.False;
			clnMovData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnMovData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnMovData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//clnMovData.DefaultCellStyle.Font = clnFont;
			colList.Add(clnMovData);

			//--- (1) COLUNA ORIGEM DA MOVIMENTACAO
			clnMovTipoDescricao.DataPropertyName = "MovTipoDescricao";
			clnMovTipoDescricao.Visible = true;
			clnMovTipoDescricao.ReadOnly = true;
			clnMovTipoDescricao.Resizable = DataGridViewTriState.False;
			clnMovTipoDescricao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnMovTipoDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnMovTipoDescricao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//clnMovOrigem.DefaultCellStyle.Font = clnFont;
			colList.Add(clnMovTipoDescricao);

			//--- (2) COLUNA DESCRICAO DA ORIGEM
			clnDescricaoOrigem.DataPropertyName = "DescricaoOrigem";
			clnDescricaoOrigem.Visible = true;
			clnDescricaoOrigem.ReadOnly = true;
			clnDescricaoOrigem.Resizable = DataGridViewTriState.False;
			clnDescricaoOrigem.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDescricaoOrigem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDescricaoOrigem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//clnDescricaoOrigem.DefaultCellStyle.Font = clnFont;
			colList.Add(clnDescricaoOrigem);

			//--- (3) COLUNA IDORIGEM
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnIDOrigem.DataPropertyName = "IDOrigem";
			clnIDOrigem.Visible = true;
			clnIDOrigem.ReadOnly = true;
			clnIDOrigem.Resizable = DataGridViewTriState.False;
			clnIDOrigem.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIDOrigem.DefaultCellStyle.Padding = newPadding;
			clnIDOrigem.DefaultCellStyle.Format = "0000";
			//clnIDOrigem.DefaultCellStyle.Font = clnFont;
			colList.Add(clnIDOrigem);

			//--- (4) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//clnSetor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnSetor);

			//--- (5) COLUNA CONTA
			clnConta.DataPropertyName = "Conta";
			clnConta.Visible = true;
			clnConta.ReadOnly = true;
			clnConta.Resizable = DataGridViewTriState.False;
			clnConta.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnConta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnConta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//clnSetor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnConta);

			//--- (6) COLUNA CAIXA
			clnIDCaixa.DataPropertyName = "IDCaixa";
			clnIDCaixa.Visible = true;
			clnIDCaixa.ReadOnly = true;
			clnIDCaixa.Resizable = DataGridViewTriState.False;
			clnIDCaixa.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIDCaixa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIDCaixa.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIDCaixa.DefaultCellStyle.Format = "0000";
			//clnIDCaixa.DefaultCellStyle.Font = clnFont;
			colList.Add(clnIDCaixa);

			//--- (7) COLUNA VALOR
			clnValorReal.DataPropertyName = "MovValor";
			clnValorReal.Visible = true;
			clnValorReal.ReadOnly = true;
			clnValorReal.Resizable = DataGridViewTriState.False;
			clnValorReal.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorReal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorReal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			//clnValorReal.DefaultCellStyle.Font = clnFont;
			clnValorReal.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnValorReal);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		// ON DOUBLE CLICK SELECT ITEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//mnuItemQuitar_Click(sender, null);
		}

		// ON ENTER SELECT ITEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				dgvListagem_CellDoubleClick(sender, null);
			}
		}

		// CONTROLA AS CORES DA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnMovTipoDescricao.Index)
			{
				objMovimentacao mov = (objMovimentacao)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (mov.MovTipoDescricao == "SAIDA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
				else if (mov.MovTipoDescricao == "ENTRADA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(227, 231, 234);
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
				}
				else if (mov.MovTipoDescricao == "TRANSFERENCIA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen;
					//dgvListagem.Rows[e.RowIndex].DefaultCellStyle.Font = clnFont;
					e.CellStyle.Font = clnFont;
					e.CellStyle.ForeColor = Color.DarkGreen;
					e.CellStyle.SelectionForeColor = Color.Honeydew;
				}
			}
			else if (e.ColumnIndex == clnValorReal.Index)
			{
				objMovimentacao mov = (objMovimentacao)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (mov.MovValor >= 0)
				{
					e.CellStyle.ForeColor = Color.DarkBlue;
					e.CellStyle.SelectionForeColor = Color.White;
					e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
				else
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
					e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
			}
			else if (e.ColumnIndex == clnDescricaoOrigem.Index)
			{
				e.CellStyle.Font = clnFont;
				e.CellStyle.WrapMode = DataGridViewTriState.False;
			}
		}

		// COMMIT UPDATED VALUE
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				dgvListagem.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, SetorSelected.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					DefineSetor(frm.propEscolha);
					ObterDados();
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
					txtSetor,
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
			}
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = { txtSetor, };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region DATE MONTH CONTROLER

		private void btnPeriodoAnterior_Click(object sender, EventArgs e)
		{
			if (propMes.Month == 1)
			{
				propMes = new DateTime(propMes.Year - 1, 12, propMes.Day); // subtract one year
			}
			else
			{
				propMes = propMes.AddMonths(-1);
			}

			ObterDados();
		}

		private void btnPeriodoPosterior_Click(object sender, EventArgs e)
		{
			if (propMes.Month == 12)
			{
				propMes = new DateTime(propMes.Year + 1, 1, propMes.Day); // subtract one year
			}
			else
			{
				propMes = propMes.AddMonths(1);
			}

			ObterDados();
		}

		private void btnMesAtual_Click(object sender, EventArgs e)
		{
			propMes = DateTime.Today;
			ObterDados();
		}

		private void rbt_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtTodas.Checked == true) // TODAS
			{
				pnlPorMes.Visible = false;
				pnlPorPeriodo.Visible = false;
				Panel2.Width = 350;

				if (_ProcuraTipo != 3)
				{
					_ProcuraTipo = 3;
					ObterDados();
				}

			}
			else if (rbtPorMes.Checked == true) // POR MES
			{
				pnlPorMes.Visible = true;
				pnlPorPeriodo.Visible = false;
				_myMes = _dtInicial;
				Panel2.Width = 674;

				if (_ProcuraTipo != 1)
				{
					_ProcuraTipo = 1;
					ObterDados();
				}
			}
			else if (rbtPorPeriodo.Checked == true) // POR PERIODO
			{
				pnlPorMes.Visible = false;
				pnlPorPeriodo.Visible = true;
				Panel2.Width = 674;

				if (_ProcuraTipo != 2)
				{
					_ProcuraTipo = 2;
					ObterDados();
				}
			}
		}

		private void btnDt_Click(object sender, EventArgs e)
		{
			bool IsDtInicial = ((Control)sender).Name == "btnDtInicial" ? true : false;

			var frm = new Main.frmDateGet(IsDtInicial ? "Escolha a Data Inicial" : "Escolha a Data Final",
										EnumDataTipo.PassadoOuFuturo,
										IsDtInicial ? _dtInicial : _dtFinal, this);

			frm.ShowDialog();
			if (frm.DialogResult != DialogResult.OK) return;

			//--- define a data selecionada
			if (IsDtInicial)
			{
				_dtInicial = (DateTime)frm.propDataInfo;
				lblDtInicial.Text = _dtInicial.ToString("dd/MM");

				//--- verifica se a data final é menor que a data inicial
				if (_dtFinal < _dtInicial)
				{
					_dtFinal = _dtInicial;
					lblDtFinal.Text = _dtFinal.ToString("dd/MM");
				}
			}
			else
			{
				_dtFinal = (DateTime)frm.propDataInfo;
				lblDtFinal.Text = _dtFinal.ToString("dd/MM");

				//--- verifica se a data final é menor que a data inicial
				if (_dtInicial > _dtFinal)
				{
					_dtInicial = _dtFinal;
					lblDtInicial.Text = _dtInicial.ToString("dd/MM");
				}
			}

			ObterDados();
		}

		// OPEN MONTH YEAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void lblPeriodo_DoubleClick(object sender, EventArgs e)
		{
			Main.frmDateMesAnoGet frm = new Main.frmDateMesAnoGet(
				"Mês e Ano da procura.", EnumDataTipo.PassadoOuFuturo, _myMes, this
			);

			frm.ShowDialog();
			if (frm.DialogResult != DialogResult.OK) return;

			propMes = (DateTime)frm.propDataInfo;
			ObterDados();
		}

		#endregion // DATE MONTH CONTROLER --- END

		#region MENU SUSPENSO

		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			// check button
			if (e.Button != MouseButtons.Right) return;

			Control c = (Control)sender;
			DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
			dgvListagem.ClearSelection();

			if (hit.Type != DataGridViewHitTestType.Cell) return;

			// seleciona o ROW
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListagem.CurrentCell = dgvListagem.Rows[hit.RowIndex].Cells[2];
			dgvListagem.Rows[hit.RowIndex].Selected = true;

			// mostra o MENU ativar e desativar
			objMovimentacao recItem = (objMovimentacao)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// mnuVerPagamentos
			/*
			switch (recItem.IDSituacao)
			{
				case 1: // EM ABERTO
					mnuItemAlterar.Enabled = true;
					mnuItemAlterar.Text = "Alterar";
					mnuItemCancelar.Enabled = true;
					mnuItemNormalizar.Enabled = false;
					mnuItemReceber.Enabled = true;
					mnuItemEstornar.Enabled = false;
					break;
				case 2: // RECEBIDAS
					mnuItemAlterar.Enabled = false;
					mnuItemCancelar.Enabled = false;
					mnuItemNormalizar.Enabled = false;
					mnuItemReceber.Enabled = false;
					mnuItemEstornar.Enabled = true;
					break;
				case 3: // CANCELADAS
					mnuItemAlterar.Enabled = false;
					mnuItemCancelar.Enabled = false;
					mnuItemNormalizar.Enabled = true;
					mnuItemReceber.Enabled = false;
					mnuItemEstornar.Enabled = false;
					break;
				default:
					break;
			}
			*/
			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		//--- MENU VER ORIGEM
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemVerOrigem_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Get A Pagar on list
			objMovimentacao item = (objMovimentacao)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				/*
				Entradas.frmContribuicao frm = new Entradas.frmContribuicao(item.IDContribuicao);
				Visible = false;
				frm.ShowDialog();
				DesativaMenuPrincipal();
				Visible = true;
				*/
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir a Origem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // MENU SUSPENSO --- END

		#region TOOLTIP
		private void lblPeriodo_MouseHover(object sender, EventArgs e)
		{
			ShowToolTip((Control)sender, ((Control)sender).Width - 100);
			lblPeriodo.MouseHover -= lblPeriodo_MouseHover;
		}

		private void ShowToolTip(Control controle, int? xPosition = null)
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

			// define xPosition of ToolTip
			if (xPosition == null)
			{
				xPosition = controle.Width - 30;
			}

			if (controle.Tag == null)
			{
				toolTip1.Show("Clique aqui...", controle, (int)xPosition, -40, 2000);
			}
			else
			{
				toolTip1.Show(controle.Tag.ToString(), controle, (int)xPosition, -40, 2000);
			}
		}

		#endregion

	}
}
