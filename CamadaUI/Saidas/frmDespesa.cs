using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
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
		private objDespesaComum _despesa;
		private DespesaComumBLL despBLL = new DespesaComumBLL();
		private BindingSource bind = new BindingSource();
		private BindingSource bindParcelas = new BindingSource();
		private EnumFlagEstado _Sit;
		private List<objAPagar> listAPagar = new List<objAPagar>();

		private List<objDespesaDocumentoTipo> listDocTipos;
		private objSetor setorSelected;
		private Form _formOrigem;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		// CONSTRUCTOR WITH DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmDespesa(objDespesaComum despesa, Form formOrigem = null)
		{
			InitializeComponent();
			_formOrigem = formOrigem;

			//--- Continue
			ConstructorContinue(despesa);
		}

		// CONSTRUCTOR WITH ID
		//------------------------------------------------------------------------------------------------------------
		public frmDespesa(long IDDespesa, Form formOrigem = null)
		{
			InitializeComponent();
			_formOrigem = formOrigem;

			//--- get DESPESA object
			var desp = GetDespesaByID(IDDespesa);
			if (desp == null) return;

			//--- Continue
			ConstructorContinue(desp);
		}

		// CONSTRUCTOR CONTINUE AFTER GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objDespesaComum despesa)
		{
			_despesa = despesa;

			GetDocTipos();

			// Define Conta and Setor padrao
			frmPrincipal principal = Application.OpenForms.OfType<frmPrincipal>().First();
			setorSelected = principal.propSetorPadrao;

			// binding
			bind.DataSource = typeof(objDespesaComum);
			bind.Add(_despesa);
			BindingCreator();

			ChangeParcelado(_despesa.Parcelas > 1);

			// check Periodo Referencia
			CheckPeriodoReferencia();

			// check Max Despesa Data to previne future date
			dtpDespesaData.MaxDate = DateTime.Today;

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
			dgvListagem.CellDoubleClick += mnuEditarAPagar_Click;
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

					EnableControlReferencia();
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

					EnableControlReferencia();

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
		private objDespesaComum GetDespesaByID(long ID)
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

			dtpDataInicial.DataBindings.Add("Value", bind, "DataInicial", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpDataFinal.DataBindings.Add("Value", bind, "DataFinal", true, DataSourceUpdateMode.OnPropertyChanged);

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

			_despesa = new objDespesaComum(null);
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

			Fechar();
		}

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
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		private void Fechar()
		{
			Close();

			if (_formOrigem != null && _formOrigem.Name == "frmDespesaListagem")
			{
				var frm = new frmDespesaListagem();
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				frm.Show();
			}
			else if (Application.OpenForms.Count == 1)
			{
				MostraMenuPrincipal();
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
				if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDDespesaTipo != frm.propEscolha.IDDespesaTipo)
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

		// VERIFY PARCELAS NUMBER TO CHANGE PARCELADO
		//------------------------------------------------------------------------------------------------------------
		private void VerifyNumberOfParcelas()
		{
			int countParc = listAPagar.Count;
			chkParcelado.CheckedChanged -= chkParcelado_CheckedChanged;
			chkParcelado.Checked = countParc > 1;
			chkParcelado.CheckedChanged += chkParcelado_CheckedChanged;
			numParcelas.Value = countParc == 0 ? 1 : countParc;
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
			var frm = new frmDespesaParcelamento((int)numParcelas.Value, _despesa.DespesaData, this);
			frm.ShowDialog();

			// check RESPONSE
			if (frm.DialogResult != DialogResult.OK) return null;

			// Define Values and Vencimento Dates
			decimal parcValor = _despesa.DespesaValor / numParcelas.Value;

			//DateTime dtVencimento = _despesa.DespesaData;
			DateTime dtVencimento = frm.Vencimento;

			/*
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
			*/

			// create List
			List<objAPagar> pagList = new List<objAPagar>();

			// create itemns
			for (int i = 0; i < numParcelas.Value; i++)
			{
				pagList.Add(new objAPagar(null)
				{
					IDAPagar = null,
					APagarValor = parcValor,
					IDAPagarForma = (int)frm.SelPagForma.IDAPagarForma,
					APagarForma = frm.SelPagForma.APagarForma,
					IDBanco = frm.IDBanco,
					Banco = frm.BancoNome,
					DespesaDescricao = _despesa.DespesaDescricao,
					IDDespesa = _despesa.IDDespesa == null ? 0 : (int)_despesa.IDDespesa,
					Identificador = $"{_despesa.DocumentoNumero} | {(i + 1).ToString("D2")}",
					IDSituacao = 1,
					Parcela = (byte)(i + 1),
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

		#endregion // PARCELAS --- END

		#region MENU A PAGAR

		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			// check button
			if (e.Button != MouseButtons.Right) return;

			Control c = (Control)sender;
			DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
			dgvListagem.ClearSelection();

			if (hit.Type == DataGridViewHitTestType.Cell)
			{
				// seleciona o ROW
				dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dgvListagem.CurrentCell = dgvListagem.Rows[hit.RowIndex].Cells[2];
				dgvListagem.Rows[hit.RowIndex].Selected = true;

				// mostra o MENU ativar e desativar
				objAPagar desp = (objAPagar)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

				// mnuImagem
				bool IsThereImagem = desp.Imagem != null && !string.IsNullOrEmpty(desp.Imagem.ImagemFileName);

				mnuImagemRemover.Enabled = IsThereImagem;
				mnuImagemInserir.Text = IsThereImagem ? "Alterar Imagem" : "Inserir Imagem";
				mnuImagemVisualizar.Enabled = IsThereImagem;

				mnuEditarAPagar.Enabled = true;
				mnuExcluirAPagar.Enabled = true;
				mnuImagemAPagar.Enabled = true;
			}
			else
			{
				mnuEditarAPagar.Enabled = false;
				mnuExcluirAPagar.Enabled = false;
				mnuImagemAPagar.Enabled = false;
			}

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		// INSERT IMAGE
		//------------------------------------------------------------------------------------------------------------
		private void mnuImagemInserir_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Inserir Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível inserir imagem de uma Parcela de APagar num Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de Inserir a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)item.IDAPagar,
					Origem = EnumImagemOrigem.APagar,
					ImagemFileName = item.Imagem == null ? string.Empty : item.Imagem.ImagemFileName,
					ImagemPath = item.Imagem == null ? string.Empty : item.Imagem.ImagemPath,
					ReferenceDate = item.Vencimento,
				};

				// open form to edit or save image
				bool IsNew = item.Imagem == null || string.IsNullOrEmpty(item.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (item.Imagem != null && imagem != null)
				{
					IsUpdated = (item.Imagem.ImagemFileName != imagem.ImagemFileName) || (item.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				item.Imagem = imagem;

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

		private void mnuImagemVisualizar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível visualizar imagem de uma Parcela de APagar numa Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de Visualizar a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(item.Imagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Visualizar a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuImagemRemover_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível REMOVER imagem de uma Parcela de APagar numa Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de REMOVER a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			DialogResult resp;

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da despesa selecionada?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				item.Imagem = ImagemUtil.ImagemRemover(item.Imagem);

				AbrirDialog("Imagem desassociada com sucesso!" +
					"\nPor segurança a imagem foi guardada na pasta de Imagens Removidas.",
					"Imagem Removida", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Remover a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// ADICIONAR APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuAdicionarAPagar_Click(object sender, EventArgs e)
		{
			try
			{
				//--- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- CHECK IDENTIFICADOR
				if (string.IsNullOrEmpty(_despesa.DocumentoNumero))
				{
					AbrirDialog("O Número do Documento da Despesa precisa estar preenchido...\n" +
						"Favor inserir o valor deste item corretamente.",
						"Número do Documento",
						DialogType.OK,
						DialogIcon.Exclamation);
					EP.SetError(txtDocumentoNumero, "Valor necessário...");
					txtDocumentoNumero.Focus();
					return;
				}

				//--- CHECK DESPESA VALUE
				if (_despesa.DespesaValor <= 0)
				{
					AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
						"Favor inserir o valor desta despesa corretamente.",
						"Valor da Despesa",
						DialogType.OK,
						DialogIcon.Exclamation);
					EP.SetError(txtDespesaValor, "Valor necessário...");
					txtDespesaValor.Focus();
					return;
				}

				//--- define value
				decimal vlMaximo = _despesa.DespesaValor - listAPagar.Sum(x => x.APagarValor);

				if (vlMaximo <= 0)
				{
					AbrirDialog("O Valor Total das Parcelas APagar já alcançou o valor da Despesa..." +
						"\nNão há possibilidade de criar Novas Parcelas.",
						"Valor Alcançado", DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				//--- define date
				DateTime newDate = _despesa.DespesaData;

				//--- define LAST APagar
				objAPagar LastPag = null;

				if (listAPagar.Count > 0)
				{
					LastPag = listAPagar.OrderBy(x => x.Vencimento).Last();
				}

				//--- define new apagar
				var newParcela = new objAPagar(null)
				{
					Identificador = $"{_despesa.DocumentoNumero} | {(listAPagar.Count + 1).ToString("D2")}",
					Parcela = (byte)(listAPagar.Count + 1),
					APagarValor = vlMaximo,
					Vencimento = LastPag != null ? LastPag.Vencimento.AddMonths(1) : newDate,
					IDBanco = LastPag != null ? LastPag.IDBanco : null,
					Banco = LastPag != null ? LastPag.Banco : "",
					IDAPagarForma = LastPag != null ? LastPag.IDAPagarForma : 1,
					APagarForma = LastPag != null ? LastPag.APagarForma : "Em Carteira"
				};

				//--- open Form
				var frm = new frmDespesaAPagarItem(newParcela, vlMaximo, _despesa.DespesaData, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				bindParcelas.Add(newParcela);
				bindParcelas.ResetBindings(false);
				VerifyNumberOfParcelas();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Adicionar parcela de APagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EDITAR A PAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuEditarAPagar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Editar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar != null)
			{
				VerDetalheAPagar(item);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- CHECK DESPESA VALUE
				if (_despesa.DespesaValor <= 0)
				{
					AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
						"Favor inserir o valor desta despesa corretamente.",
						"Valor da Despesa",
						DialogType.OK,
						DialogIcon.Exclamation);
					EP.SetError(txtDespesaValor, "Valor necessário...");
					txtDespesaValor.Focus();
					return;
				}

				//--- define value
				decimal vlMaximo = _despesa.DespesaValor - listAPagar.Sum(x => x.APagarValor) + item.APagarValor;

				//--- define date
				DateTime newDate = item.Vencimento;

				if (listAPagar.Count > 0)
				{
					newDate = listAPagar.OrderBy(x => x.Vencimento).Last().Vencimento.AddMonths(1);
				}

				//--- define new apagar
				var Parcela = item;

				//--- open Form
				var frm = new frmDespesaAPagarItem(Parcela, vlMaximo, _despesa.DespesaData, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				bindParcelas.ResetBindings(false);
				VerifyNumberOfParcelas();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Editar a Parcela..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// DETALHE APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void VerDetalheAPagar(objAPagar pag)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var frm = new APagar.frmAPagarDetalhe(pag, this);
				frm.ShowDialog();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Abrir Formulário de Detalhamento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EXCLUIR APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuExcluirAPagar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para EXCLUIR...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar != null)
			{
				AbrirDialog("Não é possível EXCLUIR uma parcela de APagar que já está salva.",
					"Registro Bloqueado",
					DialogType.OK,
					DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				bindParcelas.Remove(item);
				bindParcelas.ResetBindings(false);
				VerifyNumberOfParcelas();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir registro de APagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // MENU A PAGAR --- END

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

			//--- (0) COLUNA ID
			clnIdentificador.DataPropertyName = "Identificador";
			clnIdentificador.Visible = true;
			clnIdentificador.ReadOnly = true;
			clnIdentificador.Resizable = DataGridViewTriState.False;
			clnIdentificador.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIdentificador.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.DefaultCellStyle.Font = clnFont;

			//--- (1) COLUNA FORMA
			clnForma.DataPropertyName = "APagarForma";
			clnForma.Visible = true;
			clnForma.ReadOnly = true;
			clnForma.Resizable = DataGridViewTriState.False;
			clnForma.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnForma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA SITUACAO
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA VENCIMENTO
			clnVencimento.DataPropertyName = "Vencimento";
			clnVencimento.Visible = true;
			clnVencimento.ReadOnly = true;
			clnVencimento.Resizable = DataGridViewTriState.False;
			clnVencimento.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnVencimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.DefaultCellStyle.Font = clnFont;

			//--- (4) COLUNA VALOR
			clnValor.DataPropertyName = "APagarValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Format = "#,##0.00";
			clnValor.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnIdentificador, clnForma, clnSituacao, clnVencimento, clnValor);
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
				long newID = despBLL.InsertDespesaComum(_despesa, ref listAPagar);
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

			// CHECK DESPESA VALUE
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
					AbrirDialog("Informe as Parcelas de APagar dessa Despesa\n" +
						"Use o segundo botão do mouse na listagem e adicione uma ou mais parcelas.",
						"Informar Parcelamento",
						DialogType.OK,
						DialogIcon.Information);
					return false;
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

			//--- check DATA FUTURA
			if (_despesa.DespesaData > DateTime.Today)
			{
				AbrirDialog("A Data da Despesa não pode ser maior que a Data de hoje\n" +
						"Favor reinserir a Data da Despesa anterior.", "Data da Despesa",
						DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(dtpDespesaData, "Valor incorreto...");
				dtpDespesaData.Focus();
				return false;
			}

			//--- check DATA PERIODO
			if (chkReferencia.Checked)
			{
				if (_despesa.DataInicial == null || _despesa.DataFinal == null)
				{
					AbrirDialog("As Datas do Período de Referência INICIAL e/ou FINAL não podem ficar vazias\n" +
							"Favor inserir o valor nestes campos corretamente.", "Data Inicial/Final",
							DialogType.OK, DialogIcon.Exclamation);
					EP.SetError(dtpDataInicial, "Valor necessário...");
					dtpDataInicial.Focus();
					return false;
				}

				if (_despesa.DataInicial > _despesa.DataFinal)
				{
					AbrirDialog("A Data Final do Período de Referência não podem ser anterior a Data Inicial\n" +
							"Favor reinserir o valor nestes campos corretamente.", "Data Inicial/Final",
							DialogType.OK, DialogIcon.Exclamation);
					EP.SetError(dtpDataFinal, "Valor incorreto...");
					dtpDataFinal.Focus();
					return false;
				}

			}
			else
			{
				_despesa.DataInicial = null;
				_despesa.DataFinal = null;
			}

			return true;
		}


		#endregion // SALVAR REGISTRO --- END

		#region IMAGE CONTROL
		private void btnInserirImagem_Click(object sender, EventArgs e)
		{
			if (_despesa.IDDespesa == null)
			{
				AbrirDialog("É necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)_despesa.IDDespesa,
					Origem = EnumImagemOrigem.Despesa,
					ImagemFileName = _despesa.Imagem == null ? string.Empty : _despesa.Imagem.ImagemFileName,
					ImagemPath = _despesa.Imagem == null ? string.Empty : _despesa.Imagem.ImagemPath,
					ReferenceDate = _despesa.DespesaData,
				};

				// open form to edit or save image
				bool IsNew = _despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (_despesa.Imagem != null && imagem != null)
				{
					IsUpdated = (_despesa.Imagem.ImagemFileName != imagem.ImagemFileName) || (_despesa.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				_despesa.Imagem = imagem;

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

		private void btnVerImagem_Click(object sender, EventArgs e)
		{
			if (_despesa.IDDespesa == null)
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa..." +
					"\nÉ necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				var resp = AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa..." +
					"\nDeseja INSERIR uma nova imagem à despesa?",
					"Não há Imagem", DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					btnInserirImagem_Click(sender, e);
				}

				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(_despesa.Imagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Visualizar a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void mnuImagem_Click(object sender, EventArgs e)
		{
			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				btnInserirImagem.Text = "Inserir Imagem";
				btnRemoverImagem.Enabled = false;
			}
			else
			{
				btnInserirImagem.Text = "Alterar Imagem";
				btnRemoverImagem.Enabled = true;
			}
		}

		private void btnRemoverImagem_Click(object sender, EventArgs e)
		{
			DialogResult resp;

			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa para que seja removida...",
					"Não há Imagem", DialogType.OK, DialogIcon.Warning);
				return;
			}

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da despesa atual?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				_despesa.Imagem = ImagemUtil.ImagemRemover(_despesa.Imagem);

				AbrirDialog("Imagem desassociada com sucesso!" +
					"\nPor segurança a imagem foi guardada na pasta de Imagens Removidas.",
					"Imagem Removida", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Remover a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // IMAGE CONTROL --- END

		#region PERIODO REFERENCIA

		private void chkReferencia_CheckedChanged(object sender, EventArgs e)
		{
			if (!chkReferencia.Checked)
			{
				_despesa.DataFinal = null;
				_despesa.DataInicial = null;

			}
			else
			{
				if (_despesa.DataInicial == null || _despesa.DataFinal == null)
				{
					dtpDataInicial.MinDate = DateTime.Today.AddYears(-3);
					dtpDataFinal.MinDate = DateTime.Today.AddYears(-3);
					dtpDataInicial.Value = _despesa.DespesaData;
					dtpDataFinal.Value = _despesa.DespesaData;
				}
			}

			EnableControlReferencia();
		}

		// UPDATE PERIODO REFERENCIA
		//------------------------------------------------------------------------------------------------------------
		private void CheckPeriodoReferencia()
		{
			if (_despesa.DataInicial == null || _despesa.DataFinal == null)
			{
				chkReferencia.Checked = false;
			}
			else
			{
				chkReferencia.Checked = true;
			}
		}

		// CONTROL PERIODO 
		//------------------------------------------------------------------------------------------------------------
		private void EnableControlReferencia()
		{
			bool IsEnable = chkReferencia.Checked;
			bool IsLocked;
			bool IsVisible;

			// IS UNLOCKED AND VISIBLE? SIT => NEW
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				IsLocked = false;
				IsVisible = true;
			}
			else
			{
				// IS DISABLED AND VISIBLE
				if (_despesa.DataInicial != null)
				{
					IsLocked = true;
					IsVisible = true;
				}
				// IS DISABLED AND INVISIBLE
				else
				{
					IsLocked = true;
					IsVisible = false;
				}
			}

			// APPLYING USING VARIABLES
			if (IsVisible && !IsLocked) // IS NEW
			{
				chkReferencia.Visible = true;

				if (IsEnable)
				{
					dtpDataInicial.Enabled = true;
					dtpDataFinal.Enabled = true;
				}
				else
				{
					dtpDataInicial.Enabled = false;
					dtpDataFinal.Enabled = false;
				}

				pnlReferencia.Visible = true;
				pnlDataValor.Location = new Point(12, 295);

			}
			else if (IsVisible && IsLocked) // IS SAVED WITH DATE
			{
				chkReferencia.Visible = false;

				// IS LOCKED
				dtpDataFinal.MaxDate = (DateTime)_despesa.DataFinal;
				dtpDataFinal.MinDate = (DateTime)_despesa.DataFinal;
				dtpDataInicial.MaxDate = (DateTime)_despesa.DataInicial;
				dtpDataInicial.MinDate = (DateTime)_despesa.DataInicial;

				// IS VISIBLE
				pnlReferencia.Visible = true;
				pnlDataValor.Location = new Point(12, 295);
			}
			else if (!IsVisible && IsLocked) // IS SAVED WITHOUT DATE
			{
				chkReferencia.Visible = false;

				pnlReferencia.Visible = false;
				pnlDataValor.Location = new Point(12, 320);
			}





		}



		#endregion // PERIODO REFERENCIA --- END

	}
}
