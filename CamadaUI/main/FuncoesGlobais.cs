﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static CamadaUI.Utilidades;
using CamadaDTO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace CamadaUI
{
	public enum DialogType { SIM_NAO, OK, OK_CANCELAR, SIM_NAO_CANCELAR }
	public enum DialogIcon { Question, Information, Exclamation, Warning }
	public enum DialogDefaultButton { First, Second, Third }
	public enum EnumFlagEstado { RegistroSalvo = 1, Alterado = 2, NovoRegistro = 3, RegistroBloqueado = 4 }

	public static class FuncoesGlobais
	{
		#region CONFIG CREATE | LOAD | CHANGE

		// CHECK IF EXIST CONFIG
		//==============================================================================================
		public static bool VerificaConfigXML()
		{
			string FindXML = Application.StartupPath + "\\Config.xml";

			if (File.Exists(FindXML))
				return true;
			else
				return false;
		}

		// CREATE CONFIG XML
		//==============================================================================================
		public static void CriarConfigXML()
		{
			try
			{
				new XDocument(
					new XElement("Configuracao",
						new XElement("DefaultValues",
							new XElement("IgrejaTitulo", ""),
							new XElement("DataPadrao", ""),
							new XElement("CongregacaoPadrao", 1),
							new XElement("CongregacaoDescricao", "Sede"),
							new XElement("ContaPadrao", "1"),
							new XElement("ContaDescricao", "Caixa Geral"),
							new XElement("SetorPadrao", "1"),
							new XElement("SetorDescricao", ""),
							new XElement("DataBloqueada", ""),
							new XElement("CidadePadrao", ""),
							new XElement("UFPadrao", "")
						),
						new XElement("Colors",
							new XElement("TopTitleColor", ""),
							new XElement("PrincipalBackColor", ""),
							new XElement("PrincipalBackImage", ""),
							new XElement("PrincipalBackgroundImageLayout", "")
						),
						new XElement("ArquivoLogo",
							new XElement("ArquivoLogoMono", ""),
							new XElement("ArquivoLogoColor", "")
						),
						new XElement("ServidorDados",
							new XElement("StringConexao", ""),
							new XElement("ServidorLocal", "")
						)
					)
				)
				.Save("Config.xml");

			}
			catch (Exception ex)
			{
				AbrirDialog(ex.Message, "Exceção XML",
					DialogType.OK, DialogIcon.Exclamation);
			}
		}

		// GET CONFIG XML DEFAULT VALUE
		// =============================================================================
		public static string ObterDefault(string CampoDefault)
		{
			try
			{
				XmlDocument config = MyConfig();
				if (config != null)
				{
					return config.SelectSingleNode("Configuracao").SelectSingleNode("DefaultValues").SelectSingleNode(CampoDefault).InnerText;
				}
				else
				{
					return string.Empty;
				}
			}
			catch
			{
				return string.Empty;
			}
		}

		// GET CONFIG XML FILE
		// =============================================================================
		public static XmlDocument MyConfig()
		{
			if (VerificaConfigXML())
			{
				XmlDocument myXML = new XmlDocument();
				try
				{
					myXML.Load(Application.StartupPath + "\\Config.xml");
					return myXML;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			else
			{
				return null;
			}
		}

		// OBTER VALOR DO NODE XML DO ARQUIVO CONFIGXML PELO NOME
		// =============================================================================
		public static string ObterConfigValorNode(string NodeName)
		{
			XmlNodeList elemList = MyConfig().GetElementsByTagName(NodeName);
			string myValor = "";

			for (int i = 0; i < elemList.Count; i++)
			{
				myValor = elemList[i].InnerXml;
			}

			return myValor;

		}

		// SAVE CONFIG XML DEFAULT VALUE
		// =============================================================================
		public static bool SaveDefault(string CampoDefault, string NewValorDefault)
		{
			try
			{
				XmlDocument xmlConfig = MyConfig();
				XmlNode myNode = xmlConfig.SelectSingleNode("/Configuracao/DefaultValues/" + CampoDefault);

				if (myNode != null)
				{
					myNode.InnerText = NewValorDefault;
					xmlConfig.Save("Config.xml");
					return true;
				}
				else
				{
					throw new Exception("O XMLNode não foi encontrado...");
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// SAVE CONFIG NODE VALOR CONFIGXML PELO NOME
		// =============================================================================
		public static bool SaveConfigValorNode(string NodeName, string NodeValue)
		{
			try
			{
				XmlDocument xmlConfig = MyConfig();

				if (xmlConfig == null)
				{
					CriarConfigXML();
					xmlConfig = MyConfig();
				}

				XmlNodeList elemList = xmlConfig.GetElementsByTagName(NodeName);

				if (elemList.Count > 0)
				{
					elemList[0].InnerXml = NodeValue;
					xmlConfig.Save("Config.xml");
				}
				else
				{
					throw new AppException("O xmlNode não foi encontrado...");
				}

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion

		#region CHECK CONTROLS TO SAVE

		//=================================================================================================
		// BOOLEAN VERIFICA CONTROLES E RETORNA MENSAGEM
		//=================================================================================================
		public static bool VerificaControle(Control controle, string controleNome)
		{
			bool IsNullOrEmpty = false;

			switch (controle.GetType())
			{
				case Type textboxType when textboxType == typeof(TextBox):

					if (controle.Text.Trim().Length == 0) IsNullOrEmpty = true;
					break;

				case Type ComboBox when ComboBox == typeof(ComboBox):

					ComboBox combo = (ComboBox)controle;
					if (combo.SelectedValue == null) IsNullOrEmpty = true;
					break;

				case Type DTPickerType when DTPickerType == typeof(DateTimePicker):

					DateTimePicker dtPicker = (DateTimePicker)controle;
					if (dtPicker.Value == null) IsNullOrEmpty = true;
					break;

				default:
					break;
			}

			if (IsNullOrEmpty)
			{
				AbrirDialog("O campo: " + controleNome + "\nnão pode ficar vazio...\n" +
							"Favor preencher o campo informado.",
							"Campo Obrigatório", DialogType.OK, DialogIcon.Exclamation);
				controle.Focus();
				return false;
			}

			return true;
		}

		//=================================================================================================
		// FUNÇAO QUE VERIFICA OS DADOS DO CONTROLES/CAMPOS E RETORNA SE ESTA PREENCHIDO
		//=================================================================================================
		public static bool VerificaDadosClasse(Control control,
			string controlTexto,
			object minhaClasse,
			ErrorProvider errorProvider = null)
		{
			//--- GET O NOME DA PROPERTY
			string myPropertyName;

			if (control.DataBindings["text"] != null)
			{
				myPropertyName = control.DataBindings["text"].BindingMemberInfo.BindingMember;
			}
			else if (control.DataBindings["SelectedValue"] != null)
			{
				myPropertyName = control.DataBindings["SelectedValue"].BindingMemberInfo.BindingField;
			}
			else if (control.DataBindings["Value"] != null)
			{
				myPropertyName = control.DataBindings["Value"].BindingMemberInfo.BindingField;
			}
			else
			{
				AbrirDialog("Um erro inesperado ocorreu ao verificar os controles...",
							"Erro Inseperado", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}

			//--- GET PROPERTY
			PropertyInfo pInfo = minhaClasse.GetType().GetProperty(myPropertyName);
			var value = pInfo.GetValue(minhaClasse, null);

			//--- GET TYPE OF VALUE
			Type type = value.GetType();

			//--- CHECK IF EMPTY OR NULL
			bool IsEmptyOrNull = false;

			if (type == typeof(string) && (string)value == "") IsEmptyOrNull = true;
			else if (value == null) IsEmptyOrNull = true;

			//--- VERIFY PROPERTY VALUE
			if (IsEmptyOrNull)
			{
				//--- MENSAGEM E ERROR PROVIDER
				AbrirDialog("O campo " + controlTexto.ToUpper() + " não pode ficar vazio;\n" +
							"Preencha esse campo antes de Salvar o registro por favor...",
							"Campo Vazio", DialogType.OK, DialogIcon.Warning);

				//--- CONTROLA O ERROR PROVIDER
				if (errorProvider == null)
				{
					ErrorProvider EP = new ErrorProvider();
					EP.SetError(control, "Preencha o valor desse campo!");
				}
				else
				{
					errorProvider.SetError(control, "Preencha o valor desse campo!");
				}

				//--- DEVOLVE O FOCO AO CONTROLE
				control.Focus();

				//--- RETORNA
				return false;
			}

			//--- RETORNA
			return true;
		}

		#endregion

		#region CONTROLE DO MENU

		//--- OCULTAR E REVELAR O MENU PRINCIPAL
		public static void OcultaMenuPrincipal()
		{
			frmPrincipal frm = Application.OpenForms.OfType<frmPrincipal>().First();
			frm.mnuPrincipal.Visible = false;
			frm.pnlTop.BackColor = Color.Gainsboro;
			frm.btnConfig.Enabled = false;
		}

		//--- REVELA MENU PRINCIPAL
		public static void MostraMenuPrincipal()
		{
			frmPrincipal frm = Application.OpenForms.OfType<frmPrincipal>().First();
			frm.mnuPrincipal.Visible = true;
			frm.mnuPrincipal.Enabled = true;
			frm.pnlTop.BackColor = Color.SlateGray;
			frm.btnConfig.Enabled = true;
		}

		//--- DESABILITA MENU PRINCIPAL
		public static void DesativaMenuPrincipal()
		{
			frmPrincipal frm = Application.OpenForms.OfType<frmPrincipal>().First();
			frm.mnuPrincipal.Enabled = false;
			frm.pnlTop.BackColor = Color.SlateGray;
			frm.btnConfig.Enabled = false;
		}

		#endregion
	}
}
