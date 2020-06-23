using CamadaDTO;
using CamadaBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;
using System.Linq;

namespace CamadaUI.Caixa
{
	public partial class frmCaixa : CamadaUI.Modals.frmModFinBorder
	{

		private List<objMovimentacao> lstMov;
		private BindingSource bindMovs = new BindingSource();
		private CaixaBLL cxBLL = new CaixaBLL();

		private objCaixa _caixa;
		private BindingSource bindCaixa = new BindingSource();
		private Form _formOrigem;

		private decimal _TEntradas;
		private decimal _TSaidas;
		private decimal _TTransf;

		#region SUB NEW | CONSTRUCTOR

		// CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmCaixa(objCaixa caixa, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;

			_caixa = caixa;
			bindCaixa.DataSource = typeof(objCaixa);
			bindCaixa.Add(_caixa);

			propSituacao = _caixa.IDSituacao;
			BindingCreator();

			ObterMovimentacaoList();
		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public byte propSituacao
		{
			get
			{
				return _caixa.IDSituacao;
			}
			set
			{
				_caixa.IDSituacao = value;

				switch (value)
				{
					case 1: // INICIADO
						btnAlterar.Enabled = true;
						btnFinalizar.Enabled = true;
						btnExcluirCaixa.Enabled = true;
						txtObservacao.ReadOnly = false;
						btnFinalizar.Text = "Finalizar Caixa";
						btnFinalizar.Image = Properties.Resources.accept_24;
						break;
					case 2: // FINALIZADO
						btnAlterar.Enabled = false;
						btnFinalizar.Enabled = true;
						btnExcluirCaixa.Enabled = false;
						txtObservacao.ReadOnly = true;
						btnFinalizar.Text = "Desbloqueio";
						btnFinalizar.Image = Properties.Resources.unlock_24;
						break;
					case 3: // BLOQUEADO
						btnAlterar.Enabled = false;
						btnFinalizar.Enabled = false;
						btnExcluirCaixa.Enabled = false;
						txtObservacao.ReadOnly = true;
						btnFinalizar.Text = "Finalizar Caixa";
						btnFinalizar.Image = Properties.Resources.accept_24;
						break;
					default:
						break;
				}
			}
		}

		// GET MOVS LIST
		//------------------------------------------------------------------------------------------------------------
		private void ObterMovimentacaoList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				lstMov = new MovimentacaoBLL().GetMovimentacaoCaixaList((long)_caixa.IDCaixa);
				bindMovs.DataSource = lstMov;
				dgvListagem.DataSource = bindMovs;

				// preenche a lista
				FormataListagem();

				// calcula os totais
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter a Lista de Movimentações de Caixa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// CALCULA VALOR DOS TOTAIS
		//------------------------------------------------------------------------------------------------------------
		private void CalculaTotais()
		{
			_TEntradas = lstMov.Where(x => x.MovOrigem == "ENTRADA").Sum(x => x.MovValorReal);
			_TSaidas = lstMov.Where(x => x.MovOrigem == "SAIDA").Sum(x => x.MovValorReal);
			_TTransf = lstMov.Where(x => x.MovOrigem == "TRANSFERENCIA").Sum(x => x.MovValorReal);

			lblTEntradas.Text = _TEntradas.ToString("c");
			lblTSaidas.Text = (_TSaidas * -1).ToString("c");
			lblTTransf.Text = _TTransf.ToString("c");

			lblSaldoFinal.Text = (_TEntradas + _TSaidas + _TTransf).ToString("c");
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bindCaixa, "IDCaixa", true);
			lblConta.DataBindings.Add("Text", bindCaixa, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			lblSaldoAnterior.DataBindings.Add("Text", bindCaixa, "SaldoAnterior", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDataFinal.DataBindings.Add("Text", bindCaixa, "DataFinal", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDataInicial.DataBindings.Add("Text", bindCaixa, "DataInicial", true, DataSourceUpdateMode.OnPropertyChanged);
			lblSituacao.DataBindings.Add("Text", bindCaixa, "Situacao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblSaldoAnterior.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
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

			//--- (0) COLUNA ORIGEM DA MOVIMENTACAO
			clnMovOrigemSigla.DataPropertyName = "MovOrigemSigla";
			clnMovOrigemSigla.Visible = true;
			clnMovOrigemSigla.ReadOnly = true;
			clnMovOrigemSigla.Resizable = DataGridViewTriState.False;
			clnMovOrigemSigla.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnMovOrigemSigla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnMovOrigemSigla.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			colList.Add(clnMovOrigemSigla);

			//--- (1) COLUNA DATA
			clnMovData.DataPropertyName = "MovData";
			clnMovData.Visible = true;
			clnMovData.ReadOnly = true;
			clnMovData.Resizable = DataGridViewTriState.False;
			clnMovData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnMovData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnMovData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnMovData);

			//--- (2) COLUNA ORIGEM TABELA
			clnOrigemTabela.DataPropertyName = "OrigemTabelaDescricao";
			clnOrigemTabela.Visible = true;
			clnOrigemTabela.ReadOnly = true;
			clnOrigemTabela.Resizable = DataGridViewTriState.False;
			clnOrigemTabela.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnOrigemTabela.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnOrigemTabela.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnOrigemTabela);

			//--- (3) COLUNA IDORIGEM
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnIDOrigem.DataPropertyName = "IDOrigem";
			clnIDOrigem.Visible = true;
			clnIDOrigem.ReadOnly = true;
			clnIDOrigem.Resizable = DataGridViewTriState.False;
			clnIDOrigem.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIDOrigem.DefaultCellStyle.Padding = newPadding;
			clnIDOrigem.DefaultCellStyle.Format = "0000";
			colList.Add(clnIDOrigem);

			//--- (4) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnSetor);

			//--- (5) COLUNA VALOR
			clnValorReal.DataPropertyName = "MovValor";
			clnValorReal.Visible = true;
			clnValorReal.ReadOnly = true;
			clnValorReal.Resizable = DataGridViewTriState.False;
			clnValorReal.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorReal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorReal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
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
			if (e.ColumnIndex == clnMovOrigemSigla.Index)
			{
				objMovimentacao mov = (objMovimentacao)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (mov.MovOrigem == "SAIDA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
				else if (mov.MovOrigem == "ENTRADA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
				}
				else if (mov.MovOrigem == "TRANSFERENCIA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen;
					//dgvListagem.Rows[e.RowIndex].DefaultCellStyle.Font = clnFont;
					e.CellStyle.ForeColor = Color.DarkGreen;
					e.CellStyle.SelectionForeColor = Color.Honeydew;
				}
			}
			else if (e.ColumnIndex == clnValorReal.Index)
			{
				objMovimentacao mov = (objMovimentacao)dgvListagem.Rows[e.RowIndex].DataBoundItem;

				if (mov.MovValorReal >= 0)
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
		}

		#endregion

		#region BUTTONS FUNCTIONS

		// FECHAR
		//------------------------------------------------------------------------------------------------------------
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		#endregion // BUTTONS FUNCTIONS --- END

	}
}
