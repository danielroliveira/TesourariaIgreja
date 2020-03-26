using CamadaBLL;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using System.Xml;

namespace CamadaUI.Config
{
	public partial class frmConfigGeral : modals.frmModConfig
	{
		private int? IDCongregacao;
		private int? IDConta;
		string db = DBPath();

		#region SUB NEW | LOAD

		// SUB NEW
		public frmConfigGeral()
		{
			InitializeComponent();
			LoadConfig();
		}

		// LOAD
		private void frmConfigGeral_Load(object sender, EventArgs e)
		{
			txtIgrejaTitulo.Focus();
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

		#region XML FUNCTIONS

		private void LoadConfig()
		{
			try
			{
				XmlDocument doc = MyConfig();

				if (doc == null)
				{
					throw new Exception("Arquivo de Configuração Inválido...");
				}

				txtIgrejaTitulo.Text = LoadNode(doc, "IgrejaTitulo");

				// CONGREGACAO
				string strIDCong = LoadNode(doc, "CongregacaoPadrao");
				IDCongregacao = string.IsNullOrEmpty(strIDCong) ? null : int.Parse(strIDCong) as int?;
				txtCongregacaoPadrao.Text = LoadNode(doc, "CongregacaoDescricao");

				// CONTA
				string strIDConta = LoadNode(doc, "ContaPadrao");
				IDConta = string.IsNullOrEmpty(strIDConta) ? null : int.Parse(strIDConta) as int?;
				txtContaPadrao.Text = LoadNode(doc, "ContaDescricao");
				
				// DATA BLOQUEIO | DATA PADRAO
				lblDataBloqueio.Text = LoadNode(doc, "DataBloqueada");
				string DataPadrao = LoadNode(doc, "DataPadrao");
				dtpDataPadrao.Value =  string.IsNullOrEmpty(DataPadrao) ? DateTime.Today : Convert.ToDateTime(DataPadrao);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ler arquivo XML..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			
		}

		private string LoadNode(XmlDocument doc, string nodeName)
		{
			XmlNodeList elemList = doc.GetElementsByTagName(nodeName);
			string myValor = "";

			for (int i = 0; i < elemList.Count; i++)
			{
				myValor = elemList[i].InnerXml;
			}

			return myValor;
		}

		#endregion


		private void txtIgrejaTitulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				frmConfig fConfig = Application.OpenForms.OfType<frmConfig>().FirstOrDefault();

				frmPrincipal f = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				f.AplicacaoTitulo = txtIgrejaTitulo.Text;



			}
			catch (Exception ex)
			{
				AbrirDialog("Houve uma execeção ao salvar Config... \n" +
					ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
		}

		private void btnSalvarConfig_Click(object sender, EventArgs e)
		{
			// check controls
			if (!VerificaControles()) return;

			// save items
			SaveConfigValorNode("IgrejaTitulo", txtIgrejaTitulo.Text);
			SaveConfigValorNode("CongregacaoDescricao", txtCongregacaoPadrao.Text);
			SaveConfigValorNode("CongregacaoPadrao", IDCongregacao.ToString());
			SaveConfigValorNode("ContaDescricao", txtContaPadrao.Text);
			SaveConfigValorNode("ContaPadrao", IDConta.ToString());
			SaveConfigValorNode("DataPadrao", dtpDataPadrao.Value.ToShortDateString());

		}

		private bool VerificaControles()
		{
			if (!VerificaControle(txtIgrejaTitulo, "TÍTULO DA IGREJA")) return false;
			if (!VerificaControle(dtpDataPadrao, "DATA PADRÃO")) return false;
			if (!VerificaControle(txtCongregacaoPadrao, "CONGREGAÇÃO PADRÃO")) return false;
			if (!VerificaControle(txtContaPadrao, "CONTA PADRÃO")) return false;

			return true;
		}

	}
}
