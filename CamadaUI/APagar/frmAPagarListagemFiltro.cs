using CamadaBLL;
using CamadaDTO;
using CamadaUI.Registres;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarListagemFiltro : CamadaUI.Modals.frmModFinBorder
	{
		private bool _Alterado = false;
		private frmAPagarListagem _formOrigem;
		private List<objCobrancaForma> listFormas;

		private frmAPagarListagem.StructPesquisa DadosNovos = new frmAPagarListagem.StructPesquisa();

		#region SUB NEW | CONSTRUCTOR

		public frmAPagarListagemFiltro(frmAPagarListagem formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			DadosNovos = _formOrigem.Dados;
			GetFormasList();

			// LOAD VALUES
			txtCobrancaForma.Text = DadosNovos.Forma;
			txtCredor.Text = DadosNovos.Credor;

			// ADD HANDLERS
			txtCobrancaForma.KeyDown += Control_KeyDown;
			txtCredor.KeyDown += Control_KeyDown;

			txtCobrancaForma.Enter += Control_Enter;
			txtCredor.Enter += Control_Enter;

			HandlerKeyDownControl(this);
		}

		public bool propAlterado
		{
			get => _Alterado;
			set
			{
				if (value != _Alterado)
				{
					ShowToolTip(btnProcurar);
				}

				_Alterado = value;
				btnProcurar.Enabled = value;
			}
		}

		// GET LIST OF FORMAS DE COBRANCA
		//------------------------------------------------------------------------------------------------------------
		private void GetFormasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listFormas = new CobrancaFormaBLL().GetListCobrancaForma(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Formas de Cobrança..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{

			txtCobrancaForma.Clear();
			DadosNovos.IDForma = null;
			DadosNovos.Forma = null;

			txtCredor.Clear();
			DadosNovos.IDCredor = null;
			DadosNovos.Credor = null;

			propAlterado = true;
		}

		// PROCURAR
		//------------------------------------------------------------------------------------------------------------
		private void btnProcurar_Click(object sender, EventArgs e)
		{
			_formOrigem.Dados = DadosNovos;
			DialogResult = DialogResult.Yes;
		}

		#endregion // BUTTONS FUNCTION --- END

		#region BUTTONS PROCURA

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetCredor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmCredorListagem frm = new frmCredorListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					if (DadosNovos.IDCredor != (int)frm.propEscolha.IDCredor) propAlterado = true;

					DadosNovos.IDCredor = (int)frm.propEscolha.IDCredor;
					DadosNovos.Credor = frm.propEscolha.Credor;
					txtCredor.Text = frm.propEscolha.Credor;
				}

				//--- select
				txtCredor.Focus();
				txtCredor.SelectAll();
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

		private void btnSetForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...", "Formas de Cobrança",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDCobrancaForma, x => x.CobrancaForma);
			var textBox = txtCobrancaForma;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, DadosNovos.IDForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				DadosNovos.IDForma = (int)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
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
					txtCobrancaForma,
					txtCredor
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCredor":
						btnSetCredor_Click(sender, new EventArgs());
						break;
					case "txtCobrancaForma":
						btnSetForma_Click(sender, new EventArgs());
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
					case "txtCredor":
						DadosNovos.IDCredor = null;
						DadosNovos.Credor = string.Empty;
						txtCredor.Clear();
						break;
					case "txtCobrancaForma":
						DadosNovos.IDForma = null;
						DadosNovos.Forma = string.Empty;
						txtCobrancaForma.Clear();
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
				Control[] controlesBloqueados = {
					txtCredor, txtCobrancaForma
				};

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region TOOLTIP

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void Control_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= Control_Enter;
		}

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
