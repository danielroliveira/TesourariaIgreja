using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class ComissaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objComissao> GetList(
			int? IDCredor = null,
			int? IDSetor = null,
			DateTime? DataInicial = null,
			DateTime? DataFinal = null,
			byte? IDSituacao = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryComissoes ";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				// add IDCredor
				if (IDCredor != null)
				{
					db.AdicionarParametros("@IDCredor", IDCredor);
					query += haveWhere ? " AND IDCredor = @IDCredor" : " WHERE IDCredor = @IDCredor";
					haveWhere = true;
				}

				// add IDSetor
				if (IDSetor != null)
				{
					db.AdicionarParametros("@IDSetor", IDSetor);
					query += haveWhere ? " AND IDSetor = @IDSetor" : " WHERE IDSetor = @IDSetor";
					haveWhere = true;
				}

				// add IDSituacao
				if (IDSituacao != null)
				{
					db.AdicionarParametros("@IDSituacao", IDSituacao);
					query += haveWhere ? " AND IDSituacao = @IDSituacao" : " WHERE IDSituacao = @IDSituacao";
					haveWhere = true;
				}

				// add DataInicial
				if (DataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)DataInicial);
					query += haveWhere ? " AND DataInicial >= @DataInicial" : " WHERE DataInicial >= @DataInicial";
					haveWhere = true;
				}

				// add DataFinal
				if (DataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)DataFinal);
					query += haveWhere ? " AND DataInicial <= @DataFinal" : " WHERE DataInicial <= @DataFinal";
					haveWhere = true;
				}

				query += " ORDER BY DataInicial";

				List<objComissao> listagem = new List<objComissao>();
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

		// GET CREDOR
		//------------------------------------------------------------------------------------------------------------
		public objComissao GetByID(int IDComissao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryComissoes WHERE IDComissao = @IDComissao";
				db.LimparParametros();
				db.AdicionarParametros("@IDComissao", IDComissao);

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
		public objComissao ConvertRowInClass(DataRow row)
		{
			objComissao comissao = new objComissao((int)row["IDComissao"])
			{
				IDCredor = (int)row["IDCredor"],
				Credor = (string)row["Credor"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				ComissaoTaxa = (decimal)row["ComissaoTaxa"],
				DataInicial = (DateTime)row["DataInicial"],
				DataFinal = (DateTime)row["DataFinal"],
				ValorContribuicoes = (decimal)row["ValorContribuicoes"],
				ValorDescontado = (decimal)row["ValorDescontado"],
				ValorComissao = (decimal)row["ValorComissao"],
				IDSituacao = (byte)row["IDSituacao"],
				IDDespesa = row["IDDespesa"] == DBNull.Value ? null : (long?)row["IDDespesa"],
			};

			return comissao;

		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertComissao(objComissao comissao, List<objContribuicao> lstContribuicao)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCredor", comissao.IDCredor);
				db.AdicionarParametros("@IDSetor", comissao.IDSetor);
				db.AdicionarParametros("@DataInicial", comissao.DataInicial);
				db.AdicionarParametros("@DataFinal", comissao.DataFinal);
				db.AdicionarParametros("@ValorContribuicoes", comissao.ValorContribuicoes);
				db.AdicionarParametros("@ValorDescontado", comissao.ValorDescontado);
				db.AdicionarParametros("@ValorComissao", comissao.ValorComissao);
				db.AdicionarParametros("@ComissaoTaxa", comissao.ComissaoTaxa);
				db.AdicionarParametros("@IDSituacao", comissao.IDSituacao);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblComissoes");

				//--- insert
				int newID = (int)db.ExecutarInsertAndGetID(query);
				comissao.IDComissao = newID;

				//--- insert Contribuicao List
				InsertComissaoContribuicaoList(newID, lstContribuicao, db);

				//--- COMMIT and RETURN
				db.CommitTransaction();
				return newID;
			}
			catch (Exception ex)
			{
				//--- ROOLBACK
				db.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT CONTRIBUICAO COMISSIONADA LIST
		//------------------------------------------------------------------------------------------------------------
		private void InsertComissaoContribuicaoList(int IDComissao, List<objContribuicao> lstContribuicao, AcessoDados dbTran)
		{
			try
			{
				string query = "";

				foreach (var contribuicao in lstContribuicao)
				{
					dbTran.LimparParametros();
					dbTran.AdicionarParametros("@IDContribuicao", contribuicao.IDContribuicao);
					dbTran.AdicionarParametros("@IDComissao", IDComissao);
					dbTran.AdicionarParametros("@ValorComissionado", contribuicao.ValorRecebido);

					query = "INSERT INTO tblContribuicaoComissionada " +
						"(IDContribuicao, IDComissao, ValorComissionado) " +
						"VALUES " +
						"(@IDContribuicao, @IDComissao, @ValorComissionado)";

					dbTran.ExecutarManipulacao(CommandType.Text, query);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateComissao(objComissao comissao)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDComissao", comissao.IDComissao);
				db.AdicionarParametros("@IDCredor", comissao.IDCredor);
				db.AdicionarParametros("@IDSetor", comissao.IDSetor);
				db.AdicionarParametros("@DataInicial", comissao.DataInicial);
				db.AdicionarParametros("@DataFinal", comissao.DataFinal);
				db.AdicionarParametros("@ValorContribuicoes", comissao.ValorContribuicoes);
				db.AdicionarParametros("@ValorDescontado", comissao.ValorDescontado);
				db.AdicionarParametros("@ValorComissao", comissao.ValorComissao);
				db.AdicionarParametros("@ComissaoTaxa", comissao.ComissaoTaxa);
				db.AdicionarParametros("@IDSituacao", comissao.IDSituacao);
				db.AdicionarParametros("@IDDespesa", comissao.IDDespesa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblComissao", "IDComissao");

				//--- UPDATE
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- COMMIT
				db.CommitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				//--- ROOLBACK
				db.RollBackTransaction();
				throw ex;
			}
		}

		// GET CONTRIBUICAO LIST BY SETOR WITH NOT IN COMISSAO COMISSIONADA
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicao> GetContribuicaoComissaoList(int IDSetor)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				db.LimparParametros();
				db.AdicionarParametros("@IDSetor", IDSetor);

				string query = "SELECT * FROM qryContribuicao AS C " +
						"JOIN tblContribuicaoTipo AS T " +
						"ON C.IDContribuicaoTipo = T.IDContribuicaoTipo " +
						"WHERE " +
						"IDSetor = @IDSetor " +
						"AND Realizado = 'TRUE' " +
						"AND T.ComComissao = 'TRUE' " +
						"AND IDContribuicao " +
						"NOT IN (SELECT IDContribuicao FROM tblContribuicaoComissionada)";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return null;
				}

				//--- convert row to Contribuicao
				var list = new List<objContribuicao>();
				var cBLL = new ContribuicaoBLL();

				foreach (DataRow row in dt.Rows)
				{
					objContribuicao contribuicao = cBLL.ConvertRowInClass(row);
					list.Add(contribuicao);
				}

				return list;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET CONTRIBUICAO LIST INSERTED CONTRIBUICAO IN COMISSAO
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicao> GetInsertedContribuicaoList(int IDComissao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				db.LimparParametros();
				db.AdicionarParametros("@IDComissao", IDComissao);

				string query = "SELECT * FROM qryContribuicao WHERE " +
				"IDContribuicao IN " +
				"(SELECT IDContribuicao FROM tblContribuicaoComissionada WHERE IDComissao = @IDComissao)";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return null;
				}

				//--- convert row to Contribuicao
				var list = new List<objContribuicao>();
				var cBLL = new ContribuicaoBLL();

				foreach (DataRow row in dt.Rows)
				{
					objContribuicao contribuicao = cBLL.ConvertRowInClass(row);
					list.Add(contribuicao);
				}

				return list;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONCLUIR COMISSAO CHANGE SITUATION
		//------------------------------------------------------------------------------------------------------------
		public void ComissoesSituacaoChange(List<objComissao> list, byte newSituacao)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				string query = "UPDATE tblComissoes SET IDSituacao = @IDSituacao WHERE IDComissao = @IDComissao";

				foreach (var comissao in list)
				{
					comissao.IDSituacao = newSituacao;

					dbTran.LimparParametros();
					dbTran.AdicionarParametros("@IDSituacao", newSituacao);
					dbTran.AdicionarParametros("@IDComissao", comissao.IDComissao);

					dbTran.ExecutarManipulacao(CommandType.Text, query);
				}

				dbTran.CommitTransaction();

			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

		// PAGAR LIST OF COMISSAO AND CHANGE SITUATION
		//------------------------------------------------------------------------------------------------------------
		public long ComissoesPagamento(
			List<objComissao> list,
			objDespesa despesa,
			objAPagar pagar,
			objMovimentacao saida,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// insert new Despesa Realizada | Gasto
				var despBLL = new DespesaBLL();
				long newID = despBLL.InsertDespesaRealizada(despesa, pagar, saida, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);

				// update all comissoes to PAGO
				string query = "UPDATE tblComissoes SET " +
					"IDSituacao = 3, " +
					"IDDespesa = @IDDespesa " +
					"WHERE IDComissao = @IDComissao";

				foreach (var comissao in list)
				{
					dbTran.LimparParametros();
					dbTran.AdicionarParametros("@IDDespesa", newID);
					dbTran.AdicionarParametros("@IDComissao", comissao.IDComissao);

					dbTran.ExecutarManipulacao(CommandType.Text, query);
				}

				dbTran.CommitTransaction();

				return newID;
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

		// EXCLUIR COMISSAO
		//------------------------------------------------------------------------------------------------------------
		public void ComissaoExcluir(objComissao comissao)
		{
			AcessoDados dbTran = null;

			try
			{
				//--- VERIFICA SE EXISTE DESPESA ANEXADA
				if (comissao.IDDespesa != null)
				{
					string message = "Não é possível excluir essa Comissão porque ainda existe uma despesa vinculada..." +
						$"O registro da despesa é {comissao.IDDespesa:D4}" +
						$"É necessário Excluir a Despesa anexada para remover a comissão.";
					throw new AppException(message);
				}

				//--- INIT DB
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				//--- remove Contribuicao <=> Comissao associate
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDComissao", comissao.IDComissao);

				string query = "DELETE tblContribuicaoComissionada WHERE IDComissao = @IDComissao";

				dbTran.ExecutarManipulacao(CommandType.Text, query);

				//--- delete Comissao
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDComissao", comissao.IDComissao);

				query = "DELETE tblComissoes WHERE IDComissao = @IDComissao";

				dbTran.ExecutarManipulacao(CommandType.Text, query);

				//--- COMMIT
				dbTran.CommitTransaction();
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

	}
}
