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

namespace CamadaUI.Saidas
{
	public partial class frmDespesa : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesa _despesa;
		private DespesaBLL despDLL = new DespesaBLL();
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objDespesaDocumentoTipo> listDocTipos;
		private objConta contaSelected;
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
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Tipos e Formas..." + "\n" +
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
			lblID.DataBindings.Add("Text", bind, "IDContribuicao", true);
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
			Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{

		}

		#endregion // BUTTONS --- END

		#region BUTTONS PROCURA

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
					txtEntradaForma,
					txtCampanha,
					txtConta,
					txtContribuinte,
					txtContribuicaoTipo,
					txtReuniao,
					txtSetor,
					txtDespesaDescricao
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
					case "txtEntradaForma":

						if (listFormas.Count > 0)
						{
							var forma = listFormas.FirstOrDefault(x => x.IDEntradaForma == int.Parse(e.KeyChar.ToString()));

							if (forma == null) return;

							if (forma.IDEntradaForma != _contribuicao.IDEntradaForma)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_contribuicao.IDEntradaForma = (byte)forma.IDEntradaForma;
								txtEntradaForma.Text = forma.EntradaForma;
							}

						}
						break;

					case "txtContribuicaoTipo":

						if (listTipos.Count > 0)
						{
							var tipo = listTipos.FirstOrDefault(x => x.IDContribuicaoTipo == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDContribuicaoTipo != _contribuicao.IDContribuicaoTipo)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_contribuicao.IDContribuicaoTipo = (byte)tipo.IDContribuicaoTipo;
								propContribuicaoTipo = _contribuicao.IDContribuicaoTipo;
								txtContribuicaoTipo.Text = tipo.ContribuicaoTipo;
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

			txtDespesaDescricao.Text = descricao;
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void cmbEntradaMes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				cmbEntradaMes.SelectedValue = _contribuicao.EntradaMes;
			}
		}

		// PREVINE BLOCK CHANGES IN SIT => REGISTRO SALVO
		private void txt_KeyDown_Block(object sender, KeyEventArgs e)
		{

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


	}
}
