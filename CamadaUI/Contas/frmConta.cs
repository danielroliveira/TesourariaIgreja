using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Contas
{
	public partial class frmConta : CamadaUI.Modals.frmModFinBorder
	{
		private objConta _conta;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private List<objCongregacao> congregacaoList;// = CongBLL.GetListCongregacao();

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmConta(objConta obj)
		{
			InitializeComponent();

			_conta = obj;
			bind.DataSource = _conta;
			BindingCreator();

			_conta.PropertyChanged += RegistroAlterado;

			if (_conta.IDConta == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// get list of congregacao
			GetCongregacaoList();

			AtivoButtonImage();
			HandlerKeyDownControl(this);
			txtConta.Validating += (a, b) => PrimeiraLetraMaiuscula(txtConta);

			// controle do focus dos checkboxes
			chkBancaria.GotFocus += chkBox_ControleFocus;
			chkBancaria.LostFocus += chkBox_ControleFocus;
			chkOperadoraCartao.GotFocus += chkBox_ControleFocus;
			chkOperadoraCartao.LostFocus += chkBox_ControleFocus;
		}

		// ON SHOW CHECK IF EXISTS CONGREGACAO
		//------------------------------------------------------------------------------------------------------------
		private void frmConta_Shown(object sender, EventArgs e)
		{
			if (congregacaoList.Count == 0)
			{
				AbrirDialog("Ainda não há congregações inseridas...\n" +
					"Favor inserir congregações antes de inserir contas.",
					"Inserir Congregações", DialogType.OK, DialogIcon.Exclamation);

				btnFechar_Click(sender, e);
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
						lblSaldoInicialLabel.Visible = true;
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

				DefineShowSaldoInicial(Sit == EnumFlagEstado.NovoRegistro);
			}
		}

		private void DefineShowSaldoInicial(bool isVisible)
		{
			lblSaldoInicialLabel.Visible = isVisible;
			txtSaldoInicial.Visible = isVisible;
			lblDataInicialLabel.Visible = isVisible;
			dtpDataInicial.Visible = isVisible;
			dtpDataInicial.MaxDate = DateTime.Today;

			if (isVisible)
			{
				Height = 420;
				lblContaSaldo.Location = new Point(144, 319);
				lblContaSaldoLabel.Location = new Point(28, 324);
				lblBloqueioDataLabel.Location = new Point(266, 324);
				lblBloqueioData.Location = new Point(397, 319);
			}
			else
			{
				Height = 364;
				lblContaSaldo.Location = new Point(144, 263);
				lblContaSaldoLabel.Location = new Point(28, 268);
				lblBloqueioDataLabel.Location = new Point(266, 268);
				lblBloqueioData.Location = new Point(397, 263);
			}

		}

		private void GetCongregacaoList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var CongBLL = new CongregacaoBLL();
				congregacaoList = CongBLL.GetListCongregacao();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de congregações..." + "\n" +
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
			lblID.DataBindings.Add("Text", bind, "IDConta", true);
			txtConta.DataBindings.Add("Text", bind, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCongregacao.DataBindings.Add("Text", bind, "Congregacao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblContaSaldo.DataBindings.Add("Text", bind, "ContaSaldo", true, DataSourceUpdateMode.OnPropertyChanged);
			lblBloqueioData.DataBindings.Add("Text", bind, "BloqueioData", true, DataSourceUpdateMode.OnPropertyChanged);
			chkOperadoraCartao.DataBindings.Add("Checked", bind, "OperadoraCartao", true, DataSourceUpdateMode.OnPropertyChanged);
			chkBancaria.DataBindings.Add("Checked", bind, "Bancaria", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSaldoInicial.DataBindings.Add("Text", bind, "ContaSaldo", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpDataInicial.DataBindings.Add("Value", bind, "BloqueioData", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblContaSaldo.DataBindings["Text"].Format += FormatCurrency;
			txtSaldoInicial.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
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

			new frmContaListagem().Show();
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
					new frmContaListagem().Show();
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

			_conta = new objConta(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _conta;
			txtConta.Focus();
		}

		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR uma Nova Conta", "Desativar Conta",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			//--- check saldo existente
			if (_conta.ContaSaldo > 0)
			{
				AbrirDialog("Não é possivel desastivar uma CONTA que possui SALDO...",
					"Saldo Existente", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			if (_conta.Ativa == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR a Conta:\n" +
							   txtConta.Text.ToUpper(),
							   "Desativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR a Conta:\n" +
							   txtConta.Text.ToUpper(),
							   "Ativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_conta.BeginEdit();
			_conta.Ativa = !_conta.Ativa;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_conta.Ativa == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativa";
				}
				else if (_conta.Ativa == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativa";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar a conta..." + "\n" +
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

				ContaBLL cBLL = new ContaBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_conta.IDConta == null) //--- save | Insert
				{
					// create ajuste
					objCaixaAjuste ajuste = null;

					if (_conta.ContaSaldo > 0)
					{
						ajuste = CreateAjuste();
						if (ajuste == null) return;
					}

					//--- execute INSERT
					int ID = cBLL.InsertConta(_conta, ajuste, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

					//--- define newID
					_conta.IDConta = ID;
				}
				else //--- update
				{
					cBLL.UpdateConta(_conta);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Conta..." + "\n" +
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
			if (!VerificaDadosClasse(txtConta, "Descrição da Conta", _conta)) return false;
			if (!VerificaDadosClasse(txtCongregacao, "Congregação", _conta)) return false;

			if (_conta.Bancaria && _conta.OperadoraCartao)
			{
				AbrirDialog("Uma conta não pode ser Bancária e Operadora de Cartão simultaneamente..." + "\n" +
							"Favor selecionar uma das opções.",
							"Bancária ou Operadora?",
							DialogType.OK,
							DialogIcon.Exclamation);
				chkBancaria.Focus();
				return false;
			}

			if (Sit == EnumFlagEstado.NovoRegistro && _conta.ContaSaldo == 0)
			{
				var resp = AbrirDialog("O valor do saldo incial da conta não foi informado ou é igual a zero..." + "\n" +
							"Deseja informar o valor do SALDO INICIAL da nova CONTA?",
							"Saldo Inicial",
							DialogType.SIM_NAO,
							DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					txtSaldoInicial.Focus();
					txtSaldoInicial.SelectAll();
					return false;
				}
			}

			return true;
		}

		private objCaixaAjuste CreateAjuste()
		{
			// get Setor de Entrada
			objSetor setor = null;

			Setores.frmSetorProcura frm = new Setores.frmSetorProcura(this);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				setor = frm.propEscolha;

				if (_conta.IDCongregacao != setor.IDCongregacao)
				{
					var resp = AbrirDialog("A Congregação Padrão do Setor de Recursos escolhido é " +
						"diferente da congregação padrão da Nova Conta...\n" +
						"Deseja continuar assim mesmo?", "Congregação Divergente",
						DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

					if (resp == DialogResult.No) return null;
				}

			}
			else
			{
				return null;
			}

			objCaixaAjuste ajuste = new objCaixaAjuste(null)
			{
				AjusteDescricao = "Ajuste de Saldo Inicial Conta",
				IDAjusteTipo = 1,
				IDSetor = (int)setor.IDSetor,
				Setor = setor.Setor,
				IDUserAuth = (int)Program.usuarioAtual.IDUsuario,
				MovData = dtpDataInicial.Value,
				MovValor = _conta.ContaSaldo,
				MovValorReal = _conta.ContaSaldo
			};

			return ajuste;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmConta_KeyDown(object sender, KeyEventArgs e)
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
					case "txtCongregacao":
						btnCongregacaoEscolher_Click(sender, new EventArgs());
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
					case "txtCongregacao":
						if (_conta.IDCongregacao != null) Sit = EnumFlagEstado.Alterado;
						txtCongregacao.Clear();
						_conta.IDCongregacao = null;
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
				Control[] controlesBloqueados = { txtCongregacao };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnCongregacaoEscolher_Click(object sender, EventArgs e)
		{
			if (congregacaoList.Count == 0)
			{
				AbrirDialog("Não há congregações cadastradas...", "Congregação",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = congregacaoList.ToDictionary(x => (int)x.IDCongregacao, x => x.Congregacao);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtCongregacao, _conta.IDCongregacao);

			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_conta.IDCongregacao = frm.propEscolha.Key;
				txtCongregacao.Text = frm.propEscolha.Value;
			}

			//--- select
			txtCongregacao.Focus();
			txtCongregacao.SelectAll();
		}

		// WHEN SELECT RADIO CHANGE COLOR OF PANEL
		//------------------------------------------------------------------------------------------------------------
		private void chkBox_ControleFocus(object sender, EventArgs e)
		{
			pnlChk1.BackColor = Color.Transparent;
			pnlChk2.BackColor = Color.Transparent;

			if (chkBancaria.Focused)
			{
				pnlChk1.BackColor = Color.Gainsboro;
			}
			else if (chkOperadoraCartao.Focused)
			{
				pnlChk2.BackColor = Color.Gainsboro;
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		private void frmConta_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtCongregacao
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}
	}
}
