﻿using CamadaBLL;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Config
{
	public partial class frmConfigAvisos : Modals.frmModConfig
	{

		#region SUB NEW | LOAD

		// SUB NEW
		public frmConfigAvisos()
		{
			InitializeComponent();

		}

		// LOAD
		private void frmConfigAvisos_Load(object sender, EventArgs e)
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
