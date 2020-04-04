using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CamadaUI
{
	public static class Utilidades
	{
		// MESSAGE DIALOG BOX
		// =============================================================================
		public static DialogResult AbrirDialog
			(string Message,
			string Title,
			DialogType Type = DialogType.OK,
			DialogIcon Icon = DialogIcon.Information,
			DialogDefaultButton DefaultButton = DialogDefaultButton.First)
		{
			using (main.frmMessage f = new main.frmMessage(Message, Title, Type, Icon, DefaultButton))
			{
				f.ShowDialog();
				return f.DialogResult;
			}
		}

		// VERIFY IS STRING CAN CHANGE TO NUMERIC
		// =============================================================================
		public static bool IsNumeric(this string text) => double.TryParse(text, out _);

		// RESIZE FONT SIZE LABEL TO FIT ALL TEXT
		// =============================================================================
		public static void ResizeFontLabel(Label myLabel)
		{
			Font lblFont = new Font(myLabel.Font.FontFamily, myLabel.Font.Size, myLabel.Font.Style);

			while (myLabel.Width < TextRenderer.MeasureText(myLabel.Text, lblFont).Width)
			{
				myLabel.Font = new Font(myLabel.Font.FontFamily, myLabel.Font.Size - 0.5F, myLabel.Font.Style);
				lblFont = new Font(myLabel.Font.FontFamily, myLabel.Font.Size, myLabel.Font.Style);
			}
		}

		// HANDLER DEFAULT FOR TEXTBOX ENTER => TAB
		// =============================================================================
		public static void HandlerKeyDownControl(Form form)
		{
			//--- Tipos de Controles
			List<Type> types = new List<Type>()
			{
				typeof(TextBox),
				typeof(ComboBox),
				typeof(MaskedTextBox)
			};

			//--- para cada TabPage no tabPrincipal
			foreach (Control control in form.Controls)
			{
				if (types.Contains(control.GetType()))
				{
					control.KeyDown += Control_KeyDown;
				}
			}
		}
		static void Control_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SendKeys.Send("{Tab}");
			};
		}

		// GET TEXT AND RETURN CNPJ OR CPF FORMAT STRING
		//=================================================================================================
		public static string CNPConvert(string CNP)
		{
			if (CNP.Length == 11)
			{
				// txtCNPJ.Mask = "000,000,000-00"
				return CNP.Insert(3, ".").Insert(7, ".").Insert(11, "-");
			}
			else if (CNP.Length == 14)
			{
				// txtCNPJ.Mask = "00,000,000/0000-00"
				return CNP.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
			}
			else
			{
				throw new CamadaDTO.AppException("Número de CNPJ ou CPF inválido...");
			}
		}
	}

}
