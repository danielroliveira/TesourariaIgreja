using CamadaDAL;
using System;
using System.Data;

namespace CamadaBLL
{
	public class ObservacaoBLL
	{
		/* Origem OrigemDescricao
        *  ------ --------------------------------------------------
        *  1      tblEntrada
        *  2      tblSaida
        */

		//===============================================================================
		// SAVE NEW OBSERVACAO
		//===============================================================================

		public bool SaveObservacao(byte Origem,
								   long IDOrigem,
								   string Observacao,
								   object dbTran = null)
		{

			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;
			bool tranInterna = false;

			if (!db.isTran)
			{
				db.BeginTransaction();
				tranInterna = true;
			}

			string myQuery = "";

			try
			{
				//--- DELETE old OBSERVACAO
				DeleteObservacao(Origem, IDOrigem);

				//--- Verifica se existe observacao, se nao return TRUE
				if (Observacao == null || Observacao.Trim().Length == 0)
				{
					//--- COMMIT
					if (tranInterna) db.CommitTransaction();
					//--- RETURN
					return true;
				}

				//--- INSERT NEW DETERMINA OS PARAMETROS
				db.LimparParametros();
				db.AdicionarParametros("@Origem", Origem);
				db.AdicionarParametros("@IDOrigem", IDOrigem);
				db.AdicionarParametros("@Observacao", Observacao);

				//--- INSERE A NOVA OBSERVACAO
				myQuery = "INSERT INTO tblObservacao (IDOrigem, Origem, Observacao) VALUES (@IDOrigem, @Origem, @Observacao)";

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
		// DELETE OBSERVACAO
		//==========================================================================================
		public bool DeleteObservacao(byte Origem,
									 long IDOrigem,
									 object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{

				//--- DELETE OBSERVACAO
				db.LimparParametros();
				db.AdicionarParametros("@Origem", Origem);
				db.AdicionarParametros("@IDOrigem", IDOrigem);

				string myQuery = "DELETE tblObservacao WHERE Origem = @Origem AND IDOrigem = @IDOrigem";

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
