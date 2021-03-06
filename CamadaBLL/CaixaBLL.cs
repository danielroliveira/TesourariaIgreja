﻿using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class CaixaBLL
	{
		// GET Caixa
		//------------------------------------------------------------------------------------------------------------
		public objCaixa GetCaixaByID(long IDCaixa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCaixa WHERE IDCaixa = @IDCaixa";
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", IDCaixa);

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
		public List<objCaixa> GetCaixaList(
			int? IDConta = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null,
			object dbTran = null)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryCaixa";
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

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND DataInicial >= @DataInicial" : " WHERE DataInicial >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND DataInicial <= @DataFinal" : " WHERE DataInicial <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY IDCaixa";

				List<objCaixa> listagem = new List<objCaixa>();
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
		public objCaixa ConvertRowInClass(DataRow row)
		{
			objCaixa caixa = new objCaixa((long)row["IDCaixa"])
			{
				FechamentoData = (DateTime)row["FechamentoData"],
				IDConta = (int)row["IDConta"],
				Conta = row["Conta"] == DBNull.Value ? null : (string)row["Conta"],
				ContaSaldo = (decimal)row["ContaSaldo"],
				ContaBloqueioData = row["ContaBloqueioData"] == DBNull.Value ? null : (DateTime?)row["ContaBloqueioData"],
				DataFinal = (DateTime)row["DataFinal"],
				DataInicial = (DateTime)row["DataInicial"],
				SaldoAnterior = (decimal)row["SaldoAnterior"],
				SaldoFinal = (decimal)row["SaldoFinal"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				IDUsuario = (int)row["IDUsuario"],
				UsuarioApelido = (string)row["UsuarioApelido"],
				CaixaFinalDoDia = (bool)row["CaixaFinalDoDia"],
				Observacao = row["Observacao"] == DBNull.Value ? string.Empty : (string)row["Observacao"],
			};

			return caixa;
		}

		// INSERT CAIXA
		//------------------------------------------------------------------------------------------------------------
		public long InsertCaixa(objCaixa caixa)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@FechamentoData", caixa.FechamentoData);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataInicial", caixa.DataInicial);
				db.AdicionarParametros("@DataFinal", caixa.DataFinal);
				db.AdicionarParametros("@SaldoAnterior", caixa.SaldoAnterior);
				db.AdicionarParametros("@SaldoFinal", caixa.SaldoFinal);
				db.AdicionarParametros("@IDSituacao", caixa.IDSituacao);
				db.AdicionarParametros("@IDUsuario", caixa.IDUsuario);
				db.AdicionarParametros("@CaixaFinalDoDia", caixa.CaixaFinalDoDia);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblCaixa");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);
				caixa.IDCaixa = newID;

				//--- return
				db.CommitTransaction();
				return newID;
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE CAIXA
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCaixa(objCaixa caixa, AcessoDados dbTran)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : dbTran;
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.AdicionarParametros("@FechamentoData", caixa.FechamentoData);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataInicial", caixa.DataInicial);
				db.AdicionarParametros("@DataFinal", caixa.DataFinal);
				db.AdicionarParametros("@SaldoAnterior", caixa.SaldoAnterior);
				db.AdicionarParametros("@SaldoFinal", caixa.SaldoFinal);
				db.AdicionarParametros("@IDSituacao", caixa.IDSituacao);
				db.AdicionarParametros("@IDUsuario", caixa.IDUsuario);
				db.AdicionarParametros("@CaixaFinalDoDia", caixa.CaixaFinalDoDia);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblCaixa", "IDCaixa");

				//--- execute update
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- change observacao
				ObservacaoBLL oBLL = new ObservacaoBLL();
				oBLL.SaveObservacao(3, (long)caixa.IDCaixa, caixa.Observacao, db);

				//--- commit and return
				if (dbTran == null) db.CommitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// FINALIZE CAIXA
		//------------------------------------------------------------------------------------------------------------
		public bool FinalizeCaixa(objCaixa caixa)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				// 1. BLOCK older Caixa Conta SITUACAO = 3
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataFinal", caixa.DataFinal);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- define query
				string query = "UPDATE tblCaixa SET IDSituacao = 3 " +
					"WHERE IDConta = @IDConta " +
					"AND DataFinal <= @DataFinal " +
					"AND IDCaixa <> @IDCaixa";

				//--- execute update
				db.ExecutarManipulacao(CommandType.Text, query);

				// 2. BLOCK CONTA Date
				//------------------------------------------------------------------------------------------------------------
				DateTime blockDate = caixa.CaixaFinalDoDia == false ? caixa.DataFinal : caixa.DataFinal.AddDays(1);
				new ContaBLL().UpdateContaBloqueioData(caixa.IDConta, blockDate, db);

				// 3. UPDATE Caixa
				//------------------------------------------------------------------------------------------------------------
				UpdateCaixa(caixa, db);

				// COMMIT and RETURN
				//------------------------------------------------------------------------------------------------------------
				db.CommitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// UNBLOCK CAIXA
		//------------------------------------------------------------------------------------------------------------
		public DateTime DesbloquearCaixa(objCaixa caixa)
		{
			AcessoDados db = null;
			DateTime? oldDataPadraoConta = null;

			try
			{
				db = new AcessoDados();
				//--- INICIA TRANSACTION
				db.BeginTransaction();

				// 1. CHECK if Caixa is the lastest
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataFinal", caixa.DataFinal);

				string query = "SELECT COUNT(*) AS QUANT " +
					"FROM tblCaixa " +
					"WHERE IDConta = @IDConta " +
					"AND DataInicial >= @DataFinal " +
					"AND IDCaixa > @IDCaixa;";

				//--- execute SELECT
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
					throw new Exception("Consulta não retornou nenhum resultado...");

				if ((int)dt.Rows[0]["QUANT"] > 0)
					throw new AppException("Não é possível desbloquerar porque o caixa não é o último da Conta...");

				// 2. GET the PREVIOUS IDCAIXA to UNLOCK
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataInicial", caixa.DataInicial);

				query = "SELECT TOP 1 IDCaixa, CaixaFinalDoDia, DataFinal " +
					"FROM tblCaixa " +
					"WHERE IDConta = @IDConta " +
					"AND DataFinal <= @DataInicial " +
					"AND IDCaixa < @IDCaixa " +
					"ORDER BY IDCaixa DESC";

				//--- execute SELECT
				dt = db.ExecutarConsulta(CommandType.Text, query);
				DataRow dtRow = null;

				if (dt.Rows.Count > 0)
					dtRow = dt.Rows[0];

				// 3. UNBLOCK older Caixa Conta SET SITUACAO = 2
				//------------------------------------------------------------------------------------------------------------
				if (dtRow != null)
				{
					db.LimparParametros();

					//--- define Params
					db.AdicionarParametros("@IDCaixa", (long)dtRow["IDCaixa"]);

					//--- define query
					query = "UPDATE tblCaixa SET IDSituacao = 2 " +
						"WHERE IDCaixa = @IDCaixa";

					//--- execute update
					db.ExecutarManipulacao(CommandType.Text, query);
				}

				// 4. unBLOCK CONTA Date
				//------------------------------------------------------------------------------------------------------------
				if (dtRow != null)
				{
					DateTime blockDate = (bool)dtRow["CaixaFinalDoDia"] == false ? (DateTime)dtRow["DataFinal"] : ((DateTime)dtRow["DataFinal"]).AddDays(1);
					new ContaBLL().UpdateContaBloqueioData(caixa.IDConta, blockDate, db);

					oldDataPadraoConta = blockDate;
				}
				else
				{
					new ContaBLL().UpdateContaBloqueioData(caixa.IDConta, caixa.DataInicial, db);

					oldDataPadraoConta = caixa.DataInicial;
				}

				// 5. UPDATE Caixa
				//------------------------------------------------------------------------------------------------------------
				caixa.IDSituacao = 1;
				caixa.Situacao = "Iniciado";
				UpdateCaixa(caixa, db);

				// COMMIT and RETURN
				//------------------------------------------------------------------------------------------------------------
				db.CommitTransaction();
				return (DateTime)oldDataPadraoConta;
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// DELETE | REMOVE CAIXA
		//------------------------------------------------------------------------------------------------------------
		public void DeleteCaixa(objCaixa caixa)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				// 1. CHECK CAIXA
				//------------------------------------------------------------------------------------------------------------
				if (!verifyDeleting(caixa, db))
				{
					throw new AppException("Caixa não pode ser excluído porque existem outro(s) caixa(s) na mesma conta depois dele...");
				}

				// 2. REMOVE AJUSTES
				//------------------------------------------------------------------------------------------------------------
				new AjusteBLL().RemoveAjusteFromCaixa((long)caixa.IDCaixa, db);

				// 3. UPDATE MOVIMENTACAO
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.ConvertNullParams();

				string query = "UPDATE tblMovimentacao SET IDCaixa = NULL WHERE IDCaixa = @IDCaixa";

				//--- execute update
				db.ExecutarManipulacao(CommandType.Text, query);

				// 4. REMOVE OBSERVACAO
				//------------------------------------------------------------------------------------------------------------
				ObservacaoBLL oBLL = new ObservacaoBLL();
				oBLL.DeleteObservacao(3, (long)caixa.IDCaixa, db);

				// 5. DELETE CAIXA
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.ConvertNullParams();

				query = "DELETE tblCaixa WHERE IDCaixa = @IDCaixa";

				//--- execute update
				db.ExecutarManipulacao(CommandType.Text, query);

				// 6. COMMIT AND RETURN
				//------------------------------------------------------------------------------------------------------------
				db.CommitTransaction();

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// VERIFY BEFORE DELETING
		//------------------------------------------------------------------------------------------------------------
		private bool verifyDeleting(objCaixa caixa, AcessoDados dbTran)
		{
			try
			{
				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				dbTran.AdicionarParametros("@DataFinal", caixa.DataFinal);
				dbTran.AdicionarParametros("@IDConta", caixa.IDConta);
				dbTran.ConvertNullParams();

				string query = "SELECT COUNT(*) AS Total " +
					"FROM tblCaixa WHERE IDConta = @IDConta " +
					"AND DataFinal >= @DataFinal AND IDCaixa <> @IDCaixa";

				DataTable dt = dbTran.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new Exception("Não houve retorno na consulta de verificação de caixas");
				}

				if ((int)dt.Rows[0]["Total"] > 0)
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

		// GET LAST CAIXA CONTA
		//------------------------------------------------------------------------------------------------------------
		public objCaixa GetLastCaixa(int IDConta)
		{
			try
			{
				AcessoDados db = new AcessoDados();
				db.BeginTransaction();

				//--- get the MAXDATE to verify movimentacao and continue
				DateTime? MaxDate = GetMaxDateContaMov(IDConta, db);

				if (MaxDate == null)
				{
					throw new AppException("Essa Conta não possui nenhuma movimentação pendente de caixa...");
				}

				//--- get lastCaixa
				objCaixa LastCaixa = null;
				string query = "SELECT TOP 1 * FROM qryCaixa WHERE IDConta = @IDConta ORDER BY IDCaixa DESC";

				db.LimparParametros();
				db.AdicionarParametros("@IDConta", IDConta);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				//--- if LASTCaixa => NULL construct new objCaixa to return
				if (dt.Rows.Count == 0)
				{
					objConta conta = new ContaBLL().GetConta(IDConta, db);

					LastCaixa = new objCaixa(null)
					{
						DataFinal = (DateTime)MaxDate,
						DataInicial = GetMinDateContaMov(IDConta, db),
						IDConta = IDConta,
						CaixaFinalDoDia = false,
						Conta = conta.Conta,
						ContaBloqueioData = conta.BloqueioData,
						ContaSaldo = conta.ContaSaldo,
						FechamentoData = DateTime.Today,
						IDSituacao = 0,
						SaldoAnterior = 0,
						SaldoFinal = 0,
						Situacao = "Iniciado",
					};

					return LastCaixa;
				}

				//--- else convert DataRow in objCaixa
				LastCaixa = ConvertRowInClass(dt.Rows[0]);

				//--- Redefine control Dates
				LastCaixa.DataInicial = LastCaixa.CaixaFinalDoDia ? LastCaixa.DataFinal.AddDays(1) : LastCaixa.DataFinal;
				LastCaixa.DataFinal = (DateTime)MaxDate;

				return LastCaixa;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET MAX DATE MOVIMENTACAO BY IDCONTA
		//------------------------------------------------------------------------------------------------------------
		private DateTime? GetMaxDateContaMov(int IDConta, AcessoDados dbTran)
		{
			try
			{
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDConta", IDConta);

				string query = "SELECT MAX(MovData) AS MaxDate FROM qryMovimentacao WHERE IDConta = @IDConta AND IDCaixa IS NULL";

				DataTable dt = dbTran.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return null;
				}

				return dt.Rows[0][0] == DBNull.Value ? null : (DateTime?)dt.Rows[0][0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET MIN DATE MOVIMENTACAO BY IDCONTA
		//------------------------------------------------------------------------------------------------------------
		private DateTime GetMinDateContaMov(int IDConta, AcessoDados dbTran)
		{
			try
			{
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDConta", IDConta);

				string query = "SELECT MIN(MovData) AS MinDate FROM qryMovimentacao WHERE IDConta = @IDConta AND IDCaixa IS NULL";

				DataTable dt = dbTran.ExecutarConsulta(CommandType.Text, query);

				return (DateTime)dt.Rows[0][0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
