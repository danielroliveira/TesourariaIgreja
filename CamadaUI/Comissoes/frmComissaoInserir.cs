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
	public partial class frmComissaoInserir : Modals.frmModFinBorder
	{
		private objCredor Colaborador;
		private List<objContribuicao> list;
		private Form _formOrigem;
		private ComissaoBLL cBLL = new ComissaoBLL();
		private DateTime? _MaxDate = null;
		private DateTime _DataFinal;
		private DateTime? _MinDate = null;

		#region SUB NEW | CONSTRUCTOR

		public frmComissaoInserir(Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;

			dtpDataFinal.MaxDate = DateTime.Today;
			dtpDataFinal.MinDate = DateTime.Today;

			// HANDLER to use TAB for ENTER
			HandlerKeyDownControl(this);
			dtpDataFinal.ValueChanged += (a, b) => DefineDataFinal();
		}

		private void ObterDados()
		{
			if (Colaborador == null || Colaborador.IDSetor == null) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Get CONTRIBUICAO LIST
				list = cBLL.GetContribuicaoComissaoList((int)Colaborador.IDSetor);

				if (list == null || list.Count == 0)
				{
					AbrirDialog("Não há contribuições disponíveis para comissão" +
						$" para o colaborador escolhido: \n{Colaborador.Credor}",
						"Não há registros", DialogType.OK, DialogIcon.Exclamation);
				}

				PreecheCampos();
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

		// PREENCHE OS CAMPOS DEPOIS DA DATA ESCOLHIDA
		//------------------------------------------------------------------------------------------------------------
		private void PreecheCampos()
		{
			if (Colaborador == null || Colaborador.IDSetor == null) return;

			lblSetor.Text = Colaborador.Setor;

			if (list == null || list.Count == 0)
			{
				_MaxDate = null;
				_MinDate = null;

				lblDataInicial.Text = "00/00/0000";
				dtpDataFinal.Enabled = false;
				dtpDataFinal.MaxDate = DateTime.Today;
				dtpDataFinal.MinDate = DateTime.Today;
				lblMaxDate.Text = "Data máx.: INDEFINIDA";
				btnEfetuar.Enabled = false;

			}
			else
			{
				_MaxDate = list.Max(x => x.ContribuicaoData);
				_MinDate = list.Min(x => x.ContribuicaoData);

				// define Min and Max Date to CONTROL
				dtpDataFinal.Enabled = true;
				dtpDataFinal.MinDate = (DateTime)_MinDate;
				dtpDataFinal.Value = (DateTime)_MaxDate;
				dtpDataFinal.MaxDate = (DateTime)_MaxDate;

				lblDataInicial.Text = _MinDate.ToString();
				lblMaxDate.Text = "Data máx.: " + ((DateTime)_MaxDate).ToShortDateString();
				btnEfetuar.Enabled = true;

			}

			DefineDataFinal();

		}

		// DEFINE A DATA FINAL
		//------------------------------------------------------------------------------------------------------------
		private void DefineDataFinal()
		{
			if (_DataFinal == dtpDataFinal.Value) return;

			if (_MaxDate != null)
			{
				_DataFinal = dtpDataFinal.Value;
				decimal soma = list.Where(x => x.ContribuicaoData <= _DataFinal).Sum(x => x.ValorRecebido);
				int count = list.Where(x => x.ContribuicaoData <= _DataFinal).Count();
				lblSomaTotal.Text = soma.ToString("c");
				lblQuantidade.Text = count.ToString("D2") + " registros";
			}
			else
			{
				lblSomaTotal.Text = 0.ToString("c");
				lblQuantidade.Text = "nenhum registro";
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTON FUNCTIONS

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
				if (frm.DialogResult == DialogResult.OK)
				{
					Colaborador = frm.propEscolha;
					txtColaborador.Text = frm.propEscolha.Credor;
					lblTaxa.Text = Colaborador.ComissaoTaxa == null ? string.Empty : Colaborador.ComissaoTaxa.ToString() + "%";
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

		#endregion // BUTTON FUNCTIONS --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		private void btnEfetuar_Click(object sender, EventArgs e)
		{
			var resp = AbrirDialog("Tem certeza que deseja inicializar um registro de cálculo de comissão para: " +
				$"\n{Colaborador.Credor}" +
				$"\nSETOR: {Colaborador.Setor}",
				"Inicializar Registro de Comissão",
				DialogType.SIM_NAO,
				DialogIcon.Question);

			if (resp != DialogResult.Yes) return;

			List<objContribuicao> listFinal = list.Where(x => x.ContribuicaoData <= _DataFinal).ToList();
			decimal soma = listFinal.Sum(x => x.ValorRecebido);
			decimal vlComissao = soma * (decimal)Colaborador.ComissaoTaxa / 100;

			var Comissao = new objComissao(null)
			{
				ComissaoTaxa = (decimal)Colaborador.ComissaoTaxa,
				IDCredor = (int)Colaborador.IDCredor,
				Credor = Colaborador.Credor,
				DataFinal = _DataFinal,
				DataInicial = (DateTime)_MinDate,
				IDDespesa = null,
				IDSetor = (int)Colaborador.IDSetor,
				Setor = Colaborador.Setor,
				IDSituacao = 1,
				ValorContribuicoes = soma,
				ValorDescontado = 0,
				ValorComissao = vlComissao,
			};

			//--- INSERT NEW COMISSAO
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Comissao.IDComissao = cBLL.InsertComissao(Comissao, listFinal);

				//--- open form
				var frm = new frmComissao(Comissao, listFinal, this);
				frm.Show();

				Close();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Inserir um novo registro de Comissão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS FUNCTION --- END

		#region CONTROLS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtColaborador,
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
				Control[] controlesBloqueados = { txtColaborador, };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		#endregion // CONTROLS --- END

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






	}
}
