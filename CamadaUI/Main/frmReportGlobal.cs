using CamadaDTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Main
{
	public partial class frmReportGlobal : CamadaUI.Modals.frmModFinBorderSizeable
	{
		private objDadosIgreja dadosIgreja;

		#region SUB NEW | CONSTRUCTOR

		public frmReportGlobal(string ReportPathName, string ReportFormTitulo, List<object> DtSourcePrincipal, List<object> DtSourceSecundario = null)
		{
			InitializeComponent();

			//--- Define Form Titulo
			lblTitulo.Text = ReportFormTitulo;

			//--- Define Embebed Report => Ex: "CamadaUI.APagar.Reports.rptAPagarList.rdlc"
			rptvPadrao.LocalReport.ReportEmbeddedResource = ReportPathName;

			//--- Define Data sources
			ReportDataSource dstPrincipal = new ReportDataSource("dstPrincipal", DtSourcePrincipal);

			dadosIgreja = ObterDadosIgreja();
			var lstDados = new List<objDadosIgreja>() { dadosIgreja };
			ReportDataSource dstDados = new ReportDataSource("dstDados", lstDados);

			// --- clear dataSources
			rptvPadrao.LocalReport.DataSources.Clear();

			// --- insert DataSources
			rptvPadrao.LocalReport.DataSources.Add(dstPrincipal);
			rptvPadrao.LocalReport.DataSources.Add(dstDados);
			addParameters();

			if (DtSourceSecundario != null)
			{
				ReportDataSource dstSecundario = new ReportDataSource("dstSecundario", DtSourceSecundario);
				rptvPadrao.LocalReport.DataSources.Add(dstSecundario);
			}

			// -- display
			rptvPadrao.SetDisplayMode(DisplayMode.PrintLayout);
			rptvPadrao.RefreshReport();

		}

		private void frmReportGlobal_Load(object sender, EventArgs e)
		{
			//--- define o tamanho
			int tamMaxH = Screen.PrimaryScreen.Bounds.Height;
			Height = tamMaxH - (tamMaxH * 10) / 100;
			CenterToScreen();

			this.rptvPadrao.RefreshReport();
		}

		#endregion // SUB NEW --- END

		#region PARAMETERS

		private void addParameters()
		{
			List<ReportParameter> @params = new List<ReportParameter>();

			//--- set Logo Path
			setLogo(dadosIgreja.ArquivoLogoMono, @params);

			//--- add Parameters
			rptvPadrao.LocalReport.SetParameters(@params);
			rptvPadrao.LocalReport.Refresh();
		}

		private void setLogo(string path, List<ReportParameter> @params)
		{
			rptvPadrao.LocalReport.EnableExternalImages = true;
			ReportParameter parameterLogo = new ReportParameter("LogoPath", @"file://" + path);

			@params.Add(parameterLogo);
		}

		#endregion // PARAMETERS --- END

		#region BUTTONS

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			Dispose();
		}

		#endregion // BUTTONS --- END
	}
}
