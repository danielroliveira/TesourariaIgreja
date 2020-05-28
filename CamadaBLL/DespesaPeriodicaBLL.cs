using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class DespesaPeriodicaBLL
	{
		//=============================================================================
		// DESPESA
		//=============================================================================

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaPeriodica> GetListDespesaPeriodica()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaPeriodica";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDDespesa";

				List<objDespesaPeriodica> listagem = new List<objDespesaPeriodica>();
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

		// GET LIST OF WITH DETAILS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaPeriodica> GetListDespesaPeriodica(
			int? IDSetor = null,
			int? IDDespesaTipo = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaPeriodica";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add IDSetor
				if (IDSetor != null)
				{
					db.AdicionarParametros("@IDSetor", IDSetor);
					query += myWhere ? " AND IDSetor = @IDSetor" : " WHERE IDSetor = @IDSetor";
					myWhere = true;
				}

				// add IDDespesaTipo
				if (IDDespesaTipo != null)
				{
					db.AdicionarParametros("@IDDespesaTipo", IDDespesaTipo);
					query += myWhere ? " AND IDDespesaTipo = @IDDespesaTipo" : " WHERE IDDespesaTipo = @IDDespesaTipo";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND DespesaData >= @DataInicial" : " WHERE DespesaData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND DespesaData <= @DataFinal" : " WHERE DespesaData <= @DataFinal";
					myWhere = true;
				}

				// add IDCredor
				if (IDCredor != null)
				{
					db.AdicionarParametros("@IDCredor", IDCredor);
					query += myWhere ? " AND IDCredor = @IDCredor" : " WHERE IDCredor = @IDCredor";
					myWhere = true;
				}

				query += " ORDER BY DespesaData";

				List<objDespesaPeriodica> listagem = new List<objDespesaPeriodica>();
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

		// GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		public objDespesaPeriodica GetDespesaPeriodica(long IDDespesa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaPeriodica WHERE IDDespesa = @IDDespesa";
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", IDDespesa);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowInClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objDespesaPeriodica ConvertRowInClass(DataRow row)
		{
			objDespesaPeriodica despesa = new objDespesaPeriodica((long)row["IDDespesa"])
			{
				DespesaOrigem = 2,
				DespesaDescricao = (string)row["DespesaDescricao"],
				DespesaData = (DateTime)row["DespesaData"],
				DespesaValor = (decimal)row["DespesaValor"],
				IDCredor = (int)row["IDCredor"],
				Credor = (string)row["Credor"],
				IDDespesaTipo = (int)row["IDDespesaTipo"],
				DespesaTipo = (string)row["DespesaTipo"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDCobrancaForma = (byte)row["IDCobrancaForma"],
				CobrancaForma = (string)row["CobrancaForma"],
				IniciarData = (DateTime)row["IniciarData"],
				RecorrenciaTipo = (byte)row["RecorrenciaTipo"],
				RecorrenciaDia = row["RecorrenciaDia"] == DBNull.Value ? null : (byte?)row["RecorrenciaDia"],
				RecorrenciaMes = row["RecorrenciaMes"] == DBNull.Value ? null : (byte?)row["RecorrenciaMes"],
				RecorrenciaRepeticao = row["RecorrenciaRepeticao"] == DBNull.Value ? null : (short?)row["RecorrenciaRepeticao"],
				RecorrenciaSemana = row["RecorrenciaSemana"] == DBNull.Value ? null : (byte?)row["RecorrenciaSemana"],
				Ativa = (bool)row["Ativa"],
			};

			return despesa;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesa(objDespesaPeriodica desp)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				dbTran.AdicionarParametros("@DespesaOrigem", desp.DespesaOrigem);
				dbTran.AdicionarParametros("@DespesaValor", desp.DespesaValor);
				dbTran.AdicionarParametros("@DespesaData", desp.DespesaData);
				dbTran.AdicionarParametros("@IDCredor", desp.IDCredor);
				dbTran.AdicionarParametros("@IDSetor", desp.IDSetor);
				dbTran.AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesa");

				//--- insert and Get new ID
				long newID = dbTran.ExecutarInsertAndGetID(query);

				//--- insert Despesa Comum
				desp.IDDespesa = newID;
				InsertDespesaPeriodica(desp, dbTran);

				dbTran.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		private void InsertDespesaPeriodica(objDespesaPeriodica desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@IDCobrancaForma", desp.IDCobrancaForma);
				dbTran.AdicionarParametros("@IniciarData", desp.IniciarData);
				dbTran.AdicionarParametros("@RecorrenciaTipo", desp.RecorrenciaTipo);
				dbTran.AdicionarParametros("@RecorrenciaDia", desp.RecorrenciaDia);
				dbTran.AdicionarParametros("@RecorrenciaMes", desp.RecorrenciaMes);
				dbTran.AdicionarParametros("@RecorrenciaRepeticao", desp.RecorrenciaRepeticao);
				dbTran.AdicionarParametros("@RecorrenciaSemana", desp.RecorrenciaSemana);
				dbTran.AdicionarParametros("@Ativa", desp.Ativa);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesaPeriodica");

				//--- insert
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesaPeriodica(objDespesaPeriodica desp)
		{
			try
			{

				throw new NotImplementedException("Ainda não foi implementada essa função");

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteDespesaPeriodica(int IDDespesa)
		{
			throw new NotImplementedException("Em implementação");
		}
	}
}
