using CamadaBLL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using static CamadaUI.Utilidades;

namespace CamadaUI.Config
{
	public partial class frmConfigEmailServer : Modals.frmModConfig
	{

		private string SourceXMLFile = "";
		private bool _ArquivoAlterado = false;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmConfigEmailServer()
		{
			// This call is required by the designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent() call.
			ObterArquivo();

			HandlerKeyDownControl(this);
		}

		private void frmConfigEmailServer_Shown(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(SourceXMLFile))
			{
				LoadXMLSettings();

				if (txtLogoRemota.Text.Length > 0)
				{
					var result = GetImageAsync(txtLogoRemota.Text);
					result.ContinueWith(task =>
					{
						picLogo.Image = task.Result;
					});
				}

				//--- add Handler Change
				HandlerChangedControles();
			}
			else
			{
				AbrirDialog("Uma exceção ocorreu ao acessar o arquivo de configuração..." +
					"\nArquivo XML não foi encontrado", "Exceção", DialogType.OK, DialogIcon.Exclamation);
				Close();
			}
		}

		private void ObterArquivo()
		{
			AcessoControlBLL aBLL = new AcessoControlBLL();

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				SourceXMLFile = aBLL.GetConfigXMLPath();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter acesso ao arquivo de configuração XML..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		public bool ArquivoAlterado
		{
			get
			{
				return _ArquivoAlterado;
			}
			set
			{
				if (value)
				{
					btnSalvar.Enabled = true;
					btnCancelar.Text = "&Cancelar";
				}
				else
				{
					btnSalvar.Enabled = false;
					btnCancelar.Text = "&Fechar";
				}

				_ArquivoAlterado = value;
			}
		}

		#endregion

		#region XML FUNCTIONS

		private bool LoadXMLSettings()
		{
			XmlDocument doc = new XmlDocument();

			//--- Try open XML document
			try
			{
				doc.Load(SourceXMLFile);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ler o arquivo XML..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}

			if (!VerificaArquivoXML(doc)) return false;

			try
			{
				XmlNode setting = doc.GetElementsByTagName("emailServerSettings")[0];

				txtUser.Text = setting.SelectSingleNode("emailUserName").InnerText;
				txtPassword.Text = setting.SelectSingleNode("emailPassword").InnerText;
				txtSMTPPort.Text = setting.SelectSingleNode("smtpPort").InnerText;
				txtSMTPHost.Text = setting.SelectSingleNode("smtpHost").InnerText;

				//--- FILL ITEMS / TEXTBOX
				if (setting.SelectSingleNode("smtpEnableSSL").InnerText == "True")
					chkEnableSSL.Checked = true;
				else
					chkEnableSSL.Checked = false;

				txtLogoRemota.Text = setting.SelectSingleNode("logoRemotaURL").InnerText;
				txtSite.Text = setting.SelectSingleNode("sitePadraoURL").InnerText;

				//--- RETURN
				return true;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ler o arquivo XML..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}

		}

		private bool VerificaArquivoXML(XmlDocument doc)
		{
			//--- CHECK XML FILE
			bool check1 = doc.GetElementsByTagName("userSettings").Count == 1;
			bool check2 = doc.GetElementsByTagName("MySettings").Count == 1;
			bool check3 = doc.GetElementsByTagName("setting").Count > 0;

			if (!(check1 && check2 && check3))
			{
				AbrirDialog("Arquivo XML Inválido", "XML Inválido",
								DialogType.OK, DialogIcon.Exclamation);
				SourceXMLFile = "";
				lblCaminho.Text = SourceXMLFile;
				return false;
			}

			XmlNode root = doc.DocumentElement;

			if (doc.GetElementsByTagName("emailServerSettings").Count == 0)
			{
				XmlElement elem = (XmlElement)doc.CreateNode(XmlNodeType.Element, "emailServerSettings", "");
				XmlNode setting = root.AppendChild(elem);

				EmailAppendChild(doc, setting, "emailUserName");
				EmailAppendChild(doc, setting, "emailPassword");
				EmailAppendChild(doc, setting, "smtpPort");
				EmailAppendChild(doc, setting, "smtpHost");
				EmailAppendChild(doc, setting, "smtpEnableSSL");
				EmailAppendChild(doc, setting, "logoRemotaURL");
				EmailAppendChild(doc, setting, "sitePadraoURL");
			}

			doc.Save(SourceXMLFile);

			return true;
		}

		private void EmailAppendChild(XmlDocument doc, XmlNode setting, string nodeName)
		{
			XmlElement elem = (XmlElement)doc.CreateNode(XmlNodeType.Element, nodeName, "");
			setting.AppendChild(elem);
		}

		#endregion // XML FUNCTIONS --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (ArquivoAlterado)
			{
				LoadXMLSettings();
				ArquivoAlterado = false;
			}
		}

