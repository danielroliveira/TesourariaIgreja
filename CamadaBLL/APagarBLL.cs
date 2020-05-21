using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	//=================================================================================================
	// APAGAR
	//=================================================================================================
	public class APagarBLL
	{
		// GET
		//------------------------------------------------------------------------------------------------------------
		public objAPagar GetAPagar()
		{
			throw new NotImplementedException();

		}

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagar(int? IDSituacao,
			int? IDCobrancaForma = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryAPagar";
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

				// add IDDespesaTipo
				if (IDCobrancaForma != null)
				{
					db.AdicionarParametros("@IDCobrancaForma", IDCobrancaForma);
					query += myWhere ? " AND IDCobrancaForma = @IDCobrancaForma" : " WHERE IDCobrancaForma = @IDCobrancaForma";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND Vencimento >= @DataInicial" : " WHERE Vencimento >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND Vencimento <= @DataFinal" : " WHERE Vencimento <= @DataFinal";
					myWhere = true;
				}

				// add IDCredor
				if (IDCredor != null)
				{
					db.AdicionarParametros("@IDCredor", IDCredor);
					query += myWhere ? " AND IDCredor = @IDCredor" : " WHERE IDCredor = @IDCredor";
					myWhere = true;
				}

				query += " ORDER BY Vencimento";

				List<objAPagar> listagem = new List<objAPagar>();
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

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagarByDespesa(long IDDespesa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryAPagar WHERE IDDespesa = @IDDespesa";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", IDDespesa);

				query += " ORDER BY IDAPagar";

				List<objAPagar> listagem = new List<objAPagar>();
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
		private objAPagar ConvertRowInClass(DataRow row)
		{
			objAPagar despesa = new objAPagar((long)row["IDAPagar"])
			{
				IDDespesa = (long)row["IDDespesa"],
				DespesaDescricao = (string)row["DespesaDescricao"],
				Identificador = (string)row["Identificador"],
				Parcela = row["Parcela"] == DBNull.Value ? null : (byte?)row["Parcela"],
				IDCobrancaForma = (int)row["IDCobrancaForma"],
				CobrancaForma = (string)row["CobrancaForma"],
				APagarValor = (decimal)row["APagarValor"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				IDBanco = row["IDBanco"] == DBNull.Value ? null : (int?)row["IDBanco"],
				Banco = row["BancoNome"] == DBNull.Value ? string.Empty : (string)row["BancoNome"],
				Vencimento = (DateTime)row["Vencimento"],
				PagamentoData = row["PagamentoData"] == DBNull.Value ? null : (DateTime?)row["PagamentoData"],
				Prioridade = (byte)row["Prioridade"],
				IDCredor = row["IDCredor"] == DBNull.Value ? null : (int?)row["IDCredor"],
				Credor = row["Credor"] == DBNull.Value ? string.Empty : (string)row["Credor"],
				ValorPago = (decimal)row["ValorPago"],
				ValorAcrescimo = (decimal)row["ValorAcrescimo"],
				ValorDesconto = (decimal)row["ValorDesconto"],
				ReferenciaMes = row["ReferenciaMes"] == DBNull.Value ? null : (int?)row["ReferenciaMes"],
				ReferenciaAno = row["ReferenciaMes"] == DBNull.Value ? null : (int?)row["ReferenciaAno"],
				Imagem = (bool)row["Imagem"],
			};

			return despesa;

		}

		// INSERT LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> InsertAPagarList(List<objAPagar> list, AcessoDados dbTran)
		{
			try
			{
				foreach (var pag in list)
				{
					//--- clear Params
					dbTran.LimparParametros();

					//--- define Params
					dbTran.AdicionarParametros("@APagarValor", pag.APagarValor);
					dbTran.AdicionarParametros("@IDBanco", pag.IDBanco);
					dbTran.AdicionarParametros("@IDCobrancaForma", pag.IDCobrancaForma);
					dbTran.AdicionarParametros("@IDDespesa", pag.IDDespesa);
					dbTran.AdicionarParametros("@Identificador", pag.Identificador);
					dbTran.AdicionarParametros("@IDSituacao", pag.IDSituacao);
					dbTran.AdicionarParametros("@Imagem", pag.Imagem);
					dbTran.AdicionarParametros("@Parcela", pag.Parcela);
					dbTran.AdicionarParametros("@Prioridade", pag.Prioridade);
					dbTran.AdicionarParametros("@ReferenciaAno", pag.ReferenciaAno);
					dbTran.AdicionarParametros("@ReferenciaMes", pag.ReferenciaMes);
					dbTran.AdicionarParametros("@ValorPago", pag.ValorPago);
					dbTran.AdicionarParametros("@ValorAcrescimo", pag.ValorAcrescimo);
					dbTran.AdicionarParametros("@ValorDesconto", pag.ValorDesconto);
					dbTran.AdicionarParametros("@Vencimento", pag.Vencimento);

					//--- convert null parameters
					dbTran.ConvertNullParams();

					string query = dbTran.CreateInsertSQL("tblAPagar");

					//--- insert and Get new ID
					int newID = dbTran.ExecutarInsertAndGetID(query);
					pag.IDAPagar = newID;
				}

				return list;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAPagar(objAPagar pag, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAPagar", pag.IDAPagar);
				db.AdicionarParametros("@APagarValor", pag.APagarValor);
				db.AdicionarParametros("@IDBanco", pag.IDBanco);
				db.AdicionarParametros("@IDCobrancaForma", pag.IDCobrancaForma);
				db.AdicionarParametros("@IDDespesa", pag.IDDespesa);
				db.AdicionarParametros("@Identificador", pag.Identificador);
				db.AdicionarParametros("@IDSituacao", pag.IDSituacao);
				db.AdicionarParametros("@Imagem", pag.Imagem);
				db.AdicionarParametros("@Parcela", pag.Parcela);
				db.AdicionarParametros("@Prioridade", pag.Prioridade);
				db.AdicionarParametros("@ReferenciaAno", pag.ReferenciaAno);
				db.AdicionarParametros("@ReferenciaMes", pag.ReferenciaMes);
				db.AdicionarParametros("@ValorPago", pag.ValorPago);
				db.AdicionarParametros("@ValorAcrescimo", pag.ValorAcrescimo);
				db.AdicionarParametros("@ValorDesconto", pag.ValorDesconto);
				db.AdicionarParametros("@Vencimento", pag.Vencimento);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblAPagar", "IDAPagar");

				//--- insert and Get new ID
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

	//=================================================================================================
	// COBRANCA FORMA
	//=================================================================================================
	public class CobrancaFormaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objCobrancaForma> GetListCobrancaForma(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCobrancaForma";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					if (haveWhere)
						query += " AND Ativo = @Ativo";
					else
						query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDCobrancaForma";

				// execute datatable
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				// create list
				List<objCobrancaForma> listagem = new List<objCobrancaForma>();

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objCobrancaForma cob = new objCobrancaForma((int)row["IDCobrancaForma"])
					{
						CobrancaForma = (string)row["CobrancaForma"],
						IDBanco = row["IDBanco"] == DBNull.Value ? null : (int?)row["IDBanco"],
						BancoNome = row["BancoNome"] == DBNull.Value ? string.Empty : (string)row["BancoNome"],
						IDCartaoBandeira = row["IDCartaoBandeira"] == DBNull.Value ? null : (int?)row["IDCartaoBandeira"],
						CartaoBandeira = row["CartaoBandeira"] == DBNull.Value ? string.Empty : (string)row["CartaoBandeira"],
						Ativo = (bool)row["Ativo"],
					};

					listagem.Add(cob);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertCobrancaForma(objCobrancaForma forma)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@CobrancaForma", forma.CobrancaForma);
				db.AdicionarParametros("@IDBanco", forma.IDBanco);
				db.AdicionarParametros("@IDCartaoBandeira", forma.IDCartaoBandeira);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblCobrancaForma");

				//--- insert
				return db.ExecutarInsertAndGetID(query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCobrancaForma(objCobrancaForma forma)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCobrancaForma", forma.IDCobrancaForma);
				db.AdicionarParametros("@CobrancaForma", forma.CobrancaForma);
				db.AdicionarParametros("@IDBanco", forma.IDBanco);
				db.AdicionarParametros("@IDCartaoBandeira", forma.IDCartaoBandeira);
				db.AdicionarParametros("@Ativo", forma.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblCobrancaForma", "IDCobrancaForma");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
