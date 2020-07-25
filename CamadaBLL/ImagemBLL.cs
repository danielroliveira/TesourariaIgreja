using CamadaDAL;
using CamadaDTO;
using System;
using System.Data;

namespace CamadaBLL
{
	public class ImagemBLL
	{
		/* Origem OrigemDescricao
		*  ------ --------------------------------------------------
		*  1      tblDespesa
		*  2      tblAPagar
		*  3      tblMovimentacao
		*/

		//===============================================================================
		// SAVE NEW IMAGEM
		//===============================================================================
		public bool SaveImagem(objImagem imagem,
							   object dbTran = null)
		{

			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;
			bool tranInterna = false;

			if (dbTran == null)
			{
				db.BeginTransaction();
				tranInterna = true;
			}

			try
			{
				//--- DELETE old Imagem
				DeleteImagem(imagem.Origem, imagem.IDOrigem);

				//--- Verifica se existe Imagem, se nao return TRUE
				if (imagem.ImagemFileName.Trim().Length == 0)
				{
					//--- COMMIT
					if (tranInterna) db.CommitTransaction();
					//--- RETURN
					return true;
				}

				//--- INSERT NEW DETERMINA OS PARAMETROS
				db.LimparParametros();
				db.AdicionarParametros("@Origem", imagem.Origem);
				db.AdicionarParametros("@IDOrigem", imagem.IDOrigem);
				db.AdicionarParametros("@ImagemFileName", imagem.ImagemFileName);
				db.AdicionarParametros("@ImagemPath", imagem.ImagemPath);

				//--- INSERE A NOVA Imagem
				string myQuery = "INSERT INTO tblImagem " +
					"(IDOrigem, Origem, ImagemFileName, ImagemPath) " +
					"VALUES " +
					"(@IDOrigem, @Origem, @ImagemFileName, @ImagemPath)";

				db.ExecutarManipulacao(CommandType.Text, myQuery);

				//--- COMMIT
				if (tranInterna) db.CommitTransaction();

				return true;
			}
			catch (Exception ex)
			{
				//--- ROLLBACK
				if (tranInterna) db.RollBackTransaction();
				throw ex;
			}

		}

		//==========================================================================================
		// DELETE Imagem
		//==========================================================================================
		public bool DeleteImagem(EnumImagemOrigem Origem,
								 long IDOrigem,
								 object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				//--- DELETE Imagem
				db.LimparParametros();
				db.AdicionarParametros("@Origem", Origem);
				db.AdicionarParametros("@IDOrigem", IDOrigem);

				string myQuery = "DELETE tblImagem WHERE Origem = @Origem AND IDOrigem = @IDOrigem";

				db.ExecutarManipulacao(CommandType.Text, myQuery);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
