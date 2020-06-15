using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class MovimentacaoBLL
	{
		//=================================================================================================
		// Movimentacao BLL
		//=================================================================================================

		// GET Movimentacao
		//------------------------------------------------------------------------------------------------------------
		public objMovimentacao GetMovimentacao(long MovID, string movOrigem, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryMovimentacaoOrigem WHERE IDMovimentacao = @IDMovimentacao";
				db.LimparParametros();
				db.AdicionarParametros("@IDMovimentacao", MovID);
				db.AdicionarParametros("@MovOrigem", movOrigem);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowInClass(dt.Rows[0]);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET Movimentacao LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objMovimentacao> GetMovimentacaoList(
			int? IDConta = null,
			int? IDSetor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null,
			object dbTran = null)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryMovimentacaoOrigem";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add IDConta
				if (IDConta != null)
				{
					db.AdicionarParametros("@IDConta", IDConta);
					query += myWhere ? " AND IDConta = @IDConta" : " WHERE IDConta = @IDConta";
					myWhere = true;
				}

				// add IDSetor
				if (IDSetor != null)
				{
					db.AdicionarParametros("@IDSetor", IDSetor);
					query += myWhere ? " AND IDSetor = @IDSetor" : " WHERE IDSetor = @IDSetor";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND MovData >= @DataInicial" : " WHERE MovData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND MovData <= @DataFinal" : " WHERE MovData <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY MovData";

				List<objMovimentacao> listagem = new List<objMovimentacao>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClass(row));
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objMovimentacao ConvertRowInClass(DataRow row)
		{
			objMovimentacao Movimentacao = new objMovimentacao((long)row["MovID"])
			{
				MovData = (DateTime)row["MovData"],
				MovOrigem = (string)row["MovOrigem"],
				MovTabela = (string)row["MovTabela"],
				OrigemTabela = (string)row["OrigemTabela"],
				IDOrigem = (long)row["IDOrigem"],
				Origem = (int)row["Origem"],
				MovValor = (decimal)row["MovValor"],
				MovValorReal = (decimal)row["MovValorReal"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				IDCaixa = row["IDCaixa"] == DBNull.Value ? null : (long?)row["IDCaixa"],
			};

			return Movimentacao;
		}
	}
}
