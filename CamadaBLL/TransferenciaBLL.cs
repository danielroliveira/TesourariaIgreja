using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class TransferenciaBLL
	{
		//=================================================================================================
		// TRANSFERENCIA BLL
		//=================================================================================================

		// GET TRANSFERENCIA
		//------------------------------------------------------------------------------------------------------------
		public objTransferencia GetTransferencia(long IDTransferencia, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryTransferencia WHERE IDTransferencia = @IDTransferencia";
				db.LimparParametros();
				db.AdicionarParametros("@IDTransferencia", IDTransferencia);

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
		public objTransferencia ConvertRowInClass(DataRow row)
		{
			objTransferencia entrada = new objTransferencia((long)row["IDTransferencia"])
			{
				TransferenciaData = (DateTime)row["TransferenciaData"],
				IDOrigem = (long)row["IDOrigem"],
				Origem = (int)row["Origem"],
				TransferenciaValor = (decimal)row["TransferenciaValor"],
				IDSetor = row["IDSetor"] == DBNull.Value ? null : (int?)row["IDSetor"],
				Setor = row["Setor"] == DBNull.Value ? string.Empty : (string)row["Setor"],
				IDConta = row["IDConta"] == DBNull.Value ? null : (int?)row["IDConta"],
				Conta = row["Conta"] == DBNull.Value ? string.Empty : (string)row["Conta"],
				IDCaixa = row["IDCaixa"] == DBNull.Value ? null : (long?)row["IDCaixa"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertTransferencia(objTransferencia transf,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", transf.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", transf.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", transf.IDOrigem);
				db.AdicionarParametros("@Origem", transf.Origem);
				db.AdicionarParametros("@IDSetor", transf.IDSetor);
				db.AdicionarParametros("@IDConta", transf.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblTransferencias");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA
				if (transf.IDConta != null)
				{
					new ContaBLL().ContaSaldoChange((int)transf.IDConta, transf.TransferenciaValor, db, ContaSdlUpdate);
				}

				//--- altera o saldo do SETOR
				if (transf.IDSetor != null)
				{
					new SetorBLL().SetorSaldoChange((int)transf.IDSetor, transf.TransferenciaValor, db, SetorSdlUpdate);
				}

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// REMOVE DELETE TRANSFERENCIA BY ORIGEM AND IDORIGEM
		//------------------------------------------------------------------------------------------------------------
		public void RemoveTransferenciaByOrigem(
			int Origem,
			long IDOrigem,
			Action<int, decimal> ContaSdlUpdate = null,
			Action<int, decimal> SetorSdlUpdate = null,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;
			List<objTransferencia> ListTransf = new List<objTransferencia>();
			string query = "";

			try
			{
				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDOrigem", IDOrigem);
				db.AdicionarParametros("@Origem", Origem);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create SELECT query
				query = "SELECT * FROM qryTransferencia WHERE Origem = @Origem AND IDOrigem = @IDOrigem";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);
				if (dt.Rows.Count == 0)
				{
					throw new AppException("Não foi encontrada nenhuma transferência com a Origem informada...");
				}

				foreach (DataRow row in dt.Rows)
				{
					var transf = ConvertRowInClass(row);

					//--- Check is Caixa
					if (transf.IDCaixa != null)
					{
						throw new AppException("A Transferência não pode ser removida porque está anexada a um caixa...");
					}

					//--- Check is ContaDateBlock
					if (!new ContaBLL().ContaDateBlockPermit((int)transf.IDConta, transf.TransferenciaData, db))
					{
						throw new AppException("A Transferência não pode ser removida porque a Data está bloqueada na Conta...");
					}

					ListTransf.Add(transf);
				}

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- Get OLD Values
				foreach (objTransferencia transf in ListTransf)
				{
					//--- clear Params
					db.LimparParametros();

					//--- define Params
					db.AdicionarParametros("@IDOrigem", IDOrigem);
					db.AdicionarParametros("@Origem", Origem);
					db.AdicionarParametros("@IDConta", transf.IDConta);

					//--- convert null parameters
					db.ConvertNullParams();

					//--- Delete Transferencia
					query = "DELETE tblTransferencias WHERE Origem = @Origem AND IDOrigem = @IDOrigem AND IDConta = @IDConta";
					db.ExecutarManipulacao(CommandType.Text, query);

					//--- altera o saldo da CONTA
					if (transf.IDConta != null)
					{
						if (ContaSdlUpdate == null)
						{
							throw new Exception("Não foi informado o delegate de alteração do SALDO DA CONTA...");
						}
						new ContaBLL().ContaSaldoChange((int)transf.IDConta, transf.TransferenciaValor * (-1), db, ContaSdlUpdate);
					}

					//--- altera o saldo do SETOR
					if (transf.IDSetor != null)
					{
						if (SetorSdlUpdate == null)
						{
							throw new Exception("Não foi informado o delegate de alteração do SALDO DO SETOR...");
						}
						new SetorBLL().SetorSaldoChange((int)transf.IDSetor, transf.TransferenciaValor * (-1), db, SetorSdlUpdate);
					}
				}

				if (dbTran == null) db.CommitTransaction();

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		//=================================================================================================
		// TRANSFERENCIA DE CONTAS
		//=================================================================================================

		// GET TRANSFERENCIA CONTA
		//------------------------------------------------------------------------------------------------------------
		public objTransfConta GetTransfContaByID(long IDTransfConta, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryTransfConta WHERE IDTransfConta = @IDTransfConta AND TransferenciaValor > 0";
				db.LimparParametros();
				db.AdicionarParametros("@IDTransfConta", IDTransfConta);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowTC_InClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET TRANSFERENCIA CONTA LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objTransfConta> GetTransfContaList(
			bool entrada,
			int? IDConta = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT " +
					"IDTransfConta, " +
					"IDContaEntrada, " +
					"ContaEntrada, " +
					"IDContaSaida, " +
					"ContaSaida, " +
					"TransferenciaData, " +
					"TransferenciaValor, " +
					"Descricao, " +
					"IDTransferencia " +
					"FROM qryTransfConta ";

				// add params
				db.LimparParametros();

				if (entrada)
				{
					query += " WHERE TransferenciaValor > 0 ";
				}
				else // saida
				{
					query += " WHERE TransferenciaValor < 0 ";
				}

				// add IDConta
				if (IDConta != null)
				{
					db.AdicionarParametros("@IDConta", IDConta);
					query += " AND IDConta = @IDConta";
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += " AND TransferenciaData >= @DataInicial";
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += " AND TransferenciaData <= @DataFinal";
				}

				query += " ORDER BY TransferenciaData";

				List<objTransfConta> listagem = new List<objTransfConta>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowTC_InClass(row));
				}

				return listagem;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW TRANSFERENCIA CONTA IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objTransfConta ConvertRowTC_InClass(DataRow row)
		{
			objTransferencia entrada = new objTransferencia((long)row["IDTransferencia"])
			{
				TransferenciaData = (DateTime)row["TransferenciaData"],
				TransferenciaValor = (decimal)row["TransferenciaValor"],
			};

			objTransfConta tConta = new objTransfConta(null)
			{
				IDTransfConta = (long)row["IDTransfConta"],
				IDContaEntrada = (int)row["IDContaEntrada"],
				ContaEntrada = (string)row["ContaEntrada"],
				IDContaSaida = (int)row["IDContaSaida"],
				ContaSaida = (string)row["ContaSaida"],
				Descricao = (string)row["Descricao"],
				Transferencia = entrada
			};

			return tConta;
		}

		// INSERT TRANSFERENCIA CONTA
		//------------------------------------------------------------------------------------------------------------
		public long InsertTranferenciaConta(objTransfConta Transf,
			Action<int, decimal> ContaSdlUpdate)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- 1. INSERT TRANSF CONTA
				//------------------------------------------------------------------------------------------------------------

				//--- clear Params
				db.LimparParametros();

				//--- params
				db.AdicionarParametros("@IDContaEntrada", Transf.IDContaEntrada);
				db.AdicionarParametros("@IDContaSaida", Transf.IDContaSaida);
				db.AdicionarParametros("@Descricao", Transf.Descricao);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create insert string
				string query = db.CreateInsertSQL("tblTransfConta");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- 2. INSERT TRANSF ENTRADA
				//------------------------------------------------------------------------------------------------------------

				//--- create transferencia de entrada
				objTransferencia entrada = new objTransferencia(null)
				{
					IDConta = Transf.IDContaEntrada,
					IDCaixa = null,
					IDSetor = null,
					Origem = 1,
					IDOrigem = newID,
					TransferenciaData = Transf.Transferencia.TransferenciaData,
					TransferenciaValor = Transf.Transferencia.TransferenciaValor,
				};

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", entrada.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", entrada.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", entrada.IDOrigem);
				db.AdicionarParametros("@Origem", entrada.Origem);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				query = db.CreateInsertSQL("tblTransferencias");

				//--- insert ENTRADA and Get new ID
				db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA DE ENTRADA
				new ContaBLL().ContaSaldoChange((int)entrada.IDConta, entrada.TransferenciaValor, db, ContaSdlUpdate);

				//--- 3. INSERT TRANSF SAIDA
				//------------------------------------------------------------------------------------------------------------

				//--- create transferencia de entrada
				objTransferencia saida = new objTransferencia(null)
				{
					IDConta = Transf.IDContaSaida,
					IDCaixa = null,
					IDSetor = null,
					Origem = 1,
					IDOrigem = newID,
					TransferenciaData = Transf.Transferencia.TransferenciaData,
					TransferenciaValor = Transf.Transferencia.TransferenciaValor * (-1),
				};

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", saida.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", saida.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", saida.IDOrigem);
				db.AdicionarParametros("@Origem", saida.Origem);
				db.AdicionarParametros("@IDSetor", saida.IDSetor);
				db.AdicionarParametros("@IDConta", saida.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				query = db.CreateInsertSQL("tblTransferencias");

				//--- insert SAIDA and Get new ID
				db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA DE SAIDA
				new ContaBLL().ContaSaldoChange((int)saida.IDConta, saida.TransferenciaValor, db, ContaSdlUpdate);

				//--- COMMIT and RETURN
				db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// DELETE TRANFERENCIA CONTA
		//------------------------------------------------------------------------------------------------------------
		public void DeleteTransferenciaConta(objTransfConta Transf,
			Action<int, decimal> ContaSdlUpdate)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				// 1. TRY REMOVE TRANSFERENCIA (entrada e saida)
				//------------------------------------------------------------------------------------------------------------
				RemoveTransferenciaByOrigem(1, (long)Transf.IDTransfConta, ContaSdlUpdate, null, db);

				// 2. REMOVE TRANSF CONTA
				//------------------------------------------------------------------------------------------------------------
				string query = "DELETE tblTransfConta WHERE IDTransfConta = @IDTransfConta";

				//--- clear and insert params
				db.LimparParametros();
				db.AdicionarParametros("@IDTransfConta", Transf.IDTransfConta);

				//--- execute
				db.ExecutarManipulacao(CommandType.Text, query);

				// 3. COMMIT TRANSACTION
				//------------------------------------------------------------------------------------------------------------
				db.CommitTransaction();
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		//=================================================================================================
		// TRANSFERENCIA DE SETOR
		//=================================================================================================

		// GET TRANSFERENCIA SETOR
		//------------------------------------------------------------------------------------------------------------
		public objTransfSetor GetTransfSetorByID(long IDTransfSetor, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryTransfSetor WHERE IDTransfSetor = @IDTransfSetor AND TransferenciaValor > 0";
				db.LimparParametros();
				db.AdicionarParametros("@IDTransfSetor", IDTransfSetor);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowTS_InClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET TRANSFERENCIA SETOR LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objTransfSetor> GetTransfSetorList(
			bool entrada,
			int? IDSetor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT " +
					"IDTransfSetor, " +
					"IDSetorEntrada, " +
					"SetorEntrada, " +
					"IDSetorSaida, " +
					"SetorSaida, " +
					"TransferenciaData, " +
					"TransferenciaValor, " +
					"Descricao, " +
					"IDTransferencia " +
					"FROM qryTransfSetor ";

				// add params
				db.LimparParametros();

				if (entrada)
				{
					query += " WHERE TransferenciaValor > 0 ";
				}
				else // saida
				{
					query += " WHERE TransferenciaValor < 0 ";
				}

				// add IDSetor
				if (IDSetor != null)
				{
					db.AdicionarParametros("@IDSetor", IDSetor);
					query += " AND IDSetor = @IDSetor";
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += " AND TransferenciaData >= @DataInicial";
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += " AND TransferenciaData <= @DataFinal";
				}

				query += " ORDER BY TransferenciaData";

				List<objTransfSetor> listagem = new List<objTransfSetor>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowTS_InClass(row));
				}

				return listagem;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW TRANSFERENCIA SETOR IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objTransfSetor ConvertRowTS_InClass(DataRow row)
		{
			objTransferencia entrada = new objTransferencia((long)row["IDTransferencia"])
			{
				TransferenciaData = (DateTime)row["TransferenciaData"],
				TransferenciaValor = (decimal)row["TransferenciaValor"],
			};

			objTransfSetor tSetor = new objTransfSetor(null)
			{
				IDTransfSetor = (long)row["IDTransfSetor"],
				IDSetorEntrada = (int)row["IDSetorEntrada"],
				SetorEntrada = (string)row["SetorEntrada"],
				IDSetorSaida = (int)row["IDSetorSaida"],
				SetorSaida = (string)row["SetorSaida"],
				Descricao = (string)row["Descricao"],
				Transferencia = entrada
			};

			return tSetor;
		}

		// INSERT TRANSFERENCIA SETOR
		//------------------------------------------------------------------------------------------------------------
		public long InsertTranferenciaSetor(objTransfSetor Transf,
			Action<int, decimal> SetorSdlUpdate)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();


				//--- 1. INSERT TRANSF SETOR
				//------------------------------------------------------------------------------------------------------------

				//--- clear Params
				db.LimparParametros();

				//--- params
				db.AdicionarParametros("@IDSetorEntrada", Transf.IDSetorEntrada);
				db.AdicionarParametros("@IDSetorSaida", Transf.IDSetorSaida);
				db.AdicionarParametros("@Descricao", Transf.Descricao);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create insert string
				string query = db.CreateInsertSQL("tblTransfSetor");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- 2. INSERT TRANSF ENTRADA
				//------------------------------------------------------------------------------------------------------------

				//--- create transferencia de entrada
				objTransferencia entrada = new objTransferencia(null)
				{
					IDSetor = Transf.IDSetorEntrada,
					IDCaixa = null,
					IDConta = null,
					Origem = 2,
					IDOrigem = newID,
					TransferenciaData = Transf.Transferencia.TransferenciaData,
					TransferenciaValor = Transf.Transferencia.TransferenciaValor,
				};

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", entrada.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", entrada.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", entrada.IDOrigem);
				db.AdicionarParametros("@Origem", entrada.Origem);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);

				//--- convert null parameters
				db.ConvertNullParams();

				query = db.CreateInsertSQL("tblTransferencias");

				//--- insert ENTRADA and Get new ID
				db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA DE ENTRADA
				new SetorBLL().SetorSaldoChange((int)entrada.IDSetor, entrada.TransferenciaValor, db, SetorSdlUpdate);

				//--- 3. INSERT TRANSF SAIDA
				//------------------------------------------------------------------------------------------------------------

				//--- create transferencia de entrada
				objTransferencia saida = new objTransferencia(null)
				{
					IDSetor = Transf.IDSetorSaida,
					IDCaixa = null,
					IDConta = null,
					Origem = 2,
					IDOrigem = newID,
					TransferenciaData = Transf.Transferencia.TransferenciaData,
					TransferenciaValor = Transf.Transferencia.TransferenciaValor * (-1),
				};

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", saida.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", saida.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", saida.IDOrigem);
				db.AdicionarParametros("@Origem", saida.Origem);
				db.AdicionarParametros("@IDConta", saida.IDConta);
				db.AdicionarParametros("@IDSetor", saida.IDSetor);

				//--- convert null parameters
				db.ConvertNullParams();

				query = db.CreateInsertSQL("tblTransferencias");

				//--- insert SAIDA and Get new ID
				db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA DE SAIDA
				new SetorBLL().SetorSaldoChange((int)saida.IDSetor, saida.TransferenciaValor, db, SetorSdlUpdate);

				//--- COMMIT and RETURN
				db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// DELETE TRANFERENCIA SETOR
		//------------------------------------------------------------------------------------------------------------
		public void DeleteTransferenciaSetor(objTransfSetor Transf,
			Action<int, decimal> SetorSdlUpdate)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				// 1. TRY REMOVE TRANSFERENCIA (entrada e saida)
				//------------------------------------------------------------------------------------------------------------
				RemoveTransferenciaByOrigem(2, (long)Transf.IDTransfSetor, null, SetorSdlUpdate, db);

				// 2. REMOVE TRANSF CONTA
				//------------------------------------------------------------------------------------------------------------
				string query = "DELETE tblTransfSetor WHERE IDTransfSetor = @IDTransfSetor";

				//--- clear and insert params
				db.LimparParametros();
				db.AdicionarParametros("@IDTransfSetor", Transf.IDTransfSetor);

				//--- execute
				db.ExecutarManipulacao(CommandType.Text, query);

				// 3. COMMIT TRANSACTION
				//------------------------------------------------------------------------------------------------------------
				db.CommitTransaction();
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
