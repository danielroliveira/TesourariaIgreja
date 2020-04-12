using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;
using System.Linq;
using ComponentOwl.BetterListView;
using System.Drawing.Drawing2D;
using CamadaUI.Contas;

namespace CamadaUI.Main
{
	public partial class frmUsuarioContaAcesso : CamadaUI.Modals.frmModFinBorder
	{
		private List<objUsuarioConta> listAcesso = new List<objUsuarioConta>();
		private Form _formOrigem;
		private objUsuario _usuario;
		UsuarioBLL uBLL = new UsuarioBLL();

		#region NEW | OPEN FUNCTIONS

		public frmUsuarioContaAcesso(objUsuario Usuario, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			_usuario = Usuario;
			lblUsuarioApelido.Text = _usuario.UsuarioApelido;

			//--- Add any initialization after the InitializeComponent() call.
			ObterDados(this, new EventArgs());

			//--- Handlers
			HandlerKeyDownControl(this);
		}

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				listAcesso = uBLL.GetUserPermitedContaList((int)_usuario.IDUsuario);
				PreencheListagem();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter os Dados da listagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private void PreencheListagem()
		{
			lstItens.DataSource = listAcesso;
			FormataListagem();
		}

		#endregion

		#region LIST FUNCTIONS

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagem()
		{

			lstItens.MultiSelect = false;
			lstItens.HideSelection = false;

			clnID.DisplayMember = "IDUserConta";
			clnID.ValueMember = "IDUserConta";

			clnItem.DisplayMember = "Conta";
			clnItem.ValueMember = "Conta";

			lstItens.SearchSettings = new BetterListViewSearchSettings(BetterListViewSearchMode.PrefixOrSubstring,
																	   BetterListViewSearchOptions.UpdateSearchHighlight,
																	   new int[] { 0, 1 });
		}

		// DESIGN HEADER STYLE
		//------------------------------------------------------------------------------------------------------------
		private void lstItens_DrawColumnHeader(object sender, BetterListViewDrawColumnHeaderEventArgs eventArgs)
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

		// FORMAT ITENS ID NUMBER
		//------------------------------------------------------------------------------------------------------------
		private void lstItens_DrawItem(object sender, BetterListViewDrawItemEventArgs eventArgs)
		{
			if (int.TryParse(eventArgs.Item.Text, out int intValue))
			{
				eventArgs.Item.Text = $"{intValue: 00}";
			}
		}

		#endregion

		#region BUTTONS FUNCTION

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnRemover_Click(object sender, EventArgs e)
		{
			objUsuarioConta item = GetSelectedItem();

			//--- check selected item
			if (item == null)
			{
				AbrirDialog("Favor selecionar um registro para remover...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			// message
			DialogResult resp =
			AbrirDialog($"Deseja realmente remover a autorização do Usuário {_usuario.UsuarioApelido.ToUpper()} " +
				$"para movimentar a conta {item.Conta.ToUpper()}?", "Remover Autorização",
				DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp == DialogResult.No) return; // exit if NO

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				uBLL.DeleteUserPermissionConta((int)item.IDUserConta);
				//listAcesso.Remove(item);
				lstItens.SelectedItems[0].Remove();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Remover acesso..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContaProcura frm = new frmContaProcura(this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK)
					return;

				objUsuarioConta usuarioConta = new objUsuarioConta(_usuario.IDUsuario, frm.propEscolha.IDConta);

				// insert
				int newID = uBLL.InsertUserPermissionConta(usuarioConta);
				usuarioConta.IDUserConta = newID;
				usuarioConta.Conta = frm.propEscolha.Conta;
				usuarioConta.Ativo = true;

				//get dados
				ObterDados(sender, null);

				// message
				AbrirDialog($"Usuário {_usuario.UsuarioApelido.ToUpper()} autorizado " +
					$"para movimentar a conta {usuarioConta.Conta.ToUpper()}", "Autorização",
					DialogType.OK, DialogIcon.Information);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir formulário de Conta..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private objUsuarioConta GetSelectedItem()
		{
			if (lstItens.SelectedItems.Count == 0) return null;

			int IDSelected = (int)lstItens.SelectedItems[0].Value;
			return listAcesso.First(s => s.IDUserConta == IDSelected);
		}

		#endregion

		#region CONTROLS FUNCTION

		// ESC TO CLOSE || KEYDOWN TO DOWNLIST || KEYUP TO UPLIST
		//------------------------------------------------------------------------------------------------------------
		private void frmUsuarioContaAcesso_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnClose_Click(sender, new EventArgs());
			}
			else if (e.KeyCode == Keys.Up && ActiveControl.GetType().BaseType.Name != "ComboBox")
			{
				e.Handled = true;

				if (lstItens.Items.Count > 0)
				{
					if (lstItens.SelectedItems.Count > 0)
					{
						int i = lstItens.SelectedItems[0].Index;
						lstItens.Items[i].Selected = false;

						if (i == 0) lstItens.Items[lstItens.Items.Count - 1].Selected = true;
						else lstItens.Items[i - 1].Selected = true;
					}
					else
					{
						lstItens.Items[0].Selected = true;
					}

					lstItens.EnsureVisible(lstItens.SelectedItems[0]);
				}
			}
			else if (e.KeyCode == Keys.Down && ActiveControl.GetType().BaseType.Name != "ComboBox")
			{
				e.Handled = true;

				if (lstItens.Items.Count > 0)
				{
					if (lstItens.SelectedItems.Count > 0)
					{
						int i = lstItens.SelectedItems[0].Index;
						lstItens.Items[i].Selected = false;
						if (i == lstItens.Items.Count - 1) i = -1;
						lstItens.Items[i + 1].Selected = true;
					}
					else
					{
						lstItens.Items[0].Selected = true;
					}

					lstItens.EnsureVisible(lstItens.SelectedItems[0]);
				}
			}
		}

		#endregion // CONTROLS FUNCTION --- END

		#region DESIGN FORM FUNCTIONS

		private void frmUsuarioContaAcesso_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmUsuarioContaAcesso_FormClosed(object sender, FormClosedEventArgs e)
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
