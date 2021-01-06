using CamadaDTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Comissoes
{
	public partial class frmComissaoQuitarInfo : CamadaUI.Modals.frmModFinBorder
	{
		private Form _formOrigem;
		private decimal _ValorTotal;
		private ErrorProvider EP = new ErrorProvider(); // default error provider
		public objConta propContaEscolhida { get; set; }
		public DateTime propDataEscolhida { get; set; }
		public string propObservacao { get; set; }

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmComissaoQuitarInfo(objComissao comissao, decimal ValorTotal, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			_ValorTotal = ValorTotal;

			lblValorTotal.Text = ValorTotal.ToString("C");
			lblColaborador.Text = comissao.Credor;
			lblSetor.Text = comissao.Setor;

			DefineConta(ContaPadrao());

			// handlers
			HandlerKeyDownControl(this);
		}

		#endregion

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			//--- check data
			if (!CheckSaveData()) return;

			//--- define props values
			propDataEscolhida = dtpDespesaData.Value;
			propObservacao = txtObservacao.Text;

			DialogResult = DialogResult.OK;
		}

		// CHECK INSERTED DATA
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			// check conta
			if (propContaEscolhida == null)
			{
				AbrirDialog("Favor escolher uma Conta de Débito para criar o pagamento...",
					"Escolher Conta", DialogType.OK, DialogIcon.Exclamation);
				txtConta.Focus();
				return false;
			}

			// check conta saldo
			if (propContaEscolhida.ContaSaldo < _ValorTotal)
			{
				AbrirDialog("A Saldo Total da conta escolhida é menor que " +
					"o valor necessário para quitar o pagamento que seria criado...",
					"Saldo Insuficiente", DialogType.OK, DialogIcon.Exclamation);
				txtConta.Focus();
				return false;
			}

			// check data
			if (propContaEscolhida.BloqueioData != null && dtpDespesaData.Value < propContaEscolhida.BloqueioData)
			{
				AbrirDialog("A Data escolhida para o pagamento está bloqueada na CONTA escolhida..." +
					"Favor definir uma data posterior ou igual à data de bloqueio.",
					"Data Bloqueada", DialogType.OK, DialogIcon.Exclamation);
				dtpDespesaData.Focus();
				return false;
			}

			return true;
		}

		// FECHAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtConta
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
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
				Control[] controlesBloqueados = {
					txtConta,
				};

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, propContaEscolhida.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					DefineConta(frm.propEscolha);
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

		private void DefineConta(objConta conta)
		{
			propContaEscolhida = conta;
			txtConta.Text = propContaEscolhida.Conta;
			lblContaDetalhe.Text = $"Saldo da Conta: {propContaEscolhida.ContaSaldo:c} \n" +
								   $"Data de Bloqueio até: {propContaEscolhida.BloqueioData?.ToShortDateString() ?? ""}";
		}

		#endregion // BUTTONS PROCURA --- END

		#region DESIGN FORM FUNCTIONS

		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END
	}
}
