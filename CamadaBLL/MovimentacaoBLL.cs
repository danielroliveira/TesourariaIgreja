using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class MovimentacaoBLL
	{
		//=================================================================================================
		// Movimentacao BLL
		//=================================================================================================

		// GET Movimentacao
		//------------------------------------------------------------------------------------------------------------
		public objMovimentacao GetMovimentacao(long MovID, bool GetWithAcrescimoImagem = false, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "";

				if (!GetWithAcrescimoImagem)
				{
					query = "SELECT * FROM qryMovimentacao WHERE IDMovimentacao = @IDMovimentacao";
				}
				else
				{
					query = "SELECT * FROM qryMovimentacaoAcrescimo WHERE IDMovimentacao = @IDMovimentacao";
				}

				db.LimparParametros();
				db.AdicionarParametros("@IDMovimentacao", MovID);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				//--- RETURN
				return ConvertRowInClass(dt.Rows[0], GetWithAcrescimoImagem);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET Movimentacao LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objMovimentacao> GetMovimentacaoList(
			EnumMovOrigem? Origem = null,
			int? IDConta = null,
			int? IDSetor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null,
			object dbTran = null,
			bool GetWithAcrescimoImagem = false)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "";
				bool myWhere = false;

				if (!GetWithAcrescimoImagem)
				{
					query = "SELECT * FROM qryMovimentacao";
				}
				else
				{
					query = "SELECT * FROM qryMovimentacaoAcrescimo";
				}

				// add params
				db.LimparParametros();

				// add Origem
				if (Origem != null)
				{
					db.AdicionarParametros("@Origem", Origem);
					query += " WHERE Origem = @Origem";
					myWhere = true;
				}

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

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND MovData >= @DataInicial" : " WHERE MovData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND MovData <= @DataFinal" : " WHERE MovData <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY MovData";

				List<objMovimentacao> listagem = new List<objMovimentacao>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClass(row, GetWithAcrescimoImagem));
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET Movimentacao LIST BY IDCaixa
		//------------------------------------------------------------------------------------------------------------
		public List<objMovimentacao> GetMovimentacaoCaixaList(
			long IDCaixa,
			object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", IDCaixa);

				string query = "SELECT * FROM qryMovimentacao WHERE IDCaixa = @IDCaixa";

				query += " ORDER BY MovData";

				List<objMovimentacao> listagem = new List<objMovimentacao>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClass(row, false));
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST MOVIMENTACAO FROM ORIGEM AND IDORIGEM
		//------------------------------------------------------------------------------------------------------------
		public List<objMovimentacao> GetMovimentacaoListByOrigem(
			EnumMovOrigem Origem,
			long IDOrigem,
			bool GetWithAcrescimoImagem = false,
			object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "";

				if (!GetWithAcrescimoImagem)
				{
					query = "SELECT * FROM qryMovimentacao WHERE Origem = @Origem AND IDOrigem = @IDOrigem";
				}
				else
				{
					query = "SELECT * FROM qryMovimentacaoAcrescimo WHERE Origem = @Origem AND IDOrigem = @IDOrigem";
				}


				db.LimparParametros();
				db.AdicionarParametros("@IDOrigem", IDOrigem);
				db.AdicionarParametros("@Origem", Origem);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				List<objMovimentacao> list = new List<objMovimentacao>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow row in dt.Rows)
					{
						list.Add(ConvertRowInClass(row, GetWithAcrescimoImagem));
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objMovimentacao ConvertRowInClass(DataRow row, bool hasAcrescimo)
		{
			objMovimentacao Movimentacao = new objMovimentacao((long)row["IDMovimentacao"])
			{
				MovTipo = (byte)row["MovTipo"], // 1: ENTRADA | 2: SAIDA | 3: TRANSFERENCIA
				MovTipoDescricao = (string)row["MovTipoDescricao"],
				Origem = (EnumMovOrigem)row["Origem"],
				IDOrigem = (long)row["IDOrigem"],
				MovData = (DateTime)row["MovData"],
				MovValor = (decimal)row["MovValor"],
				MovValorAbsoluto = (decimal)row["MovValorAbsoluto"],
				IDConta = row["IDConta"] == DBNull.Value ? null : (int?)row["IDConta"],
				Conta = row["Conta"] == DBNull.Value ? null : (string)row["Conta"],
				IDSetor = row["IDSetor"] == DBNull.Value ? null : (int?)row["IDSetor"],
				Setor = row["Setor"] == DBNull.Value ? null : (string)row["Setor"],
				IDCaixa = row["IDCaixa"] == DBNull.Value ? null : (long?)row["IDCaixa"],
				DescricaoOrigem = (string)row["DescricaoOrigem"],
				Consolidado = (bool)row["Consolidado"],
			};

			if (hasAcrescimo) // ADD ACRESCIMO and IMAGEM
			{
				Movimentacao.AcrescimoValor = row["AcrescimoValor"] == DBNull.Value ? null : (decimal?)row["AcrescimoValor"];
				Movimentacao.AcrescimoMotivo = row["AcrescimoMotivo"] == DBNull.Value ? string.Empty : (string)row["AcrescimoMotivo"];
				Movimentacao.IDAcrescimoMotivo = row["IDAcrescimoMotivo"] == DBNull.Value ? null : (byte?)row["IDAcrescimoMotivo"];
				Movimentacao.ImagemPath = row["ImagemPath"] == DBNull.Value ? string.Empty : (string)row["ImagemPath"];
				Movimentacao.ImagemFileName = row["ImagemFileName"] == DBNull.Value ? string.Empty : (string)row["ImagemFileName"];
			}

			return Movimentacao;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertMovimentacao(
			objMovimentacao mov,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- Check DescricaoOrigem
				if (string.IsNullOrEmpty(mov.DescricaoOrigem))
				{
					throw new AppException("A Descrição da origem não pode estar vazia...");
				}

				//--- 1. Check if is SAIDA and check Positive Value 
				//------------------------------------------------------------------------------------------------------------
				if (mov.MovTipo == 2 && mov.MovValor > 0)
				{
					mov.MovValor *= -1;
				}

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@MovTipo", mov.MovTipo);
				db.AdicionarParametros("@Origem", mov.Origem);
				db.AdicionarParametros("@IDOrigem", mov.IDOrigem);
				db.AdicionarParametros("@MovData", mov.MovData);
				db.AdicionarParametros("@MovValor", mov.MovValor);
				db.AdicionarParametros("@IDConta", mov.IDConta);
				db.AdicionarParametros("@IDSetor", mov.IDSetor);
				db.AdicionarParametros("@DescricaoOrigem", mov.DescricaoOrigem);
				db.AdicionarParametros("@Consolidado", mov.Consolidado);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblMovimentacao");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);
				mov.IDMovimentacao = newID;

				//--- insert IN tblMovAcrescimo IF is necessary
				if (mov.AcrescimoValor != null && mov.AcrescimoValor != 0)
				{
					InsertMovimentacaoAcrescimo(mov, db);
				}

				//--- insert in tblMovImagem IF is necessary
				if (!string.IsNullOrEmpty(mov.ImagemFileName))
				{
					InsertMovimentacaoImagem(mov, db);
				}

				//--- insert OBSERVACAO
				new ObservacaoBLL().SaveObservacao(1, newID, mov.Observacao, db);

				//--- altera o saldo da CONTA
				if (ContaSdlUpdate != null)
				{
					new ContaBLL().ContaSaldoChange((int)mov.IDConta, mov.MovValor, db, ContaSdlUpdate);
				}

				//--- altera o saldo do SETOR
				if (SetorSdlUpdate != null)
				{
					new SetorBLL().SetorSaldoChange((int)mov.IDSetor, mov.MovValor, db, SetorSdlUpdate);
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

		// INSERT MOVIMENTACAO ACRESCIMO
		//------------------------------------------------------------------------------------------------------------
		private void InsertMovimentacaoAcrescimo(objMovimentacao mov, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
				dbTran.AdicionarParametros("@AcrescimoValor", mov.AcrescimoValor);
				dbTran.AdicionarParametros("@IDAcrescimoMotivo", mov.IDAcrescimoMotivo);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = "INSERT INTO tblMovAcrescimo " +
								"(IDMovimentacao, AcrescimoValor, IDAcrescimoMotivo) " +
								"VALUES " +
								"(@IDMovimentacao, @AcrescimoValor, @IDAcrescimoMotivo)";

				//--- execute INSERT
				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT MOVIMENTACAO ACRESCIMO
		//------------------------------------------------------------------------------------------------------------
		public void InsertMovimentacaoImagem(objMovimentacao mov, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
				dbTran.AdicionarParametros("@ImagemPath", mov.ImagemPath);
				dbTran.AdicionarParametros("@ImagemFileName", mov.ImagemFileName);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = "INSERT INTO tblMovImagem " +
							   "(IDMovimentacao, ImagemPath, ImagemFileName) " +
							   "VALUES " +
							   "(@IDMovimentacao, @ImagemPath, @ImagemFileName)";

				//--- execute INSERT
				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//=================================================================================================
		// DELETE | REMOVE
		//=================================================================================================

		// REMOVE MOVIMENTACAO (AND ACRESCIMO AND IMAGEM IF NECESSARY)
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteMovimentacao(
			long IDMov,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- get MOVIMENTACAO by ID to discover MOVVALOR
				//------------------------------------------------------------------------------------------------------------
				objMovimentacao mov = GetMovimentacao(IDMov, true, db);

				//--- check MOVIMENTACAO
				//------------------------------------------------------------------------------------------------------------

				//--- 1. Check is Caixa
				if (mov.IDCaixa != null)
				{
					throw new AppException("A MOVIMENTAÇÃO de CAIXA não pôde ser removida porque já se encontra anexada a um caixa...");
				}

				//--- 2. Check is ContaDateBlock
				if (!new ContaBLL().ContaDateBlockPermit((int)mov.IDConta, mov.MovData))
				{
					throw new AppException("A MOVIMENTAÇÃO de CAIXA não pode ser removida porque a Data se encontra bloqueada...");
				}

				//--- DELETE REMOVE MOVIMENTACAO (AND ACRESCIMO AND IMAGEM IF NECESSARY)
				//------------------------------------------------------------------------------------------------------------

				string query = "";

				//--- 1. check DELETE tblMovAcrescimo
				//------------------------------------------------------------------------------------------------------------
				if (mov.AcrescimoValor != null && mov.AcrescimoValor != 0)
				{
					//--- clear Params
					db.LimparParametros();

					//--- define Params
					db.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
					query = "DELETE tblMovAcrescimo WHERE IDMovimentacao = @IDMovimentacao";

					//--- DELETE
					db.ExecutarManipulacao(CommandType.Text, query);
				}

				//--- 2. check DELETE tblMovImagem
				//------------------------------------------------------------------------------------------------------------
				if (mov.ImagemPath != String.Empty)
				{
					//--- clear Params
					db.LimparParametros();

					//--- define Params
					db.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
					query = "DELETE tblMovImagem WHERE IDMovimentacao = @IDMovimentacao";

					//--- DELETE
					db.ExecutarManipulacao(CommandType.Text, query);
				}

				//--- 3. DELETE tblMovimentacao
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
				query = "DELETE tblMovimentacao WHERE IDMovimentacao = @IDMovimentacao";

				//--- DELETE
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- 4. DELETE OBSERVACAO
				//------------------------------------------------------------------------------------------------------------
				new ObservacaoBLL().DeleteObservacao(1, (long)mov.IDMovimentacao, db);

				//--- 5. CHANGE SALDOS
				//------------------------------------------------------------------------------------------------------------
				new ContaBLL().ContaSaldoChange((int)mov.IDConta, mov.MovValor * (-1), db, ContaSdlUpdate);
				new SetorBLL().SetorSaldoChange((int)mov.IDSetor, mov.MovValor * (-1), db, SetorSdlUpdate);

				if (dbTran == null) db.CommitTransaction();
				return true;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// REMOVE LIST OF MOVIMENTACAO (AND ACRESCIMO AND IMAGEM IF NECESSARY)
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteMovimentacaoList(
			List<objMovimentacao> Movs,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- check MOVIMENTACAO
				//------------------------------------------------------------------------------------------------------------
				foreach (objMovimentacao mov in Movs)
				{
					//--- 1. Check is Caixa
					if (mov.IDCaixa != null)
					{
						throw new AppException("A MOVIMENTAÇÃO de CAIXA não pôde ser removida porque já se encontra anexada a um caixa...");
					}

					//--- 2. Check is ContaDateBlock
					if (!new ContaBLL().ContaDateBlockPermit((int)mov.IDConta, mov.MovData))
					{
						throw new AppException("A MOVIMENTAÇÃO de CAIXA não pode ser removida porque a Data se encontra bloqueada...");
					}
				}

				string query = "";

				//--- DELETE REMOVE MOVIMENTACAO (AND ACRESCIMO AND IMAGEM IF NECESSARY)
				//------------------------------------------------------------------------------------------------------------

				foreach (objMovimentacao mov in Movs)
				{
					//--- 1. check DELETE tblMovAcrescimo
					//------------------------------------------------------------------------------------------------------------
					if (mov.AcrescimoValor != null && mov.AcrescimoValor != 0)
					{
						//--- clear Params
						db.LimparParametros();

						//--- define Params
						db.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
						query = "DELETE tblMovAcrescimo WHERE IDMovimentacao = @IDMovimentacao";

						//--- DELETE
						db.ExecutarManipulacao(CommandType.Text, query);
					}

					//--- 2. check DELETE tblMovImagem
					//------------------------------------------------------------------------------------------------------------
					if (mov.ImagemPath != String.Empty)
					{
						//--- clear Params
						db.LimparParametros();

						//--- define Params
						db.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
						query = "DELETE tblMovImagem WHERE IDMovimentacao = @IDMovimentacao";

						//--- DELETE
						db.ExecutarManipulacao(CommandType.Text, query);
					}

					//--- 3. DELETE tblMovimentacao
					//------------------------------------------------------------------------------------------------------------
					db.LimparParametros();

					//--- define Params
					db.AdicionarParametros("@IDMovimentacao", mov.IDMovimentacao);
					query = "DELETE tblMovimentacao WHERE IDMovimentacao = @IDMovimentacao";

					//--- DELETE
					db.ExecutarManipulacao(CommandType.Text, query);

					//--- 4. DELETE OBSERVACAO
					//------------------------------------------------------------------------------------------------------------
					new ObservacaoBLL().DeleteObservacao(1, (long)mov.IDMovimentacao, db);

					//--- 5. CHANGE SALDOS RETURN OLD VALUES
					//------------------------------------------------------------------------------------------------------------
					if (ContaSdlUpdate != null && mov.IDConta != null)
					{
						new ContaBLL().ContaSaldoChange((int)mov.IDConta, mov.MovValor * (-1), db, ContaSdlUpdate);
					}

					if (SetorSdlUpdate != null && mov.IDSetor != null)
					{
						new SetorBLL().SetorSaldoChange((int)mov.IDSetor, mov.MovValor * (-1), db, SetorSdlUpdate);
					}
				}

				if (dbTran == null) db.CommitTransaction();
				return true;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}


		// REMOVE DELETE ALL MOVS FROM ORIGEM AND IDORIGEM
		//------------------------------------------------------------------------------------------------------------
		public void DeleteMovsByOrigem(
			EnumMovOrigem Origem,
			long IDOrigem,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;
				if (dbTran == null) db.BeginTransaction();

				List<objMovimentacao> ListMovs = new List<objMovimentacao>();
				string query = "";

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDOrigem", IDOrigem);
				db.AdicionarParametros("@Origem", Origem);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create SELECT query
				query = "SELECT * FROM qryMovimentacaoAcrescimo WHERE Origem = @Origem AND IDOrigem = @IDOrigem";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);
				if (dt.Rows.Count == 0)
				{
					throw new AppException("Não foi encontrada nenhuma MOVIMENTACAO de Caixa com a Origem informada...");
				}

				foreach (DataRow row in dt.Rows)
				{
					ListMovs.Add(ConvertRowInClass(row, true));
				}

				//--- EXECUTE
				DeleteMovimentacaoList(ListMovs, ContaSdlUpdate, SetorSdlUpdate, db);

				//--- COMMIT
				if (dbTran == null) db.CommitTransaction();

			}
			catch (Exception ex)
			{
				//--- ROOLBACK
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE CONSOLIDADO FOR IDARECEBER
		//------------------------------------------------------------------------------------------------------------
		public void UpdateConsolidado(long IDMovimentacao, bool Consolidado, AcessoDados dbTran)
		{
			try
			{
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDMovimentacao", IDMovimentacao);
				dbTran.AdicionarParametros("@Consolidado", Consolidado);

				string query = "UPDATE tblMovimentacao SET Consolidado = @Consolidado WHERE IDMovimentacao = @IDMovimentacao";

				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
