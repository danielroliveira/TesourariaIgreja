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
	public partial class frmDespesaAPagarItem : CamadaUI.Modals.frmModFinBorder
	{
		private List<objAPagarForma> listFormas;
		private Form _formOrigem;
		private DateTime _minVencimento;
		private decimal _maxValor;
		private ErrorProvider EP = new ErrorProvider(); // default error provider
		private objAPagar _Pag;
		private BindingSource bind = new BindingSource();

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaAPagarItem(objAPagar APagar, decimal maxValor, DateTime minVencimento, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			GetFormasList();

			_Pag = APagar;
			bind.DataSource = _Pag;
			BindingCreator();

			_minVencimento = minVencimento;
			_maxValor = maxValor;
			dtpVencimento.MinDate = minVencimento;

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

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			txtIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAPagarForma.DataBindings.Add("Text", bind, "APagarForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpVencimento.DataBindings.Add("Value", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			txtAPagarValor.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		#endregion // DATABINDING --- END

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			//--- check minVencimento
			if (dtpVencimento.Value < _minVencimento)
			{
				AbrirDialog("A Data de Vencimento não pode ser anterior à Data da Despesa...\n" +
					$"Data da Despesa: {_minVencimento.ToShortDateString()}",
					"Data de Vencimento", DialogType.OK, DialogIcon.Exclamation);
				dtpVencimento.Focus();
				return;
			}

			//--- check maxValor
			if (_Pag.APagarValor > _maxValor)
			{
				AbrirDialog("O Valor da Parcela de APagar não pode ser maior do que:\n" +
					$"{_maxValor:c}",
					"Valor da Parcela", DialogType.OK, DialogIcon.Exclamation);
				txtAPagarValor.Focus();
				return;
			}

			//--- check forma if is CARTAO check DAY of vencimento
			objAPagarForma forma = listFormas.First(x => x.IDAPagarForma == _Pag.IDAPagarForma);

			if (forma.IDPagFormaModo == 3) // caso cartão
			{
				// check vencimento day
				if (dtpVencimento.Value.Day != forma.CartaoCredito.VencimentoDia)
				{
					AbrirDialog("O Dia da data de vencimento precisa ser igual o dia de Vencimento do Cartão selecionado:" +
						$"\n\nO Dia de Vencimento do cartão é: {forma.CartaoCredito.VencimentoDia:D2}" +
						$"\n\nFavor alterar o dia do primeiro vencimento...",
						"Dia do Vencimento",
						DialogType.OK,
						DialogIcon.Exclamation);
					dtpVencimento.Focus();
					return;
				}
			}

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
						_Pag.IDBanco = null;
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

		// ON ENTER FORMAT APAGAR VALOR
		private void tspMenu_Enter(object sender, EventArgs e)
		{
			txtAPagarValor.DataBindings["Text"].ReadValue();
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

				frmBancoProcura frm = new frmBancoProcura(this, _Pag.IDBanco == 0 ? null : _Pag.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					_Pag.IDBanco = (int)frm.propEscolha.IDBanco;
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
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _Pag.IDAPagarForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_Pag.IDAPagarForma = (int)frm.propEscolha.Key;
				_Pag.APagarForma = frm.propEscolha.Value;
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
