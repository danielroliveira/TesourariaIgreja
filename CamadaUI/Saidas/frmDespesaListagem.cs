using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmDespesaListagem : CamadaUI.Modals.frmModFinBorder
	{
		DespesaComumBLL dBLL = new DespesaComumBLL();
		private List<objDespesaComum> listCont = new List<objDespesaComum>();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos
		public objDespesaComum propEscolha = null;
		private bool _disableProcura = false;

		public struct StructPesquisa
		{
			public int? IDSetor;
			public string Setor;
			public int? IDCredor;
			public string Credor;
			public int? IDTipo;
			public string Tipo;
		}

		public StructPesquisa Dados;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaListagem(Form formOrigem = null)
		{
			InitializeComponent();

			Dados = new StructPesquisa();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

			if (_formOrigem != null && _formOrigem.Name == "frmProvisorio")
			{
				btnAdicionar.Text = "&Escolher";
				btnAdicionar.Image = Properties.Resources.accept_24;
				btnVisualizar.Enabled = false;
				btnExcluir.Enabled = false;
				btnImprimirListagem.Enabled = false;
				lblTitulo.Text = "Escolher Despesa";
			}

			// define a data inicial
			propMes = DateTime.Parse(ObterDefault("DataPadrao"));

			// obter dados e preenche a listagem
			ObterDados();
			FormataListagem();

			//--- get dados
			dgvListagem.CellDoubleClick += btnVisualizar_Click;

			DefineLabelFiltro();

			//--- Handlers
			HandlerKeyDownControl(this);
			rbtPorMes.CheckedChanged += rbt_CheckedChanged;
			rbtPorPeriodo.CheckedChanged += rbt_CheckedChanged;
			rbtTodas.CheckedChanged += rbt_CheckedChanged;
			txtProcura.TextChanged += FiltrarListagem;

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

				// define list
				listCont = dBLL.GetListDespesa(
					Dados.IDSetor,
					Dados.IDTipo,
					Dados.IDCredor,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null);

				dgvListagem.DataSource = listCont;
				CalculaTotais();

				// disable procura text => Filtar Listagem
				_disableProcura = true;
				txtProcura.Clear();
				_disableProcura = false;
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
			decimal vlTotal = listCont.Sum(x => x.DespesaValor);
			lblValorTotal.Text = vlTotal.ToString("C");
		}

		// DEFINE O LABEL FILTRO
		//------------------------------------------------------------------------------------------------------------
		private void DefineLabelFiltro()
		{
			StringBuilder builder = new StringBuilder();

			if (Dados.IDSetor != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "SETOR: " + Dados.Setor);
			}

			if (Dados.IDTipo != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "TIPO: " + Dados.Tipo);
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

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDDespesa";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA DATA
			clnData.DataPropertyName = "DespesaData";
			clnData.Visible = true;
			clnData.ReadOnly = true;
			clnData.Resizable = DataGridViewTriState.False;
			clnData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnData.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.DefaultCellStyle.Font = clnFont;

			//--- (4) COLUNA TIPO
			clnTipo.DataPropertyName = "DespesaTipo";
			clnTipo.Visible = true;
			clnTipo.ReadOnly = true;
			clnTipo.Resizable = DataGridViewTriState.False;
			clnTipo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.DefaultCellStyle.Font = clnFont;

			//--- (5) COLUNA CREDOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;

			//--- (6) COLUNA DOCUMENTO TIPO
			clnDespesaDescricao.DataPropertyName = "DespesaDescricao";
			clnDespesaDescricao.Visible = true;
			clnDespesaDescricao.ReadOnly = true;
			clnDespesaDescricao.Resizable = DataGridViewTriState.False;
			clnDespesaDescricao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDespesaDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDespesaDescricao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDespesaDescricao.DefaultCellStyle.Font = clnFont;

			//--- (7) COLUNA PARCELAS
			clnParcelas.DataPropertyName = "Parcelas";
			clnParcelas.Visible = true;
			clnParcelas.ReadOnly = true;
			clnParcelas.Resizable = DataGridViewTriState.False;
			clnParcelas.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnParcelas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnParcelas.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnParcelas.DefaultCellStyle.Font = clnFont;

			//--- (8) COLUNA SITUACAO
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.DefaultCellStyle.Font = clnFont;

			//--- (9) COLUNA VALOR
			clnValor.DataPropertyName = "DespesaValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(
				clnID,
				clnData,
				clnSetor,
				clnTipo,
				clnDespesaDescricao,
				clnCredor,
				clnParcelas,
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

		// CONTROLA AS CORES DA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnParcelas.Index)
			{
				if ((byte)e.Value == 1)
				{
					e.Value = "única";
					e.CellStyle.ForeColor = Color.Black;
				}
				else
				{
					e.Value = $"{e.Value:D2} Parcelas";
					e.CellStyle.ForeColor = Color.Red;
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
			if (_formOrigem == null || (_formOrigem != null && _formOrigem.Name != "frmProvisorio"))
			{
				MostraMenuPrincipal();
			}
		}

		// ADICIONAR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			if (_formOrigem == null || (_formOrigem != null && _formOrigem.Name != "frmProvisorio"))
			{
				Adicionar();
			}
			else
			{
				Escolher();
			}
		}

		private void Adicionar()
		{
			frmDespesa frm = new frmDespesa(new objDespesaComum(null));
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		private void Escolher()
		{
			//--- get Selected item
			propEscolha = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;
			DialogResult = DialogResult.OK;
		}

		// EDITAR DESPESA ESCOLHIDA
		//------------------------------------------------------------------------------------------------------------
		private void btnVisualizar_Click(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.Name == "frmProvisorio")
			{
				Escolher();
			}
			else
			{
				//--- check selected item
				if (dgvListagem.SelectedRows.Count == 0)
				{
					AbrirDialog("Favor selecionar um registro para Editar...",
						"Selecionar Registro", DialogType.OK, DialogIcon.Information);
					return;
				}

				//--- get Selected item
				objDespesaComum item = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;

				frmDespesa frm = new frmDespesa(item, this);
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				DesativaMenuPrincipal();
				Close();
				frm.Show();
			}
		}

		// PROCURAR
		//------------------------------------------------------------------------------------------------------------
		private void btnProcurar_Click(object sender, EventArgs e)
		{
			var frm = new frmDespesaListagemFiltro(this);
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.Yes)
			{
				ObterDados();
				DefineLabelFiltro();
			}
		}

		// EXCLUIR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnExcluir_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Excluir...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objDespesaComum item = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;

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
				dBLL.DeleteDespesaComum(item);

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
			objDespesaComum desp = (objDespesaComum)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

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

		// VERIFICA A SITUACAO DA DESPESA BY SITUACAO APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuVerificaSituacao_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Verificar a Situação...",
					"Selecionar Registro",
					DialogType.OK,
					DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objDespesaComum item = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var result = dBLL.CheckSituacaoDespesa(item);

				if (result)
				{
					ObterDados();
					AbrirDialog("Situação da Despesa foi verificada." +
						"\nA Situação da Despesa foi corrigida.", "Situação Corrigida");
				}
				else
				{
					AbrirDialog("Situação da Despesa verificada..." +
						"\nNão foi encontrado nenhum erro.", "Situação Verificada");
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Verificar a situação da despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
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
			objDespesaComum item = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;

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
			objDespesaComum item = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;

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
			objDespesaComum item = (objDespesaComum)dgvListagem.SelectedRows[0].DataBoundItem;

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

		#region FILTRAGEM PROCURA

		private void FiltrarListagem(object sender, EventArgs e)
		{
			// if obterDados exit
			if (_disableProcura) return;

			if (txtProcura.TextLength > 0)
			{
				// filter
				if (!int.TryParse(txtProcura.Text, out int i))
				{
					// declare function
					Func<objDespesa, bool> FiltroItem = c => c.DespesaDescricao.ToLower().Contains(txtProcura.Text.ToLower());

					// aply filter using function
					dgvListagem.DataSource = listCont.FindAll(c => FiltroItem(c));
				}
				else
				{
					// declare function
					Func<objDespesa, bool> FiltroID = c => c.IDDespesa == i;

					// aply filter using function
					dgvListagem.DataSource = listCont.FindAll(c => FiltroID(c));
				}
			}
			else
			{
				dgvListagem.DataSource = listCont;
			}
		}

		#endregion // FILTRAGEM PROCURA --- END
	}
}
