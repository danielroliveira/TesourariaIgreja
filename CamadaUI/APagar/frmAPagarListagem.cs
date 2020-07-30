using CamadaBLL;
using CamadaDTO;
using CamadaUI.APagar.Reports;
using CamadaUI.Imagem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarListagem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objAPagar> listPag = new List<objAPagar>();
		private BindingSource bindPag = new BindingSource();
		private APagarBLL pBLL = new APagarBLL();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos
		private int? _Situacao = 1; // 1: Em Aberto | 2: Quitadas | 3: Canceladas | 4:Negociadas | 5:Negativadas | null :Todas

		public struct StructPesquisa
		{
			public int? IDForma;
			public string Forma;
			public int? IDCredor;
			public string Credor;
		}

		public StructPesquisa Dados;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmAPagarListagem(Form formOrigem = null)
		{
			InitializeComponent();

			Dados = new StructPesquisa();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- get dados
			DefineLabelFiltro();

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

				// define list
				listPag = pBLL.GetListAPagar(
					_Situacao,
					Dados.IDForma,
					Dados.IDCredor,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null);

				bindPag.DataSource = listPag;
				dgvListagem.DataSource = bindPag;
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
			decimal vlAPagar = listPag.Sum(x => x.APagarValor);
			lblValor.Text = vlAPagar.ToString("C");

			decimal vlPago = listPag.Sum(x => x.ValorPago);
			lblValorPago.Text = vlPago.ToString("C");
		}

		// DEFINE O LABEL FILTRO
		//------------------------------------------------------------------------------------------------------------
		private void DefineLabelFiltro()
		{
			StringBuilder builder = new StringBuilder();

			if (Dados.IDForma != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "SETOR: " + Dados.Forma);
			}

			if (Dados.IDCredor != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "Credor: " + Dados.Credor);
			}

			lblFiltro.Text = builder.ToString();

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
			clnID.DataPropertyName = "IDAPagar";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;
			colList.Add(clnID);

			//--- (2) COLUNA DATA
			clnVencimento.DataPropertyName = "Vencimento";
			clnVencimento.Visible = true;
			clnVencimento.ReadOnly = true;
			clnVencimento.Resizable = DataGridViewTriState.False;
			clnVencimento.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnVencimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnVencimento.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnVencimento.DefaultCellStyle.Font = clnFont;
			colList.Add(clnVencimento);

			//--- (3) COLUNA SETOR
			clnForma.DataPropertyName = "CobrancaForma";
			clnForma.Visible = true;
			clnForma.ReadOnly = true;
			clnForma.Resizable = DataGridViewTriState.False;
			clnForma.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnForma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.DefaultCellStyle.Font = clnFont;
			colList.Add(clnForma);

			//--- (4) COLUNA CREDOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnCredor);

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

			//--- (6) COLUNA REFERENCIA
			clnReferencia.DataPropertyName = "Referencia";
			clnReferencia.Visible = true;
			clnReferencia.ReadOnly = true;
			clnReferencia.Resizable = DataGridViewTriState.False;
			clnReferencia.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnReferencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnReferencia.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnReferencia.DefaultCellStyle.Font = clnFont;
			colList.Add(clnReferencia);

			//--- (7) COLUNA VALOR
			clnValor.DataPropertyName = "APagarValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Font = clnFont;
			clnValor.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnValor);

			//--- (8) COLUNA VALOR PAGO
			clnValorPago.DataPropertyName = "ValorPago";
			clnValorPago.Visible = true;
			clnValorPago.ReadOnly = true;
			clnValorPago.Resizable = DataGridViewTriState.False;
			clnValorPago.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorPago.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorPago.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorPago.DefaultCellStyle.Font = clnFont;
			clnValorPago.DefaultCellStyle.Format = "#,##0.00";
			colList.Add(clnValorPago);

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
			objAPagar pagar = (objAPagar)dgvListagem.Rows[e.RowIndex].DataBoundItem;

			if (e.ColumnIndex == clnSituacao.Index)
			{
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
			else if (e.ColumnIndex == clnVencimento.Index)
			{
				if (pagar.Situacao == "Vencida")
				{
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
			}
			else if (e.ColumnIndex == 0) // COLOR TO A PAGAR PERIODICO
			{
				if (pagar.IDAPagar == null)
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkBlue;
					e.Value = "PER";
				}
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

		// FILTRAR
		//------------------------------------------------------------------------------------------------------------
		private void btnFiltrar_Click(object sender, EventArgs e)
		{
			var frm = new frmAPagarListagemFiltro(this);
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.Yes)
			{
				ObterDados();
				DefineLabelFiltro();
			}
		}

		//--- QUITAR A PAGAR
		//-------------------------------------------------------------------------------------------------------
		private void btnQuitar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Quitar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objAPagar pagItem = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

				//--- check selected item
				if (pagItem.IDAPagar == null)
				{
					AbrirDialog("Este APAGAR selecionado é PERIÓDICO, para quitar é necessário " +
						"transformá-lo em REAL...",
						"APagar Periódico",
						DialogType.OK,
						DialogIcon.Exclamation);
					return;
				}

				frmAPagarSaidas frm = new frmAPagarSaidas(pagItem, this);
				frm.ShowDialog();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de Pagamentos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// IMPRIMIR LISTAGEM
		//-------------------------------------------------------------------------------------------------------
		private void btnImprimir_Click(object sender, EventArgs e)
		{
			if (listPag == null || listPag.Count == 0)
			{
				AbrirDialog("Não há nenhum registro de A Pagar na listagem para ser impresso...",
					"Listagem Vazia");
				return;
			}

			frmAPagarReport frm = new frmAPagarReport(listPag);
			frm.ShowDialog();
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
			rbtQuitadas.CheckedChanged += rbtSit_CheckedChanged;
			rbtCanceladas.CheckedChanged += rbtSit_CheckedChanged;
			rbtNegociadas.CheckedChanged += rbtSit_CheckedChanged;
			rbtNegativadas.CheckedChanged += rbtSit_CheckedChanged;
			rbtSitTodas.CheckedChanged += rbtSit_CheckedChanged;
		}

		private void DefSituacao(int Situacao)
		{
			_Situacao = Situacao != 6 ? (int?)Situacao : null;
			ObterDados();

			if (_Situacao == 1 || _Situacao == null)
			{
				btnQuitar.Text = "&Quitar";
				btnQuitar.Image = Properties.Resources.money_red_24;
			}
			else if (_Situacao == 2)
			{
				btnQuitar.Text = "&Estornar";
				btnQuitar.Image = Properties.Resources.refresh_24;
			}
			else
			{
				btnQuitar.Text = "&Verificar";
				btnQuitar.Image = Properties.Resources.search_page_24;
			}
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

		private void SalvarRegistro(objAPagar pag)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				pBLL.UpdateAPagar(pag);
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
			objAPagar pagItem = (objAPagar)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// mnuImagem
			if (pagItem.IDAPagar != null)
			{
				mnuImagem.Enabled = true;
				bool IsThereImagem = pagItem.Imagem != null && !string.IsNullOrEmpty(pagItem.Imagem.ImagemFileName);

				mnuImagemRemover.Enabled = IsThereImagem;
				mnuImagemInserir.Text = IsThereImagem ? "Alterar Imagem" : "Inserir Imagem";
				mnuImagemVisualizar.Enabled = IsThereImagem;
			}
			else
			{
				mnuImagem.Enabled = false;
			}

			// mnuVerPagamentos
			mnuItemVerPagamentos.Enabled = pagItem.ValorPago > 0;

			switch (pagItem.IDSituacao)
			{
				case 1: // EM ABERTO
						//--- check if ORIGEM is Comum or Periodica
					mnuItemAlterar.Enabled = true;

					if (pagItem.IDAPagar != null)
					{
						mnuItemAlterar.Text = "Alterar";
						mnuItemCancelar.Enabled = true;
						mnuItemNegativar.Enabled = true;
						mnuItemNegociar.Enabled = true;
						mnuItemNormalizar.Enabled = false;
						mnuItemQuitar.Enabled = true;
						mnuItemVerPagamentos.Enabled = true;
					}
					else
					{
						mnuItemAlterar.Text = "Transformar em Real";
						mnuItemCancelar.Enabled = false;
						mnuItemNegativar.Enabled = false;
						mnuItemNegociar.Enabled = false;
						mnuItemNormalizar.Enabled = false;
						mnuItemQuitar.Enabled = true;
						mnuItemVerPagamentos.Enabled = false;
					}

					break;
				case 2: // QUITADAS
					mnuItemAlterar.Enabled = false;
					mnuItemCancelar.Enabled = false;
					mnuItemNegativar.Enabled = false;
					mnuItemNegociar.Enabled = false;
					mnuItemNormalizar.Enabled = false;
					mnuItemQuitar.Enabled = false;
					mnuItemVerPagamentos.Enabled = true;
					break;
				case 3: // CANCELADAS
				case 4: // NEGOCIADAS
				case 5: // NEGATIVADAS
					mnuItemAlterar.Enabled = false;
					mnuItemCancelar.Enabled = false;
					mnuItemNegativar.Enabled = false;
					mnuItemNegociar.Enabled = false;
					mnuItemNormalizar.Enabled = true;
					mnuItemQuitar.Enabled = false;
					mnuItemVerPagamentos.Enabled = true;
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
			btnQuitar_Click(sender, e);
		}

		//--- MENU CANCELAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemCancelar_Click(object sender, EventArgs e)
		{
			// check and ask to user
			objAPagar item = CheckAlteraSituacao("Cancelar");
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
				bindPag.RemoveCurrent();
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

		//--- MENU NEGOCIAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemNegociar_Click(object sender, EventArgs e)
		{
			// check and ask to user
			objAPagar item = CheckAlteraSituacao("Negociar");
			if (item == null) return;

			//--- EXECUTE
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				item.IDSituacao = 4;
				item.Situacao = "Negociada";

				// save aPagar
				SalvarRegistro(item);

				// Confirm AND CalcTotais
				//--- update list
				bindPag.RemoveCurrent();
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Negociar o 'A Pagar'..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		//--- MENU NEGATIVAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemNegativar_Click(object sender, EventArgs e)
		{
			// check and ask to user
			objAPagar item = CheckAlteraSituacao("Negativar");
			if (item == null) return;

			//--- EXECUTE
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				item.IDSituacao = 5;
				item.Situacao = "Negativada";

				// save aPagar
				SalvarRegistro(item);

				// Confirm AND CalcTotais
				//--- update list
				bindPag.RemoveCurrent();
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Negativar o 'a Pagar'..." + "\n" +
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
			objAPagar item = CheckAlteraSituacao("Normalizar");
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
				bindPag.RemoveCurrent();
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
		private objAPagar CheckAlteraSituacao(string acao)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return null;

			//--- verifica USER PERMIT
			if (!CheckAuthorization(EnumAcessoTipo.Usuario_Senior, $"{acao} a Pagar", this)) return null;

			//--- Pergunta ao USER
			var resp = AbrirDialog($"Você deseja realmente {acao.ToUpper()} este registro de A Pagar selecionado?",
				$"{acao} A Pagar",
				DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp == DialogResult.No) return null;

			//--- Get A Pagar on list
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- check if ORIGEM is Periodica
			if (item.DespesaOrigem != 1)
			{
				AbrirDialog($"Esse A Pagar é uma DEPESA PERIÓDICA.\n" +
					$"Não é possível {acao} uma Despesa Periódica.",
					"Despesa Periódica", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}

			return item;
		}

		//--- MENU VER PAGAMENTOS ESTORNAR
		//-------------------------------------------------------------------------------------------------------
		private void mnuItemVerPagamentos_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Ver Pagamentos ou Estornar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objAPagar pagItem = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

				frmAPagarSaidas frm = new frmAPagarSaidas(pagItem, this);
				frm.ShowDialog();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de Pagamentos..." + "\n" +
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
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- check if ORIGEM is Comum or Periodica
				if (item.DespesaOrigem == 1)
				{
					Saidas.frmDespesa frm = new Saidas.frmDespesa(item.IDDespesa);
					Visible = false;
					frm.ShowDialog();
					DesativaMenuPrincipal();
					Visible = true;
				}
				else
				{
					if (item.IDAPagar != null)
					{
						AbrirDialog("A origem deste APagar é uma despesa periódica que foi transformado em REAL...\n" +
							"Mesmo que se faça alterações na ORIGEM essas alterações não serão refletidas " +
							"no APagar.", "Despesa Periódica");
					}

					Saidas.frmDespesaPeriodica frm = new Saidas.frmDespesaPeriodica(item.IDDespesa);
					Visible = false;
					frm.ShowDialog();
					DesativaMenuPrincipal();
					Visible = true;
					// get data
					ObterDados();
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir a Despesa..." + "\n" +
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

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- check if ORIGEM is Comum or Periodica
			if (item.DespesaOrigem == 1 || item.IDAPagar != null)
			{
				//--- check if not is locked
				if (item.ValorPago > 0)
				{
					AbrirDialog($"O registro de a pagar selecionado: {item.IDAPagar:D4} já possui pagamentos realizados\n" +
						$"Não é possível fazer alterações num registro de a pagar que já foi quitado.",
						"A Pagar com Pagamentos", DialogType.OK, DialogIcon.Information);
					return;
				}

				frmAPagarAlterar frm = new frmAPagarAlterar(item, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK)
				{
					bindPag.CancelEdit();
				}
				else
				{
					bindPag.EndEdit();

					// save aPagar
					SalvarRegistro(item);
				}
			}
			else if (item.DespesaOrigem == 2) // DESPESA PERIODICA ==> TORNAR REAL
			{
				var resp = AbrirDialog("Deseja transformar este APagar em REAL? \n" +
					$"{item.DespesaDescricao}",
					"Transformar em REAL",
					DialogType.SIM_NAO,
					DialogIcon.Question,
					DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;

					var desp = new DespesaPeriodicaBLL().GetDespesaPeriodica(item.IDDespesa);
					pBLL.ConvertPeriodicoInReal(desp, item.Vencimento);

					ObterDados();

				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Tornar Despesa Real..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
			}
		}

		private void mnuImagemInserir_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Inserir Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)item.IDAPagar,
					Origem = EnumImagemOrigem.APagar,
					ImagemFileName = item.Imagem == null ? string.Empty : item.Imagem.ImagemFileName,
					ImagemPath = item.Imagem == null ? string.Empty : item.Imagem.ImagemPath,
					ReferenceDate = item.Vencimento,
				};

				// open form to edit or save image
				bool IsNew = item.Imagem == null || string.IsNullOrEmpty(item.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (item.Imagem != null && imagem != null)
				{
					IsUpdated = (item.Imagem.ImagemFileName != imagem.ImagemFileName) || (item.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				item.Imagem = imagem;

				// emit message
				if (IsNew && imagem != null)
				{
					AbrirDialog("Imagem associada e salva com sucesso!" +
								"\nPor segurança a imagem foi transferida para a pasta padrão.",
								"Imagem Salva", DialogType.OK, DialogIcon.Information);
				}
				else if (IsUpdated)
				{
					AbrirDialog("Imagem alterada com sucesso!" +
								"\nPor segurança a imagem anterior foi transferida para a pasta de imagens removidas.",
								"Imagem Alterada", DialogType.OK, DialogIcon.Information);
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuImagemVisualizar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(item.Imagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Visualizar a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuImagemRemover_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			DialogResult resp;

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem do APagar selecionado?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				item.Imagem = ImagemUtil.ImagemRemover(item.Imagem);

				AbrirDialog("Imagem desassociada com sucesso!" +
					"\nPor segurança a imagem foi guardada na pasta de Imagens Removidas.",
					"Imagem Removida", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Remover a imagem..." + "\n" +
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
