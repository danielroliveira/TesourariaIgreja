using CamadaBLL;
using CamadaDTO;
using CamadaUI.Registres;
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
	public partial class frmDespesa : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesa _despesa;
		private DespesaBLL despBLL = new DespesaBLL();
		private BindingSource bind = new BindingSource();
		private BindingSource bindParcelas = new BindingSource();
		private EnumFlagEstado _Sit;
		private List<objAPagar> listAPagar = new List<objAPagar>();

		private List<objDespesaDocumentoTipo> listDocTipos;
		private objSetor setorSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		// CONSTRUCTOR WITH DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmDespesa(objDespesa despesa)
		{
			InitializeComponent();
			ConstructorContinue(despesa);
		}

		// CONSTRUCTOR WITH ID
		//------------------------------------------------------------------------------------------------------------
		public frmDespesa(long IDDespesa)
		{
			InitializeComponent();
			var desp = GetDespesaByID(IDDespesa);

			if (desp == null) return;

			ConstructorContinue(desp);
		}

		// CONSTRUCTOR CONTINUE AFTER GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objDespesa despesa)
		{
			_despesa = despesa;

			GetDocTipos();

			// Define Conta and Setor padrao
			frmPrincipal principal = Application.OpenForms.OfType<frmPrincipal>().First();
			setorSelected = principal.propSetorPadrao;

			// binding
			bind.DataSource = typeof(objDespesa);
			bind.Add(_despesa);
			BindingCreator();

			ChangeParcelado(_despesa.Parcelas > 1);

			if (_despesa.IDDespesa == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				_despesa.IDSetor = (int)setorSelected.IDSetor;
				_despesa.Setor = setorSelected.Setor;
				_despesa.DespesaData = DataPadrao();
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
				chkParcelado.Checked = _despesa.Parcelas > 1;
				GetAPagar();
			}

			// format Datagridview
			FormataListagem();
			bindParcelas.DataSource = listAPagar;
			dgvListagem.DataSource = bindParcelas;

			// handlers
			_despesa.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
			btnParcelasGerar.Click += (a, b) => ParcelasGerar();
		}

		// SHOW
		//------------------------------------------------------------------------------------------------------------
		private void frmDespesa_Shown(object sender, EventArgs e)
		{
			if (_despesa == null)
			{
				Close();
				return;
			}

			txtSetor.Enter += text_Enter;
			txtCredor.Enter += text_Enter;
			txtDespesaTipo.Enter += text_Enter;
			txtDocumentoTipo.Enter += text_Enter;

			// block keyDown then Sit = Alterado
			txtDocumentoNumero.KeyDown += control_KeyDown_Block;
			txtDespesaValor.KeyDown += control_KeyDown_Block;
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
					lblSitBlock.Visible = false;
				}
				else
				{
					btnNovo.Enabled = true;
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					// define MaxDate of Data da Despesa
					dtpDespesaData.MaxDate = _despesa.DespesaData;
					dtpDespesaData.MinDate = _despesa.DespesaData;
					lblSitBlock.Visible = true;
				}

				// btnSET ENABLE | DISABLE
				btnSetDespesaTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetDocumentoTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetCredor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetTitular.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnInsertTitular.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// GET DESPESA BY ID
		//------------------------------------------------------------------------------------------------------------
		private objDespesa GetDespesaByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return despBLL.GetDespesa(ID);
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

		// GET PARCELAMENTO | APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void GetAPagar()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listAPagar = new APagarBLL().GetListAPagarByDespesa((long)_despesa.IDDespesa);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Parcelamento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF DOCUMENTO TIPOS
		//------------------------------------------------------------------------------------------------------------
		private void GetDocTipos()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listDocTipos = despBLL.GetDespesaDocumentoTipos();
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

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDDespesa", true);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCredor.DataBindings.Add("Text", bind, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaTipo.DataBindings.Add("Text", bind, "DespesaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDocumentoTipo.DataBindings.Add("Text", bind, "DocumentoTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDocumentoNumero.DataBindings.Add("Text", bind, "DocumentoNumero", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpDespesaData.DataBindings.Add("Value", bind, "DespesaData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaValor.DataBindings.Add("Text", bind, "DespesaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			numParcelas.DataBindings.Add("Value", bind, "Parcelas", true, DataSourceUpdateMode.OnPropertyChanged);
			txtTitular.DataBindings.Add("Text", bind, "Titular", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtDespesaValor.DataBindings["Text"].Format += FormatCurrency;
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

		private void FormatNomeCNP(object sender, ConvertEventArgs e)
		{
			e.Value = string.IsNullOrEmpty(_despesa.CNP) ? e.Value : $"{e.Value} ({_despesa.CNP})";
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

		private void btnNovo_Click(object sender, EventArgs e)
		{
			// if frmAPagarListagem is ENABLED then exit
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}

			if (Sit == EnumFlagEstado.NovoRegistro || Sit == EnumFlagEstado.RegistroBloqueado) return;

			_despesa = new objDespesa(null);
			Sit = EnumFlagEstado.NovoRegistro;
			bind.DataSource = _despesa;
			listAPagar = new List<objAPagar>();
			bindParcelas.DataSource = listAPagar;
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
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		#endregion // BUTTONS --- END

		#region BUTTONS PROCURA

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _despesa.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDSetor != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					_despesa.IDSetor = (int)frm.propEscolha.IDSetor;
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

		private void btnSetCredor_Click(object sender, EventArgs e)
		{
			frmCredorListagem frm = new frmCredorListagem(true, this);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDCredor != frm.propEscolha.IDCredor)
					Sit = EnumFlagEstado.Alterado;

				_despesa.IDCredor = (int)frm.propEscolha.IDCredor;
				txtCredor.Text = frm.propEscolha.Credor;
			}
			else if (frm.DialogResult == DialogResult.Yes) // ADD NEW CONTRIBUINTE
			{
				frmCredor frmNovo = new frmCredor(new objCredor(null), this);
				frmNovo.ShowDialog();

				if (frmNovo.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDCredor != frmNovo.propEscolha.IDCredor)
						Sit = EnumFlagEstado.Alterado;

					_despesa.IDCredor = (int)frmNovo.propEscolha.IDCredor;
					txtCredor.Text = frmNovo.propEscolha.Credor;
				}
			}

			//--- select
			txtCredor.Focus();
			txtCredor.SelectAll();
		}

		private void btnSetTitular_Click(object sender, EventArgs e)
		{
			frmTitularProcura frm = new frmTitularProcura(this, _despesa.IDTitular);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH TITULAR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDTitular != frm.propEscolha.IDTitular)
					Sit = EnumFlagEstado.Alterado;

				_despesa.IDTitular = (int)frm.propEscolha.IDTitular;
				_despesa.Titular = frm.propEscolha.Titular;
				_despesa.CNP = frm.propEscolha.CNP;
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

		private void btnSetDespesaTipo_Click(object sender, EventArgs e)
		{
			frmDespesaTipoProcura frm = new frmDespesaTipoProcura(this, _despesa.IDDespesaTipo == 0 ? null : (int?)_despesa.IDDespesaTipo);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDCredor != frm.propEscolha.IDDespesaTipo)
					Sit = EnumFlagEstado.Alterado;

				_despesa.IDDespesaTipo = (int)frm.propEscolha.IDDespesaTipo;
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

			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _despesa.IDDocumentoTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_despesa.IDDocumentoTipo = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
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
					txtCredor,
					txtDespesaTipo,
					txtDocumentoTipo,
					txtSetor,
					txtDespesaDescricao,
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
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtDocumentoTipo":
						btnSetDocumentoTipo_Click(sender, new EventArgs());
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
					case "txtDespesaDescricao":
						e.Handled = false;
						break;
					case "txtTitular":
						e.Handled = false;
						_despesa.Titular = string.Empty;
						_despesa.CNP = string.Empty;
						_despesa.IDTitular = null;
						txtTitular.Clear();
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
					txtDocumentoTipo, txtDespesaDescricao,
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
					txtCredor,
					txtDespesaTipo,
					txtDocumentoTipo,
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

							if (tipo.IDDocumentoTipo != _despesa.IDDocumentoTipo)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_despesa.IDDocumentoTipo = (byte)tipo.IDDocumentoTipo;
								txtDocumentoTipo.Text = tipo.DocumentoTipo;
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

		// DEFINE CRIA UM TEXTO AUTOMATICA PARA DESCRICAO
		//------------------------------------------------------------------------------------------------------------
		private void defineDescricao()
		{
			// Oferta: TIPO de DESPESA + CREDOR

			if (string.IsNullOrEmpty(_despesa.DespesaTipo))
			{
				AbrirDialog("Favor definir o Tipo de Despesa...", "Tipo de Despesa");
				txtDespesaTipo.Focus();
				return;
			}

			string descricao = _despesa.DespesaTipo;

			if (!string.IsNullOrEmpty(_despesa.Credor))
			{
				descricao += " - " + _despesa.Credor;

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

		// CHECKBOX CHANGED
		//------------------------------------------------------------------------------------------------------------
		private void chkParcelado_CheckedChanged(object sender, EventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				chkParcelado.Checked = _despesa.Parcelas > 1;
				return;
			}
			//---------------------------------------------------

			if (!chkParcelado.Checked && listAPagar.Count > 0)
			{
				var resp = AbrirDialog("Essa operação fará a exclusão de todas as parcelas da listagem...\n" +
					"Deseja realmente desmarcar o parcelamento?", "Parcelamento",
					DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

				if (resp == DialogResult.Yes)
				{
					bindParcelas.Clear();
				}
				else
				{
					chkParcelado.Checked = true;
					return;
				}
			}

			ChangeParcelado(chkParcelado.Checked);
		}

		// CHANGE PARCELADO PROPERTY
		//------------------------------------------------------------------------------------------------------------
		private void ChangeParcelado(bool parcelado)
		{
			bool _parcelado = _despesa.Parcelas > 1;

			if (parcelado != _parcelado)
			{
				numParcelas.Enabled = parcelado;

				lblParcelas.ForeColor = parcelado == true ? Color.Black : Color.WhiteSmoke;
				btnParcelasGerar.Enabled = parcelado;

				if (parcelado == true)
				{
					_despesa.Parcelas = 2;
					numParcelas.DataBindings["value"].ReadValue();
					numParcelas.Maximum = 200;
					numParcelas.Minimum = 2;
				}
				else
				{
					_despesa.Parcelas = 1;
					numParcelas.DataBindings["value"].ReadValue();
					numParcelas.Maximum = 1;
					numParcelas.Minimum = 1;
				}
			}
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

		#region PARCELAS

		// GERAR PARCELAS
		//------------------------------------------------------------------------------------------------------------
		private bool ParcelasGerar()
		{
			try
			{
				// check data
				if (!VerificaParcelasDados()) return false;

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// create parcelamento
				List<objAPagar> newList = CreateParcelamentoItems();

				if (newList == null) return false;

				// define Binding of Datagridview
				newList.ForEach(x => bindParcelas.Add(x));
				dgvListagem.DataSource = bindParcelas;

				// block change in numParcela
				numParcelas.Enabled = false;
				btnParcelasGerar.Enabled = false;

				// RETURN
				return true;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de parcelamento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// CHECK DATA TO CREATE PARCELAMENTO
		//------------------------------------------------------------------------------------------------------------
		private bool VerificaParcelasDados()
		{
			if (string.IsNullOrEmpty(_despesa.Credor))
			{
				AbrirDialog("O CREDOR da Despesa precisa ser informado...\n" +
					"Favor escolher o Credor / Fornecedor desta despesa.", "Descrição da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtCredor, "Descrição necessária...");
				txtCredor.Focus();
				return false;
			}

			if (string.IsNullOrEmpty(_despesa.DespesaDescricao))
			{
				AbrirDialog("A descrição da Despesa precisa ser informada...\n" +
					"Favor inserir a descrição desta despesa.", "Descrição da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtDespesaDescricao, "Descrição necessária...");
				txtDespesaDescricao.Focus();
				return false;
			}

			if (string.IsNullOrEmpty(_despesa.DocumentoNumero))
			{
				AbrirDialog("O número do Documento da Despesa precisa ser informado...\n" +
					"Favor inserir o número do documento desta despesa.", "Número do Documento",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtDocumentoNumero, "Informação necessária...");
				txtDocumentoNumero.Focus();
				return false;
			}

			if (_despesa.DespesaValor <= 0)
			{
				AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
					"Favor inserir o valor desta despesa corretamente.", "Valor da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtDespesaValor, "Valor necessário...");
				txtDespesaValor.Focus();
				return false;
			}

			return true;
		}

		// CREATE ALL PARCELAS | APAGAR
		//------------------------------------------------------------------------------------------------------------
		private List<objAPagar> CreateParcelamentoItems()
		{
			bindParcelas.Clear();

			// Open Form Parcelamento
			var frm = new frmDespesaParcelamento((int)numParcelas.Value, this);
			frm.ShowDialog();

			// check RESPONSE
			if (frm.DialogResult != DialogResult.OK) return null;

			// Define Values and Vencimento Dates
			decimal parcValor = _despesa.DespesaValor / numParcelas.Value;
			DateTime dtVencimento = _despesa.DespesaData;

			if (frm.VencimentoDia >= dtVencimento.Day)
			{
				if (!DateTime.TryParse($"{frm.VencimentoDia}/{dtVencimento.Month}/{dtVencimento.Year}", out dtVencimento))
				{
					int maxDays = DateTime.DaysInMonth(dtVencimento.Year, dtVencimento.Month);
					dtVencimento = new DateTime(dtVencimento.Year, dtVencimento.Month, maxDays);
				};
			}
			else
			{
				dtVencimento = dtVencimento.AddMonths(1);

				if (!DateTime.TryParse($"{frm.VencimentoDia}/{dtVencimento.Month}/{dtVencimento.Year}", out dtVencimento))
				{
					int maxDays = DateTime.DaysInMonth(dtVencimento.Year, dtVencimento.Month);
					dtVencimento = new DateTime(dtVencimento.Year, dtVencimento.Month, maxDays);
				};
			}

			// create List
			List<objAPagar> pagList = new List<objAPagar>();

			// create itemns
			for (int i = 0; i < numParcelas.Value; i++)
			{
				pagList.Add(new objAPagar(null)
				{
					IDAPagar = null,
					APagarValor = parcValor,
					IDCobrancaForma = (int)frm.IDCobrancaForma,
					CobrancaForma = frm.CobrancaForma,
					IDBanco = frm.IDBanco,
					Banco = frm.BancoNome,
					DespesaDescricao = _despesa.DespesaDescricao,
					IDDespesa = _despesa.IDDespesa == null ? 0 : (int)_despesa.IDDespesa,
					Identificador = $"{_despesa.DocumentoNumero} | {(i + 1).ToString("D2")}",
					IDSituacao = 1,
					Parcela = (byte)(i + 1),
					Imagem = false,
					PagamentoData = null,
					Prioridade = 3,
					ValorPago = 0,
					Vencimento = dtVencimento,
					ReferenciaAno = dtVencimento.Year,
					ReferenciaMes = dtVencimento.Month,
					IDCredor = _despesa.IDCredor,
					Credor = _despesa.Credor,
				});

				dtVencimento = dtVencimento.AddMonths(1);
			}

			return pagList;
		}

		// EDITAR A PARCELA
		//------------------------------------------------------------------------------------------------------------
		private void ParcelaEditar()
		{
			if (dgvListagem.SelectedRows.Count == 0) return;

			objAPagar pag = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			var frm = new APagar.frmAPagarDetalhe(pag, this);
			frm.ShowDialog();
		}

		#endregion // PARCELAS --- END

		#region DATAGRID LIST FUNCTIONS

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

			//--- (1) COLUNA FORMA
			clnForma.DataPropertyName = "CobrancaForma";
			clnForma.Visible = true;
			clnForma.ReadOnly = true;
			clnForma.Resizable = DataGridViewTriState.False;
			clnForma.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnForma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA ID
			clnIdentificador.DataPropertyName = "Identificador";
			clnIdentificador.Visible = true;
			clnIdentificador.ReadOnly = true;
			clnIdentificador.Resizable = DataGridViewTriState.False;
			clnIdentificador.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIdentificador.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA VENCIMENTO
			clnVencimento.DataPropertyName = "Vencimento";
			clnVencimento.Visible = true;
			clnVencimento.ReadOnly = true;
			clnVencimento.Resizable = DataGridViewTriState.False;
			clnVencimento.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnVencimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- (4) COLUNA VALOR
			clnValor.DataPropertyName = "APagarValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Format = "#,##0.00";

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnForma, clnIdentificador, clnVencimento, clnValor);

			dgvListagem.CellDoubleClick += (a, b) => ParcelaEditar();
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

				//--- INSERT Desepesa
				long newID = despBLL.InsertDespesa(_despesa, ref listAPagar);
				_despesa.IDDespesa = newID;
				bind.EndEdit();
				bind.ResetBindings(false);

				Sit = EnumFlagEstado.RegistroSalvo;

				AbrirDialog("Registro de despesa salvo com sucesso!",
					"Salvamento Efetuado");

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
			if (!VerificaDadosClasse(txtSetor, "Setor Debitado", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtCredor, "Credor/Fornecedor", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtDespesaTipo, "Tipo de Despesa", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtDocumentoTipo, "Tipo de Documento", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtDocumentoNumero, "Número do Documento", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtDespesaDescricao, "Descrição da Despesa", _despesa, EP)) return false;

			// CHECK VALUE
			if (_despesa.DespesaValor <= 0)
			{
				AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
					"Favor inserir o valor desta despesa corretamente.", "Valor da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtDespesaValor, "Valor necessário...");
				txtDespesaValor.Focus();
				return false;
			}

			//--- Check and Create APagar
			if (listAPagar.Count == 0)
			{
				if (chkParcelado.Checked)
				{
					AbrirDialog("Antes de Salvar a Despesa, favor pressionar " +
						"o botão de GERAR PARCELAMENTO para que as parcelas sejam criadas",
						"Gerar Parcelamento", DialogType.OK, DialogIcon.Information);
					return false;
				}
				else
				{
					if (!ParcelasGerar()) return false;
				}
			}

			// CHECK PARCELAS VALUE AND PARCELAS QUANTITY
			if (listAPagar.Count > 0)
			{
				// check VALUE
				decimal parcTotal = listAPagar.Sum(x => x.APagarValor);

				if (Math.Abs(_despesa.DespesaValor - parcTotal) > 1)
				{
					AbrirDialog($"O valor do somatório das parcelas: {parcTotal:c} não pode ser maior que o valor da Despesa:{_despesa.DespesaValor:c}\n" +
								"Favor verificar se o valor das parcelas está correto.", "Valor das Parcelas",
								DialogType.OK, DialogIcon.Exclamation);
					txtDespesaValor.Focus();
					return false;
				}

				// check quantity
				if (listAPagar.Count != _despesa.Parcelas)
				{
					var resp = AbrirDialog($"A quantidade de parcelas deve ser igual ao número de items " +
										   $"na listagem de parcelamento\n" +
										   "Deseja alterar a quantidade de parcelas para conferir com a quantidade de items?",
										   "Quantidade de Parcelas",
										   DialogType.SIM_NAO,
										   DialogIcon.Question);

					if (resp == DialogResult.Yes)
					{
						_despesa.Parcelas = (byte)listAPagar.Count;
					}
					else
					{
						numParcelas.Focus();
						return false;
					}
				}
			}

			return true;
		}


		#endregion // SALVAR REGISTRO --- END
	}
}
