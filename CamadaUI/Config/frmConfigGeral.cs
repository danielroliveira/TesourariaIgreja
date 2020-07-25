using System;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaUI.Contas;
using CamadaUI.Setores;
using System.Xml;
using System.Drawing;
using CamadaDTO;
using System.IO;

namespace CamadaUI.Config
{
	public partial class frmConfigGeral : Modals.frmModConfig
	{
		private int? _IDCongregacao;
		private objConta _Conta;
		private objSetor _Setor;

		#region SUB NEW | LOAD

		// SUB NEW | CONSTRUCTOR
		public frmConfigGeral()
		{
			InitializeComponent();
			LoadConfig();

			HandlerKeyDownControl(this);

			_Conta = Application.OpenForms.OfType<frmPrincipal>().First().propContaPadrao;
			_Setor = Application.OpenForms.OfType<frmPrincipal>().First().propSetorPadrao;

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

		// CANCELAR BTN
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			LoadConfig();
		}

		// ALTERAR CONTA
		//------------------------------------------------------------------------------------------------------------
		private void btnContaAlterar_Click(object sender, EventArgs e)
		{
			frmConfig config = Application.OpenForms.OfType<frmConfig>().First();

			frmContaProcura frm = new frmContaProcura(this, _Conta?.IDConta);

			// disable forms
			this.lblTitulo.BackColor = Color.Silver;
			config.panel1.BackColor = Color.Silver;
			// show
			frm.ShowDialog();
			// return
			this.lblTitulo.BackColor = Color.SlateGray;
			config.panel1.BackColor = Color.Goldenrod;

			if (frm.DialogResult == DialogResult.OK)
			{
				Application.OpenForms.OfType<frmPrincipal>().First().propContaPadrao = frm.propEscolha;
				_Conta = frm.propEscolha;
				txtContaPadrao.Text = frm.propEscolha.Conta;

				// check SETOR
				if (_Setor != null)
				{
					if (_Setor.IDCongregacao != _Conta.IDCongregacao)
					{
						// user message
						AbrirDialog("A CONTA escolhida pertence a uma congregação diferente do SETOR padrão escolhido:\n" +
							_Setor.Setor.ToUpper() +
							"\nO Setor padrão atual será descartado. Favor definir um novo Setor...",
							"Redefinir Setor", DialogType.OK, DialogIcon.Exclamation);

						// clear controls
						txtSetorPadrao.Clear();
						_Setor = null;
						Application.OpenForms.OfType<frmPrincipal>().First().propSetorPadrao = null;
					}
				}

			}

			// focus control
			txtContaPadrao.Focus();
		}

		// EDITAR CONTA
		//------------------------------------------------------------------------------------------------------------
		private void btnContaEditar_Click(object sender, EventArgs e)
		{
			Form config = Application.OpenForms.OfType<frmConfig>().First();

			frmContaListagem frm = new frmContaListagem(this);

			// disable forms
			this.Visible = false;
			config.Visible = false;
			// show
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.Yes)
			{
				frmConta frmC = new frmConta(frm.propEscolha);
				DesativaMenuPrincipal();
				frmC.ShowDialog();
			}

			// return
			config.Visible = true;
			this.Visible = true;
			// focus control
			txtContaPadrao.Focus();
		}

