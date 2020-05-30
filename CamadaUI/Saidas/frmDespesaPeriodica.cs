using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaBLL;
using CamadaDTO;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;
using CamadaUI.Caixa;
using CamadaUI.Registres;
using CamadaUI.Setores;
using CamadaUI.Main;

namespace CamadaUI.Saidas
{
	public partial class frmDespesaPeriodica : CamadaUI.Modals.frmModFinBorder
	{
		private DespesaPeriodicaBLL despBLL = new DespesaPeriodicaBLL();
		private objDespesaPeriodica _despesa;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private List<objCobrancaForma> listFormas;

		private objSetor setorSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		// CONSTRUCTOR WITH DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaPeriodica(objDespesaPeriodica despesa)
		{
			InitializeComponent();
			ConstructorContinue(despesa);
		}

		// CONSTRUCTOR WITH ID
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaPeriodica(long IDDespesa)
		{
			InitializeComponent();
			var desp = GetDespesaByID(IDDespesa);

			if (desp == null) return;

			ConstructorContinue(GetDespesaByID(IDDespesa));
		}

		// CONSTRUCTOR CONTINUE AFTER GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objDespesaPeriodica despesa)
		{
			_despesa = despesa;
			GetFormasList();
			AtivoButtonImage();

			// Define Conta and Setor padrao
			frmPrincipal principal = Application.OpenForms.OfType<frmPrincipal>().First();
			setorSelected = principal.propSetorPadrao;

			// binding
			bind.DataSource = typeof(objDespesaPeriodica);
			bind.Add(_despesa);
			BindingCreator();

			if (_despesa.IDDespesa == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				_despesa.IDSetor = (int)setorSelected.IDSetor;
				_despesa.Setor = setorSelected.Setor;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			DefineRecorrenciaTipo(_despesa.RecorrenciaTipo);

			// handlers
			_despesa.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);

			txtRecorrenciaRepeticao.TextAlign = HorizontalAlignment.Left;

		}

		// SHOW
		//------------------------------------------------------------------------------------------------------------
		private void frmDespesaPeriodica_Shown(object sender, EventArgs e)
		{
			if (_despesa == null)
			{
				Close();
				return;
			}

			txtSetor.Enter += text_Enter;
			txtCredor.Enter += text_Enter;
			txtDespesaTipo.Enter += text_Enter;
			txtCobrancaForma.Enter += text_Enter;
			txtBanco.Enter += text_Enter;

			// block keyDown then Sit = Alterado
			txtDespesaValor.KeyDown += control_KeyDown_Block;
			dtpIniciarData.KeyDown += control_KeyDown_Block;
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
				}
				else
				{
					btnNovo.Enabled = true;
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
				}