		private void btnFechar_Click(object sender, EventArgs e)
		{
			//Close();

			frmConfig f = Application.OpenForms.OfType<frmConfig>().FirstOrDefault();
			f.FormNoPanelClosed(this);

		}

		#endregion // BUTTONS FUNCTION --- END

		#region CONTROLS

		private void HandlerChangedControles()
		{
			foreach (Control c in Controls.OfType<TextBox>())
			{
				c.TextChanged += (a, b) => { if (!ArquivoAlterado) ArquivoAlterado = true; };
			}
		}

		#endregion // CONTROLS --- END

		#region SAVE

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (!VerificaDados()) return;

			XmlDocument doc = new XmlDocument();

			//--- Try open XML document
			try
			{
				doc.Load(SourceXMLFile);

				XmlNode setting = doc.SelectSingleNode("configuration/emailServerSettings");

				//--- remove all childs
				setting.RemoveAll();

				//--- add all necessary childs
				EmailAppendChild(doc, setting, "emailUserName");
				EmailAppendChild(doc, setting, "emailPassword");
				EmailAppendChild(doc, setting, "smtpPort");
				EmailAppendChild(doc, setting, "smtpHost");
				EmailAppendChild(doc, setting, "smtpEnableSSL");
				EmailAppendChild(doc, setting, "logoRemotaURL");
				EmailAppendChild(doc, setting, "sitePadraoURL");

				//--- save the values InnerText
				setting.SelectSingleNode("emailUserName").InnerText = txtUser.Text;
				setting.SelectSingleNode("emailPassword").InnerText = txtPassword.Text;
				setting.SelectSingleNode("smtpPort").InnerText = txtSMTPPort.Text;
				setting.SelectSingleNode("smtpHost").InnerText = txtSMTPHost.Text;

				if (chkEnableSSL.Checked)
					setting.SelectSingleNode("smtpEnableSSL").InnerText = "true";
				else
					setting.SelectSingleNode("smtpEnableSSL").InnerText = "false";

				setting.SelectSingleNode("logoRemotaURL").InnerText = txtLogoRemota.Text;
				setting.SelectSingleNode("sitePadraoURL").InnerText = txtSite.Text;

				doc.Save(SourceXMLFile);
				ArquivoAlterado = false;

				AbrirDialog("Configuração de Email salva com sucessso!",
							"Salvo",
							DialogType.OK,
							DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Arquivo de Configuração..." +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);

			}
		}

		private bool VerificaDados()
		{
			foreach (TextBox c in Controls.OfType<TextBox>())
			{
				//--- se for LogoRemota ou Site nao verifica
				if (!(c.Name == "txtLogoRemota" || c.Name == "txtSite"))
				{
					//--- verifica texto
					if (c.Text.Trim().Length == 0)
					{
						AbrirDialog("Todos os campos precisam ser preenchidos",
								"Campos Vazios", DialogType.OK,
								DialogIcon.Exclamation);
						c.Focus();
						return false;
					}

				}
			}

			return true;
		}

		#endregion // SAVE --- END
	}
}
