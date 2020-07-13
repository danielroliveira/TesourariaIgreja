using CamadaDAL;
using CamadaDTO;
using System;
using System.Data;

namespace CamadaBLL
{
	public class AjusteBLL
	{
		// INSERT AJUSTE
		//------------------------------------------------------------------------------------------------------------
		public objMovimentacao InsertAjuste(
			objCaixaAjuste ajuste,
			Action<int, decimal> ContaSldUpdate,
			Action<int, decimal> SetorSldUpdate,
			long? IDCaixa = null,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				// 1. INSERT AJUSTE
				//------------------------------------------------------
				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@AjusteDescricao", ajuste.AjusteDescricao);
				db.AdicionarParametros("@IDAjusteTipo", ajuste.IDAjusteTipo);
				db.AdicionarParametros("@IDUserAuth", ajuste.IDUserAuth);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblCaixaAjuste");

				//--- insert AJUSTE
				var newID = (int)db.ExecutarInsertAndGetID(query);
				ajuste.IDAjuste = newID;

				// 2. INSERT MOVIMENTACAO
				//------------------------------------------------------
				var movimentacao = new objMovimentacao(null)
				{
					MovTipo = ajuste.MovValor >= 0 ? (byte)1 : (byte)2,
					MovTipoDescricao = ajuste.MovValor >= 0 ? "E" : "S",
					Consolidado = true,
					IDConta = ajuste.IDConta,
					IDSetor = ajuste.IDSetor,
					Setor = ajuste.Setor,
					MovData = ajuste.MovData,
					MovValor = ajuste.MovValor,
					IDOrigem = (long)ajuste.IDAjuste,
					Origem = EnumMovOrigem.CaixaAjuste, // origem ajuste
					DescricaoOrigem = ajuste.AjusteDescricao,
					IDCaixa = IDCaixa,
				};

				//--- insert MOVIMENTACAO
				var movID = new MovimentacaoBLL().InsertMovimentacao(movimentacao, ContaSldUpdate, SetorSldUpdate, dbTran);
				movimentacao.IDMovimentacao = movID;

				// 3. COMMIT AND RETURN
				//------------------------------------------------------
				if (dbTran == null) db.CommitTransaction();

				return movimentacao;
			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// REMOVE AJUSTE FROM CAIXA
		//------------------------------------------------------------------------------------------------------------
		public void RemoveAjusteFromCaixa(long IDCaixa, object dbTran = null)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				// 1. GET AJUSTES CAIXA
				//------------------------------------------------------------------------------------------------------------
				//--- define Params
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", IDCaixa);
				db.ConvertNullParams();

				string query = "SELECT * FROM tblCaixaAjuste " +
					"WHERE IDAjusteTipo = 2 AND IDAjuste IN " +
					"(SELECT IDOrigem FROM tblMovimentacao WHERE Origem = 4 AND IDCaixa = @IDCaixa)";

				//--- get datatable
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				// 2. DELETE AJUSTE
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", IDCaixa);
				db.ConvertNullParams();

				query = "DELETE tblCaixaAjuste " +
					"WHERE IDAjusteTipo = 2 AND IDAjuste IN " +
					"(SELECT IDOrigem FROM tblMovimentacao WHERE Origem = 4 AND IDCaixa = @IDCaixa)";

				//--- execute deleting
				db.ExecutarManipulacao(CommandType.Text, query);

				// 3. DELETE MOVIMENTACAO
				//------------------------------------------------------------------------------------------------------------

				foreach (DataRow row in dt.Rows)
				{
					//--- define Params
					db.LimparParametros();
					db.AdicionarParametros("@IDOrigem", (int)row["IDAjuste"]);
					db.ConvertNullParams();

					query = "DELETE tblMovimentacao WHERE Origem = 4 AND IDOrigem = @IDOrigem";

					//--- execute deleting
					db.ExecutarManipulacao(CommandType.Text, query);
				}

				// COMMIT
				if (dbTran == null) db.CommitTransaction();

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
