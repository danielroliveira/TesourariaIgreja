using CamadaBLL;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Config
{
	public partial class frmConfigAparencia : modals.frmModConfig
	{
		string db = DBPath();

		#region SUB NEW | LOAD

		// SUB NEW
		public frmConfigAparencia()
		{
			InitializeComponent();

		}

		// LOAD
		private void frmConfigAparencia_Load(object sender, EventArgs e)
		{

		}

		#endregion

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
