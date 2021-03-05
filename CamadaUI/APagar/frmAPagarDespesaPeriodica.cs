using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarDespesaPeriodica : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesaPeriodica _periodica;
		private List<objAPagar> listPag = new List<objAPagar>();
		private BindingSource bind = new BindingSource();
		private BindingSource bindPag = new BindingSource();
		private APagarBLL pBLL = new APagarBLL();
		private Form _formOrigem;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		public frmAPagarDespesaPeriodica(objDespesaPeriodica Periodica, Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_periodica = Periodica;
			_formOrigem = formOrigem;
			bind.DataSource = _periodica;
			BindingCreator();

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- Handlers
			HandlerKeyDownControl(this);
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
				listPag = pBLL.GetListAPagarByDespesa((int)_periodica.IDDespesa);

				bindPag.DataSource = listPag;
				dgvListagem.DataSource = bindPag;
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

		#endregion // NEW | OPEN FUNCTIONS | PROPERTIES --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDDespesa", true);
			lblSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaTipo.DataBindings.Add("Text", bind, "DespesaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaValor.DataBindings.Add("Text", bind, "DespesaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblIniciarData.DataBindings.Add("Text", bind, "IniciarData", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblDespesaValor.DataBindings["Text"].Format += FormatCurrency;
			lblDespesaDescricao.DataBindings["Text"].Format += FormatDescricao;

		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			if (e.Value == DBNull.Value || e.Value == null)
			{
				e.Value = "NOVA";
			}
			else
			{
				e.Value = $"{e.Value: 0000}";
			}
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		private void FormatDescricao(object sender, ConvertEventArgs e)
		{
			if (_periodica.Instalacao != null && !string.IsNullOrEmpty(_periodica.Instalacao))
			{
				e.Value = $"{e.Value} ({_periodica.Instalacao})";
			}
		}

		#endregion // DATABINDING --- END

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

			//--- (4) COLUNA SITUACAO
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.DefaultCellStyle.Font = clnFont;
			colList.Add(clnSituacao);

			//--- (5) COLUNA REFERENCIA
			clnReferencia.DataPropertyName = "Referencia";
			clnReferencia.Visible = true;
			clnReferencia.ReadOnly = true;
			clnReferencia.Resizable = DataGridViewTriState.False;
			clnReferencia.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnReferencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnReferencia.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnReferencia.DefaultCellStyle.Font = clnFont;
			colList.Add(clnReferencia);

			//--- (6) COLUNA VALOR
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

			//--- (7) COLUNA DATA
			clnPagamentoData.DataPropertyName = "PagamentoData";
			clnPagamentoData.Visible = true;
			clnPagamentoData.ReadOnly = true;
			clnPagamentoData.Resizable = DataGridViewTriState.False;
			clnPagamentoData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnPagamentoData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnPagamentoData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnPagamentoData.DefaultCellStyle.Font = clnFont;
			colList.Add(clnPagamentoData);

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

			VerPagamentos();
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

		#region CONTROL FUNCTIONS

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			e.SuppressKeyPress = true;
		}

		// CONTROLLING LABEL FONT SIZE
		//------------------------------------------------------------------------------------------------------------
		private void lbl_TextChanged(object sender, EventArgs e)
		{
			ResizeFontLabel(lblDespesaDescricao);
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS FUNCTION

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
		}

		// IMPRIMIR LISTAGEM
		//-------------------------------------------------------------------------------------------------------
		private void btnImprimir_Click(object sender, EventArgs e)
		{
			//--- check list quantity
			if (listPag == null || listPag.Count == 0)
			{
				AbrirDialog("Não existe nenhum item na listagem para ser impresso...",
					"Listagem Vazia", DialogType.OK, DialogIcon.Warning);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- convert list
				List<object> dstPrimario = listPag.Cast<object>().ToList();

				//--- create Params
				var param = new List<Microsoft.Reporting.WinForms.ReportParameter>();

				DateTime dtInicial = listPag.Min(x => x.Vencimento);
				DateTime dtFinal = listPag.Max(x => x.Vencimento);

				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("prmDataInicial", dtInicial.ToShortDateString()));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("prmDataFinal", dtFinal.ToShortDateString()));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("prmHideGroupMes", "true"));
				param.Add(new Microsoft.Reporting.WinForms.ReportParameter("prmTitulo", "Listagem de Despesas Periódicas Pagas"));

				//--- create Report Global and Show
				var frm = new Main.frmReportGlobal("CamadaUI.APagar.Reports.rptPagamentos.rdlc",
					"Relatório de Pagamentos",
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



			/*
			if (listPag == null || listPag.Count == 0)
			{
				AbrirDialog("Não há nenhum registro de A Pagar na listagem para ser impresso...",
					"Listagem Vazia");
				return;
			}

			DateTime dtInicial = listPag.Min(x => x.Vencimento); ;
			DateTime dtFinal = listPag.Max(x => x.Vencimento); ;

			Reports.frmAPagarReport frm = new Reports.frmAPagarReport(listPag, dtInicial, dtFinal);
			frm.ShowDialog();
			*/
		}

		#endregion // BUTTONS FUNCTION --- END

		#region MENU ITEMS

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

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}


		//--- VER PAGAMENTOS A PAGAR
		//-------------------------------------------------------------------------------------------------------
		private void VerPagamentos()
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

		// VER PAGAMENTOS
		//------------------------------------------------------------------------------------------------------------
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

		// IMAGEM MENU
		//------------------------------------------------------------------------------------------------------------
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

		#endregion // MENU ITEMS --- END

		#region DESIGN FORM FUNCTIONS

		private void frm_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END

	}
}
