﻿using CamadaBLL;
using CamadaDTO;
using ComponentOwl.BetterListView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.Saidas
{
	public partial class frmProvisorioComprador : CamadaUI.Modals.frmModFinBorder
	{
		private List<string> lstAutorizante = new List<string>();
		private Form _formOrigem;
		public string propEscolha { get; set; } //--- PROPRIEDADE DE ESCOLHA

		#region NEW | OPEN FUNCTIONS

		public frmProvisorioComprador(Form formOrigem, string DefaultID = null)
		{
			InitializeComponent();

			_formOrigem = formOrigem;

			//--- Add any initialization after the InitializeComponent() call.
			ObterDados(this, new EventArgs());

			//--- Handlers
			HandlerKeyDownControl(this);

			//--- Select Default item
			FindSelectDefautID(DefaultID);

			lstItens.PreviewKeyDown += (a, e) => e.IsInputKey = true;
			this.PreviewKeyDown += (a, e) => e.IsInputKey = true;
		}

		// GET DATA
		//------------------------------------------------------------------------------------------------------------
		private void ObterDados(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				lstAutorizante = new DespesaProvisoriaBLL().GetAutorizanteList();
				PreencheListagem();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter os Dados da listagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private void PreencheListagem()
		{
			lstItens.DataSource = lstAutorizante;
			FormataListagem();
		}

		// FIND AND SELECT IN LIST PROVIDED DEFAULT ID 
		//------------------------------------------------------------------------------------------------------------
		private void FindSelectDefautID(string DefaultID)
		{
			if (DefaultID != null)
			{
				foreach (BetterListViewItem item in lstItens)
				{
					if (item.Text == DefaultID)
					{
						item.Selected = true;
						propEscolha = GetSelectedItem();
					}
					else
					{
						item.Selected = false;
					}
				}
			}
			else
			{
				if (lstItens.Items.Count > 0)
				{
					lstItens.Items[0].Selected = true;
				}
			}
		}

		#endregion

		#region LIST FUNCTIONS

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagem()
		{

			lstItens.MultiSelect = false;
			lstItens.HideSelection = false;

			clnComprador.DisplayMember = "Autorizante";
			clnComprador.ValueMember = "Autorizante";

			lstItens.SearchSettings = new BetterListViewSearchSettings(BetterListViewSearchMode.PrefixOrSubstring,
																	   BetterListViewSearchOptions.UpdateSearchHighlight,
																	   new int[] { 0 });
		}

		// DESIGN HEADER STYLE
		//------------------------------------------------------------------------------------------------------------
		private void lstItens_DrawColumnHeader(object sender, BetterListViewDrawColumnHeaderEventArgs eventArgs)
		{
			if (eventArgs.ColumnHeaderBounds.BoundsOuter.Width > 0 && eventArgs.ColumnHeaderBounds.BoundsOuter.Height > 0)
			{
				Brush brush = new LinearGradientBrush(
					eventArgs.ColumnHeaderBounds.BoundsOuter,
					Color.Transparent,
					Color.FromArgb(64, Color.SteelBlue),
					LinearGradientMode.Vertical
				);

				eventArgs.Graphics.FillRectangle(brush, eventArgs.ColumnHeaderBounds.BoundsOuter);
				brush.Dispose();
			}
		}

		// FORMAT ITENS ID NUMBER
		//------------------------------------------------------------------------------------------------------------
		private void lstItens_DrawItem(object sender, BetterListViewDrawItemEventArgs eventArgs)
		{
			if (int.TryParse(eventArgs.Item.Text, out int intValue))
			{
				eventArgs.Item.Text = $"{intValue: 00}";
			}
		}

		// HANDLER ITEM ACTIVATE TO BTN ESCOLHER
		//------------------------------------------------------------------------------------------------------------
		private void lstItens_ItemActivate(object sender, BetterListViewItemActivateEventArgs eventArgs)
		{
			btnEscolher_Click(sender, new EventArgs());
		}

		#endregion

		#region BUTTONS FUNCTION

		private void btnFechar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnEscolher_Click(object sender, EventArgs e)
		{
			string item = GetSelectedItem();

			//--- check selected item
			if (item == null)
			{
				AbrirDialog("Favor selecionar um registro para Escolher...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- open edit form
			propEscolha = item;
			DialogResult = DialogResult.OK;
		}

		private string GetSelectedItem()
		{
			if (lstItens.SelectedItems.Count == 0) return null;

			string IDSelected = lstItens.SelectedItems[0].Value.ToString();
			return lstAutorizante.First(s => s == IDSelected);
		}

		#endregion

		#region CONTROLS FUNCTION

		// ESC TO CLOSE || KEYDOWN TO DOWNLIST || KEYUP TO UPLIST
		//------------------------------------------------------------------------------------------------------------
		private void form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) // CLOSE FORM
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
			// UP SELECTED ITEM IN LIST
			else if (e.KeyCode == Keys.Up && ActiveControl.GetType().BaseType.Name != "ComboBox")
			{
				e.Handled = true;

				if (lstItens.Items.Count > 0)
				{
					if (lstItens.SelectedItems.Count > 0)
					{
						int i = lstItens.SelectedItems[0].Index;
						lstItens.Items[i].Selected = false;

						if (i == 0) lstItens.Items[lstItens.Items.Count - 1].Selected = true;
						else lstItens.Items[i - 1].Selected = true;
					}
					else
					{
						lstItens.Items[0].Selected = true;
					}

					lstItens.EnsureVisible(lstItens.SelectedItems[0]);
				}
			}
			// DOWN SELECTED ITEM IN LIST
			else if (e.KeyCode == Keys.Down && ActiveControl.GetType().BaseType.Name != "ComboBox")
			{
				e.Handled = true;

				if (lstItens.Items.Count > 0)
				{
					if (lstItens.SelectedItems.Count > 0)
					{
						int i = lstItens.SelectedItems[0].Index;
						lstItens.Items[i].Selected = false;
						if (i == lstItens.Items.Count - 1) i = -1;
						lstItens.Items[i + 1].Selected = true;
					}
					else
					{
						lstItens.Items[0].Selected = true;
					}

					lstItens.EnsureVisible(lstItens.SelectedItems[0]);
				}
			}
			else if (e.KeyCode == Keys.Delete) // CLEAR PROCURA
			{
				txtProcura.Clear();
			}
			else if (e.KeyCode == Keys.Back) // BACKSPACE LAST WORD IN PROCURA
			{
				int len = txtProcura.Text.Length;
				if (txtProcura.Text.Length > 0)
				{
					txtProcura.Text = txtProcura.Text.Substring(0, len - 1);
				}
			}
		}

		// CREATE SHORTCUT TO TEXTBOX LIST VALUES
		//------------------------------------------------------------------------------------------------------------
		private void Form_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar))
			{
				e.Handled = true;
				txtProcura.Text += e.KeyChar;
			}
		}

		#endregion // CONTROLS FUNCTION --- END

		#region PROCURA BY TEXT

		private void txtProcura_TextChanged(object sender, EventArgs e)
		{
			ProcurarTexto();
			BetterListViewItemCollection itemsFound = new BetterListViewItemCollection();

			if (txtProcura.Text.Length > 0)
			{
				itemsFound = lstItens.FindItemsWithText(txtProcura.Text);
			}
			else
			{
				lstItens.FindItemsWithText("?");
				lstItens.SelectedItems.Clear();
			}
		}

		private void ProcurarTexto()
		{
			if (txtProcura.TextLength > 0)
			{
				// declare function
				Func<string, bool> FiltroItem = c => c.ToLower().Contains(txtProcura.Text.ToLower());

				// aply filter using function
				lstItens.DataSource = lstAutorizante.FindAll(c => FiltroItem(c));
			}
			else
			{
				lstItens.DataSource = lstAutorizante;
			}
		}

		#endregion // PROCURA BY TEXT --- END

		#region DESIGN FORM FUNCTIONS

		private void frmProvisorioComprador_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmProvisorioComprador_FormClosed(object sender, FormClosedEventArgs e)
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
