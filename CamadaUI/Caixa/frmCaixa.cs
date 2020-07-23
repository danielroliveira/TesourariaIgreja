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

namespace CamadaUI.Caixa
{
	public partial class frmCaixa : CamadaUI.Modals.frmModFinBorder
	{

		private List<objMovimentacao> lstMov;
		private BindingSource bindMovs = new BindingSource();
		private CaixaBLL cxBLL = new CaixaBLL();

		private objCaixa _caixa;
		private objConta contaSelected;
		private BindingSource bindCaixa = new BindingSource();
		private Form _formOrigem;

		private decimal _TEntradas;
		private decimal _TSaidas;
		private decimal _TTransf;

		// DEFINE COLUMN FONT
		Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

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

			BindingCreator();
			propSituacao = _caixa.IDSituacao;

			//--- Get Data with TRANSACTION
			var access = new AcessoControlBLL();
			object dbTran = access.GetNewAcessoWithTransaction();

			ObterConta(dbTran);
			ObterMovimentacaoList(dbTran);

			access.CommitAcessoWithTransaction(dbTran);

			//--- check if exists nivelamento
			checkAjusteNivelamento();

			txtObservacao.GotFocus += txtObservacao_GotFocus;
			txtObservacao.LostFocus += txtObservacao_LostFocus;

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
						btnAjuste.Enabled = true;
						btnFinalizar.Enabled = true;
						btnExcluirCaixa.Enabled = true;
						txtObservacao.ReadOnly = false;
						btnFinalizar.Text = "Finalizar Caixa";
						btnFinalizar.Image = Properties.Resources.accept_24;
						break;
					case 2: // FINALIZADO
						btnAlterar.Enabled = false;
						btnAjuste.Enabled = false;
						btnFinalizar.Enabled = true;
						btnExcluirCaixa.Enabled = false;
						txtObservacao.ReadOnly = true;
						btnFinalizar.Text = "Desbloqueio";
						btnFinalizar.Image = Properties.Resources.unlock_24;
						break;
					case 3: // BLOQUEADO
						btnAlterar.Enabled = false;
						btnAjuste.Enabled = false;
						btnFinalizar.Enabled = false;
						btnExcluirCaixa.Enabled = false;
						txtObservacao.ReadOnly = true;
						btnFinalizar.Text = "Caixa Bloqueado";
						btnFinalizar.Image = Properties.Resources.block_16;
						break;
					default:
						break;
				}

