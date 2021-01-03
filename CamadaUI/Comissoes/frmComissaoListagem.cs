﻿using CamadaBLL;
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

		#region NEW | OPEN FUNCTIONS | PROPERTIES

		// SUN NEW | CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmComissaoListagem(Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			_formOrigem = formOrigem;

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
			//--- Get Situacao
			if (rbtIniciadas.Checked)
			{
				if (_situacao != 1)
				{
					_situacao = 1;
					ObterDados();
				}
			}
			else if (rbtConcluidas.Checked)
			{
				if (_situacao != 2)
				{
					_situacao = 2;
					ObterDados();
				}
			}
			else if (rbtPagas.Checked)
			{
				if (_situacao != 3)
				{
					_situacao = 3;
					ObterDados();
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
				var frm = new Main.frmReportGlobal("CamadaUI.Entradas.Reports.rptEntradasPorPeriodoList.rdlc",
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

		// EXCLUIR CONTRIBUICAO
		//------------------------------------------------------------------------------------------------------------
		private void btnExcluir_Click(object sender, EventArgs e)
		{
			/*
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Excluir...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objComissao item = (objComissao)dgvListagem.SelectedRows[0].DataBoundItem;

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
			*/
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



	}
}