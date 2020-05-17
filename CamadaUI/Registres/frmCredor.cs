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

namespace CamadaUI.Registres
{
	public partial class frmCredor : CamadaUI.Modals.frmModFinBorder
	{
		private objCredor _credor;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private Form _formOrigem;
		public objCredor propEscolha { get; set; }

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmCredor(objCredor obj, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			_credor = obj;
			bind.DataSource = _credor;
			BindingCreator();
			CheckCredorTipo();

			_credor.PropertyChanged += RegistroAlterado;

			if (_credor.IDCredor == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			AtivoButtonImage();
			HandlerKeyDownControl(this);
			chkWhatsapp.GotFocus += chkWathsapp_ControleFocus;
			chkWhatsapp.LostFocus += chkWathsapp_ControleFocus;
			txtEnderecoNumero.KeyPress += txtSoNumeros_KeyPress;
			txtCNP.KeyPress += txtSoNumeros_KeyPress;
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
			lblID.DataBindings.Add("Text", bind, "IDCredor", true);
			txtCredor.DataBindings.Add("Text", bind, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCNP.DataBindings.Add("Text", bind, "CNP", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEnderecoLogradouro.DataBindings.Add("Text", bind, "EnderecoLogradouro", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEnderecoNumero.DataBindings.Add("Text", bind, "EnderecoNumero", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEnderecoComplemento.DataBindings.Add("Text", bind, "EnderecoComplemento", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBairro.DataBindings.Add("Text", bind, "Bairro", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
			txtCidade.DataBindings.Add("Text", bind, "Cidade", true, DataSourceUpdateMode.OnPropertyChanged);
			txtUF.DataBindings.Add("Text", bind, "UF", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCEP.DataBindings.Add("Text", bind, "CEP", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTelefoneFixo.DataBindings.Add("Text", bind, "TelefoneFixo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTelefoneCelular.DataBindings.Add("Text", bind, "TelefoneCelular", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEmail.DataBindings.Add("Text", bind, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
			chkWhatsapp.DataBindings.Add("Checked", bind, "Whatsapp", true, DataSourceUpdateMode.OnPropertyChanged);

			// CARREGA COMBO
			CarregaCmbCredorTipo();

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
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
		private void CarregaCmbCredorTipo()
		{
			//--- Create DataTable
			DataTable dtAtivo = new DataTable();
			dtAtivo.Columns.Add("ID");
			dtAtivo.Columns.Add("Tipo");
			dtAtivo.Rows.Add(new object[] { 1, "Pessoa Física" });
			dtAtivo.Rows.Add(new object[] { 2, "Pessoa Jurídica" });
			dtAtivo.Rows.Add(new object[] { 3, "Órgão Público" });
			dtAtivo.Rows.Add(new object[] { 4, "Credor Simples" });

			//--- Set DataTable
			cmbCredorTipo.DataSource = dtAtivo;
			cmbCredorTipo.ValueMember = "ID";
			cmbCredorTipo.DisplayMember = "Tipo";
			cmbCredorTipo.DataBindings.Add("SelectedValue", bind, "CredorTipo", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		#endregion

		#region BUTTONS

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_credor = new objCredor(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _credor;
			txtCredor.Focus();
		}

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

				if (response != DialogResult.Yes) return;

				//--- check origem
				if (_formOrigem.GetType() == typeof(frmPrincipal)) // return to frmPrincipal
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

		// CONTROLA ATIVO BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR um Novo Credor", "Desativar Credor",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_credor.Ativo == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR o Credor:\n" +
							   txtCredor.Text.ToUpper(),
							   "Desativar Credor", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR o Credor:\n" +
							   txtCredor.Text.ToUpper(),
							   "Ativar Credor", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_credor.BeginEdit();
			_credor.Ativo = !_credor.Ativo;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		// CONTROLA IMAGEM CONTROLE ATIVO
		//------------------------------------------------------------------------------------------------------------
		private void AtivoButtonImage()
		{
			try
			{
				if (_credor.Ativo == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativo";
				}
				else if (_credor.Ativo == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativo";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar o Credor..." + "\n" +
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

				CredorBLL cBLL = new CredorBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_credor.IDCredor == null) //--- save | Insert
				{
					//--- save | Insert
					int ID = cBLL.InsertCredor(_credor);
					//--- define newID
					_credor.IDCredor = ID;
				}
				else //--- update
				{
					cBLL.UpdateCredor(_credor);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);

				//--- Return value
				if (_formOrigem.GetType() != typeof(frmPrincipal))
				{
					propEscolha = _credor;
					DialogResult = DialogResult.OK;
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Credor..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// CHECK DATA TO SAVE
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtCredor, "Credor", _credor)) return false;
			if (!VerificaDadosClasse(cmbCredorTipo, "CredorTipo", _credor)) return false;

			if (_credor.CredorTipo == 1 || _credor.CredorTipo == 2) // check CNP if Credor PJ or PF
			{
				if (!VerificaDadosClasse(txtCNP, "CNP", _credor)) return false;

				if (!ValidacaoCNP.ValidaCNP(_credor.CNP))
				{
					AbrirDialog("CPF ou CNPJ inválido,\n favor inserir um CPF/CNPJ válido...",
						"CPF ou CNPJ inválido!",
						DialogType.OK,
						DialogIcon.Warning);
					txtCNP.Focus();
					return false;
				}
			}

			return true;
		}

		#endregion

		#region CONTROLS

		private void chkWathsapp_ControleFocus(object sender, EventArgs e)
		{
			if (chkWhatsapp.Focused)
				pnlChk.BackColor = Color.Gainsboro;
			else
				pnlChk.BackColor = Color.Transparent;
		}
		private void picWathsapp_Click(object sender, EventArgs e)
		{
			chkWhatsapp.Focus();
		}

		// CONTROL CHANGES COMBOBOX CREDOR TIPO
		//------------------------------------------------------------------------------------------------------------
		private void cmbCredorTipo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			cmbCredorTipo.DataBindings["SelectedValue"].WriteValue();
			CheckCredorTipo();
		}

		// CHECK CREDOR TIPO TO ENABLE OR DISABLE CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void CheckCredorTipo()
		{
			// lista de controles que serao desabilitados
			List<Control> controls = new List<Control>()
			{
				txtEnderecoComplemento, txtEnderecoLogradouro,
				txtEnderecoNumero, txtBairro, txtCidade,
				txtUF, txtCEP, txtTelefoneCelular, txtTelefoneFixo, txtEmail
			};

			// verifica valor do combo Tipo do Credor
			switch (_credor.CredorTipo)
			{
				case 1: // PESSOA FISICA
					lblCNP.Text = "CPF";
					txtCNP.Enabled = true;
					if (txtCNP.Text.Trim().Replace("/", "").Replace(".", "").Replace("-", "").Length != 11)
					{
						txtCNP.Clear();
					}

					controls.ForEach(x => x.Enabled = true);
					pnlChk.Visible = true;

					// get default config value
					if (Sit == EnumFlagEstado.NovoRegistro)
					{
						txtCidade.Text = ObterDefault("CidadePadrao");
						txtUF.Text = ObterDefault("UFPadrao");
					}

					break;

				case 2: // PESSOA JURIDICA
					lblCNP.Text = "CNPJ";
					txtCNP.Enabled = true;
					if (txtCNP.Text.Trim().Replace("/", "").Replace(".", "").Replace("-", "").Length != 14)
					{
						txtCNP.Clear();
					}

					controls.ForEach(x => x.Enabled = true);
					pnlChk.Visible = true;

					// get default config value
					if (Sit == EnumFlagEstado.NovoRegistro)
					{
						txtCidade.Text = ObterDefault("CidadePadrao");
						txtUF.Text = ObterDefault("UFPadrao");
					}

					break;

				case 3: // ORGAO PUBLICO
					lblCNP.Text = "";
					txtCNP.Enabled = false;
					txtCNP.Clear();
					controls.ForEach(x => x.Enabled = false);
					controls.ForEach(x => x.Text = "");
					pnlChk.Visible = false;

					break;

				case 4: // CREDOR SIMPLES
					lblCNP.Text = "";
					txtCNP.Enabled = false;
					txtCNP.Clear();
					controls.ForEach(x => x.Enabled = false);
					controls.ForEach(x => x.Text = "");
					pnlChk.Visible = false;

					break;

				default:
					break;
			}
		}

		// FORMATA CPF OU CNPJ
		//------------------------------------------------------------------------------------------------------------
		private void txtCNP_Leave(object sender, EventArgs e)
		{
			if (txtCNP.Text.Trim().Length > 0)
			{
				try
				{
					txtCNP.Text = CNPConvert(txtCNP.Text);
				}
				catch (AppException ex)
				{
					AbrirDialog(ex.Message, "Valor Inválido", DialogType.OK, DialogIcon.Exclamation);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Uma exceção ocorreu ao formatar CNP...\n" +
									ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
		}

		// KEYPRESS ONLY NUMBERS CHAR
		//------------------------------------------------------------------------------------------------------------
		private void txtSoNumeros_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
				e.Handled = true;
		}

		#endregion // CONTROLS --- END

		#region FORM DESIGN

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

		#endregion // FORM DESIGN --- END

	}
}
