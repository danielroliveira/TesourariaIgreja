using CamadaDTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Saidas.Reports
{
	public partial class frmProvisorioReciboReport : CamadaUI.Modals.frmModFinBorderSizeable
	{
		//private objDespesaProvisoria _provisoria;

		#region SUB NEW | CONSTRUCTOR

		public frmProvisorioReciboReport(objDespesaProvisoria provisorio)
		{
			InitializeComponent();

			//--- Define Data sources
			var lstProvisoria = new List<objDespesaProvisoria>() { provisorio };
			ReportDataSource dstProvisorio = new ReportDataSource("dstProvisorio", lstProvisoria);

			objDadosIgreja dadosIgreja = ObterDadosIgreja();
			var lstDados = new List<objDadosIgreja>() { dadosIgreja };
			ReportDataSource dstDados = new ReportDataSource("dstDados", lstDados);

			CreateReciboTexto(provisorio, dadosIgreja);

			// --- clear dataSources
			rptvPadrao.LocalReport.DataSources.Clear();

			// --- insert DataSources
			rptvPadrao.LocalReport.DataSources.Add(dstProvisorio);
			rptvPadrao.LocalReport.DataSources.Add(dstDados);
			addParameters(dadosIgreja.ArquivoLogoMono, dadosIgreja.Cidade);

			// -- display
			rptvPadrao.SetDisplayMode(DisplayMode.PrintLayout);
			rptvPadrao.RefreshReport();

		}

		private void frmProvisorioReciboReport_Load(object sender, EventArgs e)
		{
			//--- define o tamanho
			int tamMaxH = Screen.PrimaryScreen.Bounds.Height;
			Height = tamMaxH - (tamMaxH * 10) / 100;
			CenterToScreen();

			this.rptvPadrao.RefreshReport();
		}

		#endregion // SUB NEW --- END

		#region PARAMETERS

		private void addParameters(string LogoPath, string Cidade)
		{
			List<ReportParameter> @params = new List<ReportParameter>();

			rptvPadrao.LocalReport.EnableExternalImages = true;
			ReportParameter parameterLogo = new ReportParameter("LogoPath", @"file://" + LogoPath);
			ReportParameter parameterCidade = new ReportParameter("Cidade", Cidade);

			@params.Add(parameterLogo);
			@params.Add(parameterCidade);

			//--- add Parameters
			rptvPadrao.LocalReport.SetParameters(@params);
			rptvPadrao.LocalReport.Refresh();
		}

		private void CreateReciboTexto(objDespesaProvisoria provisorio, objDadosIgreja dados)
		{
			string Extenso = Utilidades.EscreverExtenso(provisorio.ValorProvisorio);

			string texto = $"Eu, {provisorio.Comprador} declaro que recebi da " +
				$"{(dados.RazaoSocial.Trim().Length == 0 ? "Instituição " : dados.RazaoSocial)} " +
				$"o valor de {provisorio.ValorProvisorio:C} ({Extenso}) para a seguinte finalidade: {provisorio.Finalidade.ToUpper()}. " +
				$"Comprometo-me a, após a execução do objetivo fim, apresentar o comprovante, nota fiscal ou recibo " +
				$"da compra ou do serviço prestado.";

			provisorio.ReciboTexto = texto;
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
