using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Mensagens
{
	public partial class frmMensagens : CamadaUI.Modals.frmModFinBorder
	{
		private List<objMensagem> list = new List<objMensagem>();
		private BindingSource bind = new BindingSource();
		private MensagemBLL mBLL = new MensagemBLL();
		private bool _Recebida = true;

		#region NEW | OPEN FUNCTIONS

		public frmMensagens()
		{
			InitializeComponent();

			// define o nome do usuario
			lblUsuario.Text = $"Mensagens para {Program.usuarioAtual.UsuarioApelido}";

			// get mensages
			ObterDados();

			//--- Handlers
			HandlerKeyDownControl(this);
			rbtRecebidas.CheckedChanged += rbt_CheckedChanged;
			rbtEnviadas.CheckedChanged += rbt_CheckedChanged;

			mnuEditar.Click += (a, b) => EditarMensagem();
			mnuRemover.Click += (a, b) => RemoverMensagem();
			mnuRecebida.Click += (a, b) => MarcarComoLida();
			mnuItemResponder.Click += (a, b) => ResponderMensagem();
		}

		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (_Recebida)
				{
					list = mBLL.Recebidas((int)Program.usuarioAtual.IDUsuario);
				}
				else
				{
					list = mBLL.Enviadas((int)Program.usuarioAtual.IDUsuario);
				}

				bind.DataSource = list;
				dgvListagem.DataSource = bind;
				FormataListagem();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter as Mensagens..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		#endregion // NEW | OPEN FUNCTIONS --- END

		#region DATAGRID FUNCTIONS

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagem()
		{
			dgvListagem.Columns.Clear();
			dgvListagem.AutoGenerateColumns = false;
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListagem.MultiSelect = false;
			dgvListagem.ColumnHeadersVisible = true;
			dgvListagem.AllowUserToResizeRows = false;
			dgvListagem.AllowUserToResizeColumns = false;
			dgvListagem.RowHeadersWidth = 36;
			dgvListagem.RowHeadersVisible = false;
			dgvListagem.RowTemplate.Height = 45;
			dgvListagem.StandardTab = true;
			dgvListagem.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			// DEFINE COLUMN FONT
			Font clnFont = new Font("Pathway Gothic One", 16.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (0) COLUNA DATA
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnMensagemData.DataPropertyName = "MensagemData";
			clnMensagemData.Visible = true;
			clnMensagemData.ReadOnly = true;
			clnMensagemData.Resizable = DataGridViewTriState.False;
			clnMensagemData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnMensagemData.DefaultCellStyle.Padding = newPadding;
			clnMensagemData.DefaultCellStyle.Font = clnFont;
			clnMensagemData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			colList.Add(clnMensagemData);

			//--- (1) COLUNA SITUACAO
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Font = clnFont;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnSituacao);

			//--- (2) COLUNA MENSAGEM
			clnMensagem.DataPropertyName = "Mensagem";
			clnMensagem.Visible = true;
			clnMensagem.ReadOnly = true;
			clnMensagem.Resizable = DataGridViewTriState.False;
			clnMensagem.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnMensagem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnMensagem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnMensagem.DefaultCellStyle.Font = clnFont;
			colList.Add(clnMensagem);

			//--- (3) COLUNA USUARIO
			if (_Recebida)
			{
				clnUsuario.DataPropertyName = "UsuarioOrigem";
				clnUsuario.HeaderText = "Origem De";
			}
			else
			{
				clnUsuario.DataPropertyName = "UsuarioDestino";
				clnUsuario.HeaderText = "Enviada para";
			}

			clnUsuario.Visible = true;
			clnUsuario.ReadOnly = true;
			clnUsuario.Resizable = DataGridViewTriState.False;
			clnUsuario.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnUsuario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnUsuario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnUsuario.DefaultCellStyle.Font = clnFont;
			colList.Add(clnUsuario);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		// CONTROLA AS CORES DA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			objMensagem mensagem = (objMensagem)dgvListagem.Rows[e.RowIndex].DataBoundItem;

			if (e.ColumnIndex == clnSituacao.Index)
			{
				if (mensagem.Recebida == false)
				{
					e.Value = _Recebida ? "NOVA" : "NÃO LIDA";

					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
					dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
					e.CellStyle.ForeColor = Color.Red;
					e.CellStyle.SelectionForeColor = Color.Yellow;
				}
				else
				{
					e.Value = "LIDA";
					if ((e.RowIndex + 1) % 2 != 0) // row ODD (impar)
					{
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OldLace;
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
					}
					else // row EVEN (par)
					{
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
						dgvListagem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
					}
				}
			}
		}

		// SELECT FROM MOUSE ENTER
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1) return;

			dgvListagem.Rows[e.RowIndex].Selected = true;

		}

		#endregion // DATAGRID FUNCTIONS --- END

		#region BUTTONS FUNCTION

		// CHANGE SITUACAO RECEBIDO
		//------------------------------------------------------------------------------------------------------------
		private void rbt_CheckedChanged(object sender, EventArgs e)
		{
			bool escolha = rbtRecebidas.Checked;

			if (_Recebida != escolha)
			{
				_Recebida = escolha;
				btnExcluir.Enabled = !_Recebida;
				ObterDados();
			}

			if (_Recebida)
			{
				// define o nome do usuario
				lblUsuario.Text = $"Mensagens para {Program.usuarioAtual.UsuarioApelido}";
			}
			else
			{
				// define o nome do usuario
				lblUsuario.Text = $"Mensagens enviadas por {Program.usuarioAtual.UsuarioApelido}";
			}

		}

		// CLOSE FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
			((frmPrincipal)Application.OpenForms[0]).CheckUserNewMessages();
		}

		// CREATE ENVIAR NOVA MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		private void btnEnviarNova_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- get destination user message
				var frm = new frmUsuarioProcura(this, null, true);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				var user = frm.propEscolha;

				if (user.IDUsuario == (int)Program.usuarioAtual.IDUsuario)
				{
					AbrirDialog("Não é possível enviar uma mensagem para o usuário atual:\n" +
						$"{Program.usuarioAtual.UsuarioApelido}",
						"Mensagem para Usuário", DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				//--- create new mensagem
				var novaMensagem = new objMensagem()
				{
					IDUsuarioDestino = (int)user.IDUsuario,
					IDUsuarioOrigem = (int)Program.usuarioAtual.IDUsuario,
					IsResposta = false,
					IDMensagem = null,
					IDOrigem = null,
					Mensagem = "",
					MensagemData = DateTime.Today,
					MensagemOrigem = null,
					Recebida = false,
					RecebidaData = null,
					Suporte = false,
					UsuarioOrigem = Program.usuarioAtual.UsuarioApelido,
					UsuarioDestino = user.UsuarioApelido
				};

				//--- open form mensagem
				var frmM = new frmMensagemEditar(novaMensagem, user, this);

				frmM.ShowDialog();

				if (frmM.DialogResult != DialogResult.OK) return;

				EnviarMensagem(novaMensagem);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Enviar Nova Mensagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// ENVIAR MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		private void EnviarMensagem(objMensagem mensagem)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//---mensagem
				string texto = "";

				//--- check usuario destino
				if (mensagem.IDUsuarioDestino != -1)
				{
					mBLL.InsertMensagem(mensagem);
					texto = "Mensagem enviada com sucesso!";
				}
				else
				{
					int total = mBLL.SendToAllActiveUsers(mensagem);

					if (total > 1)
					{
						texto = $"Mensagens enviadas com sucesso para {total: D2} usuários.";
					}
					else
					{
						texto = $"Mensagem enviada com sucesso para 1 usuário.";
					}

				}

				if (rbtEnviadas.Checked)
				{
					ObterDados();
				}
				else
				{
					rbtEnviadas.Checked = true;
				}

				AbrirDialog(texto, "Enviada");

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Enviar Mensagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		#endregion // BUTTONS FUNCTION --- END

		#region MENU SUSPENSO

		// LISTAGEM AO CLICAR
		//------------------------------------------------------------------------------------------------------------
		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			// check button
			if (e.Button != MouseButtons.Right) return;

			Control c = (Control)sender;
			DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
			dgvListagem.ClearSelection();

			if (hit.Type != DataGridViewHitTestType.Cell) return;

			// seleciona o ROW
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListagem.CurrentCell = dgvListagem.Rows[hit.RowIndex].Cells[2];
			dgvListagem.Rows[hit.RowIndex].Selected = true;

			// mostra o MENU ativar e desativar
			objMensagem item = (objMensagem)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// revela menu
			if (_Recebida)
			{
				mnuRecebida.Enabled = !item.Recebida;
				mnuOperacoes.Show(c.PointToScreen(e.Location));
			}
			else
			{
				mnuEnviadas.Show(c.PointToScreen(e.Location));
			}
		}

		// EDITAR MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		private void EditarMensagem()
		{
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Selecione um registro para editar...", "Selecionar");
				return;
			}

			//--- get selected message
			objMensagem mensagem = (objMensagem)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- create destino user
			var user = new objUsuario(mensagem.IDUsuarioDestino)
			{
				UsuarioApelido = mensagem.UsuarioDestino
			};

			//--- open form mensagem
			var frmM = new frmMensagemEditar(mensagem, user, this);
			frmM.ShowDialog();

			if (frmM.DialogResult != DialogResult.OK) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- update
				mBLL.UpdateMensagem(mensagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Mensagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// REMOVER MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		private void RemoverMensagem()
		{
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Selecione um registro para Remover...", "Selecionar");
				return;
			}

			//--- get selected message
			objMensagem mensagem = (objMensagem)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- ask user
			var resp = AbrirDialog("Você deseja realmente REMOVER a mensagem selecionada para o usuário\n" +
				$"{mensagem.UsuarioDestino.ToUpper()}?", "Remover Mensagem",
				DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- remove
				mBLL.DeleteMensagem((int)mensagem.IDMensagem);

				//--- get dados
				bind.Remove(mensagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Mensagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// MARCAR COMO LIDA
		//------------------------------------------------------------------------------------------------------------
		private void MarcarComoLida()
		{
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Selecione um registro para Marcar como Lida...", "Selecionar");
				return;
			}

			//--- get selected message
			objMensagem mensagem = (objMensagem)dgvListagem.SelectedRows[0].DataBoundItem;
			mensagem.Recebida = true;
			mensagem.RecebidaData = DateTime.Today;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- update
				mBLL.UpdateMensagem(mensagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Mensagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// RESPONDER MENSAGEM SELECIONADA
		//------------------------------------------------------------------------------------------------------------
		private void ResponderMensagem()
		{
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Selecione uma mensagem para Responder...", "Selecionar");
				return;
			}

			//--- get selected message
			objMensagem mensagem = (objMensagem)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- check if mensagem is RECEBIDA
			if (!mensagem.Recebida)
			{
				AbrirDialog("Para responder uma mensagem, a mesma deve estar marcada como mensagem LIDA..." +
					"Favor marcar essa mensagem com LIDA.",
					"Responder Mensagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Define Destination User message
				objUsuario userDestino = new objUsuario(mensagem.IDUsuarioOrigem)
				{
					UsuarioApelido = mensagem.UsuarioOrigem
				};

				//--- create new mensagem
				var novaMensagem = new objMensagem()
				{
					IDMensagem = null,
					IDUsuarioDestino = (int)userDestino.IDUsuario,
					IDUsuarioOrigem = (int)Program.usuarioAtual.IDUsuario,
					IsResposta = true,
					IDOrigem = mensagem.IDMensagem,
					Mensagem = "",
					MensagemData = DateTime.Today,
					MensagemOrigem = mensagem,
					Recebida = false,
					RecebidaData = null,
					Suporte = false,
					UsuarioOrigem = Program.usuarioAtual.UsuarioApelido,
					UsuarioDestino = userDestino.UsuarioApelido
				};

				//--- open form mensagem
				var frmM = new frmMensagemEditar(novaMensagem, userDestino, this);

				frmM.ShowDialog();

				if (frmM.DialogResult != DialogResult.OK) return;

				EnviarMensagem(novaMensagem);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Enviar a Resposta da Mensagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}



		#endregion // MENU SUSPENSO --- END
	}
}
