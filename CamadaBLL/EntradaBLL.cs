using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	class EntradaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objEntrada> GetListEntrada()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryEntrada";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDEntrada";

				List<objEntrada> listagem = new List<objEntrada>();
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
		public List<objEntrada> GetListEntrada(
			int? IDConta = null,
			int? IDSetor = null,
			byte? IDEntradaTipo = null,
			int? IDEntradaOrigem = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryEntrada";
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

				// add IDEntradaTipo
				if (IDEntradaTipo != null)
				{
					db.AdicionarParametros("@IDEntradaTipo", IDEntradaTipo);
					query += myWhere ? " AND IDEntradaTipo = @IDEntradaTipo" : " WHERE IDEntradaTipo = @IDEntradaTipo";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND EntradaData >= @DataInicial" : " WHERE EntradaData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND EntradaData <= @DataFinal" : " WHERE EntradaData <= @DataFinal";
					myWhere = true;
				}

				// add IDEntradaOrigem
				if (IDEntradaOrigem != null)
				{
					db.AdicionarParametros("@IDEntradaOrigem", IDEntradaOrigem);
					query += myWhere ? " AND IDEntradaOrigem = @IDEntradaOrigem" : " WHERE IDEntradaOrigem = @IDEntradaOrigem";
					myWhere = true;
				}

				query += " ORDER BY EntradaData";

				List<objEntrada> listagem = new List<objEntrada>();
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

		// GET Entrada
		//------------------------------------------------------------------------------------------------------------
		public objEntrada GetEntrada(long IDEntrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryEntrada WHERE IDEntrada = @IDEntrada";
				db.LimparParametros();
				db.AdicionarParametros("@IDEntrada", IDEntrada);

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
		public objEntrada ConvertRowInClass(DataRow row)
		{
			objEntrada entrada = new objEntrada((long)row["IDEntrada"])
			{
				EntradaData = (DateTime)row["EntradaData"],
				EntradaValor = (decimal)row["EntradaValor"],
				EntradaTipo = new objEntradaTipo()
				{
					IDEntradaTipo = (int)row["IDEntradaTipo"],
					EntradaTipo = (string)row["EntradaTipo"]
				},
				IDSetor = row["IDSetor"] == DBNull.Value ? null : (int?)row["IDSetor"],
				Setor = row["Setor"] == DBNull.Value ? "A DEFINIR" : (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				EntradaOrigem = new objEntradaOrigem()
				{
					IDEntradaOrigem = (int)row["IDEntradaOrigem"],
					OrigemDescricao = (string)row["OrigemDescricao"],
					CNP = (string)row["CNP"]
				},
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertEntrada(
			objEntrada cont,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate)
		{
			AcessoDados db = new AcessoDados();
			long? newID = null;
			objMovimentacao entrada = null;

			try
			{
				db.BeginTransaction();

				//--- Check Conta Bloqueio
				if (!new ContaBLL().ContaDateBlockPermit(cont.IDConta, cont.EntradaData, db))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data de Crédito proposta...", 2);
				}

				//--- Insert Entrada
				newID = AddEntrada(cont, db);

				//--- Create NEW Entrada
				entrada = new objMovimentacao(null)
				{
					MovTipo = 1,
					IDConta = cont.IDConta,
					IDSetor = cont.IDSetor,
					IDOrigem = (long)newID,
					Origem = EnumMovOrigem.Entrada,
					MovData = cont.EntradaData,
					MovValor = cont.EntradaValor,
					Consolidado = true,
					DescricaoOrigem = "ENTRADA: " + cont.EntradaOrigem.OrigemDescricao,
				};

				//--- Insert MOVIMENTACAO Entrada
				new MovimentacaoBLL().InsertMovimentacao(entrada, ContaSldLocalUpdate, SetorSldLocalUpdate, db);

				if (newID == 0)
				{
					throw new Exception("Não foi possível inserir um novo registro de Entrada...");
				}

				db.CommitTransaction();
				return (long)newID;

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT Entrada SIMPLES
		//------------------------------------------------------------------------------------------------------------
		private long AddEntrada(objEntrada cont, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@EntradaData", cont.EntradaData);
				dbTran.AdicionarParametros("@EntradaValor", cont.EntradaValor);
				dbTran.AdicionarParametros("@IDEntradaTipo", cont.EntradaTipo.IDEntradaTipo);
				dbTran.AdicionarParametros("@IDSetor", cont.IDSetor);
				dbTran.AdicionarParametros("@IDConta", cont.IDConta);
				dbTran.AdicionarParametros("@IDEntradaOrigem", cont.EntradaOrigem.IDEntradaOrigem);
				dbTran.AdicionarParametros("@EntradaDescricao", cont.EntradaDescricao);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblEntrada");

				//--- insert and Get new ID
				long newID = dbTran.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateEntrada(objEntrada entrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDEntrada", entrada.IDEntrada);
				db.AdicionarParametros("@EntradaData", entrada.EntradaData);
				db.AdicionarParametros("@EntradaValor", entrada.EntradaValor);
				db.AdicionarParametros("@IDEntradaTipo", entrada.EntradaTipo.IDEntradaTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDEntradaOrigem", entrada.EntradaOrigem.IDEntradaOrigem);
				db.AdicionarParametros("@EntradaDescricao", entrada.EntradaDescricao);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblEntrada", "@IDEntrada");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteEntrada(long IDEntrada,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// 1 - CHECK Movs
				//------------------------------------------------------------------------------------------------------------
				List<objMovimentacao> listMovs = new List<objMovimentacao>();

				if (!VerifyBeforeDelete(IDEntrada, ref listMovs, dbTran)) return false;

				// 2 - delete ALL MOVIMENTACAO ENTRADA 
				//------------------------------------------------------------------------------------------------------------
				if (listMovs.Count > 0)
				{
					MovimentacaoBLL mBLL = new MovimentacaoBLL();
					mBLL.DeleteMovimentacaoList(listMovs, ContaSdlUpdate, SetorSdlUpdate, dbTran);
				}

				// 3 - delete Entrada
				//------------------------------------------------------------------------------------------------------------

				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDEntrada", IDEntrada);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				//--- create query
				string query = "DELETE tblEntrada WHERE IDEntrada = @IDEntrada";

				//--- DELETE
				dbTran.ExecutarManipulacao(CommandType.Text, query);

				//--- COMMIT AND RETURN
				dbTran.CommitTransaction();
				return true;
			}
			catch (AppException ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

		private bool VerifyBeforeDelete(long IDEntrada,
			ref List<objMovimentacao> listMovs,
			AcessoDados dbTran)
		{
			try
			{
				bool err = false;
				string errMessage = "";

				// VERIFY MOVIMENTACAO ENTRADA FROM Entrada
				//------------------------------------------------------------------------------------------------------------
				MovimentacaoBLL mBLL = new MovimentacaoBLL();
				listMovs = mBLL.GetMovimentacaoListByOrigem(EnumMovOrigem.Entrada, IDEntrada, false, dbTran);

				// VERIFY RECEBIMENTOS WITH CAIXA OR BLOCKED
				//------------------------------------------------------------------------------------------------------------
				errMessage = "Essa Entrada possui movimentações que foram inseridas no caixa...\n";

				foreach (objMovimentacao entrada in listMovs)
				{
					if (entrada.IDCaixa != null)
					{
						errMessage += $"Reg.: {entrada.IDMovimentacao:D4} | {entrada.MovData.ToShortDateString()} | Caixa: {entrada.IDCaixa:D4}\n";
						err = true;
					}
				}

				if (err == true)
				{
					errMessage += "Favor remover o(s) caixa(s) se desejar EXCLUIR a(s) Entrada.";
					throw new AppException(errMessage);
				}

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
