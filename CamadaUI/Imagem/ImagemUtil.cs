using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaBLL;
using CamadaDTO;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Imagem
{
	public static class ImagemUtil
	{
		public static objImagem ImagemGetFileAndSave(objImagem imagem, Form formOrigem)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// GET IMAGE FOLDER
				string ImageFolder = GetImageFolder();

				if (string.IsNullOrEmpty(imagem.ImagemFileName))
				{
					// GET ImageFile
					using (OpenFileDialog OFD = new OpenFileDialog()
					{
						Filter = "Arquivo PDF (*.pdf)|*.pdf|Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png",
						Title = "Escolher arquivo de imagem",
						InitialDirectory = ImageFolder
					})
					{
						if (OFD.ShowDialog() == DialogResult.OK)
						{
							imagem.ImagemFileName = OFD.SafeFileName;
							imagem.ImagemPath = OFD.FileName;

							using (frmImagemDialog frm = new frmImagemDialog(imagem, formOrigem))
							{
								frm.ShowDialog();

								if (frm.DialogResult == DialogResult.OK)
								{
									imagem.ImagemFileName = frm.propImagem.ImagemFileName;
									imagem.ImagemPath = frm.propImagem.ImagemPath;
								}
								else
								{
									return null;
								}
							}
						}
						else
						{
							return null;
						}
					}
				}
				else
				{
					using (frmImagemDialog frm = new frmImagemDialog(imagem, formOrigem))
					{
						frm.ShowDialog();

						if (frm.DialogResult == DialogResult.OK)
						{
							imagem.ImagemFileName = frm.propImagem.ImagemFileName;
							imagem.ImagemPath = frm.propImagem.ImagemPath;
						}
						else
						{
							return null;
						}
					}
				}

				// save in database
				ImagemSave(imagem);
				return imagem;
			}
			catch (Exception ex)
			{
				throw new Exception("Uma exceção ocorreu ao Obter o arquivo da imagem..." + "\n" + ex.Message);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		public static void ImagemSave(objImagem imagem)
		{
			try
			{   // --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				new ImagemBLL().SaveImagem(imagem);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		public static string GetImageFolder()
		{
			try
			{
				string folder = ObterDefault("DocumentsImageFolder");

				if (string.IsNullOrEmpty(folder))
				{
					throw new Exception("A pasta de Images ainda não foi definida na Configuração...");
				}

				if (Directory.Exists(folder))
				{
					return folder;
				}
				else
				{
					DialogResult resp = AbrirDialog("Ainda não foi criada a pasta padrão para as Imagens dos Documentos e Comprovantes. \n" +
						"Deseja criar a pasta padrão?",
						"Pasta de Imagens Documentos",
						DialogType.SIM_NAO,
						DialogIcon.Question);

					if (resp == DialogResult.Yes)
					{
						Directory.CreateDirectory(folder);
						return folder;
					}
					else
					{
						throw new Exception("a pasta padrão para as Imagens dos Documentos e Comprovantes ainda ñão foi criada...");
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
