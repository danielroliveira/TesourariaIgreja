using CamadaBLL;
using CamadaDTO;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Registres
{
	public partial class frmContribuinte : CamadaUI.Modals.frmModFinBorder
	{
		private objContribuinte _contribuinte;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private Form _formOrigem;
		public objContribuinte propEscolha { get; set; }

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuinte(objContribuinte obj, Form formOrigem)
		{
			InitializeComponent();

			_contribuinte = obj;
			_formOrigem = formOrigem;
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
			txtCongregacao.Enter += text_Enter;

			txtContribuinte.Validating += (a, b) => PrimeiraLetraMaiuscula(txtContribuinte);
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
			//MessageBox.Show("alterado");
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
				txtContribuinte.Focus();
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

				if (response != DialogResult.Yes) return;

				//--- check origem
				if (_formOrigem == null || _formOrigem.GetType() == typeof(frmPrincipal)) // return to frmPrincipal
				{
					AutoValidate = AutoValidate.Disable;
					Close();
					MostraMenuPrincipal();
				}
				else // return to formOrigem
				{
					propEscolha = null;
					DialogResult = DialogResult.Cancel;
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

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnCongregacaoEscolher_Click(object sender, EventArgs e)
		{

			Congregacoes.frmCongregacaoProcura frm = new Congregacoes.frmCongregacaoProcura(this, _contribuinte.IDCongregacao);
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
					_contribuinte.IDContribuinte = ID;
					lblID.DataBindings["Text"].ReadValue();
				}
				else
				{
					//--- update
					cBLL.UpdateContribuinte(_contribuinte);
				}

				//--- change Sit
				_contribuinte.EndEdit();
				Sit = EnumFlagEstado.RegistroSalvo;

				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);

				//--- Return value
				if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
				{
					propEscolha = _contribuinte;
					DialogResult = DialogResult.OK;
				}

			}
			catch (AppException ex)
			{
				AbrirDialog("Uma duplicação de registro irá acontecer ao Salvar Registro de Contribuinte..." + "\n" +
							ex.Message, "Duplicação", DialogType.OK, DialogIcon.Exclamation);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Contribuinte..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Warning);
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

			string CPFnumber = txtCNP.Text.Replace("-", "").Replace(".", "").Replace("_", "").Trim();

			if (string.IsNullOrEmpty(CPFnumber))
			{
				var resp = AbrirDialog("Não foi informado o CPF do contribuinte," +
					"\n Se você deseja inserir um contribuinte sem informar o CPF, pressione OK...",
							"CPF Vazio!",
							DialogType.OK_CANCELAR,
							DialogIcon.Question, DialogDefaultButton.Second);

				if (resp == DialogResult.Cancel) return false;

			}
			else if (!ValidacaoCNP.ValidaCNP(_contribuinte.CNP))
			{
				AbrirDialog("CPF inválido,\n favor inserir um CPF válido...",
					"CPF inválido!",
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
				Control[] controlesBloqueados = {
					txtCongregacao
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
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = { txtCongregacao };

				if (controlesBloqueados.Contains(ctr))
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

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				if (_formOrigem.GetType() != typeof(frmPrincipal))
				{
					Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
					pnl.BackColor = Color.Silver;
				}
				else
				{
					DesativaMenuPrincipal();
				}
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				if (_formOrigem.GetType() != typeof(frmPrincipal))
				{
					Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
					pnl.BackColor = Color.SlateGray;
				}
				else
				{
					MostraMenuPrincipal();
				}

			}
		}

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void text_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= text_Enter;
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
