using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Config
{
	public partial class frmConfig : CamadaUI.Modals.frmModFinBorder
	{
		frmPrincipal _formOrigem;
		Form _OpenedForm;
		Color btnColorSelected = Color.Goldenrod;
		Color btnColorNormal = Color.FromArgb(37, 46, 59);

		#region NEW | PROPERTIES

		public frmConfig(frmPrincipal formOrigem)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
		}

		private Form OpenedForm
		{
			get => _OpenedForm;
			set
			{
				_OpenedForm = value;
				foreach (Control control in pnlMenu.Controls)
				{
					control.BackColor = btnColorNormal;
				}

				if (_OpenedForm == null)
					return;

				switch (_OpenedForm.Name)
				{
					case "frmConfigGeral":
						btnGeral.BackColor = btnColorSelected;
						break;
					case "frmConfigDados":
						btnDados.BackColor = btnColorSelected;
						break;
					case "frmConfigImagem":
						btnImagem.BackColor = btnColorSelected;
						break;
					case "frmConfigServidor":
						btnServidor.BackColor = btnColorSelected;
						break;
					case "frmConfigEmailServer":
						btnEmail.BackColor = btnColorSelected;
						break;
					case "frmConfigAvisos":
						btnAvisos.BackColor = btnColorSelected;
						break;
					case "frmConfigUsuarios":
						btnUsuarios.BackColor = btnColorSelected;
						break;
					default:
						break;
				}
			}
		}

		#endregion

		#region BUTTONS

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
			_formOrigem.MenuEnabled(true);
		}

		#endregion // BUTTONS --- END

		#region FUNCTIONS

		private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
		{
			Form formulario;
			formulario = pnlCorpo.Controls.OfType<Forms>().FirstOrDefault();

			if (OpenedForm != null && formulario == null)
			{
				OpenedForm.Close();
				OpenedForm = null;
			}

			if (formulario == null)
			{
				formulario = new Forms();
				formulario.TopLevel = false;
				formulario.FormBorderStyle = FormBorderStyle.None;
				formulario.Dock = DockStyle.Fill;
				pnlCorpo.Controls.Add(formulario);
				pnlCorpo.Tag = formulario;
				formulario.Show();
				formulario.BringToFront();
				OpenedForm = formulario;
			}
			else
			{
				if (formulario.WindowState == FormWindowState.Minimized)
					formulario.WindowState = FormWindowState.Normal;
				formulario.BringToFront();
			}
		}

		public void FormNoPanelClosed(Form frm)
		{
			frm.Close();
			OpenedForm = null;
		}

		#endregion // FUNCTIONS --- END

		#region BUTTONS CONFIGS

		private void btnGeral_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigGeral>();
		}

		private void btnImagem_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigImagem>();
		}

		private void btnServidor_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigServidor>();
		}

		private void btnEmail_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigEmailServer>();
		}

		private void btnAvisos_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigAvisos>();
		}

		private void btnUsuarios_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigUsuarios>();
		}

		private void btnDados_Click(object sender, EventArgs e)
		{
			AbrirFormNoPanel<frmConfigDados>();
		}

		#endregion // BUTTONS CONFIGS --- END

		#region ARQUIVO DE CONFIGURACAO: OPEN | SAVE

		// FAZER BACKUP DO ARQUIVO DE CONFIGURACAO
		//------------------------------------------------------------------------------------------------------------
		private void btnSalvarConfig_Click(object sender, EventArgs e)
		{
			FileInfo config = new FileInfo(Application.StartupPath + "\\Config.xml");

			//--- check exists config file
			if (!config.Exists)
			{
				AbrirDialog("O arquivo de CONFIGURAÇÃO é inexistente ou ainda não foi criado..." +
					"\nNão é possível, nesse caso, salvar o arquivo.",
					"Salvar Configuração", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- Get Backup Folder
			try
			{
				string path = "";
				string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
				string defFolder = userFolder + "\\Tesouraria\\Backup\\";

				if (Directory.Exists(defFolder))
				{
					path = defFolder;
				}
				else
				{
					path = userFolder;
				}

				// get folder
				using (FolderBrowserDialog FBDiag = new FolderBrowserDialog()
				{
					Description = "Pasta de Backup do Arquivo de Configuração",
					SelectedPath = path,
					ShowNewFolderButton = true
				})
				{
					DialogResult result = FBDiag.ShowDialog();

					if (result == DialogResult.OK)
					{
						path = FBDiag.SelectedPath;
					}
					else
					{
						return;
					}
				}

				config.CopyTo(path + "\\Config_Backup.xml", true);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar arquivo de Configuração..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
		}


		// ABRIR NOVO ARQUIVO DE CONFIGURACAO
		//------------------------------------------------------------------------------------------------------------
		private void btnAbrirConfig_Click(object sender, EventArgs e)
		{
			//--- ask user
			var resp = AbrirDialog("Deseja obter um BACKUP do arquivo de configuração e substituir a configuração atual?",
				"Configuração Backup", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			//--- get default folder
			string path = "";
			string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			string defFolder = userFolder + "\\Tesouraria\\Backup\\";

			if (Directory.Exists(defFolder))
			{
				path = defFolder;
			}
			else
			{
				path = userFolder;
			}

			//--- open FileDialog
			using (OpenFileDialog OFD = new OpenFileDialog()
			{
				Filter = "XML (*.xml)|*.xml",
				InitialDirectory = path
			})
			{
				if (OFD.ShowDialog() != DialogResult.OK) return;

				bool? Check = CheckNewConfigFile(OFD.FileName);

				if (Check != null && Check == false)
				{
					AbrirDialog("O arquivo de confiruação selecionado é inválido ou não se encontra no formato esperado..." +
						"\nFavor escolher outro arquivo com formato correto.",
						"Arquivo Inválido",
						DialogType.OK,
						DialogIcon.Warning);
					return;
				}
				else if (Check == null)
				{
					return;
				}

				//--- execute copy
				FileInfo newConfig = new FileInfo(OFD.FileName);
				newConfig.CopyTo(Application.StartupPath + "\\Config.xml", true);

				//--- user message
				resp = AbrirDialog("Arquivo de Configuração obtido com sucesso!" +
					"\nÉ necessário sair da aplicação para que o novo arquivo seja lido corretamente..." +
					"\n\nDeseja Sair?",
					"Nova Configuração",
					DialogType.SIM_NAO,
					DialogIcon.Question);

				if (resp != DialogResult.No)
				{
					Application.Exit();
				}

			}
		}

		// CHECK ARQUIVO DE CONFIGURACAO
		//------------------------------------------------------------------------------------------------------------
		private bool? CheckNewConfigFile(string NewConfigPath)
		{
			var XsdPath = Application.StartupPath + "\\ConfigFiles\\ConfigSchema.xsd";

			//--- check XSDPath
			if (!File.Exists(XsdPath))
			{
				AbrirDialog("Arquivo de Validação XSD da configuração do sistema não encontrado..." +
					"Favor comunicar ao administrador do sistema",
					"Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}

			return ValidatedXML(NewConfigPath, XsdPath);
		}

		#endregion // ARQUIVO DE CONFIGURACAO: OPEN | SAVE --- END
	}
}
