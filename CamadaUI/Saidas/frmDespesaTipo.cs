using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;

namespace CamadaUI.Saidas
{
	public partial class frmDespesaTipo : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesaTipo _tipo;
		private DespesaBLL dBLL = new DespesaBLL();
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objDespesaTipoGrupo> listGrupos;
		private Dictionary<int, string> dicPeriodicidade = new Dictionary<int, string>();

		private Form _formOrigem;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaTipo(objDespesaTipo obj, Form formOrigem)
		{
			InitializeComponent();

			_tipo = obj;
			_formOrigem = formOrigem;
			GetGruposList();
			PreencheDictionary();

			// binding
			bind.DataSource = typeof(objDespesaTipo);
			bind.Add(_tipo);
			BindingCreator();
			AtivoButtonImage();

			if (_tipo.IDDespesaTipo == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// handlers
			_tipo.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
			txtDespesaTipo.Validating += (a, b) => PrimeiraLetraMaiuscula(txtDespesaTipo);
		}

		// ON SHOW FORM
		//------------------------------------------------------------------------------------------------------------
		private void frmDespesa_Shown(object sender, EventArgs e)
		{
			txtDespesaTipo.Enter += text_Enter;
			txtDespesaTipoGrupo.Enter += text_Enter;
		}

		// GET LIST OF GRUPOS
		//------------------------------------------------------------------------------------------------------------
		private void GetGruposList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listGrupos = dBLL.GetDespesaTipoGruposList();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de CLASSIFICAÇÃO..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void PreencheDictionary()
		{
			// 1:Variavel | 2:Semanal | 3:Mensal | 4:Semestral | 5:Anual
			dicPeriodicidade.Add(1, "Variável");
			dicPeriodicidade.Add(2, "Semanal");
			dicPeriodicidade.Add(3, "Mensal");
			dicPeriodicidade.Add(4, "Semestral");
			dicPeriodicidade.Add(5, "Anual");
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

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDDespesaTipo", true);
			txtDespesaTipo.DataBindings.Add("Text", bind, "DespesaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtPeriodicidade.DataBindings.Add("Text", bind, "PeriodicidadeDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaTipoGrupo.DataBindings.Add("Text", bind, "DespesaTipoGrupo", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
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

			EP.Clear();
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

			new frmDespesaTipoListagem().Show();
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
					new frmDespesaTipoListagem().Show();
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

			_tipo = new objDespesaTipo(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _tipo;
			txtDespesaTipo.Focus();
		}

		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR um NOVO Tipo de Despesa", "Desativar Tipo",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_tipo.Ativo == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR o Tipo de Despesa:\n" +
							   txtDespesaTipo.Text.ToUpper(),
							   "Desativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR o Tipo de Despesa:\n" +
							   txtDespesaTipo.Text.ToUpper(),
							   "Ativor Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_tipo.BeginEdit();
			_tipo.Ativo = !_tipo.Ativo;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_tipo.Ativo == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativo";
				}
				else if (_tipo.Ativo == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativo";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar o Tipo de Despesa..." + "\n" +
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
				if (_tipo.IDDespesaTipo == null) //--- save | Insert
				{
					int ID = dBLL.InsertDespesaTipo(_tipo);
					//--- define newID
					_tipo.IDDespesaTipo = ID;
				}
				else //--- update
				{
					dBLL.UpdateDespesaTipo(_tipo);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Tipo de Despesa..." + "\n" +
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
			if (!VerificaDadosClasse(txtDespesaTipo, "Descrição do Tipo de Despesa", _tipo)) return false;
			if (!VerificaDadosClasse(txtDespesaTipoGrupo, "Grupo da Despesa", _tipo)) return false;
			if (!VerificaDadosClasse(txtPeriodicidade, "Periodicidade", _tipo)) return false;
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
					txtDespesaTipoGrupo, txtDespesaTipo, txtPeriodicidade
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
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtPeriodicidade":
						btnSetPeriodicidade_Click(sender, new EventArgs());
						break;
					case "txtDespesaTipoGrupo":
						btnSetDespesaTipoGrupo_Click(sender, new EventArgs());
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
					case "txtPeriodicidade":
						break;
					case "txtDespesaTipoGrupo":
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtPeriodicidade,
					txtDespesaTipoGrupo
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
			else if (e.Alt)
			{
				e.Handled = false;
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtPeriodicidade,
					txtDespesaTipoGrupo, };

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
					case "txtPeriodicidade":

						if (dicPeriodicidade.Count > 0)
						{
							if (dicPeriodicidade.ContainsKey(byte.Parse(e.KeyChar.ToString())))
							{
								var tipo = dicPeriodicidade.FirstOrDefault(x => x.Key == byte.Parse(e.KeyChar.ToString()));

								if (tipo.Key != _tipo.Periodicidade)
								{
									if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

									_tipo.Periodicidade = (byte)tipo.Key;
									txtPeriodicidade.Text = tipo.Value;
								}
							}
						}
						break;

					case "txtDespesaTipoGrupo":

						if (listGrupos.Count > 0)
						{
							var tipo = listGrupos.FirstOrDefault(x => x.IDDespesaTipoGrupo == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDDespesaTipoGrupo != _tipo.IDDespesaTipoGrupo)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_tipo.IDDespesaTipoGrupo = (byte)tipo.IDDespesaTipoGrupo;
								txtDespesaTipoGrupo.Text = tipo.DespesaTipoGrupo;
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
		private void text_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= text_Enter;
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		// OPEN LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetPeriodicidade_Click(object sender, EventArgs e)
		{
			// seleciona o TextBox
			TextBox textBox = txtPeriodicidade;

			Main.frmComboLista frm = new Main.frmComboLista(dicPeriodicidade, textBox, _tipo.Periodicidade);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_tipo.Periodicidade = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetDespesaTipoGrupo_Click(object sender, EventArgs e)
		{
			if (listGrupos.Count == 0)
			{
				AbrirDialog("Não há Grupos de Despesa cadastradas...", "Grupos de Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// seleciona o TextBox
			TextBox textBox = txtDespesaTipoGrupo;

			var dic = listGrupos.ToDictionary(x => (int)x.IDDespesaTipoGrupo, x => x.DespesaTipoGrupo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _tipo.IDDespesaTipoGrupo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_tipo.IDDespesaTipoGrupo = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		//--- INSERT NEW CLASSIFICAÇÃO
		//------------------------------------------------------------------------------------------------------------
		private void btnInsertClassificacao_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmDespesaTipoGrupoControle frm = new frmDespesaTipoGrupoControle(this);
				frm.ShowDialog();
				GetGruposList();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir o formulário de cadastro de Classificação..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS PROCURA --- END

		#region DESIGN FORM FUNCTIONS

		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END

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

	}
}
