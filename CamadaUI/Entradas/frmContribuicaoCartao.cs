using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Entradas
{
	public partial class frmContribuicaoCartao : CamadaUI.Modals.frmModFinBorder
	{
		private objContribuicaoCartao _cartao;
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objCartaoOperadora> listOperadoras;
		private List<objCartaoBandeira> listBandeiras;

		private Form _formOrigem;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuicaoCartao(ref objContribuicaoCartao obj, Form formOrigem)
		{
			InitializeComponent();

			_cartao = obj;
			_formOrigem = formOrigem;
			GetOperadorasList();
			GetBandeirasList();

			// binding
			bind.DataSource = typeof(objContribuicaoCartao);
			bind.Add(_cartao);
			BindingCreator();

			if (_cartao.IDContribuicao == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

			// handlers
			_cartao.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
		}

		// GET LIST OF OPERADORA E BANDEIRA
		//------------------------------------------------------------------------------------------------------------
		private void GetOperadorasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var cartaoBLL = new CartaoBLL();
				listOperadoras = cartaoBLL.GetCartaoOperadora();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de operadoras..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void GetBandeirasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var cartaoBLL = new CartaoBLL();
				listBandeiras = cartaoBLL.GetCartaoBandeiras();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de bandeiras de cartão..." + "\n" +
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
						btnOK.Enabled = false;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Fechar";
						break;
					case EnumFlagEstado.Alterado:
						btnOK.Enabled = true;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Cancelar";
						break;
					case EnumFlagEstado.NovoRegistro:
						btnOK.Enabled = true;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Cancelar";
						break;
					case EnumFlagEstado.RegistroBloqueado:
						btnOK.Enabled = false;
						btnCancelar.Enabled = true;
						btnCancelar.Text = "Fechar";
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
			lblID.DataBindings.Add("Text", bind, "IDContribuicao", true);
			txtCartaoTipo.DataBindings.Add("Text", bind, "CartaoTipoDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCartaoBandeira.DataBindings.Add("Text", bind, "CartaoBandeira", true, DataSourceUpdateMode.OnPropertyChanged);
			txtCartaoOperadora.DataBindings.Add("Text", bind, "CartaoOperadora", true, DataSourceUpdateMode.OnPropertyChanged);
			numParcelas.DataBindings.Add("Value", bind, "Parcelas", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
		}


		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void Format00(object sender, ConvertEventArgs e)
		{
			if (e.Value != null)
			{
				((byte)e.Value).ToString("D2");
			}
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}
		}

		#endregion

		#region BUTTONS

		// FECHAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
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
					txtCartaoBandeira, txtCartaoTipo, txtCartaoOperadora
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
					case "txtCartaoTipo":
						btnSetCartaoTipo_Click(sender, new EventArgs());
						break;
					case "txtCartaoOperadora":
						btnSetOperadora_Click(sender, new EventArgs());
						break;
					case "txtCartaoBandeira":
						btnSetBandeira_Click(sender, new EventArgs());
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
					case "txtCartaoTipo":
						break;
					case "txtCartaoOperadora":
						break;
					case "txtCartaoBandeira":
						break;
					default:
						break;
				}
			}
			else
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtCartaoTipo,
					txtCartaoOperadora,
					txtCartaoBandeira, };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region BUTTONS PROCURA

		// OPEN LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetCartaoTipo_Click(object sender, EventArgs e)
		{
			var dic = new Dictionary<int, string>();
			dic.Add(1, "Débito");
			dic.Add(2, "Crédito");
			dic.Add(3, "Parcelado");

			// seleciona o TextBox
			TextBox textBox = txtCartaoTipo;

			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _cartao.CartaoTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_cartao.CartaoTipo = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetOperadora_Click(object sender, EventArgs e)
		{
			if (listOperadoras.Count == 0)
			{
				AbrirDialog("Não há Operadoras de Cartão cadastradas...", "Operadoras",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listOperadoras.ToDictionary(x => (int)x.IDCartaoOperadora, x => x.CartaoOperadora);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtCartaoOperadora, _cartao.IDCartaoOperadora);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_cartao.IDCartaoOperadora = (byte)frm.propEscolha.Key;
				txtCartaoOperadora.Text = frm.propEscolha.Value;
			}

			//--- select
			txtCartaoOperadora.Focus();
			txtCartaoOperadora.SelectAll();
		}

		private void btnSetBandeira_Click(object sender, EventArgs e)
		{
			if (listBandeiras.Count == 0)
			{
				AbrirDialog("Não há Bandeiras de Cartão cadastradas...", "Bandeiras",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			// seleciona o TextBox
			TextBox textBox = txtCartaoBandeira;

			var dic = listBandeiras.ToDictionary(x => (int)x.IDCartaoBandeira, x => x.CartaoBandeira);

			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _cartao.IDCartaoBandeira);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_cartao.IDCartaoBandeira = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
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

	}
}
