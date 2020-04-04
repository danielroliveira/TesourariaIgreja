using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaDTO;
using CamadaBLL;
using CamadaUI.Registres;

namespace CamadaUI
{
	public partial class frmPrincipal : Form
	{
		private DateTime _DataPadrao;
		private objConta _ContaPadrao;
		private objUsuario _UsuarioAtual;

		#region SUB NEW | LOAD

		// SUB NEW
		// =============================================================================
		public frmPrincipal()
		{
			InitializeComponent();

			pnlTop.BackColor = Properties.Settings.Default.PanelTopColor;
			lblTitulo.Text = AplicacaoTitulo;

			foreach (Control control in this.Controls)
			{
				MdiClient client = control as MdiClient;
				if (!(client == null))
				{
					BackgroundImageLayout = ImageLayout.Zoom;
					client.BackgroundImage = Properties.Resources.Logo_FAES_cinza_PNG_Borda;
				}
			}
		}

		// LOAD
		// =============================================================================
		private void frmPrincipal_Load(object sender, EventArgs e)
		{
			//--- INICIA APLICACAO COM O MENU DESABILITADO
			//mnuPrincipal.Enabled = false;

			//--- VERIFICA SE EXISTE CONFIG DO CAMINHO DO BD
			try
			{
				//--- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				AcessoControlBLL acessoBLL = new AcessoControlBLL();
				string TestAcesso = acessoBLL.GetConnString();

				//--- open FRMCONNSTRING: to define the string de conexao
				if (string.IsNullOrEmpty(TestAcesso))
				{
					Main.frmConnString fcString = new Main.frmConnString();
					fcString.ShowDialog();

					if (fcString.DialogResult == DialogResult.Cancel)
					{
						Application.Exit();
						return;
					}
				}

				//--- ABRE E VERIFICA O LOGIN DO USUARIO
				Main.frmLogin frmLog = new Main.frmLogin();
				objConta contaInicial = new objConta(null);

				frmLog.ShowDialog();

				if (frmLog.DialogResult == DialogResult.No)
				{
					Application.Exit();
					return;
				}

				//--- VERFICA SE O ARQUIVO DE CONFIG FOI ENCONTRADO
				if (VerificaConfig() == false)
				{
					Application.Exit();
					return;
				}

				/*
				'
				'----------------------------------------------------------------
				*/

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter o caminho do BD..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

			mnuPrincipal.Focus();
			btnEntradas.Select();

			MenuOpen_Handler();
		}

		//--- PROPERTY PUBLIC
		// =============================================================================
		public objUsuario UsuarioAtual
		{
			get => _UsuarioAtual;
			set
			{
				_UsuarioAtual = value;
			}
		}


		public string AplicacaoTitulo
		{
			get
			{
				return ObterDefault("IgrejaTitulo");
			}
			set
			{
				lblTitulo.Text = value;
				SaveConfigValorNode("IgrejaTitulo", value);
			}
		}

		#endregion

		#region CONFIGURACAO INICIAL

		//--- VERIFICA CONFIG
		//=================================================================================================
		private bool VerificaConfig()
		{
			if (File.Exists(Application.StartupPath + "\\Config.xml"))
			{
				return true;
			}
			else
			{
				if (UsuarioAtual.UsuarioAcesso > 1) // não é administrador do sistema
				{
					AbrirDialog("Arquivo de Configuração não foi encontrado! \n" +
								"Seu LOGIN não tem acesso à Configuração... \n" +
								"Comunique-se com o administrador do sistema.",
								"Erro de Arquivo",
								DialogType.OK,
								DialogIcon.Warning);
					return false;
				}
			}

			AbrirDialog("Arquivo de Configuração não foi encontrado!",
						"Gerar CONFIG",
						DialogType.OK,
						DialogIcon.Warning);

			//--- abre o form de config
			Config.frmConfig frmC = new Config.frmConfig(this);
			frmC.ShowDialog();

			//--- se não existe o config, então fecha a aplicação
			if (File.Exists(Application.StartupPath + "\\Config.xml"))
			{
				return true;
			}
			else
			{
				AbrirDialog("Arquivo de Configuração ainda não foi encontrado! \n" +
							"Sem CONFIGURAÇÃO não será possível continuar... \n" +
							"Comunique-se com o administrador do Sistema.",
							"Erro de Arquivo",
							DialogType.OK,
							DialogIcon.Warning);
				return false;
			}
		}

		#endregion

		#region BUTTONS
		private void MenuOpen_Handler()
		{
			foreach (object control in mnuPrincipal.Items)
			{
				//MessageBox.Show(control.GetType().ToString());

				if (control.GetType() == typeof(ToolStripSplitButton))
				{
					ToolStripSplitButton splitButton = (ToolStripSplitButton)control;
					splitButton.ButtonClick += ToolStripSplitButton_ButtonClick;
					splitButton.MouseHover += ToolStripSplitButton_ButtonClick;
				}
			}
		}

		private void ToolStripSplitButton_ButtonClick(object sender, EventArgs e)
		{
			ToolStripSplitButton control = (ToolStripSplitButton)sender;
			control.ShowDropDown();
		}


		/*
			private void MenuOpen_AdHandler()
				'
				Foreach c In tsPrincipal.Items
					If (c.GetType Is GetType(ToolStripSplitButton)) Then
						AddHandler DirectCast(c, ToolStripSplitButton).ButtonClick, AddressOf tsbButtonClick
						AddHandler DirectCast(c, ToolStripSplitButton).MouseHover, AddressOf tsbButtonClick
					End If
				Next
				'
			End Sub
			
		*/

		// APPLICATION EXIT
		// =============================================================================
		private void btnSair_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// APPLICATION MINIMIZE
		// =============================================================================
		private void btnMinimizer_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		// OPEN ESCRITURA
		// =============================================================================
		private void btnBiblia_Click(object sender, EventArgs e)
		{
			//frmLeitura f = new frmLeitura();
			//f.Show();
			Visible = false;
		}

		// OPEN HARPA
		// =============================================================================
		private void btnHarpa_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//Form f = new Harpa.frmHarpa();
				//f.Show();
				Visible = false;

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de Hinos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// OPEN CONFIG
		// =============================================================================
		private void btnConfig_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Form f = new Config.frmConfig(this);
				MenuEnabled(false);
				f.MdiParent = this;
				f.Show();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de Configuração..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}
		private void btnEntradas_ButtonClick(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//Form f = new Louvor.frmLouvorLista();
				//f.Show();
				//Visible = false;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de Louvores..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSaidas_ButtonClick(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//Form f = new Louvor.frmLouvorLista();
				//f.Show();
				//Visible = false;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de Louvores..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion

		#region OTHER FUNCTIONS

		public void MenuEnabled(bool IsEnabled)
		{
			mnuPrincipal.Enabled = IsEnabled;
			btnConfig.Enabled = IsEnabled;
		}


		#endregion

		#region MENU FUNCOES

		private void mnuCongregacoes_Click(object sender, EventArgs e)
		{
			frmCongregacaoListagem frm = new frmCongregacaoListagem();
			frm.MdiParent = this;
			DesativaMenuPrincipal();
			frm.Show();
		}

		private void mnuSetores_Click(object sender, EventArgs e)
		{
			frmCongregacaoSetorListagem frm = new frmCongregacaoSetorListagem();
			frm.MdiParent = this;
			DesativaMenuPrincipal();
			frm.Show();
		}

		#endregion

		private void mnuContribuintes_Click(object sender, EventArgs e)
		{
			frmContribuinteListagem frm = new frmContribuinteListagem(false, this);
			frm.MdiParent = this;
			DesativaMenuPrincipal();
			frm.Show();
		}

		private void mnuCredores_Click(object sender, EventArgs e)
		{
			frmCredorListagem frm = new frmCredorListagem(false, this);
			frm.MdiParent = this;
			DesativaMenuPrincipal();
			frm.Show();
		}
	}
}
