using CamadaBLL;
using CamadaDTO;
using CamadaUI.Main;
using ComponentOwl.BetterListView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Config
{

	public partial class frmConfigUsuarios : Modals.frmModConfig
	{

		private Image ItemAtivo = Properties.Resources.accept_24;
		private Image ItemInativo = Properties.Resources.block_24;
		UsuarioBLL uBLL = new UsuarioBLL();
		List<objUsuario> listUser = new List<objUsuario>();
		Form _formOrigem;

		#region SUB NEW | LOAD

		// SUB NEW
		public frmConfigUsuarios()
		{
			InitializeComponent();
			_formOrigem = Application.OpenForms.OfType<frmConfig>().FirstOrDefault();

			ObterDados();

			lstUsuarios_SelectedIndexChanged(this, null);

			// handler
			lstUsuarios.SelectedIndexChanged += lstUsuarios_SelectedIndexChanged;
		}

		private void PreencheListagem()
		{
			lstUsuarios.DataSource = listUser;
			// column 0
			clnIDUsuario.Width = 70;
			clnIDUsuario.DisplayMember = "IDUsuario";
			// column 1
			clnUsuarioApelido.Width = 160;
			clnUsuarioApelido.DisplayMember = "UsuarioApelido";
			// column 2
			clnUsuarioAcessoDesc.Width = 130;
			clnUsuarioAcessoDesc.DisplayMember = "UsuarioAcessoDesc";
			clnUsuarioAcessoDesc.ValueMember = "UsuarioAcesso";
			// column 3
			clnUsuarioAtivo.Width = 60;
			clnUsuarioAtivo.ValueMember = "UsuarioAtivo";
		}

		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// get list of usuarios
				listUser = uBLL.GetListUsuario();

				// fill list
				PreencheListagem();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Usuários..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion

		#region BUTTONS FUNCTION

		// CLOSE
		// =============================================================================
		private void btnClose_Click(object sender, EventArgs e)
		{
			frmConfig f = Application.OpenForms.OfType<frmConfig>().FirstOrDefault();
			f.FormNoPanelClosed(this);
		}

		#endregion

		private void lstUsuarios_DrawColumnHeader(object sender, ComponentOwl.BetterListView.BetterListViewDrawColumnHeaderEventArgs eventArgs)
		{
			if (eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 && eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0)
			{
				Brush brush = new LinearGradientBrush(
					eventArgs.ColumnHeaderBounds.BoundsOuter,
					Color.Transparent,
					Color.FromArgb(64, Color.SteelBlue),
					LinearGradientMode.Vertical
				);

				eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter);
				brush.Dispose();
			}
		}

		private void lstUsuarios_DrawItem(object sender, BetterListViewDrawItemEventArgs eventArgs)
		{
			if (int.TryParse(eventArgs.Item.Text, out int intValue))
			{
				eventArgs.Item.Text = $"{intValue: 0000}";
			}

			if (eventArgs.Item.SubItems[3].Value != null)
			{
				eventArgs.Item.SubItems[3].AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter;

				if ((bool)eventArgs.Item.SubItems[3].Value == true)
					eventArgs.Item.SubItems[3].Image = ItemAtivo;
				else if ((bool)eventArgs.Item.SubItems[3].Value == false)
					eventArgs.Item.SubItems[3].Image = ItemInativo;
			}

		}

		// GET THE SELECTED USER IF EXISTS
		private objUsuario GetSelectedItem()
		{
			if (lstUsuarios.SelectedItems.Count == 0)
			{
				AbrirDialog("Não há usuário selecionada na listagem. Favor selecionar um usúario...",
					"Selecionar", DialogType.OK, DialogIcon.Exclamation);
				lstUsuarios.Focus();
				return null;
			}

			return (objUsuario)lstUsuarios.SelectedItems[0].Value;
		}
		private void lstUsuarios_ItemActivate(object sender, BetterListViewItemActivateEventArgs eventArgs)
		{
			btnUserPermissao_Click(sender, null);
		}

		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			AlterarUsuario((Control)sender);
		}

		private void btnAlterarSenha_Click(object sender, EventArgs e)
		{
			AlterarUsuario((Control)sender);
		}

		private void btnAlterarEmail_Click(object sender, EventArgs e)
		{
			AlterarUsuario((Control)sender);
		}

		private void btnAlterarAcesso_Click(object sender, EventArgs e)
		{
			AlterarUsuario((Control)sender);
		}

		private void AlterarUsuario(Control controle)
		{
			try
			{
				objUsuario usuario = null;

				if (controle == btnAdicionar)
				{
					usuario = new objUsuario(null);
				}
				else
				{
					usuario = GetSelectedItem();
					if (usuario == null)
						return;
				}


				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmUsuario.EnumFormUsuarioFuncao funcao = frmUsuario.EnumFormUsuarioFuncao.Alterar_Senha;

				switch (controle.Name)
				{
					case "btnAdicionar":
						funcao = frmUsuario.EnumFormUsuarioFuncao.Novo_Usuario;
						break;
					case "btnAlterarSenha":
						funcao = frmUsuario.EnumFormUsuarioFuncao.Alterar_Senha;
						break;
					case "btnAlterarEmail":
						funcao = frmUsuario.EnumFormUsuarioFuncao.Alterar_Email;
						break;
					case "btnAlterarAcesso":
						funcao = frmUsuario.EnumFormUsuarioFuncao.Alterar_Acesso;
						break;
					case "lstUsuarios":
						funcao = frmUsuario.EnumFormUsuarioFuncao.Alterar_Email;
						break;
					default:
						break;
				}

				frmUsuario frm = new frmUsuario(usuario, funcao);

				// hide forms
				this.Visible = false;
				_formOrigem.Visible = false;
				lstUsuarios.SelectedIndexChanged -= lstUsuarios_SelectedIndexChanged;

				// show Usuario Form
				frm.ShowDialog();

				// show forms
				this.Visible = true;
				_formOrigem.Visible = true;

				// requery list
				ObterDados();

				// select old usuario in list
				if (usuario != null && lstUsuarios.Items.Count > 0)
				{
					foreach (var item in lstUsuarios.Items)
					{
						if (Convert.ToInt32(item.Text) == usuario.IDUsuario)
						{
							item.Selected = true;
							item.EnsureVisible();
						}
						else
						{
							item.Selected = false;
						}
					}
				}
				else
				{
					lstUsuarios.Items.ToList().ForEach(x => x.Selected = false); // unselect all items
					lstUsuarios.Items.Last().Selected = true; // select last item
				}

				// restore Handler to list changed item
				lstUsuarios.SelectedIndexChanged += lstUsuarios_SelectedIndexChanged;

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir formulário de Alteração..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnAlterarAtivo_Click(object sender, EventArgs e)
		{
			// get selected user on list
			objUsuario usuario = GetSelectedItem();

			if (usuario == null)
				return;

			// check if is actual user
			if (usuario.UsuarioAtivo && usuario.IDUsuario == Program.usuarioAtual.IDUsuario)
			{
				AbrirDialog("Você não pode desabilitar o usuário atual...",
					"Desativar", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// change ATIVO value
			usuario.UsuarioAtivo = !usuario.UsuarioAtivo;

			// Save DB
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// update
				uBLL.UpdateUsuario(usuario);

				// redraw itens and button
				lstUsuarios.RedrawItems();
				lstUsuarios_SelectedIndexChanged(sender, null);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar/Desativar Usuário..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// ALTERA A IMAGEM DO BTN ALTERAR ATIVO
		//------------------------------------------------------------------------------------------------------------
		private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
		{
			objUsuario usuario = GetSelectedItem();

			if (usuario == null)
			{
				btnAlterarAtivo.Enabled = false;
				return;
			}

			btnAlterarAtivo.Enabled = true;
			if (usuario.UsuarioAtivo)
			{
				btnAlterarAtivo.Text = "Desativar Usuário";
				btnAlterarAtivo.Image = Properties.Resources.block_24;
			}
			else
			{
				btnAlterarAtivo.Text = "Ativar Usuário";
				btnAlterarAtivo.Image = Properties.Resources.accept_24;
			}
		}

		private void btnUserPermissao_Click(object sender, EventArgs e)
		{
			objUsuario usuario = GetSelectedItem();

			if (usuario == null)
			{
				btnAlterarAtivo.Enabled = false;
				return;
			}
			else if (usuario.UsuarioAcesso == 1)
			{
				AbrirDialog("O acesso desse usuário já ilimitado...\n" +
					"Não há necessidade de definir o acesso para um usuário ADMINISTRADOR.",
					"Definir Acesso");
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmUsuarioContaAcesso frm = new frmUsuarioContaAcesso(usuario, this);
				frm.ShowDialog();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir formulário de Permissão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}
	}
}
