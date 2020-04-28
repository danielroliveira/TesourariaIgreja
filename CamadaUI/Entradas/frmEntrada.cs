using CamadaBLL;
using CamadaDTO;
using CamadaUI.Congregacoes;
using CamadaUI.Contas;
using CamadaUI.Registres;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmEntrada : CamadaUI.Modals.frmModFinBorder
	{
		private objEntrada _entrada;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objEntradaTipo> listTipos;
		private List<objEntradaForma> listFormas;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmEntrada(objEntrada obj)
		{
			InitializeComponent();

			_entrada = obj;
			GetTiposAndFormas();

			bind.DataSource = typeof(objEntrada);
			bind.Add(_entrada);

			BindingCreator();
			propEntradaTipo = _entrada.IDEntradaTipo;
			_entrada.PropertyChanged += RegistroAlterado;

			if (_entrada.IDEntrada == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			HandlerKeyDownControl(this);
		}

		private void GetTiposAndFormas()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				EntradaBLL entradaBLL = new EntradaBLL();
				listFormas = entradaBLL.GetEntradaFormasList();
				listTipos = entradaBLL.GetEntradaTiposList();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Tipos e Formas..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
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
						break;
					case EnumFlagEstado.Alterado:
						btnNovo.Enabled = false;
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						break;
					case EnumFlagEstado.NovoRegistro:
						btnNovo.Enabled = false;
						btnSalvar.Enabled = true;
						btnCancelar.Enabled = true;
						break;
					case EnumFlagEstado.RegistroBloqueado:
						btnNovo.Enabled = true;
						btnSalvar.Enabled = false;
						btnCancelar.Enabled = false;
						break;
					default:
						break;
				}
			}
		}

		private byte propEntradaTipo
		{
			get => _entrada.IDEntradaTipo;
			set
			{
				_entrada.IDEntradaTipo = value;

				if (listTipos.Count > 0)
				{
					objEntradaTipo tipo = listTipos.Find(x => x.IDEntradaTipo == value);

					if (tipo.ComAtividade)
					{
						txtReuniao.Enabled = true;
						btnSetReuniao.Enabled = true;
					}
					else
					{
						txtReuniao.Enabled = false;
						btnSetReuniao.Enabled = false;
						txtReuniao.Clear();
						_entrada.IDReuniao = null;
					}

					if (tipo.ComCampanha)
					{
						txtCampanha.Enabled = true;
						btnSetCampanha.Enabled = true;
					}
					else
					{
						txtCampanha.Enabled = false;
						btnSetCampanha.Enabled = false;
						txtCampanha.Clear();
						_entrada.IDCampanha = null;
					}

					if (tipo.ComOrigem)
					{
						txtContribuinte.Enabled = true;
						btnSetContribuinte.Enabled = true;
					}
					else
					{
						txtContribuinte.Enabled = false;
						btnSetContribuinte.Enabled = false;
						txtContribuinte.Clear();
						_entrada.IDContribuinte = null;
					}
				}

				// change labels color
				Action<Control, Label> ChangeLblColor = (ctrl, lbl) =>
				{
					lbl.ForeColor = ctrl.Enabled ? Color.Black : Color.Gainsboro;
				};

				ChangeLblColor(txtReuniao, lblReuniao);
				ChangeLblColor(txtCampanha, lblCampanha);
				ChangeLblColor(txtContribuinte, lblContribuinte);

			}
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDEntrada", true);

			Binding bndEntradaDia = txtEntradaDia.DataBindings.Add("Text", bind, "EntradaDia", true);
			Binding bndEntradaAno = txtEntradaAno.DataBindings.Add("Text", bind, "EntradaAno", true, DataSourceUpdateMode.OnPropertyChanged);

			txtEntradaForma.DataBindings.Add("Text", bind, "EntradaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorBruto.DataBindings.Add("Text", bind, "ValorBruto", true, DataSourceUpdateMode.OnPropertyChanged);
			txtEntradaTipo.DataBindings.Add("Text", bind, "EntradaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtConta.DataBindings.Add("Text", bind, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			txtContribuinte.DataBindings.Add("Text", bind, "Contribuinte", true, DataSourceUpdateMode.OnPropertyChanged);
			txtOrigemDescricao.DataBindings.Add("Text", bind, "OrigemDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtReuniao.DataBindings.Add("Text", bind, "Reuniao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCampanha.DataBindings.Add("Text", bind, "Campanha", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtValorBruto.DataBindings["Text"].Format += FormatCurrency;

			// CARREGA COMBO
			CarregaComboMes();
			Binding bndEntradaMes = cmbEntradaMes.DataBindings.Add("SelectedValue", bind, "EntradaMes", true, DataSourceUpdateMode.OnPropertyChanged);

			Action<object, BindingCompleteEventArgs, Control> bindComplete = (o, e, c) =>
			{
				if (e.BindingCompleteState != BindingCompleteState.Success)
				{
					AbrirDialog(e.Exception.Message, "Data Inválida", DialogType.OK, DialogIcon.Exclamation);
					txtEntradaDia.DataBindings["Text"].ReadValue();
					cmbEntradaMes.DataBindings["SelectedValue"].ReadValue();
					txtEntradaAno.DataBindings["Text"].ReadValue();

					if (c.GetType() == typeof(CamadaUC.ucOnlyNumbers)) ((TextBox)c).SelectAll();
				}
			};

			// HANDLERS
			bndEntradaDia.BindingComplete += (a, b) => bindComplete(a, b, txtEntradaDia);
			bndEntradaMes.BindingComplete += (a, b) => bindComplete(a, b, cmbEntradaMes);
			bndEntradaAno.BindingComplete += (a, b) => bindComplete(a, b, txtEntradaAno);
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

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaComboMes()
		{
			//--- Create DataTable
			DataTable dtMeses = new DataTable();
			dtMeses.Columns.Add("ID", typeof(int));
			dtMeses.Columns.Add("Mes");

			// get values of EnumAgendaRecorrencia
			string[] EnumValues = new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.MonthNames;
			int i = 1;

			// insert all item of EnumAgendaRecorrencia in datatable
			foreach (var mes in EnumValues)
			{
				if (string.IsNullOrEmpty(mes)) continue;
				dtMeses.Rows.Add(new object[] { i, mes });
				i++;
			}

			//--- Set DataTable
			cmbEntradaMes.DataSource = dtMeses;
			cmbEntradaMes.ValueMember = "ID";
			cmbEntradaMes.DisplayMember = "Mes";
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

			new frmEntradaListagem().Show();
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
					new frmEntradaListagem().Show();
					Close();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bind.CancelEdit();
				propEntradaTipo = _entrada.IDEntradaTipo;
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

			_entrada = new objEntrada(null);
			Sit = EnumFlagEstado.NovoRegistro;
			bind.DataSource = _entrada;
			txtOrigemDescricao.Focus();
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

				EntradaBLL sBLL = new EntradaBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_entrada.IDEntrada == null) //--- save | Insert
				{
					int ID = sBLL.InsertEntrada(_entrada);
					//--- define newID
					_entrada.IDEntrada = ID;
				}
				else //--- update
				{
					sBLL.UpdateEntrada(_entrada);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Entrada..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// CHECK INSERTED DATA
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtOrigemDescricao, "Descrição da Origem", _entrada)) return false;
			if (!VerificaDadosClasse(txtEntradaForma, "Forma da Entrada", _entrada)) return false;
			if (!VerificaDadosClasse(txtValorBruto, "Valor Bruto", _entrada)) return false;
			if (!VerificaDadosClasse(txtEntradaTipo, "Tipo de Entrada", _entrada)) return false;
			if (!VerificaDadosClasse(txtSetor, "Setor de Entrada", _entrada)) return false;
			if (!VerificaDadosClasse(txtConta, "Conta de Entrada", _entrada)) return false;

			// check CAMPANHA
			bool ComCampanha = listTipos.First(x => x.IDEntradaTipo == _entrada.IDEntradaTipo).ComCampanha;

			if (ComCampanha)
			{
				if (!VerificaDadosClasse(txtCampanha, "Campanha", _entrada)) return false;
			}
			else
			{
				_entrada.IDCampanha = null;
			}

			// CHECK ATIVIDADE REUNIAO
			bool ComAtividade = listTipos.First(x => x.IDEntradaTipo == _entrada.IDEntradaTipo).ComAtividade;

			if (ComAtividade)
			{
				if (!VerificaDadosClasse(txtReuniao, "Reunião", _entrada)) return false;
			}
			else
			{
				_entrada.IDReuniao = null;
			}

			// CHECK ORIGEM
			bool ComOrigem = listTipos.First(x => x.IDEntradaTipo == _entrada.IDEntradaTipo).ComOrigem;

			if (ComOrigem)
			{
				if (!VerificaDadosClasse(txtContribuinte, "Contribuinte", _entrada)) return false;
			}
			else
			{
				_entrada.IDContribuinte = null;
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
					txtEntradaForma, txtCampanha, txtConta, txtContribuinte, txtEntradaTipo, txtReuniao, txtSetor
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmEntrada_KeyDown(object sender, KeyEventArgs e)
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
					case "txtEntradaForma":
						btnSetEntradaForma_Click(sender, new EventArgs());
						break;
					case "txtEntradaTipo":
						btnSetEntradaTipo_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtContribuinte":
						btnSetContribuinte_Click(sender, new EventArgs());
						break;
					case "txtReuniao":
						btnSetReuniao_Click(sender, new EventArgs());
						break;
					case "txtCampanha":
						btnSetCampanha_Click(sender, new EventArgs());
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
					case "txtContribuinte":
						if (_entrada.IDContribuinte != null) Sit = EnumFlagEstado.Alterado;
						txtContribuinte.Clear();
						_entrada.IDContribuinte = null;
						break;
					case "txtReuniao":
						if (_entrada.IDReuniao != null) Sit = EnumFlagEstado.Alterado;
						txtReuniao.Clear();
						_entrada.IDReuniao = null;
						break;
					case "txtCampanha":
						if (_entrada.IDCampanha != null) Sit = EnumFlagEstado.Alterado;
						txtCampanha.Clear();
						_entrada.IDCampanha = null;
						break;
					default:
						break;
				}
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtEntradaForma,
					txtCampanha,
					txtConta,
					txtContribuinte,
					txtEntradaTipo,
					txtReuniao,
					txtSetor };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContaProcura frm = new frmContaProcura(this, _entrada.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (_entrada.IDConta != frm.propEscolha.IDConta) Sit = EnumFlagEstado.Alterado;
					_entrada.IDConta = (int)frm.propEscolha.IDConta;
					txtConta.Text = frm.propEscolha.Conta;
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

		private void btnSetEntradaForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Entradas cadastradas...", "Formas de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDEntradaForma, x => x.EntradaForma);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtEntradaForma, _entrada.IDEntradaForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_entrada.IDEntradaForma = (byte)frm.propEscolha.Key;
				txtEntradaForma.Text = frm.propEscolha.Value;
			}

			//--- select
			txtEntradaForma.Focus();
			txtEntradaForma.SelectAll();
		}

		private void btnSetEntradaTipo_Click(object sender, EventArgs e)
		{
			if (listFormas == null || listFormas.Count == 0)
			{
				AbrirDialog("Não há Tipos de Entrada cadastrados...", "Tipos de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listTipos.ToDictionary(x => (int)x.IDEntradaTipo, x => x.EntradaTipo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtEntradaTipo, _entrada.IDEntradaTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_entrada.IDEntradaTipo = (byte)frm.propEscolha.Key;
				txtEntradaTipo.Text = frm.propEscolha.Value;
				propEntradaTipo = _entrada.IDEntradaTipo;
			}

			//--- select
			txtEntradaTipo.Focus();
			txtEntradaTipo.SelectAll();
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _entrada.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (_entrada.IDSetor != frm.propEscolha.IDSetor) Sit = EnumFlagEstado.Alterado;
					_entrada.IDSetor = (int)frm.propEscolha.IDSetor;
					txtSetor.Text = frm.propEscolha.Setor;
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

		private void btnSetContribuinte_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContribuinteListagem frm = new frmContribuinteListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (_entrada.IDContribuinte != frm.propEscolha.IDContribuinte) Sit = EnumFlagEstado.Alterado;
					_entrada.IDContribuinte = (int)frm.propEscolha.IDContribuinte;
					txtContribuinte.Text = frm.propEscolha.Contribuinte;
				}

				//--- select
				txtContribuinte.Focus();
				txtContribuinte.SelectAll();
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

		private void btnSetReuniao_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmCongregacaoReuniaoProcura frm = new frmCongregacaoReuniaoProcura(this, _entrada.IDReuniao);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (_entrada.IDReuniao != frm.propEscolha.IDReuniao) Sit = EnumFlagEstado.Alterado;
					_entrada.IDReuniao = (int)frm.propEscolha.IDReuniao;
					txtReuniao.Text = frm.propEscolha.Reuniao;
				}

				//--- select
				txtReuniao.Focus();
				txtReuniao.SelectAll();
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

		private void btnSetCampanha_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmCampanhaProcura frm = new frmCampanhaProcura(this, _entrada.IDCampanha);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (_entrada.IDCampanha != frm.propEscolha.IDCampanha) Sit = EnumFlagEstado.Alterado;
					_entrada.IDCampanha = (int)frm.propEscolha.IDCampanha;
					txtCampanha.Text = frm.propEscolha.Campanha;
				}

				//--- select
				txtCampanha.Focus();
				txtCampanha.SelectAll();
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

		#endregion // BUTTONS PROCURA --- END


	}
}
