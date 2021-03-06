﻿using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Congregacoes
{
	public partial class frmCongregacao : CamadaUI.Modals.frmModFinBorder
	{
		private objCongregacao _congregacao;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objSetor> listSetor;
		private List<objReuniao> listReuniao;

		// DEFINE DATAGRID FONTS
		private Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmCongregacao(objCongregacao obj)
		{
			InitializeComponent();

			_congregacao = obj;
			bind.DataSource = _congregacao;
			BindingCreator();

			_congregacao.PropertyChanged += RegistroAlterado;

			if (_congregacao.IDCongregacao == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
				ObterDadosSetor();
				ObterDadosReuniao();
			}

			AtivoButtonImage();

			// ADD HANDLERS
			HandlerKeyDownControl(this);

			// ADD HANDLER UPPER CASE
			txtCongregacao.Validating += (a, b) => PrimeiraLetraMaiuscula(txtCongregacao);
			txtDirigente.Validating += (a, b) => PrimeiraLetraMaiuscula(txtDirigente);
			txtTesoureiro.Validating += (a, b) => PrimeiraLetraMaiuscula(txtTesoureiro);
			txtEnderecoLogradouro.Validating += (a, b) => PrimeiraLetraMaiuscula(txtEnderecoLogradouro);
			txtBairro.Validating += (a, b) => PrimeiraLetraMaiuscula(txtBairro);
			txtCidade.Validating += (a, b) => PrimeiraLetraMaiuscula(txtCidade);
		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public EnumFlagEstado Sit
		{
			get { return _Sit; }
			set
			{
				// before change ---> redefine format and controls
				DefineSize(value);

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

		private void DefineSize(EnumFlagEstado newSit)
		{
			if (Sit == newSit) return;

			switch (newSit)
			{
				case EnumFlagEstado.NovoRegistro:
					lblReuniao.Visible = false;
					dgvReuniao.Visible = false;
					lblSetores.Visible = false;
					dgvSetor.Visible = false;
					Size = new Size(560, 503);
					break;
				case EnumFlagEstado.RegistroSalvo:
				case EnumFlagEstado.Alterado:
				case EnumFlagEstado.RegistroBloqueado:
					lblReuniao.Visible = true;
					dgvReuniao.Visible = true;
					lblSetores.Visible = true;
					dgvSetor.Visible = true;
					Size = new Size(940, 503);
					break;
				default:
					break;
			}

			//--- Redesenha a border do form
			Rectangle rect = new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
			Pen pen = new Pen(Color.SlateGray, 3);
			Refresh();
			CreateGraphics().DrawRectangle(pen, rect);
		}

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDadosSetor()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				SetorBLL sBLL = new SetorBLL();
				listSetor = sBLL.GetListSetor("", null, _congregacao.IDCongregacao);
				dgvSetor.DataSource = listSetor;
				FormataListagemSetor();
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

		private void ObterDadosReuniao()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ReuniaoBLL rBLL = new ReuniaoBLL();
				listReuniao = rBLL.GetListReuniao("", null, _congregacao.IDCongregacao);
				dgvReuniao.DataSource = listReuniao;
				FormataListagemReuniao();
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

		#endregion

		#region DATAGRID LIST FUNCTIONS

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagemSetor()
		{
			dgvSetor.Columns.Clear();
			dgvSetor.AutoGenerateColumns = false;
			dgvSetor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvSetor.MultiSelect = false;
			dgvSetor.ColumnHeadersVisible = true;
			dgvSetor.AllowUserToResizeRows = false;
			dgvSetor.AllowUserToResizeColumns = false;
			dgvSetor.RowHeadersWidth = 36;
			dgvSetor.RowTemplate.Height = 30;
			dgvSetor.StandardTab = true;
			dgvSetor.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			// FONT
			dgvSetor.Font = clnFont;
			dgvSetor.DefaultCellStyle.Font = clnFont;
			dgvSetor.AlternatingRowsDefaultCellStyle.Font = clnFont;
			dgvSetor.ColumnHeadersDefaultCellStyle.Font = clnFont;

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (1) COLUNA SETOR
			clnSetor.DataPropertyName = "Setor";
			clnSetor.Visible = true;
			clnSetor.ReadOnly = true;
			clnSetor.Resizable = DataGridViewTriState.False;
			clnSetor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSetor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnSetor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnSetor);

			//--- (2) COLUNA SALDO
			clnSaldo.DataPropertyName = "SetorSaldo";
			clnSaldo.Visible = true;
			clnSaldo.ReadOnly = true;
			clnSaldo.Resizable = DataGridViewTriState.False;
			clnSaldo.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSaldo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnSaldo.DefaultCellStyle.Format = "c";
			colList.Add(clnSaldo);

			//--- Add Columns
			dgvSetor.Columns.AddRange(colList.ToArray());
		}

		private void FormataListagemReuniao()
		{
			dgvReuniao.Columns.Clear();
			dgvReuniao.AutoGenerateColumns = false;
			dgvReuniao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvReuniao.MultiSelect = false;
			dgvReuniao.ColumnHeadersVisible = true;
			dgvReuniao.AllowUserToResizeRows = false;
			dgvReuniao.AllowUserToResizeColumns = false;
			dgvReuniao.RowHeadersWidth = 36;
			dgvReuniao.RowTemplate.Height = 30;
			dgvReuniao.StandardTab = true;
			dgvReuniao.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			// FONT
			dgvReuniao.Font = clnFont;
			dgvReuniao.DefaultCellStyle.Font = clnFont;
			dgvReuniao.AlternatingRowsDefaultCellStyle.Font = clnFont;
			dgvReuniao.ColumnHeadersDefaultCellStyle.Font = clnFont;

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (1) COLUNA REUNIAO
			clnReuniao.DataPropertyName = "Reuniao";
			clnReuniao.Visible = true;
			clnReuniao.ReadOnly = true;
			clnReuniao.Resizable = DataGridViewTriState.False;
			clnReuniao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnReuniao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnReuniao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			colList.Add(clnReuniao);

			//--- (2) Coluna da imagem
			clnImage.Name = "Ativa";
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			colList.Add(clnImage);

			//--- Add Columns
			dgvReuniao.Columns.AddRange(colList.ToArray());
		}

		// CONTROL IMAGES OF LIST DATAGRID
		//------------------------------------------------------------------------------------------------------------
		private void dgvReuniao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == clnImage.Index)
			{
				objReuniao item = (objReuniao)dgvReuniao.Rows[e.RowIndex].DataBoundItem;
				if (item.Ativa) e.Value = ImgAtivo;
				else e.Value = ImgInativo;
				e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDcongregacao", true);
			txtCongregacao.DataBindings.Add("Text", bind, "Congregacao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDirigente.DataBindings.Add("Text", bind, "Dirigente", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTesoureiro.DataBindings.Add("Text", bind, "Tesoureiro", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEnderecoLogradouro.DataBindings.Add("Text", bind, "EnderecoLogradouro", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEnderecoNumero.DataBindings.Add("Text", bind, "EnderecoNumero", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEnderecoComplemento.DataBindings.Add("Text", bind, "EnderecoComplemento", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBairro.DataBindings.Add("Text", bind, "Bairro", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
			txtCidade.DataBindings.Add("Text", bind, "Cidade", true, DataSourceUpdateMode.OnPropertyChanged);
			txtUF.DataBindings.Add("Text", bind, "UF", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCEP.DataBindings.Add("Text", bind, "CEP", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTelefoneFixo.DataBindings.Add("Text", bind, "TelefoneFixo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTelefoneDirigente.DataBindings.Add("Text", bind, "TelefoneDirigente", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEmail.DataBindings.Add("Text", bind, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "CongregacaoSetor");

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
			//MessageBox.Show("alterado");
		}

		#endregion

		#region BUTTONS

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_congregacao = new objCongregacao(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _congregacao;
			txtCongregacao.Focus();
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

				if (response == DialogResult.Yes)
				{
					Close();
					MostraMenuPrincipal();
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

		// OPEN SETOR PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetorEscolher_Click(object sender, EventArgs e)
		{
			frmCongregacaoSetorProcura frm = new frmCongregacaoSetorProcura(this, _congregacao.IDCongregacaoSetor);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_congregacao.IDCongregacaoSetor = frm.propEscolha.IDCongregacaoSetor;
				txtSetor.Text = frm.propEscolha.CongregacaoSetor;
			}

			//--- select
			txtSetor.Focus();
			txtSetor.SelectAll();
		}

		// CONTROLA ATIVO BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR uma Nova Congregação", "Desativar Congregação",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_congregacao.Ativo == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR a Congregação:\n" +
							   txtCongregacao.Text.ToUpper(),
							   "Desativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR a Congregação:\n" +
							   txtCongregacao.Text.ToUpper(),
							   "Ativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_congregacao.BeginEdit();
			_congregacao.Ativo = !_congregacao.Ativo;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		// CONTROLA IMAGEM CONTROLE ATIVO
		//------------------------------------------------------------------------------------------------------------
		private void AtivoButtonImage()
		{
			try
			{
				if (_congregacao.Ativo == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativa";
				}
				else if (_congregacao.Ativo == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativa";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar a congregação..." + "\n" +
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

				CongregacaoBLL cBLL = new CongregacaoBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_congregacao.IDCongregacao == null) //--- save | Insert
				{
					//--- save | Insert
					int ID = cBLL.InsertCongregacao(_congregacao);
					//--- define newID
					_congregacao.IDCongregacao = ID;
				}
				else //--- update
				{
					cBLL.UpdateCongregacao(_congregacao);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Congregação..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtCongregacao, "Congregação", _congregacao)) return false;
			return true;
		}

		#endregion

		#region FORM CONTROLS FUCTIONS

		// FORM KEYPRESS: BLOQUEIA (+)
		//------------------------------------------------------------------------------------------------------------
		private void frmCongregacao_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtSetor
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
					case "txtSetor":
						btnSetorEscolher_Click(sender, new EventArgs());
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
						if (_congregacao.IDCongregacaoSetor != null) Sit = EnumFlagEstado.Alterado;
						txtSetor.Clear();
						_congregacao.IDCongregacaoSetor = null;
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
				Control[] controlesBloqueados = { txtSetor };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// ACCEPTS ONLY NUMBERS AND BACKSPACE (keychar = 8)
		private void txtEnderecoNumero_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
				e.Handled = true;
		}

		#endregion // FORM CONTROLS FUCTIONS --- END

	}
}
