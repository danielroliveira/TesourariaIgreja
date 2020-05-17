using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using static CamadaUI.FuncoesGlobais;
using CamadaUI.Setores;
using CamadaUI.Registres;

namespace CamadaUI.Saidas
{
	public partial class frmDespesa : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesa _despesa;
		private DespesaBLL despDLL = new DespesaBLL();
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objDespesaDocumentoTipo> listDocTipos;
		private objSetor setorSelected;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		public frmDespesa(objDespesa despesa)
		{
			InitializeComponent();

			_despesa = despesa;
			GetDocTipos();

			// Define Conta and Setor padrao
			frmPrincipal principal = Application.OpenForms.OfType<frmPrincipal>().First();
			setorSelected = principal.propSetorPadrao;

			// binding
			bind.DataSource = typeof(objDespesa);
			bind.Add(_despesa);
			BindingCreator();

			propParcelado = _despesa.Parcelas > 1;

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

			// handlers
			_despesa.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
		}

		private void frmDespesa_Shown(object sender, EventArgs e)
		{
			txtSetor.Enter += text_Enter;
			txtCredor.Enter += text_Enter;
			txtDespesaTipo.Enter += text_Enter;
			txtDocumentoTipo.Enter += text_Enter;
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
				btnSetDocumentoTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetCredor.Enabled = value == EnumFlagEstado.NovoRegistro;
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

				listDocTipos = despDLL.GetDespesaDocumentoTipos();
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

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtDespesaValor.DataBindings["Text"].Format += FormatCurrency;
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

		private void btnNovo_Click(object sender, EventArgs e)
		{

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

		#region SAVE

		#endregion // SAVE --- END

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
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCredor":
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = {
					txtDocumentoTipo,
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
		private void txt_KeyDown_Block(object sender, KeyEventArgs e)
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

		private void chkParcelado_CheckedChanged(object sender, EventArgs e)
		{
			propParcelado = chkParcelado.Checked;
		}

		public bool propParcelado
		{
			get
			{
				return _despesa.Parcelas > 1;
			}
			set
			{
				bool _parcelado = _despesa.Parcelas > 1;

				if (value != _parcelado)
				{
					numParcelas.Enabled = value;
					lblParcelas.ForeColor = value == true ? Color.Black : Color.WhiteSmoke;
					btnParcelasGerar.Enabled = value;

					if (value == true)
					{
						_despesa.Parcelas = 2;
					}
					else
					{
						_despesa.Parcelas = 1;
					}
				}

			}
		}

	}
}
