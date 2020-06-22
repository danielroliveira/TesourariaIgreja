using CamadaBLL;
using CamadaDTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Caixa
{
	public partial class frmCaixaInserir : CamadaUI.Modals.frmModFinBorder
	{
		private objCaixa lastCaixa;
		private objConta ContaSelected;
		private Form _formOrigem;
		private CaixaBLL cBLL = new CaixaBLL();

		#region SUB NEW | CONSTRUCTOR

		public frmCaixaInserir(Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;

			// HANDLER to use TAB for ENTER
			HandlerKeyDownControl(this);

			lblDataFinalText.Location = new Point(134, 286);
		}

		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Check Conta
				if (ContaSelected == null)
				{
					AbrirDialog("Favor selecionar uma conta...", "Conta");
					txtConta.Focus();
				}

				//--- Get LAST CAIXA
				lastCaixa = cBLL.GetLastCaixa((int)ContaSelected.IDConta);

				//--- check if is situacao = iniciado
				if (lastCaixa.IDSituacao == 1)
				{
					AbrirDialog("Essa conta possui um caixa que ainda não foi finalizado...",
						"Caixa Não Finalizado");

					//--- OPEN FORM CAIXA
					try
					{
						//--- open form
						var frm = new frmCaixa(lastCaixa, Application.OpenForms[0]);
						frm.Show();

						Close();
					}
					catch (Exception ex)
					{
						AbrirDialog("Uma exceção ocorreu ao Inserir o novo Caixa..." + "\n" +
									ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
					}
					finally
					{
						// --- Ampulheta OFF
						Cursor.Current = Cursors.Default;
					}

					return;
				}

				PreecheCampos();
				btnEfetuar.Enabled = true;
			}
			catch (AppException ex)
			{
				AbrirDialog(ex.Message, "Aviso", DialogType.OK, DialogIcon.Exclamation);
				btnEfetuar.Enabled = false;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter as informações do caixa anterior..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				btnEfetuar.Enabled = false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void PreecheCampos()
		{
			if (lastCaixa == null)
			{
				AbrirDialog("É necessário escolher a conta bancária para finalização", "Escolha a conta");
				return;
			}

			if (rbtPeriodo.Checked)
			{
				dtpDataFinal.MaxDate = lastCaixa.DataFinal;
				dtpDataFinal.MinDate = lastCaixa.DataInicial;
				dtpDataFinal.Value = lastCaixa.DataFinal;
				lblDataInicial.Text = lastCaixa.DataInicial.ToShortDateString();
				lblDataFinalText.Text = lastCaixa.DataFinal.ToShortDateString();
				lblMaxDate.Text = "máx.: " + lastCaixa.DataFinal.ToShortDateString();
			}
			else // diario
			{
				dtpDataFinal.MaxDate = lastCaixa.DataInicial;
				dtpDataFinal.MinDate = lastCaixa.DataInicial;
				dtpDataFinal.Value = lastCaixa.DataInicial;
				lblDataInicial.Text = lastCaixa.DataInicial.ToShortDateString();
				lblDataFinalText.Text = lastCaixa.DataInicial.ToShortDateString();
				lblMaxDate.Text = "máx.: " + lastCaixa.DataInicial.ToShortDateString();
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTON FUNCTIONS

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, ContaSelected?.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					ContaSelected = frm.propEscolha;
					txtConta.Text = frm.propEscolha.Conta;
					lblContaDetalhe.Text = $"Saldo da Conta: {frm.propEscolha.ContaSaldo.ToString("c")} \n" +
						$"Data de Bloqueio até: {frm.propEscolha.BloqueioData?.ToString() ?? ""}";

					ObterDados();
				}

				//--- select
				txtConta.Focus();
				txtConta.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTON FUNCTIONS --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		private void btnEfetuar_Click(object sender, EventArgs e)
		{
			var newCaixa = new objCaixa(null)
			{
				DataFinal = dtpDataFinal.Value,
				DataInicial = lastCaixa.DataInicial,
				IDConta = (int)ContaSelected.IDConta,
				CaixaFinalDoDia = false,
				Conta = ContaSelected.Conta,
				ContaBloqueioData = ContaSelected.BloqueioData,
				ContaSaldo = ContaSelected.ContaSaldo,
				FechamentoData = DateTime.Today,
				IDSituacao = 1,
				SaldoAnterior = lastCaixa.SaldoFinal,
				SaldoFinal = 0,
				Situacao = "Iniciado",
				IDUsuario = (int)Program.usuarioAtual.IDUsuario,
				UsuarioApelido = Program.usuarioAtual.UsuarioApelido,
				Observacao = ""
			};

			//--- INSERT NEW CAIXA
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var cBLL = new CaixaBLL();
				newCaixa.IDCaixa = new CaixaBLL().InsertCaixa(newCaixa);

				//--- open form
				var frm = new frmCaixa(newCaixa, Application.OpenForms[0]);
				frm.Show();

				Close();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Inserir o novo Caixa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		#endregion // BUTTONS FUNCTION --- END

		#region CONTROLS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtConta,
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
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
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = { txtConta, };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		private void rbtPeriodo_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtPeriodo.Checked)
			{
				dtpDataFinal.Visible = true;
				lblDataFinalText.Visible = false;
			}
			else
			{
				dtpDataFinal.Visible = false;
				lblDataFinalText.Visible = true;
			}
			PreecheCampos();
		}

		#endregion // CONTROLS --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;

			}
		}

		// CONTROLA TOOLTIP
		//------------------------------------------------------------------------------------------------------------
		private void ShowToolTip(Control control)
		{
			//--- Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip();

			//--- Define o delay para a ToolTip.
			toolTip1.AutoPopDelay = 2000;
			toolTip1.InitialDelay = 2000;
			toolTip1.ReshowDelay = 500;
			toolTip1.IsBalloon = true;
			toolTip1.UseAnimation = true;
			toolTip1.UseFading = true;

			if (string.IsNullOrEmpty(control.Tag.ToString()))
				toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000);
			else
				toolTip1.Show(control.Tag.ToString(), control, control.Width - 30, -40, 2000);
		}

		private void btnProcurar_EnabledChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;

			if (control.Enabled == true)
				ShowToolTip(control);
		}






		#endregion // DESIGN FORM FUNCTIONS --- END






	}
}
