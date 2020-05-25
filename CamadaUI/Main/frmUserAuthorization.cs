using System;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Main
{
	public partial class frmUserAuthorization : CamadaUI.Modals.frmModFinBorder
	{
		Form _formOrigem = null;
		public string propUser { get; set; }
		public string propSenha { get; set; }

		public frmUserAuthorization(string AuthDescription, Form formOrigem = null)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			lblMessage.Text = AuthDescription;
			HandlerKeyDownControl(this);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!VerificaControles()) return;

			propUser = txtApelido.Text;
			propSenha = txtSenha.Text;

			DialogResult = DialogResult.OK;
		}

		private bool VerificaControles()
		{
			if (txtApelido.Text.Trim().Length == 0)
			{
				AbrirDialog("O campo Nome do Usuário precisa estar preenchido...",
							"Nome do Usuário",
							DialogType.OK,
							DialogIcon.Information);
				txtApelido.Focus();
				return false;
			}

			if (txtSenha.Text.Trim().Length == 0)
			{
				AbrirDialog("O campo Senha precisa estar preenchido...",
							"Senha do Usuário",
							DialogType.OK,
							DialogIcon.Information);
				txtApelido.Focus();
				return false;
			}

			if (txtSenha.Text.Trim().Length < 8)
			{
				AbrirDialog("O campo Senha precisa ter 8 caracteres",
							"Senha do Usuário",
							DialogType.OK,
							DialogIcon.Information);
				txtApelido.Focus();
				return false;
			}

			return true;

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			propUser = string.Empty;
			propSenha = string.Empty;
			DialogResult = DialogResult.Cancel;
		}

		private void frmUserAuthorization_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnCancel_Click(sender, new EventArgs());
			}
		}

		#region VISUAL EFFECTS

		//-------------------------------------------------------------------------------------------------
		//---  CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//-------------------------------------------------------------------------------------------------
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

		#endregion // VISUAL EFFECTS --- END
	}
}
