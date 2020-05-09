using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Entradas
{
	public partial class frmContribuicaoCheque : CamadaUI.Modals.frmModFinBorder
	{
		private objContribuicaoCheque _cheque;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objBanco> listBancos;

		private Form _formOrigem;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuicaoCheque(ref objContribuicaoCheque obj, Form formOrigem)
		{
			InitializeComponent();

			_cheque = obj;
			_formOrigem = formOrigem;
			GetBancosList();

			// binding
			bind.DataSource = typeof(objContribuicaoCartao);
			bind.Add(_cheque);
			BindingCreator();

			if (_cheque.IDContribuicao == null)
				Sit = EnumFlagEstado.NovoRegistro;
			else
				Sit = EnumFlagEstado.RegistroSalvo;

			// handlers
			_cheque.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
		}

		// GET LIST OF BANCOS
		//------------------------------------------------------------------------------------------------------------
		private void GetBancosList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var bancoBLL = new BancoBLL();
				listBancos = bancoBLL.GetListBanco();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de bancos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}


		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public EnumFlagEstado Sit
		{
			get { return _Sit; }
			set
			{
				_Sit = value;
				switch (value)
				{
					case EnumFlagEstado.RegistroSalvo:
						btnOK.Enabled = false;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Fechar";
						break;
					case EnumFlagEstado.Alterado:
						btnOK.Enabled = true;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Cancelar";
						break;
					case EnumFlagEstado.NovoRegistro:
						btnOK.Enabled = true;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Cancelar";
						break;
					case EnumFlagEstado.RegistroBloqueado:
						btnOK.Enabled = false;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Fechar";
						break;
					default:
						break;
				}
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			txtBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			txtChequeNumero.DataBindings.Add("Text", bind, "ChequeNumero", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpDepositoData.DataBindings.Add("Text", bind, "DepositoData", true, DataSourceUpdateMode.OnPropertyChanged);

			txtChequeNumero.DataBindings["Text"].Format += FormatD6;
		}

		private void FormatD6(object sender, ConvertEventArgs e)
		{
			if (e.Value != null)
			{
				((byte)e.Value).ToString("D6");
			}
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}

			EP.Clear();
		}

		#endregion

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			//--- check data
			if (!CheckSaveData()) return;

			DialogResult = DialogResult.OK;
		}

		// CHECK INSERTED DATA
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtBanco, "Banco do Cheque", _cheque, EP)) return false;
			if (!VerificaDadosClasse(txtChequeNumero, "Número do Cheque", _cheque, EP)) return false;

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
					txtBanco
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

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtBanco":
						btnSetBanco_Click(sender, new EventArgs());
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
					txtBanco,
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

		// OPEN LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			if (listBancos.Count == 0)
			{
				AbrirDialog("Não há Bancos cadastrados...", "Bancos",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listBancos.ToDictionary(x => (int)x.IDBanco, x => x.BancoNome);
			var textBox = txtBanco;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _cheque.IDBanco);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_cheque.IDBanco = (byte)frm.propEscolha.Key;
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
