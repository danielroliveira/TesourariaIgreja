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
using System.Linq;

namespace CamadaUI.Registres
{
	public partial class frmContribuinte : CamadaUI.Modals.frmModFinBorder
	{
		private objContribuinte _contribuinte;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuinte(objContribuinte obj)
		{
			InitializeComponent();

			_contribuinte = obj;
			bind.DataSource = _contribuinte;
			BindingCreator();

			_contribuinte.PropertyChanged += RegistroAlterado;

			if (_contribuinte.IDCongregacao == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			AtivoButtonImage();

			// ADD HANDLERS
			HandlerKeyDownControl(this);
			txtIDMembro.LostFocus += TxtIDMembro_LostFocus;
			txtIDMembro.GotFocus += TxtIDMembro_GotFocus;

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
			lblID.DataBindings.Add("Text", bind, "IDContribuinte", true);
			txtContribuinte.DataBindings.Add("Text", bind, "Contribuinte", true, DataSourceUpdateMode.OnPropertyChanged);
			txtIDMembro.DataBindings.Add("Text", bind, "IDMembro", true, DataSourceUpdateMode.OnPropertyChanged);
			txtNascimentoData.DataBindings.Add("Text", bind, "NascimentoData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTelefoneCelular.DataBindings.Add("Text", bind, "TelefoneCelular", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCNP.DataBindings.Add("Text", bind, "CNP", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCongregacao.DataBindings.Add("Text", bind, "Congregacao");

			// CARREGA COMBOS
			CarregaCmbDizimista();

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtIDMembro.DataBindings["Text"].Format += FormatID;
			bind.CurrentChanged += BindRegistroChanged;

		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}
		}
		private void BindRegistroChanged(object sender, EventArgs e)
		{
			MessageBox.Show("alterado");
		}

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaCmbDizimista()
		{
			//--- Create DataTable
			DataTable dtAtivo = new DataTable();
			dtAtivo.Columns.Add("Ativo");
			dtAtivo.Columns.Add("Texto");
			dtAtivo.Rows.Add(new object[] { false, "NÃO" });
			dtAtivo.Rows.Add(new object[] { true, "SIM" });

			//--- Set DataTable
			cmbDizimista.DataSource = dtAtivo;
			cmbDizimista.ValueMember = "Ativo";
			cmbDizimista.DisplayMember = "Texto";
			cmbDizimista.DataBindings.Add("SelectedValue", bind, "Dizimista", true, DataSourceUpdateMode.OnPropertyChanged);
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

			Close();
			MostraMenuPrincipal();
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
					AutoValidate = AutoValidate.Disable;
					Close();
					MostraMenuPrincipal();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				_contribuinte.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
				AtivoButtonImage();
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		// OPEN SETOR PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnCongregacaoEscolher_Click(object sender, EventArgs e)
		{

			frmCongregacaoProcura frm = new frmCongregacaoProcura(this, _contribuinte.IDCongregacao);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_contribuinte.IDCongregacao = frm.propEscolha.IDCongregacao;
				txtCongregacao.Text = frm.propEscolha.Congregacao;
			}

			//--- select
			txtCongregacao.Focus();
			txtCongregacao.SelectAll();

		}

		// CONTROLA ATIVO BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR um Novo Contribuinte", "Desativar Contribuinte",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_contribuinte.Ativo == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR o Contribuinte:\n" +
							   txtContribuinte.Text.ToUpper(),
							   "Desativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR o Contribuinte:\n" +
							   txtContribuinte.Text.ToUpper(),
							   "Ativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_contribuinte.BeginEdit();
			_contribuinte.Ativo = !_contribuinte.Ativo;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		// CONTROLA IMAGEM CONTROLE ATIVO
		//------------------------------------------------------------------------------------------------------------
		private void AtivoButtonImage()
		{
			try
			{
				if (_contribuinte.Ativo == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativo";
				}
				else if (_contribuinte.Ativo == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativo";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar o Contribuinte..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
		}

		// NOVO REGISTRO INSERIR
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_contribuinte = new objContribuinte(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _contribuinte;
			txtContribuinte.Focus();
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

				ContribuinteBLL cBLL = new ContribuinteBLL();

				if (_contribuinte.IDContribuinte == null)
				{
					//--- save | Insert
					int ID = cBLL.InsertContribuinte(_contribuinte);
					//--- define newID
					_contribuinte.IDCongregacao = ID;
				}
				else
				{
					//--- update
					cBLL.UpdateContribuinte(_contribuinte);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Contribuinte..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// CHECK DATA BEFORE SAVE
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtContribuinte, "Contribuinte", _contribuinte)) return false;

			if (!ValidacaoCNP.ValidaCNP(_contribuinte.CNP))
			{
				AbrirDialog("CPF ou CNPJ inválido,\n favor inserir um CPF/CNPJ válido...",
					"CPF ou CNPJ inválido!",
					DialogType.OK,
					DialogIcon.Warning);
				txtCNP.Focus();
				return false;
			}

			return true;
		}

		#endregion

		#region FORM CONTROLS FUCTIONS

		// FORM KEYPRESS: BLOQUEIA (+)
		//------------------------------------------------------------------------------------------------------------
		private void frmContribuinte_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				string[] controlesBloqueados = {
					"txtCongregacao"
				};

				if (controlesBloqueados.Contains(ActiveControl.Name)) e.Handled = true;
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
					case "txtSetor":
						if (_contribuinte.IDCongregacao != null) Sit = EnumFlagEstado.Alterado;
						txtCongregacao.Clear();
						_contribuinte.IDCongregacao = null;
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

		// DIGITA SOMENTE NUMEROS
		//------------------------------------------------------------------------------------------------------------
		private void txtIDMembro_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
				e.Handled = true;
		}

		// VALIDA O ID MEMBRO
		//------------------------------------------------------------------------------------------------------------
		private void txtIDMembro_Validating(object sender, CancelEventArgs e)
		{
			if (txtIDMembro.Text.Length == 0)
			{
				e.Cancel = false;
			}
		}

		// GOT LOST FOCUS IDMEMBRO
		//------------------------------------------------------------------------------------------------------------
		private void TxtIDMembro_LostFocus(object sender, EventArgs e)
		{
			AutoValidate = AutoValidate.EnablePreventFocusChange;
		}

		private void TxtIDMembro_GotFocus(object sender, EventArgs e)
		{
			AutoValidate = AutoValidate.EnableAllowFocusChange;
		}

		#endregion // FORM CONTROLS FUCTIONS --- END

	}
}
