using CamadaBLL;
using CamadaDTO;
using CamadaUI.Setores;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmCampanha : CamadaUI.Modals.frmModFinBorder
	{
		private CampanhaBLL cBLL = new CampanhaBLL();
		private objCampanha _campanha;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private int? _IDSetor;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmCampanha(objCampanha obj)
		{
			InitializeComponent();

			_campanha = obj;
			bind.DataSource = _campanha;
			BindingCreator();
			_IDSetor = _campanha.IDSetor;

			_campanha.PropertyChanged += RegistroAlterado;

			if (_campanha.IDCampanha == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;

			}

			AtivoButtonImage();
			HandlerKeyDownControl(this);
			txtCampanha.Validating += (a, b) => PrimeiraLetraMaiuscula(txtCampanha);
			GetSaldo();

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

		// OBTER SALDO DA CAMPANHA E UPDATE
		//------------------------------------------------------------------------------------------------------------
		private void GetSaldo()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (_campanha.IDCampanha == null)
				{
					_campanha.CampanhaSaldo = 0;
				}
				else
				{
					decimal SaldoAtual = cBLL.GetCampanhaSaldo((int)_campanha.IDCampanha);

					if (SaldoAtual != _campanha.CampanhaSaldo)
					{
						_campanha.CampanhaSaldo = cBLL.GetCampanhaSaldo((int)_campanha.IDCampanha);

						cBLL.UpdateCampanha(_campanha);
						Sit = EnumFlagEstado.RegistroSalvo;
					}
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter o Saldo da Campanha..." + "\n" +
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
			lblID.DataBindings.Add("Text", bind, "IDCampanha", true);
			txtCampanha.DataBindings.Add("Text", bind, "Campanha", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCampanhaSaldo.DataBindings.Add("Text", bind, "CampanhaSaldo", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpInicioData.DataBindings.Add("Value", bind, "InicioData", true, DataSourceUpdateMode.OnPropertyChanged);
			lblConclusaoData.DataBindings.Add("Text", bind, "ConclusaoData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtObjetivo.DataBindings.Add("Text", bind, "ObjetivoValor", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblCampanhaSaldo.DataBindings["Text"].Format += FormatCurrency;
			txtObjetivo.DataBindings["Text"].Format += FormatCurrency;
			lblConclusaoData.DataBindings["Text"].Format += FormatNullDate;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		private void FormatNullDate(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == null || e.Value == DBNull.Value ? " Ativa" : e.Value;
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

			new frmCampanhaListagem().Show();
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
					new frmCampanhaListagem().Show();
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

			_campanha = new objCampanha(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _campanha;
			txtCampanha.Focus();
			GetSaldo();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_campanha.Ativa == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativa";
				}
				else if (_campanha.Ativa == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Concluída";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar o campanha..." + "\n" +
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

				//--- SAVE: INSERT OR UPDATE
				if (_campanha.IDCampanha == null) //--- save | Insert
				{
					int ID = cBLL.InsertCampanha(_campanha);
					//--- define newID
					_campanha.IDCampanha = ID;
				}
				else //--- update
				{
					cBLL.UpdateCampanha(_campanha);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;

				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Campanha..." + "\n" +
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
			if (!VerificaDadosClasse(txtCampanha, "Campanha", _campanha)) return false;
			if (!VerificaDadosClasse(txtSetor, "Setor", _campanha)) return false;
			if (!VerificaDadosClasse(dtpInicioData, "Data de Início", _campanha)) return false;
			if (!VerificaDadosClasse(txtObjetivo, "Valor do Objetivo Alvo", _campanha)) return false;

			if (_campanha.ObjetivoValor <= 0)
			{
				AbrirDialog("O Valor objetivo alvo não pode ser igual ou menor que zero..." +
					"\nFavor inserir um valor maior que zero.", "Valor Objetivo", DialogType.OK, DialogIcon.Exclamation);
				txtObjetivo.Focus();
				return false;
			}

			return true;
		}

		#endregion

		#region CONTROL FUNCTIONS

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
						if (_campanha.IDSetor != null) Sit = EnumFlagEstado.Alterado;
						txtSetor.Clear();
						_campanha.IDSetor = null;
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

		// OPEN SETOR PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetorEscolher_Click(object sender, EventArgs e)
		{

			frmSetorProcura frm = new frmSetorProcura(this, _campanha.IDSetor);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_campanha.IDSetor = frm.propEscolha.IDSetor;
				txtSetor.Text = frm.propEscolha.Setor;
			}

			//--- select
			txtSetor.Focus();
			txtSetor.SelectAll();

		}

		#endregion // CONTROL FUNCTIONS --- END

	}
}
