using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class ContribuicaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicao> GetListContribuicao()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDContribuicao";

				List<objContribuicao> listagem = new List<objContribuicao>();
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
		public List<objContribuicao> GetListContribuicao(
			int? IDConta = null,
			int? IDSetor = null,
			byte? IDEntradaForma = null,
			byte? IDContribuicaoTipo = null,
			int? IDContribuinte = null,
			int? IDCampanha = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao";
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

				// add IDEntradaForma
				if (IDEntradaForma != null)
				{
					db.AdicionarParametros("@IDEntradaForma", IDEntradaForma);
					query += myWhere ? " AND IDEntradaForma = @IDEntradaForma" : " WHERE IDEntradaForma = @IDEntradaForma";
					myWhere = true;
				}

				// add IDContribuicaoTipo
				if (IDContribuicaoTipo != null)
				{
					db.AdicionarParametros("@IDContribuicaoTipo", IDContribuicaoTipo);
					query += myWhere ? " AND IDContribuicaoTipo = @IDContribuicaoTipo" : " WHERE IDContribuicaoTipo = @IDContribuicaoTipo";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND ContribuicaoData >= @DataInicial" : " WHERE ContribuicaoData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND ContribuicaoData <= @DataFinal" : " WHERE ContribuicaoData <= @DataFinal";
					myWhere = true;
				}

				// add IDContribuinte
				if (IDContribuinte != null)
				{
					db.AdicionarParametros("@IDContribuinte", IDContribuinte);
					query += myWhere ? " AND IDContribuinte = @IDContribuinte" : " WHERE IDContribuinte = @IDContribuinte";
					myWhere = true;
				}

				// add IDCampanha
				if (IDCampanha != null)
				{
					db.AdicionarParametros("@IDCampanha", IDCampanha);
					query += myWhere ? " AND IDCampanha = @IDCampanha" : " WHERE IDCampanha = @IDCampanha";
					myWhere = true;
				}

				query += " ORDER BY ContribuicaoData";

				List<objContribuicao> listagem = new List<objContribuicao>();
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

		// GET CONTRIBUICAO
		//------------------------------------------------------------------------------------------------------------
		public objContribuicao GetContribuicao(long IDContribuicao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao WHERE IDContribuicao = @IDContribuicao";
				db.LimparParametros();
				db.AdicionarParametros("@IDContribuicao", IDContribuicao);

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
		public objContribuicao ConvertRowInClass(DataRow row)
		{
			objContribuicao entrada = new objContribuicao((long)row["IDContribuicao"])
			{
				ContribuicaoData = (DateTime)row["ContribuicaoData"],
				IDEntradaForma = (byte)row["IDEntradaForma"],
				EntradaForma = (string)row["EntradaForma"],
				ValorBruto = (decimal)row["ValorBruto"],
				IDContribuicaoTipo = (byte)row["IDContribuicaoTipo"],
				ContribuicaoTipo = (string)row["ContribuicaoTipo"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				IDContribuinte = row["IDContribuinte"] == DBNull.Value ? null : (int?)row["IDContribuinte"],
				Contribuinte = row["Contribuinte"] == DBNull.Value ? null : (string)row["Contribuinte"],
				OrigemDescricao = row["OrigemDescricao"] == DBNull.Value ? null : (string)row["OrigemDescricao"],
				IDReuniao = row["IDReuniao"] == DBNull.Value ? null : (int?)row["IDReuniao"],
				Reuniao = row["Reuniao"] == DBNull.Value ? null : (string)row["Reuniao"],
				IDCampanha = row["IDCampanha"] == DBNull.Value ? null : (int?)row["IDCampanha"],
				Campanha = row["Campanha"] == DBNull.Value ? null : (string)row["Campanha"],
				ValorRecebido = (decimal)row["ValorRecebido"],
				Realizado = (bool)row["Realizado"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertContribuicao(
			objContribuicao cont,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate,
			object forma = null)
		{
			AcessoDados db = new AcessoDados();
			long? newID = null;
			long? newMovID = null;
			objMovimentacao entrada = null;

			try
			{
				db.BeginTransaction();

				//--- Check Conta Bloqueio
				if (!new ContaBLL().ContaDateBlockPermit(cont.IDConta, cont.ContribuicaoData, db))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data de Crédito proposta...", 2);
				}

				switch (cont.IDEntradaForma)
				{
					case 1: // DINHEIRO

						//--- Insert Contribuicao
						cont.Realizado = true;
						cont.ValorRecebido = cont.ValorBruto;
						newID = AddContribuicao(cont, db);

						//--- Create NEW Entrada
						entrada = new objMovimentacao(null)
						{
							MovTipo = 1,
							IDConta = cont.IDConta,
							IDSetor = cont.IDSetor,
							IDOrigem = (long)newID,
							Origem = EnumMovOrigem.Contribuicao,
							MovData = cont.ContribuicaoData,
							MovValor = cont.ValorBruto,
							Consolidado = true,
							DescricaoOrigem = "CONTRIBUIÇÃO: " + cont.OrigemDescricao,
						};

						//--- Insert MOVIMENTACAO Entrada
						new MovimentacaoBLL().InsertMovimentacao(entrada, ContaSldLocalUpdate, SetorSldLocalUpdate, db);

						break;

					case 2: // CHEQUE

						if (forma == null || forma.GetType() != typeof(objContribuicaoCheque))
							throw new Exception("Não há registro de informação do cheque...");

						//--- Insert Contribuicao
						cont.Realizado = false;
						cont.ValorRecebido = 0;
						newID = AddContribuicao(cont, db);
						cont.IDContribuicao = newID;

						//--- Insert ContribuicaoCheque
						objContribuicaoCheque cheque = (objContribuicaoCheque)forma;

						cheque.IDContribuicao = newID;
						AddContribuicaoCheque(cheque, db);

						//--- Create NEW MOVIMENTACAO ENTRADA
						entrada = new objMovimentacao(null)
						{
							MovTipo = 1,
							IDConta = cont.IDConta,
							IDSetor = cont.IDSetor,
							IDOrigem = (long)newID,
							Origem = EnumMovOrigem.Contribuicao,
							MovData = cont.ContribuicaoData,
							MovValor = cont.ValorBruto,
							Consolidado = false,
							DescricaoOrigem = $"CONTRIBUIÇÃO: Cheque no. {cheque.ChequeNumero} {cheque.Banco}",
						};

						//--- Insert MOVIMENTACAO Entrada
						newMovID = new MovimentacaoBLL().InsertMovimentacao(entrada, ContaSldLocalUpdate, SetorSldLocalUpdate, db);

						//--- Create AReceber
						var areceber = new objAReceber(null)
						{
							CompensacaoData = cheque.DepositoData,
							IDContaProvisoria = cont.IDConta,
							IDContribuicao = (long)cont.IDContribuicao,
							IDSituacao = 1,
							Situacao = "Em Aberto",
							ValorBruto = cont.ValorBruto,
							ValorLiquido = cont.ValorBruto,
							ValorRecebido = 0,
							IDMovProvisoria = (long)newMovID,
						};

						//--- Insert AReceber Parcela
						new AReceberBLL().InsertAReceber(areceber, db);

						break;

					case 3: // CARTAO

						if (forma == null || forma.GetType() != typeof(objContribuicaoCartao))
							throw new Exception("Não há registro de informação do cartão...");

						//--- Check Conta Bloqueio
						objContribuicaoCartao cartao = (objContribuicaoCartao)forma;

						if (!new ContaBLL().ContaDateBlockPermit(cartao.IDContaProvisoria, cont.ContribuicaoData, db))
						{
							throw new AppException("A Data da Conta está BLOQUEADA nesta Data de Crédito proposta...", 2);
						}

						//--- Insert Contribuicao
						cont.Realizado = false;
						cont.ValorRecebido = 0;
						newID = AddContribuicao(cont, db);
						cont.IDContribuicao = newID;

						//--- Insert ContribuicaoCartao
						cartao.IDContribuicao = newID;
						AddContribuicaoCartao(cartao, db);

						//--- Insert ListOf AReceber
						var listAReceber = new List<objAReceber>();

						int parcelas = cartao.Parcelas == 0 ? 1 : cartao.Parcelas;

						// create PARCELAS
						for (int i = 0; i < parcelas; i++)
						{
							var parcela = new objAReceber(null)
							{
								CompensacaoData = cont.ContribuicaoData.AddDays(cartao.Prazo * (i + 1)),
								IDContaProvisoria = cartao.IDContaProvisoria,
								IDContribuicao = (long)cont.IDContribuicao,
								IDSituacao = 1,
								Situacao = "Em Aberto",
								ValorBruto = cont.ValorBruto / parcelas,
								ValorLiquido = (cont.ValorBruto / parcelas) * (100 - cartao.TaxaAplicada) / 100,
								ValorRecebido = 0
							};

							listAReceber.Add(parcela);
						}

						var rBLL = new AReceberBLL();
						var mBLL = new MovimentacaoBLL();

						int numParcela = 1;

						//--- Insert ListOf AReceber Parcelas
						foreach (var parcela in listAReceber)
						{
							//--- Create NEW MOVIMENTACAO Entrada
							entrada = new objMovimentacao(null)
							{
								MovTipo = 1,
								IDConta = parcela.IDContaProvisoria,
								IDSetor = cont.IDSetor,
								IDOrigem = (long)newID,
								Origem = EnumMovOrigem.Contribuicao,
								MovData = cont.ContribuicaoData,
								MovValor = parcela.ValorBruto,
								Consolidado = false,
							};

							//--- define descricao origem of movimentacao
							if (cartao.Parcelas == 0)
							{
								entrada.DescricaoOrigem = $"CONTRIBUIÇÃO: Cartão de Débito {cartao.CartaoBandeira}";
							}
							else if (cartao.Parcelas == 1)
							{
								entrada.DescricaoOrigem = $"CONTRIBUIÇÃO: Cartão de Crédito {cartao.CartaoBandeira}";
							}
							else
							{
								entrada.DescricaoOrigem = $"CONTRIBUIÇÃO: Cartão Parcelado {cartao.CartaoBandeira} parcela {numParcela:D2}";
							}

							//--- add Parcela
							numParcela += 1;

							//--- Insert Entrada
							newMovID = mBLL.InsertMovimentacao(entrada, ContaSldLocalUpdate, SetorSldLocalUpdate, db);

							//--- Insert AReceber
							parcela.IDMovProvisoria = (long)newMovID;
							rBLL.InsertAReceber(parcela, db);
						}

						break;
					default:
						break;
				}

				if (newID == 0)
				{
					throw new Exception("Não foi possível inserir um novo registro de Contribuição...");
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

		// INSERT CONTRIBUICAO SIMPLES
		//------------------------------------------------------------------------------------------------------------
		private long AddContribuicao(objContribuicao cont, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@ContribuicaoData", cont.ContribuicaoData);
				dbTran.AdicionarParametros("@IDEntradaForma", cont.IDEntradaForma);
				dbTran.AdicionarParametros("@ValorBruto", cont.ValorBruto);
				dbTran.AdicionarParametros("@IDContribuicaoTipo", cont.IDContribuicaoTipo);
				dbTran.AdicionarParametros("@IDSetor", cont.IDSetor);
				dbTran.AdicionarParametros("@IDConta", cont.IDConta);
				dbTran.AdicionarParametros("@IDContribuinte", cont.IDContribuinte);
				dbTran.AdicionarParametros("@OrigemDescricao", cont.OrigemDescricao);
				dbTran.AdicionarParametros("@IDReuniao", cont.IDReuniao);
				dbTran.AdicionarParametros("@IDCampanha", cont.IDCampanha);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblContribuicao");

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
		public bool UpdateContribuicao(objContribuicao entrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDContribuicao", entrada.IDContribuicao);
				db.AdicionarParametros("@ContribuicaoData", entrada.ContribuicaoData);
				db.AdicionarParametros("@IDEntradaForma", entrada.IDEntradaForma);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@IDContribuicaoTipo", entrada.IDContribuicaoTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDContribuinte", entrada.IDContribuinte);
				db.AdicionarParametros("@OrigemDescricao", entrada.OrigemDescricao);
				db.AdicionarParametros("@IDReuniao", entrada.IDReuniao);
				db.AdicionarParametros("@IDCampanha", entrada.IDCampanha);
				db.AdicionarParametros("@ValorRecebido", entrada.ValorRecebido);
				db.AdicionarParametros("@Realizado", entrada.Realizado);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblContribuicao", "@IDContribuicao");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE VALOR_RECEBIDO WHEN ARECEBER QUITADO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateValorRecebidoAndCheckRealizado(long IDContribuicao, decimal ValorMovimentado, AcessoDados dbTran)
		{
			try
			{
				// clear Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDContribuicao", IDContribuicao);

				// CheckRealizado and Update
				string query = "SELECT COUNT(IDContribuicao) AS QTDE " +
					"FROM tblAReceber " +
					"WHERE IDContribuicao = @IDContribuicao AND IDSituacao = 1";

				DataTable dt = dbTran.ExecutarConsulta(CommandType.Text, query);
				bool realizado = false;

				if (dt.Rows.Count > 0 && (int)dt.Rows[0][0] > 0)
				{
					realizado = false;
				}
				else
				{
					realizado = true;
				}

				// UPDATE VALOR RECEBIDO
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDContribuicao", IDContribuicao);
				dbTran.AdicionarParametros("@ValorRecebido", ValorMovimentado);
				dbTran.AdicionarParametros("@Realizado", realizado);

				query = "UPDATE tblContribuicao " +
					"SET ValorRecebido = ValorRecebido + @ValorRecebido, Realizado = @Realizado " +
					"WHERE IDContribuicao = @IDContribuicao";

				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return true;
		}

		// UPDATE VALOR_RECEBIDO WHEN ARECEBER ESTORNO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateValorRecebidoEstorno(long IDContribuicao, decimal ValorEstorno, AcessoDados dbTran)
		{
			try
			{
				// UPDATE VALOR RECEBIDO
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDContribuicao", IDContribuicao);
				dbTran.AdicionarParametros("@ValorEstorno", ValorEstorno);
				dbTran.AdicionarParametros("@Realizado", false);

				string query = "UPDATE tblContribuicao " +
					"SET ValorRecebido = ValorRecebido - @ValorEstorno, Realizado = @Realizado " +
					"WHERE IDContribuicao = @IDContribuicao";

				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return true;
		}

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteContribuicao(long IDContribuicao,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// 1 - CHECK AReceber and Entradas
				//------------------------------------------------------------------------------------------------------------
				List<objAReceber> listAReceber = new List<objAReceber>();
				List<objMovimentacao> listEntradas = new List<objMovimentacao>();

				if (!VerifyBeforeDelete(IDContribuicao, ref listAReceber, ref listEntradas, dbTran)) return false;

				// 2 - delete ALL ARECEBER 
				//------------------------------------------------------------------------------------------------------------
				if (listAReceber.Count > 0)
				{
					AReceberBLL rBLL = new AReceberBLL();

					foreach (objAReceber receber in listAReceber)
					{
						rBLL.DeleteAReceber((long)receber.IDAReceber, dbTran);
					}
				}

				// 3 - delete ALL MOVIMENTACAO ENTRADA 
				//------------------------------------------------------------------------------------------------------------
				if (listEntradas.Count > 0)
				{
					MovimentacaoBLL mBLL = new MovimentacaoBLL();
					mBLL.DeleteMovimentacaoList(listEntradas, ContaSdlUpdate, SetorSdlUpdate, dbTran);
				}

				// 4 - delete CONTRIBUICAO
				//------------------------------------------------------------------------------------------------------------

				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDContribuicao", IDContribuicao);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				//--- create query
				string query = "DELETE tblContribuicao WHERE IDContribuicao = @IDContribuicao";

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

		private bool VerifyBeforeDelete(long IDContribuicao,
			ref List<objAReceber> listAReceber,
			ref List<objMovimentacao> listEntradas,
			AcessoDados dbTran)
		{
			try
			{
				// GET ARECEBER
				//------------------------------------------------------------------------------------------------------------
				listAReceber = new AReceberBLL().GetListAReceberByIDContribuicao(IDContribuicao, dbTran);

				// VERIFY ARECEBER
				//------------------------------------------------------------------------------------------------------------
				bool err = false;
				string errMessage = "Os ARECEBER abaixo possuem recebimentos...\n";

				foreach (objAReceber receber in listAReceber)
				{
					if (receber.IDSituacao == 2)
					{
						errMessage += $"Reg.: {receber.IDAReceber:D4}    {receber.CompensacaoData.ToShortDateString()}\n";
						err = true;
					}
				}

				if (err == true)
				{
					errMessage += "Favor estornar antes os recebimentos se deseja EXCLUIR a contribuição.";
					throw new AppException(errMessage);
				}

				// VERIFY MOVIMENTACAO ENTRADA FROM CONTRIBUICAO
				//------------------------------------------------------------------------------------------------------------
				MovimentacaoBLL mBLL = new MovimentacaoBLL();
				listEntradas = mBLL.GetMovimentacaoListByOrigem(EnumMovOrigem.Contribuicao, IDContribuicao, false, dbTran);

				// VERIFY MOVIMENTACAO ENTRADA FROM ARECEBER
				//------------------------------------------------------------------------------------------------------------
				if (listAReceber.Count > 0)
				{
					foreach (objAReceber receber in listAReceber)
					{
						listEntradas.AddRange(mBLL.GetMovimentacaoListByOrigem(EnumMovOrigem.AReceber, (long)receber.IDAReceber, false, dbTran));
					}
				}

				// VERIFY RECEBIMENTOS WITH CAIXA OR BLOCKED
				//------------------------------------------------------------------------------------------------------------
				errMessage = "Essa Contribuição possui entradas que foram inseridas no caixa...\n";

				foreach (objMovimentacao entrada in listEntradas)
				{
					if (entrada.IDCaixa != null)
					{
						errMessage += $"Reg.: {entrada.IDMovimentacao:D4} | {entrada.MovData.ToShortDateString()} | Caixa: {entrada.IDCaixa:D4}\n";
						err = true;
					}
				}

				if (err == true)
				{
					errMessage += "Favor remover o(s) caixa(s) se desejar EXCLUIR a(s) contribuição.";
					throw new AppException(errMessage);
				}

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=================================================================================================
		// CONTRIBUICAO CARTAO / CHEQUE
		//=================================================================================================

		// GET CONTRIBUICAO CARTAO
		//------------------------------------------------------------------------------------------------------------
		public objContribuicaoCartao GetContribuicaoCartao(long IDContribuicao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicaoCartao WHERE IDContribuicao = @IDContribuicao";
				db.LimparParametros();
				db.AdicionarParametros("@IDContribuicao", IDContribuicao);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new Exception("Não foi encontrado nenhum registro de Contribuição de Cartão com o ID informado...");
				}

				DataRow row = dt.Rows[0];

				return new objContribuicaoCartao(IDContribuicao)
				{
					CartaoBandeira = (string)row["CartaoBandeira"],
					CartaoOperadora = (string)row["CartaoOperadora"],
					CartaoTipo = (byte)row["CartaoTipo"],
					CartaoTipoDescricao = (string)row["CartaoTipoDescricao"],
					ContaProvisoria = (string)row["ContaProvisoria"],
					IDCartaoBandeira = (int)row["IDCartaoBandeira"],
					IDCartaoOperadora = (int)row["IDCartaoOperadora"],
					IDContaProvisoria = (int)row["IDContaProvisoria"],
					IDContribuicao = (long)row["IDContribuicao"],
					Parcelas = (byte)row["Parcelas"],
					Prazo = (byte)row["Prazo"],
					TaxaAplicada = (decimal)row["TaxaAplicada"]
				};

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET CONTRIBUICAO CHEQUE
		//------------------------------------------------------------------------------------------------------------
		public objContribuicaoCheque GetContribuicaoCheque(long IDContribuicao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicaoCheque WHERE IDContribuicao = @IDContribuicao";
				db.LimparParametros();
				db.AdicionarParametros("@IDContribuicao", IDContribuicao);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new Exception("Não foi encontrado nenhum registro de Contribuição de Cheque com o ID informado...");
				}

				DataRow row = dt.Rows[0];

				return new objContribuicaoCheque(IDContribuicao)
				{
					Banco = (string)row["BancoNome"],
					ChequeNumero = (string)row["ChequeNumero"],
					DepositoData = (DateTime)row["DepositoData"],
					IDBanco = (int)row["IDBanco"]
				};

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		// INSERT CONTRIBUICAO CARTAO
		//------------------------------------------------------------------------------------------------------------
		private void AddContribuicaoCartao(objContribuicaoCartao cartao, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDContribuicao", cartao.IDContribuicao);
				dbTran.AdicionarParametros("@CartaoTipo", cartao.CartaoTipo);
				dbTran.AdicionarParametros("@IDCartaoBandeira", cartao.IDCartaoBandeira);
				dbTran.AdicionarParametros("@IDCartaoOperadora", cartao.IDCartaoOperadora);
				dbTran.AdicionarParametros("@IDContaProvisoria", cartao.IDContaProvisoria);
				dbTran.AdicionarParametros("@Parcelas", cartao.Parcelas);
				dbTran.AdicionarParametros("@TaxaAplicada", cartao.TaxaAplicada);
				dbTran.AdicionarParametros("@Prazo", cartao.Prazo);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblContribuicaoCartao");

				//--- insert and Get new ID
				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT CONTRIBUICAO CHEQUE
		//------------------------------------------------------------------------------------------------------------
		private void AddContribuicaoCheque(objContribuicaoCheque cheque, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDContribuicao", cheque.IDContribuicao);
				dbTran.AdicionarParametros("@ChequeNumero", cheque.ChequeNumero);
				dbTran.AdicionarParametros("@DepositoData", cheque.DepositoData);
				dbTran.AdicionarParametros("@IDBanco", cheque.IDBanco);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblContribuicaoCheque");

				//--- insert and Get new ID
				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=============================================================================
		//=============================================================================

		// GET CONTRIBUICAO TIPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicaoTipo> GetContribuicaoTiposList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblContribuicaoTipo WHERE IDContribuicaoTipo > 0";

				// add params
				db.LimparParametros();

				query += " ORDER BY ContribuicaoTipo";

				List<objContribuicaoTipo> listagem = new List<objContribuicaoTipo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objContribuicaoTipo forma = new objContribuicaoTipo((byte)row["IDContribuicaoTipo"])
					{
						ContribuicaoTipo = (string)row["ContribuicaoTipo"],
						ComAtividade = (bool)row["ComAtividade"],
						ComCampanha = (bool)row["ComCampanha"],
						ComOrigem = (bool)row["ComOrigem"]
					};

					listagem.Add(forma);
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
