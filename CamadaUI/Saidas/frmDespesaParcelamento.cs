using CamadaBLL;
using CamadaDTO;
using CamadaUI.Caixa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmDespesaParcelamento : CamadaUI.Modals.frmModFinBorder
	{
		private List<objAPagarForma> listFormas;
		private Form _formOrigem;
		private DateTime _DataInicial;
		private ErrorProvider EP = new ErrorProvider(); // default error provider

		public int? IDBanco { get; set; }
		public string BancoNome { get; set; }
		public objAPagarForma SelPagForma { get; set; }
		public DateTime Vencimento { get; set; }

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaParcelamento(int Parcelas, DateTime DataInicial, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			GetFormasList();


			lblParcelas.Text = Parcelas.ToString("D2") + " Parcelas";
			lblVencimento.Text = Parcelas == 1 ? "Data do Vencimento" : "Primeiro Vencimento";
			_DataInicial = DataInicial;
			dtpDataVencimento.MinDate = _DataInicial;
			dtpDataVencimento.Value = _DataInicial;

			// handlers
			HandlerKeyDownControl(this);
		}

		// GET LIST OF FORMAS DE COBRANCA
		//------------------------------------------------------------------------------------------------------------
		private void GetFormasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listFormas = new APagarFormaBLL().GetListAPagarForma(true);

				if (listFormas.Count == 0)
				{
					AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...",
						"Formas de Cobrança",
						DialogType.OK,
						DialogIcon.Exclamation);
					return;
				}
				else
				{
					SelPagForma = listFormas[0];
					txtAPagarForma.Text = SelPagForma.APagarForma;
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Formas de Cobrança..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			//--- check data
			if (SelPagForma == null || SelPagForma.IDAPagarForma == null)
			{
				AbrirDialog("Favor preencher a informação da Forma de Pagamento",
					"Forma de Pagamento", DialogType.OK, DialogIcon.Exclamation);
				txtAPagarForma.Focus();
				return;
			}

			if (SelPagForma.IDPagFormaModo == 3) // caso cartão
			{
				// check vencimento day
				if (dtpDataVencimento.Value.Day != SelPagForma.CartaoCredito.VencimentoDia)
				{
					AbrirDialog("O Dia da data de vencimento precisa ser igual o dia de Vencimento do Cartão selecionado:" +
						$"\n\nO Dia de Vencimento do cartão é: {SelPagForma.CartaoCredito.VencimentoDia:D2}" +
						$"\n\nFavor alterar o dia do primeiro vencimento...",
						"Dia do Vencimento",
						DialogType.OK,
						DialogIcon.Exclamation);
					dtpDataVencimento.Focus();
					return;
				}
			}

			Vencimento = dtpDataVencimento.Value;
			BancoNome = txtBanco.Text;

			DialogResult = DialogResult.OK;
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
					txtBanco, txtAPagarForma
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
					case "txtBanco":
						btnSetBanco_Click(sender, new EventArgs());
						break;
					case "txtAPagarForma":
						btnSetForma_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtBanco":
						IDBanco = null;
						txtBanco.Clear();
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
					txtBanco, txtAPagarForma
				};

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// KEY DOWN ENTER OF NUMERIC UPDOWN
		private void num_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			};
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		// OPEN LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmBancoProcura frm = new frmBancoProcura(this, IDBanco == 0 ? null : IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					IDBanco = (int)frm.propEscolha.IDBanco;
					txtBanco.Text = frm.propEscolha.BancoNome;
				}

				//--- select
				txtBanco.Focus();
				txtBanco.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...",
					"Formas de Cobrança",
					DialogType.OK,
					DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDAPagarForma, x => x.APagarForma);
			var textBox = txtAPagarForma;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, SelPagForma.IDAPagarForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				SelPagForma = listFormas.First(x => x.IDAPagarForma == (int)frm.propEscolha.Key);
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
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
