using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml;
using ComponentOwl.BetterListView;
using CamadaBLL;
using static CamadaUI.Utilidades;
using System.Linq;

namespace CamadaUI.Main
{
	public partial class frmConnString : CamadaUI.Modals.frmModFinBorder
	{
		private string SourceXMLFile = "";
		private bool ArquivoNovo = false;
		private bool _ArquivoAlterado;
		private string _SelectedString = "";

		#region SUBNEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmConnString()
		{
			InitializeComponent();
		}

		// PROPERTY SELECTED STRING
		//------------------------------------------------------------------------------------------------------------
		public string SelectedString
		{
			get => _SelectedString;
			set
			{
				_SelectedString = value;

				if (string.IsNullOrEmpty(value))
				{
					btnAtualizar.Enabled = false;
					btnRemoverString.Enabled = false;
					btnUsar.Enabled = false;
				}
				else
				{
					btnAtualizar.Enabled = true;
					btnRemoverString.Enabled = true;

					if (ArquivoAlterado || ArquivoNovo)
					{
						btnUsar.Enabled = false;
					}
					else
					{
						btnUsar.Enabled = true;
					}
				}
			}
		}

		// PROPERTY ARQUIVO ALTERADO
		//------------------------------------------------------------------------------------------------------------
		public bool ArquivoAlterado
		{
			get => _ArquivoAlterado;
			set
			{
				_ArquivoAlterado = value;

				if (value = true && lstConn.Items.Count > 0)
				{
					btnSalvarArquivo.Enabled = true;
					btnUsar.Enabled = false;
				}
				else
				{
					btnSalvarArquivo.Enabled = false;
				}

			}
		}

		#endregion

		#region BUTTONS

