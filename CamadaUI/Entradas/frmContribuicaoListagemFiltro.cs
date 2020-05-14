﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using CamadaUI.Contas;
using CamadaUI.Setores;
using static CamadaUI.Utilidades;
using System.Linq;
using CamadaUI.Registres;
using System.Drawing;

namespace CamadaUI.Entradas
{
	public partial class frmContribuicaoListagemFiltro : CamadaUI.Modals.frmModFinBorder
	{
		private bool _Alterado = false;
		private frmContribuicaoListagem _formOrigem;
		private List<objContribuicaoTipo> listTipos;
		private List<objEntradaForma> listFormas;

		private frmContribuicaoListagem.StructPesquisa DadosNovos = new frmContribuicaoListagem.StructPesquisa();

		#region SUB NEW | CONSTRUCTOR

		public frmContribuicaoListagemFiltro(frmContribuicaoListagem formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			DadosNovos = _formOrigem.Dados;

			// GET TIPO AND FORMAS LIST
			GetTiposAndFormas();

			// LOAD VALUES
			txtConta.Text = DadosNovos.Conta;
			txtSetor.Text = DadosNovos.Setor;
			txtContribuicaoTipo.Text = DadosNovos.Tipo;
			txtEntradaForma.Text = DadosNovos.Forma;
			txtContribuinte.Text = DadosNovos.Contribuinte;
			txtCampanha.Text = DadosNovos.Campanha;

			// ADD HANDLERS
			txtConta.KeyDown += Control_KeyDown;
			txtSetor.KeyDown += Control_KeyDown;
			txtContribuicaoTipo.KeyDown += Control_KeyDown;
			txtEntradaForma.KeyDown += Control_KeyDown;
			txtCampanha.KeyDown += Control_KeyDown;
			txtContribuinte.KeyDown += Control_KeyDown;

			txtConta.Enter += Control_Enter;
			txtSetor.Enter += Control_Enter;
			txtContribuicaoTipo.Enter += Control_Enter;
			txtEntradaForma.Enter += Control_Enter;
			txtCampanha.Enter += Control_Enter;
			txtContribuinte.Enter += Control_Enter;

			txtEntradaForma.KeyPress += Control_KeyPress;
			txtContribuicaoTipo.KeyPress += Control_KeyPress;

			HandlerKeyDownControl(this);

		}

		// GET LIST OF ENTRADA FORMAS AND TIPOS
		//------------------------------------------------------------------------------------------------------------
		private void GetTiposAndFormas()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				EntradaBLL entradaBLL = new EntradaBLL();
				ContribuicaoBLL contribuicaoBLL = new ContribuicaoBLL();
				listFormas = entradaBLL.GetEntradaFormasList();
				listTipos = contribuicaoBLL.GetContribuicaoTiposList();

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

		public bool propAlterado
		{
			get => _Alterado;
			set
			{
				if (value != _Alterado)
				{
					ShowToolTip(btnProcurar);
				}

				_Alterado = value;
				btnProcurar.Enabled = value;
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region BUTTONS FUNCTION

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{
			txtEntradaForma.Clear();
			DadosNovos.IDForma = null;
			DadosNovos.Forma = null;

			txtContribuicaoTipo.Clear();
			DadosNovos.IDTipo = null;
			DadosNovos.Tipo = null;

			txtSetor.Clear();
			DadosNovos.IDSetor = null;
			DadosNovos.Setor = null;

			txtConta.Clear();
			DadosNovos.IDConta = null;
			DadosNovos.Conta = null;

			txtContribuinte.Clear();
			DadosNovos.IDContribuinte = null;
			DadosNovos.Contribuinte = null;

			txtCampanha.Clear();
			DadosNovos.IDCampanha = null;
			DadosNovos.Campanha = null;

			propAlterado = true;
		}

		// PROCURAR
		//------------------------------------------------------------------------------------------------------------
		private void btnProcurar_Click(object sender, EventArgs e)
		{
			_formOrigem.Dados = DadosNovos;
			DialogResult = DialogResult.Yes;
		}

		#endregion // BUTTONS FUNCTION --- END

		#region BUTTONS PROCURA

		// OPEN CONGREGACAO PROCURA FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnSetConta_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContaProcura frm = new frmContaProcura(this, DadosNovos.IDConta);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (DadosNovos.IDConta != (int)frm.propEscolha.IDConta) propAlterado = true;

					DadosNovos.IDConta = (int)frm.propEscolha.IDConta;
					DadosNovos.Conta = frm.propEscolha.Conta;
					txtConta.Text = frm.propEscolha.Conta;
				}

				//--- select
				txtConta.Focus();
				txtConta.SelectAll();
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

		private void btnSetEntradaForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Entradas cadastradas...", "Formas de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDEntradaForma, x => x.EntradaForma);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtEntradaForma, DadosNovos.IDForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				if (DadosNovos.IDForma != (byte)frm.propEscolha.Key) propAlterado = true;

				DadosNovos.IDForma = (byte)frm.propEscolha.Key;
				DadosNovos.Forma = frm.propEscolha.Value;
				txtEntradaForma.Text = frm.propEscolha.Value;
			}