				lblSituacao.DataBindings["Text"].ReadValue();

			}
		}

		// GET CONTA CAIXA
		//------------------------------------------------------------------------------------------------------------
		private void ObterConta(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				contaSelected = new ContaBLL().GetConta(_caixa.IDConta, dbTran);
				lblContaDetalhe.Text = $"Saldo da Conta: {contaSelected.ContaSaldo.ToString("c")} \n" +
									$"Data de Bloqueio até: {contaSelected.BloqueioData?.ToString() ?? ""}";
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a conta do Caixa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET MOVS LIST
		//------------------------------------------------------------------------------------------------------------
		private void ObterMovimentacaoList(object dbTran = null)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				lstMov = new MovimentacaoBLL().GetMovimentacaoCaixaList(_caixa, dbTran);
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
		private decimal CalculaTotais()
		{
			_TEntradas = lstMov.Where(x => x.MovTipo == 1).Sum(x => x.MovValor);
			_TSaidas = lstMov.Where(x => x.MovTipo == 2).Sum(x => x.MovValor);
			_TTransf = lstMov.Where(x => x.MovTipo == 3).Sum(x => x.MovValor);

			lblTEntradas.Text = _TEntradas.ToString("c");
			lblTSaidas.Text = (_TSaidas * -1).ToString("c");
			lblTTransf.Text = _TTransf.ToString("c");

			decimal SaldoFinal = _TEntradas + _TSaidas + _TTransf;

			lblSaldoFinal.Text = SaldoFinal.ToString("c");
			return SaldoFinal;
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
			txtObservacao.DataBindings.Add("Text", bindCaixa, "Observacao", true, DataSourceUpdateMode.OnPropertyChanged);

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
			clnMovOrigemSigla.DataPropertyName = "MovTipoSigla";
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
			clnDescricaoOrigem.DataPropertyName = "DescricaoOrigem";
			clnDescricaoOrigem.Visible = true;
			clnDescricaoOrigem.ReadOnly = true;
			clnDescricaoOrigem.Resizable = DataGridViewTriState.False;
			clnDescricaoOrigem.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDescricaoOrigem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDescricaoOrigem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
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

				if (mov.MovTipoDescricao == "SAIDA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
				else if (mov.MovTipoDescricao == "ENTRADA")
				{
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(228, 235, 244);
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
				}
				else if (mov.MovTipoDescricao == "TRANSFERENCIA")
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

				if (mov.MovValor >= 0)
				{
					e.CellStyle.ForeColor = Color.DarkBlue;
					e.CellStyle.SelectionForeColor = Color.White;
					e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
				else
				{
					e.CellStyle.ForeColor = Color.DarkRed;
					e.CellStyle.SelectionForeColor = Color.Yellow;
					e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				}
			}
			else if (e.ColumnIndex == clnDescricaoOrigem.Index)
			{
				e.CellStyle.Font = clnFont;
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

		// BUTTON FINALIZAR OR DESBLOQUEAR CAIXA
		//------------------------------------------------------------------------------------------------------------
		private void btnFinalizar_Click(object sender, EventArgs e)
		{
			if (propSituacao == 1)
			{
				FinalizarCaixa();
			}
			else
			{
				DesbloquearCaixa();
			}
		}

		// FINALIZAR CAIXA
		//------------------------------------------------------------------------------------------------------------
		private void FinalizarCaixa()
		{
			// Ask USER
			var resp = AbrirDialog($"Você deseja realmente FINALIZAR o caixa da conta: {_caixa.Conta} ?" +
				$"\nSaldo Final: {CalculaTotais():c}",
				"Finalizar Caixa", DialogType.SIM_NAO, DialogIcon.Question);

			if (resp != DialogResult.Yes) return;

			// Ask USER
			resp = AbrirDialog($"Deseja que a data final do caixa seja bloqueada?" +
				$"\nData Final: {_caixa.DataFinal.ToShortDateString()}",
				"Bloqueio de Data", DialogType.SIM_NAO_CANCELAR, DialogIcon.Question);

			if (resp == DialogResult.Cancel) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				_caixa.CaixaFinalDoDia = resp == DialogResult.Yes;

				//  Define Values
				_caixa.SaldoFinal = CalculaTotais();
				_caixa.FechamentoData = DateTime.Today;
				_caixa.IDSituacao = 2;
				_caixa.Observacao = txtObservacao.Text;

				// FINALIZE caixa 
				cxBLL.FinalizeCaixa(_caixa);

				// change SIT
				propSituacao = 2;

				// CHECK ContaPadrao and change DatePadrao
				//------------------------------------------------------------------------------------------------------------
				DateTime blockDate = _caixa.CaixaFinalDoDia == false ? _caixa.DataFinal : _caixa.DataFinal.AddDays(1);

				if (ContaPadrao().IDConta == _caixa.IDConta)
				{
					((frmPrincipal)Application.OpenForms[0]).propDataPadrao = blockDate;
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Finalizar o Caixa Atual..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// DESBLOQUEAR CAIXA
		//------------------------------------------------------------------------------------------------------------
		private void DesbloquearCaixa()
		{
			// Ask USER
			var resp = AbrirDialog($"Você deseja realmente DESBLOQUEAR o caixa da conta: {_caixa.Conta} ?" +
				$"\nSaldo Final: {CalculaTotais():c}",
				"Finalizar Caixa", DialogType.SIM_NAO, DialogIcon.Question);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//  Define Values
				_caixa.IDSituacao = 1;

				// DESBLOQUEAR caixa and GET oldDataPadrao
				DateTime oldDataPadrao = cxBLL.DesbloquearCaixa(_caixa);

				// change SIT
				propSituacao = 1;

				// CHECK ContaPadrao and change DatePadrao
				//------------------------------------------------------------------------------------------------------------
				if (ContaPadrao().IDConta == _caixa.IDConta)
				{
					((frmPrincipal)Application.OpenForms[0]).propDataPadrao = oldDataPadrao;
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Desbloquear o Caixa Atual..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EXCLUIR CAIXA
		//------------------------------------------------------------------------------------------------------------
		private void btnExcluirCaixa_Click(object sender, EventArgs e)
		{
			// CHECK BLOCK SIT
			if (_caixa.IDSituacao == 3)
			{
				AbrirDialog("O Caixa atual não pode ser excluído porque está bloqueado para edição e exclusão...",
					"Caixa bloqueado", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// ASK USER
			var resp = AbrirDialog("Deseja realmente EXCLUIR o caixa atual?",
							"Excluir Caixa",
							DialogType.SIM_NAO,
							DialogIcon.Question,
							DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			// EXECUTE WITH CHECKING
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				cxBLL.DeleteCaixa(_caixa);
				Close();
				MostraMenuPrincipal();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir o Caixa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS FUNCTIONS --- END

		#region AJUSTE DE CAIXA
		private void btnAjuste_Click(object sender, EventArgs e)
		{
			if (!checkAjusteNivelamento())
			{
				Ajuste_Insert();
			}
			else
			{
				Ajuste_Remove();
			}

			checkAjusteNivelamento();
		}

		private void Ajuste_Insert()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmAjusteCaixa frm = new frmAjusteCaixa(_TEntradas + _TSaidas + _TTransf, _caixa.Conta, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				//--- create ajuste
				objCaixaAjuste ajuste = CreateAjuste(frm.propAjusteValue);

				if (ajuste == null) return;

				//--- insert
				objMovimentacao newMov = new AjusteBLL().InsertAjuste(ajuste, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate, _caixa.IDCaixa);
				bindMovs.Add(newMov);
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Inserir Ajuste..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private objCaixaAjuste CreateAjuste(decimal ajusteValue)
		{
			// get Setor de Entrada
			objSetor setor = null;

			Setores.frmSetorProcura frm = new Setores.frmSetorProcura(this);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				setor = frm.propEscolha;

				if (contaSelected.IDCongregacao != setor.IDCongregacao)
				{
					var resp = AbrirDialog("A Congregação Padrão do Setor de Recursos escolhido é " +
						"diferente da congregação padrão da Conta do Caixa...\n" +
						"Deseja continuar assim mesmo?", "Congregação Divergente",
						DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

					if (resp == DialogResult.No) return null;
				}
			}
			else
			{
				return null;
			}

			objCaixaAjuste ajuste = new objCaixaAjuste(null)
			{
				AjusteDescricao = $"Ajuste de Nivelamento de Caixa: {_caixa.IDCaixa:D4}",
				IDAjusteTipo = 2,
				IDSetor = (int)setor.IDSetor,
				Setor = setor.Setor,
				IDUserAuth = (int)Program.usuarioAtual.IDUsuario,
				MovData = _caixa.DataFinal,
				MovValor = ajusteValue,
				MovValorReal = Math.Abs(ajusteValue),
				IDConta = _caixa.IDConta,
				Conta = _caixa.Conta,

			};

			return ajuste;
		}

		private void Ajuste_Remove()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				new AjusteBLL().RemoveAjusteFromCaixa((long)_caixa.IDCaixa);

				ObterMovimentacaoList();
				CalculaTotais();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Remover o Ajuste..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private bool checkAjusteNivelamento()
		{
			bool haveAjuste = false;

			foreach (objMovimentacao mov in lstMov)
			{
				if (mov.DescricaoOrigem.Contains("Ajuste de Nivelamento"))
				{
					haveAjuste = true;
				}
			}

			if (!haveAjuste)
			{
				btnAjuste.Text = "Inserir Ajuste";
				btnAjuste.Image = Properties.Resources.editar_24;
			}
			else
			{
				btnAjuste.Text = "Remover Ajuste";
				btnAjuste.Image = Properties.Resources.delete_16;
			}

			return haveAjuste;
		}

		#endregion // AJUSTE DE CAIXA --- END

		#region OBSERVACAO

		private void btnSalvarObservacao_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				new ObservacaoBLL().SaveObservacao(2, (long)_caixa.IDCaixa, txtObservacao.Text);

				AbrirDialog("Observação salva com sucesso.", "Observação");
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar a observação..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void txtObservacao_GotFocus(object sender, EventArgs e)
		{
			txtObservacao.BackColor = Color.White;
			pnlObservacao.BackColor = Color.Silver;
		}

		private void txtObservacao_LostFocus(object sender, EventArgs e)
		{
			txtObservacao.BackColor = SystemColors.Control;
			pnlObservacao.BackColor = Color.Gainsboro;
		}

		#endregion // OBSERVACAO --- END
	}
}