		// ALTERAR SETOR
		//------------------------------------------------------------------------------------------------------------
		private void btnSetorAlterar_Click(object sender, EventArgs e)
		{
			frmConfig config = Application.OpenForms.OfType<frmConfig>().First();

			frmSetorProcura fProc = new frmSetorProcura(this, _IDCongregacao);

			// disable forms
			this.lblTitulo.BackColor = Color.Silver;
			config.panel1.BackColor = Color.Silver;
			// show
			fProc.ShowDialog();
			// return
			this.lblTitulo.BackColor = Color.SlateGray;
			config.panel1.BackColor = Color.Goldenrod;

			if (fProc.DialogResult == DialogResult.OK)
			{
				// check SETOR
				if (_Conta != null && fProc.propEscolha.IDCongregacao != _Conta.IDCongregacao)
				{
					// user message
					AbrirDialog("O SETOR escolhido pertence a uma congregação diferente da CONTA padrão atual:\n" +
						_Conta.Conta.ToUpper() +
						"\nO Setor escolhido será descartado. Favor escolher um novo Setor...",
						"Redefinir Setor", DialogType.OK, DialogIcon.Exclamation);
				}
				else
				{
					Application.OpenForms.OfType<frmPrincipal>().First().propSetorPadrao = fProc.propEscolha;
					txtSetorPadrao.Text = fProc.propEscolha.Setor;
					_Setor = fProc.propEscolha;
				}
			}

			// focus control
			txtSetorPadrao.Focus();
		}

		// EDITAR SETOR
		//------------------------------------------------------------------------------------------------------------
		private void btnSetorEditar_Click(object sender, EventArgs e)
		{
			Form config = Application.OpenForms.OfType<frmConfig>().First();

			frmSetorListagem frmList = new frmSetorListagem(this);

			// disable forms
			this.Visible = false;
			config.Visible = false;
			// show
			frmList.ShowDialog();

			if (frmList.DialogResult == DialogResult.Yes)
			{
				frmSetor frmC = new frmSetor(frmList.propEscolha);
				DesativaMenuPrincipal();
				frmC.ShowDialog();
			}

			// return
			config.Visible = true;
			this.Visible = true;

			// focus control
			txtSetorPadrao.Focus();
		}

		#endregion

		#region CONTROLS FUNCTIONS

		// FORM KEYPRESS: BLOQUEIA (+)
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtContaPadrao, txtSetorPadrao
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtContaPadrao":
						btnContaAlterar_Click(sender, new EventArgs());
						break;
					case "txtSetorPadrao":
						btnSetorAlterar_Click(sender, new EventArgs());
						break;
					case "txtImageFolder":
						btnProcImageFolder_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = { txtContaPadrao, txtSetorPadrao, txtImageFolder };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// TITULO VALIDATING
		//------------------------------------------------------------------------------------------------------------
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

		#endregion // CONTROLS FUNCTIONS --- END

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
				_IDCongregacao = string.IsNullOrEmpty(strIDCong) ? null : int.Parse(strIDCong) as int?;
				lblCongregacao.Text = LoadNode(doc, "CongregacaoDescricao");

				// CONTA
				//string strIDConta = LoadNode(doc, "ContaPadrao");
				//_Conta.IDConta = string.IsNullOrEmpty(strIDConta) ? null : int.Parse(strIDConta) as int?;
				txtContaPadrao.Text = LoadNode(doc, "ContaDescricao");

				// SETOR
				//string strIDSetor = LoadNode(doc, "SetorPadrao");
				//_Setor.IDSetor = string.IsNullOrEmpty(strIDSetor) ? null : int.Parse(strIDSetor) as int?;
				txtSetorPadrao.Text = LoadNode(doc, "SetorDescricao");

				// DATA BLOQUEIO | DATA PADRAO
				lblDataBloqueio.Text = LoadNode(doc, "DataBloqueada");
				string DataPadrao = LoadNode(doc, "DataPadrao");
				dtpDataPadrao.Value = string.IsNullOrEmpty(DataPadrao) ? DateTime.Today : Convert.ToDateTime(DataPadrao);

				// CIDADE PADRAO
				txtCidadePadrao.Text = LoadNode(doc, "CidadePadrao");

				// UF PADRAO
				txtUFPadrao.Text = LoadNode(doc, "UFPadrao");

				// IMAGES FOLDER
				txtImageFolder.Text = LoadNode(doc, "DocumentsImageFolder");

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

		#region SAVE CONFIG

