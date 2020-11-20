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

		// GET LIST OF BY IDCONTRIBUICAO
		//------------------------------------------------------------------------------------------------------------
		public List<objAReceber> GetListAReceberByIDContribuicao(long IDContribuicao, AcessoDados dbTran)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : dbTran;

				string query = "SELECT * FROM qryAReceber";

				// add params
				db.LimparParametros();

				db.AdicionarParametros("@IDContribuicao", IDContribuicao);
				query += " WHERE IDContribuicao = @IDContribuicao";

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
				IDMovProvisoria = (long)row["IDMovProvisoria"],
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
		public long InsertAReceber(objAReceber entrada, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@CompensacaoData", entrada.CompensacaoData);
				db.AdicionarParametros("@IDContribuicao", entrada.IDContribuicao);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@ValorLiquido", entrada.ValorLiquido);
				db.AdicionarParametros("@ValorRecebido", 0);
				db.AdicionarParametros("@IDContaProvisoria", entrada.IDContaProvisoria);
				db.AdicionarParametros("@IDMovProvisoria", entrada.IDMovProvisoria);
				db.AdicionarParametros("@IDSituacao", 1);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblAReceber");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA PROVISORIA
				//new ContaBLL().ContaSaldoChange(entrada.IDContaProvisoria, entrada.ValorBruto, db, ContaSldUpdate);

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// DELETE ARECEBER
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteAReceber(long IDAReceber, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAReceber", IDAReceber);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "DELETE tblAReceber WHERE IDAReceber = @IDAReceber";

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE ARECEBER SITUACAO || VALOR LIQUIDO || COMPENSACAO DATA
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAReceber(objAReceber rec, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAReceber", rec.IDAReceber);
				db.AdicionarParametros("@IDSituacao", rec.IDSituacao);
				db.AdicionarParametros("@ValorLiquido", rec.ValorLiquido);
				db.AdicionarParametros("@ValorRecebido", rec.ValorRecebido);
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

		// QUITAR A RECEBER LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objAReceber> AReceberConsolidacaoList(
			List<objAReceber> listRec,
			List<objMovimentacao> entradas,
			Action<int, decimal> contaSaldoUpdate,
			Action<int, decimal> setorSaldoUpdate)
		{
			List<objAReceber> retorno = new List<objAReceber>();
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				ContribuicaoBLL contBLL = new ContribuicaoBLL();

				foreach (objMovimentacao entrada in entradas)
				{
					objAReceber receber = listRec.First(r => r.IDAReceber == entrada.IDOrigem);

					if (receber.IDEntradaForma == 3) // IDEntradaForma : CARTAO
					{
						objAReceber newRec = insertAReceberCartao(receber, entrada, contaSaldoUpdate, setorSaldoUpdate, db);
						retorno.Add(newRec);
					}
					else
					{
						objAReceber newRec = insertAReceberCheque(receber, entrada, contaSaldoUpdate, db);
						retorno.Add(newRec);
					}

					// update Contribuicao
					contBLL.UpdateValorRecebidoAndCheckRealizado(receber.IDContribuicao, entrada.MovValor, db);

				}

				db.CommitTransaction();
				return retorno;
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT ENTRADA | ARECEBER CARTAO
		//------------------------------------------------------------------------------------------------------------
		private objAReceber insertAReceberCartao(
			objAReceber receber,
			objMovimentacao entrada,
			Action<int, decimal> contaSaldoUpdate,
			Action<int, decimal> setorSaldoUpdate,
			AcessoDados dbTran)
		{
			// create TRANSFER SAIDA
			objMovimentacao transfSaida = new objMovimentacao(null)
			{
				MovTipo = 3, // TRANSFERENCIA
				Origem = EnumMovOrigem.AReceber, // tblAReceber
				IDOrigem = (long)receber.IDAReceber,
				IDConta = receber.IDContaProvisoria,
				IDSetor = receber.IDSetor,
				MovData = entrada.MovData,
				MovValor = entrada.MovValor * (-1),
				DescricaoOrigem = "TRANSFERÊNCIA: Compensação de Cartao",
			};

			// create TRANSFER ENTRADA
			objMovimentacao transfEntrada = new objMovimentacao(null)
			{
				MovTipo = 3, // TRANSFERENCIA
				Origem = EnumMovOrigem.AReceber, // tblAReceber
				IDOrigem = (long)receber.IDAReceber,
				IDConta = entrada.IDConta,
				IDSetor = receber.IDSetor,
				MovData = entrada.MovData,
				MovValor = entrada.MovValor,
				DescricaoOrigem = "TRANSFERÊNCIA: Recebimento de Cartao",
			};

			// create SAIDA COMISSAO
			objMovimentacao saidaComissao = new objMovimentacao(null)
			{
				MovTipo = 2, // SAIDA
				Origem = EnumMovOrigem.AReceber, // tblAReceber 
				IDOrigem = (long)receber.IDAReceber,
				IDConta = receber.IDContaProvisoria,
				IDSetor = receber.IDSetor,
				MovData = entrada.MovData,
				MovValor = receber.ValorBruto - entrada.MovValor,
				DescricaoOrigem = "SAÍDA: Desconto Comissão de Cartao",
			};

			try
			{
				MovimentacaoBLL mBLL = new MovimentacaoBLL();

				// Update FIRST Entrada: CONSOLIDADO = TRUE
				mBLL.UpdateConsolidado(receber.IDMovProvisoria, true, dbTran);

				// Insert transf saida
				mBLL.InsertMovimentacao(transfSaida, contaSaldoUpdate, null, dbTran);

				// Insert transf entrada
				mBLL.InsertMovimentacao(transfEntrada, contaSaldoUpdate, null, dbTran);

				// Insert saida comissao
				mBLL.InsertMovimentacao(saidaComissao, contaSaldoUpdate, setorSaldoUpdate, dbTran);

				// update AReceber
				UpdateAReceber(receber, dbTran);

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return receber;
		}

		// INSERT ENTRADA | ARECEBER CHEQUE
		//------------------------------------------------------------------------------------------------------------
		private objAReceber insertAReceberCheque(
			objAReceber receber,
			objMovimentacao entrada,
			Action<int, decimal> contaSaldoUpdate,
			AcessoDados dbTran)
		{
			// create TRANSFER SAIDA
			objMovimentacao transfSaida = new objMovimentacao(null)
			{
				MovTipo = 3, // TRANSFERENCIA
				Origem = EnumMovOrigem.AReceber, // tblAReceber
				IDOrigem = (long)receber.IDAReceber,
				IDConta = receber.IDContaProvisoria,
				IDSetor = null,
				MovData = entrada.MovData,
				MovValor = entrada.MovValor * (-1),
				DescricaoOrigem = "TRANSFERÊNCIA: Depósito de Cheque",
			};

			// create TRANSFER ENTRADA
			objMovimentacao transfEntrada = new objMovimentacao(null)
			{
				MovTipo = 3, // TRANSFERENCIA
				Origem = EnumMovOrigem.AReceber, // tblAReceber
				IDOrigem = (long)receber.IDAReceber,
				IDConta = entrada.IDConta,
				IDSetor = null,
				MovData = entrada.MovData,
				MovValor = entrada.MovValor,
				DescricaoOrigem = "TRANSFERÊNCIA: Compensação de Cheque",
			};

			try
			{
				MovimentacaoBLL mBLL = new MovimentacaoBLL();

				// Update FIRST Entrada: CONSOLIDADO = TRUE
				mBLL.UpdateConsolidado(receber.IDMovProvisoria, true, dbTran);

				// Insert transf saida
				mBLL.InsertMovimentacao(transfSaida, contaSaldoUpdate, null, dbTran);

				// Insert transf entrada
				mBLL.InsertMovimentacao(transfEntrada, contaSaldoUpdate, null, dbTran);

				// update AReceber
				UpdateAReceber(receber, dbTran);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return receber;
		}

		// ESTORNA ARECEBER
		//------------------------------------------------------------------------------------------------------------
		public objAReceber estornaAReceber(objAReceber receber,
			Action<int, decimal> contaSaldoUpdate,
			Action<int, decimal> setorSaldoUpdate)
		{
			AcessoDados db = null;

			// UPDATE CONSOLIDADO ENTRADA = FALSE
			// DELETE TRANSFER ENTRADA / SAIDA
			// DELETE COMISSAO SAIDA
			// UPDATE A RECEBER
			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				MovimentacaoBLL mBLL = new MovimentacaoBLL();

				// Update FIRST Entrada: CONSOLIDADO = FALSE
				mBLL.UpdateConsolidado(receber.IDMovProvisoria, false, db);

				// REMOVE transf saida entrada
				mBLL.DeleteMovsByOrigem(EnumMovOrigem.AReceber, (long)receber.IDAReceber, contaSaldoUpdate, setorSaldoUpdate, db);

				// UPDATE Contribuicao
				var cBLL = new ContribuicaoBLL();
				cBLL.UpdateValorRecebidoEstorno(receber.IDContribuicao, receber.ValorRecebido, db);

				// UPDATE AReceber
				receber.ValorRecebido = 0;
				receber.IDSituacao = 1;
				receber.Situacao = "Em Aberto";
				UpdateAReceber(receber, db);

				// COMMIT
				db.CommitTransaction();

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}

			return receber;
		}
	}
}
