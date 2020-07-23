using CamadaBLL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.Utilidades;

namespace CamadaUI.APagar
{
	public partial class frmAcrescimoMotivo : CamadaUI.Modals.frmModFinBorder
	{
		public objAcrescimoMotivo _motivo;
		private List<objAcrescimoMotivo> listMotivos;
		private Form _formOrigem;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmAcrescimoMotivo(objAcrescimoMotivo motivo, Form formOrigem)
		{
			InitializeComponent();
			_motivo = motivo;
			_formOrigem = formOrigem;
			GetMotivosList();
			HandlerKeyDownControl(this);
		}

		// GET LIST OF MOTIVOS
		//------------------------------------------------------------------------------------------------------------
		private void GetMotivosList()
		{
			try
			{
				if (listMotivos != null) return;

				listMotivos = new List<objAcrescimoMotivo>();

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				listMotivos = new APagarBLL().GetListMotivo(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Motivos de Acréscimo..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion

		#region BUTTONS

		// CONFIRM OK BUTTON
		//------------------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			//--- check data
			if (!CheckSaveData()) return;

			DialogResult = DialogResult.OK;
		}

		// CHECK INSERTED DATA
		//------------------------------------------------------------------------------------------------------------
		private bool CheckSaveData()
		{
			if (_motivo.IDAcrescimoMotivo == null) return false;
			if (string.IsNullOrEmpty(_motivo.AcrescimoMotivo)) return false;

			return true;
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
					txtAcrescimoMotivo
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
			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtAcrescimoMotivo":
						btnSetMotivo_Click(sender, new EventArgs());
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
				Control[] controlesBloqueados = {
					txtAcrescimoMotivo,
				};

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
		private void btnSetMotivo_Click(object sender, EventArgs e)
		{
			if (listMotivos == null || listMotivos.Count == 0)
			{
				AbrirDialog("Não há Motivos de Acréscimo cadastrados...", "Motivos de Acréscimo",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listMotivos.ToDictionary(x => (int)x.IDAcrescimoMotivo, x => x.AcrescimoMotivo);

			Main.frmComboLista frm = new Main.frmComboLista(dic, txtAcrescimoMotivo, _motivo.IDAcrescimoMotivo);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_motivo.IDAcrescimoMotivo = (byte)frm.propEscolha.Key;
				_motivo.AcrescimoMotivo = frm.propEscolha.Value;
				txtAcrescimoMotivo.Text = frm.propEscolha.Value;
			}

			//--- select
			txtAcrescimoMotivo.Focus();
			txtAcrescimoMotivo.SelectAll();
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
