using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Caixa
{
	public partial class frmCaixaListagem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objCaixa> listCaixa = new List<objCaixa>();
		private BindingSource bindMov = new BindingSource();
		private CaixaBLL cBLL = new CaixaBLL();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos
		private objConta ContaSelected;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmCaixaListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter conta
			DefineConta(ContaPadrao());

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
				listCaixa = cBLL.GetCaixaList(ContaSelected.IDConta,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null);

				bindMov.DataSource = listCaixa;
				dgvListagem.DataSource = bindMov;
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

		// DFEFINE CONTA SELECTED
		//------------------------------------------------------------------------------------------------------------
		private void DefineConta(objConta conta)
		{
			ContaSelected = conta;
			txtConta.Text = conta.Conta;
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

			//--- (0) COLUNA IDCAIXA
			clnID.DataPropertyName = "IDCaixa";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnID);

			//--- (1) COLUNA DATAINICIAL
			clnDataInicial.DataPropertyName = "DataInicial";
			clnDataInicial.Visible = true;
			clnDataInicial.ReadOnly = true;
			clnDataInicial.Resizable = DataGridViewTriState.False;
			clnDataInicial.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDataInicial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDataInicial.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnDataInicial);

			//--- (2) COLUNA DATA FINAL
			clnDataFinal.DataPropertyName = "DataFinal";
			clnDataFinal.Visible = true;
			clnDataFinal.ReadOnly = true;
			clnDataFinal.Resizable = DataGridViewTriState.False;
			clnDataFinal.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDataFinal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDataFinal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnDataFinal);

			//--- (3) COLUNA CONTA
			clnConta.DataPropertyName = "Conta";
			clnConta.Visible = true;
			clnConta.ReadOnly = true;
			clnConta.Resizable = DataGridViewTriState.False;
			clnConta.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnConta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnConta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//clnConta.DefaultCellStyle.Font = clnFont;
			colList.Add(clnConta);

			//--- (4) COLUNA SALDO ANTERIOR
			clnSaldoAnterior.DataPropertyName = "SaldoAnterior";
			clnSaldoAnterior.Visible = true;
			clnSaldoAnterior.ReadOnly = true;
			clnSaldoAnterior.Resizable = DataGridViewTriState.False;
			clnSaldoAnterior.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSaldoAnterior.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSaldoAnterior.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSaldoAnterior.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnSaldoAnterior);

			//--- (5) COLUNA SALDO FINAL
			clnSaldoFinal.DataPropertyName = "SaldoFinal";
			clnSaldoFinal.Visible = true;
			clnSaldoFinal.ReadOnly = true;
			clnSaldoFinal.Resizable = DataGridViewTriState.False;
			clnSaldoFinal.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSaldoFinal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSaldoFinal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSaldoFinal.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnSaldoFinal);

			//--- (5) COLUNA SALDO FINAL
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			colList.Add(clnSituacao);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		// ON DOUBLE CLICK SELECT ITEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			AbrirCaixa();
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

		// FORMAT ID ON LIST
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnID.Index)
			{
				e.Value = e.Value == null ? null : ((long)e.Value).ToString("D4");
			}
		}

		#endregion

		#region BUTTONS FUNCTION

		// NOVO CAIXA
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			this.Close();
			frmCaixaInserir frm = new frmCaixaInserir(_formOrigem);
			frm.MdiParent = Application.OpenForms[0];
			frm.Show();
		}

		// FECHAR FORMULARIO
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, ContaSelected.IDConta, false);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					DefineConta(frm.propEscolha);
					ObterDados();
				}

				//--- select
				txtConta.Focus();
				txtConta.SelectAll();
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

		private void AbrirCaixa()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- check selected item
				if (dgvListagem.SelectedRows.Count == 0)
				{
					AbrirDialog("Favor selecionar um registro para Visualizar...",
						"Selecionar Registro", DialogType.OK, DialogIcon.Information);
					return;
				}

				objCaixa caixa = (objCaixa)dgvListagem.SelectedRows[0].DataBoundItem;

				var frm = new frmCaixa(caixa, Application.OpenForms[0]);
				frm.MdiParent = Application.OpenForms[0];
				frm.Show();
				Close();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de caixa..." + "\n" +
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
					txtConta,
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
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
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
				Control[] controlesBloqueados = { txtConta, };

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
			objCaixa recItem = (objCaixa)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

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
			objCaixa item = (objCaixa)dgvListagem.SelectedRows[0].DataBoundItem;

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
