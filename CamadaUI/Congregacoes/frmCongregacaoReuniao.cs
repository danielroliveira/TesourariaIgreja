using CamadaBLL;
using CamadaDTO;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Congregacoes
{
	public partial class frmCongregacaoReuniao : CamadaUI.Modals.frmModFinBorder
	{
		private objReuniao _reuniao;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;
		private int? _IDCongregacao;

		private int _RecorrenciaTipo; // property TIPO of recorrencia, change textboxes and labels

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmCongregacaoReuniao(objReuniao obj)
		{
			InitializeComponent();

			_reuniao = obj;
			bind.DataSource = _reuniao;
			BindingCreator();
			_IDCongregacao = _reuniao.IDCongregacao;

			_reuniao.PropertyChanged += RegistroAlterado;

			if (_reuniao.IDReuniao == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			propRecorrenciaTipo = _reuniao.RecorrenciaTipo;

			AtivoButtonImage();
			HandlerKeyDownControl(this);
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
			lblID.DataBindings.Add("Text", bind, "IDReuniao", true);
			txtReuniao.DataBindings.Add("Text", bind, "Reuniao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtRecorrenciaRepeticao.DataBindings.Add("Text", bind, "RecorrenciaRepeticao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCongregacao.DataBindings.Add("Text", bind, "Congregacao", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpIniciarData.DataBindings.Add("Value", bind, "IniciarData", true, DataSourceUpdateMode.OnPropertyChanged);

			lblRecorrenciaTexto.DataBindings.Add("Text", bind, "RecorrenciaTexto", true, DataSourceUpdateMode.OnValidation);
			lblIniciarEmDiaDaSemana.DataBindings.Add("Text", bind, "IniciarDataDiaDaSemana", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtRecorrenciaRepeticao.DataBindings["Text"].Format += Format00;

			// PREENCHE COMBOS
			CarregaComboRecorrenciaTipo();
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void Format00(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : int.Parse(e.Value.ToString()).ToString("D2"); //$"{e.Value: 00}";
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
				dtDiaMes.Rows.Add(new object[] { i + 1, i + 1 });
			}

			//--- Set DataTable
			cmbRecorrenciaDia.DataSource = dtDiaMes;
			cmbRecorrenciaDia.ValueMember = "ID";
			cmbRecorrenciaDia.DisplayMember = "Tipo";
			cmbRecorrenciaDia.DropDownHeight = 193;
			cmbRecorrenciaDia.Width = 50;

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

			OpenListagem();
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
					OpenListagem();
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

		// OPEN LISTAGEM FORM
		//------------------------------------------------------------------------------------------------------------
		private void OpenListagem()
		{
			var form = new frmCongregacaoReuniaoListagem();
			form.MdiParent = Application.OpenForms.OfType<frmPrincipal>().First();
			form.Show();
		}

		// INSERIR NOVO REGISTRO
		//------------------------------------------------------------------------------------------------------------
		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (Sit != EnumFlagEstado.RegistroSalvo) return;

			_reuniao = new objReuniao(null);
			Sit = EnumFlagEstado.NovoRegistro;
			AtivoButtonImage();
			bind.DataSource = _reuniao;
			txtReuniao.Focus();
		}

		private void btnAtivo_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				MessageBox.Show("Você não pode DESATIVAR um Novo Reuniao", "Desativar Reuniao",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_reuniao.Ativa == true) //--- ATIVA
			{
				var response = AbrirDialog("Você deseja realmente DESATIVAR o Reuniao:\n" +
							   txtReuniao.Text.ToUpper(),
							   "Desativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}
			else //--- INATIVO
			{
				var response = AbrirDialog("Você deseja realmente ATIVAR o Reuniao:\n" +
							   txtReuniao.Text.ToUpper(),
							   "Ativar Conta", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);
				if (response == DialogResult.No) return;
			}

			_reuniao.BeginEdit();
			_reuniao.Ativa = !_reuniao.Ativa;

			if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

			AtivoButtonImage();
		}

		private void AtivoButtonImage()
		{
			try
			{
				if (_reuniao.Ativa == true) //--- Nesse caso é Forma Ativo
				{
					btnAtivo.Image = Properties.Resources.SwitchON_30;
					btnAtivo.Text = "Ativo";
				}
				else if (_reuniao.Ativa == false) //--- Nesse caso é Forma Inativo
				{
					btnAtivo.Image = Properties.Resources.SwitchOFF_30;
					btnAtivo.Text = "Inativo";
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Ativar o reuniao..." + "\n" +
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

				ReuniaoBLL sBLL = new ReuniaoBLL();

				//--- SAVE: INSERT OR UPDATE
				if (_reuniao.IDReuniao == null) //--- save | Insert
				{
					int ID = sBLL.InsertReuniao(_reuniao);
					//--- define newID
					_reuniao.IDReuniao = ID;
				}
				else //--- update
				{
					sBLL.UpdateReuniao(_reuniao);
				}

				//--- change Sit
				Sit = EnumFlagEstado.RegistroSalvo;
				//--- emit massage
				AbrirDialog("Registro Salvo com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Reuniao..." + "\n" +
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
			if (!VerificaDadosClasse(txtReuniao, "Reuniao", _reuniao)) return false;
			if (_reuniao.RecorrenciaMes == 0) _reuniao.RecorrenciaMes = null;
			if (_reuniao.RecorrenciaSemana == 0) _reuniao.RecorrenciaSemana = null;



			return true;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmCongregacaoReuniao_KeyDown(object sender, KeyEventArgs e)
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
						if (_reuniao.IDCongregacao != null) Sit = EnumFlagEstado.Alterado;
						txtCongregacao.Clear();
						_reuniao.IDCongregacao = null;
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

			frmCongregacaoProcura frm = new frmCongregacaoProcura(this, _reuniao.IDCongregacao);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_reuniao.IDCongregacao = frm.propEscolha.IDCongregacao;
				txtCongregacao.Text = frm.propEscolha.Congregacao;
			}

			//--- select
			txtCongregacao.Focus();
			txtCongregacao.SelectAll();

		}

		#endregion // CONTROL FUNCTIONS --- END

		private void cmbRecorrenciaTipo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			cmbRecorrenciaTipo.DataBindings["SelectedValue"].WriteValue();
			propRecorrenciaTipo = _reuniao.RecorrenciaTipo;
		}

		// RECORRENCIA TIPO, TO CHANGE TEXTBOXES AND LABELS
		//------------------------------------------------------------------------------------------------------------
		public int propRecorrenciaTipo
		{
			get => _RecorrenciaTipo;
			set
			{
				_RecorrenciaTipo = value;

				switch (_RecorrenciaTipo)
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
					lbl.ForeColor = ctrl.Enabled ? Color.Black : Color.Gainsboro;
				};

				ChangeLblColor(cmbRecorrenciaDia, lblDia);
				ChangeLblColor(cmbRecorrenciaMes, lblMes);
				ChangeLblColor(cmbRecorrenciaSemana, lblSemana);
			}
		}

		private void lblRecorrenciaTexto_TextChanged(object sender, EventArgs e)
		{
			ResizeFontLabel(lblRecorrenciaTexto);
		}
	}
}
