using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaUI.Imagem;

namespace CamadaUI.APagar
{
	public partial class frmAPagarSaidas : Modals.frmModFinBorder
	{
		objAPagar _apagar;
		APagarBLL pBLL = new APagarBLL();
		BindingSource bind = new BindingSource();
		BindingSource bindSaida = new BindingSource();
		List<objMovimentacao> listSaidas = new List<objMovimentacao>();
		Form _formOrigem;
		decimal DescontoAnterior;

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarSaidas(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			_apagar = pag;
			bind.DataSource = _apagar;
			BindingCreator();

			GetSaidaList();
			dgvListagem.DataSource = bindSaida;
			FormataListagem();

			if (_apagar.IDSituacao != 1) // NOT NORMAL
			{
				btnQuitar.Enabled = false;
				btnConcederDesconto.Enabled = false;
			}

			DefineValueLabels();
		}

		// GET LIST OF SAIDAS
		//------------------------------------------------------------------------------------------------------------
		private void GetSaidaList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//listSaidas = new MovimentacaoBLL().GetSaidaList(1, (long)_apagar.IDAPagar);
				listSaidas = new MovimentacaoBLL().GetMovimentacaoListByOrigem(EnumMovOrigem.APagar, (long)_apagar.IDAPagar, true);
				bindSaida.DataSource = listSaidas;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Saídas/Pagamentos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void DefineValueLabels()
		{
			int atraso = (DateTime.Today - _apagar.Vencimento).Days;
			lblAtrasoDias.Text = atraso < 1 ? "Em Dia" : atraso.ToString("D2") + " dia(s)";
			lblValorEmAberto.Text = (_apagar.APagarValor - _apagar.ValorDesconto - _apagar.ValorPago).ToString("c");
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDINGS

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagar", true);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true);
			lblIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCobrancaForma.DataBindings.Add("Text", bind, "CobrancaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			lblBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			lblVencimento.DataBindings.Add("Text", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			lblAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorDesconto.DataBindings.Add("Text", bind, "ValorDesconto", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorPago.DataBindings.Add("Text", bind, "ValorPago", true, DataSourceUpdateMode.OnPropertyChanged);
			lblValorAcrescimo.DataBindings.Add("Text", bind, "ValorAcrescimo", true, DataSourceUpdateMode.OnPropertyChanged);
			lblReferencia.DataBindings.Add("Text", bind, "Referencia", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += (a, e) => e.Value = $"{e.Value: 0000}";
			lblAPagarValor.DataBindings["Text"].Format += FormatCurrency;
			txtValorDesconto.DataBindings["Text"].Format += FormatCurrency;
			lblValorPago.DataBindings["Text"].Format += FormatCurrency;
			lblValorAcrescimo.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		#endregion // DATABINDINGS --- END

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

			//--- (1) COLUNA DATA
			clnData.DataPropertyName = "MovData";
			clnData.Visible = true;
			clnData.ReadOnly = true;
			clnData.Resizable = DataGridViewTriState.False;
			clnData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.DefaultCellStyle.Font = clnFont;
			colList.Add(clnData);

			//--- (2) COLUNA VALOR
			clnValor.DataPropertyName = "MovValorAbsoluto";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnValor);

			//--- (3) COLUNA CONTA
			clnConta.DataPropertyName = "Conta";
			clnConta.Visible = true;
			clnConta.ReadOnly = true;
			clnConta.Resizable = DataGridViewTriState.False;
			clnConta.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnConta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnConta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnConta.DefaultCellStyle.Font = clnFont;
			colList.Add(clnConta);

			//--- (4) COLUNA OBSERVACAO
			clnObservacao.DataPropertyName = "Observacao";
			clnObservacao.Visible = true;
			clnObservacao.ReadOnly = true;
			clnObservacao.Resizable = DataGridViewTriState.False;
			clnObservacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnObservacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnObservacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnObservacao.DefaultCellStyle.Font = clnFont;
			colList.Add(clnObservacao);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		#endregion

		#region BUTTONS FUNCTION

		// CLOSE | CANCELAR
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		// QUITAR
		private void btnQuitar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmAPagarQuitar frm = new frmAPagarQuitar(_apagar, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				// EXECUTE
				objMovimentacao newSaida = frm.propSaida;
				newSaida.IDMovimentacao = pBLL.QuitarAPagar(_apagar, frm.propSaida, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

				// binding
				bindSaida.Add(newSaida);
				DefineValueLabels();

				// check pagamento total
				if (_apagar.IDSituacao == 2)
				{
					AbrirDialog("A Pagar totalmente quitado...", "Pagamento Total");
					btnQuitar.Enabled = false;
					btnConcederDesconto.Enabled = false;
				}



			}
			catch (AppException ex)
			{
				if (ex.HResult == 1)
					AbrirDialog("Pagamento não realizado...\n" + ex.Message, "Saldo da Conta", DialogType.OK, DialogIcon.Information);
				else
					AbrirDialog("Pagamento não realizado...\n" + ex.Message, "Conta Data Bloqueada", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Quitar o A Pagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// ESTORNAR
		private void btnEstornar_Click(object sender, EventArgs e)
		{
			//--- check selecteded item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro de Pagamento para Estornar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- verifica USER PERMIT
				if (!CheckAuthorization(EnumAcessoTipo.Usuario_Senior, $"Estornar a Saída de APagar", this)) return;

				//--- Pergunta ao USER
				objMovimentacao saida = (objMovimentacao)dgvListagem.SelectedRows[0].DataBoundItem;

				var resp = AbrirDialog($"Você deseja realmente ESTORNAR este registro de PAGAMENTO selecionado?\n" +
					$"DATA: {saida.MovData.ToShortDateString()}\nVALOR: {saida.MovValorAbsoluto:c}\n{saida.Conta}", "Estornar Pagamento",
					DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

				if (resp == DialogResult.No) return;

				// EXECUTE
				pBLL.EstornarAPagar(_apagar, saida, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

				// binding
				bindSaida.RemoveCurrent();
				DefineValueLabels();

				// MESSAGE
				AbrirDialog("Pagamento Estornado com sucesso...", "Estorno");
				btnQuitar.Enabled = true;
				btnConcederDesconto.Enabled = true;
			}
			catch (AppException ex)
			{
				AbrirDialog("Estorno não pôde ser realizado...\n" + ex.Message, "Conta Data Bloqueada", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Estornar Pagamento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CLOSE FORM
		//------------------------------------------------------------------------------------------------------------
		private void frmAPagarSaidas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) // CLOSE FORM
			{
				e.Handled = true;
				btnClose_Click(sender, new EventArgs());
			}
		}

		#endregion // BUTTONS FUNCTION --- END

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

		// CONTROLA TOOLTIP
		//------------------------------------------------------------------------------------------------------------
		private void ShowToolTip(Control control)
		{
			//--- Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip();

			//--- Define o delay para a ToolTip.
			toolTip1.AutoPopDelay = 2000;
			toolTip1.InitialDelay = 2000;
			toolTip1.ReshowDelay = 500;
			toolTip1.IsBalloon = true;
			toolTip1.UseAnimation = true;
			toolTip1.UseFading = true;

			if (string.IsNullOrEmpty(control.Tag.ToString()))
				toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000);
			else
				toolTip1.Show(control.Tag.ToString(), control, control.Width - 30, -40, 2000);
		}

		private void btnProcurar_EnabledChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;

			if (control.Enabled == true)
				ShowToolTip(control);
		}


		#endregion // DESIGN FORM FUNCTIONS --- END

		#region EDIT DESCONTO

		private void btnConcederDesconto_Click(object sender, EventArgs e)
		{
			DescontoAnterior = decimal.Parse(txtValorDesconto.Text, NumberStyles.Currency);
			txtValorDesconto.BackColor = Color.White;
			txtValorDesconto.ReadOnly = false;
			txtValorDesconto.Focus();
			txtValorDesconto.SelectAll();

			ShowToolTip(txtValorDesconto as Control);
		}

		private void txtValorDesconto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			}
		}

		private void txtValorDesconto_Leave(object sender, EventArgs e)
		{
			txtValorDesconto.ReadOnly = true;
			txtValorDesconto.BackColor = Color.FromArgb(225, 232, 240);

			//--- verifica se o desconto foi alterado
			decimal newDesconto = decimal.Parse(txtValorDesconto.Text, NumberStyles.Currency);

			if (DescontoAnterior != newDesconto)
			{
				//--- verifica se o novo valor do desconto é menor que o valor do APagar
				if (newDesconto >= _apagar.APagarValor - _apagar.ValorPago)
				{
					AbrirDialog("Não é possível conceder um valor de DESCONTO MAIOR ou IGUAL ao valor EM ABERTO desse A PAGAR...",
								"Conceder Desconto",
								DialogType.OK,
								DialogIcon.Exclamation);
					_apagar.ValorDesconto = DescontoAnterior;
					txtValorDesconto.DataBindings["Text"].ReadValue();
					return;
				}

				txtValorDesconto.DataBindings["Text"].ReadValue();

				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;
					pBLL.UpdateAPagar(_apagar);

					//--- recalcula o valor em aberto
					DefineValueLabels();

				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Alterar o Desconto..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
			}
		}

		private void UcOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '.')
			{
				txtValorDesconto.SelectedText = ",";
				e.Handled = true;
			}
			else if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}


		#endregion // EDIT DESCONTO --- END

		#region IMAGE CONTROL
		private void btnInserirImagem_Click(object sender, EventArgs e)
		{
			if (_apagar.IDAPagar == null)
			{
				AbrirDialog("É necessário salvar o APagar para anexar uma imagem ao pagamento...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)_apagar.IDAPagar,
					Origem = EnumImagemOrigem.APagar,
					ImagemFileName = _apagar.Imagem == null ? string.Empty : _apagar.Imagem.ImagemFileName,
					ImagemPath = _apagar.Imagem == null ? string.Empty : _apagar.Imagem.ImagemPath,
					ReferenceDate = _apagar.Vencimento,
				};

				// open form to edit or save image
				bool IsNew = _apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (_apagar.Imagem != null && imagem != null)
				{
					IsUpdated = (_apagar.Imagem.ImagemFileName != imagem.ImagemFileName) || (_apagar.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				_apagar.Imagem = imagem;

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

		private void btnVerImagem_Click(object sender, EventArgs e)
		{
			if (_apagar.IDAPagar == null)
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a esse APagar..." +
					"\nÉ necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			if (_apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemFileName))
			{
				var resp = AbrirDialog("Ainda não existe nenhuma imagem associada a esse APagar..." +
					"\nDeseja INSERIR uma nova imagem ao APagar?",
					"Não há Imagem", DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					btnInserirImagem_Click(sender, e);
				}

				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(_apagar.Imagem);
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

		private void mnuImagem_Click(object sender, EventArgs e)
		{
			if (_apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemFileName))
			{
				btnInserirImagem.Text = "Inserir Imagem";
				btnRemoverImagem.Enabled = false;
			}
			else
			{
				btnInserirImagem.Text = "Alterar Imagem";
				btnRemoverImagem.Enabled = true;
			}
		}

		private void btnRemoverImagem_Click(object sender, EventArgs e)
		{
			DialogResult resp;

			if (_apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemFileName))
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a esse APagar para que seja removida...",
					"Não há Imagem", DialogType.OK, DialogIcon.Warning);
				return;
			}

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem do APagar atual?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				_apagar.Imagem = ImagemUtil.ImagemRemover(_apagar.Imagem);

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

		#endregion // IMAGE CONTROL --- END

		#region MNU CONTEXT PAGAMENTO

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
			objMovimentacao mov = (objMovimentacao)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// mnuImagem
			if (mov.IDMovimentacao != null)
			{
				mnuImagem.Enabled = true;
				bool IsThereImagem = mov.Imagem != null && !string.IsNullOrEmpty(mov.Imagem.ImagemFileName);

				mnuImagemRemover.Enabled = IsThereImagem;
				mnuImagemInserir.Text = IsThereImagem ? "Alterar Imagem" : "Inserir Imagem";
				mnuImagemVisualizar.Enabled = IsThereImagem;
			}
			else
			{
				mnuImagem.Enabled = false;
			}

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));
		}

		private void estornarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnEstornar_Click(sender, e);
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
			objMovimentacao item = (objMovimentacao)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)item.IDMovimentacao,
					Origem = EnumImagemOrigem.Movimentacao,
					ImagemFileName = item.Imagem == null ? string.Empty : item.Imagem.ImagemFileName,
					ImagemPath = item.Imagem == null ? string.Empty : item.Imagem.ImagemPath,
					ReferenceDate = item.MovData,
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
			objMovimentacao item = (objMovimentacao)dgvListagem.SelectedRows[0].DataBoundItem;

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
			objMovimentacao item = (objMovimentacao)dgvListagem.SelectedRows[0].DataBoundItem;

			DialogResult resp;

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da Movimentação de Saída selecionada?" +
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

		#endregion // MNU CONTEXT PAGAMENTO --- END

	}
}
