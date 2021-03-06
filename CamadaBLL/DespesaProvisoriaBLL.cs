﻿using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
			int? IDSetor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null,
			bool? Concluida = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaProvisoria";
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
					db.AdicionarParametros("@IDSetor", IDConta);
					query += myWhere ? " AND IDSetor = @IDSetor" : " WHERE IDSetor = @IDSetor";
					myWhere = true;
				}

				// add Concluida
				if (Concluida != null)
				{
					db.AdicionarParametros("@Concluida", Concluida);
					query += myWhere ? " AND Concluida = @Concluida" : " WHERE Concluida = @Concluida";
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
			objDespesaProvisoria despesa = new objDespesaProvisoria((int)row["IDProvisorio"])
			{
				Finalidade = (string)row["Finalidade"],
				Autorizante = (string)row["Autorizante"],
				ValorProvisorio = (decimal)row["ValorProvisorio"],
				RetiradaData = (DateTime)row["RetiradaData"],
				Comprador = (string)row["Comprador"],
				DevolucaoData = row["DevolucaoData"] == DBNull.Value ? null : (DateTime?)row["DevolucaoData"],
				ValorRealizado = row["ValorRealizado"] == DBNull.Value ? null : (decimal?)row["ValorRealizado"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
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
		public void UpdateDespesaProvisoria(objDespesaProvisoria desp, AcessoDados dbTran)
		{
			try
			{
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

				DespesaComumBLL dBLL = new DespesaComumBLL();

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

		// GET IF DESPESA IS ALREADY VINCULATE
		//------------------------------------------------------------------------------------------------------------
		public bool DespesaAlreadyVinculada(long IDDespesa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				// add params
				db.LimparParametros();

				db.AdicionarParametros("@IDDespesa", IDDespesa);
				string query = "SELECT * FROM tblDespesaProvisoriaRealizado WHERE IDDespesa = @IDDespesa";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return false;
				}

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST PROVISORIA AUTORIZANTES
		//------------------------------------------------------------------------------------------------------------
		public List<string> GetAutorizanteList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT Autorizante FROM tblDespesaProvisoria GROUP BY Autorizante ";

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

		// GET LIST PROVISORIA COMPRADORES
		//------------------------------------------------------------------------------------------------------------
		public List<string> GetCompradorList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT Comprador FROM tblDespesaProvisoria GROUP BY Comprador ";

				// add params
				db.LimparParametros();

				query += " ORDER BY Comprador";

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

		// ATTACH DESPESA TO PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public void AttachDespesaToProvisoria(objDespesaProvisoria Provisorio, objDespesa Despesa)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- limpar parametros
				db.LimparParametros();
				db.AdicionarParametros("@IDProvisorio", Provisorio.IDProvisorio);
				db.AdicionarParametros("@IDDespesa", Despesa.IDDespesa);

				//--- execute insert tblDespesaProvisoriaRealizado
				string query = "INSERT INTO tblDespesaProvisoriaRealizado " +
					"(IDProvisorio, IDDespesa) " +
					"VALUES (@IDProvisorio, @IDDespesa);";

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- execute Update Desepesa Provisoria
				Provisorio.ValorRealizado = Provisorio.ValorRealizado == null ? Despesa.DespesaValor : Provisorio.ValorRealizado + Despesa.DespesaValor;
				Provisorio.EndEdit();

				UpdateDespesaProvisoria(Provisorio, db);

				//--- commit
				db.CommitTransaction();
			}
			catch (SqlException ex)
			{
				db.RollBackTransaction();

				if (ex.Number == 2627)
				{
					throw new AppException("Já existe um Vínculo criado entre a Despesa Provisória com a Despesa Escolhida...");
				}
				else
				{
					throw ex;
				}
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// DETTACH DESPESA TO PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public void DettachDespesaToProvisoria(objDespesaProvisoria Provisorio, objDespesa Despesa)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- limpar parametros
				db.LimparParametros();
				db.AdicionarParametros("@IDProvisorio", Provisorio.IDProvisorio);
				db.AdicionarParametros("@IDDespesa", Despesa.IDDespesa);

				//--- execute insert tblDespesaProvisoriaRealizado
				string query = "DELETE tblDespesaProvisoriaRealizado " +
					"WHERE IDProvisorio = @IDProvisorio AND IDDespesa = @IDDespesa";

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- execute Update Desepesa Provisoria
				Provisorio.Concluida = false;
				Provisorio.DevolucaoData = null;
				Provisorio.ValorRealizado -= Despesa.DespesaValor;
				Provisorio.EndEdit();

				UpdateDespesaProvisoria(Provisorio, db);

				//--- commit
				db.CommitTransaction();
			}
			catch (SqlException ex)
			{
				db.RollBackTransaction();

				if (ex.Number == 2627)
				{
					throw new AppException("Já existe um Vínculo criado entre a Despesa Provisória com a Despesa Escolhida...");
				}
				else
				{
					throw ex;
				}
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// FINALIZE DESPESA PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public void FinalizeProvisoria(objDespesaProvisoria Provisorio)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- execute Update Desepesa Provisoria
				Provisorio.Concluida = true;
				Provisorio.DevolucaoData = DateTime.Today;
				Provisorio.EndEdit();

				UpdateDespesaProvisoria(Provisorio, db);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// REACTIVE DESPESA PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public void ReactiveProvisoria(objDespesaProvisoria Provisorio)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- execute Update Desepesa Provisoria
				Provisorio.Concluida = false;
				Provisorio.DevolucaoData = null;
				Provisorio.EndEdit();

				UpdateDespesaProvisoria(Provisorio, db);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE DESPESA PROVISORIA
		//------------------------------------------------------------------------------------------------------------
		public void DeleteProvisoria(long IDProvisorio)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				// 1- REMOVE VINCULO DESPESA
				//-------------------------------------------------------------

				//--- limpar parametros
				db.LimparParametros();
				db.AdicionarParametros("@IDProvisorio", IDProvisorio);

				//--- execute insert tblDespesaProvisoriaRealizado
				string query = "DELETE tblDespesaProvisoriaRealizado " +
					"WHERE IDProvisorio = @IDProvisorio";

				db.ExecutarManipulacao(CommandType.Text, query);

				// 2- REMOVE PROVISORIA
				//-------------------------------------------------------------

				//--- limpar parametros
				db.LimparParametros();
				db.AdicionarParametros("@IDProvisorio", IDProvisorio);

				//--- execute DELETE tblDespesaProvisoria
				query = "DELETE tblDespesaProvisoria " +
					"WHERE IDProvisorio = @IDProvisorio";

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- commit
				db.CommitTransaction();
			}
			catch (SqlException ex)
			{
				db.RollBackTransaction();
				throw new AppException("Não é possível excluir essa Despesa Provisória..." +
					ex.Message);
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
