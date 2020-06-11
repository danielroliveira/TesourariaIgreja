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

namespace CamadaUI.Entradas
{
	public partial class frmContribuicaoCartao : CamadaUI.Modals.frmModFinBorder
	{
		private objContribuicaoCartao _cartao;
		private CartaoBLL cBLL = new CartaoBLL();
		private BindingSource bind = new BindingSource();
		private EnumFlagEstado _Sit;

		private List<objCartaoOperadora> listOperadoras;
		private List<objCartaoBandeira> listBandeiras;
		private Dictionary<int, string> dicTipo = new Dictionary<int, string>();

		private Form _formOrigem;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContribuicaoCartao(ref objContribuicaoCartao cartao, Form formOrigem)
		{
			InitializeComponent();

			if (cartao.IDContribuicao != null)
			{
				_cartao = GetCartao((long)cartao.IDContribuicao);
			}
			else
			{
				_cartao = cartao;
			}

			_formOrigem = formOrigem;
			GetOperadorasList();
			GetBandeirasList();
			PreencheDictionary();

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

		// GET CONTRIBUICAO CARTAO
		//------------------------------------------------------------------------------------------------------------
		private objContribuicaoCartao GetCartao(long IDContribuicao)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				return new ContribuicaoBLL().GetContribuicaoCartao(IDContribuicao);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter os dados do Cartão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET LIST OF OPERADORA E BANDEIRA
		//------------------------------------------------------------------------------------------------------------
		private void GetOperadorasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listOperadoras = cBLL.GetCartaoOperadora();
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

				listBandeiras = cBLL.GetCartaoBandeiras();
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

		private void PreencheDictionary()
		{
			dicTipo.Add(1, "Débito");
			dicTipo.Add(2, "Crédito");
			dicTipo.Add(3, "Parcelado");
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
					btnOK.Enabled = true;
					btnCancelar.Enabled = true;
					btnCancelar.Text = "Cancelar";
					lblSitBlock.Visible = false;
				}
				else
				{
					btnOK.Enabled = false;
					btnCancelar.Enabled = true;
					btnCancelar.Text = "Fechar";
					lblSitBlock.Visible = true;
				}

				// btnSET
				btnSetCartaoTipo.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetBandeira.Enabled = value == EnumFlagEstado.NovoRegistro;
				btnSetOperadora.Enabled = value == EnumFlagEstado.NovoRegistro;
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

			EP.Clear();
		}

		#endregion

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			//--- check data
			if (!CheckSaveData())
			{
				txtCartaoTipo.Focus();
				return;
			}

			//--- save and close
			bind.EndEdit();
			DialogResult = DialogResult.OK;
		}

		// CHECK INSERTED DATA
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (!VerificaDadosClasse(txtCartaoTipo, "Tipo de Cartão", _cartao, EP)) return false;
			if (!VerificaDadosClasse(txtCartaoOperadora, "Operadora de Crédito", _cartao, EP)) return false;
			if (!VerificaDadosClasse(txtCartaoBandeira, "Bandeira do Cartão", _cartao, EP)) return false;

			// get taxa
			if (!GetAndCheckTaxa()) return false;

