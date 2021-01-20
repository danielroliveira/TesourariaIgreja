using CamadaBLL;
using CamadaDTO;
using CamadaUI.Saidas.Reports;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
		private DespesaProvisoriaBLL provBLL = new DespesaProvisoriaBLL();
		private BindingSource bindProvisoria = new BindingSource();
		private BindingSource bindDespesa = new BindingSource();
		private EnumFlagEstado _Sit;

		private Form _formOrigem;
		private objSetor SetorSelected;
		private objConta ContaSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES  

		// CONSTRUCTOR WITH OBJECT DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmProvisorio(objDespesaProvisoria provisoria, Form formOrigem)
		{
			InitializeComponent();

			// get formOrigem
			_formOrigem = formOrigem;

			// create acesso dados
			AcessoControlBLL acesso = new AcessoControlBLL();
			object dbTran = acesso.GetNewAcessoWithTransaction();

			// set DESPESA
			_provisoria = provisoria;
			dtpRetiradaData.MinDate = DateTime.Today;

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
			BindingCreator();

			if (_provisoria.IDProvisorio == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				_provisoria.RetiradaData = DateTime.Today;
			}
			else if (_provisoria.Concluida)
			{
				Sit = EnumFlagEstado.RegistroBloqueado;
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
				Fechar();
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
					btnAnexarDespesa.Enabled = false;
					btnInserirDespesa.Enabled = false;
					btnFinalizar.Enabled = false;
					btnRecibo.Enabled = false;
					lblConcluida.Visible = false;
					btnExcluir.Enabled = false;
					// define MaxDate of Data da Despesa
					dtpRetiradaData.MaxDate = DateTime.Today;
					dtpRetiradaData.MinDate = DateTime.Today.AddMonths(-12);
				}
				else
				{
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					btnAnexarDespesa.Enabled = value != EnumFlagEstado.RegistroBloqueado;
					btnInserirDespesa.Enabled = value != EnumFlagEstado.RegistroBloqueado;
					btnFinalizar.Enabled = value != EnumFlagEstado.RegistroBloqueado;
					btnRecibo.Enabled = value != EnumFlagEstado.RegistroBloqueado;
					btnExcluir.Enabled = value != EnumFlagEstado.RegistroBloqueado;
					lblConcluida.Visible = value == EnumFlagEstado.RegistroBloqueado;
					// define MaxDate of Data da Despesa
					dtpRetiradaData.MaxDate = _provisoria.RetiradaData;
					dtpRetiradaData.MinDate = _provisoria.RetiradaData;
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

			if (conta.BloqueioData != null)
			{
				if (_provisoria.RetiradaData < conta.BloqueioData)
				{
					AbrirDialog("A data da Despesa Provisória não pode ser anterior à Data de Bloqueio da Conta escolhida..." +
						"\nA Data da Despesa Provisória será alterada.", "Data de Bloqueio");
					_provisoria.RetiradaData = (DateTime)conta.BloqueioData;
				}

				dtpRetiradaData.MinDate = (DateTime)conta.BloqueioData;
			}
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
				bindDespesa.DataSource = lstDespesas;
				dgvListagem.DataSource = bindDespesa;
				FormataListagem();
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
			dgvListagem.RowTemplate.Height = 30;
			dgvListagem.StandardTab = true;
			dgvListagem.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			// DEFINE COLUMN FONT
			Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

			// CREATE ARRAY OF COLUMNS
			var colList = new List<DataGridViewColumn>();

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDDespesa";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";
			clnID.DefaultCellStyle.Font = clnFont;
			colList.Add(clnID);

			//--- (2) COLUNA DATA
			clnDespesaData.DataPropertyName = "DespesaData";
			clnDespesaData.Visible = true;
			clnDespesaData.ReadOnly = true;
			clnDespesaData.Resizable = DataGridViewTriState.False;
			clnDespesaData.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnDespesaData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDespesaData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnDespesaData.DefaultCellStyle.Font = clnFont;
			colList.Add(clnDespesaData);

			//--- (5) COLUNA CREDOR
			clnCredor.DataPropertyName = "Credor";
			clnCredor.Visible = true;
			clnCredor.ReadOnly = true;
			clnCredor.Resizable = DataGridViewTriState.False;
			clnCredor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCredor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCredor.DefaultCellStyle.Font = clnFont;
			colList.Add(clnCredor);

			//--- (8) COLUNA VALOR
			clnValor.DataPropertyName = "DespesaValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Font = clnFont;
			clnValor.DefaultCellStyle.Format = "c";
			colList.Add(clnValor);

			//--- Add Columns
			dgvListagem.Columns.AddRange(colList.ToArray());
		}

		#endregion // DATAGRID FUNCTIONS --- END

		#region BUTTONS

		// FECHAR | CLOSE
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

			Fechar();
		}

		private void Fechar()
		{
			Close();

			if (_formOrigem.Name == "frmProvisoriaListagem")
			{
				var frm = new frmProvisoriaListagem();
				frm.Show();
			}
			else
			{
				MostraMenuPrincipal();
			}
		}

		// CANCELAR
		//------------------------------------------------------------------------------------------------------------
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de um novo registro?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					Fechar();
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

		private void btnRecibo_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new frmProvisorioReciboReport(_provisoria);
				frm.ShowDialog();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir Relatório..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS --- END

		#region ANEXAR DESPESA

		// ANEXAR DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void btnAnexarDespesa_Click(object sender, EventArgs e)
		{
			var frm = new frmDespesaListagem(this);
			frm.ShowDialog();

			if (frm.DialogResult != DialogResult.OK) return;

			objDespesa newDesp = frm.propEscolha;
			if (VerificaDespesaAnexada(newDesp) == false) return;

			//--- save
			SaveAttachDespesa(newDesp);
			_provisoria.EndEdit();
			Sit = EnumFlagEstado.RegistroSalvo;
		}

		// CHECK DESPESA REALIZADA BEFORE ANEXAR
		//------------------------------------------------------------------------------------------------------------
		private bool VerificaDespesaAnexada(objDespesa newDesp)
		{
			// check data
			if (newDesp.DespesaData < _provisoria.RetiradaData)
			{
				AbrirDialog("A despesa realizada não pode ter uma data anterior à data da despesa provisória...\n" +
					$"Favor escolher uma despesa com data igual ou depois de {_provisoria.RetiradaData.ToShortDateString()}.", "Anexar Despesa Realizada",
					DialogType.OK, DialogIcon.Information);
				return false;
			}

			// check situacao
			if (newDesp.IDSituacao == 1)
			{
				AbrirDialog("A despesa realizada não pode estar em aberto, precisa estar quitada..." +
					"\nFavor escolher uma despesa quitada.", "Anexar Despesa Realizada",
					DialogType.OK, DialogIcon.Information);
				return false;
			}

			// check Despesa Already Anexada
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (provBLL.DespesaAlreadyVinculada((long)newDesp.IDDespesa))
				{
					AbrirDialog("Essa despesa escolhida já está anexada/vinculada com uma Despesa Provisória..." +
						"\nFavor escolher outra despesa realizada.", "Anexar Despesa Realizada",
						DialogType.OK, DialogIcon.Information);
					return false;
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao verifica se a despesa já estava vinculada..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

			return true;
		}

		// INSERIR NOVA DESPESA GASTO
		//------------------------------------------------------------------------------------------------------------
		private void btnInserirDespesa_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmGasto frm = new frmGasto(new objDespesa(null), _provisoria.IDConta, _provisoria.RetiradaData);
				frm.ShowDialog();

				//--- check inserted Despesa
				if (frm.DialogResult != DialogResult.OK) return;

				//--- check Despesa Realizada
				objDespesa newDesp = frm.propDespesa;
				if (VerificaDespesaAnexada(newDesp) == false) return;

				//--- save
				SaveAttachDespesa(newDesp);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de Despesa Realizada..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// INSERT DESPESA IN LIST AND ATTACH ON PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		private void SaveAttachDespesa(objDespesa despesa)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (_provisoria.IDProvisorio == null || Sit == EnumFlagEstado.NovoRegistro)
				{
					throw new Exception("Essa despesa provisória ainda não foi salva...");
				}

				//--- check concluida
				if (despesa.DespesaValor >= _provisoria.ValorProvisorio - (_provisoria.ValorRealizado ?? 0))
				{
					var resp = AbrirDialog("O Valor total da Despesa a ser inserida é maior que o valor esperado da Despesa Provisória." +
									"\nDeseja FINALIZAR a despesa provisória após anexar essa Despesa?", "Finalizar Provisório",
									DialogType.SIM_NAO, DialogIcon.Question);

					if (resp == DialogResult.Yes)
					{
						_provisoria.Concluida = true;
						_provisoria.DevolucaoData = DateTime.Today;
					}
				}

				provBLL.AttachDespesaToProvisoria(_provisoria, despesa);
				bindDespesa.Add(despesa);

				_provisoria.EndEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Anexar Despesa ao Provisório..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// FINALIZAR CONCLUIR DESPESA PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		private void btnFinalizar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (_provisoria.IDProvisorio == null || Sit == EnumFlagEstado.NovoRegistro)
				{
					throw new Exception("Essa despesa provisória ainda não foi salva...");
				}

				var resp = AbrirDialog("A Despesa Provisória será FINALIZADA..." +
					"\nIsso significa que o recurso restante foi devolvido à CONTA." +
					"\nDeseja realmente FINALIZAR esta despesa provisória?", "Finalizar Provisório",
					DialogType.SIM_NAO, DialogIcon.Question);

				if (resp != DialogResult.Yes) return;

				// finalize
				_provisoria.Concluida = true;
				_provisoria.DevolucaoData = DateTime.Today;

				provBLL.FinalizeProvisoria(_provisoria);
				_provisoria.EndEdit();
				Sit = EnumFlagEstado.RegistroBloqueado;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Finalizar Despesa Provisória..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // ANEXAR DESPESA --- END

		#region BUTTONS PROCURA

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			if (!btnSetConta.Enabled) return;

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
			if (!btnSetSetor.Enabled) return;

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
			if (!btnSetAutorizante.Enabled) return;

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
			else if (frm.DialogResult == DialogResult.Yes) // SEARCH AUTORIZANTE
			{
				btnInsertAutorizante_Click(sender, e);
			}

			//--- select
			txtAutorizante.Focus();
			txtAutorizante.SelectAll();
		}

		private void btnSetComprador_Click(object sender, EventArgs e)
		{
			if (!btnSetComprador.Enabled) return;

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
			else if (frm.DialogResult == DialogResult.Yes) // SEARCH AUTORIZANTE
			{
				btnInsertComprador_Click(sender, e);
			}
			//--- select
			txtComprador.Focus();
			txtComprador.SelectAll();
		}

		// LIBERAR PARA INSERIR NOVO AUTORIZANTE
		//------------------------------------------------------------------------------------------------------------
		private void btnInsertAutorizante_Click(object sender, EventArgs e)
		{
			if (txtAutorizante.Text.Trim().Length > 0)
			{
				var resp = AbrirDialog("Deseja substituir o Autorizante escolhido atualmente?\n" +
					txtAutorizante.Text,
					"Inserir Autorizante", DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					txtAutorizante.Clear();
				}
				else
				{
					return;
				}
			}

			txtAutorizante.Tag = "Insira aqui o nome do novo Autorizante...";
			ShowToolTip(txtAutorizante);
			txtAutorizante.Enter -= text_Enter;

			txtAutorizante.KeyDown -= Control_KeyDown;
			txtAutorizante.Validating += (a, b) => PrimeiraLetraMaiuscula(txtAutorizante);
			txtAutorizante.BackColor = Color.LightYellow;
			txtAutorizante.LostFocus += (a, b) => txtAutorizante.BackColor = Color.White;
			txtAutorizante.Focus();
			btnInsertAutorizante.Enabled = false;
		}

		// LIBERAR PARA INSERIR COMPRADOR
		//------------------------------------------------------------------------------------------------------------
		private void btnInsertComprador_Click(object sender, EventArgs e)
		{
			if (txtComprador.Text.Trim().Length > 0)
			{
				var resp = AbrirDialog("Deseja substituir o Comprador escolhido atualmente?\n" +
					txtComprador.Text,
					"Inserir Comprador", DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					txtComprador.Clear();
				}
				else
				{
					return;
				}
			}

			txtComprador.Tag = "Insira aqui o nome do novo Comprador...";
			ShowToolTip(txtComprador);
			txtComprador.Enter -= text_Enter;

			txtComprador.KeyDown -= Control_KeyDown;
			txtComprador.Validating += (a, b) => PrimeiraLetraMaiuscula(txtComprador);
			txtComprador.BackColor = Color.LightYellow;
			txtComprador.LostFocus += (a, b) => txtComprador.BackColor = Color.White;
			txtComprador.Focus();
			btnInsertComprador.Enabled = false;
		}

		// DELETE PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		private void btnExcluir_Click(object sender, EventArgs e)
		{
			if (_provisoria.Concluida)
			{
				AbrirDialog("Não é possível Excluir uma Despesa Provisória que já está Concluída",
					"Excluir Despesa Provisória", DialogType.OK, DialogIcon.Information);
				return;
			}

			if (lstDespesas.Count > 0)
			{
				AbrirDialog("Não é possível Excluir uma Despesa Provisória que possui Despesas Realizadas anexadas.",
					"Excluir Despesa Provisória", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- ask to user
			var resp = AbrirDialog("Você tem certeza que deseja excluir essa Despesa provisória?" +
				"\nEssa exclusão não tem retorno.", "Excluir Despesa Provisória",
				DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- delete
				provBLL.DeleteProvisoria((long)_provisoria.IDProvisorio);

				//--- close
				btnFechar_Click(sender, e);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir a Despesa Provisória..." + "\n" +
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
			if (Sit != EnumFlagEstado.NovoRegistro)
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
				long newID = provBLL.InsertDespesaProvisoria(_provisoria);
				_provisoria.IDProvisorio = newID;
				bindProvisoria.EndEdit();
				bindProvisoria.ResetBindings(false);

				Sit = EnumFlagEstado.RegistroSalvo;

				_ = AbrirDialog("Registro de Despesa Provisória salva com sucesso!",
					"Salvamento Efetuado",
					DialogType.OK, DialogIcon.Information);

				// return with keydown handler Autorizante & Comprador
				txtAutorizante.Tag = "Pressione a tecla (+) para procurar...";
				txtAutorizante.KeyDown += Control_KeyDown;
				txtComprador.Tag = "Pressione a tecla (+) para procurar...";
				txtComprador.KeyDown += Control_KeyDown;
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

			//--- check DATA FUTURA
			if (_provisoria.RetiradaData > DateTime.Today)
			{
				AbrirDialog("A Data da Despesa não pode ser maior que a Data de hoje\n" +
						"Favor reinserir a Data da Despesa anterior.", "Data da Despesa",
						DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(dtpRetiradaData, "Valor incorreto...");
				dtpRetiradaData.Focus();
				return false;
			}

			return true;
		}


		#endregion // SALVAR REGISTRO --- END

		#region MENU SUSPENSO

		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			// check blocked
			if (_provisoria.Concluida) return;

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
			//objDespesa item = (objDespesa)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		private void mnuItemAnexar_Click(object sender, EventArgs e)
		{
			btnAnexarDespesa_Click(sender, e);
		}

		private void mnuItemDesvincular_Click(object sender, EventArgs e)
		{
			//--- verifica se existe alguma cell 
			if (dgvListagem.SelectedRows.Count == 0) return;

			//--- Get A Pagar on list
			objDespesa item = (objDespesa)dgvListagem.SelectedRows[0].DataBoundItem;

			//--- ask user
			var resp = AbrirDialog($"Deseja desvincular a despesa realizada: {item.IDDespesa:D4} valor: {item.DespesaValor:c} da despesa Provisória?",
				"Desvincular", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				provBLL.DettachDespesaToProvisoria(_provisoria, item);
				bindDespesa.Remove(item);
				_provisoria.EndEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Desvincular a Despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuItemInserir_Click(object sender, EventArgs e)
		{
			btnInserirDespesa_Click(sender, e);
		}

		#endregion // MENU SUSPENSO --- END

	}
}
