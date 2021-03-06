﻿using CamadaDTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Caixa.Reports
{
	public partial class frmCaixaReport : CamadaUI.Modals.frmModFinBorderSizeable
	{
		private List<objMovimentacao> _movList;
		private objCaixa _caixa;

		#region SUB NEW | CONSTRUCTOR

		public frmCaixaReport(objCaixa caixa, List<objMovimentacao> movList)
		{
			InitializeComponent();

			_caixa = caixa;
			_movList = movList;

			ReportDataSource dstCaixa = new ReportDataSource("dstCaixa", _caixa);
			ReportDataSource dstMov = new ReportDataSource("dstMov", _movList);

			// --- define o relatório
			// -------------------------------------------------------------
			// --- clear dataSources
			rptvPadrao.LocalReport.DataSources.Clear();

			// --- insert data
			rptvPadrao.LocalReport.DataSources.Add(dstCaixa);
			rptvPadrao.LocalReport.DataSources.Add(dstMov);

			//--- add Parameters
			//addParameters(dtInicial, dtFinal);

			// -- display
			rptvPadrao.SetDisplayMode(DisplayMode.PrintLayout);
			rptvPadrao.RefreshReport();

		}

		private void frmCaixaReport_Load(object sender, EventArgs e)
		{
			//--- define o tamanho
			int tamMaxH = Screen.PrimaryScreen.Bounds.Height;
			Height = tamMaxH - (tamMaxH * 10) / 100;
			CenterToScreen();

			this.rptvPadrao.RefreshReport();
		}

		#endregion // SUB NEW --- END

		#region PARAMETERS

		private void addParameters(DateTime dtInicial, DateTime dtFinal)
		{
			List<ReportParameter> @params = new List<ReportParameter>();

			// obter Dados da Igreja
			objDadosIgreja dadosIgreja = ObterDadosIgreja();

			//--- set Periodo
			setPeriodo(dtInicial, dtFinal, @params);

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

		private void setPeriodo(DateTime dtInicial, DateTime dtFinal, List<ReportParameter> @params)
		{
			ReportParameter DataInicial = new ReportParameter("dtInicial", dtInicial.ToShortDateString());
			ReportParameter DataFinal = new ReportParameter("dtFinal", dtFinal.ToShortDateString());

			@params.Add(DataInicial);
			@params.Add(DataFinal);
		}

		#endregion // PARAMETERS --- END

		#region BUTTONS

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion // BUTTONS --- END
	}
}
