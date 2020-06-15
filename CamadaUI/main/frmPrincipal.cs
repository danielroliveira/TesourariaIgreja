using CamadaBLL;
using CamadaDTO;
using CamadaUI.APagar;
using CamadaUI.AReceber;
using CamadaUI.Main;
using CamadaUI.Saidas;
using System;
using System.IO;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI
{
	public partial class frmPrincipal : Form
	{
		private DateTime _DataPadrao;
		private objConta _ContaPadrao;
		private objSetor _SetorPadrao;

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
			mnuPrincipal.Enabled = false;

			//--- VERIFICA SE EXISTE CONFIG DO CAMINHO DO BD
			//------------------------------------------------------------------------------------------------------------
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
				//------------------------------------------------------------------------------------------------------------
				Main.frmLogin frmLog = new Main.frmLogin();
				objConta contaInicial = new objConta(null);

				frmLog.ShowDialog();

				if (frmLog.DialogResult == DialogResult.No)
				{
					Application.Exit();
					return;
				}

				//--- VERFICA SE O ARQUIVO DE CONFIG FOI ENCONTRADO
				//------------------------------------------------------------------------------------------------------------
				if (VerificaConfig() == false)
				{
					Application.Exit();
					return;
				}

				// VERIFICA AND GET CONTA PADRAO
				//------------------------------------------------------------------------------------------------------------
				contaInicial = VerificaAndGet_ContaAndCongregacao();

				if (contaInicial == null || contaInicial.IDConta == null)
				{
					Application.Exit();
					return;
				}

				// VERIFICA AND GET SETOR PADRAO
				//------------------------------------------------------------------------------------------------------------

				propSetorPadrao = VerificaAndGet_Setor();

				// DETERMINA A CONTA ATIVA | CONGREGACAO ATIVA | DATAPADRAO
				//------------------------------------------------------------------------------------------------------------
				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;

					if (contaInicial.IDConta == null)
						throw new Exception("Não foi possível salvar arquivo de configuração...");

					propContaPadrao = contaInicial;

					//--- configurar DATAPADRAO
					if (contaInicial.BloqueioData != null)
					{
						//--  adiciona um dia à data do caixa final ???
						DateTime dtPadrao = (DateTime)contaInicial.BloqueioData;
						//dtPadrao = dtPadrao.AddDays(1)

						//-- verifica se a data adicionada é DOMINGO, sendo adiciona um dia
						if (dtPadrao.DayOfWeek == DayOfWeek.Sunday) dtPadrao.AddDays(1);

						//-- define a propriedade DATA PADRAO
						propDataPadrao = dtPadrao;
					}
					else
					{
						AbrirDialog("A CONTA PADRÃO escolhida: " + contaInicial.Conta.ToUpper() + "\n" +
									"ainda não tem data de bloqueio definida...\n" +
									"Logo a DATA PADRÃO do sistema será escolhida para " +
									"DATA ATUAL: " + string.Format("dd de MMMM de yyyy", DateTime.Now),
									"Data Padrão",
									DialogType.OK,
									DialogIcon.Exclamation);

						propDataPadrao = DateTime.Today;
					}
				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Determinar a Conta Ativa..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
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

			//--- HABILITA A VERSAO E O TITULO
			//----------------------------------------------------------------
			string Versao = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			lblVersao.Text = Versao;

			//-- HABILITA O MENU
			//----------------------------------------------------------------
			mnuPrincipal.Enabled = true;

			//--- ATUALIZA O MENU CONFORME O USUARIO ACESSO
			//----------------------------------------------------------------
			MenuUserAcesso();

			//---- INICIALIZA O TIMER DA HORA
			//----------------------------------------------------------------
			//lblHora.Text = DateTime.Now.ToShortTimeString;

			//--- HABILITA O HANDLER DE ABERTURA DO MENU
			//----------------------------------------------------------------
			MenuOpen_Handler();
			mnuPrincipal.Focus();
			btnCadastros.Select();

			// CREATE HANDLERS TO OPEN FORM ONCLICK
			//----------------------------------------------------------------
			HandlersMenuClickToOpenForm();


		}

		#endregion

		#region PROPERTIES

		// Property Titulo da Aplicacao
		//------------------------------------------------------------------------------------------------------------
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

		// Property Conta Padrao | define Default Conta and Congregacao
		//------------------------------------------------------------------------------------------------------------
		public objConta propContaPadrao
		{
			get
			{
				return _ContaPadrao;
			}
			set
			{
				_ContaPadrao = value;

				//--- define a conta no config
				SaveDefault("ContaPadrao", value.IDConta.ToString());
				SaveDefault("ContaDescricao", value.Conta);
				SaveDefault("CongregacaoPadrao", value.IDCongregacao.ToString());
				SaveDefault("CongregacaoDescricao", value.Congregacao.ToString());

				//--- define as labels da conta e Filial
				lblConta.Text = value.Conta;
				lblFilial.Text = value.Congregacao;
			}
		}

		// Property SETOR Padrao
		//------------------------------------------------------------------------------------------------------------
		public objSetor propSetorPadrao
		{
			get
			{
				return _SetorPadrao;
			}
			set
			{
				_SetorPadrao = value;

				if (value != null)
				{
					//--- define a conta no config
					SaveDefault("SetorPadrao", value.IDSetor.ToString());
					SaveDefault("SetorDescricao", value.Setor);

					//--- define as labels da conta e Filial
					lblSetor.Text = value.Setor;
				}
				else
				{
					//--- define a conta no config
					SaveDefault("SetorPadrao", string.Empty);
					SaveDefault("SetorDescricao", string.Empty);

					//--- define as labels da conta e Filial
					lblSetor.Text = "Definir Setor Padrão";
				}
			}
		}
		// Property Data Padrao
		//------------------------------------------------------------------------------------------------------------
		public DateTime propDataPadrao
		{
			get { return _DataPadrao; }
			set
			{
				_DataPadrao = value;
				//--- define a data padrao no config
				SaveDefault("DataPadrao", value.ToShortDateString());

				//--- define a label da data padrao
				lblDataSis.Text = string.Format("dd/MM", value);
				lblDataSis.Text = $"{value.Day:00}/{value.Month:00}";
			}
		}

		#endregion // PROPERTIES --- END

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
				if (Program.usuarioAtual.UsuarioAcesso > 1) // não é administrador do sistema
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

		// VERIFICA CONTA and CONGREGACAO INICIAL
		//=================================================================================================
		private objConta VerificaAndGet_ContaAndCongregacao()
		{
			objConta conta = new objConta(null);

			if (!CheckContaPadrao(ref conta))
			{
				MessageBox.Show("Ainda não foi encontrada nenhuma CONTA PADRÃO no sistema...\n\n" +
								"Favor inserir e escolher uma CONTA padrão no arquivo do sistema",
								"Conta Padrão",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				// abre o form de config
				Config.frmConfig frmC = new Config.frmConfig(this);
				frmC.ShowDialog();

				// testa novamente
				if (!CheckContaPadrao(ref conta))
				{
					MessageBox.Show("Ainda não foi encontrado nenhuma Conta Padrão no sistema!\n" +
									"A aplicação será fechada...",
									"Conta Inespecífica",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					return null;
				}
			}

			return conta;
		}

		// CHECK CONTA PADRAO
		//------------------------------------------------------------------------------------------------------------
		private bool CheckContaPadrao(ref objConta conta)
		{
			//--- VERIFICA CONTA
			string ContaPadrao = ObterDefault("ContaPadrao");

			if (string.IsNullOrEmpty(ContaPadrao))
			{
				return false;
			}
			else
			{
				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;

					ContaBLL cBLL = new ContaBLL();
					conta = cBLL.GetConta(Convert.ToInt32(ContaPadrao));
					return (conta != null && conta.IDConta != null);
				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Obter Conta Padrao..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
					return false;
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
			}
		}

		// VERIFICA SETOR INICIAL
		//=================================================================================================
		private objSetor VerificaAndGet_Setor()
		{
			objSetor setor = new objSetor(null);

			if (!CheckSetorPadrao(ref setor))
			{
				MessageBox.Show("Ainda não foi encontrada nenhum SETOR PADRÃO no sistema...\n\n" +
								"Favor inserir e escolher um SETOR padrão no arquivo do sistema",
								"Setor Padrão",
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);

				return null;
			}

			return setor;
		}

		// CHECK SETOR PADRAO
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSetorPadrao(ref objSetor setor)
		{
			//--- VERIFICA SETOR
			string SetorPadrao = ObterDefault("SetorPadrao");
			SetorBLL sBLL = new SetorBLL();

			if (string.IsNullOrEmpty(SetorPadrao))
			{
				return false;
			}
			else
			{
				try
				{
					// --- Ampulheta ON
					Cursor.Current = Cursors.WaitCursor;

					setor = sBLL.GetSetor(Convert.ToInt32(SetorPadrao));
					return (setor != null && setor.IDSetor != null);
				}
				catch (Exception ex)
				{
					AbrirDialog("Uma exceção ocorreu ao Obter SETOR Padrao..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
					return false;
				}
				finally
				{
					// --- Ampulheta OFF
					Cursor.Current = Cursors.Default;
				}
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

		//=================================================================================================
		// PERMITIR OU PROIBIR ACESSO DOS USERS AO MENU PRINCIPAL
		//=================================================================================================
		private void MenuUserAcesso()
		{
			ToolStripSplitButton t;

			foreach (ToolStripItem c in mnuPrincipal.Items)
			{
				if (c.GetType() == typeof(ToolStripSplitButton))
				{
					t = (ToolStripSplitButton)c;

					foreach (ToolStripItem itm in t.DropDownItems)
					{
						if (itm.GetType() == typeof(ToolStripMenuItem))
						{
							switch (Program.usuarioAtual.UsuarioAcesso)
							{
								case 1: // Administrador
									itm.Enabled = true; // somente adminsitrador acesso ao config
									btnConfig.Visible = true;
									break;
								case 2: //Usuario Senior
									btnConfig.Visible = false;
									if (itm.Tag != null && Convert.ToInt32(itm.Tag) == 1)
										itm.Enabled = false;
									else
										itm.Enabled = true;
									break;
								case 3: // Usuario Comum
									btnConfig.Visible = false;
									if (itm.Tag != null && Convert.ToInt32(itm.Tag) <= 2)
										itm.Enabled = false;
									else
										itm.Enabled = true;
									break;
								case 4: // Usuario Local
									btnConfig.Visible = false;
									if (itm.Tag != null && Convert.ToInt32(itm.Tag) <= 3)
										itm.Enabled = false;
									else
										itm.Enabled = true;
									break;
								default:
									btnConfig.Visible = false;
									break;
							}
						}
					}
				}
			}
		}

		// CLICK LABEL TO DEFINE CONTA
		//------------------------------------------------------------------------------------------------------------
		private void lblConta_Click(object sender, EventArgs e)
		{
			// check if exists open forms
			if (Application.OpenForms.Count > 1)
				return;

			Contas.frmContaProcura frm = new Contas.frmContaProcura(null, propContaPadrao.IDConta);

			// show
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.OK)
			{
				// check SETOR
				if (propContaPadrao.IDCongregacao != frm.propEscolha.IDCongregacao)
				{
					AbrirDialog("Essa CONTA pertence a uma congregação diferente do SETOR padrão escolhido:\n" +
						propSetorPadrao.Setor.ToUpper() +
						"\nO Setor padrão atual será descartado. Favor definir um novo Setor...",
						"Definir Setor", DialogType.OK, DialogIcon.Exclamation);

					propSetorPadrao = null;
				}

				propContaPadrao = frm.propEscolha;
			}
		}

		// CLICK LABEL TO DEFINE SETOR
		//------------------------------------------------------------------------------------------------------------
		private void lblSetor_Click(object sender, EventArgs e)
		{
			// check if exists open forms
			if (Application.OpenForms.Count > 1)
				return;

			Setores.frmSetorProcura frm = new Setores.frmSetorProcura(null, propSetorPadrao?.IDSetor);

			// show
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.OK)
			{
				// check Conta and Congregacao
				if (propContaPadrao.IDCongregacao != frm.propEscolha.IDCongregacao)
				{
					AbrirDialog("Esse setor não pertence à CONGREGAÇÃO padrão escolhida:\n" +
						propContaPadrao.Congregacao.ToUpper() +
						"\nFavor escolher um Setor que pertence à essa congregação.",
						"Definir Setor", DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				propSetorPadrao = frm.propEscolha;
			}
		}

		// CLICK LABEL TO DEFINE DATA PADRAO
		//------------------------------------------------------------------------------------------------------------
		private void lblDataSis_Click(object sender, EventArgs e)
		{
			// check if exists open forms
			if (Application.OpenForms.Count > 1)
				return;

			frmDateGet frm = new frmDateGet("Data padrão do sistema", EnumDataTipo.PassadoPresente, _DataPadrao, null);

			// show
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.OK)
			{
				propDataPadrao = (DateTime)frm.propDataInfo;
			}
		}

		#endregion

		#region MENU FUNCOES

		private void HandlersMenuClickToOpenForm()
		{
			// MENU CADASTROS
			mnuContribuintes.Click += (a, b) => MenuClickOpenForm(new Registres.frmContribuinteListagem(false, this));
			mnuCredores.Click += (a, b) => MenuClickOpenForm(new Registres.frmCredorListagem(false, this));
			mnuCongregacoes.Click += (a, b) => MenuClickOpenForm(new Congregacoes.frmCongregacaoListagem());
			mnuSetoresCongregacao.Click += (a, b) => MenuClickOpenForm(new Congregacoes.frmCongregacaoSetorListagem());
			mnuReunioes.Click += (a, b) => MenuClickOpenForm(new Congregacoes.frmCongregacaoReuniaoListagem());

			// MENU ENTRADAS
			mnuCampanhas.Click += (a, b) => MenuClickOpenForm(new Entradas.frmCampanhaListagem());
			mnuContribuicaoInserir.Click += (a, b) => MenuClickOpenForm(new Entradas.frmContribuicao(new objContribuicao(null)));
			mnuContribuicaoProcurar.Click += (a, b) => MenuClickOpenForm(new Entradas.frmContribuicaoListagem());
			mnuAReceberProcurar.Click += (a, b) => MenuClickOpenForm(new frmAReceberListagem());

			// MENU SAIDAS
			mnuDespesaInserir.Click += (a, b) => MenuClickOpenForm(new frmDespesa(new objDespesa(null)));
			mnuDespesaTipo.Click += (a, b) => MenuClickOpenForm(new frmDespesaTipoListagem());
			mnuDespesaGrupo.Click += (a, b) => MenuClickOpenForm(new frmDespesaTipoGrupoControle());
			mnuCobrancaForma.Click += (a, b) => MenuClickOpenForm(new frmCobrancaForma());
			mnuDespesaProcurar.Click += (a, b) => MenuClickOpenForm(new frmDespesaListagem());
			mnuAPagarProcurar.Click += (a, b) => MenuClickOpenForm(new frmAPagarListagem());
			mnuDespesaPeriodicaInserir.Click += (a, b) => MenuClickOpenForm(new frmDespesaPeriodica(new objDespesaPeriodica(null)));
			mnuDespesaPeriodicaProcurar.Click += (a, b) => MenuClickOpenForm(new frmDespesaPeriodicaListagem());
			mnuDespesaRealizada.Click += (a, b) => MenuClickOpenForm(new frmGasto(new objDespesa(null)));

			// MENU MOVIMENTACAO
			mnuContaProcurar.Click += (a, b) => MenuClickOpenForm(new Contas.frmContaListagem());
			mnuContaMov.Click += (a, b) => MenuClickOpenForm(new Contas.frmContaMovimentacao());
			mnuSetores.Click += (a, b) => MenuClickOpenForm(new Setores.frmSetorListagem());
			mnuCartao.Click += (a, b) => MenuClickOpenForm(new Caixa.frmCartaoControle());
			mnuBanco.Click += (a, b) => MenuClickOpenForm(new Caixa.frmBancosControle());
		}

		private void MenuClickOpenForm(Form form)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				form.MdiParent = this;
				DesativaMenuPrincipal();
				form.Show();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion

	}
}
