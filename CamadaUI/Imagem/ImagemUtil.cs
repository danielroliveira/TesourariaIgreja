using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDTO;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Imagem
{
	public static class ImagemUtil
	{
		public static objImagem ImagemGetFileAndSave(EnumImagemOrigem origem, long IDOrigem)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				// GET IMAGE FOLDER
				string ImageFolder = GetImageFolder();
				string ImageName = "";

				// GET ImageFile
				using (OpenFileDialog OFD = new OpenFileDialog()
				{
					Filter = "Arquivo PDF (*.pdf)|*.pdf|Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png"
				})
				{
					if (OFD.ShowDialog() == DialogResult.OK)
					{
						ImageName = string.Format(@"{0}", OFD.FileName);
						var img = new FileInfo(ImageName);
						//frmImagemViewer frm = new frmImagemViewer(img.FullName);
						//frm.ShowDialog();
					}
				}

				if (string.IsNullOrEmpty(ImageName))
				{
					return null;
				}

				return new objImagem()
				{
					Origem = origem,
					IDOrigem = IDOrigem
				};
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

		public static objImagem ImagemSave(EnumImagemOrigem origem, long IDOrigem)
		{
			// 

			return new objImagem()
			{
				Origem = origem,
				IDOrigem = IDOrigem
			};
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
