using CamadaBLL;
using CamadaDTO;
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

namespace CamadaUI.DespesaCartao
{
	public partial class frmCartaoCreditoDespesa : CamadaUI.Modals.frmModFinBorder
	{
		private APagarCartaoBLL cBLL = new APagarCartaoBLL();
		private objAPagarCartao _cartao;
		private List<objAPagarCartao> list;
		private List<objCartaoBandeira> listBandeira;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private Form _formOrigem;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmCartaoCreditoDespesa(Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;

			ObterDados();
			GetBandeiraList();
			bind.DataSource = typeof(objAPagarCartao);
			bind.DataSource = list;
			PreencheListagem();
			BindingCreator();

			HandlerKeyDownControl(this);

			//  check bind position and addNew
			if (bind.Position == -1) bind.AddNew();

			// add handler
			bind.CurrentChanged += (a, b) => ChangeCurrent();
			txtCartaoDescricao.Validating += (a, b) => PrimeiraLetraMaiuscula(txtCartaoDescricao);
			ChangeCurrent();
		}

		// PROP CURRENT REGISTRY
		//------------------------------------------------------------------------------------------------------------
		private void ChangeCurrent()
		{
			_cartao = (objAPagarCartao)bind.CurrencyManager.Current;

			if (_cartao != null)
			{
				_cartao.PropertyChanged += RegistroAlterado;

				if (_cartao.IDCartaoCredito == null)
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

				list = cBLL.GetCartaoCreditoDespesaList();
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
		private void GetBandeiraList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listBandeira = new CartaoBLL().GetCartaoBandeiras(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de cartão de Bandeiras de Cartão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDCartaoCredito", true);
			txtCartaoDescricao.DataBindings.Add("Text", bind, "CartaoDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCartaoBandeira.DataBindings.Add("Text", bind, "CartaoBandeira", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCartaoNumeracao.DataBindings.Add("Text", bind, "CartaoNumeracao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "SetorCartao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCredor.DataBindings.Add("Text", bind, "CredorCartao", true, DataSourceUpdateMode.OnPropertyChanged);
			numVencimentoDia.DataBindings.Add("Value", bind, "VencimentoDia", true, DataSourceUpdateMode.OnPropertyChanged);

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
			clnID.DisplayMember = "IDCartaoCredito";
			clnID.ValueMember = "IDCartaoCredito";

			// column 1
			clnCadastro.Width = 275;
			clnCadastro.DisplayMember = "CartaoDescricao";
			clnCadastro.ValueMember = "CartaoDescricao";
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

			if (_formOrigem != null && _formOrigem.GetType() == typeof(frmPrincipal))
			{
				MostraMenuPrincipal();
			}

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

						if (_formOrigem != null && _formOrigem.GetType() == typeof(frmPrincipal))
						{
							MostraMenuPrincipal();
						}
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
			txtCartaoDescricao.Focus();
		}

		// OPEN CARTOES BANDEIRA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnCartoesBandeira_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- show form
				var frm = new Caixa.frmCartaoBandeirasControle(this);
				frm.ShowDialog();

				//--- requery bnadeira list
				GetBandeiraList();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
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

				//--- SAVE: INSERT OR UPDATE
				if (_cartao.IDCartaoCredito == null) //--- save | Insert
				{
					int ID = cBLL.InsertCartaoCreditoDespesa(_cartao);

					//--- define newID
					((objAPagarCartao)bind.Current).IDCartaoCredito = ID;
					bind.EndEdit();
					bind.ResetBindings(false);
				}
				else //--- update
				{
					cBLL.UpdateCartaoCreditoDespesa(_cartao);
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
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Cartão de Crédito..." + "\n" +
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
			if (!VerificaDadosClasse(txtCartaoDescricao, "Descrição do Cartão", _cartao)) return false;
			if (!VerificaDadosClasse(txtCartaoBandeira, "Bandeira do Cartão", _cartao)) return false;
			if (!VerificaDadosClasse(txtCartaoNumeracao, "Numeração do Cartão", _cartao)) return false;
			if (!VerificaDadosClasse(txtSetor, "Setor do Cartão", _cartao)) return false;
			if (!VerificaDadosClasse(txtCredor, "Credor do Cartão", _cartao)) return false;
			if (!VerificaDadosClasse(numVencimentoDia, "Dia do Vencimento do Cartão", _cartao)) return false;

			byte num = (byte)numVencimentoDia.Value;

			if (num > 28 || num < 1)
			{
				AbrirDialog("O vencimento deve ser um número entre 1 e 28", "Vencimento",
					DialogType.OK, DialogIcon.Exclamation);
				numVencimentoDia.Focus();
				return false;
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
					txtCartaoBandeira,
					txtCredor,
					txtSetor,
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
					case "txtCartaoBandeira":
						btnSetBandeira_Click(sender, new EventArgs());
						break;
					case "txtCredor":
						btnSetCredor_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = {
					txtCartaoBandeira
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
					txtCredor,
					txtSetor,
					txtCartaoBandeira
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
					case "txtCartaoBandeira":

						if (listBandeira.Count > 0)
						{
							var bandeira = listBandeira.FirstOrDefault(x => x.IDCartaoBandeira == int.Parse(e.KeyChar.ToString()));

							if (bandeira == null) return;

							if (bandeira.IDCartaoBandeira != _cartao.IDCartaoBandeira)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_cartao.IDCartaoBandeira = (int)bandeira.IDCartaoBandeira;
								txtCartaoBandeira.Text = bandeira.CartaoBandeira;
							}
						}
						break;

					default:
						break;
				}
			}
		}

		// ONLY NUMBERS IN CARTAO NUMERACAO
		//------------------------------------------------------------------------------------------------------------
		private void txtCartaoNumeracao_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
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

		private void btnSetBandeira_Click(object sender, EventArgs e)
		{
			if (listBandeira.Count == 0)
			{
				AbrirDialog("Não há Bandeiras de Cartão de Crédito cadastradas ou ativas...", "Bandeiras de Cartão",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listBandeira.ToDictionary(x => (int)x.IDCartaoBandeira, x => x.CartaoBandeira);
			var textBox = txtCartaoBandeira;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _cartao.IDCartaoBandeira);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_cartao.IDCartaoBandeira = (int)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Setores.frmSetorProcura frm = new Setores.frmSetorProcura(this, _cartao.IDSetorCartao);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _cartao.IDSetorCartao != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					_cartao.IDSetorCartao = (int)frm.propEscolha.IDSetor;
					txtCredor.Text = frm.propEscolha.Setor;
				}

				//--- select
				txtSetor.Focus();
				txtSetor.SelectAll();
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

		private void btnSetCredor_Click(object sender, EventArgs e)
		{
			Registres.frmCredorListagem frm = new Registres.frmCredorListagem(true, this);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _cartao.IDCredorCartao != frm.propEscolha.IDCredor)
					Sit = EnumFlagEstado.Alterado;

				_cartao.IDCredorCartao = (int)frm.propEscolha.IDCredor;
				txtCredor.Text = frm.propEscolha.Credor;
			}
			else if (frm.DialogResult == DialogResult.Yes) // ADD NEW CONTRIBUINTE
			{
				Registres.frmCredor frmNovo = new Registres.frmCredor(new objCredor(null), this);
				frmNovo.ShowDialog();

				if (frmNovo.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _cartao.IDCredorCartao != frmNovo.propEscolha.IDCredor)
						Sit = EnumFlagEstado.Alterado;

					_cartao.IDCredorCartao = (int)frmNovo.propEscolha.IDCredor;
					txtCredor.Text = frmNovo.propEscolha.Credor;
				}
			}

			//--- select
			txtCredor.Focus();
			txtCredor.SelectAll();
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

		#region DESIGN FORM FUNCTIONS

		private void frmSetorProcura_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmSetorProcura_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END

	}
}
