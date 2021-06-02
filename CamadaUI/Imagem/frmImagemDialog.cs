using CamadaDTO;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Imagem
{
	public partial class frmImagemDialog : CamadaUI.Modals.frmModFinBorder
	{
		public objImagem propImagem { get; set; }
		Form _formOrigem;

		#region CONSTRUCTOR | SUB NEW

		public frmImagemDialog(objImagem imagem, bool IsNewImage, Form formOrigem)
		{
			InitializeComponent();

			_formOrigem = formOrigem;
			propImagem = imagem;
			Height = 200;

			btnSalvar.Enabled = IsNewImage;

			lblPath.Text = imagem.ImagemPath;
			ResizeFontLabel(lblPath);
		}

		private void frmImagemDialog_Load(object sender, EventArgs e)
		{
			btnSalvar.Focus();
		}

		#endregion // CONSTRUCTOR | SUB NEW --- END

		#region BUTTONS FUNCTION

		private void btnAlterar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnProcurar_Click(object sender, EventArgs e)
		{
			// CHECK IS NEW
			bool IsNew = propImagem == null || string.IsNullOrEmpty(propImagem.ImagemPath);
			string DefaultInitialFolder = IsNew ? ObterDefault("LastSourceImageFolder") : propImagem.ImagemPath;

			// GET ImageFile
			using (OpenFileDialog OFD = new OpenFileDialog()
			{
				Filter = "Arquivo PDF (*.pdf)|*.pdf|Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png",
				InitialDirectory = DefaultInitialFolder,
			})
			{
				if (OFD.ShowDialog() == DialogResult.OK)
				{
					if (propImagem.ImagemFileName != OFD.SafeFileName)
					{
						propImagem.ImagemFileName = OFD.SafeFileName;
						propImagem.ImagemPath = OFD.FileName;
						lblPath.Text = propImagem.ImagemPath;
						ResizeFontLabel(lblPath);
						btnAlterar.Enabled = true;
						SaveDefault("LastSourceImageFolder", System.IO.Path.GetDirectoryName(propImagem.ImagemPath));
					}
					else
					{
						AbrirDialog("O arquivo de imagem escolhido continua sendo o mesmo.",
							"Escolher Arquivo");
						return;
					}
				};
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnVisualizar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(propImagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Visualizar Imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		#endregion // BUTTONS FUNCTION --- END

		#region VISUAL EFFECTS

		//-------------------------------------------------------------------------------------------------
		//---  CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//-------------------------------------------------------------------------------------------------
		private void frmDateGet_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void frmDateGet_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}



		#endregion // VISUAL EFFECTS --- END


	}
}