			return true;
		}

		// CHECK CARTAO OPERADORA TAXAS
		//------------------------------------------------------------------------------------------------------------
		private bool GetAndCheckTaxa()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objCartaoTaxa taxa = cBLL.GetCartaoTaxa(_cartao.IDCartaoOperadora, _cartao.IDCartaoBandeira);

				// CHECK TAXA
				if (taxa == null)
				{
					AbrirDialog("Não há configuração de TAXA para essa operadora e/ou bandeira...",
						"Configurar Taxa", DialogType.OK, DialogIcon.Exclamation);
					return false;
				}

				// DEFINE TAXA with PARCELAS
				if (_cartao.CartaoTipo == 1) // DEBITO
				{
					if (taxa.TaxaDebito == null)
					{
						AbrirDialog("Não há configuração de TAXA de DÉBITO para essa operadora e bandeira...",
							"Configurar Taxa", DialogType.OK, DialogIcon.Exclamation);
						return false;
					}

					_cartao.TaxaAplicada = (decimal)taxa.TaxaDebito;
				}
				else if (_cartao.CartaoTipo == 2) // CREDITO
				{
					if (taxa.TaxaCredito == null)
					{
						AbrirDialog("Não há configuração de TAXA de CRÉDITO para essa operadora e bandeira...",
							"Configurar Taxa", DialogType.OK, DialogIcon.Exclamation);
						return false;
					}

					_cartao.TaxaAplicada = (decimal)taxa.TaxaCredito;
				}
				else if (_cartao.CartaoTipo == 3) // PARCELADO
				{
					decimal? taxaAplicada = null;

					switch (_cartao.Parcelas)
					{
						case 2:
							taxaAplicada = taxa.Taxa2;
							break;
						case 3:
							taxaAplicada = taxa.Taxa3;
							break;
						case 4:
							taxaAplicada = taxa.Taxa4;
							break;
						case 5:
							taxaAplicada = taxa.Taxa5;
							break;
						case 6:
							taxaAplicada = taxa.Taxa6;
							break;
						case 7:
							taxaAplicada = taxa.Taxa7;
							break;
						case 8:
							taxaAplicada = taxa.Taxa8;
							break;
						case 9:
							taxaAplicada = taxa.Taxa9;
							break;
						case 10:
							taxaAplicada = taxa.Taxa10;
							break;
						case 11:
							taxaAplicada = taxa.Taxa11;
							break;
						case 12:
							taxaAplicada = taxa.Taxa12;
							break;
						default:
							break;
					}

					if (taxaAplicada == null)
					{
						AbrirDialog($"Não há configuração de TAXA de PARCELAMENTO em {_cartao.Parcelas} " +
							"vezes para essa operadora e bandeira...",
							"Configurar Taxa",
							DialogType.OK,
							DialogIcon.Exclamation);
						return false;
					}

					_cartao.TaxaAplicada = (decimal)taxaAplicada;
				}

				// DEFINE PRAZO
				if (_cartao.CartaoTipo == 1) // DEBITO
				{
					_cartao.Prazo = taxa.PrazoDebito;
				}
				else // CREDITO OU PARCELADO
				{
					_cartao.Prazo = taxa.PrazoCredito;
				}

				// DEFINE CONTA PROVISORIA
				_cartao.IDContaProvisoria = taxa.IDContaProvisoria;

				return true;

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter as taxas do cartão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

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
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}

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
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtCartaoTipo,
					txtCartaoOperadora,
					txtCartaoBandeira
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
					case "txtCartaoTipo":

						if (dicTipo.Count > 0)
						{
							if (dicTipo.ContainsKey(byte.Parse(e.KeyChar.ToString())))
							{
								var tipo = dicTipo.FirstOrDefault(x => x.Key == byte.Parse(e.KeyChar.ToString()));

								if (tipo.Key != _cartao.CartaoTipo)
								{
									if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

									_cartao.CartaoTipo = (byte)tipo.Key;
									txtCartaoTipo.Text = tipo.Value;

									CartaoTipoUpdate();
								}
							}
						}
						break;

					case "txtCartaoOperadora":

						if (listOperadoras.Count > 0)
						{
							var tipo = listOperadoras.FirstOrDefault(x => x.IDCartaoOperadora == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDCartaoOperadora != _cartao.IDCartaoOperadora)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_cartao.IDCartaoOperadora = (byte)tipo.IDCartaoOperadora;
								txtCartaoOperadora.Text = tipo.CartaoOperadora;
							}
						}
						break;

					case "txtCartaoBandeira":

						if (listBandeiras.Count > 0)
						{
							var tipo = listBandeiras.FirstOrDefault(x => x.IDCartaoBandeira == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDCartaoBandeira != _cartao.IDCartaoBandeira)
							{
								if (Sit == EnumFlagEstado.RegistroSalvo) Sit = EnumFlagEstado.Alterado;

								_cartao.IDCartaoBandeira = (int)tipo.IDCartaoBandeira;
								txtCartaoBandeira.Text = tipo.CartaoBandeira;
							}
						}
						break;
					default:
						break;
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

		#region BUTTONS PROCURA

		// OPEN LIST
		//------------------------------------------------------------------------------------------------------------
		private void btnSetCartaoTipo_Click(object sender, EventArgs e)
		{
			// seleciona o TextBox
			TextBox textBox = txtCartaoTipo;

			Main.frmComboLista frm = new Main.frmComboLista(dicTipo, textBox, _cartao.CartaoTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_cartao.CartaoTipo = (byte)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
				CartaoTipoUpdate();
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		// ENABLE | DISABLE numParcelas to CartaoTipo
		//------------------------------------------------------------------------------------------------------------
		private void CartaoTipoUpdate()
		{
			// enable disable numeric parcelas
			switch (_cartao.CartaoTipo)
			{
				case 1: // debito
					numParcelas.Enabled = false;
					numParcelas.Minimum = 0;
					numParcelas.Value = 0;
					break;
				case 2: // credito
					numParcelas.Enabled = false;
					numParcelas.Minimum = 1;
					numParcelas.Value = 1;
					break;
				case 3: // parcelado
					numParcelas.Enabled = true;
					numParcelas.Minimum = 2;
					numParcelas.Value = 2;
					break;
				default:
					break;
			}

			lblParcelas.ForeColor = numParcelas.Enabled ? Color.Black : Color.Silver;
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
