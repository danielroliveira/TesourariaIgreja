using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Mensagens
{
	public partial class frmMensagemEditar : CamadaUI.Modals.frmModFinBorder
	{
		private objMensagem _mensagem;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private Form _formOrigem;
		private objUsuario _DestinoUser;
		private MensagemBLL mBLL;
		private List<objMensagem> lstAntigas;

		#region SUB NEW | LOAD

		public frmMensagemEditar(objMensagem mensagem, objUsuario DestinoUser, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			_DestinoUser = DestinoUser;
			_mensagem = mensagem;
			bind.DataSource = _mensagem;
			BindingCreator();

			if (_mensagem.IDMensagem == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// CHECK IF IS RESPOSTA
			if (_mensagem.IsResposta && mensagem.IDOrigem != null)
			{
				mBLL = new MensagemBLL();
				lstAntigas = ObterAnteriores((int)mensagem.IDOrigem);

				if (lstAntigas != null && lstAntigas.Count > 0) PreencheControleAntigas();
			}

			// CHECK FORM SIZE
			WithAnteriores();

			// ADD HANDLERS
			HandlerKeyDownControl(this);

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
					case EnumFlagEstado.NovoRegistro:
						lblTitulo.Text = "Enviar Nova Mensagem";
						break;
					case EnumFlagEstado.Alterado:
					case EnumFlagEstado.RegistroSalvo:
					case EnumFlagEstado.RegistroBloqueado:
						lblTitulo.Text = "Ler Mensagem";
						break;
					default:
						break;
				}
			}
		}

		// GET LIST OF MENSAGENS ANTERIORES
		//------------------------------------------------------------------------------------------------------------
		private List<objMensagem> ObterAnteriores(int IDMensagemAnterior)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				return mBLL.GetListMensagensRelacionadas(IDMensagemAnterior);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter Mensagens Anteriores..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void PreencheControleAntigas()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- create new label with mensagem
				foreach (var item in lstAntigas.OrderBy(x => x.IDMensagem))
				{
					Label label = new Label()
					{
						Text = $"{item.MensagemData.ToShortDateString()} - {item.Mensagem}",
						Name = $"Mensagem {item.IDMensagem}",
						AutoSize = true,
					};

					pnlAnteriores.Controls.Add(label);
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Preecher as Mensagens Relacionadas Anteriores..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void WithAnteriores()
		{
			if (lstAntigas != null && lstAntigas.Count > 0)
			{
				pnlAnteriores.Visible = true;
				lblAnteriores.Visible = true;
			}
			else
			{
				pnlAnteriores.Visible = false;
				lblAnteriores.Visible = false;
				//lblMensagens.Location = new Point(19, 204);
				//txtMensagem.Location = new Point(18, 236);
				Size = new Size(749, 464);
			}
		}


		#endregion // SUB NEW | LOAD --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblMensagemData.DataBindings.Add("Text", bind, "MensagemData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtUsuarioDestino.DataBindings.Add("Text", bind, "UsuarioDestino", true, DataSourceUpdateMode.OnPropertyChanged);
			lblUsuarioOrigem.DataBindings.Add("Text", bind, "UsuarioOrigem", true, DataSourceUpdateMode.OnPropertyChanged);
			txtMensagem.DataBindings.Add("Text", bind, "Mensagem", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			bind.CurrentChanged += BindRegistroChanged;

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

		#endregion

		#region BUTTONS FUNCTION

		// CANCEL MESSAGE
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		// SAVE | SEND MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		private void btnEnviar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(_mensagem.Mensagem))
			{
				AbrirDialog("É necessário que a mensagem tenha pelo menos uma palavra...",
					"Mensagem Vazia", DialogType.OK, DialogIcon.Exclamation);
				txtMensagem.Focus();
				return;
			}

			_mensagem.IDUsuarioDestino = (int)_DestinoUser.IDUsuario;
			_mensagem.UsuarioDestino = _DestinoUser.UsuarioApelido;

			DialogResult = DialogResult.OK;
		}

		#endregion // BUTTONS FUNCTION --- END

		#region CONTROLS FUNCTIONS

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
					case "txtUsuarioDestino":
						btnSetUser_Click(sender, new EventArgs());
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
				Control[] controlesBloqueados = { txtUsuarioDestino, };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetUser_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmUsuarioProcura frm = new frmUsuarioProcura(this, null, true);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult != DialogResult.OK) return;

				//--- check user
				if (frm.propEscolha.IDUsuario == (int)Program.usuarioAtual.IDUsuario)
				{
					AbrirDialog("Não é possível enviar uma mensagem para o usuário:\n" +
						$"{Program.usuarioAtual.UsuarioApelido}\n" +
						$"porque este é o usuário atual.",
						"Mensagem para Usuário",
						DialogType.OK,
						DialogIcon.Exclamation);
					return;
				}

				// set user
				_DestinoUser = frm.propEscolha;
				txtUsuarioDestino.Text = frm.propEscolha.UsuarioApelido;

				//--- select
				txtUsuarioDestino.Focus();
				txtUsuarioDestino.SelectAll();
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

		#endregion // CONTROLS FUNCTIONS --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				//_formOrigem.Visible = false;
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				//_formOrigem.Visible = true;
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END

	}
}
