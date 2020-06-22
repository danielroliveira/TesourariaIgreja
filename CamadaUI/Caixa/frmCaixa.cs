using CamadaDTO;
using CamadaBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Caixa
{
	public partial class frmCaixa : CamadaUI.Modals.frmModFinBorder
	{

		private List<objMovimentacao> lstMov;
		private BindingSource bindMovs = new BindingSource();
		private CaixaBLL cxBLL = new CaixaBLL();

		private objCaixa _caixa;
		private BindingSource bindCaixa = new BindingSource();
		private Form _formOrigem;

		private decimal _TEntradas;
		private decimal _TSaidas;
		private decimal _TTransf;

		#region SUB NEW | CONSTRUCTOR

		// CONSTRUCTOR
		//------------------------------------------------------------------------------------------------------------
		public frmCaixa(objCaixa caixa, Form formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;

			_caixa = caixa;
			bindCaixa.DataSource = typeof(objCaixa);
			bindCaixa.Add(_caixa);

			propSituacao = _caixa.IDSituacao;
			BindingCreator();

		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public byte propSituacao
		{
			get
			{
				return _caixa.IDSituacao;
			}
			set
			{
				_caixa.IDSituacao = value;

				switch (value)
				{
					case 1: // INICIADO
						btnAlterar.Enabled = true;
						btnFinalizar.Enabled = true;
						btnExcluirCaixa.Enabled = true;
						txtObservacao.ReadOnly = false;
						btnFinalizar.Text = "Finalizar Caixa";
						btnFinalizar.Image = Properties.Resources.accept_24;
						break;
					case 2: // FINALIZADO
						btnAlterar.Enabled = false;
						btnFinalizar.Enabled = true;
						btnExcluirCaixa.Enabled = false;
						txtObservacao.ReadOnly = true;
						btnFinalizar.Text = "Desbloqueio";
						btnFinalizar.Image = Properties.Resources.unlock_24;
						break;
					case 3: // BLOQUEADO
						btnAlterar.Enabled = false;
						btnFinalizar.Enabled = false;
						btnExcluirCaixa.Enabled = false;
						txtObservacao.ReadOnly = true;
						btnFinalizar.Text = "Finalizar Caixa";
						btnFinalizar.Image = Properties.Resources.accept_24;
						break;
					default:
						break;
				}
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bindCaixa, "IDCaixa", true);
			lblConta.DataBindings.Add("Text", bindCaixa, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			lblSaldoAnterior.DataBindings.Add("Text", bindCaixa, "SaldoAnterior", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDataFinal.DataBindings.Add("Text", bindCaixa, "DataFinal", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDataInicial.DataBindings.Add("Text", bindCaixa, "DataInicial", true, DataSourceUpdateMode.OnPropertyChanged);
			lblSituacao.DataBindings.Add("Text", bindCaixa, "Situacao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblSaldoAnterior.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		#endregion

		#region BUTTONS FUNCTIONS

		// FECHAR
		//------------------------------------------------------------------------------------------------------------
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		#endregion // BUTTONS FUNCTIONS --- END

	}
}
