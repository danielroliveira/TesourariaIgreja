using CamadaBLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CamadaUI.Config
{
	public partial class frmConfigServidor : Modals.frmModConfig
	{

		#region SUB NEW | LOAD

		// SUB NEW
		public frmConfigServidor()
		{
			InitializeComponent();

		}

		// LOAD
		private void frmConfigServidor_Load(object sender, EventArgs e)
		{
			//--- Get Connection String
			AcessoControlBLL bBLL = new AcessoControlBLL();
			txtStringConexao.Text = bBLL.GetConnString();

			if (!string.IsNullOrEmpty(txtStringConexao.Text))
			{
				if (txtStringConexao.Text.Contains("Server=tcp:") || txtStringConexao.Text.Contains("Server = tcp:"))
					lblServidorTipo.Text = "Servidor REMOTO";
				else
					lblServidorTipo.Text = "Servidor LOCAL";
			}
			else
			{
				lblServidorTipo.Text = "Servidor INDEFINIDO";
			}
		}

		#endregion

		#region CONTROLS FUNCTIONS

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			Control ctr = (Control)sender;

			//--- cria um array de controles que serão bloqueados de alteracao
			Control[] controlesBloqueados = { txtStringConexao, };

			if (controlesBloqueados.Contains(ctr))
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		#endregion // CONTROLS FUNCTIONS --- END

		#region BUTTONS FUNCTION

		// CLOSE
		// =============================================================================
		private void btnClose_Click(object sender, EventArgs e)
		{
			frmConfig f = Application.OpenForms.OfType<frmConfig>().FirstOrDefault();
			f.FormNoPanelClosed(this);
		}

		#endregion

	}
}