		// Obter Abrir Arquivo
		private void btnObterArquivo_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog OFD = new OpenFileDialog())
			{
				OFD.Filter = "XML (*.xml)|*.xml";
				OFD.InitialDirectory = Application.StartupPath;

				if (OFD.ShowDialog() == DialogResult.OK)
				{
					SourceXMLFile = OFD.FileName;
					lblCaminho.Text = SourceXMLFile;
					ArquivoNovo = false;
					ArquivoAlterado = false;

					LoadXMLConnection();
				}
			}
		}

		// BTN FECHAR FORM | CANCELAR
		//------------------------------------------------------------------------------------------------------------
		private void btnClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		// BTN NOVA STRING
		//------------------------------------------------------------------------------------------------------------
		private void btnNovaString_Click(object sender, EventArgs e)
		{
			//--- check SourceXMLFile
			if (string.IsNullOrEmpty(SourceXMLFile))
			{
				MessageBox.Show("Favor escolher antes um arquivo XML válido...",
					"Arquivo XML Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//--- check text on txtConnString
			if (txtConnString.Text.Trim().Length < 10)
			{
				MessageBox.Show("String de Conexão inválida... \n" +
					"Favor entrar com uma nova String de Conexão válida",
					"String Inválida",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				txtConnString.Focus();
				txtConnString.SelectAll();
				return;
			}

			string novaString = "";
			DialogResult response = InputBoxDialog.InputBox("Titulo", "Prompt do texto que fica no input box", ref novaString);

			if (response == DialogResult.Cancel || string.IsNullOrEmpty(novaString)) return;

			//--- check if duplicated string name
			foreach (var item in lstConn.Items)
			{
				if (item.Text == novaString.Trim())
				{
					MessageBox.Show("Já existe uma string de conexão com esse mesmo nome... \n" +
					"Favor entrar com um nome diferente.",
					"Nome Inválido",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
					return;
				}
			}

			//--- EXECUTE
			lstConn.Items.Add(new string[] { novaString, txtConnString.Text.Trim() });
			txtConnString.Clear();
			ArquivoAlterado = true;
		}

		// BTN REMOVER STRING
		//------------------------------------------------------------------------------------------------------------
		private void btnRemoverString_Click(object sender, EventArgs e)
		{
			if (lstConn.Items.Count == 1)
			{
				MessageBox.Show("Não é possível salvar arquivo de acesso do Servidor sem pelo menos uma String de Conexão",
								"Somente uma String",
								MessageBoxButtons.OK,
								MessageBoxIcon.Information);
				return;
			}

			if (lstConn.SelectedItems.Count > 0)
			{
				lstConn.Items.RemoveAt(lstConn.SelectedItems[0].Index);
				ArquivoAlterado = true;
			}
		}

		// BTN ATUALIZAR STRING
		//------------------------------------------------------------------------------------------------------------
		private void btnAtualizar_Click(object sender, EventArgs e)
		{
			//--- check SourceXMLFile
			if (string.IsNullOrEmpty(SourceXMLFile))
			{
				MessageBox.Show("Favor escolher antes um arquivo XML válido...",
								"Arquivo XML Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//--- check text on txtConnString
			if (txtConnString.Text.Trim().Length < 10)
			{
				MessageBox.Show("String de Conexão inválida... \n" +
								"Favor entrar com uma nova String de Conexão válida",
								"String Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtConnString.Focus();
				txtConnString.SelectAll();
				return;
			}

			//--- execute
			if (lstConn.SelectedItems.Count > 0)
			{
				var novaString = lstConn.SelectedItems[0].Text;
				lstConn.Items.First(x => x.Text == novaString).SubItems[1].Text = txtConnString.Text.Trim();
				ArquivoAlterado = true;
			}
		}

		// BTN SALVAR STRING
		//------------------------------------------------------------------------------------------------------------
		private void btnSalvarArquivo_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				XmlTextWriter writer = new XmlTextWriter(SourceXMLFile, Encoding.UTF8);

				writer.WriteStartDocument();

				//--- define a indentação do arquivo
				writer.Formatting = Formatting.Indented;

				writer.WriteStartElement("configuration");
				writer.WriteStartElement("userSettings");
				writer.WriteStartElement("MySettings");

				foreach (var item in lstConn.Items)
				{
					writer.WriteStartElement("setting");
					// atributo para marcar arquivo recebido
					writer.WriteAttributeString("name", item.Text);
					// atributo para marcar arquivo devolvido e confirmado
					writer.WriteAttributeString("serializeAs", "String");
					writer.WriteElementString("value", item.SubItems[1].Text);
					writer.WriteEndElement(); // setting
				}

				writer.WriteEndElement(); // END: MySettings
				writer.WriteEndElement(); // END: userSettings

				//--- CONFIG EMAIL ELEMENTS
				writer.WriteStartElement("emailServerSettings"); //--- START

				writer.WriteElementString("emailUserName", "");
				writer.WriteElementString("emailPassword", "");
				writer.WriteElementString("smtpPort", "");
				writer.WriteElementString("smtpHost", "");
				writer.WriteElementString("smtpEnableSSL", "");
				writer.WriteElementString("logoRemotaURL", "");
				writer.WriteElementString("sitePadraoURL", "");

				writer.WriteEndElement(); // END: emailServerSettings

				writer.WriteEndElement(); // END: configuration
				writer.Close();

				ArquivoAlterado = false;
				ArquivoNovo = false;

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Arquivo XML..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// BTN CRIAR ARQUIVO
		//------------------------------------------------------------------------------------------------------------
		private void btnCriarArquivo_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog OFD = new SaveFileDialog()
			{
				Filter = "XML (*.xml)|*.xml",
				InitialDirectory = Application.StartupPath
			})
			{
				if (OFD.ShowDialog() == DialogResult.OK)
				{
					SourceXMLFile = OFD.FileName;
					lblCaminho.Text = SourceXMLFile;
					ArquivoNovo = true;
					ArquivoAlterado = false;
				}
			}
		}

		// BTN USAR STRING
		//------------------------------------------------------------------------------------------------------------
		private void btnUsar_Click(object sender, EventArgs e)
		{
			AcessoControlBLL acessoControl = new AcessoControlBLL();

			try
			{
				acessoControl.SaveConnString(SourceXMLFile, lstConn.SelectedItems[0].Text);
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Uma exceção ocorreu ao Salvar arquivo de configuração... /n" +
								ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region FUNCTIONS

		private bool LoadXMLConnection()
		{
			XmlDocument doc = new XmlDocument();

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				doc.Load(SourceXMLFile);

				//--- CHECK XML FILE
				bool check1 = doc.GetElementsByTagName("userSettings").Count == 1;
				bool check2 = doc.GetElementsByTagName("MySettings").Count == 1;
				bool check3 = doc.GetElementsByTagName("setting").Count > 0;

				if (!(check1 && check2 && check3))
				{
					MessageBox.Show("Arquivo XML Inválido", "XML Inválido",
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					SourceXMLFile = "";
					lblCaminho.Text = SourceXMLFile;
					return false;
				}

				//--- FILL LIST ITEMS
				lstConn.Items.Clear();

				XmlNodeList stringsConn = doc.GetElementsByTagName("setting");

				foreach (XmlNode conn in stringsConn)
				{
					lstConn.Items.Add(new string[] { conn.Attributes["name"].Value, conn.SelectSingleNode("value").InnerText });
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ler Arquivo XML..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

			//--- RETURN
			return true;
		}

		// AO ALTERAR INDEX DA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void lstConn_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstConn.SelectedItems.Count > 0)
			{
				txtConnString.Text = lstConn.SelectedItems[0].SubItems[1].Text;
				SelectedString = lstConn.SelectedItems[0].Text;
			}
			else
			{
				txtConnString.Text = "";
				SelectedString = "";
			}
		}

		private void lstConn_DrawColumnHeader(object sender, BetterListViewDrawColumnHeaderEventArgs eventArgs)
		{
			if (eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 && eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0)
			{
				Brush brush = new LinearGradientBrush(
					eventArgs.ColumnHeaderBounds.BoundsOuter,
					Color.Transparent,
					Color.FromArgb(64, Color.SteelBlue),
					LinearGradientMode.Vertical
					);
				eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter);
				brush.Dispose();
			}
		}

		#endregion
	}
}
