using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Main
{
	public partial class frmUsuario : CamadaUI.Modals.frmModFinBorder
	{
		private objUsuario _usuario;
		private UsuarioBLL userBLL = new UsuarioBLL();
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private EnumFormUsuarioFuncao _funcao;

		public enum EnumFormUsuarioFuncao
		{
			Novo_Usuario,
			Alterar_Senha,
			Alterar_Email,
			Alterar_Acesso
		}

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmUsuario(objUsuario obj, EnumFormUsuarioFuncao Funcao)
		{
			InitializeComponent();

			_usuario = obj;
			_funcao = Funcao;
			bind.DataSource = _usuario;
			BindingCreator();

			_usuario.PropertyChanged += RegistroAlterado;

			if (_usuario.IDUsuario == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// ADD HANDLERS
			HandlerKeyDownControl(this);
		}

		// LOAD
		//------------------------------------------------------------------------------------------------------------
		private void frmUsuario_Load(object sender, EventArgs e)
		{
			funcao = _funcao;
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
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						break;
					case EnumFlagEstado.Alterado:
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						break;
					case EnumFlagEstado.NovoRegistro:
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						break;
					case EnumFlagEstado.RegistroBloqueado:
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						break;
					default:
						break;
				}
			}
		}

		public EnumFormUsuarioFuncao funcao
		{
			get => _funcao;
			set
			{
				switch (value)
				{
					case EnumFormUsuarioFuncao.Novo_Usuario:
						pnlNovoUsuario.Visible = true;
						pnlNovoUsuario.Location = new Point(18, 70);
						txtUsuarioNovo.Focus();
						pnlAlterarEmail.Visible = false;
						pnlAlterarSenha.Visible = false;
						pnlAlterarAcesso.Visible = false;
						lblTitulo.Text = "Cadastro de Usuário";
						break;
					case EnumFormUsuarioFuncao.Alterar_Senha:
						pnlNovoUsuario.Visible = false;
						pnlAlterarEmail.Visible = false;
						pnlAlterarSenha.Visible = true;
						pnlAlterarSenha.Location = new Point(18, 70);
						txtSenhaAntigaAlterar.Focus();
						pnlAlterarAcesso.Visible = false;
						lblTitulo.Text = "Usuário Alterar Senha";
						break;
					case EnumFormUsuarioFuncao.Alterar_Email:
						pnlNovoUsuario.Visible = false;
						pnlAlterarEmail.Visible = true;
						pnlAlterarEmail.Location = new Point(18, 70);
						txtEmailAlterar.Focus();
						pnlAlterarSenha.Visible = false;
						pnlAlterarAcesso.Visible = false;
						lblTitulo.Text = "Usuário Alterar Email";
						break;
					case EnumFormUsuarioFuncao.Alterar_Acesso:
						pnlNovoUsuario.Visible = false;
						pnlAlterarEmail.Visible = false;
						pnlAlterarSenha.Visible = false;
						pnlAlterarAcesso.Visible = true;
						pnlAlterarAcesso.Location = new Point(18, 70);
						cmbAcessoAlterar.Focus();
						lblTitulo.Text = "Usuário Alterar Acesso";
						break;
					default:
						break;
				}

				ResizeForm();
				_funcao = value;
			}
		}

		// RESIZE FORM FROM VISIBLE PANEL
		//------------------------------------------------------------------------------------------------------------
		private void ResizeForm()
		{
			int FormHeight = 0;
			int pnlTop = panel1.Size.Height;
			int pnlBottom = tspMenu.Size.Height;

			if (pnlNovoUsuario.Visible)
				FormHeight += pnlNovoUsuario.Size.Height;

			if (pnlAlterarSenha.Visible)
				FormHeight += pnlAlterarSenha.Size.Height;

			if (pnlAlterarAcesso.Visible)
				FormHeight += pnlAlterarAcesso.Size.Height;

			if (pnlAlterarEmail.Visible)
				FormHeight += pnlAlterarEmail.Size.Height;

			FormHeight += pnlTop + pnlBottom + 50;

			this.Height = FormHeight;

		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDUsuario", true);

			// usuario apelido nome
			txtUsuarioNovo.DataBindings.Add("Text", bind, "UsuarioApelido", true, DataSourceUpdateMode.OnPropertyChanged);
			lblUsuarioAcessoAlterar.DataBindings.Add("Text", bind, "UsuarioApelido", true, DataSourceUpdateMode.OnPropertyChanged);
			lblUsuarioEmailAlterar.DataBindings.Add("Text", bind, "UsuarioApelido", true, DataSourceUpdateMode.OnPropertyChanged);
			lblUsuarioSenhaAlterar.DataBindings.Add("Text", bind, "UsuarioApelido", true, DataSourceUpdateMode.OnPropertyChanged);

			// senha
			txtSenhaNovo.DataBindings.Add("Text", bind, "UsuarioSenha", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSenhaNovaAlterar.DataBindings.Add("Text", bind, "UsuarioSenha", true, DataSourceUpdateMode.OnPropertyChanged);

			// email
			txtEmailNovo.DataBindings.Add("Text", bind, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEmailAlterar.DataBindings.Add("Text", bind, "Email", true, DataSourceUpdateMode.OnPropertyChanged);


			// CARREGA COMBOS
			CarregaCmbAcesso();

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
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

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaCmbAcesso()
		{
			//--- Create DataTable
			DataTable dtAcesso = new DataTable();
			dtAcesso.Columns.Add("ID");
			dtAcesso.Columns.Add("Texto");
			dtAcesso.Rows.Add(new object[] { 1, "Administrador" });
			dtAcesso.Rows.Add(new object[] { 2, "Usuário Senior" });
			dtAcesso.Rows.Add(new object[] { 3, "Usuário Comum" });
			dtAcesso.Rows.Add(new object[] { 4, "Usuário Local" });

			//--- Set DataTable
			cmbAcessoAlterar.DataSource = dtAcesso;
			cmbAcessoAlterar.ValueMember = "ID";
			cmbAcessoAlterar.DisplayMember = "Texto";
			cmbAcessoAlterar.DataBindings.Add("SelectedValue", bind, "UsuarioAcesso", true, DataSourceUpdateMode.OnPropertyChanged);

			//--- Set DataTable
			cmbAcessoNovo.DataSource = dtAcesso;
			cmbAcessoNovo.ValueMember = "ID";
			cmbAcessoNovo.DisplayMember = "Texto";
			cmbAcessoNovo.DataBindings.Add("SelectedValue", bind, "UsuarioAcesso", true, DataSourceUpdateMode.OnPropertyChanged);
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
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
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

				if (_usuario.IDUsuario == null)
				{
					//--- save | Insert
					int ID = userBLL.InsertUsuario(_usuario);
					//--- define newID
					_usuario.IDUsuario = ID;
				}
				else
				{
					//--- update
					userBLL.UpdateUsuario(_usuario);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
				//--- close
				Close();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Usuario..." + "\n" +
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
			switch (funcao)
			{
				case EnumFormUsuarioFuncao.Novo_Usuario: // USUARIO NOVO

					if (!VerificaDadosClasse(txtUsuarioNovo, "Usuario", _usuario)) return false;
					if (!VerificaDadosClasse(cmbAcessoNovo, "Acesso", _usuario)) return false;
					if (!VerificaDadosClasse(txtSenhaNovo, "Senha", _usuario)) return false;
					if (!VerificaDadosClasse(txtEmailNovo, "Email", _usuario)) return false;

					// check password lenght
					if (txtSenhaNovo.TextLength != 8)
					{
						AbrirDialog("A Senha precisa ter oito carateres...",
									"Senha", DialogType.OK, DialogIcon.Exclamation);
						txtSenhaNovo.Focus();
						return false;
					}

					// verifica semelhanca da password com confirmacao
					if (txtSenhaNovo.Text != txtSenhaConfirmarNovo.Text)
					{
						AbrirDialog("A Senha e a Confirmação da Senha não são idênticas...",
							"Confirmação de Senha", DialogType.OK, DialogIcon.Exclamation);
						txtSenhaNovo.Focus();
						return false;
					}

					break;

				case EnumFormUsuarioFuncao.Alterar_Senha: // ALTERAR A SENHA

					// Senha anterior
					if (txtSenhaAntigaAlterar.Text.Trim().Length == 0)
					{
						AbrirDialog("Prencha a senha anterior...", "Senha Anterior",
							DialogType.OK, DialogIcon.Exclamation);
						return false;
					}

					// Nova Senha
					if (txtSenhaNovaAlterar.Text.Trim().Length == 0)
					{
						AbrirDialog("Prencha a senha nova...", "Senha Nova",
							DialogType.OK, DialogIcon.Exclamation);
						return false;
					}
					// Senha anterior
					if (txtSenhaConfirmarAlterar.Text.Trim().Length == 0)
					{
						AbrirDialog("Prencha a confirmação da senha...", "Senha Confirmação",
							DialogType.OK, DialogIcon.Exclamation);
						return false;
					}

					// verifica senha
					try
					{
						// --- Ampulheta ON
						Cursor.Current = Cursors.WaitCursor;

						if (!userBLL.ConfirmPassword(_usuario, txtSenhaAntigaAlterar.Text))
						{
							AbrirDialog("A Senha anterior não está correta...",
								"Senha Incorreta", DialogType.OK, DialogIcon.Exclamation);
							return false;
						}
					}
					catch (Exception ex)
					{
						AbrirDialog("Uma exceção ocorreu ao Confirmar a Senha do Usuário..." + "\n" +
									ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
					}
					finally
					{
						// --- Ampulheta OFF
						Cursor.Current = Cursors.Default;
					}

					break;

				case EnumFormUsuarioFuncao.Alterar_Email: // ALTERAR O EMAIL

					break;
				case EnumFormUsuarioFuncao.Alterar_Acesso: // ALTERAR O ACESSO

					break;
				default:
					break;
			}

			return true;
		}

		#endregion
	}
}
