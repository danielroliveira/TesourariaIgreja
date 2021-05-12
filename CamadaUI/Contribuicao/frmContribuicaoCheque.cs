using CamadaBLL;
using CamadaDTO;
using CamadaUI.Caixa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Contribuicao
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
		public frmContribuicaoCheque(ref objContribuicaoCheque cheque, Form formOrigem)
		{
			InitializeComponent();

			if (cheque.IDContribuicao != null)
			{
				_cheque = GetCheque((long)cheque.IDContribuicao);
			}
			else
			{
				_cheque = cheque;
			}

			_formOrigem = formOrigem;
			GetBancosList();

			// binding
			bind.DataSource = typeof(objContribuicaoCheque);
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

		// GET CONTRIBUICAO CHEQUE
		//------------------------------------------------------------------------------------------------------------
		private objContribuicaoCheque GetCheque(long IDContribuicao)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				return new ContribuicaoBLL().GetContribuicaoCheque(IDContribuicao);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter os dados do Cheque..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
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

				if (value == EnumFlagEstado.NovoRegistro)
				{
					btnOK.Enabled = true;
					btnCancelar.Enabled = true;
					btnCancelar.Text = "Cancelar";
					lblSitBlock.Visible = false;
				}
				else
				{
					btnOK.Enabled = false;
					btnCancelar.Enabled = true;
					btnCancelar.Text = "Fechar";
					dtpDepositoData.MaxDate = _cheque.DepositoData;
					dtpDepositoData.MinDate = _cheque.DepositoData;
					lblSitBlock.Visible = true;
				}

				// btnSET
				btnSetBanco.Enabled = value == EnumFlagEstado.NovoRegistro;
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
				(int.Parse(e.Value.ToString())).ToString("D6");
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
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
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

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void control_KeyDown_Block(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------
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

				frmBancoProcura frm = new frmBancoProcura(this, _cheque.IDBanco == 0 ? null : (int?)_cheque.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _cheque.IDBanco != frm.propEscolha.IDBanco)
						Sit = EnumFlagEstado.Alterado;

					_cheque.IDBanco = (int)frm.propEscolha.IDBanco;
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
