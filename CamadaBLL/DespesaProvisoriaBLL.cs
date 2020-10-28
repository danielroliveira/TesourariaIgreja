using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace CamadaBLL
{
	//=================================================================================================
	// DESPESA PROVISORIA
	//=================================================================================================
	public class DespesaProvisoriaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaProvisoria> GetListDespesaProvisoria()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaProvisoria";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDProvisorio";

				List<objDespesaProvisoria> listagem = new List<objDespesaProvisoria>();
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
		public List<objDespesaProvisoria> GetListDespesaProvisoria(
			int? IDConta = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaProvisoria";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add IDSetor
				if (IDConta != null)
				{
					db.AdicionarParametros("@IDConta", IDConta);
					query += myWhere ? " AND IDConta = @IDConta" : " WHERE IDConta = @IDConta";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND RetiradaData >= @DataInicial" : " WHERE RetiradaData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND RetiradaData <= @DataFinal" : " WHERE RetiradaData <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY RetiradaData";

				List<objDespesaProvisoria> listagem = new List<objDespesaProvisoria>();
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
		public objDespesaProvisoria ConvertRowInClass(DataRow row)
		{
			objDespesaProvisoria despesa = new objDespesaProvisoria((long)row["IDProvisorio"])
			{
				Finalidade = (string)row["Finalidade"],
				Autorizante = (string)row["Autorizante"],
				ValorProvisorio = (decimal)row["ValorProvisorio"],
				RetiradaData = (DateTime)row["RetiradaData"],
				Comprador = (string)row["Comprador"],
				DevolucaoData = row["DevolucaoData"] == DBNull.Value ? null : (DateTime?)row["DevolucaoData"] ,
				ValorRealizado = row["ValorRealizado"] == DBNull.Value ? null : (decimal?)row["ValorRealizado"],
				IDConta = (byte)row["IDConta"],
				Conta = (string)row["Conta"],
				ContaSaldo = row["ContaSaldo"] == DBNull.Value ? 0 : (decimal)row["ContaSaldo"],
				BloqueioData = row["BloqueioData"] == DBNull.Value ? null : (DateTime?)row["BloqueioData"],
				Concluida = (bool)row["Concluida"],
			};

			// RETURN
			return despesa;
		}

		// INSERT DESPESA PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesaProvisoria(objDespesaProvisoria desp)
		{
			try
			{
				AcessoDados dbTran = new AcessoDados();

				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@Finalidade", desp.Finalidade);
				dbTran.AdicionarParametros("@Autorizante", desp.Autorizante);
				dbTran.AdicionarParametros("@ValorProvisorio", desp.ValorProvisorio);
				dbTran.AdicionarParametros("@RetiradaData", desp.RetiradaData);
				dbTran.AdicionarParametros("@Comprador", desp.Comprador);
				dbTran.AdicionarParametros("@IDConta", desp.IDConta);
				dbTran.AdicionarParametros("@IDSetor", desp.IDSetor);
				dbTran.AdicionarParametros("@Concluida", desp.Concluida);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesaProvisoria");

				//--- insert
				long newID = dbTran.ExecutarInsertAndGetID(query);

				//--- insert Despesa Periodica
				desp.IDProvisorio = newID;
				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE DESPESA PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public void UpdateDespesaProvisoria(objDespesaProvisoria desp)
		{
			try
			{
				AcessoDados dbTran = new AcessoDados();

				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDProvisorio", desp.IDProvisorio);
				dbTran.AdicionarParametros("@Finalidade", desp.Finalidade);
				dbTran.AdicionarParametros("@Autorizante", desp.Autorizante);
				dbTran.AdicionarParametros("@ValorProvisorio", desp.ValorProvisorio);
				dbTran.AdicionarParametros("@RetiradaData", desp.RetiradaData);
				dbTran.AdicionarParametros("@Comprador", desp.Comprador);
				dbTran.AdicionarParametros("@IDConta", desp.IDConta);
				dbTran.AdicionarParametros("@IDSetor", desp.IDSetor);
				dbTran.AdicionarParametros("@Concluida", desp.Concluida);
				dbTran.AdicionarParametros("@DevolucaoData", desp.DevolucaoData);
				dbTran.AdicionarParametros("@ValorRealizado", desp.ValorRealizado);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateUpdateSQL("tblDespesaProvisoria", "@IDProvisorio");

				//--- insert
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST DESPESA RELACIONADA WITH PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesa> GetDespesasRealizado(int IDProvisorio, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryDespesaComum ";
				
				// add params
				db.LimparParametros();

				db.AdicionarParametros("@IDProvisorio", IDProvisorio);

				query += "WHERE IDDespesa IN (SELECT IDDespesa FROM tblDespesaProvisoriaRealizado WHERE IDProvisorio = @IDProvisorio)";
				query += " ORDER BY IDDespesa";

				List<objDespesa> listagem = new List<objDespesa>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				DespesaBLL dBLL = new DespesaBLL();

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(dBLL.ConvertRowInClass(row));
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST DESPESA AUTORIZANTES
		//------------------------------------------------------------------------------------------------------------
		public List<string> GetAutorizanteList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT Autorizante FROM tblDespesaProvisoria GROUP BY Autorizante;";

				// add params
				db.LimparParametros();

				query += " ORDER BY Autorizante";

				List<string> listagem = new List<string>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				DespesaBLL dBLL = new DespesaBLL();

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add((string)row[0]);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
