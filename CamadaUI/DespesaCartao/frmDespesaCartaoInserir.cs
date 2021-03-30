using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.DespesaCartao
{
	public partial class frmDespesaCartaoInserir : CamadaUI.Modals.frmModFinBorder
	{
		private objAPagarCartao _CartaoSelected;
		private List<objAPagarCartao> ListCartao;
		private Form _formOrigem;
		private DespesaCartaoBLL dBLL = new DespesaCartaoBLL();
		private objDespesaCartao _LastDespesa;

		#region SUB NEW | CONSTRUCTOR

		public frmDespesaCartaoInserir(Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			CarregaComboMes();
			ObterDadosCartao();

			// HANDLER to use TAB for ENTER
			HandlerKeyDownControl(this);
			numRefDia.KeyDown += Numeric_KeyDown;
			numRefAno.KeyDown += Numeric_KeyDown;
			numRefDia.Enter += Numeric_Enter;
			numRefAno.Enter += Numeric_Enter;
		}

		private void ObterDadosLastDespesa()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- Check Conta
				if (_CartaoSelected == null)
				{
					AbrirDialog("Favor selecionar o Cartao de Crédito...", "Cartão Selecionado");
					txtCartaoDescricao.Focus();
				}

				_LastDespesa = dBLL.GetLastDespesaCartaoByCartao((int)_CartaoSelected.IDCartaoCredito);

				if (_LastDespesa == null)
				{
					cmbRefMes.SelectedValue = DateTime.Today.Month;
					numRefAno.Value = DateTime.Today.Year;
				}
				else
				{
					cmbRefMes.SelectedValue = _LastDespesa.ReferenciaData.AddMonths(1).Month;
					numRefAno.Value = _LastDespesa.ReferenciaData.AddMonths(1).Year;
				}

				btnEfetuar.Enabled = true;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter as informações de Cartão de Crédito..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				btnEfetuar.Enabled = false;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void ObterDadosCartao()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				ListCartao = new APagarCartaoBLL().GetCartaoCreditoDespesaList();

				if (ListCartao.Count == 0)
				{
					AbrirDialog("Não há Cartões de Crédito Cadastrados para realização de Despesas...\n" +
						"Favor Comunicar com o adminstrador do sistema.", "Não há Cartões",
						DialogType.OK, DialogIcon.Exclamation);
					btnEfetuar.Enabled = false;
				}

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter Lista de Cartõe de Crédito..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void SetSelectedCartao(int IDCartao)
		{
			try
			{
				if (IDCartao == _CartaoSelected?.IDCartaoCredito) return;

				//--- define values
				_CartaoSelected = ListCartao.First(x => x.IDCartaoCredito == IDCartao);
				txtCartaoDescricao.Text = _CartaoSelected.CartaoDescricao;
				numRefDia.Value = _CartaoSelected.VencimentoDia;

				//--- get last despesa
				ObterDadosLastDespesa();

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Selecionar o Cartão..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
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
			cmbRefMes.DataSource = dtMeses;
			cmbRefMes.ValueMember = "ID";
			cmbRefMes.DisplayMember = "Mes";
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
			MostraMenuPrincipal();
		}

		private void btnEfetuar_Click(object sender, EventArgs e)
		{
			//--- CHECK LAST DESPESA
			if (_LastDespesa.IDSituacao != 2)
			{
				var resp = AbrirDialog("A última Despesa Reunida desse Cartão de Crédito ainda não foi Quitada...\n" +
					"Há necessidade de Quitar a ultima despesa antes de Criar uma nova Despesa.\n" +
					"Deseja abrir a última despesa de Cartão?",
					"Despesa não Quitada",
					DialogType.SIM_NAO,
					DialogIcon.Exclamation);

				if (resp != DialogResult.Yes) return;

				var frm = new frmDespesaCartao(_LastDespesa);
				frm.MdiParent = Application.OpenForms[0];
				Close();
				frm.Show();
				return;
			}

			//--- GET REF DATE
			if (!DateTime.TryParse($"{numRefDia.Value}/{cmbRefMes.SelectedValue}/{numRefAno.Value}", out DateTime _RefDate))
			{
				AbrirDialog("Data escolhida é inválida...\n" +
					"Favor selecionar uma data válida", "Data de Referência",
					DialogType.OK, DialogIcon.Exclamation);
				numRefDia.Focus();
			}

			//--- INSERT NEW DESPESA CARTAO
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				var dBLL = new DespesaCartaoBLL();
				var newDespCartao = dBLL.InsertDespesaCartao(_CartaoSelected, _RefDate);

				//--- open form
				var frm = new frmDespesaCartao(newDespCartao);
				frm.Show();

				Close();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Inserir o novo Caixa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		// OPEN PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetCartao_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				if (ListCartao.Count == 0)
				{
					AbrirDialog("Não há Cartão de Crédito cadastrados ou ativos...", "Cartão de Crédito",
						DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				var dic = ListCartao.ToDictionary(x => (int)x.IDCartaoCredito, x => x.CartaoDescricao);
				var textBox = txtCartaoDescricao;
				Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _CartaoSelected?.IDCartaoCredito);

				// show form
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					SetSelectedCartao(frm.propEscolha.Key);
				}

				//--- select
				textBox.Focus();
				textBox.SelectAll();

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

		#endregion // BUTTONS FUNCTION --- END

		#region CONTROLS

		// CONTROLING NUMERIC UP/DOWN
		//------------------------------------------------------------------------------------------------------------
		private void Numeric_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			};
		}

		private void Numeric_Enter(object sender, EventArgs e)
		{
			((NumericUpDown)sender).Select(0, 4);
		}

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					txtCartaoDescricao,
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtCartaoDescricao":
						btnSetCartao_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = { txtCartaoDescricao };

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
				Control[] controlesBloqueados = { txtCartaoDescricao, };

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
					case "txtCartaoDescricao":

						if (ListCartao.Count > 0)
						{
							var cartao = ListCartao.FirstOrDefault(x => x.IDCartaoCredito == int.Parse(e.KeyChar.ToString()));

							if (cartao == null) return;
							SetSelectedCartao((int)cartao.IDCartaoCredito);
						}

						break;

					default:
						break;
				}
			}
		}

		#endregion // CONTROLS --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;

			}
		}

		// CONTROLA TOOLTIP
		//------------------------------------------------------------------------------------------------------------
		private void ShowToolTip(Control control)
		{
			//--- Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip();

			//--- Define o delay para a ToolTip.
			toolTip1.AutoPopDelay = 2000;
			toolTip1.InitialDelay = 2000;
			toolTip1.ReshowDelay = 500;
			toolTip1.IsBalloon = true;
			toolTip1.UseAnimation = true;
			toolTip1.UseFading = true;

			if (string.IsNullOrEmpty(control.Tag.ToString()))
				toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000);
			else
				toolTip1.Show(control.Tag.ToString(), control, control.Width - 30, -40, 2000);
		}

		private void btnProcurar_EnabledChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;

			if (control.Enabled == true)
				ShowToolTip(control);
		}






		#endregion // DESIGN FORM FUNCTIONS --- END

	}
}
