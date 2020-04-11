using System;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaUI.Contas;
using CamadaUI.Setores;
using CamadaUI.Registres;
using System.Xml;
using CamadaDTO;
using System.Drawing;

namespace CamadaUI.Config
{
	public partial class frmConfigGeral : Modals.frmModConfig
	{
		private int? _IDCongregacao;
		private int? _IDConta;
		private int? _IDSetor;

		#region SUB NEW | LOAD

		// SUB NEW | CONSTRUCTOR
		public frmConfigGeral()
		{
			InitializeComponent();
			LoadConfig();

			HandlerKeyDownControl(this);
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
				_IDCongregacao = string.IsNullOrEmpty(strIDCong) ? null : int.Parse(strIDCong) as int?;
				txtCongregacaoPadrao.Text = LoadNode(doc, "CongregacaoDescricao");

				// CONTA
				string strIDConta = LoadNode(doc, "ContaPadrao");
				_IDConta = string.IsNullOrEmpty(strIDConta) ? null : int.Parse(strIDConta) as int?;
				txtContaPadrao.Text = LoadNode(doc, "ContaDescricao");

				// SETOR
				string strIDSetor = LoadNode(doc, "SetorPadrao");
				_IDSetor = string.IsNullOrEmpty(strIDSetor) ? null : int.Parse(strIDSetor) as int?;
				txtSetorPadrao.Text = LoadNode(doc, "SetorDescricao");

				// DATA BLOQUEIO | DATA PADRAO
				lblDataBloqueio.Text = LoadNode(doc, "DataBloqueada");
				string DataPadrao = LoadNode(doc, "DataPadrao");
				dtpDataPadrao.Value = string.IsNullOrEmpty(DataPadrao) ? DateTime.Today : Convert.ToDateTime(DataPadrao);

				// CIDADE PADRAO
				txtCidadePadrao.Text = LoadNode(doc, "CidadePadrao");

				// UF PADRAO
				txtUFPadrao.Text = LoadNode(doc, "UFPadrao");

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

		// FORM KEYPRESS: BLOQUEIA (+)
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtCongregacaoPadrao, txtContaPadrao, txtSetorPadrao
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

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
				SaveConfigValorNode("CongregacaoDescricao", txtCongregacaoPadrao.Text);
				SaveConfigValorNode("CongregacaoPadrao", _IDCongregacao.ToString());
				SaveConfigValorNode("ContaDescricao", txtContaPadrao.Text);
				SaveConfigValorNode("ContaPadrao", _IDConta.ToString());
				SaveConfigValorNode("SetorDescricao", txtSetorPadrao.Text);
				SaveConfigValorNode("SetorPadrao", _IDSetor.ToString());
				SaveConfigValorNode("DataPadrao", dtpDataPadrao.Value.ToShortDateString());
				SaveConfigValorNode("CidadePadrao", txtCidadePadrao.Text);
				SaveConfigValorNode("UFPadrao", txtUFPadrao.Text);

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

		private bool VerificaControles()
		{
			if (!VerificaControle(txtIgrejaTitulo, "TÍTULO DA IGREJA")) return false;
			if (!VerificaControle(dtpDataPadrao, "DATA PADRÃO")) return false;
			if (!VerificaControle(txtCongregacaoPadrao, "CONGREGAÇÃO PADRÃO")) return false;
			if (!VerificaControle(txtContaPadrao, "CONTA PADRÃO")) return false;
			if (!VerificaControle(txtSetorPadrao, "SETOR PADRÃO")) return false;
			if (!VerificaControle(txtCidadePadrao, "CIDADE PADRÃO")) return false;
			if (!VerificaControle(txtUFPadrao, "UF PADRÃO")) return false;

			return true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			LoadConfig();
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCongregacaoPadrao":
						btnFilialAlterar_Click(sender, new EventArgs());
						break;
					case "txtContaPadrao":
						btnContaAlterar_Click(sender, new EventArgs());
						break;
					case "txtSetorPadrao":
						btnSetorAlterar_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = { txtCongregacaoPadrao, txtContaPadrao, txtSetorPadrao };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		private void btnContaAlterar_Click(object sender, EventArgs e)
		{
			frmConfig config = Application.OpenForms.OfType<frmConfig>().First();

			frmContaProcura frm = new frmContaProcura(this, _IDConta);

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
				txtContaPadrao.Text = frm.propEscolha.Conta;
				_IDConta = frm.propEscolha.IDConta;
			}

			// focus control
			txtContaPadrao.Focus();
		}

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

		private void btnFilialAlterar_Click(object sender, EventArgs e)
		{
			frmConfig config = Application.OpenForms.OfType<frmConfig>().First();

			frmCongregacaoProcura fProc = new frmCongregacaoProcura(this, _IDCongregacao);

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
				txtCongregacaoPadrao.Text = fProc.propEscolha.Congregacao;
				_IDCongregacao = fProc.propEscolha.IDCongregacao;
			}

			// focus control
			txtCongregacaoPadrao.Focus();
		}

		private void btnFilialEditar_Click(object sender, EventArgs e)
		{
			Form config = Application.OpenForms.OfType<frmConfig>().First();

			frmCongregacaoListagem frmList = new frmCongregacaoListagem(this);

			// disable forms
			this.Visible = false;
			config.Visible = false;
			// show
			frmList.ShowDialog();

			if (frmList.DialogResult == DialogResult.Yes)
			{
				frmCongregacao frmC = new frmCongregacao(frmList.propEscolha);
				DesativaMenuPrincipal();
				frmC.ShowDialog();
			}

			// return
			config.Visible = true;
			this.Visible = true;
			// focus control
			txtCongregacaoPadrao.Focus();
		}

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
				txtSetorPadrao.Text = fProc.propEscolha.Setor;
				_IDSetor = fProc.propEscolha.IDSetor;
			}

			// focus control
			txtSetorPadrao.Focus();
		}

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
			txtCongregacaoPadrao.Focus();
		}
	}
}
