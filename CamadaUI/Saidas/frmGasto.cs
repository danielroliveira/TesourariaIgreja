﻿using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
using CamadaUI.Registres;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmGasto : CamadaUI.Modals.frmModFinBorder
	{
		public objDespesaComum propDespesa;
		private objAPagar _pagar;
		private objMovimentacao _saida;
		private DespesaComumBLL despBLL = new DespesaComumBLL();
		private BindingSource bindDespesa = new BindingSource();
		private BindingSource bindPagar = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objAPagarForma> listFormas;
		private List<objDespesaDocumentoTipo> listDocTipos;

		private objSetor SetorSelected;
		private objConta ContaSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider
		private Form _formOrigem = null;

		private DateTime? _MinDateProvisoria = null;

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		// CONSTRUCTOR WITH OBJECT DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmGasto(objDespesaComum despesa, int? IDContaFromProvisoria = null, DateTime? MinDateFromProvisoria = null)
		{
			InitializeComponent();

			// create acesso dados
			AcessoControlBLL acesso = new AcessoControlBLL();
			object dbTran = acesso.GetNewAcessoWithTransaction();

			// set DESPESA
			propDespesa = despesa;

			// Save Min Date if from Provisoria
			_MinDateProvisoria = MinDateFromProvisoria;

			// GET DATA
			if (despesa.IDDespesa != null)
			{
				GetAPagar(dbTran);
				GetSaida(dbTran);
			}
			else
			{
				_pagar = new objAPagar(null);
				_saida = new objMovimentacao(null);

				if (Application.OpenForms.OfType<frmProvisorio>().Count() == 1)
				{
					_formOrigem = Application.OpenForms.OfType<frmProvisorio>().First();
					_formOrigem.Visible = false;
				}
			}

			GetFormasList(dbTran);
			GetDocTipos(dbTran);

			// Define CONTA
			if (_saida.IDMovimentacao == null)
			{
				if (IDContaFromProvisoria != null)
				{
					_saida.IDConta = (int)IDContaFromProvisoria;
					GetConta(dbTran);
				}
				else
				{
					DefineConta(ContaPadrao());
				}
			}
			else
			{
				GetConta(dbTran);
			}

			//--- CLOSE CONNECTION
			acesso.CommitAcessoWithTransaction(dbTran);

			//--- CONTINUE
			ConstructorContinue();
		}

		// CONSTRUCTOR WITH ID
		//------------------------------------------------------------------------------------------------------------
		public frmGasto(long IDDespesa)
		{
			InitializeComponent();

			// create acesso dados
			AcessoControlBLL acesso = new AcessoControlBLL();
			object dbTran = acesso.GetNewAcessoWithTransaction();

			// GET DATA
			var despesa = GetDespesaByID(IDDespesa, dbTran);

			if (despesa != null)
			{
				propDespesa = despesa;
				GetAPagar(dbTran);
				GetSaida(dbTran);
			}
			else
			{
				return;
			}

			GetFormasList(dbTran);
			GetDocTipos(dbTran);

			// Define CONTA
			if (_saida.IDMovimentacao == null)
			{
				DefineConta(ContaPadrao());
			}
			else
			{
				GetConta(dbTran);
			}

			//--- CLOSE CONNECTION
			acesso.CommitAcessoWithTransaction(dbTran);

			//--- CONTINUE
			ConstructorContinue();
		}

		// CONSTRUCTOR CONTINUE AFTER GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue()
		{
			// Define Setor
			if (_saida.IDMovimentacao == null)
			{
				DefineSetor(SetorPadrao());
			}
			else
			{
				objSetor setor = new objSetor(_saida.IDSetor);
				setor.Setor = _saida.Setor;
				DefineSetor(setor);
			}

			// binding
			bindDespesa.DataSource = typeof(objDespesaComum);
			bindDespesa.Add(propDespesa);
			bindPagar.DataSource = typeof(objAPagar);
			bindPagar.Add(_pagar);
			BindingCreator();

			if (propDespesa.IDDespesa == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;

				if (_MinDateProvisoria != null)
				{
					propDespesa.DespesaData = (DateTime)_MinDateProvisoria;
					dtpDespesaData.MinDate = (DateTime)_MinDateProvisoria;
					txtConta.Enabled = false;
					btnSetConta.Enabled = false;
				}
				else
				{
					propDespesa.DespesaData = DataPadrao();
				}
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// handlers
			propDespesa.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
		}

		// SHOW
		//------------------------------------------------------------------------------------------------------------
		private void frmGasto_Shown(object sender, EventArgs e)
		{
			if (propDespesa == null)
			{
				Close();
				return;
			}

			txtSetor.Enter += Text_Enter;
			txtCredor.Enter += Text_Enter;
			txtDespesaTipo.Enter += Text_Enter;
			txtDocumentoTipo.Enter += Text_Enter;
			txtBanco.Enter += Text_Enter;
			txtAPagarForma.Enter += Text_Enter;

			// block keyDown then Sit = Alterado
			txtDocumentoNumero.KeyDown += control_KeyDown_Block;
			txtDespesaValor.KeyDown += control_KeyDown_Block;
			txtDesconto.KeyDown += control_KeyDown_Block;
			txtAcrescimo.KeyDown += control_KeyDown_Block;
			dtpDespesaData.KeyDown += control_KeyDown_Block;

			// if frmListagem is ENABLED
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
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

				if (value == EnumFlagEstado.NovoRegistro)
				{
					btnNovo.Enabled = false;
					btnSalvar.Enabled = true;
					btnCancelar.Enabled = true;
					// define MaxDate of Data da Despesa
					dtpDespesaData.MaxDate = DateTime.Today;
					dtpDespesaData.MinDate = DateTime.Today.AddMonths(-12);
				}
				else
				{
					btnNovo.Enabled = true;
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					// define MaxDate of Data da Despesa
					dtpDespesaData.MaxDate = propDespesa.DespesaData;
					dtpDespesaData.MinDate = propDespesa.DespesaData;
				}

				// btnSET ENABLE | DISABLE
				btnSetConta.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetDespesaTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetDocumentoTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetCredor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetBanco.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetForma.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetTitular.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnInsertTitular.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// INTERNAL PROPERTY CONTA
		private void DefineConta(objConta conta)
		{
			ContaSelected = conta;
			txtConta.Text = ContaSelected.Conta;
			lblContaDetalhe.Text = $"Saldo da Conta: {conta.ContaSaldo.ToString("c")} \n" +
								   $"Data de Bloqueio até: {conta.BloqueioData?.ToString() ?? ""}";
			_saida.IDConta = (int)conta.IDConta;
			_saida.Conta = conta.Conta;
		}

		// INTERNAL PROPERTY SETOR
		private void DefineSetor(objSetor setor)
		{
			SetorSelected = setor;
			txtSetor.Text = SetorSelected.Setor;
			propDespesa.IDSituacao = 2; // quitada
			propDespesa.IDSetor = (int)SetorSelected.IDSetor;
			propDespesa.Setor = SetorSelected.Setor;
			_pagar.IDSetor = (int)setor.IDSetor;
			_pagar.Setor = setor.Setor;
			_saida.IDSetor = (int)setor.IDSetor;
			_saida.Setor = setor.Setor;
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region GET IN DB

		// GET DESPESA BY ID
		//------------------------------------------------------------------------------------------------------------
		private objDespesaComum GetDespesaByID(long ID, object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return despBLL.GetDespesa(ID, dbTran);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF DOCUMENTO TIPOS
		//------------------------------------------------------------------------------------------------------------
		private void GetDocTipos(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listDocTipos = despBLL.GetDespesaDocumentoTipos(null, dbTran);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Tipos de Documento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF FORMAS DE COBRANCA
		//------------------------------------------------------------------------------------------------------------
		private void GetFormasList(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listFormas = new APagarFormaBLL().GetListAPagarForma(true, dbTran).FindAll(x => x.IDPagFormaModo == 1);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Formas de Cobrança..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET A PAGAR data
		//------------------------------------------------------------------------------------------------------------
		private void GetAPagar(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				//--- GET
				_pagar = new APagarBLL().GetListAPagarByDespesa((long)propDespesa.IDDespesa, dbTran)[0];
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter o APagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET SAIDA INFO
		//------------------------------------------------------------------------------------------------------------
		private void GetSaida(object dbTran)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				//--- GET
				_saida = new MovimentacaoBLL().GetMovimentacaoListByOrigem(EnumMovOrigem.APagar, (long)_pagar.IDAPagar, true, dbTran)[0];
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter o APagar..." + "\n" +
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
				objConta _conta = new ContaBLL().GetConta((int)_saida.IDConta, dbTran);
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
			lblID.DataBindings.Add("Text", bindDespesa, "IDDespesa", true);
			txtSetor.DataBindings.Add("Text", bindDespesa, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCredor.DataBindings.Add("Text", bindDespesa, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaTipo.DataBindings.Add("Text", bindDespesa, "DespesaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDocumentoTipo.DataBindings.Add("Text", bindDespesa, "DocumentoTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDocumentoNumero.DataBindings.Add("Text", bindDespesa, "DocumentoNumero", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaDescricao.DataBindings.Add("Text", bindDespesa, "DespesaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpDespesaData.DataBindings.Add("Value", bindDespesa, "DespesaData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaValor.DataBindings.Add("Text", bindDespesa, "DespesaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTitular.DataBindings.Add("Text", bindDespesa, "Titular", true, DataSourceUpdateMode.OnPropertyChanged);

			// CREATE BINDIGS APAGAR
			txtAPagarForma.DataBindings.Add("Text", bindPagar, "APagarForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bindPagar, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAcrescimo.DataBindings.Add("Text", bindPagar, "ValorAcrescimo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDesconto.DataBindings.Add("Text", bindPagar, "ValorDesconto", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtDespesaValor.DataBindings["Text"].Format += FormatCurrency;
			txtAcrescimo.DataBindings["Text"].Format += FormatCurrency;
			txtDesconto.DataBindings["Text"].Format += FormatCurrency;
			txtTitular.DataBindings["Text"].Format += FormatNomeCNP;

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

		private void FormatNomeCNP(object sender, ConvertEventArgs e)
		{
			e.Value = string.IsNullOrEmpty(propDespesa.CNP) ? e.Value : $"{e.Value} ({propDespesa.CNP})";
		}

		#endregion // DATABINDING --- END

		#region BUTTONS

		private void btnNovo_Click(object sender, EventArgs e)
		{
			// if frmAPagarListagem is ENABLED then exit
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}

			if (Sit == EnumFlagEstado.NovoRegistro || Sit == EnumFlagEstado.RegistroBloqueado) return;

			propDespesa = new objDespesaComum(null);
			_pagar = new objAPagar(null);
			_saida = new objMovimentacao(null);

			bindDespesa.DataSource = propDespesa;
			bindPagar.DataSource = _pagar;
			DefineConta(ContaPadrao());
			DefineSetor(SetorPadrao());

			Sit = EnumFlagEstado.NovoRegistro;
			txtSetor.Focus();
		}

		private void btnFechar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.Alterado || Sit == EnumFlagEstado.NovoRegistro)
			{
				AbrirDialog("Esse registro ainda não foi salvo... \n" +
					"Favor SALVAR ou CANCELAR a edição do registro atual antes de fechar.",
					"Registro Novo ou Alterado", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			CloseAndMostraMenu(false);
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de um novo registro?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					CloseAndMostraMenu(false);
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bindDespesa.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		private void CloseAndMostraMenu(bool saved)
		{
			if (_formOrigem != null)
			{
				DialogResult = saved ? DialogResult.OK : DialogResult.Cancel;
				_formOrigem.Visible = true;
			}
			else
			{
				Close();
				MostraMenuPrincipal();
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

				Contas.frmContaProcura frm = new Contas.frmContaProcura(this, _saida.IDConta);
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

				frmSetorProcura frm = new frmSetorProcura(this, propDespesa.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && propDespesa.IDSetor != frm.propEscolha.IDSetor)
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

		private void btnSetCredor_Click(object sender, EventArgs e)
		{
			frmCredorListagem frm = new frmCredorListagem(true, this);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && propDespesa.IDCredor != frm.propEscolha.IDCredor)
					Sit = EnumFlagEstado.Alterado;

				propDespesa.IDCredor = (int)frm.propEscolha.IDCredor;
				txtCredor.Text = frm.propEscolha.Credor;
			}
			else if (frm.DialogResult == DialogResult.Yes) // ADD NEW CONTRIBUINTE
			{
				frmCredor frmNovo = new frmCredor(new objCredor(null), this);
				frmNovo.ShowDialog();

				if (frmNovo.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && propDespesa.IDCredor != frmNovo.propEscolha.IDCredor)
						Sit = EnumFlagEstado.Alterado;

					propDespesa.IDCredor = (int)frmNovo.propEscolha.IDCredor;
					txtCredor.Text = frmNovo.propEscolha.Credor;
				}
			}

			//--- select
			txtCredor.Focus();
			txtCredor.SelectAll();
		}

		private void btnSetDespesaTipo_Click(object sender, EventArgs e)
		{
			frmDespesaTipoProcura frm = new frmDespesaTipoProcura(this, propDespesa.IDDespesaTipo == 0 ? null : (int?)propDespesa.IDDespesaTipo);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && propDespesa.IDCredor != frm.propEscolha.IDDespesaTipo)
					Sit = EnumFlagEstado.Alterado;

				propDespesa.IDDespesaTipo = (int)frm.propEscolha.IDDespesaTipo;
				txtDespesaTipo.Text = frm.propEscolha.DespesaTipo;
			}

			//--- select
			txtDespesaTipo.Focus();
			txtDespesaTipo.SelectAll();
		}

		private void btnSetDocumentoTipo_Click(object sender, EventArgs e)
		{
			if (listDocTipos.Count == 0)
			{
				AbrirDialog("Não há Tipos de Documento inseridos...", "Tipos de Documento",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// seleciona o TextBox
			TextBox textBox = txtDocumentoTipo;

			var dic = listDocTipos.ToDictionary(x => (int)x.IDDocumentoTipo, x => x.DocumentoTipo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, propDespesa.IDDocumentoTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				propDespesa.IDDocumentoTipo = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...", "Formas de Cobrança",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDAPagarForma, x => x.APagarForma);
			var textBox = txtAPagarForma;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _pagar.IDAPagarForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_pagar.IDAPagarForma = (int)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				Caixa.frmBancoProcura frm = new Caixa.frmBancoProcura(this, _pagar.IDBanco == 0 ? null : _pagar.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					_pagar.IDBanco = (int)frm.propEscolha.IDBanco;
					txtBanco.Text = frm.propEscolha.BancoNome;
				}

				//--- select
				txtBanco.Focus();
				txtBanco.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de procura de Bancos..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetTitular_Click(object sender, EventArgs e)
		{
			frmTitularProcura frm = new frmTitularProcura(this, propDespesa.IDTitular);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH TITULAR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && propDespesa.IDTitular != frm.propEscolha.IDTitular)
					Sit = EnumFlagEstado.Alterado;

				propDespesa.IDTitular = (int)frm.propEscolha.IDTitular;
				propDespesa.Titular = frm.propEscolha.Titular;
				propDespesa.CNP = frm.propEscolha.CNP;
				txtTitular.Text = frm.propEscolha.Titular;
			}

			//--- select
			txtTitular.Focus();
			txtTitular.SelectAll();
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
					txtCredor,
					txtDespesaTipo,
					txtDocumentoTipo,
					txtSetor,
					txtDespesaDescricao,
					txtAPagarForma,
					txtBanco,
					txtTitular,
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
					case "txtCredor":
						btnSetCredor_Click(sender, new EventArgs());
						break;
					case "txtDespesaTipo":
						btnSetDespesaTipo_Click(sender, new EventArgs());
						break;
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtDocumentoTipo":
						btnSetDocumentoTipo_Click(sender, new EventArgs());
						break;
					case "txtAPagarForma":
						btnSetForma_Click(sender, new EventArgs());
						break;
					case "txtBanco":
						btnSetBanco_Click(sender, new EventArgs());
						break;
					case "txtDespesaDescricao":
						defineDescricao();
						break;
					case "txtTitular":
						btnSetTitular_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				switch (ctr.Name)
				{
					case "txtTitular":
						e.Handled = false;
						propDespesa.Titular = string.Empty;
						propDespesa.CNP = string.Empty;
						propDespesa.IDTitular = null;
						txtTitular.Clear();
						break;
					case "txtBanco":
						e.Handled = true;
						if (_pagar.IDBanco != null && Sit != EnumFlagEstado.NovoRegistro) Sit = EnumFlagEstado.Alterado;
						_pagar.IDBanco = null;
						txtBanco.Clear();
						break;
					case "txtDespesaDescricao":
					case "txtObservacao":
						e.Handled = false;
						break;
					default:
						e.Handled = true;
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = {
					txtDocumentoTipo, txtDespesaDescricao, txtAPagarForma
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
					txtSetor,
					txtConta,
					txtCredor,
					txtDespesaTipo,
					txtDocumentoTipo,
					txtAPagarForma,
					txtBanco,
					txtTitular,
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
					case "txtDocumentoTipo":

						if (listDocTipos.Count > 0)
						{
							var tipo = listDocTipos.FirstOrDefault(x => x.IDDocumentoTipo == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDDocumentoTipo != propDespesa.IDDocumentoTipo)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								propDespesa.IDDocumentoTipo = (byte)tipo.IDDocumentoTipo;
								txtDocumentoTipo.Text = tipo.DocumentoTipo;
							}
						}
						break;

					case "txtAPagarForma":

						if (listFormas.Count > 0)
						{
							var forma = listFormas.FirstOrDefault(x => x.IDAPagarForma == int.Parse(e.KeyChar.ToString()));

							if (forma == null) return;

							if (txtAPagarForma.Text == string.Empty || forma.IDAPagarForma != _pagar.IDAPagarForma)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_pagar.IDAPagarForma = (byte)forma.IDAPagarForma;
								txtAPagarForma.Text = forma.APagarForma;
							}
						}
						break;
					default:
						break;
				}
			}
		}

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void Text_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= Text_Enter;
		}

		// DEFINE CRIA UM TEXTO AUTOMATICA PARA DESCRICAO
		//------------------------------------------------------------------------------------------------------------
		private void defineDescricao()
		{
			// Oferta: TIPO de DESPESA + CREDOR

			if (string.IsNullOrEmpty(propDespesa.DespesaTipo))
			{
				AbrirDialog("Favor definir o Tipo de Despesa...", "Tipo de Despesa");
				txtDespesaTipo.Focus();
				return;
			}

			string descricao = propDespesa.DespesaTipo;

			if (!string.IsNullOrEmpty(propDespesa.Credor))
			{
				descricao += " - " + propDespesa.Credor;

				// define text
				txtDespesaDescricao.Text = descricao;
			}
			else
			{
				AbrirDialog("Favor definir o Credor / Fornecedor...", "Credor / Fornecedor Despesa");
				txtCredor.Focus();
				return;
			}
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

		// KEY DOWN ENTER OF NUMERIC UPDOWN
		private void numParcelas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			};
		}

		// VALIDA DESCONTO AND ACRESCIMO TO DEFINE VALOR A PAGAR
		//------------------------------------------------------------------------------------------------------------
		private void txtValor_Validating(object sender, CancelEventArgs e)
		{
			CalculaValorAPagar();
		}

		private void CalculaValorAPagar()
		{
			decimal desconto = decimal.Parse(string.IsNullOrEmpty(txtDesconto.Text) ? "0" : txtDesconto.Text, NumberStyles.Currency, new CultureInfo("pt-BR"));
			decimal acrescimo = decimal.Parse(string.IsNullOrEmpty(txtAcrescimo.Text) ? "0" : txtAcrescimo.Text, NumberStyles.Currency, new CultureInfo("pt-BR"));
			lblValorAPagar.Text = (propDespesa.DespesaValor - desconto + acrescimo).ToString("c");
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
				AbrirDialog("Não é possível alterar um registro de Despesa...", "Alterar Despesa");
				return;
			}

			if (!VerificaRegistro()) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- INSERT Despesa REALIZADA
				DefineAPagar();
				if (!DefineSaida()) return;
				long newID = despBLL.InsertDespesaRealizada(propDespesa, _pagar, _saida, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);
				propDespesa.IDDespesa = newID;
				bindDespesa.EndEdit();
				bindDespesa.ResetBindings(false);

				Sit = EnumFlagEstado.RegistroSalvo;

				var resp = AbrirDialog("Registro de Despesa Realizada salva e quitada com sucesso!" +
					"\nDeseja inserir uma imagem associada à Despesa?",
					"Salvamento Efetuado | Inserir Imagem",
					DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					InserirImagem();
				}

				//--- close form if formOrigem = frmProvisorio
				if (_formOrigem != null)
				{
					CloseAndMostraMenu(true);
				}

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
			if (!VerificaDadosClasse(txtSetor, "Setor Debitado", propDespesa, EP)) return false;
			if (!VerificaDadosClasse(txtCredor, "Credor/Fornecedor", propDespesa, EP)) return false;
			if (!VerificaDadosClasse(txtDespesaTipo, "Tipo de Despesa", propDespesa, EP)) return false;
			if (!VerificaDadosClasse(txtDocumentoTipo, "Tipo de Documento", propDespesa, EP)) return false;
			if (!VerificaDadosClasse(txtDocumentoNumero, "Número do Documento", propDespesa, EP)) return false;
			if (!VerificaDadosClasse(txtDespesaDescricao, "Descrição da Despesa", propDespesa, EP)) return false;
			if (!VerificaDadosClasse(txtAPagarForma, "Forma de Cobranca", _pagar, EP)) return false;

			// CHECK VALUE
			if (propDespesa.DespesaValor <= 0)
			{
				AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
					"Favor inserir o valor desta despesa corretamente.", "Valor da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtDespesaValor, "Valor necessário...");
				txtDespesaValor.Focus();
				return false;
			}

			//--- check DATA FUTURA
			if (propDespesa.DespesaData > DateTime.Today)
			{
				AbrirDialog("A Data da Despesa não pode ser maior que a Data de hoje\n" +
						"Favor reinserir a Data da Despesa anterior.", "Data da Despesa",
						DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(dtpDespesaData, "Valor incorreto...");
				dtpDespesaData.Focus();
				return false;
			}

			// CHECK MIN DATE FROM PROVISORIA
			if (_MinDateProvisoria != null && propDespesa.DespesaData < (DateTime)_MinDateProvisoria)
			{
				AbrirDialog("A Data da Despesa Realizada precisa ser posterior ou igual a Data da Despesa Provisória...\n" +
					"Favor inserir a data desta despesa corretamente.", "Data da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(dtpDespesaData, "Data Incorreta...");
				dtpDespesaData.Focus();
				return false;
			}

			return true;
		}

		// DEFINE APAGAR TO SAVE
		//------------------------------------------------------------------------------------------------------------
		private void DefineAPagar()
		{
			_pagar.APagarValor = propDespesa.DespesaValor;
			_pagar.IDCredor = propDespesa.IDCredor;
			_pagar.Identificador = propDespesa.DocumentoNumero;
			_pagar.IDSetor = propDespesa.IDSetor;
			_pagar.IDSituacao = 2;
			_pagar.PagamentoData = propDespesa.DespesaData;
			_pagar.Parcela = 1;
			_pagar.Prioridade = 3;
			_pagar.Situacao = "Quitado";
			_pagar.ValorPago = propDespesa.DespesaValor - _pagar.ValorDesconto;
			_pagar.Vencimento = propDespesa.DespesaData;
		}

		// DEFINE SAIDA TO SAVE
		//------------------------------------------------------------------------------------------------------------
		private bool DefineSaida()
		{
			DefineConta(ContaSelected);
			DefineSetor(SetorSelected);
			_saida.MovTipo = 2;
			_saida.AcrescimoValor = _pagar.ValorAcrescimo == 0 ? null : (decimal?)_pagar.ValorAcrescimo;
			_saida.IDCaixa = null;
			_saida.Origem = EnumMovOrigem.APagar;
			_saida.Observacao = txtObservacao.Text;
			_saida.MovData = propDespesa.DespesaData;
			_saida.MovValor = _pagar.ValorPago + _pagar.ValorAcrescimo;

			// check acrescimo
			if (_saida.AcrescimoValor != null && _saida.AcrescimoValor != 0)
			{
				var motivo = new objAcrescimoMotivo()
				{
					AcrescimoMotivo = _saida.AcrescimoMotivo,
					IDAcrescimoMotivo = _saida.IDAcrescimoMotivo,
					Ativo = true
				};

				APagar.frmAcrescimoMotivo frm = new APagar.frmAcrescimoMotivo(motivo, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return false;

				_saida.IDAcrescimoMotivo = frm._motivo.IDAcrescimoMotivo;
				_saida.AcrescimoMotivo = frm._motivo.AcrescimoMotivo;
			}

			return true;
		}

		#endregion // SALVAR REGISTRO --- END

		#region IMAGE CONTROL

		private void InserirImagem()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)propDespesa.IDDespesa,
					Origem = EnumImagemOrigem.Despesa,
					ImagemFileName = propDespesa.Imagem == null ? string.Empty : propDespesa.Imagem.ImagemFileName,
					ImagemPath = propDespesa.Imagem == null ? string.Empty : propDespesa.Imagem.ImagemPath,
					ReferenceDate = propDespesa.DespesaData,
				};

				// open form to edit or save image
				bool IsNew = propDespesa.Imagem == null || string.IsNullOrEmpty(propDespesa.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (propDespesa.Imagem != null && imagem != null)
				{
					IsUpdated = (propDespesa.Imagem.ImagemFileName != imagem.ImagemFileName) || (propDespesa.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				propDespesa.Imagem = imagem;

				// emit message
				if (IsNew && imagem != null)
				{
					AbrirDialog("Imagem associada e salva com sucesso!" +
								"\nPor segurança a imagem foi transferida para a pasta padrão.",
								"Imagem Salva", DialogType.OK, DialogIcon.Information);
				}
				else if (IsUpdated)
				{
					AbrirDialog("Imagem alterada com sucesso!" +
								"\nPor segurança a imagem anterior foi transferida para a pasta de imagens removidas.",
								"Imagem Alterada", DialogType.OK, DialogIcon.Information);
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // IMAGE CONTROL --- END
	}
}
