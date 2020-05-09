﻿using CamadaBLL;
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
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmContribuicao : CamadaUI.Modals.frmModFinBorder
	{
		private objContribuicao _contribuicao;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objContribuicaoTipo> listTipos;
		private List<objEntradaForma> listFormas;

		private objConta contaSelected;
		private objSetor setorSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuicao(objContribuicao obj)
		{
			InitializeComponent();

			_contribuicao = obj;
			GetTiposAndFormas();

			// Define Conta and Setor padrao
			frmPrincipal principal = Application.OpenForms.OfType<frmPrincipal>().First();
			contaSelected = principal.propContaPadrao;
			setorSelected = principal.propSetorPadrao;

			// binding
			bind.DataSource = typeof(objContribuicao);
			bind.Add(_contribuicao);
			BindingCreator();

			propContribuicaoTipo = _contribuicao.IDContribuicaoTipo;

			if (_contribuicao.IDContribuicao == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				_contribuicao.IDConta = (int)contaSelected.IDConta;
				_contribuicao.Conta = contaSelected.Conta;
				_contribuicao.IDSetor = (int)setorSelected.IDSetor;
				_contribuicao.Setor = setorSelected.Setor;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// handlers
			_contribuicao.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);

			txtContribuicaoTipo.Enter += text_Enter;
			txtReuniao.Enter += text_Enter;
			txtContribuinte.Enter += text_Enter;
			txtCampanha.Enter += text_Enter;
			txtOrigemDescricao.Enter += text_Enter;

		}

		// GET LIST OF ENTRADA FORMAS AND TIPOS
		//------------------------------------------------------------------------------------------------------------
		private void GetTiposAndFormas()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				EntradaBLL entradaBLL = new EntradaBLL();
				ContribuicaoBLL contribuicaoBLL = new ContribuicaoBLL();
				listFormas = entradaBLL.GetEntradaFormasList();
				listTipos = contribuicaoBLL.GetContribuicaoTiposList();

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

		// PROPERTY CONTRIBUICAO TIPO
		//------------------------------------------------------------------------------------------------------------
		private byte propContribuicaoTipo
		{
			get => _contribuicao.IDContribuicaoTipo;
			set
			{
				_contribuicao.IDContribuicaoTipo = value;

				if (listTipos.Count > 0)
				{
					objContribuicaoTipo tipo = listTipos.Find(x => x.IDContribuicaoTipo == value);

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
						_contribuicao.IDReuniao = null;
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
						_contribuicao.IDCampanha = null;
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
						_contribuicao.IDContribuinte = null;
					}
				}

				// change labels color
				Action<Control, Label> ChangeLblColor = (ctrl, lbl) =>
				{
					lbl.ForeColor = ctrl.Enabled ? Color.Black : Color.Silver;
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
			lblID.DataBindings.Add("Text", bind, "IDContribuicao", true);
			txtEntradaForma.DataBindings.Add("Text", bind, "EntradaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtValorBruto.DataBindings.Add("Text", bind, "ValorBruto", true, DataSourceUpdateMode.OnPropertyChanged);
			txtContribuicaoTipo.DataBindings.Add("Text", bind, "ContribuicaoTipo", true, DataSourceUpdateMode.OnPropertyChanged);
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

			// ADD NAMED BINDINGS TO CONTROL ERROS
			//------------------------------------------------------------------------------------------------------------
			Binding bndEntradaMes = cmbEntradaMes.DataBindings.Add("SelectedValue", bind, "EntradaMes", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaDia = txtEntradaDia.DataBindings.Add("Text", bind, "EntradaDia", true, DataSourceUpdateMode.OnPropertyChanged);
			Binding bndEntradaAno = txtEntradaAno.DataBindings.Add("Text", bind, "EntradaAno", true, DataSourceUpdateMode.OnPropertyChanged);

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

			// HANDLERS TO CONTROL ERROS
			bndEntradaDia.BindingComplete += (a, b) => bindComplete(a, b, txtEntradaDia);
			bndEntradaMes.BindingComplete += (a, b) => bindComplete(a, b, cmbEntradaMes);
			bndEntradaAno.BindingComplete += (a, b) => bindComplete(a, b, txtEntradaAno);
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

			new frmContribuicaoListagem().Show();
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
					new frmContribuicaoListagem().Show();
					Close();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bind.CancelEdit();
				propContribuicaoTipo = _contribuicao.IDContribuicaoTipo;
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

			_contribuicao = new objContribuicao(null);
			Sit = EnumFlagEstado.NovoRegistro;
			bind.DataSource = _contribuicao;
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

				//--- check Cartao
				if (_contribuicao.IDEntradaForma == 3) // cartao
				{
					var cartao = new objContribuicaoCartao(null);
					var frm = new frmContribuicaoCartao(ref cartao, this);
					frm.ShowDialog();
				}
				else if (_contribuicao.IDEntradaForma == 2) // cheque 
				{
					var cheque = new objContribuicaoCheque(null);
					var frm = new frmContribuicaoCheque(ref cheque, this);
					frm.ShowDialog();
				}


				ContribuicaoBLL sBLL = new ContribuicaoBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_contribuicao.IDContribuicao == null) //--- save | Insert
				{
					int ID = sBLL.InsertContribuicao(_contribuicao);
					//--- define newID
					_contribuicao.IDContribuicao = ID;
				}
				else //--- update
				{
					sBLL.UpdateContribuicao(_contribuicao);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Contribuicao..." + "\n" +
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
			if (!VerificaDadosClasse(txtEntradaForma, "Forma da Entrada", _contribuicao, EP)) return false;
			if (!VerificaDadosClasse(txtContribuicaoTipo, "Tipo de Entrada", _contribuicao, EP)) return false;
			if (!VerificaDadosClasse(txtSetor, "Setor de Entrada", _contribuicao, EP)) return false;
			if (!VerificaDadosClasse(txtConta, "Conta de Entrada", _contribuicao, EP)) return false;

			// check VALOR BRUTO
			if (!VerificaDadosClasse(txtValorBruto, "Valor Bruto", _contribuicao, EP)) return false;

			if (_contribuicao.ValorBruto <= 0)
			{
				// message
				AbrirDialog("O valor da contribuição não pode ser igual a zero...\n" +
					"Favor preecher esse campo com um valor maior que zero.", "Valor da Contribuição",
					DialogType.OK, DialogIcon.Exclamation);
				// error provider
				EP.SetError(txtValorBruto, "Preencha o valor desse campo!");
				// select
				txtValorBruto.Focus();
				// return
				return false;
			}

			// check CAMPANHA
			bool ComCampanha = listTipos.First(x => x.IDContribuicaoTipo == _contribuicao.IDContribuicaoTipo).ComCampanha;

			if (ComCampanha)
			{
				if (!VerificaDadosClasse(txtCampanha, "Campanha", _contribuicao, EP)) return false;
			}
			else
			{
				_contribuicao.IDCampanha = null;
			}

			// CHECK ATIVIDADE REUNIAO
			bool ComAtividade = listTipos.First(x => x.IDContribuicaoTipo == _contribuicao.IDContribuicaoTipo).ComAtividade;

			if (ComAtividade)
			{
				if (!VerificaDadosClasse(txtReuniao, "Reunião", _contribuicao, EP)) return false;
			}
			else
			{
				_contribuicao.IDReuniao = null;
			}

			// CHECK ORIGEM
			bool ComOrigem = listTipos.First(x => x.IDContribuicaoTipo == _contribuicao.IDContribuicaoTipo).ComOrigem;

			if (ComOrigem)
			{
				if (!VerificaDadosClasse(txtContribuinte, "Contribuinte", _contribuicao, EP)) return false;
			}
			else
			{
				_contribuicao.IDContribuinte = null;
			}

			// CHECK DESCRICAO
			if (!VerificaDadosClasse(txtOrigemDescricao, "Descrição da Origem", _contribuicao, EP)) return false;

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
					txtEntradaForma,
					txtCampanha,
					txtConta,
					txtContribuinte,
					txtContribuicaoTipo,
					txtReuniao,
					txtSetor,
					txtOrigemDescricao
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
					case "txtContribuicaoTipo":
						btnSetContribuicaoTipo_Click(sender, new EventArgs());
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
					case "txtOrigemDescricao":
						defineDescricao();
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
						if (_contribuicao.IDContribuinte != null) Sit = EnumFlagEstado.Alterado;
						txtContribuinte.Clear();
						_contribuicao.IDContribuinte = null;
						break;
					case "txtReuniao":
						if (_contribuicao.IDReuniao != null) Sit = EnumFlagEstado.Alterado;
						txtReuniao.Clear();
						_contribuicao.IDReuniao = null;
						break;
					case "txtCampanha":
						if (_contribuicao.IDCampanha != null) Sit = EnumFlagEstado.Alterado;
						txtCampanha.Clear();
						_contribuicao.IDCampanha = null;
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
				Control[] controlesBloqueados = {
					txtEntradaForma,
					txtCampanha,
					txtConta,
					txtContribuinte,
					txtContribuicaoTipo,
					txtReuniao,
					txtSetor };

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

		// DEFINE CRIA UM TEXTO AUTOMATICA PARA DESCRICAO
		//------------------------------------------------------------------------------------------------------------
		private void defineDescricao()
		{
			if (!string.IsNullOrEmpty(_contribuicao.OrigemDescricao)) return;

			// Oferta:   TIPO + REUNIAO + DATA
			// dizimo:   TIPO + CONTRIBUINTE
			// CAMPANHA: TIPO + CAMPANHA

			string descricao = _contribuicao.ContribuicaoTipo + " - ";

			if (!string.IsNullOrEmpty(_contribuicao.Contribuinte))
			{
				descricao += _contribuicao.Contribuinte;

				if (!string.IsNullOrEmpty(_contribuicao.Campanha))
					descricao += " - " + _contribuicao.Campanha;
			}
			else if (!string.IsNullOrEmpty(_contribuicao.Campanha))
				descricao += _contribuicao.Campanha;
			else
				descricao += _contribuicao.Reuniao + " - " + _contribuicao.ContribuicaoData.ToShortDateString();

			txtOrigemDescricao.Text = descricao;
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

				frmContaProcura frm = new frmContaProcura(this, _contribuicao.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDConta != frm.propEscolha.IDConta)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDConta = (int)frm.propEscolha.IDConta;
					txtConta.Text = frm.propEscolha.Conta;
					contaSelected = frm.propEscolha;
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

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtEntradaForma, _contribuicao.IDEntradaForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_contribuicao.IDEntradaForma = (byte)frm.propEscolha.Key;
				txtEntradaForma.Text = frm.propEscolha.Value;
			}

			//--- select
			txtEntradaForma.Focus();
			txtEntradaForma.SelectAll();
		}

		private void btnSetContribuicaoTipo_Click(object sender, EventArgs e)
		{
			if (listFormas == null || listFormas.Count == 0)
			{
				AbrirDialog("Não há Tipos de Entrada cadastrados...", "Tipos de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listTipos.ToDictionary(x => (int)x.IDContribuicaoTipo, x => x.ContribuicaoTipo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtContribuicaoTipo, _contribuicao.IDContribuicaoTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_contribuicao.IDContribuicaoTipo = (byte)frm.propEscolha.Key;
				txtContribuicaoTipo.Text = frm.propEscolha.Value;
				propContribuicaoTipo = _contribuicao.IDContribuicaoTipo;
				txtOrigemDescricao.Clear();
			}

			//--- select
			txtContribuicaoTipo.Focus();
			txtContribuicaoTipo.SelectAll();
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _contribuicao.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDSetor != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDSetor = (int)frm.propEscolha.IDSetor;
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
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDContribuinte != frm.propEscolha.IDContribuinte)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDContribuinte = (int)frm.propEscolha.IDContribuinte;
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

				//--- create filter congregacao
				var filter = new KeyValuePair<int, string>((int)contaSelected.IDCongregacao, contaSelected.Congregacao);

				frmCongregacaoReuniaoProcura frm = new frmCongregacaoReuniaoProcura(this, _contribuicao.IDReuniao, filter);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDReuniao != frm.propEscolha.IDReuniao)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDReuniao = (int)frm.propEscolha.IDReuniao;
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

				frmCampanhaProcura frm = new frmCampanhaProcura(this, _contribuicao.IDCampanha);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _contribuicao.IDCampanha != frm.propEscolha.IDCampanha)
						Sit = EnumFlagEstado.Alterado;

					_contribuicao.IDCampanha = (int)frm.propEscolha.IDCampanha;
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

			if (controle.Tag.ToString() == "")
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
