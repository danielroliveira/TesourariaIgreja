using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Caixa
{
	public partial class frmCartaoTaxa : CamadaUI.Modals.frmModFinBorder
	{
		private objCartaoTaxa _taxa;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private List<objCartaoOperadora> operadoraList;// = CongBLL.GetListCongregacao();
		private List<objCartaoBandeira> bandeirasList;// = CongBLL.GetListCongregacao();

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmCartaoTaxa(objCartaoTaxa obj)
		{
			InitializeComponent();

			_taxa = obj;
			bind.DataSource = _taxa;
			BindingCreator();

			_taxa.PropertyChanged += RegistroAlterado;

			if (_taxa.IDCartaoTaxa == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// get list of Operadoras and bandeiras
			GetOperadorasList();
			GetBandeirasList();

			AtivoButtonImage();
			HandlerKeyDownControl(this);

		}

		// ON SHOW CHECK IF EXISTS CONGREGACAO
		//------------------------------------------------------------------------------------------------------------
		private void frmCartaoTaxa_Shown(object sender, EventArgs e)
		{
			bool itsOK = true;

			if (operadoraList == null || operadoraList.Count == 0)
			{
				AbrirDialog("Ainda não há operadoras de cartão inseridas...\n" +
					"Favor inserir operadoras de cartão antes de inserir as taxas.",
					"Inserir Operadoras de Cartão", DialogType.OK, DialogIcon.Exclamation);

				itsOK = false;
			}

			if (itsOK && (bandeirasList == null || bandeirasList.Count == 0))
			{
				AbrirDialog("Ainda não há bandeiras de cartão inseridas...\n" +
					"Favor inserir bandeiras de cartão antes de inserir as taxas.",
					"Inserir Bandeiras de Cartão", DialogType.OK, DialogIcon.Exclamation);

				itsOK = false;
			}

			if (!itsOK)
			{
				Close();
				MostraMenuPrincipal();
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

		private void GetOperadorasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var cartaoBLL = new CartaoBLL();
				operadoraList = cartaoBLL.GetCartaoOperadora();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de operadoras..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void GetBandeirasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var cartaoBLL = new CartaoBLL();
				bandeirasList = cartaoBLL.GetCartaoBandeiras();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de bandeiras de cartão..." + "\n" +
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
			lblID.DataBindings.Add("Text", bind, "IDCartaoTaxa", true);
			txtCartaoOperadora.DataBindings.Add(
				"Text", bind, "CartaoOperadora", true,
				DataSourceUpdateMode.OnPropertyChanged);
			lblContaProvisoria.DataBindings.Add(
				"Text", bind, "ContaProvisoria", true,
				DataSourceUpdateMode.OnPropertyChanged, "favor escolher uma operadora...");
			txtCartaoBandeira.DataBindings.Add("Text", bind, "CartaoBandeira", true, DataSourceUpdateMode.OnPropertyChanged);
			txtPrazoDebito.DataBindings.Add("Text", bind, "PrazoDebito", true, DataSourceUpdateMode.OnPropertyChanged);
			txtPrazoCredito.DataBindings.Add("Text", bind, "PrazoCredito", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxaCredito.DataBindings.Add("Text", bind, "TaxaCredito", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxaDebito.DataBindings.Add("Text", bind, "TaxaDebito", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa2.DataBindings.Add("Text", bind, "Taxa2", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa3.DataBindings.Add("Text", bind, "Taxa3", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa4.DataBindings.Add("Text", bind, "Taxa4", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa5.DataBindings.Add("Text", bind, "Taxa5", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa6.DataBindings.Add("Text", bind, "Taxa6", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa7.DataBindings.Add("Text", bind, "Taxa7", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa8.DataBindings.Add("Text", bind, "Taxa8", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa9.DataBindings.Add("Text", bind, "Taxa9", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa10.DataBindings.Add("Text", bind, "Taxa10", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa11.DataBindings.Add("Text", bind, "Taxa11", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTaxa12.DataBindings.Add("Text", bind, "Taxa12", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtPrazoCredito.DataBindings["Text"].Format += Format00;
			txtPrazoDebito.DataBindings["Text"].Format += Format00;
			txtTaxaCredito.DataBindings["Text"].Format += FormatTaxa;
			txtTaxaDebito.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa2.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa3.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa4.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa5.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa6.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa7.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa8.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa9.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa10.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa11.DataBindings["Text"].Format += FormatTaxa;
			txtTaxa12.DataBindings["Text"].Format += FormatTaxa;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == null ? "nova" : $"{e.Value: 0000}";
		}

		private void Format00(object sender, ConvertEventArgs e)
		{
			if (e.Value != null)
			{
				e.Value = ((byte)e.Value).ToString("D2");
			}
		}

		private void FormatTaxa(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == null ? null : $"{e.Value: #.00}";
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}
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

			new frmCartaoControle().Show();
			Close();

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
					new frmCartaoControle().Show();
					MostraMenuPrincipal();
					Close();
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

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_taxa = new objCartaoTaxa(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _taxa;
			txtCartaoOperadora.Focus();
		}

		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR uma Nova Conta", "Desativar Conta",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_taxa.Ativo == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR a Operadora:\n" +
							   txtCartaoOperadora.Text.ToUpper(),
							   "Desativar Operadora", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR a Operadora:\n" +
							   txtCartaoOperadora.Text.ToUpper(),
							   "Ativar Operadora", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_taxa.BeginEdit();
			_taxa.Ativo = !_taxa.Ativo;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_taxa.Ativo == true) //--- Nesse caso é Operadora Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativa";
				}
				else if (_taxa.Ativo == false) //--- Nesse caso é Operadora Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativa";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar a Operadora..." + "\n" +
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

				CartaoBLL cBLL = new CartaoBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_taxa.IDCartaoTaxa == null) //--- save | Insert
				{
					int ID = cBLL.InsertCartaoTaxas(_taxa);
					//--- define newID
					_taxa.IDCartaoTaxa = ID;
				}
				else //--- update
				{
					cBLL.UpdateCartaoTaxas(_taxa);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				if (((System.Data.SqlClient.SqlException)ex).Number == 2627) // operadora + bandeira duplicada
				{
					AbrirDialog($"As taxas da operadora: {_taxa.CartaoOperadora} já foi inserida com " +
						(_taxa.IDCartaoBandeira == null ? "bandeiras diversas." : $"a bandeira {_taxa.CartaoBandeira}."),
						"Duplicação de Cadastro", DialogType.OK, DialogIcon.Exclamation);
				}
				else
				{
					AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Operadora..." + "\n" +
								ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				}
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtCartaoOperadora, "Operadora", _taxa)) return false;
			return true;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmCartaoTaxa_KeyDown(object sender, KeyEventArgs e)
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
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCartaoOperadora":
						btnSetOperadora_Click(sender, new EventArgs());
						break;
					case "txtCartaoBandeira":
						btnSetBandeira_Click(sender, new EventArgs());
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
					case "txtCartaoBandeira":
						if (_taxa.IDCartaoBandeira != null) Sit = EnumFlagEstado.Alterado;
						txtCartaoBandeira.Clear();
						_taxa.IDCartaoBandeira = null;
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
				Control[] controlesBloqueados = { txtCartaoOperadora, txtCartaoBandeira };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// OPEN OPERADORA PROCURA LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetOperadora_Click(object sender, EventArgs e)
		{
			if (operadoraList.Count == 0)
			{
				AbrirDialog("Não há operadoras cadastradas...", "Operadoras",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = operadoraList.ToDictionary(x => (int)x.IDCartaoOperadora, x => x.CartaoOperadora);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtCartaoOperadora, _taxa.IDCartaoOperadora);

			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_taxa.IDCartaoOperadora = frm.propEscolha.Key;
				txtCartaoOperadora.Text = frm.propEscolha.Value;
				lblContaProvisoria.Text = operadoraList.First(x => x.IDCartaoOperadora == frm.propEscolha.Key).Conta;
			}

			//--- select
			txtCartaoOperadora.Focus();
			txtCartaoOperadora.SelectAll();
		}

		// OPEN BANDEIRA PROCURA LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetBandeira_Click(object sender, EventArgs e)
		{
			if (operadoraList.Count == 0)
			{
				AbrirDialog("Não há BANDEIRAS cadastradas...", "BANDEIRAS",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = bandeirasList.ToDictionary(x => (int)x.IDCartaoBandeira, x => x.CartaoBandeira);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtCartaoBandeira, _taxa.IDCartaoBandeira);

			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

				_taxa.IDCartaoBandeira = frm.propEscolha.Key;
				txtCartaoBandeira.Text = frm.propEscolha.Value;
			}

			//--- select
			txtCartaoBandeira.Focus();
			txtCartaoBandeira.SelectAll();
		}

		// CONTROL KEYPRESS (+)
		private void frmCartaoTaxa_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtCartaoOperadora, txtCartaoBandeira
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

	}
}
