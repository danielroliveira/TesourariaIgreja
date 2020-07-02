using CamadaDTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CamadaUI.APagar.Reports
{
	public partial class frmAPagarReport : CamadaUI.Modals.frmModFinBorderSizeable
	{
		private List<objAPagar> _apagarList;

		public frmAPagarReport(List<objAPagar> apagarList)
		{
			InitializeComponent();

			_apagarList = apagarList;

			// Criar a lista de ClientePF
			//dadosEmpresa.Add(ObterDadosEmpresa);

			ReportDataSource dst = new ReportDataSource("dstAPagar", _apagarList);

			// --- define o relatório
			// -------------------------------------------------------------
			// --- clear dataSources
			rptvPadrao.LocalReport.DataSources.Clear();

			// --- insert data
			rptvPadrao.LocalReport.DataSources.Add(dst);

			// --- set Logo Path
			//getLogo(dadosEmpresa[0].ArquivoLogoMono);

			// -- display
			rptvPadrao.SetDisplayMode(DisplayMode.PrintLayout);
			rptvPadrao.RefreshReport();

		}

		private void frmAPagarReport_Load(object sender, EventArgs e)
		{

			//--- define o tamanho
			int tamMaxH = Screen.PrimaryScreen.Bounds.Height;
			Height = tamMaxH - (tamMaxH * 10) / 100;
			CenterToScreen();

			this.rptvPadrao.RefreshReport();
		}

		private void getLogo(string path)
		{
			List<ReportParameter> @params = new List<ReportParameter>();

			rptvPadrao.LocalReport.EnableExternalImages = true;
			ReportParameter parameterLogo = new ReportParameter("LogoPath", @"file:\\" + path);

			@params.Add(parameterLogo);
			rptvPadrao.LocalReport.SetParameters(@params);
			rptvPadrao.LocalReport.Refresh();
		}

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
