using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmContribuicaoListagem : CamadaUI.Modals.frmModFinBorder
	{
		ContribuicaoBLL cBLL = new ContribuicaoBLL();
		private List<objContribuicao> listCont = new List<objContribuicao>();
		private Form _formOrigem;
		private DateTime _myMes;
		private DateTime _dtInicial;
		private DateTime _dtFinal;
		private byte _ProcuraTipo = 1; // 1: Por Mes | 2: Por Datas | 3: Todos

		public struct StructPesquisa
		{
			public int? IDConta;
			public string Conta;
			public int? IDSetor;
			public string Setor;
			public byte? IDTipo;
			public string Tipo;
			public byte? IDForma;
			public string Forma;
			public int? IDContribuinte;
			public string Contribuinte;
			public int? IDCampanha;
			public string Campanha;
		}

		public StructPesquisa Dados;

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmContribuicaoListagem(Form formOrigem = null)
		{
			InitializeComponent();

			Dados = new StructPesquisa();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

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

				listCont = cBLL.GetListContribuicao(
					Dados.IDConta,
					Dados.IDSetor,
					Dados.IDForma,
					Dados.IDTipo,
					Dados.IDContribuinte,
					Dados.IDCampanha,
					_ProcuraTipo != 3 ? (DateTime?)_dtInicial : null,
					_ProcuraTipo != 3 ? (DateTime?)_dtFinal : null);
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

		//--- CALCULA OS TOTAIS E ALTERA AS LABELS
		//----------------------------------------------------------------------------------
		private void CalculaTotais()
		{
			decimal vlTotal = listCont.Sum(x => x.ValorBruto);
			lblValorTotal.Text = vlTotal.ToString("C");

			decimal vlRecebido = listCont.Sum(x => x.ValorRecebido);
			lblValorRecebido.Text = vlRecebido.ToString("C");
		}

		// DEFINE O LABEL FILTRO
		//------------------------------------------------------------------------------------------------------------
		private void DefineLabelFiltro()
		{
			StringBuilder builder = new StringBuilder();

			if (Dados.IDConta != null)
			{
				builder.Append("CONTA: " + Dados.Conta);
			}

			if (Dados.IDSetor != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "SETOR: " + Dados.Setor);
			}

			if (Dados.IDTipo != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "TIPO: " + Dados.Tipo);
			}

			if (Dados.IDForma != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "FORMA: " + Dados.Forma);
			}

			if (Dados.IDContribuinte != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "CONTRIBUINTE: " + Dados.Contribuinte);
			}

			if (Dados.IDCampanha != null)
			{
				builder.Append((builder.Length > 0 ? " | " : "") + "CAMPANHA: " + Dados.Campanha);
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

			//--- (4) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.DefaultCellStyle.Font = clnFont;

			//--- (5) COLUNA TIPO
			clnTipo.DataPropertyName = "ContribuicaoTipo";
			clnTipo.Visible = true;
			clnTipo.ReadOnly = true;
			clnTipo.Resizable = DataGridViewTriState.False;
			clnTipo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnTipo.DefaultCellStyle.Font = clnFont;

			//--- (6) COLUNA CONTRIBUINTE
			clnContribuinte.DataPropertyName = "Contribuinte";
			clnContribuinte.Visible = true;
			clnContribuinte.ReadOnly = true;
			clnContribuinte.Resizable = DataGridViewTriState.False;
			clnContribuinte.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnContribuinte.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnContribuinte.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnContribuinte.DefaultCellStyle.Font = clnFont;

			//--- (7) COLUNA FORMA
			clnForma.DataPropertyName = "EntradaForma";
			clnForma.Visible = true;
			clnForma.ReadOnly = true;
			clnForma.Resizable = DataGridViewTriState.False;
			clnForma.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnForma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnForma.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnForma.DefaultCellStyle.Font = clnFont;

			//--- (8) COLUNA VALOR
			clnValor.DataPropertyName = "ValorBruto";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Font = clnFont;

			//--- (9) COLUNA VALOR RECEBIDO
			clnValorRecebido.DataPropertyName = "ValorRecebido";
			clnValorRecebido.Visible = true;
			clnValorRecebido.ReadOnly = true;
			clnValorRecebido.Resizable = DataGridViewTriState.False;
			clnValorRecebido.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValorRecebido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorRecebido.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValorRecebido.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(
				clnID,
				clnData,
				clnConta,
				clnSetor,
				clnTipo,
				clnContribuinte,
				clnForma,
				clnValor,
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
			frmContribuicao frm = new frmContribuicao(new objContribuicao(null));
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// EDITAR CONTA ESCOLHIDA
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
			objContribuicao item = (objContribuicao)dgvListagem.SelectedRows[0].DataBoundItem;

			frmContribuicao frm = new frmContribuicao(item);
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
			DesativaMenuPrincipal();
			Close();
			frm.Show();
		}

		// PROCURAR
		//------------------------------------------------------------------------------------------------------------
		private void btnProcurar_Click(object sender, EventArgs e)
		{
			var frm = new frmContribuicaoListagemFiltro(this);
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.Yes)
			{
				ObterDados();
				DefineLabelFiltro();
			}
		}

		// EXCLUIR CONTRIBUICAO
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
			objContribuicao item = (objContribuicao)dgvListagem.SelectedRows[0].DataBoundItem;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// --- ask USER
				var resp = AbrirDialog("Você deseja realmente EXCLUIR definitivamente a Contribuição abaixo?\n" +
					$"\nREG: {item.IDContribuicao:D4}\nDATA: {item.ContribuicaoData.ToShortDateString()}\nVALOR: {item.ValorBruto:c}",
					"Excluir Contribuição", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

				if (resp != DialogResult.Yes) return;

				//--- EXECUTE DELETE
				cBLL.DeleteContribuicao((long)item.IDContribuicao, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

				//--- REQUERY LIST
				ObterDados();

			}
			catch (AppException ex)
			{
				AbrirDialog("A contribuição está protegida de exclusão porque:\n" +
							ex.Message, "Bloqueio de Exclusão", DialogType.OK, DialogIcon.Exclamation);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir Contribuição..." + "\n" +
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

	}
}
