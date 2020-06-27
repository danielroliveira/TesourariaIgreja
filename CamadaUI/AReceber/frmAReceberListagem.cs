using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.AReceber
{
	public partial class frmAReceberListagem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objAReceber> listRec = new List<objAReceber>();
		private BindingSource bindRec = new BindingSource();
		private AReceberBLL rBLL = new AReceberBLL();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos
		private byte? _Situacao = 1; // 1: Em Aberto | 2: Recebidas | 3: Canceladas
		private int? _IDContaProvisoria = null;
		private decimal _vlBrutoSelected = 0;
		private decimal _vlRecebidoSelected = 0;
		private decimal _vlLiquidoSelected = 0;
		private int nItemsSelected = 0;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmAReceberListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- Handlers
			HandlerKeyDownControl(this);
			rbtPorMes.CheckedChanged += rbt_CheckedChanged;
			rbtPorPeriodo.CheckedChanged += rbt_CheckedChanged;
			rbtTodas.CheckedChanged += rbt_CheckedChanged;
			AddHandlersRadioButSituacao();
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

				// disable handler
				dgvListagem.CellValueChanged -= dgvListagem_CellValueChanged;

				// define list
				listRec = rBLL.GetListAReceber(
					_Situacao,
					_IDContaProvisoria,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null);

				bindRec.DataSource = listRec;
				dgvListagem.DataSource = bindRec;

				// recalc totais labels
				CalculaTotais();
				unCheckListagem();

				// enable handler
				dgvListagem.CellValueChanged += dgvListagem_CellValueChanged;

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
			decimal vlAPagar = listRec.Sum(x => x.ValorBruto);
			lblValorBruto.Text = vlAPagar.ToString("C");

			decimal vlLiquido = listRec.Sum(x => x.ValorLiquido);
			lblValorLiquido.Text = vlLiquido.ToString("C");

			decimal vlRecebido = listRec.Sum(x => x.ValorRecebido);
			lblValorRecebido.Text = vlRecebido.ToString("C");
		}

		//--- CALCULA OS TOTAIS DOS SELECIONADOS
		//----------------------------------------------------------------------------------
		private void CalculaTotaisSelected()
		{
			lblBrutoSelected.Text = _vlBrutoSelected.ToString("c");
			lblPrevisto.Text = (_vlLiquidoSelected - _vlRecebidoSelected).ToString("c");
			btnReceberLote.Visible = nItemsSelected > 1;
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

			//--- (0) COLUNA CHECK
			clnCheck.DataPropertyName = "";
			clnCheck.Visible = true;
			clnCheck.ReadOnly = false;
			clnCheck.Resizable = DataGridViewTriState.False;
			clnCheck.SortMode = DataGridViewColumnSortMode.NotSortable;
			colList.Add(clnCheck);

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDAReceber";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;
			colList.Add(clnID);

			//--- (2) COLUNA DATA
			clnCompensacaoData.DataPropertyName = "CompensacaoData";
			clnCompensacaoData.Visible = true;
			clnCompensacaoData.ReadOnly = true;
			clnCompensacaoData.Resizable = DataGridViewTriState.False;
			clnCompensacaoData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCompensacaoData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCompensacaoData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCompensacaoData.DefaultCellStyle.Font = clnFont;
			colList.Add(clnCompensacaoData);

			//--- (3) COLUNA FORMA DE ENTRADA
			clnEntradaForma.DataPropertyName = "EntradaForma";
			clnEntradaForma.Visible = true;
			clnEntradaForma.ReadOnly = true;
			clnEntradaForma.Resizable = DataGridViewTriState.False;
			clnEntradaForma.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnEntradaForma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnEntradaForma.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnEntradaForma.DefaultCellStyle.Font = clnFont;
			colList.Add(clnEntradaForma);

			//--- (4) COLUNA CONTA
			clnConta.DataPropertyName = "Conta";
			clnConta.Visible = true;
			clnConta.ReadOnly = true;
			clnConta.Resizable = DataGridViewTriState.False;
			clnConta.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnConta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnConta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnConta.DefaultCellStyle.Font = clnFont;
			colList.Add(clnConta);

			//--- (5) COLUNA SITUACAO
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.DefaultCellStyle.Font = clnFont;
			colList.Add(clnSituacao);

			//--- (6) COLUNA VALOR
			clnValorBruto.DataPropertyName = "ValorBruto";
			clnValorBruto.Visible = true;
			clnValorBruto.ReadOnly = true;
			clnValorBruto.Resizable = DataGridViewTriState.False;
			clnValorBruto.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorBruto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorBruto.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorBruto.DefaultCellStyle.Font = clnFont;
			clnValorBruto.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnValorBruto);

			//--- (7) COLUNA VALOR LIQUIDO
			clnValorLiquido.DataPropertyName = "ValorLiquido";
			clnValorLiquido.Visible = true;
			clnValorLiquido.ReadOnly = true;
			clnValorLiquido.Resizable = DataGridViewTriState.False;
			clnValorLiquido.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorLiquido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorLiquido.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorLiquido.DefaultCellStyle.Font = clnFont;
			clnValorLiquido.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnValorLiquido);

			//--- (8) COLUNA VALOR PAGO
			clnValorRecebido.DataPropertyName = "ValorRecebido";
			clnValorRecebido.Visible = true;
			clnValorRecebido.ReadOnly = true;
			clnValorRecebido.Resizable = DataGridViewTriState.False;
			clnValorRecebido.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorRecebido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorRecebido.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorRecebido.DefaultCellStyle.Font = clnFont;
			clnValorRecebido.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnValorRecebido);

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

			mnuItemQuitar_Click(sender, null);
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
			if (e.ColumnIndex == clnSituacao.Index)
			{
				objAReceber pagar = (objAReceber)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (pagar.Situacao == "Vencida")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
				else
				{
					if ((e.RowIndex + 1) % 2 != 0) // row ODD (impar)
					{
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OldLace;
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
					}
					else // row EVEN (par)
					{
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
					}
				}
			}
			else if (e.ColumnIndex == clnCompensacaoData.Index)
			{
				objAReceber pagar = (objAReceber)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (pagar.Situacao == "Vencida")
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
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

		// CALC CHECKED VALUES LABELS
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.RowIndex >= 0)
			{
				var row = dgvListagem.Rows[e.RowIndex];
				objAReceber pag = (objAReceber)row.DataBoundItem;

				if ((bool)row.Cells[0].Value == true)
				{
					nItemsSelected += 1;
					_vlBrutoSelected += pag.ValorBruto;
					_vlRecebidoSelected += pag.ValorRecebido;
					_vlLiquidoSelected += pag.ValorLiquido;
				}
				else
				{
					nItemsSelected -= 1;
					_vlBrutoSelected -= pag.ValorBruto;
					_vlRecebidoSelected -= pag.ValorRecebido;
					_vlLiquidoSelected -= pag.ValorLiquido;
				}

				CalculaTotaisSelected();
			}
		}

		// UNCHECK ALL ITEMS IN LIST
		//------------------------------------------------------------------------------------------------------------
		private void unCheckListagem()
		{
			//--- uncheck all
			foreach (DataGridViewRow row in dgvListagem.Rows)
			{
				row.Cells[0].Value = false;
			}

			nItemsSelected = 0;
			_vlBrutoSelected = 0;
			_vlLiquidoSelected = 0;
			_vlRecebidoSelected = 0;
			CalculaTotaisSelected();
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

		//--- RECEBER PAGAMENTO
		//-------------------------------------------------------------------------------------------------------
		private void btnReceber_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para efetuar a entrada...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			// --- Create List
			List<objAReceber> recItems = new List<objAReceber>();

			foreach (DataGridViewRow item in dgvListagem.SelectedRows)
			{
				var rec = (objAReceber)item.DataBoundItem;

				if (rec.IDSituacao != 1)
				{
					AbrirDialog($"Não é possível realizar o recebimento " +
						$"porque a Situacao do a receber selecionado está: {rec.Situacao.ToUpper()}",
						"Situação");
					return;
				}

				recItems.Add(rec);
			}

			// open form Quitar
			AReceberFormConsolidacao(recItems);
		}

		// RECEBER PAGAMENTO EM LOTE
		//------------------------------------------------------------------------------------------------------------
		private void btnReceberLote_Click(object sender, EventArgs e)
		{
			//--- verify checked itens
			if (nItemsSelected == 0)
			{
				AbrirDialog("Favor selecionar um registro para efetuar a entrada...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- create list
			List<objAReceber> recItems = new List<objAReceber>();

			foreach (DataGridViewRow item in dgvListagem.Rows)
			{
				if ((bool)item.Cells[0].Value == true)
				{
					var rec = (objAReceber)item.DataBoundItem;
					if (rec.IDSituacao != 1)
					{
						AbrirDialog($"Não é possível realizar o recebimento " +
							$"porque a Situacao do a receber selecionado está: {rec.Situacao.ToUpper()}",
							"Situação");
						return;
					}
					recItems.Add(rec);
				}
			}

			//--- verify is the same FORMA
			if (recItems.GroupBy(rec => rec.IDEntradaForma).Count() > 1)
			{
				AbrirDialog("Os itens selecionados devem ser da mesma FORMA de Entrada...",
					"Forma de Entrada", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- verify is the same CONTA PROVISORIA
			if (recItems.GroupBy(rec => rec.IDContaProvisoria).Count() > 1)
			{
				AbrirDialog("Os itens selecionados devem ser da mesma CONTA PROVISÓRIA...",
					"Conta Provisória", DialogType.OK, DialogIcon.Information);
				return;
			}

			// open form Quitar
			AReceberFormConsolidacao(recItems);

		}

		// OPEN FORM AND GET VALUES
		//------------------------------------------------------------------------------------------------------------
		private void AReceberFormConsolidacao(List<objAReceber> recItems)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new frmAReceberQuitar(recItems, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				AReceberExecuteConsolidacao(recItems, frm.entradasList);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de Recebimentos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// A RECEBER EXECUTE CONSOLIDACAO ENTRADAS AND TRANSFERENCIAS
		//------------------------------------------------------------------------------------------------------------
		private void AReceberExecuteConsolidacao(List<objAReceber> listRec, List<objMovimentacao> entradas)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				// --- Execute
				rBLL.AReceberConsolidacaoList(listRec, entradas, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao executar o recebimento do(s) AReceber..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, _IDContaProvisoria, false);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					_IDContaProvisoria = (int)frm.propEscolha.IDConta;
					txtConta.Text = frm.propEscolha.Conta;
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
				if (_IDContaProvisoria != null)
				{
					_IDContaProvisoria = null;
					txtConta.Clear();
					ObterDados();
				}
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

		#region CONTROL SITUACAO

		private void AddHandlersRadioButSituacao()
		{
			rbtEmAberto.CheckedChanged += rbtSit_CheckedChanged;
			rbtRecebidos.CheckedChanged += rbtSit_CheckedChanged;
			rbtCanceladas.CheckedChanged += rbtSit_CheckedChanged;
			rbtSitTodas.CheckedChanged += rbtSit_CheckedChanged;
		}

		private void DefSituacao(int Situacao)
		{
			_Situacao = Situacao != 6 ? (byte?)Situacao : null;
			ObterDados();
		}

		private void rbtSit_CheckedChanged(object sender, EventArgs e)
		{
			int newSit = int.Parse(((Control)sender).Tag.ToString());

			if (_Situacao != newSit)
			{
				DefSituacao(newSit);
			}
		}

		#endregion // CONTROL SITUACAO --- END

		#region SAVE

		// PERSISTIR ALTERAR SITUACAO NO BD
		//------------------------------------------------------------------------------------------------------------
		private void SalvarRegistro(objAReceber rec)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				rBLL.UpdateAReceber(rec);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar a alteração do Registro..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // SAVE --- END

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
			objAReceber recItem = (objAReceber)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// mnuVerPagamentos
			mnuItemEstornar.Enabled = recItem.ValorRecebido > 0;

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

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		//--- MENU QUITAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemQuitar_Click(object sender, EventArgs e)
		{
			btnReceber_Click(sender, e);
		}

		//--- MENU CANCELAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemCancelar_Click(object sender, EventArgs e)
		{
			// check and ask to user
			objAReceber item = CheckAlteraSituacao("Cancelar");
			if (item == null) return;

			//--- EXECUTE
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				item.IDSituacao = 3;
				item.Situacao = "Cancelada";

				// save aPagar
				SalvarRegistro(item);

				// Confirm AND CalcTotais
				//--- update list
				bindRec.RemoveCurrent();
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Cancelar o A Pagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		//--- MENU NORMALIZAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemNormalizar_Click(object sender, EventArgs e)
		{
			// check and ask to user
			objAReceber item = CheckAlteraSituacao("Normalizar");
			if (item == null) return;

			//--- EXECUTE
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				item.IDSituacao = 1;
				item.Situacao = "Em Aberto";

				// save aPagar
				SalvarRegistro(item);

				// Confirm AND CalcTotais
				//--- update list
				bindRec.RemoveCurrent();
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Normalizar o a Pagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// VERIFICA DADOS E EMITE MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		private objAReceber CheckAlteraSituacao(string acao)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return null;

			//--- verifica USER PERMIT
			if (!CheckAuthorization(EnumAcessoTipo.Usuario_Senior, $"{acao} a Receber", this)) return null;

			//--- Pergunta ao USER
			var resp = AbrirDialog($"Você deseja realmente {acao.ToUpper()} este registro de AReceber selecionado?",
				$"{acao} AReceber",
				DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp == DialogResult.No) return null;

			//--- Get A Pagar on list
			objAReceber item = (objAReceber)dgvListagem.SelectedRows[0].DataBoundItem;

			return item;
		}

		//--- MENU ESTORNAR PAGAMENTOS
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemEstornar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Estornar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objAReceber recItem = (objAReceber)dgvListagem.SelectedRows[0].DataBoundItem;

				var resp = AbrirDialog("Você deseja realmente ESTORNAR o recebimento do AReceber selecionado?",
					"Estornar Recebimento",
					DialogType.SIM_NAO,
					DialogIcon.Question,
					DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				//--- execute
				rBLL.estornaAReceber(recItem, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);
				//--- get Dados
				ObterDados();
				//--- message
				AbrirDialog("Recebimento estornado com sucesso!", "Estorno");

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao ESTORNAR o Recebimento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		//--- MENU VER ORIGEM
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemVerOrigem_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Get A Pagar on list
			objAReceber item = (objAReceber)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Entradas.frmContribuicao frm = new Entradas.frmContribuicao(item.IDContribuicao);
				Visible = false;
				frm.ShowDialog();
				DesativaMenuPrincipal();
				Visible = true;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir a Contribuição..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		//--- MENU ALTERAR ITEM
		//------------------------------------------------------------------------------------------------------------
		private void mnuItemAlterar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Alterar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			unCheckListagem();

			//--- get Selected item
			objAReceber item = (objAReceber)dgvListagem.SelectedRows[0].DataBoundItem;

			frmAReceberAlterar frm = new frmAReceberAlterar(item, this);
			frm.ShowDialog();

			if (frm.DialogResult != DialogResult.OK)
			{
				bindRec.CancelEdit();
			}
			else
			{
				bindRec.EndEdit();
				// save persist DB
				SalvarRegistro(item);
				CalculaTotais();
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
