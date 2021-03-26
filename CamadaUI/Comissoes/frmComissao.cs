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
	public partial class frmComissao : Modals.frmModFinBorder
	{
		private objComissao _comissao;
		private List<objContribuicao> list;
		private BindingSource bind = new BindingSource();
		private BindingSource BindList = new BindingSource();
		private Form _formOrigem;
		private ComissaoBLL cBLL = new ComissaoBLL();

		#region SUB NEW | CONSTRUCTOR

		public frmComissao(
			objComissao comissao,
			List<objContribuicao> lstContribuicao = null,
			Form formOrigem = null)
		{
			InitializeComponent();

			_formOrigem = formOrigem;

			_comissao = comissao;
			bind.DataSource = _comissao;
			BindingCreator();

			DefineSituacao();

			list = lstContribuicao;
			ObterDadosListagem();


			// HANDLER to use TAB for ENTER
			HandlerKeyDownControl(this);
		}

		// DEFINE SITUACAO
		//------------------------------------------------------------------------------------------------------------
		private void DefineSituacao()
		{
			btnRecibo.Visible = _comissao.IDSituacao == 3;

			switch (_comissao.IDSituacao)
			{
				case 1:
					btnEfetuar.Text = "Concluir";
					btnEfetuar.Image = Properties.Resources.accept_24;
					break;
				case 2:
					btnEfetuar.Text = "Quitar";
					btnEfetuar.Image = Properties.Resources.money_red_24;
					break;
				case 3:
					btnEfetuar.Text = "Ver Pagamento";
					btnEfetuar.Image = Properties.Resources.search_page_24;
					break;
				default:
					break;
			}
		}

		// OBTEM DADOS DA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void ObterDadosListagem()
		{
			if (list == null) // obter dados da listagem contribuicao
			{
				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;

					//--- Get CONTRIBUICAO LIST
					list = cBLL.GetInsertedContribuicaoList((int)_comissao.IDComissao);

					if (list == null || list.Count == 0)
					{
						AbrirDialog("Não há contribuições disponíveis para comissão" +
							$" para o colaborador escolhido: \n{_comissao.Credor}",
							"Não há registros", DialogType.OK, DialogIcon.Exclamation);
						return;
					}
				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Obter a lista das contribuições..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
					btnEfetuar.Enabled = false;
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
			}

			BindList.DataSource = list;
			dgvListagem.DataSource = BindList;
			FormataListagem();
			CalculaTotais();
		}

		//--- CALCULA OS TOTAIS E ALTERA AS LABELS
		//----------------------------------------------------------------------------------
		private void CalculaTotais()
		{
			decimal vlTotal = list.Sum(x => x.ValorRecebido);
			lblValorContribuicoes.Text = vlTotal.ToString("C");
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDComissao", true);
			lblColaborador.DataBindings.Add("Text", bind, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDataInicial.DataBindings.Add("Text", bind, "DataInicial", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDataFinal.DataBindings.Add("Text", bind, "DataFinal", true, DataSourceUpdateMode.OnPropertyChanged);
			lblComissaoTaxa.DataBindings.Add("Text", bind, "ComissaoTaxa", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorContribuicoes.DataBindings.Add("Text", bind, "ValorContribuicoes", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorDescontado.DataBindings.Add("Text", bind, "ValorDescontado", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorComissao.DataBindings.Add("Text", bind, "ValorComissao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblSituacao.DataBindings.Add("Text", bind, "Situacao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblComissaoTaxa.DataBindings["Text"].Format += FormatPercent;
			lblValorComissao.DataBindings["Text"].Format += FormatCurrency;
			lblValorDescontado.DataBindings["Text"].Format += FormatCurrency;
			lblValorContribuicoes.DataBindings["Text"].Format += FormatCurrency;

		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatPercent(object sender, ConvertEventArgs e)
		{
			if (decimal.TryParse(e.Value == null ? null : e.Value.ToString(), out decimal comissao))
			{
				if (comissao > 0.99m)
				{
					e.Value = (((decimal)e.Value) / 100).ToString("#,##0.00%");
				}
				else
				{
					e.Value = ((decimal)e.Value).ToString("#,##0.00%");
				}
			}
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
			Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDContribuicao";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA DATA
			clnData.DataPropertyName = "ContribuicaoData";
			clnData.Visible = true;
			clnData.ReadOnly = true;
			clnData.Resizable = DataGridViewTriState.False;
			clnData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA CONTA
			clnConta.DataPropertyName = "Conta";
			clnConta.Visible = true;
			clnConta.ReadOnly = true;
			clnConta.Resizable = DataGridViewTriState.False;
			clnConta.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnConta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnConta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnConta.DefaultCellStyle.Font = clnFont;

			//--- (5) COLUNA TIPO
			clnTipo.DataPropertyName = "ContribuicaoTipo";
			clnTipo.Visible = true;
			clnTipo.ReadOnly = true;
			clnTipo.Resizable = DataGridViewTriState.False;
			clnTipo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.DefaultCellStyle.Font = clnFont;

			//--- (9) COLUNA VALOR RECEBIDO
			clnValorRecebido.DataPropertyName = "ValorRecebido";
			clnValorRecebido.Visible = true;
			clnValorRecebido.ReadOnly = true;
			clnValorRecebido.Resizable = DataGridViewTriState.False;
			clnValorRecebido.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorRecebido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorRecebido.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorRecebido.DefaultCellStyle.Format = "#,##0.00";
			clnValorRecebido.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(
				clnID,
				clnData,
				clnConta,
				clnTipo,
				clnValorRecebido);
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

		// ABRIR CONTRIBUICAO ESCOLHIDA
		//------------------------------------------------------------------------------------------------------------
		private void btnVisualizar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objContribuicao item = (objContribuicao)dgvListagem.SelectedRows[0].DataBoundItem;

			Entradas.frmContribuicao frm = new Entradas.frmContribuicao(item);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		#endregion

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			var frm = new frmComissaoListagem(_comissao.IDSituacao, null);
			frm.MdiParent = Application.OpenForms[0];
			frm.Show();

			Close();
			//MostraMenuPrincipal();
		}

		private void btnEfetuar_Click(object sender, EventArgs e)
		{
			switch (_comissao.IDSituacao)
			{
				case 1: // CONCLUIR COMISSAO
						// --- ask USER
					var resp = AbrirDialog("Você deseja realmente CONCLUIR esse Registro de Comissão?",
						"Concluir Comissões",
						DialogType.SIM_NAO,
						DialogIcon.Question,
						DialogDefaultButton.Second);

					if (resp != DialogResult.Yes) return;

					ConcluirComissao();
					break;
				case 2: // PAGAR COMISSAO

					PagarComissao();
					break;

				case 3: // COMISSAO PAGA --> VER PAGAMENTO

					try
					{
						// --- Ampulheta ON
						Cursor.Current = Cursors.WaitCursor;

						var despesa = ObterDespesa();

						var frmGt = new Saidas.frmGasto(despesa);
						frmGt.MdiParent = Application.OpenForms[0];
						Close();
						frmGt.Show();

					}
					catch (Exception ex)
					{
						AbrirDialog("Uma exceção ocorreu ao Obter os dados da despesa..." + "\n" +
									ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
					}
					finally
					{
						// --- Ampulheta OFF
						Cursor.Current = Cursors.Default;
					}

					break;

				default:
					break;
			}
		}

		// IMPRIMIR REPORT
		//------------------------------------------------------------------------------------------------------------
		private void btnRecibo_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Get created Despesa and Convert to List
				var dadosIgreja = ObterDadosIgreja();
				var despesa = ObterDespesa();
				var listDespesa = new List<objDespesa>() { despesa };

				//--- Create Data Text
				string DataTexto = $"{dadosIgreja.Cidade}, {despesa.DespesaData.Day} de {despesa.DespesaData:MMMM} de {despesa.DespesaData:yyyy}";

				//--- convert list
				List<object> dstPrimario = listDespesa.Cast<object>().ToList();

				//--- create and ADD params
				var param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ReciboTexto", CreateReciboTexto(dadosIgreja)));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("DataTexto", DataTexto));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ComissaoValor", _comissao.ValorComissao.ToString()));

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

		#endregion // BUTTONS FUNCTION --- END

		#region ACTIONS

		// CONCLUIR COMISSOES
		//------------------------------------------------------------------------------------------------------------
		private void ConcluirComissao()
		{
			try
			{
				List<objComissao> list = new List<objComissao>();
				list.Add(_comissao);

				cBLL.ComissoesSituacaoChange(list, 2);

				_comissao.IDSituacao = 2;
				lblSituacao.DataBindings["Text"].ReadValue();
				DefineSituacao();

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

		// CREATE DESCRICAO TEXTO PARA RECIBO
		//------------------------------------------------------------------------------------------------------------
		private string CreateReciboTexto(objDadosIgreja dadosIgreja)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				string Extenso = EscreverExtenso(_comissao.ValorComissao);

				string texto = $"Eu, {_comissao.Credor} recebi da " +
					$"{(dadosIgreja.RazaoSocial.Trim().Length == 0 ? "Instituição " : dadosIgreja.RazaoSocial)} " +
					$"o valor de {_comissao.ValorComissao:C} ({Extenso}) a título de PREBENDA. ";

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
		private objDespesaComum ObterDespesa()
		{
			try
			{
				if (_comissao.IDDespesa == null) throw new AppException("A Despesa anexada à essa Comissão foi Excluída...");

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				return new DespesaComumBLL().GetDespesa((long)_comissao.IDDespesa);
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

		// CRIAR DESPESA DE PAGAMENTO | SAIDA
		//------------------------------------------------------------------------------------------------------------
		private void PagarComissao()
		{
			// create list of comissao
			//---------------------------------------------------------------------
			List<objComissao> selected = new List<objComissao>();
			selected.Add(_comissao);

			// check total
			//---------------------------------------------------------------------
			decimal total = _comissao.ValorComissao;

			// --- ask USER
			//---------------------------------------------------------------------
			var resp = AbrirDialog("Você deseja realmente REALIZAR O PAGAMENTO da Comissão selecionada?" +
				$"\n\nCOLABORADOR: {_comissao.Credor}" +
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

				_comissao.IDDespesa = newID;
				_comissao.IDSituacao = 3;
				_comissao.EndEdit();
				DefineSituacao();

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


		#endregion // ACTIONS --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
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
