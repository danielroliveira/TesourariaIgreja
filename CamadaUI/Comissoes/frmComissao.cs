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

					break;
				case 3: // COMISSAO PAGA --> VER PAGAMENTO
					var frmGt = new Saidas.frmGasto((long)_comissao.IDDespesa);
					frmGt.MdiParent = Application.OpenForms[0];
					Close();
					frmGt.Show();
					break;
				default:
					break;
			}
		}

		private void btnRecibo_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Não implementado...");
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
