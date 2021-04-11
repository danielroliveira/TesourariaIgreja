using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.DespesaCartao
{
	public partial class frmDespesaCartaoListagem : CamadaUI.Modals.frmModFinBorder
	{
		DespesaCartaoBLL dBLL = new DespesaCartaoBLL();
		private List<objDespesaCartao> listCont = new List<objDespesaCartao>();
		private List<objAPagarCartao> ListCartao;
		private Form _formOrigem;
		private DateTime _myAno;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Ano | 2: Por Datas | 3: Todos
		private int? IDCartaoSelected;
		public objDespesaCartao propEscolha = null;


		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaCartaoListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter dados e preenche a listagem
			ObterDadosCartao();
			ObterDados();
			FormataListagem();

			//--- get dados
			dgvListagem.CellDoubleClick += btnVisualizar_Click;

			//--- Handlers
			HandlerKeyDownControl(this);
			rbtPorAno.CheckedChanged += rbt_CheckedChanged;
			rbtPorPeriodo.CheckedChanged += rbt_CheckedChanged;
			rbtTodas.CheckedChanged += rbt_CheckedChanged;
		}

		// CONTROLA O MES
		//------------------------------------------------------------------------------------------------------------
		public DateTime propMes
		{
			get
			{
				return _myAno;
			}
			set
			{
				_myAno = value;

				// define data inicial e data final
				_dtInicial = new DateTime(_myAno.Year, 1, 1);
				_dtFinal = new DateTime(_myAno.Year, 12, 31);

				lblPeriodo.Text = _myAno.ToString("yyyy");
				lblDtInicial.Text = _dtInicial.ToString("dd/MM");
				lblDtFinal.Text = _dtFinal.ToString("dd/MM");

				// habilita, desabilita btnPeriodoPosterior caso mes futuro
				btnPeriodoPosterior.Enabled = !(_myAno.Year >= DateTime.Today.Year && _myAno.Month >= DateTime.Today.Month);
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

				//--- Define DataInicial and DataFinal
				DateTime? Inicial = null;
				DateTime? Final = null;

				if (_ProcuraTipo == 1) // por ANO
				{
					Inicial = new DateTime(_dtInicial.Year, 1, 1);
					Final = new DateTime(_dtInicial.Year, 12, 31);
				}
				else if (_ProcuraTipo == 2) // por PERIODO
				{
					Inicial = _dtInicial;
					Final = _dtFinal;
				}
				else // por TODOS
				{
					Inicial = null;
					Final = null;
				}

				// define list
				listCont = dBLL.GetListDespesaCartao(IDCartaoSelected, Inicial, Final);

				dgvListagem.DataSource = listCont;
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

		// LISTAGEM DE CARTOS DE CREDITO
		//------------------------------------------------------------------------------------------------------------
		private void ObterDadosCartao()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				ListCartao = new APagarCartaoBLL().GetCartaoCreditoDespesaList();

				if (ListCartao.Count == 0)
				{
					AbrirDialog("Não há Cartões de Crédito Cadastrados para realização de Despesas...\n" +
						"Favor Comunicar com o adminstrador do sistema.", "Não há Cartões",
						DialogType.OK, DialogIcon.Exclamation);
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter Lista de Cartõe de Crédito..." + "\n" +
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
			decimal vlTotal = listCont.Sum(x => x.DespesaValor);
			lblValorTotal.Text = vlTotal.ToString("C");
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

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDDespesa";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA DATA
			clnData.DataPropertyName = "DespesaData";
			clnData.Visible = true;
			clnData.ReadOnly = true;
			clnData.Resizable = DataGridViewTriState.False;
			clnData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (4) COLUNA CREDOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (5) COLUNA DOCUMENTO TIPO
			clnDespesaDescricao.DataPropertyName = "DespesaDescricao";
			clnDespesaDescricao.Visible = true;
			clnDespesaDescricao.ReadOnly = true;
			clnDespesaDescricao.Resizable = DataGridViewTriState.False;
			clnDespesaDescricao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDespesaDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDespesaDescricao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (6) COLUNA SITUACAO
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- (7) COLUNA VALOR
			clnValor.DataPropertyName = "DespesaValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Format = "C";

			//--- Add Columns
			dgvListagem.Columns.AddRange(
				clnID,
				clnData,
				clnSetor,
				clnDespesaDescricao,
				clnCredor,
				clnSituacao,
				clnValor);
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

		#endregion

		#region BUTTONS FUNCTION

		// FECHAR FORMULARIO
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			if (_formOrigem == null || (_formOrigem != null && _formOrigem.Name != "frmProvisorio"))
			{
				MostraMenuPrincipal();
			}
		}

		// ADICIONAR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			var frm = new frmDespesaCartaoInserir(null);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// EDITAR DESPESA ESCOLHIDA
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
			objDespesaCartao item = (objDespesaCartao)dgvListagem.SelectedRows[0].DataBoundItem;

			var frm = new frmDespesaCartao(item, this);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// EXCLUIR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnExcluir_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Ainda não implemetado...");

			/*
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Excluir...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objDespesaCartao item = (objDespesaCartao)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// --- ask USER
				var resp = AbrirDialog("Você deseja realmente EXCLUIR definitivamente a Despesa abaixo?\n" +
					$"\nREG: {item.IDDespesa:D4}\nDATA: {item.DespesaData.ToShortDateString()}\nVALOR: {item.DespesaValor:c}",
					"Excluir Despesa", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				//--- EXECUTE DELETE
				//dBLL.DeleteDespesaComum(item);

				//--- REQUERY LIST
				ObterDados();

				AbrirDialog("Despesa Excluída com Sucesso!", "Despesa Excluída");
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
			*/
		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetCartao_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (ListCartao.Count == 0)
				{
					AbrirDialog("Não há Cartão de Crédito cadastrados ou ativos...", "Cartão de Crédito",
						DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				var dic = ListCartao.ToDictionary(x => (int)x.IDCartaoCredito, x => x.CartaoDescricao);
				var textBox = txtCartaoDescricao;
				Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, IDCartaoSelected);

				// show form
				frm.ShowDialog();

				//--- check return
				if ((frm.DialogResult == DialogResult.OK) && (frm.propEscolha.Key != IDCartaoSelected))
				{
					IDCartaoSelected = frm.propEscolha.Key;
					txtCartaoDescricao.Text = frm.propEscolha.Value;
					ObterDados();
				}

				//--- select
				textBox.Focus();
				textBox.SelectAll();

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

		private void btnImprimirListagem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Não foi implementado");
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
					case "txtCartaoDescricao":
						btnSetCartao_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = { txtCartaoDescricao };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;

				if (ctr.Name == "txtCartaoDescricao")
				{
					if (IDCartaoSelected != null)
					{
						IDCartaoSelected = null;
						txtCartaoDescricao.Clear();
						ObterDados(); ;
					}
				}
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = { txtCartaoDescricao, };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// CREATE SHORTCUT TO TEXTBOX LIST VALUES
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar))
			{
				Control ctr = (Control)sender;
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCartaoDescricao":

						if (ListCartao.Count > 0)
						{
							var cartao = ListCartao.FirstOrDefault(x => x.IDCartaoCredito == int.Parse(e.KeyChar.ToString()));

							if (cartao == null) return;

							if (cartao.IDCartaoCredito != IDCartaoSelected)
							{
								IDCartaoSelected = cartao.IDCartaoCredito;
								txtCartaoDescricao.Text = cartao.CartaoDescricao;
								ObterDados();
							}
						}

						break;

					default:
						break;
				}
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region DATE MONTH CONTROLER

		private void btnPeriodoAnterior_Click(object sender, EventArgs e)
		{
			propMes = propMes.AddYears(-1);
			ObterDados();
		}

		private void btnPeriodoPosterior_Click(object sender, EventArgs e)
		{
			propMes = propMes.AddYears(1);
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
			else if (rbtPorAno.Checked == true) // POR MES
			{
				pnlPorMes.Visible = true;
				pnlPorPeriodo.Visible = false;
				_myAno = _dtInicial;
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

			// check Escolha
			if (_formOrigem != null && _formOrigem.Name == "frmProvisorio") return;

			Control c = (Control)sender;
			DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
			dgvListagem.ClearSelection();

			if (hit.Type != DataGridViewHitTestType.Cell) return;

			// seleciona o ROW
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListagem.CurrentCell = dgvListagem.Rows[hit.RowIndex].Cells[2];
			dgvListagem.Rows[hit.RowIndex].Selected = true;

			// mostra o MENU ativar e desativar
			objDespesaCartao desp = (objDespesaCartao)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// mnuImagem
			bool IsThereImagem = desp.Imagem != null && !string.IsNullOrEmpty(desp.Imagem.ImagemFileName);

			mnuImagemRemover.Enabled = IsThereImagem;
			mnuImagemInserir.Text = IsThereImagem ? "Alterar Imagem" : "Inserir Imagem";
			mnuImagemVisualizar.Enabled = IsThereImagem;

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		private void mnuVisualizar_Click(object sender, EventArgs e)
		{
			btnVisualizar_Click(sender, e);
		}

		private void mnuExcluir_Click(object sender, EventArgs e)
		{
			btnExcluir_Click(sender, e);
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
			objDespesaCartao item = (objDespesaCartao)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)item.IDDespesa,
					Origem = EnumImagemOrigem.Despesa,
					ImagemFileName = item.Imagem == null ? string.Empty : item.Imagem.ImagemFileName,
					ImagemPath = item.Imagem == null ? string.Empty : item.Imagem.ImagemPath,
					ReferenceDate = item.DespesaData,
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
			objDespesaCartao item = (objDespesaCartao)dgvListagem.SelectedRows[0].DataBoundItem;

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
			objDespesaCartao item = (objDespesaCartao)dgvListagem.SelectedRows[0].DataBoundItem;

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

		#endregion // MENU SUSPENSO --- END

	}
}
