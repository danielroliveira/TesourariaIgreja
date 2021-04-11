using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.DespesaCartao
{
	public partial class frmDespesaCartao : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesaCartao _despesa;
		private DespesaCartaoBLL despBLL = new DespesaCartaoBLL();
		private BindingSource bindDespesa = new BindingSource();
		private BindingSource bindAPagar = new BindingSource();
		private List<objAPagar> listAPagarVinculado = new List<objAPagar>();
		private List<objAPagar> listAPagarEmAberto = new List<objAPagar>();

		//private objSetor setorSelected;
		private Form _formOrigem;

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		// CONSTRUCTOR WITH DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaCartao(objDespesaCartao despesa, Form formOrigem = null)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			ConstructorContinue(despesa);
		}

		// CONSTRUCTOR WITH ID
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaCartao(long IDDespesa)
		{
			InitializeComponent();
			var desp = GetDespesaByID(IDDespesa);

			if (desp == null) return;

			ConstructorContinue(desp);
		}

		// CONSTRUCTOR CONTINUE AFTER GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objDespesaCartao despesa)
		{
			_despesa = despesa;

			// binding Despesa
			bindDespesa.DataSource = typeof(objDespesaCartao);
			bindDespesa.Add(_despesa);
			BindingCreator();

			// binding APagar
			bindAPagar.DataSource = typeof(objAPagar);
			GetAPagarVinculado();

			SituacaoAlterada();

			// handlers
			bindAPagar.ListChanged += (a, b) => CalculaTotais();

			HandlerKeyDownControl(this);
		}

		// SHOW
		//------------------------------------------------------------------------------------------------------------
		private void frmDespesaCartao_Shown(object sender, EventArgs e)
		{
			if (_despesa == null)
			{
				Close();
				return;
			}

			txtSetor.Enter += text_Enter;
			CalculaTotais();
			_despesa.PropertyChanged += RegistroAlterado;

		}

		// CHANGE SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public void SituacaoAlterada()
		{
			switch (_despesa.IDSituacao)
			{
				case 1: // INICIADA
					btnIncluirItem.Enabled = true;
					btnRemoverItem.Enabled = true;
					btnFinalizar.Enabled = true;
					btnSetSetor.Enabled = true;

					GetAPagarEmAberto();

					break;
				case 2: // FINALIZADA
					btnIncluirItem.Enabled = false;
					btnRemoverItem.Enabled = false;
					btnFinalizar.Enabled = false;
					btnSetSetor.Enabled = false;

					break;
				case 3: // BLOQUEADA
					btnIncluirItem.Enabled = false;
					btnRemoverItem.Enabled = false;
					btnFinalizar.Enabled = false;
					btnSetSetor.Enabled = false;

					break;
				default:
					break;
			}
		}

		// GET DESPESA BY ID
		//------------------------------------------------------------------------------------------------------------
		private objDespesaCartao GetDespesaByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return despBLL.GetDespesaCartaoByID(ID);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET PARCELAMENTO | APAGAR VINCULADOS ADICIONADOS
		//------------------------------------------------------------------------------------------------------------
		private void GetAPagarVinculado()
		{
			try
			{
				if (_despesa.IDDespesa != null)
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;

					listAPagarVinculado = despBLL.ListAPagarCartaoVinculadas((long)_despesa.IDDespesa);
				}

				// format Datagridview
				bindAPagar.DataSource = listAPagarVinculado;
				dgvListagem.DataSource = bindAPagar;
				FormataListagem();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de APagar Vinculados..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET PARCELAMENTO | APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void GetAPagarEmAberto()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listAPagarEmAberto = despBLL.ListAPagarCartaoEmAberto(_despesa.IDCartaoCredito);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Parcelamento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bindDespesa, "IDDespesa", true);
			txtSetor.DataBindings.Add("Text", bindDespesa, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCredor.DataBindings.Add("Text", bindDespesa, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaDescricao.DataBindings.Add("Text", bindDespesa, "DespesaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaData.DataBindings.Add("Text", bindDespesa, "DespesaData", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaValor.DataBindings.Add("Text", bindDespesa, "DespesaValor", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblDespesaValor.DataBindings["Text"].Format += FormatCurrency;
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

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			_despesa.IDSituacao = 1;
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

			//--- (1) COLUNA FORMA
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA ID
			clnIdentificador.DataPropertyName = "Identificador";
			clnIdentificador.Visible = true;
			clnIdentificador.ReadOnly = true;
			clnIdentificador.Resizable = DataGridViewTriState.False;
			clnIdentificador.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIdentificador.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA VENCIMENTO
			clnVencimento.DataPropertyName = "Vencimento";
			clnVencimento.Visible = true;
			clnVencimento.ReadOnly = true;
			clnVencimento.Resizable = DataGridViewTriState.False;
			clnVencimento.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnVencimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.DefaultCellStyle.Font = clnFont;

			//--- (4) COLUNA VALOR
			clnValor.DataPropertyName = "APagarValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Format = "#,##0.00";
			clnValor.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnCredor, clnIdentificador, clnVencimento, clnValor);
		}

		#endregion

		#region BUTTONS

		private void btnFechar_Click(object sender, EventArgs e)
		{
			if (_despesa.IDSituacao == 1)
			{
				var resp = AbrirDialog("Essa Despesa de Cartão ainda não foi concluída..." +
					"\n\nDeseja fechar assim mesmo?",
					"Não concluída",
					DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.No) return;
			}

			Close();

			if (_formOrigem != null && _formOrigem.Name == "frmDespesaCartaoListagem")
			{
				var frm = new frmDespesaCartaoListagem();
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				frm.Show();
			}
			else
			{
				MostraMenuPrincipal();
			}
		}

		#endregion // BUTTONS --- END

		#region BUTTONS PROCURA

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _despesa.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (_despesa.IDSituacao != 1 && _despesa.IDSetor != frm.propEscolha.IDSetor)
						_despesa.IDSituacao = 1;

					_despesa.IDSetor = (int)frm.propEscolha.IDSetor;
					txtSetor.Text = frm.propEscolha.Setor;
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

		#endregion // BUTTONS PROCURA --- END

		#region CONTROL FUNCTIONS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtSetor,
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (_despesa.IDSituacao != 1)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.Alt) // permite O 'ALT'
			{
				e.Handled = false;
			}
			else // finaly block all inserts changes
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtSetor,
				 };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void text_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= text_Enter;
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region TOOLTIP

		private void ShowToolTip(Control controle)
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

			if (controle.Tag == null)
			{
				toolTip1.Show("Clique aqui...", controle, controle.Width - 30, -40, 2000);
			}
			else
			{
				toolTip1.Show(controle.Tag.ToString(), controle, controle.Width - 30, -40, 2000);
			}
		}

		#endregion

		#region MENU A PAGAR

		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			// check button
			if (e.Button != MouseButtons.Right) return;

			Control c = (Control)sender;
			DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
			dgvListagem.ClearSelection();

			if (hit.Type == DataGridViewHitTestType.Cell)
			{
				// seleciona o ROW
				dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dgvListagem.CurrentCell = dgvListagem.Rows[hit.RowIndex].Cells[2];
				dgvListagem.Rows[hit.RowIndex].Selected = true;

				// mostra o MENU ativar e desativar
				objAPagar desp = (objAPagar)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

				// mnuImagem
				bool IsThereImagem = desp.Imagem != null && !string.IsNullOrEmpty(desp.Imagem.ImagemFileName);

				mnuImagemRemover.Enabled = IsThereImagem;
				mnuImagemInserir.Text = IsThereImagem ? "Alterar Imagem" : "Inserir Imagem";
				mnuImagemVisualizar.Enabled = IsThereImagem;

				mnuImagemAPagar.Enabled = true;

				if (_despesa.IDSituacao == 1)
				{
					mnuExcluirAPagar.Enabled = true;
					mnuAdicionarAPagar.Enabled = true;
				}
				else
				{
					mnuExcluirAPagar.Enabled = false;
					mnuAdicionarAPagar.Enabled = false;
				}
			}
			else
			{
				mnuExcluirAPagar.Enabled = false;
				mnuImagemAPagar.Enabled = false;
				if (_despesa.IDSituacao != 1) mnuAdicionarAPagar.Enabled = false;
			}

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		// INSERT IMAGE
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

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível inserir imagem de uma Parcela de APagar num Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de Inserir a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

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

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível visualizar imagem de uma Parcela de APagar numa Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de Visualizar a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

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

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível REMOVER imagem de uma Parcela de APagar numa Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de REMOVER a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			DialogResult resp;

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da despesa selecionada?" +
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

		// ADICIONAR APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuAdicionarAPagar_Click(object sender, EventArgs e)
		{
			btnIncluirItem_Click(sender, e);
		}

		// EXCLUIR APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuRemoverAPagar_Click(object sender, EventArgs e)
		{
			btnRemoverItem_Click(sender, e);
		}

		#endregion // MENU A PAGAR --- END

		#region CONCLUIR REGISTRO

		private void btnConcluir_Click(object sender, EventArgs e)
		{
			if (!VerificaRegistro()) return;

			//--- ask user
			var resp = AbrirDialog("Deseja concluir a Fatura atual desse cartão de Crédito?" +
				$"\nValor da Fatura: {_despesa.DespesaValor:C}" +
				$"\nVencimento: {_despesa.ReferenciaData:d}",
				"Concluir Fatura", DialogType.SIM_NAO, DialogIcon.Question);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- execute
				despBLL.ConcluirDespesaCartao(_despesa);
				_despesa.IDSituacao = 2;
				_despesa.Situacao = "Concluída";
				SituacaoAlterada();

				//--- user message
				AbrirDialog("Despesa de Cartão concuída com sucesso..." +
					"\nA Fatura do cartão foi inserida no APagar.", "Despesa Concluida");

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Concluir a Fatura do Cartão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CHECK REGISTRES
		private bool VerificaRegistro()
		{
			// CHECK FIELDS
			if (!VerificaDadosClasse(txtSetor, "Setor Debitado", _despesa)) return false;

			// CHECK DESPESA VALUE
			_despesa.DespesaValor = listAPagarVinculado.Sum(x => x.APagarValor);

			if (_despesa.DespesaValor <= 0)
			{
				AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
					"Favor inserir itens nessa Despesa.", "Valor da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				lblDespesaValor.Focus();
				return false;
			}

			return true;
		}


		#endregion // SALVAR REGISTRO --- END

		#region IMAGE CONTROL
		private void btnInserirImagem_Click(object sender, EventArgs e)
		{
			if (_despesa.IDDespesa == null)
			{
				AbrirDialog("É necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)_despesa.IDDespesa,
					Origem = EnumImagemOrigem.Despesa,
					ImagemFileName = _despesa.Imagem == null ? string.Empty : _despesa.Imagem.ImagemFileName,
					ImagemPath = _despesa.Imagem == null ? string.Empty : _despesa.Imagem.ImagemPath,
					ReferenceDate = _despesa.DespesaData,
				};

				// open form to edit or save image
				bool IsNew = _despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (_despesa.Imagem != null && imagem != null)
				{
					IsUpdated = (_despesa.Imagem.ImagemFileName != imagem.ImagemFileName) || (_despesa.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				_despesa.Imagem = imagem;

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
			if (_despesa.IDDespesa == null)
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa..." +
					"\nÉ necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				var resp = AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa..." +
					"\nDeseja INSERIR uma nova imagem à despesa?",
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
				ImagemUtil.ImagemVisualizar(_despesa.Imagem);
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
			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
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

			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa para que seja removida...",
					"Não há Imagem", DialogType.OK, DialogIcon.Warning);
				return;
			}

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da despesa atual?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				_despesa.Imagem = ImagemUtil.ImagemRemover(_despesa.Imagem);

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

		private void btnIncluirItem_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- create list not inserted
				var newList = listAPagarEmAberto.Except(listAPagarVinculado).ToList();

				var frm = new frmDespesaCartaoProcurar(newList, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				//--- update DB
				despBLL.VincularAPagarItem((long)frm.SelectedItem.IDAPagar, (long)_despesa.IDDespesa);

				//--- update list
				listAPagarVinculado.Add(frm.SelectedItem);
				bindAPagar.ResetBindings(false);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir Formulário de Procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private void CalculaTotais()
		{
			decimal Total = listAPagarVinculado.Sum(x => x.APagarValor);

			lblDespesaValor.Text = $"{Total:C}";
		}

		private void btnRemoverItem_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para REMOVER...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Update DB
				despBLL.RemoverVinculoAPagarItem((long)item.IDAPagar);

				//--- Remove to list
				bindAPagar.Remove(item);
				bindAPagar.ResetBindings(false);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir registro de APagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EXCLUIR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnExcluirDespesa_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// --- ask USER
				var resp = AbrirDialog("Você deseja realmente EXCLUIR definitivamente a Despesa abaixo?\n" +
					$"\nREG: {_despesa.IDDespesa:D4}\nDATA: {_despesa.DespesaData.ToShortDateString()}\nVALOR: {_despesa.DespesaValor:c}",
					"Excluir Despesa", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				//--- EXECUTE DELETE
				despBLL.DeleteDespesaCartao(_despesa);

				//--- user message
				AbrirDialog("Despesa/Fatura Excluída com Sucesso!", "Despesa Excluída");

				//--- CLOSE
				Close();
				MostraMenuPrincipal();
			}
			catch (AppException ex)
			{
				AbrirDialog("A Despesa está protegida de exclusão porque:\n" +
							ex.Message, "Bloqueio de Exclusão", DialogType.OK, DialogIcon.Exclamation);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir Despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}
	}
}
