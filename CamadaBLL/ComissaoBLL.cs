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

				string query = "SELECT * FROM qryComissao ";
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
					query += haveWhere ? " AND Vencimento >= @DataInicial" : " WHERE Vencimento >= @DataInicial";
					haveWhere = true;
				}

				// add DataFinal
				if (DataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)DataFinal);
					query += haveWhere ? " AND Vencimento <= @DataFinal" : " WHERE Vencimento <= @DataFinal";
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

				string query = "SELECT * FROM qryComissao WHERE IDComissao = @IDComissao";
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
		public int InsertComissao(objComissao comissao)
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
				string query = db.CreateInsertSQL("tblComissao");

				//--- insert
				int newID = (int)db.ExecutarInsertAndGetID(query);
				comissao.IDComissao = newID;

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
	}
}
