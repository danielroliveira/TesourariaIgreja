using CamadaBLL;
using CamadaDTO;
using CamadaUI.Caixa;
using ComponentOwl.BetterListView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAPagarForma : CamadaUI.Modals.frmModFinBorder
	{
		private objAPagarForma _forma;
		private List<objAPagarForma> list;
		private List<objAPagarCartao> listCartao;
		private Dictionary<int, string> dicModo;
		private APagarFormaBLL fBLL = new APagarFormaBLL();
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmAPagarForma()
		{
			InitializeComponent();

			ObterDados();
			GetCartaoList();
			bind.DataSource = typeof(objAPagarForma);
			bind.DataSource = list;
			PreencheListagem();
			BindingCreator();

			HandlerKeyDownControl(this);

			//  check bind position and addNew
			if (bind.Position == -1) bind.AddNew();

			// add handler
			bind.CurrentChanged += (a, b) => ChangeCurrent();
			txtAPagarForma.Validating += (a, b) => PrimeiraLetraMaiuscula(txtAPagarForma);
			ChangeCurrent();
		}


		// PROP CURRENT REGISTRY
		//------------------------------------------------------------------------------------------------------------
		private void ChangeCurrent()
		{
			_forma = (objAPagarForma)bind.CurrencyManager.Current;

			if (_forma != null)
			{
				_forma.PropertyChanged += RegistroAlterado;

				if (_forma.IDAPagarForma == null)
				{
					Sit = EnumFlagEstado.NovoRegistro;
				}
				else
				{
					Sit = EnumFlagEstado.RegistroSalvo;
				}
			}
			else
			{
				bind.AddNew();
			}

			ChangePagFormaModo();
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
						cmbAtivo.Enabled = true;
						lstListagem.Enabled = true;
						break;
					case EnumFlagEstado.Alterado:
						btnNovo.Enabled = false;
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						cmbAtivo.Enabled = true;
						lstListagem.Enabled = false;
						break;
					case EnumFlagEstado.NovoRegistro:
						btnNovo.Enabled = false;
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						cmbAtivo.Enabled = false;
						lstListagem.Enabled = false;
						break;
					case EnumFlagEstado.RegistroBloqueado:
						btnNovo.Enabled = true;
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						cmbAtivo.Enabled = false;
						lstListagem.Enabled = true;
						break;
					default:
						break;
				}
			}
		}

		// GET DADOS
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				list = fBLL.GetListAPagarForma();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter os dados da Listagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// GET CARTAO LIST
		//------------------------------------------------------------------------------------------------------------
		private void GetCartaoList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listCartao = new APagarCartaoBLL().GetCartaoCreditoDespesaList();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de cartão de crédito..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CHANGE MODO
		//------------------------------------------------------------------------------------------------------------
		private void ChangePagFormaModo()
		{
			switch (_forma.IDPagFormaModo)
			{
				case 1: // documento
				case 2: // cheque
					txtBanco.Enabled = true;
					btnSetBanco.Enabled = true;
					txtCartaoCredito.Visible = false;
					btnSetCartao.Visible = false;
					lblCartao.Visible = false;
					break;
				case 3: // cartao
					txtBanco.Enabled = false;
					btnSetBanco.Enabled = false;
					txtCartaoCredito.Visible = true;
					btnSetCartao.Visible = true;
					lblCartao.Visible = true;
					break;
				default:
					break;
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagarForma", true);
			txtAPagarForma.DataBindings.Add("Text", bind, "APagarForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bind, "BancoNome", true, DataSourceUpdateMode.OnPropertyChanged);
			txtPagFormaModo.DataBindings.Add("Text", bind, "PagFormaModo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCartaoCredito.DataBindings.Add("Text", bind, "CartaoCredito.CartaoDescricao", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;

			// FILL COMBO
			CarregaCmbAtivo();
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == null ? "NOVA" : $"{e.Value: 0000}";
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
		private void CarregaCmbAtivo()
		{
			//--- Create DataTable

			DataTable dtAtivo = new DataTable();
			dtAtivo.Columns.Add("Ativo");
			dtAtivo.Columns.Add("Texto");
			dtAtivo.Rows.Add(new object[] { false, "Inativo" });
			dtAtivo.Rows.Add(new object[] { true, "Ativo" });

			//--- Set DataTable
			cmbAtivo.DataSource = dtAtivo;
			cmbAtivo.ValueMember = "Ativo";
			cmbAtivo.DisplayMember = "Texto";

			//--- create Databinding
			cmbAtivo.DataBindings.Add("SelectedValue", bind, "Ativo", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		#endregion

		#region LIST CONTROL

		// PREENCHE LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void PreencheListagem()
		{

			lstListagem.DataSource = bind;

			// column 0
			clnID.Width = 50;
			clnID.DisplayMember = "IDAPagarForma";
			clnID.ValueMember = "IDAPagarForma";

			// column 1
			clnCadastro.Width = 275;
			clnCadastro.DisplayMember = "APagarForma";
			clnCadastro.ValueMember = "APagarForma";
		}

		// DRAW COLUMN HEADER
		//------------------------------------------------------------------------------------------------------------
		private void list_DrawColumnHeader(object sender, BetterListViewDrawColumnHeaderEventArgs eventArgs)
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

		// DRAW ITEMS
		//------------------------------------------------------------------------------------------------------------
		private void list_DrawItem(object sender, BetterListViewDrawItemEventArgs eventArgs)
		{
			if (int.TryParse(eventArgs.Item.Text, out int intValue))
			{
				eventArgs.Item.Text = $"{intValue: 00}";
			}
		}

		#endregion // LIST CONTROL --- END

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
					if (bind.Count == 1)
					{
						Close();
						MostraMenuPrincipal();
					}
					else
					{
						bind.CancelEdit();
					}
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

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			bind.AddNew();
			Sit = EnumFlagEstado.NovoRegistro;
			txtAPagarForma.Focus();
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

				//--- SAVE: INSERT OR UPDATE
				if (_forma.IDAPagarForma == null) //--- save | Insert
				{
					int ID = fBLL.InsertAPagarForma(_forma);

					//--- define newID
					((objAPagarForma)bind.Current).IDAPagarForma = ID;
					bind.EndEdit();
					bind.ResetBindings(false);
				}
				else //--- update
				{
					fBLL.UpdateAPagarForma(_forma);
					bind.EndEdit();
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;

				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Forma de Cobranca..." + "\n" +
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
			if (!VerificaDadosClasse(txtAPagarForma, "Descrição da Forma", _forma)) return false;
			if (!VerificaDadosClasse(txtPagFormaModo, "Modo de Pagamento", _forma)) return false;

			if (_forma.IDPagFormaModo == 3) // if cartao de credito
			{
				if (!VerificaDadosClasse(txtCartaoCredito, "Cartão de Crédito", _forma)) return false;
				_forma.IDBanco = null;
			}
			else
			{
				_forma.IDCartaoCredito = null;
			}

			return true;
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
					txtBanco,
					txtCartaoCredito,
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
			if (Sit == EnumFlagEstado.RegistroSalvo && Program.usuarioAtual.UsuarioAcesso != 0)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtBanco":
						btnSetBanco_Click(sender, new EventArgs());
						break;
					case "txtCartaoCredito":
						btnSetCartao_Click(sender, new EventArgs());
						break;
					case "txtPagFormaModo":
						btnSetModo_Click(sender, new EventArgs());
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
						if (_forma.IDBanco != null)
						{
							if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;
							_forma.IDBanco = null;
							txtBanco.Clear();
						}
						break;
					case "txtCartaoCredito":
						if (_forma.IDCartaoCredito != null)
						{
							if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;
							_forma.IDCartaoCredito = null;
							txtCartaoCredito.Clear();
						}
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = {
					txtCartaoCredito, txtPagFormaModo
				};

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			else if (e.Alt) // permite O 'ALT'
			{
				e.Handled = false;
			}
			else // finaly block all inserts changes
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtCartaoCredito,
					txtBanco,
					txtPagFormaModo
				 };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// CREATE SHORTCUT TO TEXTBOX LIST VALUES
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar))
			{
				Control ctr = (Control)sender;
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCartaoCredito":

						if (listCartao.Count > 0)
						{
							var tipo = listCartao.FirstOrDefault(x => x.IDCartaoBandeira == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDCartaoBandeira != _forma.IDCartaoCredito)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_forma.IDCartaoCredito = (int)tipo.IDCartaoBandeira;
								txtCartaoCredito.Text = tipo.CartaoBandeira;
							}
						}
						break;

					case "txtPagFormaModo":

						// create dic
						if (dicModo == null || dicModo.Count == 0)
						{
							dicModo = new Dictionary<int, string>()
							{
								{1, "Documento" }, {2, "Cheque"}, {3, "Cartao"}
							};
						}

						if (!dicModo.ContainsKey(int.Parse(e.KeyChar.ToString()))) return;

						KeyValuePair<int, string> modo = dicModo.First(x => x.Key == int.Parse(e.KeyChar.ToString()));

						if (modo.Key != _forma.IDPagFormaModo)
						{
							if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

							_forma.IDPagFormaModo = (byte)modo.Key;
							txtPagFormaModo.Text = modo.Value;
						}

						break;

					default:
						break;
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

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmBancoProcura frm = new frmBancoProcura(this, _forma.IDBanco == 0 ? null : (int?)_forma.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _forma.IDBanco != frm.propEscolha.IDBanco)
						Sit = EnumFlagEstado.Alterado;

					_forma.IDBanco = (int)frm.propEscolha.IDBanco;
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

		private void btnSetCartao_Click(object sender, EventArgs e)
		{
			if (listCartao.Count == 0)
			{
				AbrirDialog("Não há registro de Cartão de Crédito cadastrados...", "Cartão de Crédito",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// seleciona o TextBox
			TextBox textBox = txtCartaoCredito;

			var dic = listCartao.ToDictionary(x => (int)x.IDCartaoCredito, x => x.CartaoDescricao);

			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _forma.IDCartaoCredito);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_forma.IDCartaoCredito = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetModo_Click(object sender, EventArgs e)
		{
			// create dic
			if (dicModo == null)
			{
				dicModo = new Dictionary<int, string>()
				{
					{1, "Documento" }, {2, "Cheque"}, {3, "Cartao"}
				};
			}

			// seleciona o TextBox
			TextBox textBox = txtPagFormaModo;

			Main.frmComboLista frm = new Main.frmComboLista(dicModo, textBox, _forma.IDCartaoCredito);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_forma.IDPagFormaModo = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		// OPEN CARTAO FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnCartoesCredito_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new DespesaCartao.frmCartaoCreditoDespesa(this);

				Visible = false;
				frm.ShowDialog();
				Visible = true;

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir Formulário de Cartão de Crédito..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS PROCURA --- END

		#region TOOLTIP

		private void ShowToolTip(Control controle)
		{
			//Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip()
			{
				AutoPopDelay = 2000, // Define o delay para a ToolTip
				InitialDelay = 2000,
				ReshowDelay = 500,
				IsBalloon = true,
				UseAnimation = true,
				UseFading = true
			};

			if (controle.Tag == null)
			{
				toolTip1.Show("Clique aqui...", controle, controle.Width - 30, -40, 2000);
			}
			else
			{
				toolTip1.Show(controle.Tag.ToString(), controle, controle.Width - 30, -40, 2000);
			}
		}



		#endregion


	}
}
