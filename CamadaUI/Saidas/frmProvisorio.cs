using CamadaBLL;
using CamadaDTO;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmProvisorio : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesaProvisoria _provisoria;
		private List<objDespesa> lstDespesas;
		private DespesaProvisoriaBLL despBLL = new DespesaProvisoriaBLL();
		private BindingSource bindProvisoria = new BindingSource();
		private BindingSource bindDesp = new BindingSource();
		private EnumFlagEstado _Sit;

		private objSetor SetorSelected;
		private objConta ContaSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES  
		// testing

		// CONSTRUCTOR WITH OBJECT DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmProvisorio(objDespesaProvisoria provisoria)
		{
			InitializeComponent();

			// create acesso dados
			AcessoControlBLL acesso = new AcessoControlBLL();
			object dbTran = acesso.GetNewAcessoWithTransaction();

			// set DESPESA
			_provisoria = provisoria;

			// GET DATA
			if (provisoria.IDProvisorio != null)
			{
				GetDespesas(dbTran);
			}
			else
			{
				lstDespesas = new List<objDespesa>();
			}

			// Define CONTA & SETOR
			if (_provisoria.IDProvisorio == null)
			{
				DefineConta(ContaPadrao());
				DefineSetor(SetorPadrao());
			}
			else
			{
				GetConta(dbTran);
				objSetor setor = new objSetor(_provisoria.IDSetor);
				setor.Setor = _provisoria.Setor;
				DefineSetor(setor);
			}

			//--- CLOSE CONNECTION
			acesso.CommitAcessoWithTransaction(dbTran);

			// binding
			bindProvisoria.DataSource = typeof(objDespesaProvisoria);
			bindProvisoria.Add(_provisoria);
			bindDesp.Add(lstDespesas);
			BindingCreator();

			if (_provisoria.IDProvisorio == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				_provisoria.RetiradaData = DateTime.Today;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// handlers
			_provisoria.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
		}

		// SHOW
		//------------------------------------------------------------------------------------------------------------
		private void frmProvisorio_Shown(object sender, EventArgs e)
		{
			if (_provisoria == null)
			{
				Close();
				return;
			}

			txtConta.Enter += text_Enter;
			txtSetor.Enter += text_Enter;
			txtAutorizante.Enter += text_Enter;
			txtComprador.Enter += text_Enter;

			// block keyDown then Sit = Alterado
			txtValorProvisorio.KeyDown += control_KeyDown_Block;
			dtpRetiradaData.KeyDown += control_KeyDown_Block;
		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public EnumFlagEstado Sit
		{
			get { return _Sit; }
			set
			{
				_Sit = value;

				if (value == EnumFlagEstado.NovoRegistro)
				{
					btnSalvar.Enabled = true;
					btnCancelar.Enabled = true;
					// define MaxDate of Data da Despesa
					dtpRetiradaData.MaxDate = DateTime.Today;
					dtpRetiradaData.MinDate = DateTime.Today.AddMonths(-12);
				}
				else
				{
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					// define MaxDate of Data da Despesa
					dtpRetiradaData.MaxDate = DateTime.Today;
					dtpRetiradaData.MinDate = (DateTime)_provisoria.BloqueioData;
				}

				// btnSET ENABLE | DISABLE
				btnSetConta.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetAutorizante.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetComprador.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnInsertComprador.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnInsertAutorizante.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// INTERNAL PROPERTY CONTA
		private void DefineConta(objConta conta)
		{
			ContaSelected = conta;
			txtConta.Text = ContaSelected.Conta;
			lblContaDetalhe.Text = $"Saldo da Conta: {conta.ContaSaldo.ToString("c")} \n" +
								   $"Data de Bloqueio até: {conta.BloqueioData?.ToString() ?? ""}";
			_provisoria.IDConta = (int)conta.IDConta;
			_provisoria.Conta = conta.Conta;
		}

		// INTERNAL PROPERTY SETOR
		private void DefineSetor(objSetor setor)
		{
			SetorSelected = setor;
			txtSetor.Text = SetorSelected.Setor;
			_provisoria.IDSetor = (int)SetorSelected.IDSetor;
			_provisoria.Setor = SetorSelected.Setor;
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region GET IN DB

		// GET A PAGAR data
		//------------------------------------------------------------------------------------------------------------
		private void GetDespesas(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				//--- GET
				lstDespesas = new DespesaProvisoriaBLL().GetDespesasRealizado((int)_provisoria.IDProvisorio, dbTran);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lsita de Despesas Realacionadas..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET CONTA object
		//------------------------------------------------------------------------------------------------------------
		private void GetConta(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				//--- GET
				objConta _conta = new ContaBLL().GetConta((int)_provisoria.IDConta, dbTran);
				DefineConta(_conta);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Conta da Despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // GET IN DB --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS DESPESA
			lblID.DataBindings.Add("Text", bindProvisoria, "IDProvisorio", true);
			txtConta.DataBindings.Add("Text", bindProvisoria, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bindProvisoria, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAutorizante.DataBindings.Add("Text", bindProvisoria, "Autorizante", true, DataSourceUpdateMode.OnPropertyChanged);
			txtComprador.DataBindings.Add("Text", bindProvisoria, "Comprador", true, DataSourceUpdateMode.OnPropertyChanged);
			txtFinalidade.DataBindings.Add("Text", bindProvisoria, "Finalidade", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpRetiradaData.DataBindings.Add("Value", bindProvisoria, "RetiradaData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorProvisorio.DataBindings.Add("Text", bindProvisoria, "ValorProvisorio", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtValorProvisorio.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			if (e.Value == DBNull.Value || e.Value == null)
			{
				e.Value = "NOVA";
			}
			else
			{
				e.Value = $"{e.Value: 0000}";
			}
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

			EP.Clear();
		}

		#endregion // DATABINDING --- END

		#region BUTTONS

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
				bindProvisoria.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}
		}

		#endregion // BUTTONS --- END

		#region BUTTONS PROCURA

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, _provisoria.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && ContaSelected.IDConta != frm.propEscolha.IDConta)
						Sit = EnumFlagEstado.Alterado;
					DefineConta(frm.propEscolha);
				}

				//--- select
				txtConta.Focus();
				txtConta.SelectAll();
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

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _provisoria.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _provisoria.IDSetor != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					DefineSetor(frm.propEscolha);
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

		private void btnSetAutorizante_Click(object sender, EventArgs e)
		{
			frmProvisorioAutorizante frm = new frmProvisorioAutorizante(this, txtAutorizante.Text);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH AUTORIZANTE
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _provisoria.Autorizante != frm.propEscolha)
					Sit = EnumFlagEstado.Alterado;

				_provisoria.Autorizante = frm.propEscolha;
				txtAutorizante.Text = frm.propEscolha;
			}

			//--- select
			txtAutorizante.Focus();
			txtAutorizante.SelectAll();
		}

		private void btnSetComprador_Click(object sender, EventArgs e)
		{
			frmProvisorioComprador frm = new frmProvisorioComprador(this, txtComprador.Text);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH COMPRADOR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _provisoria.Comprador != frm.propEscolha)
					Sit = EnumFlagEstado.Alterado;

				_provisoria.Comprador = frm.propEscolha;
				txtComprador.Text = frm.propEscolha;
			}

			//--- select
			txtComprador.Focus();
			txtComprador.SelectAll();
		}

		private void btnInsertTitular_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmTitularControle frm = new frmTitularControle(this);
				frm.ShowDialog();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de cadastro de Titulares..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS PROCURA --- END

		#region CONTROL FUNCTIONS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtConta,
					txtSetor,
					txtAutorizante,
					txtComprador,
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
			if (Sit == EnumFlagEstado.RegistroSalvo)
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
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtAutorizante":
						btnSetAutorizante_Click(sender, new EventArgs());
						break;
					case "txtComprador":
						btnSetComprador_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = false;
			}
			else if (e.Alt) // permite O 'ALT'
			{
				e.Handled = false;
			}
			else // finaly block all inserts changes
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtSetor,
					txtConta,
					txtAutorizante,
					txtComprador,
				 };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
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

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void control_KeyDown_Block(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------
		}

		#endregion // CONTROL FUNCTIONS --- END

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

		#region SALVAR REGISTRO

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.Alterado)
			{
				AbrirDialog("Não é possível alterar esse registro de Despesa Provisória...", "Alterar Despesa");
				return;
			}

			if (!VerificaRegistro()) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- INSERT Despesa REALIZADA
				long newID = despBLL.InsertDespesaProvisoria(_provisoria);
				_provisoria.IDProvisorio = newID;
				bindProvisoria.EndEdit();
				bindProvisoria.ResetBindings(false);

				Sit = EnumFlagEstado.RegistroSalvo;

				_ = AbrirDialog("Registro de Despesa Provisória salva com sucesso!",
					"Salvamento Efetuado",
					DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Evento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CHECK REGISTRES
		private bool VerificaRegistro()
		{
			// CHECK FIELDS
			if (!VerificaDadosClasse(txtSetor, "Setor Debitado", _provisoria, EP)) return false;
			if (!VerificaDadosClasse(txtAutorizante, "Credor/Fornecedor", _provisoria, EP)) return false;
			if (!VerificaDadosClasse(txtConta, "Conta", _provisoria, EP)) return false;
			if (!VerificaDadosClasse(txtFinalidade, "Descrição da Despesa", _provisoria, EP)) return false;

			// CHECK VALUE
			if (_provisoria.ValorProvisorio <= 0)
			{
				AbrirDialog("O valor da Despesa Provisória precisa ser maior do que Zero...\n" +
					"Favor inserir o valor desta despesa corretamente.", "Valor da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtValorProvisorio, "Valor necessário...");
				txtValorProvisorio.Focus();
				return false;
			}

			return true;
		}

		#endregion // SALVAR REGISTRO --- END
	}
}