		// SAVE CONFIG
		//------------------------------------------------------------------------------------------------------------
		private void btnSalvarConfig_Click(object sender, EventArgs e)
		{
			// check controls
			if (!VerificaControles()) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// save items
				SaveConfigValorNode("IgrejaTitulo", txtIgrejaTitulo.Text);
				SaveConfigValorNode("CongregacaoDescricao", lblCongregacao.Text);
				SaveConfigValorNode("CongregacaoPadrao", _IDCongregacao.ToString());
				SaveConfigValorNode("ContaDescricao", txtContaPadrao.Text);
				SaveConfigValorNode("ContaPadrao", _Conta.IDConta.ToString());
				SaveConfigValorNode("SetorDescricao", txtSetorPadrao.Text);
				SaveConfigValorNode("SetorPadrao", _Setor.IDSetor.ToString());
				SaveConfigValorNode("DataPadrao", dtpDataPadrao.Value.ToShortDateString());
				SaveConfigValorNode("CidadePadrao", txtCidadePadrao.Text);
				SaveConfigValorNode("UFPadrao", txtUFPadrao.Text);
				SaveConfigValorNode("DocumentsImageFolder", txtImageFolder.Text);

				//< DocumentsImageFolder ></ DocumentsImageFolder >

				AbrirDialog("Arquivo de Configuração Salvo com sucesso!", "Arquivo Salvo",
					DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar o arquivo de Configuração..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// VERIFICA OS CONTROLES BEFORE SAVE
		//------------------------------------------------------------------------------------------------------------
		private bool VerificaControles()
		{
			if (!VerificaControle(txtIgrejaTitulo, "TÍTULO DA IGREJA")) return false;
			if (!VerificaControle(dtpDataPadrao, "DATA PADRÃO")) return false;
			if (!VerificaControle(lblCongregacao, "CONGREGAÇÃO PADRÃO")) return false;
			if (!VerificaControle(txtContaPadrao, "CONTA PADRÃO")) return false;
			if (!VerificaControle(txtSetorPadrao, "SETOR PADRÃO")) return false;
			if (!VerificaControle(txtCidadePadrao, "CIDADE PADRÃO")) return false;
			if (!VerificaControle(txtUFPadrao, "UF PADRÃO")) return false;

			if (_Conta == null || _Conta.IDConta == null)
			{
				AbrirDialog("Favor escolher a Conta Padrão", "Conta Padrão", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}

			if (_Setor == null || _Setor.IDSetor == null)
			{
				AbrirDialog("Favor escolher o Setor Padrão", "Setor Padrão", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}

			return true;
		}

		#endregion // SAVE CONFIG --- END

		private void btnProcImageFolder_Click(object sender, EventArgs e)
		{
			try
			{
				string oldPath = txtImageFolder.Text;
				string path = "";

				// CHECK IF EXISTS DEFAULT BACKUP FOLDER
				if (oldPath == string.Empty)
				{
					string defFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
					defFolder += "\\Tesouraria\\DocumentosImagens\\";

					if (Directory.Exists(defFolder))
					{
						path = defFolder;
					}
					else
					{
						DialogResult resp = AbrirDialog("Ainda não foi criada a pasta padrão para os Documentos e Comprovantes. \n" +
							"Deseja criar a pasta padrão?",
							"Pasta de Documentos",
							DialogType.SIM_NAO,
							DialogIcon.Question);

						if (resp == DialogResult.Yes)
						{
							Directory.CreateDirectory(defFolder);
							path = defFolder;
						}
						else
						{
							path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
						}
					}
				}
				else
				{
					if (!Directory.Exists(oldPath))
					{
						oldPath = "";
						btnProcImageFolder_Click(sender, e);
						return;
					}
					else
					{
						path = oldPath;
					}
				}

				// get folder
				using (FolderBrowserDialog FBDiag = new FolderBrowserDialog()
				{
					Description = "Pasta de Imagens dos Documentos",
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

				SaveConfigValorNode("DocumentsImageFolder", path);
				txtImageFolder.Text = path;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar a pasta de Imagens dos Documentos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
		}
	}
}