				// btnSET ENABLE | DISABLE
				btnSetDespesaTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetForma.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetBanco.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetCredor.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// GET DESPESA BY ID
		//------------------------------------------------------------------------------------------------------------
		private objDespesaPeriodica GetDespesaByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return despBLL.GetDespesaPeriodica(ID);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Despesa Periódica..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF FORMAS DE COBRANCA
		//------------------------------------------------------------------------------------------------------------
		private void GetFormasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listFormas = new CobrancaFormaBLL().GetListCobrancaForma(true);
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

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDDespesa", true);
			lblDespesaData.DataBindings.Add("Text", bind, "DespesaData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCredor.DataBindings.Add("Text", bind, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaTipo.DataBindings.Add("Text", bind, "DespesaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCobrancaForma.DataBindings.Add("Text", bind, "CobrancaForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bind, "BancoNome", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpIniciarData.DataBindings.Add("Value", bind, "IniciarData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaValor.DataBindings.Add("Text", bind, "DespesaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			txtRecorrenciaRepeticao.DataBindings.Add("Text", bind, "RecorrenciaRepeticao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblRecorrenciaTexto.DataBindings.Add("Text", bind, "RecorrenciaTexto", true, DataSourceUpdateMode.OnValidation);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtDespesaValor.DataBindings["Text"].Format += FormatCurrency;
			txtRecorrenciaRepeticao.DataBindings["Text"].Format += FormatD2;
			lblDespesaData.DataBindings["Text"].Format += (a, e) => { e.Value = DateTime.Parse(e.Value.ToString()).ToString("dd/MMMM/yyyy"); };

			// PREENCHE COMBOS
			CarregaComboRecorrenciaTipo();
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

		private void FormatD2(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:D2}", e.Value);
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

		#region CARREGA COMBOS

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaComboRecorrenciaTipo()
		{
			//--- Create DataTable
			DataTable dtTipo = new DataTable();
			dtTipo.Columns.Add("ID", typeof(int));
			dtTipo.Columns.Add("Tipo");

			// get values of EnumAgendaRecorrencia
			var EnumValues = EnumUtil.AgendaRecorrenciaTexto();

			// insert all item of EnumAgendaRecorrencia in datatable
			foreach (var item in EnumValues)
			{
				dtTipo.Rows.Add(new object[] { item.Key, item.Value });
			}

			//--- Set DataTable
			cmbRecorrenciaTipo.DataSource = dtTipo;
			cmbRecorrenciaTipo.ValueMember = "ID";
			cmbRecorrenciaTipo.DisplayMember = "Tipo";
			cmbRecorrenciaTipo.DataBindings.Add("SelectedValue", bind, "RecorrenciaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		private void CarregaComboRecorrenciaDiaMes()
		{
			//--- Create DataTable
			DataTable dtDiaMes = new DataTable();
			dtDiaMes.Columns.Add("ID", typeof(int));
			dtDiaMes.Columns.Add("Tipo");

			// insert all days of mes 1 TO 31
			for (int i = 0; i < 31; i++)
			{
				dtDiaMes.Rows.Add(new object[] { i + 1, (i + 1).ToString("D2") });
			}

			//--- Set DataTable
			cmbRecorrenciaDia.DataSource = dtDiaMes;
			cmbRecorrenciaDia.ValueMember = "ID";
			cmbRecorrenciaDia.DisplayMember = "Tipo";
			cmbRecorrenciaDia.DropDownHeight = 193;
			cmbRecorrenciaDia.Width = 57;

			// BINDING
			if (cmbRecorrenciaDia.DataBindings.Count == 0)
			{
				cmbRecorrenciaDia.DataBindings.Add("SelectedValue", bind, "RecorrenciaDia", true, DataSourceUpdateMode.OnPropertyChanged);
			}
		}

		private void CarregaComboRecorrenciaDiaSemana()
		{
			//--- Create DataTable
			DataTable dtDiaSemana = new DataTable();
			dtDiaSemana.Columns.Add("ID", typeof(int));
			dtDiaSemana.Columns.Add("Tipo");

			System.Globalization.CultureInfo enBr = new System.Globalization.CultureInfo("pt-BR");

			int i = 0;

			foreach (string dayName in enBr.DateTimeFormat.DayNames)
			{
				dtDiaSemana.Rows.Add(new object[] { i, dayName });
				i++;
			}

			//--- Set DataTable
			cmbRecorrenciaDia.DataSource = dtDiaSemana;
			cmbRecorrenciaDia.ValueMember = "ID";
			cmbRecorrenciaDia.DisplayMember = "Tipo";
			cmbRecorrenciaDia.DropDownHeight = 150;
			cmbRecorrenciaDia.Width = 125;

			// BINDING
			if (cmbRecorrenciaDia.DataBindings.Count == 0)
			{
				cmbRecorrenciaDia.DataBindings.Add("SelectedValue", bind, "RecorrenciaDia", true, DataSourceUpdateMode.OnPropertyChanged);
			}
		}

		private void CarregaComboRecorrenciaSemana()
		{
			//--- Create DataTable
			DataTable dtSemana = new DataTable();
			dtSemana.Columns.Add("ID", typeof(int));
			dtSemana.Columns.Add("Semana");

			//--- add Rows 
			dtSemana.Rows.Add(new object[] { 1, "1ª Semana" });
			dtSemana.Rows.Add(new object[] { 2, "2ª Semana" });
			dtSemana.Rows.Add(new object[] { 3, "3ª Semana" });
			dtSemana.Rows.Add(new object[] { 4, "4ª Semana" });

			//--- Set DataTable
			cmbRecorrenciaSemana.DataSource = dtSemana;
			cmbRecorrenciaSemana.ValueMember = "ID";
			cmbRecorrenciaSemana.DisplayMember = "Semana";
			cmbRecorrenciaSemana.DropDownHeight = 150;
			cmbRecorrenciaSemana.Width = 125;

			// BINDING
			if (cmbRecorrenciaSemana.DataBindings.Count == 0)
			{
				cmbRecorrenciaSemana.DataBindings.Add("SelectedValue", bind, "RecorrenciaSemana", true, DataSourceUpdateMode.OnPropertyChanged);
			}
		}

		private void CarregaComboRecorrenciaMes()
		{
			//--- Create DataTable
			DataTable dtMes = new DataTable();
			dtMes.Columns.Add("ID", typeof(int));
			dtMes.Columns.Add("Mes");

			System.Globalization.CultureInfo enBr = new System.Globalization.CultureInfo("pt-BR");

			int i = 0;

			foreach (string monthName in enBr.DateTimeFormat.MonthNames)
			{
				dtMes.Rows.Add(new object[] { i, monthName });
				i++;
			}

			//--- Set DataTable
			cmbRecorrenciaMes.DataSource = dtMes;
			cmbRecorrenciaMes.ValueMember = "ID";
			cmbRecorrenciaMes.DisplayMember = "Mes";
			cmbRecorrenciaMes.DropDownHeight = 150;
			cmbRecorrenciaMes.Width = 125;

			// BINDING
			if (cmbRecorrenciaMes.DataBindings.Count == 0)
			{
				cmbRecorrenciaMes.DataBindings.Add("SelectedValue", bind, "RecorrenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
			}
		}

		#endregion // CARREGA COMBOS --- END

		#region RECORRENCIA CONTROL

		// CHANGE COMBO SELECTION
		//------------------------------------------------------------------------------------------------------------
		private void cmbRecorrenciaTipo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			cmbRecorrenciaTipo.DataBindings["SelectedValue"].WriteValue();
			DefineRecorrenciaTipo(_despesa.RecorrenciaTipo);
		}

		// RECORRENCIA TIPO, TO CHANGE TEXTBOXES AND LABELS
		//------------------------------------------------------------------------------------------------------------
		private void DefineRecorrenciaTipo(byte RecorrenciaTipo)
		{
			if (_despesa.RecorrenciaTipo != RecorrenciaTipo)
				_despesa.RecorrenciaTipo = RecorrenciaTipo;

			switch (RecorrenciaTipo)
			{
				case 1: // DIARIO
					cmbRecorrenciaDia.Enabled = false;
					cmbRecorrenciaMes.Enabled = false;
					cmbRecorrenciaSemana.Enabled = false;

					break;

				case 2: // SEMANAL
					cmbRecorrenciaDia.Enabled = true;
					lblDia.Text = "Dia da Semana";
					cmbRecorrenciaMes.Enabled = false;
					cmbRecorrenciaSemana.Enabled = false;

					CarregaComboRecorrenciaDiaSemana();
					break;

				case 3: // MENSAL POR DIA
					cmbRecorrenciaDia.Enabled = true;
					lblDia.Text = "Dia do Mês";
					cmbRecorrenciaMes.Enabled = false;
					cmbRecorrenciaSemana.Enabled = false;

					CarregaComboRecorrenciaDiaMes();
					break;

				case 4: // MENSAL POR SEMANA
					cmbRecorrenciaDia.Enabled = true;
					lblDia.Text = "Dia da Semana";
					cmbRecorrenciaMes.Enabled = false;
					cmbRecorrenciaSemana.Enabled = true;

					CarregaComboRecorrenciaDiaSemana();
					CarregaComboRecorrenciaSemana();
					break;

				case 5: // ANUAL POR MES E DIA
					cmbRecorrenciaDia.Enabled = true;
					lblDia.Text = "Dia do Mês";
					cmbRecorrenciaMes.Enabled = true;
					cmbRecorrenciaSemana.Enabled = false;

					CarregaComboRecorrenciaDiaMes();
					CarregaComboRecorrenciaMes();
					break;

				case 6: // ANUAL POR MES E SEMANA
					cmbRecorrenciaDia.Enabled = true;
					lblDia.Text = "Dia da Semana";
					cmbRecorrenciaMes.Enabled = true;
					cmbRecorrenciaSemana.Enabled = true;

					CarregaComboRecorrenciaDiaSemana();
					CarregaComboRecorrenciaSemana();
					CarregaComboRecorrenciaMes();
					break;

				default:
					break;
			}

			// change labels color
			Action<Control, Label> ChangeLblColor = (ctrl, lbl) =>
			{
				lbl.ForeColor = ctrl.Enabled ? Color.Black : Color.DarkGray;
			};

			ChangeLblColor(cmbRecorrenciaDia, lblDia);
			ChangeLblColor(cmbRecorrenciaMes, lblMes);
			ChangeLblColor(cmbRecorrenciaSemana, lblSemana);
		}

		#endregion // RECORRENCIA CONTROL --- END

		#region BUTTONS

		private void btnNovo_Click(object sender, EventArgs e)
		{
			// if frmAPagarListagem is ENABLED then exit
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}

			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_despesa = new objDespesaPeriodica(null);
			Sit = EnumFlagEstado.NovoRegistro;
			bind.Add(_despesa);
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

		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmBancoProcura frm = new frmBancoProcura(this, (int)_despesa.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDBanco != frm.propEscolha.IDBanco)
						Sit = EnumFlagEstado.Alterado;

					_despesa.IDBanco = (int)frm.propEscolha.IDBanco;
					txtBanco.Text = frm.propEscolha.BancoNome;
				}

				//--- select
				txtBanco.Focus();
				txtBanco.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSetForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...", "Formas de Cobrança",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDCobrancaForma, x => x.CobrancaForma);
			var textBox = txtCobrancaForma;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _despesa.IDCobrancaForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDCobrancaForma != frm.propEscolha.Key)
					Sit = EnumFlagEstado.Alterado;

				_despesa.IDCobrancaForma = (int)frm.propEscolha.Key;
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
					txtSetor,
					txtCredor,
					txtDespesaTipo,
					txtCobrancaForma,
					txtBanco,
					txtDespesaDescricao
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

			if (e.KeyCode == Keys.Add)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtCredor":
						btnSetCredor_Click(sender, new EventArgs());
						break;
					case "txtDespesaTipo":
						btnSetDespesaTipo_Click(sender, new EventArgs());
						break;
					case "txtCobrancaForma":
						btnSetForma_Click(sender, new EventArgs());
						break;
					case "txtBanco":
						btnSetBanco_Click(sender, new EventArgs());
						break;
					case "txtDespesaDescricao":
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
					case "txtBanco":
						if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDBanco != null)
							Sit = EnumFlagEstado.Alterado;

						txtBanco.Clear();
						_despesa.BancoNome = string.Empty;
						_despesa.IDBanco = null;
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = {
					txtCobrancaForma, txtDespesaDescricao,
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
					txtCobrancaForma,
					txtBanco,
					txtDespesaDescricao
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
					case "txtCobrancaForma":

						if (listFormas.Count > 0)
						{
							var tipo = listFormas.FirstOrDefault(x => x.IDCobrancaForma == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDCobrancaForma != _despesa.IDCobrancaForma)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_despesa.IDCobrancaForma = (int)tipo.IDCobrancaForma;
								txtCobrancaForma.Text = tipo.CobrancaForma;
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

		// ON CLICK OPEN DATE FORM TO GET DESPESA DATA
		//------------------------------------------------------------------------------------------------------------
		private void lblDespesaData_Click(object sender, EventArgs e)
		{
			frmDateGet frm = new frmDateGet("Informe a Data da abertura da despesa...",
				EnumDataTipo.PassadoPresente, _despesa.DespesaData, this);

			frm.ShowDialog();

			if (frm.DialogResult != DialogResult.OK) return;

			_despesa.DespesaData = (DateTime)frm.propDataInfo;
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

				//--- INSERT Desepesa
				long newID = despBLL.InsertDespesa(_despesa);
				_despesa.IDDespesa = newID;
				bind.EndEdit();
				bind.ResetBindings(false);

				Sit = EnumFlagEstado.RegistroSalvo;

				AbrirDialog("Registro de despesa periódica salva com sucesso!",
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
			if (!VerificaDadosClasse(txtCobrancaForma, "Forma de Cobrança", _despesa, EP)) return false;
			if (!VerificaDadosClasse(cmbRecorrenciaTipo, "Tipo de Recorrência", _despesa, EP)) return false;
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

			if (_despesa.RecorrenciaMes == 0) _despesa.RecorrenciaMes = null;
			if (_despesa.RecorrenciaSemana == 0) _despesa.RecorrenciaSemana = null;

			return true;
		}


		#endregion // SALVAR REGISTRO --- END

		#region ATIVO BUTTON CONTROL

		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR um Nova Despesa Periódica", "Desativar Despesa Periódica",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_despesa.Ativa == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR esta Despesa Periódica:",
							   "Desativar Despesa Periódica", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR a Despesa Periódica:",
							   "Ativar Despesa Periódica", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_despesa.BeginEdit();
			_despesa.Ativa = !_despesa.Ativa;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_despesa.Ativa == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativa";
				}
				else if (_despesa.Ativa == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativa";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar a Despesa Periódica..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
		}

		#endregion // ATIVO BUTTON CONTROL --- END

	}
}
