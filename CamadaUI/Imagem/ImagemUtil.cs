using CamadaBLL;
using CamadaDTO;
using System;
using System.IO;
using System.Windows.Forms;
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

				if (string.IsNullOrEmpty(imagem.ImagemFileName)) // if IMAGE = NULL
				{
					// GET ImageFile
					using (OpenFileDialog OFD = new OpenFileDialog()
					{
						Filter = "Arquivo PDF (*.pdf)|*.pdf|Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png",
						Title = "Escolher arquivo de imagem",
						InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
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
				else // IF THERE IS IMAGE --> OPEN/EDIT IMAGE
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
							return imagem;
						}
					}
				}

				// copy to default folder
				imagem = CopyImageToDefaultFolder(imagem, ImageFolder);

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

		private static objImagem CopyImageToDefaultFolder(objImagem image, string ImageFolder)
		{
			try
			{
				//--- check referece date
				if (image.ReferenceDate == null)
				{
					throw new Exception("Não há data de referência...");
				}

				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// GEt fileInfo
				FileInfo file = new FileInfo(image.ImagemPath);

				// copy file to Default Folder
				string subFolder = "";

				switch (image.Origem)
				{
					case EnumImagemOrigem.Despesa:
						subFolder = "Despesas";
						image.ImagemFileName = $"Desp{image.IDOrigem:D4}_{image.ImagemFileName}";
						break;
					case EnumImagemOrigem.APagar:
						subFolder = "APagar";
						image.ImagemFileName = $"Pag{image.IDOrigem:D4}_{image.ImagemFileName}";
						break;
					case EnumImagemOrigem.Movimentacao:
						subFolder = "Movimentacao";
						image.ImagemFileName = $"Mov{image.IDOrigem:D4}_{image.ImagemFileName}";
						break;
					default:
						break;
				}

				DateTime refDate = (DateTime)image.ReferenceDate;
				string folderDate = $"{refDate:yyyy}{refDate:MM}";
				string completeFolder = $"{ImageFolder}\\{subFolder}\\{folderDate}";

				// check directory
				if (!Directory.Exists(completeFolder))
				{
					Directory.CreateDirectory(completeFolder);
				}

				FileInfo newFile = file.CopyTo($"{ImageFolder}\\{subFolder}\\{folderDate}\\{image.ImagemFileName}", true);

				// define new Image Path
				image.ImagemPath = $"\\{subFolder}\\{folderDate}\\{image.ImagemFileName}";

				// return
				return image;

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

		public static void ImagemVisualizar(objImagem imagem)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// GET IMAGE FOLDER
				string ImageFolder = GetImageFolder();

				System.Diagnostics.Process.Start($"{ImageFolder}\\{imagem.ImagemPath}");
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

		public static objImagem ImagemRemover(objImagem imagem)
		{
			imagem.ImagemFileName = string.Empty;
			imagem.ImagemPath = string.Empty;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemSave(imagem);

				return imagem;

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
	}
}
