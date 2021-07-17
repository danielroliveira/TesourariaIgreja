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
		// GET LOCAL IMAGE FROM FOLDER TO SAVE
		//------------------------------------------------------------------------------------------------------------
		public static objImagem ImagemGetFileAndSave(objImagem imagem, Form formOrigem)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// GET IMAGE FOLDER
				string ImageFolder = GetImageFolder();

				// GET LastSourceImageFolder FROM CONFIG
				string LastSourceImageFolder = ObterDefault("LastSourceImageFolder");
				string DefaultInitialFolder = string.IsNullOrEmpty(LastSourceImageFolder) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : LastSourceImageFolder;

				if (string.IsNullOrEmpty(imagem.ImagemFileName)) // if IMAGE = NULL
				{
					// GET ImageFile
					using (OpenFileDialog OFD = new OpenFileDialog()
					{
						Filter = "Arquivo PDF (*.pdf)|*.pdf|Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png",
						Title = "Escolher arquivo de imagem",
						InitialDirectory = DefaultInitialFolder
					})
					{
						if (OFD.ShowDialog() == DialogResult.OK)
						{
							imagem.ImagemFileName = OFD.SafeFileName;
							imagem.ImagemPath = OFD.FileName;

							using (frmImagemDialog frm = new frmImagemDialog(imagem, true, formOrigem))
							{
								frm.ShowDialog();

								if (frm.DialogResult == DialogResult.OK)
								{
									imagem.ImagemFileName = frm.propImagem.ImagemFileName;
									imagem.ImagemPath = frm.propImagem.ImagemPath;
									SaveDefault("LastSourceImageFolder", Path.GetDirectoryName(imagem.ImagemPath));
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
					objImagem oldImage = imagem.ShallowCopy();

					using (frmImagemDialog frm = new frmImagemDialog(imagem, false, formOrigem))
					{
						frm.ShowDialog();

						if (frm.DialogResult == DialogResult.OK)
						{
							// remove old file
							RemoveImageToDefaultFolder(oldImage, ImageFolder);

							// change image to new file name
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

		// COPY FILE TO DEFAULT LOCAL FOLDER
		//------------------------------------------------------------------------------------------------------------
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

				// check file exists
				if (File.Exists($"{ImageFolder}\\{subFolder}\\{folderDate}\\{image.ImagemFileName}"))
				{
					throw new Exception("Já existe um arquivo com mesmo nome na pasta padrão:\n" +
						$"{ImageFolder}\\{subFolder}\\{folderDate}\\{image.ImagemFileName}");
				}

				file.MoveTo($"{ImageFolder}\\{subFolder}\\{folderDate}\\{image.ImagemFileName}");

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

		// REMOVE FILE FROM DEFAULT LOCAL FOLDER
		//------------------------------------------------------------------------------------------------------------
		private static objImagem RemoveImageToDefaultFolder(objImagem image, string ImageFolder)
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
				FileInfo file = new FileInfo($"{ImageFolder}\\{image.ImagemPath}");

				bool _fileExist = file.Exists;

				if (!_fileExist)
				{
					var resp = AbrirDialog("A imagem relacinada e anexada ao registro não foi encontrada...\n" +
						"Não será possível fazer a movimentação para Backup da imagem.\n" +
						"Deseja DESASSOCIAR a imagem do registro assim mesmo?", "Imagem não encontrada",
						DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

					if (resp == DialogResult.No) return null;
				}
				else
				{
					DateTime refDate = (DateTime)image.ReferenceDate;
					string folderDate = $"{refDate:yyyy}{refDate:MM}";
					string removedFolder = $"{ImageFolder}\\Removidas\\{folderDate}";

					// check directory
					if (!Directory.Exists(removedFolder))
					{
						Directory.CreateDirectory(removedFolder);
					}

					// backup file
					file.MoveTo($"{ImageFolder}\\Removidas\\{folderDate}\\{image.ImagemFileName}");
				}

				// define new Image Path
				image.ImagemPath = "";
				image.ImagemFileName = "";

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

		// SAVE DATABASE IMAGE DATA
		//------------------------------------------------------------------------------------------------------------
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
						throw new Exception("a pasta padrão para as Imagens dos Documentos e Comprovantes ainda não foi criada...");
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

				if (File.Exists(imagem.ImagemPath))
				{
					System.Diagnostics.Process.Start($"{imagem.ImagemPath}");
				}
				else
				{
					System.Diagnostics.Process.Start($"{ImageFolder}\\{imagem.ImagemPath}");
				}
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
			try
			{
				string imageFolder = GetImageFolder();

				// --- move to Removed folder
				imagem = RemoveImageToDefaultFolder(imagem, imageFolder);

				//--- check return
				if (imagem == null)
				{
					throw new AppException("Operação cancelada...");
				}

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