			//--- select
			txtEntradaForma.Focus();
			txtEntradaForma.SelectAll();
		}

		private void btnSetContribuicaoTipo_Click(object sender, EventArgs e)
		{
			if (listFormas == null || listFormas.Count == 0)
			{
				AbrirDialog("Não há Tipos de Entrada cadastrados...", "Tipos de Entrada",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listTipos.ToDictionary(x => (int)x.IDContribuicaoTipo, x => x.ContribuicaoTipo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtContribuicaoTipo, DadosNovos.IDTipo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				if (DadosNovos.IDTipo != (byte)frm.propEscolha.Key) propAlterado = true;

				DadosNovos.IDTipo = (byte)frm.propEscolha.Key;
				DadosNovos.Tipo = frm.propEscolha.Value;
				txtContribuicaoTipo.Text = frm.propEscolha.Value;
			}

			//--- select
			txtContribuicaoTipo.Focus();
			txtContribuicaoTipo.SelectAll();
		}

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, DadosNovos.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (DadosNovos.IDSetor != (int)frm.propEscolha.IDSetor) propAlterado = true;

					DadosNovos.IDSetor = (int)frm.propEscolha.IDSetor;
					DadosNovos.Setor = frm.propEscolha.Setor;
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

		private void btnSetContribuinte_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmContribuinteListagem frm = new frmContribuinteListagem(true, this);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CONTRIBUINTE
				{
					if (DadosNovos.IDContribuinte != (int)frm.propEscolha.IDContribuinte) propAlterado = true;

					DadosNovos.IDContribuinte = (int)frm.propEscolha.IDContribuinte;
					DadosNovos.Contribuinte = frm.propEscolha.Contribuinte;
					txtContribuinte.Text = frm.propEscolha.Contribuinte;
				}

				//--- select
				txtContribuinte.Focus();
				txtContribuinte.SelectAll();
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

		private void btnSetCampanha_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmCampanhaProcura frm = new frmCampanhaProcura(this, DadosNovos.IDCampanha);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (DadosNovos.IDCampanha != (int)frm.propEscolha.IDCampanha) propAlterado = true;

					DadosNovos.IDCampanha = (int)frm.propEscolha.IDCampanha;
					DadosNovos.Campanha = frm.propEscolha.Campanha;
					txtCampanha.Text = frm.propEscolha.Campanha;
				}

				//--- select
				txtCampanha.Focus();
				txtCampanha.SelectAll();
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
					txtEntradaForma,
					txtConta,
					txtContribuicaoTipo,
					txtSetor,
					txtCampanha,
					txtContribuinte
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
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
					case "txtEntradaForma":
						btnSetEntradaForma_Click(sender, new EventArgs());
						break;
					case "txtContribuicaoTipo":
						btnSetContribuicaoTipo_Click(sender, new EventArgs());
						break;
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					case "txtConta":
						btnSetConta_Click(sender, new EventArgs());
						break;
					case "txtContribuinte":
						btnSetContribuinte_Click(sender, new EventArgs());
						break;
					case "txtCampanha":
						btnSetCampanha_Click(sender, new EventArgs());
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
					case "txtEntradaForma":
						txtEntradaForma.Clear();
						DadosNovos.IDForma = null;
						DadosNovos.Forma = null;
						break;
					case "txtContribuicaoTipo":
						txtContribuicaoTipo.Clear();
						DadosNovos.IDTipo = null;
						DadosNovos.Tipo = null;
						break;
					case "txtSetor":
						txtSetor.Clear();
						DadosNovos.IDSetor = null;
						DadosNovos.Setor = null;
						break;
					case "txtConta":
						txtConta.Clear();
						DadosNovos.IDConta = null;
						DadosNovos.Conta = null;
						break;
					case "txtContribuinte":
						txtContribuinte.Clear();
						DadosNovos.IDContribuinte = null;
						DadosNovos.Contribuinte = null;
						break;
					case "txtCampanha":
						txtCampanha.Clear();
						DadosNovos.IDCampanha = null;
						DadosNovos.Campanha = null;
						break;
					default:
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtEntradaForma,
					txtContribuicaoTipo };

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
					txtEntradaForma,
					txtConta,
					txtContribuicaoTipo,
					txtSetor, txtCampanha, txtContribuinte };

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
					case "txtEntradaForma":

						if (listFormas.Count > 0)
						{
							var forma = listFormas.FirstOrDefault(x => x.IDEntradaForma == int.Parse(e.KeyChar.ToString()));

							if (forma == null) return;

							if (forma.IDEntradaForma != DadosNovos.IDForma)
							{
								DadosNovos.IDForma = (byte)forma.IDEntradaForma;
								txtEntradaForma.Text = forma.EntradaForma;
								propAlterado = true;
							}

						}
						break;

					case "txtContribuicaoTipo":

						if (listTipos.Count > 0)
						{
							var tipo = listTipos.FirstOrDefault(x => x.IDContribuicaoTipo == int.Parse(e.KeyChar.ToString()));

							if (tipo == null) return;

							if (tipo.IDContribuicaoTipo != DadosNovos.IDTipo)
							{
								DadosNovos.IDTipo = (byte)tipo.IDContribuicaoTipo;
								txtContribuicaoTipo.Text = tipo.ContribuicaoTipo;
								propAlterado = true;
							}
						}
						break;

					default:
						break;
				}

			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region TOOLTIP

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void Control_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= Control_Enter;
		}

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

		#region DESIGN FORM FUNCTIONS

		private void frm_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frm_FormClosed(object sender, FormClosedEventArgs e)
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