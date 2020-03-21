using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CamadaBLL;
using CamadaDTO;
using static CamadaUI.Utilidades;

namespace CamadaUI.main
{
	public partial class frmLogin : modals.frmModNoBorder
	{
		private bool Logado = false;
		AcessoControlBLL db = new AcessoControlBLL();
		private string Fantasia = "";

		public frmLogin()
		{
			InitializeComponent();
			txtApelido.Focus();

			//--- ler o arquivo de imagem da LOGO e captar o nome fantasia
			if (File.Exists(Application.StartupPath + "/ConfigFiles/Config.xml"))
			{
				XmlDocument myXML = new XmlDocument();
				string myLogoArq;

				try
				{
					myXML.Load(Application.StartupPath + "/ConfigFiles/Config.xml");
					//--- nome fantasia
					Fantasia = myXML.SelectSingleNode("Configuracao").SelectSingleNode("DadosEmpresa").ChildNodes[0].InnerText;
					//--- arquivo de imagem
					myLogoArq = myXML.SelectSingleNode("Configuracao").SelectSingleNode("ArquivoLogo").ChildNodes[1].InnerText;
					picLogo.ImageLocation = myLogoArq;
				}
				catch (Exception e)
				{
					AbrirDialog("Uma exceção ocorreu ao Ler a imagem..." + "\n" +
								e.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{

			if (!VerificaCampos()) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				object obj = db.GetAuthorization(txtApelido.Text, txtSenha.Text);

				if (obj.GetType() == typeof(objUsuario))
				{
					frmPrincipal frmP = (frmPrincipal)Application.OpenForms[0];
					frmP.UsuarioAtual = (objUsuario)obj;
					Logado = true;

					var enumAcessoTipo = (EnumAcessoTipo)frmP.UsuarioAtual.UsuarioAcesso;
					string AcessoTipo = enumAcessoTipo.ToString();

					//--- Bem-vindo
					AbrirDialog("Seja Bem-Vindo: " + txtApelido.Text.ToUpper() + "\n \n" +
								"Acesso: " + AcessoTipo.ToUpper(), Fantasia,
								DialogType.OK,
								DialogIcon.Information);
					DialogResult = DialogResult.Yes;
					Close();
				}
				else
				{
					switch (db.TentativasAcesso)
					{
						case 1:
							MessageBox.Show(obj.ToString() + "\n" +
											"Tente novamente..." + "\n" +
											"PRIMEIRA TENTATIVA, você pode tentar mais DUAS vezes",
											"Senha e/ou Usuário Incorreto",
											MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtApelido.Focus();
							break;
						case 2:
							MessageBox.Show("Usuário ou Senha estão incorretas! \n" +
											"Tente novamente...\n" +
											"SEGUNDA TENTATIVA, você pode tentar mais UMA vezes",
											"Senha e/ou Usuário Incorreto",
											MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtApelido.Focus();
							break;
						case 3:
							MessageBox.Show("Usuário ou Senha estão incorretas!\n" +
											"TERCEIRA TENTATIVA, a aplicação será encerrada...",
											"Erro de Senha e Usuário",
											MessageBoxButtons.OK, MessageBoxIcon.Stop);
							Logado = false;
							Close();
							return;
						default:
							break;
					}
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Conectar o BD SQL... \n" +
					"Verique a conexão com o servidor e tente novamente... \n" +
					ex.Message, "Conexão Inválida",
					DialogType.OK,
					DialogIcon.Exclamation);
				Logado = false;
				Close();
				return;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}


		private bool VerificaCampos()
		{
			return false;
		}

	}
}
