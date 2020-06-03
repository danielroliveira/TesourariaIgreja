using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CamadaBLL
{
	public class AReceberBLL
	{
		// GET ARECEBER
		//------------------------------------------------------------------------------------------------------------
		public objAReceber GetAReceber(long IDAReceber, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryAReceber WHERE IDAReceber = @IDAReceber";
				db.LimparParametros();
				db.AdicionarParametros("@IDAReceber", IDAReceber);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowInClass(dt.Rows[0]);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objAReceber> GetListAReceber(
			byte? IDSituacao,
			int? IDContaProvisoria = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryAReceber";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add IDSituacao
				if (IDSituacao != null)
				{
					db.AdicionarParametros("@IDSituacao", IDSituacao);
					query += myWhere ? " AND IDSituacao = @IDSituacao" : " WHERE IDSituacao = @IDSituacao";
					myWhere = true;
				}

				// add IDContaProvisoria
				if (IDContaProvisoria != null)
				{
					db.AdicionarParametros("@IDContaProvisoria", IDContaProvisoria);
					query += myWhere ? " AND IDContaProvisoria = @IDContaProvisoria" : " WHERE IDContaProvisoria = @IDContaProvisoria";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND CompensacaoData >= @DataInicial" : " WHERE CompensacaoData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND CompensacaoData <= @DataFinal" : " WHERE CompensacaoData <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY CompensacaoData";

				List<objAReceber> listagem = new List<objAReceber>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClass(row));
				}

				// RETURN
				return listagem.OrderBy(p => p.CompensacaoData).ToList();

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objAReceber ConvertRowInClass(DataRow row)
		{
			objAReceber entrada = new objAReceber((long)row["IDAReceber"])
			{
				CompensacaoData = (DateTime)row["CompensacaoData"],
				IDContribuicao = (long)row["IDContribuicao"],
				ValorBruto = (decimal)row["ValorBruto"],
				ValorLiquido = (decimal)row["ValorLiquido"],
				ValorRecebido = (decimal)row["ValorRecebido"],
				IDContaProvisoria = (int)row["IDContaProvisoria"],
				Conta = (string)row["Conta"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				IDEntradaForma = (byte)row["IDEntradaForma"],
				EntradaForma = (string)row["EntradaForma"],
				IDSetor = (int)row["IDSetor"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertAReceber(objAReceber entrada, Action<int, decimal> ContaSldUpdate, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (!db.isTran) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@CompensacaoData", entrada.CompensacaoData);
				db.AdicionarParametros("@IDContribuicao", entrada.IDContribuicao);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@ValorLiquido", entrada.ValorLiquido);
				db.AdicionarParametros("@ValorRecebido", 0);
				db.AdicionarParametros("@IDContaProvisoria", entrada.IDContaProvisoria);
				db.AdicionarParametros("@IDSituacao", 1);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblAReceber");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA PROVISORIA
				new ContaBLL().ContaSaldoChange(entrada.IDContaProvisoria, entrada.ValorBruto, db, ContaSldUpdate);

				if (!db.isTran) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (!db.isTran) db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAReceber(objAReceber receber, Action<int, decimal> ContaSldUpdate, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				// check and begin transaction
				if (!db.isTran) db.BeginTransaction();

				// get old AReceber IDConta, and Value
				var oldAReceber = GetAReceber((int)receber.IDAReceber, db);

				// return old Values SALDO CONTA PROVISORIA
				ContaBLL cBLL = new ContaBLL();
				cBLL.ContaSaldoChange(oldAReceber.IDContaProvisoria, oldAReceber.ValorBruto * (-1), db, ContaSldUpdate);

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAReceber", receber.IDAReceber);
				db.AdicionarParametros("@CompensacaoData", receber.CompensacaoData);
				db.AdicionarParametros("@IDContribuicao", receber.IDContribuicao);
				db.AdicionarParametros("@ValorBruto", receber.ValorBruto);
				db.AdicionarParametros("@ValorLiquido", receber.ValorLiquido);
				db.AdicionarParametros("@ValorRecebido", receber.ValorRecebido);
				db.AdicionarParametros("@IDContaProvisoria", receber.IDContaProvisoria);
				db.AdicionarParametros("@IDSituacao", receber.Situacao);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblAReceber", "@IDAReceber");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- altera o saldo da CONTA provisoria
				cBLL.ContaSaldoChange(receber.IDContaProvisoria, receber.ValorBruto, db, ContaSldUpdate);

				//--- commit and return
				if (!db.isTran) db.CommitTransaction();
				return true;

			}
			catch (Exception ex)
			{
				if (!db.isTran) db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE ARECEBER SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAReceber(objAReceber rec)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAReceber", rec.IDAReceber);
				db.AdicionarParametros("@IDSituacao", rec.IDSituacao);
				db.AdicionarParametros("@ValorLiquido", rec.ValorLiquido);
				db.AdicionarParametros("@CompensacaoData", rec.CompensacaoData);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblAReceber", "@IDAReceber");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
