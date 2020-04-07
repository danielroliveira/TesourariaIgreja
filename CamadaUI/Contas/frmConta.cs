using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaUI.Registres;
using System.Linq;

namespace CamadaUI.Contas
{
	public partial class frmConta : CamadaUI.Modals.frmModFinBorder
	{
		private objConta _conta;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private int? _IDCongregacao;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmConta(objConta obj)
		{
			InitializeComponent();

			_conta = obj;
			bind.DataSource = _conta;
			BindingCreator();
			_IDCongregacao = _conta.IDCongregacao;

			_conta.PropertyChanged += RegistroAlterado;

			if (_conta.IDConta == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			AtivoButtonImage();
			HandlerKeyDownControl(this);

			// controle do focus dos checkboxes
			chkBancaria.GotFocus += chkBox_ControleFocus;
			chkBancaria.LostFocus += chkBox_ControleFocus;
			chkOperadoraCartao.GotFocus += chkBox_ControleFocus;
			chkOperadoraCartao.LostFocus += chkBox_ControleFocus;
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
						btnNovo.Enabled = true;
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						btnAtivo.Enabled = true;
						break;
					case EnumFlagEstado.Alterado:
						btnNovo.Enabled = false;
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						btnAtivo.Enabled = true;
						break;
					case EnumFlagEstado.NovoRegistro:
						btnNovo.Enabled = false;
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						btnAtivo.Enabled = false;
						break;
					case EnumFlagEstado.RegistroBloqueado:
						btnNovo.Enabled = true;
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						btnAtivo.Enabled = false;
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
			lblID.DataBindings.Add("Text", bind, "IDConta", true);
			txtConta.DataBindings.Add("Text", bind, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCongregacao.DataBindings.Add("Text", bind, "Congregacao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblContaSaldo.DataBindings.Add("Text", bind, "ContaSaldo", true, DataSourceUpdateMode.OnPropertyChanged);
			lblBloqueioData.DataBindings.Add("Text", bind, "BloqueioData", true, DataSourceUpdateMode.OnPropertyChanged);
			chkOperadoraCartao.DataBindings.Add("Checked", bind, "OperadoraCartao", true, DataSourceUpdateMode.OnPropertyChanged);
			chkBancaria.DataBindings.Add("Checked", bind, "Bancaria", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblContaSaldo.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}
		}

		#endregion

		#region BUTTONS

		// FECHAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.Alterado || Sit == EnumFlagEstado.NovoRegistro)
			{
				AbrirDialog("Esse registro ainda não foi salvo... \n" +
					"Favor SALVAR ou CANCELAR a edição do registro atual antes de fechar.",
					"Registro Novo ou Alterado", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			new frmContaListagem().Show();
			Close();
		}

		// CANCELAR ALTERACAO
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de um novo registro?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					new frmContaListagem().Show();
					Close();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
				AtivoButtonImage();
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_conta = new objConta(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _conta;
			txtConta.Focus();
		}

		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR uma Nova Conta", "Desativar Conta",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_conta.Ativa == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR a Conta:\n" +
							   txtConta.Text.ToUpper(),
							   "Desativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR a Conta:\n" +
							   txtConta.Text.ToUpper(),
							   "Ativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_conta.BeginEdit();
			_conta.Ativa = !_conta.Ativa;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_conta.Ativa == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativa";
				}
				else if (_conta.Ativa == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativa";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar a conta..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
		}

		#endregion

		#region SAVE REGISTRY

		// SALVAR REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnSalvar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- check data
				if (!CheckSaveData()) return;

				ContaBLL cBLL = new ContaBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_conta.IDConta == null) //--- save | Insert
				{
					int ID = cBLL.InsertConta(_conta);
					//--- define newID
					_conta.IDConta = ID;
				}
				else //--- update
				{
					cBLL.UpdateConta(_conta);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Conta..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtConta, "Congregação Setor", _conta)) return false;
			return true;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmConta_KeyDown(object sender, KeyEventArgs e)
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
					case "txtCongregacao":
						btnCongregacaoEscolher_Click(sender, new EventArgs());
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
					case "txtCongregacao":
						if (_conta.IDCongregacao != null) Sit = EnumFlagEstado.Alterado;
						txtCongregacao.Clear();
						_conta.IDCongregacao = null;
						break;
					default:
						break;
				}
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				string[] controlesBloqueados = { "txtCongregacao" };

				if (controlesBloqueados.Contains(ctr.Name))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnCongregacaoEscolher_Click(object sender, EventArgs e)
		{

			frmCongregacaoProcura frm = new frmCongregacaoProcura(this, _conta.IDCongregacao);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_conta.IDCongregacao = frm.propEscolha.IDCongregacao;
				txtCongregacao.Text = frm.propEscolha.Congregacao;
			}

			//--- select
			txtCongregacao.Focus();
			txtCongregacao.SelectAll();

		}

		// WHEN SELECT RADIO CHANGE COLOR OF PANEL
		//------------------------------------------------------------------------------------------------------------
		private void chkBox_ControleFocus(object sender, EventArgs e)
		{
			pnlChk1.BackColor = Color.Transparent;
			pnlChk2.BackColor = Color.Transparent;

			if (chkBancaria.Focused)
			{
				pnlChk1.BackColor = Color.Gainsboro;
			}
			else if (chkOperadoraCartao.Focused)
			{
				pnlChk2.BackColor = Color.Gainsboro;
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

	}
}
