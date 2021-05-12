using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Comissoes
{
	public partial class frmComissaoListagem : CamadaUI.Modals.frmModFinBorder
	{
		ComissaoBLL cBLL = new ComissaoBLL();
		private List<objComissao> listCont = new List<objComissao>();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos
		private objCredor _colaborador;
		private objSetor _setor;
		private byte _situacao = 1;
		private int nItemsSelected = 0;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmComissaoListagem(byte SituacaoPadrao, Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// define situacao inicial
			_situacao = SituacaoPadrao;
			rbtIniciadas.Checked = _situacao == 1;
			rbtConcluidas.Checked = _situacao == 2;
			rbtPagas.Checked = _situacao == 3;

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- get dados
			dgvListagem.CellDoubleClick += btnVisualizar_Click;

			//--- Handlers
			HandlerKeyDownControl(this);
			rbtPorMes.CheckedChanged += rbt_CheckedChanged;
			rbtPorPeriodo.CheckedChanged += rbt_CheckedChanged;
			rbtTodas.CheckedChanged += rbt_CheckedChanged;

			rbtIniciadas.CheckedChanged += (a, b) => DefineSituacao();
			rbtConcluidas.CheckedChanged += (a, b) => DefineSituacao();
			rbtPagas.CheckedChanged += (a, b) => DefineSituacao();

			dgvListagem.MouseDown += dgvListagem_MouseDown;

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
				btnPeriodoPosterior.Enabled = !(_myMes.Year >= DateTime.Today.Year && _myMes.Month >= DateTime.Today.Month);
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

				listCont = cBLL.GetList(
					_colaborador == null ? null : _colaborador.IDCredor,
					_setor == null ? null : _setor.IDSetor,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null,
					_situacao);

				dgvListagem.DataSource = listCont;
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

		private void DefineSituacao()
		{
			btnEfetuar.Enabled = false;

			//--- Get Situacao
			if (rbtIniciadas.Checked)
			{
				if (_situacao != 1)
				{
					_situacao = 1;
					ObterDados();
					btnEfetuar.Text = "Concluir";
					btnEfetuar.Image = Properties.Resources.accept_24;
				}
			}
			else if (rbtConcluidas.Checked)
			{
				if (_situacao != 2)
				{
					_situacao = 2;
					ObterDados();
					btnEfetuar.Text = "Quitar";
					btnEfetuar.Image = Properties.Resources.money_red_24;
				}
			}
			else if (rbtPagas.Checked)
			{
				if (_situacao != 3)
				{
					_situacao = 3;
					ObterDados();
					btnEfetuar.Image = Properties.Resources.block_24;
				}
			}
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

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDComissao";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA DATA INICIAL
			clnDataInicial.DataPropertyName = "DataInicial";
			clnDataInicial.Visible = true;
			clnDataInicial.ReadOnly = true;
			clnDataInicial.Resizable = DataGridViewTriState.False;
			clnDataInicial.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDataInicial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDataInicial.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDataInicial.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA DATA FINAL
			clnDataFinal.DataPropertyName = "DataFinal";
			clnDataFinal.Visible = true;
			clnDataFinal.ReadOnly = true;
			clnDataFinal.Resizable = DataGridViewTriState.False;
			clnDataFinal.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDataFinal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDataFinal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDataFinal.DefaultCellStyle.Font = clnFont;

			//--- (4) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.DefaultCellStyle.Font = clnFont;

			//--- (5) COLUNA COLABORADOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;

			//--- (6) COLUNA VALOR
			clnValorContribuicoes.DataPropertyName = "ValorContribuicoes";
			clnValorContribuicoes.Visible = true;
			clnValorContribuicoes.ReadOnly = true;
			clnValorContribuicoes.Resizable = DataGridViewTriState.False;
			clnValorContribuicoes.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorContribuicoes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorContribuicoes.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorContribuicoes.DefaultCellStyle.Format = "#,##0.00";
			clnValorContribuicoes.DefaultCellStyle.Font = clnFont;

			//--- (7) COLUNA VALOR DESCONTOS
			clnValorDescontado.DataPropertyName = "ValorDescontado";
			clnValorDescontado.Visible = true;
			clnValorDescontado.ReadOnly = true;
			clnValorDescontado.Resizable = DataGridViewTriState.False;
			clnValorDescontado.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorDescontado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorDescontado.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorDescontado.DefaultCellStyle.Format = "#,##0.00";
			clnValorDescontado.DefaultCellStyle.Font = clnFont;

			//--- (8) COLUNA VALOR COMISSAO
			clnValorComissao.DataPropertyName = "ValorComissao";
			clnValorComissao.Visible = true;
			clnValorComissao.ReadOnly = true;
			clnValorComissao.Resizable = DataGridViewTriState.False;
			clnValorComissao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorComissao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorComissao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorComissao.DefaultCellStyle.Format = "#,##0.00";
			clnValorComissao.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(
				clnCheck,
				clnID,
				clnDataInicial,
				clnDataFinal,
				clnSetor,
				clnCredor,
				clnValorContribuicoes,
				clnValorDescontado,
				clnValorComissao);
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

		// CALC CHECKED VALUES LABELS
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.RowIndex >= 0)
			{
				var row = dgvListagem.Rows[e.RowIndex];

				if ((bool)row.Cells[0].Value == true)
				{
					nItemsSelected += 1;
				}
				else
				{
					nItemsSelected -= 1;
				}
			}

			btnEfetuar.Enabled = nItemsSelected > 0 && rbtPagas.Checked == false;
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
			btnEfetuar.Enabled = false;
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
			var frm = new frmComissaoInserir(Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault());
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// ABRIR CONTRIBUICAO ESCOLHIDA
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
			objComissao item = (objComissao)dgvListagem.SelectedRows[0].DataBoundItem;

			frmComissao frm = new frmComissao(item);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// IMPRIMIR REPORT
		//------------------------------------------------------------------------------------------------------------
		private void btnImprimir_Click(object sender, EventArgs e)
		{
			/*
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- convert list
				List<object> mylist = listCont.Cast<object>().ToList();

				//--- create Params
				var param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dtInicial", _dtInicial.ToShortDateString()));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dtFinal", _dtFinal.ToShortDateString()));

				//--- create Report Global and Show
				var frm = new Main.frmReportGlobal("CamadaUI.Contribuicao.Reports.rptEntradasPorPeriodoList.rdlc",
					"Relatório de Contribuições",
					mylist, null, param);
				frm.ShowDialog();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o Formulário de Impresão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
			*/
		}

		private void btnEfetuar_Click(object sender, EventArgs e)
		{
			//--- verify checked itens
			if (nItemsSelected == 0)
			{
				AbrirDialog("Favor selecionar um registro para efetuar...",
					"Selecionar Registros", DialogType.OK, DialogIcon.Information);
				return;
			}

			if (_situacao == 1) // CONCLUIR
			{
				string mesage = nItemsSelected > 1 ? $"definitivamente as {nItemsSelected:00} Comissões selecionadas?" : "definitivamente a Comissão selecionada?";

				// --- ask USER
				var resp = AbrirDialog("Você deseja realmente CONCLUIR " + mesage,
					"Concluir Comissões",
					DialogType.SIM_NAO,
					DialogIcon.Question,
					DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				ConcluirComissoesSelected();
			}
			else if (_situacao == 2) // CRIAR PAGAMENTO
			{
				PagarComissoesSelected();
			}
		}

		// CONCLUIR COMISSOES
		//------------------------------------------------------------------------------------------------------------
		private void ConcluirComissoesSelected()
		{
			try
			{
				List<objComissao> selected = new List<objComissao>();

				foreach (DataGridViewRow row in dgvListagem.Rows)
				{
					bool marked = row.Cells[0].Value == null ? false : (bool)row.Cells[0].Value;

					if (marked)
					{
						selected.Add((objComissao)row.DataBoundItem);
					}
				}

				cBLL.ComissoesSituacaoChange(selected, 2);

				//--- obterDados
				ObterDados();

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Efetuar a Finalização das Comissões Selecionadas..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CRIAR DESPESA DE PAGAMENTO | SAIDA
		//------------------------------------------------------------------------------------------------------------
		private void PagarComissoesSelected()
		{
			// create list of selected comissao
			//---------------------------------------------------------------------
			List<objComissao> selected = new List<objComissao>();

			foreach (DataGridViewRow row in dgvListagem.Rows)
			{
				bool marked = row.Cells[0].Value == null ? false : (bool)row.Cells[0].Value;

				if (marked)
				{
					selected.Add((objComissao)row.DataBoundItem);
				}
			}

			// check same colaborador
			//---------------------------------------------------------------------
			if (selected.GroupBy(x => x.IDCredor).Count() > 1)
			{
				AbrirDialog("As Comissões selecionadas pertencem a diversos COLABORADORES diferentes..." +
					"\nAs Comissões selecionadas devem ser de um ÚNICO Colaborador." +
					"\nFavor selecionar comissões do mesmo colaborador."
					, "Diversos Colaboradores", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// check total
			//---------------------------------------------------------------------
			decimal total = selected.Sum(x => x.ValorComissao);

			// --- ask USER
			//---------------------------------------------------------------------
			string mesage = nItemsSelected > 1 ? $"das {nItemsSelected:00} Comissões selecionadas?" : "da Comissão selecionada?";

			var resp = AbrirDialog("Você deseja realmente REALIZAR O PAGAMENTO " + mesage +
				$"\n\nCOLABORADOR: {selected[0].Credor}" +
				$"\nVALOR TOTAL: {total:C}",
				"Quitar Comissões",
				DialogType.SIM_NAO,
				DialogIcon.Question,
				DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// open form to get info: CONTA and DATE
				var frm = new frmComissaoQuitarInfo(selected[0], total, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				// create apagar and saida
				objDespesaComum despesa = DefineDespesa(selected, frm.propDataEscolhida, total);
				objAPagar pagar = DefineAPagar(selected, frm.propDataEscolhida, total);
				objMovimentacao saida = DefineSaida(
					frm.propDataEscolhida,
					(int)frm.propContaEscolhida.IDConta,
					selected[0].IDSetor,
					total,
					frm.propObservacao);

				// create Gasto: Despesa quitada
				long newID = cBLL.ComissoesPagamento
					(
					selected,
					despesa,
					pagar,
					saida,
					ContaSaldoLocalUpdate,
					SetorSaldoLocalUpdate
					);

				ObterDados();

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- message
				resp = AbrirDialog("Pagamento efetuado com sucesso na conta e data informados..." +
							"\nDeseja CONFERIR a Despesa criada?",
							"Sucesso",
							DialogType.SIM_NAO,
							DialogIcon.Question,
							DialogDefaultButton.Second);

				if (resp == DialogResult.Yes)
				{
					var frmGt = new Saidas.frmGasto(newID);
					frmGt.MdiParent = Application.OpenForms[0];
					Close();
					frmGt.Show();
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Efetuar a Finalização das Comissões Selecionadas..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// DEFINE DESPESA TO SAVE
		//------------------------------------------------------------------------------------------------------------
		private objDespesaComum DefineDespesa(List<objComissao> comissoes, DateTime PagData, decimal Total)
		{
			// create format Identificador
			string desc = "Pag. Comissão: " + comissoes[0].Credor;
			if (desc.Length > 200) desc.Substring(0, 200);

			// create format Doc. Numero
			string Id = "";
			comissoes.ForEach(x => Id += ((int)x.IDComissao).ToString("D2") + " | ");
			Id = Id.Substring(0, Id.Length - 3);
			if (Id.Length > 30) Id = Id.Substring(0, 30);

			// get dtInicial a dtFinal
			DateTime despDtInicial = comissoes.Min(x => x.DataInicial);
			DateTime despDtFinal = comissoes.Max(x => x.DataFinal);

			var despesa = new objDespesaComum(null)
			{
				Credor = comissoes[0].Credor,
				DespesaData = PagData,
				CNP = "",
				DataFinal = despDtFinal,
				DataInicial = despDtInicial,
				DespesaDescricao = desc,
				DespesaOrigem = 1,
				DespesaTipo = "Comissão Colaborador",
				DespesaValor = Total,
				DocumentoNumero = Id,
				DocumentoTipo = "Recibo Próprio", // recibo proprio
				IDCredor = comissoes[0].IDCredor,
				IDDespesa = null,
				IDDespesaTipo = 1,
				IDDocumentoTipo = 4,
				IDSetor = comissoes[0].IDSetor,
				IDSituacao = 2,
				IDTitular = null,
				Parcelas = 1,
				Setor = comissoes[0].Setor,
				Situacao = "Quitada",
			};

			return despesa;
		}

		// DEFINE APAGAR TO SAVE
		//------------------------------------------------------------------------------------------------------------
		private objAPagar DefineAPagar(List<objComissao> comissoes, DateTime PagData, decimal Total)
		{
			// create format Identificador
			string Id = "comissao: ";
			comissoes.ForEach(x => Id += ((int)x.IDComissao).ToString("D2") + " | ");
			Id = Id.Substring(0, Id.Length - 3);
			if (Id.Length > 40) Id = Id.Substring(0, 40);

			var apagar = new objAPagar(null)
			{
				APagarValor = Total,
				IDCredor = comissoes[0].IDCredor,
				Identificador = Id,
				IDSetor = comissoes[0].IDSetor,
				IDSituacao = 2,
				PagamentoData = PagData,
				Parcela = 1,
				Prioridade = 3,
				Situacao = "Quitado",
				ValorPago = Total,
				Vencimento = PagData,
			};

			return apagar;
		}

		// DEFINE SAIDA TO SAVE
		//------------------------------------------------------------------------------------------------------------
		private objMovimentacao DefineSaida(DateTime PagData, int IDContaEscolhida, int IDSetorEscolhido, decimal Total, string obs)
		{
			var saida = new objMovimentacao(null)
			{
				IDConta = IDContaEscolhida,
				IDSetor = IDSetorEscolhido,
				MovTipo = 2,
				AcrescimoValor = 0,
				IDCaixa = null,
				Origem = EnumMovOrigem.APagar,
				Observacao = obs,
				MovData = PagData,
				MovValor = Total,
				DescricaoOrigem = "COMISSAO: ",
				Consolidado = true,
			};

			return saida;
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
					txtColaborador, txtSetor,
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
					case "txtColaborador":
						btnSetColaborador_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
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
					case "txtColaborador":
						txtColaborador.Clear();
						_colaborador = null;
						ObterDados();
						break;
					case "txtSetor":
						txtSetor.Clear();
						_setor = null;
						ObterDados();
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
				Control[] controlesBloqueados = { txtColaborador, txtSetor };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetColaborador_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new Registres.frmColaboradorListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK && frm.propEscolha != _colaborador)
				{
					_colaborador = frm.propEscolha;
					txtColaborador.Text = frm.propEscolha.Credor;
					ObterDados();
				}

				//--- select
				txtColaborador.Focus();
				txtColaborador.SelectAll();
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

				Setores.frmSetorProcura frm = new Setores.frmSetorProcura(this, _setor == null ? null : _setor.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK && frm.propEscolha != _setor)
				{
					_setor = frm.propEscolha;
					txtSetor.Text = _setor.Setor;
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
			objComissao comissao = (objComissao)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// mnuDefinir Setor
			mnuImprimirRecibo.Enabled = comissao.IDSituacao == 3;

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		private void mnuVisualizar_Click(object sender, EventArgs e)
		{
			btnVisualizar_Click(sender, e);
		}

		private void mnuExcluir_Click(object sender, EventArgs e)
		{
			ExcluirComissao();
		}

		private void mnuImprimirRecibo_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Imprimir o Recibo de Comissão...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objComissao comissao = (objComissao)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				if (comissao.IDDespesa == null) throw new AppException("A Despesa anexada à essa Comissão foi Excluída...");

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Get created Despesa and Convert to List
				var dadosIgreja = ObterDadosIgreja();
				var despesa = ObterDespesa(comissao);
				var listDespesa = new List<objDespesa>() { despesa };

				//--- Create Data Text
				string DataTexto = $"{dadosIgreja.Cidade}, {despesa.DespesaData.Day} de {despesa.DespesaData:MMMM} de {despesa.DespesaData:yyyy}";

				//--- convert list
				List<object> dstPrimario = listDespesa.Cast<object>().ToList();

				//--- create and ADD params
				var param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ReciboTexto", CreateReciboTexto(comissao, dadosIgreja)));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("DataTexto", DataTexto));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ComissaoValor", comissao.ValorComissao.ToString()));

				//--- create Report Global and Show
				var frm = new Main.frmReportGlobal("CamadaUI.Comissoes.Reports.rptComissaoRecibo.rdlc",
					"Recibo de Auxílio Colaborador",
					dstPrimario, null, param);
				frm.ShowDialog();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o Formulário de Impresão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CREATE DESCRICAO TEXTO PARA RECIBO
		//------------------------------------------------------------------------------------------------------------
		private string CreateReciboTexto(objComissao comissao, objDadosIgreja dadosIgreja)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				string Extenso = EscreverExtenso(comissao.ValorComissao);

				string texto = $"Eu, {comissao.Credor} recebi da " +
					$"{(dadosIgreja.RazaoSocial.Trim().Length == 0 ? "Instituição " : dadosIgreja.RazaoSocial)} " +
					$"o valor de {comissao.ValorComissao:C} ({Extenso}) a título de PREBENDA. ";

				return texto;

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// OBTER DESPESA REFERENTE PARA RECIBO
		//------------------------------------------------------------------------------------------------------------
		private objDespesa ObterDespesa(objComissao comissao)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				return new DespesaComumBLL().GetDespesa((long)comissao.IDDespesa);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EXCLUIR COMISSAO
		//------------------------------------------------------------------------------------------------------------
		private void ExcluirComissao()
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Excluir...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objComissao comissao = (objComissao)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- VERIFICA SE EXISTE DESPESA ANEXADA
			if (comissao.IDDespesa != null)
			{
				AbrirDialog("Não é possível excluir essa Comissão porque ainda existe uma despesa vinculada..." +
					$"O registro da despesa é {comissao.IDDespesa:D4}" +
					$"É necessário Excluir a Despesa anexada para remover a comissão.",
					"Despesa Anexada",
					DialogType.OK,
					DialogIcon.Exclamation);
				return;
			}

			// --- ask USER
			var resp = AbrirDialog("Você deseja realmente EXCLUIR definitivamente a Comissão abaixo?\n" +
				$"\nREG: {comissao.IDComissao:D4}\nVALOR: {comissao.ValorComissao:c}",
				"Excluir Comissão",
				DialogType.SIM_NAO,
				DialogIcon.Question,
				DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- execute
				cBLL.ComissaoExcluir(comissao);

				//--- REQUERY LIST
				ObterDados();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir a Comissao..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // MENU SUSPENSO --- END
	}
}
