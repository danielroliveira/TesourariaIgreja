using CamadaUI.Registres;
using CamadaUI.Setores;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmDespesaListagemFiltro : CamadaUI.Modals.frmModFinBorder
	{
		private bool _Alterado = false;
		private frmDespesaListagem _formOrigem;

		private frmDespesaListagem.StructPesquisa DadosNovos = new frmDespesaListagem.StructPesquisa();

		#region SUB NEW | CONSTRUCTOR

		public frmDespesaListagemFiltro(frmDespesaListagem formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			DadosNovos = _formOrigem.Dados;

			// LOAD VALUES
			txtDespesaTipo.Text = DadosNovos.Tipo;
			txtSetor.Text = DadosNovos.Setor;
			txtCredor.Text = DadosNovos.Credor;

			// ADD HANDLERS
			txtDespesaTipo.KeyDown += Control_KeyDown;
			txtSetor.KeyDown += Control_KeyDown;
			txtCredor.KeyDown += Control_KeyDown;

			txtDespesaTipo.Enter += Control_Enter;
			txtSetor.Enter += Control_Enter;
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

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{

			txtSetor.Clear();
			DadosNovos.IDSetor = null;
			DadosNovos.Setor = null;

			txtDespesaTipo.Clear();
			DadosNovos.IDTipo = null;
			DadosNovos.Tipo = null;

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

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetTipo_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmDespesaTipoProcura frm = new frmDespesaTipoProcura(this, DadosNovos.IDTipo);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (DadosNovos.IDTipo != (int)frm.propEscolha.IDDespesaTipo) propAlterado = true;

					DadosNovos.IDTipo = (int)frm.propEscolha.IDDespesaTipo;
					DadosNovos.Tipo = frm.propEscolha.DespesaTipo;
					txtDespesaTipo.Text = frm.propEscolha.DespesaTipo;
				}

				//--- select
				txtDespesaTipo.Focus();
				txtDespesaTipo.SelectAll();
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

				frmSetorProcura frm = new frmSetorProcura(this, DadosNovos.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (DadosNovos.IDSetor != (int)frm.propEscolha.IDSetor) propAlterado = true;

					DadosNovos.IDSetor = (int)frm.propEscolha.IDSetor;
					DadosNovos.Setor = frm.propEscolha.Setor;
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

		private void btnSetCredor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmCredorListagem frm = new frmCredorListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CONTRIBUINTE
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
					txtDespesaTipo,
					txtSetor,
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
					case "txtDespesaTipo":
						btnSetTipo_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtCredor":
						btnSetCredor_Click(sender, new EventArgs());
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
					case "txtDespesaTipo":
						txtDespesaTipo.Clear();
						DadosNovos.IDTipo = null;
						DadosNovos.Tipo = null;
						break;
					case "txtSetor":
						txtSetor.Clear();
						DadosNovos.IDSetor = null;
						DadosNovos.Setor = null;
						break;
					case "txtCredor":
						txtCredor.Clear();
						DadosNovos.IDCredor = null;
						DadosNovos.Credor = null;
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
					txtDespesaTipo,
					txtSetor,
					txtCredor };

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
