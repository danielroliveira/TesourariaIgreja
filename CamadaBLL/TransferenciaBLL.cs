using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	//=================================================================================================
	// TRANSFERENCIA DE CONTAS
	//=================================================================================================
	public class TransfContaBLL
	{

		// GET TRANSFERENCIA CONTA
		//------------------------------------------------------------------------------------------------------------
		public objTransfConta GetTransfContaByID(long IDTransfConta, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryTransfConta WHERE IDTransfConta = @IDTransfConta";
				db.LimparParametros();
				db.AdicionarParametros("@IDTransfConta", IDTransfConta);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRow_InClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET TRANSFERENCIA CONTA LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objTransfConta> GetTransfContaList(
			int? IDContaEntrada = null,
			int? IDContaSaida = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryTransfConta ";

				// add params
				db.LimparParametros();
				bool myWhere = false;

				// add IDContaEntrada
				if (IDContaEntrada != null)
				{
					db.AdicionarParametros("@IDContaEntrada", IDContaEntrada);
					query += " WHERE IDContaEntrada = @IDContaEntrada";
					myWhere = true;
				}

				// add IDContaSaida
				if (IDContaSaida != null)
				{
					db.AdicionarParametros("@IDContaSaida", IDContaSaida);
					query += myWhere ? " AND IDContaSaida = @IDContaSaida" : " WHERE IDContaSaida = @IDContaSaida";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND TransfData >= @DataInicial" : " WHERE TransfData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND TransfData <= @DataFinal" : " WHERE TransfData <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY TransfData";

				List<objTransfConta> listagem = new List<objTransfConta>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRow_InClass(row));
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
		public objTransfConta ConvertRow_InClass(DataRow row)
		{
			objTransfConta tConta = new objTransfConta(null)
			{
				IDTransfConta = (long)row["IDTransfConta"],
				IDContaEntrada = (int)row["IDContaEntrada"],
				ContaEntrada = (string)row["ContaEntrada"],
				IDContaSaida = (int)row["IDContaSaida"],
				ContaSaida = (string)row["ContaSaida"],
				Descricao = (string)row["Descricao"],
				TransfData = (DateTime)row["TransfData"],
				TransfValor = (decimal)row["TransfValor"],
			};

			return tConta;
		}

		// INSERT TRANSFERENCIA CONTA
		//------------------------------------------------------------------------------------------------------------
		public long InsertTransferenciaConta(objTransfConta Transf,
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
				db.AdicionarParametros("@TransfData", Transf.TransfData);
				db.AdicionarParametros("@TransfValor", Transf.TransfValor);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create insert string
				string query = db.CreateInsertSQL("tblTransfConta");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- 2. INSERT TRANSF ENTRADA
				//------------------------------------------------------------------------------------------------------------

				MovimentacaoBLL mBLL = new MovimentacaoBLL();

				//--- create transferencia de entrada
				objMovimentacao entrada = new objMovimentacao(null)
				{
					IDConta = Transf.IDContaEntrada,
					IDCaixa = null,
					IDSetor = null,
					Origem = EnumMovOrigem.TransfConta,
					IDOrigem = newID,
					MovData = Transf.TransfData,
					MovValor = Transf.TransfValor,
					MovTipo = 3,
					DescricaoOrigem = $"TRANSFERÊNCIA: entrada de {Transf.ContaSaida}",
				};

				//--- execute INSERT ENTRADA MOVIMENTACAO
				mBLL.InsertMovimentacao(entrada, ContaSdlUpdate, null, db);

				//--- 3. INSERT TRANSF SAIDA
				//------------------------------------------------------------------------------------------------------------

				//--- create transferencia de entrada
				objMovimentacao saida = new objMovimentacao(null)
				{
					IDConta = Transf.IDContaSaida,
					IDCaixa = null,
					IDSetor = null,
					Origem = EnumMovOrigem.TransfConta,
					IDOrigem = newID,
					MovData = Transf.TransfData,
					MovValor = Transf.TransfValor * (-1),
					MovTipo = 3,
					DescricaoOrigem = $"TRANSFERÊNCIA: saída para {Transf.ContaEntrada}",
				};

				//--- execute INSERT SAIDA MOVIMENTACAO
				mBLL.InsertMovimentacao(saida, ContaSdlUpdate, null, db);

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
				new MovimentacaoBLL().DeleteMovsByOrigem(EnumMovOrigem.TransfConta, (long)Transf.IDTransfConta, ContaSdlUpdate, null, db);

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


	}

	//=================================================================================================
	// TRANSFERENCIA DE SETOR
	//=================================================================================================
	public class TransfSetorBLL
	{

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

				return ConvertRow_InClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET TRANSFERENCIA SETOR LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objTransfSetor> GetTransfSetorList(
			int? IDSetorEntrada = null,
			int? IDSetorSaida = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT  * FROM qryTransfSetor ";

				// add params
				db.LimparParametros();
				bool myWhere = false;

				// add IDSetorEntrada
				if (IDSetorEntrada != null)
				{
					db.AdicionarParametros("@IDSetorEntrada", IDSetorEntrada);
					query += myWhere ? " AND IDSetorEntrada = @IDSetorEntrada" : " WHERE IDSetorEntrada = @IDSetorEntrada";
					myWhere = true;
				}

				// add IDSetorSaida
				if (IDSetorSaida != null)
				{
					db.AdicionarParametros("@IDSetorSaida", IDSetorSaida);
					query += myWhere ? " AND IDSetorSaida = @IDSetorSaida" : " WHERE IDSetorSaida = @IDSetorSaida";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND TransfData >= @DataInicial" : " WHERE TransfData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND TransfData <= @DataFinal" : " WHERE TransfData <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY TransfData";

				List<objTransfSetor> listagem = new List<objTransfSetor>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRow_InClass(row));
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
		public objTransfSetor ConvertRow_InClass(DataRow row)
		{
			objTransfSetor tSetor = new objTransfSetor(null)
			{
				IDTransfSetor = (long)row["IDTransfSetor"],
				IDSetorEntrada = (int)row["IDSetorEntrada"],
				SetorEntrada = (string)row["SetorEntrada"],
				IDSetorSaida = (int)row["IDSetorSaida"],
				SetorSaida = (string)row["SetorSaida"],
				Descricao = (string)row["Descricao"],
				TransfData = (DateTime)row["TransferenciaData"],
				TransfValor = (decimal)row["TransferenciaValor"],
			};

			return tSetor;
		}

		// INSERT TRANSFERENCIA SETOR
		//------------------------------------------------------------------------------------------------------------
		public long InsertTransferenciaSetor(objTransfSetor Transf, Action<int, decimal> SetorSdlUpdate)
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
				db.AdicionarParametros("@TransfData", Transf.TransfData);
				db.AdicionarParametros("@TransfValor", Transf.TransfValor);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create insert string
				string query = db.CreateInsertSQL("tblTransfSetor");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- 2. INSERT TRANSF ENTRADA
				//------------------------------------------------------------------------------------------------------------

				MovimentacaoBLL mBLL = new MovimentacaoBLL();

				//--- create transferencia de entrada
				objMovimentacao entrada = new objMovimentacao(null)
				{
					IDSetor = Transf.IDSetorEntrada,
					IDCaixa = null,
					IDConta = null,
					Origem = EnumMovOrigem.TransfSetor,
					IDOrigem = newID,
					MovData = Transf.TransfData,
					MovValor = Transf.TransfValor,
					DescricaoOrigem = $"TRANSFERÊNCIA: entrada de {Transf.SetorSaida}",
				};

				//--- execute INSERT ENTRADA MOVIMENTACAO
				mBLL.InsertMovimentacao(entrada, SetorSdlUpdate, null, db);

				//--- 3. INSERT TRANSF SAIDA
				//------------------------------------------------------------------------------------------------------------

				//--- create transferencia de entrada
				objMovimentacao saida = new objMovimentacao(null)
				{
					IDSetor = Transf.IDSetorSaida,
					IDCaixa = null,
					IDConta = null,
					Origem = EnumMovOrigem.TransfSetor,
					IDOrigem = newID,
					MovData = Transf.TransfData,
					MovValor = Transf.TransfValor * (-1),
					DescricaoOrigem = $"TRANSFERÊNCIA: saída para {Transf.SetorEntrada}",
				};

				//--- execute INSERT SAIDA MOVIMENTACAO
				mBLL.InsertMovimentacao(entrada, null, SetorSdlUpdate, db);

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
				new MovimentacaoBLL().DeleteMovsByOrigem(EnumMovOrigem.TransfSetor, (long)Transf.IDTransfSetor, null, SetorSdlUpdate, db);

				// 2. REMOVE TRANSF SETOR
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
