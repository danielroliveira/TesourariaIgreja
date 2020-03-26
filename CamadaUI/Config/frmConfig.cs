using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace CamadaUI.Config
{
	public partial class frmConfig : CamadaUI.modals.frmModFinBorder
	{
		frmPrincipal _formOrigem;
		Form _OpenedForm;
		Color btnColorSelected = Color.Goldenrod;
		Color btnColorNormal = Color.FromArgb(37, 46, 59);

		#region NEW | PROPERTIES

		public frmConfig(frmPrincipal formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
		}

		private Form OpenedForm {
			get => _OpenedForm;
			set
			{
				_OpenedForm = value;
				foreach (Control control in pnlMenu.Controls)
				{
					control.BackColor = btnColorNormal;
				}

				if (_OpenedForm == null)
					return;

				switch (_OpenedForm.Name)
				{
					case "frmConfigLouvor":
						btnCores.BackColor = btnColorSelected;
						break;
					case "frmConfigGeral":
						btnGeral.BackColor = btnColorSelected;
						break;
					case "frmConfigHarpa":
						btnImagem.BackColor = btnColorSelected;
						break;
					case "frmConfigLeitura":
						btnServidor.BackColor = btnColorSelected;
						break;
					case "frmConfigAvisos":
						btnAvisos.BackColor = btnColorSelected;
						break;
					default:
						break;
				}

			}
		}

		#endregion
			   
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
			_formOrigem.MenuEnabled(true);
		}

		private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
		{
			Form formulario;
			formulario = pnlCorpo.Controls.OfType<Forms>().FirstOrDefault();

			if(OpenedForm != null && formulario == null)
			{
				OpenedForm.Close();
				OpenedForm = null;
			}

			if (formulario == null)
			{
				formulario = new Forms();
				formulario.TopLevel = false;
				formulario.FormBorderStyle = FormBorderStyle.None;
				formulario.Dock = DockStyle.Fill;
				pnlCorpo.Controls.Add(formulario);
				pnlCorpo.Tag = formulario;
				formulario.Show();
				formulario.BringToFront();
				OpenedForm = formulario;
			}
			else
			{
				if (formulario.WindowState == FormWindowState.Minimized)
					formulario.WindowState = FormWindowState.Normal;
				formulario.BringToFront();
			}
		}

		public void FormNoPanelClosed(Form frm)
		{
			frm.Close();
			OpenedForm = null;
		}

		private void btnGeral_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigGeral>();
		}

		private void btnAparencia_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigAparencia>();
		}

		private void btnImagem_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigImagem>();
		}

		private void btnServidor_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigServidor>();
		}

		private void btnAvisos_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigAvisos>();
		}
	}
}
