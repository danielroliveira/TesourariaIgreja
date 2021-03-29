using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class DespesaBLL
	{
		//=============================================================================
		// DESPESA
		//=============================================================================

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesa(objDespesa desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				dbTran.AdicionarParametros("@DespesaOrigem", desp.DespesaOrigem);
				dbTran.AdicionarParametros("@DespesaValor", desp.DespesaValor);
				dbTran.AdicionarParametros("@DespesaData", desp.DespesaData);
				dbTran.AdicionarParametros("@IDCredor", desp.IDCredor);
				dbTran.AdicionarParametros("@IDSetor", desp.IDSetor);
				dbTran.AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);
				dbTran.AdicionarParametros("@IDTitular", desp.IDTitular);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesa");

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
		public bool UpdateDespesa(objDespesa desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				dbTran.AdicionarParametros("@DespesaOrigem", desp.DespesaOrigem);
				dbTran.AdicionarParametros("@DespesaValor", desp.DespesaValor);
				dbTran.AdicionarParametros("@DespesaData", desp.DespesaData);
				dbTran.AdicionarParametros("@IDCredor", desp.IDCredor);
				dbTran.AdicionarParametros("@IDSetor", desp.IDSetor);
				dbTran.AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateUpdateSQL("tblDespesa", "@IDDespesa");

				//--- UPDATE
				dbTran.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		//=============================================================================
		// DESPESA TIPO
		//=============================================================================

		// GET DESPESA TIPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaTipo> GetDespesaTiposList(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaTipo";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY DespesaTipo";

				List<objDespesaTipo> listagem = new List<objDespesaTipo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objDespesaTipo forma = new objDespesaTipo((int)row["IDDespesaTipo"])
					{
						DespesaTipo = (string)row["DespesaTipo"],
						Periodicidade = (byte)row["Periodicidade"],
						DespesaFixa = (bool)row["DespesaFixa"],
						IDDespesaTipoGrupo = (byte)row["IDDespesaTipoGrupo"],
						DespesaTipoGrupo = (string)row["DespesaTipoGrupo"],
						Ativo = (bool)row["Ativo"],
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

		// INSERT DESPESA TIPO
		//------------------------------------------------------------------------------------------------------------
		public int InsertDespesaTipo(objDespesaTipo tipo)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@DespesaTipo", tipo.DespesaTipo);
				db.AdicionarParametros("@Periodicidade", tipo.Periodicidade);
				db.AdicionarParametros("@DespesaFixa", tipo.DespesaFixa);
				db.AdicionarParametros("@IDDespesaTipoGrupo", tipo.IDDespesaTipoGrupo);
				db.AdicionarParametros("@Ativo", tipo.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesaTipo");

				//--- insert and Get new ID
				int newID = (int)db.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE DESPESA TIPO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesaTipo(objDespesaTipo tipo)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDDespesaTipo", tipo.IDDespesaTipo);
				db.AdicionarParametros("@DespesaTipo", tipo.DespesaTipo);
				db.AdicionarParametros("@Periodicidade", tipo.Periodicidade);
				db.AdicionarParametros("@DespesaFixa", tipo.DespesaFixa);
				db.AdicionarParametros("@IDDespesaTipoGrupo", tipo.IDDespesaTipoGrupo);
				db.AdicionarParametros("@Ativo", tipo.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblDespesaTipo", "@IDDespesaTipo");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=================================================================================================
		// DESPESA GRUPO
		//=================================================================================================

		// GET DESPESA GRUPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaTipoGrupo> GetDespesaTipoGruposList(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT G.IDDespesaTipoGrupo, G.DespesaTipoGrupo, " +
					"G.Ativo, T.DespesaTipo " +
					"FROM tblDespesaTipoGrupo AS G " +
					"LEFT JOIN tblDespesaTipo AS T " +
					"ON G.IDDespesaTipoGrupo = T.IDDespesaTipoGrupo";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE G.Ativo = @Ativo";
				}

				query += " ORDER BY DespesaTipoGrupo";

				List<objDespesaTipoGrupo> listagem = new List<objDespesaTipoGrupo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objDespesaTipoGrupo forma = new objDespesaTipoGrupo()
					{
						IDDespesaTipoGrupo = (byte)row["IDDespesaTipoGrupo"],
						DespesaTipoGrupo = (string)row["DespesaTipoGrupo"],
						DespesaTipo = row["DespesaTipo"] == DBNull.Value ? string.Empty : (string)row["DespesaTipo"],
						Ativo = (bool)row["Ativo"],
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

		// GET DESPESA GRUPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaTipoGrupo> GetDespesaTipoGruposWithCount(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT " +
					"G.IDDespesaTipoGrupo, G.DespesaTipoGrupo, G.Ativo, COUNT(T.IDDespesaTipo) AS Quant " +
					"FROM " +
					"tblDespesaTipoGrupo AS G " +
					"LEFT JOIN " +
					"tblDespesaTipo AS T ON G.IDDespesaTipoGrupo = T.IDDespesaTipoGrupo ";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE G.Ativo = @Ativo";
				}

				query += " GROUP BY G.IDDespesaTipoGrupo, G.DespesaTipoGrupo, G.Ativo" + " ORDER BY DespesaTipoGrupo ";

				List<objDespesaTipoGrupo> listagem = new List<objDespesaTipoGrupo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objDespesaTipoGrupo forma = new objDespesaTipoGrupo()
					{
						IDDespesaTipoGrupo = (byte)row["IDDespesaTipoGrupo"],
						DespesaTipoGrupo = (string)row["DespesaTipoGrupo"],
						DespesaTipo = string.Empty,
						Ativo = (bool)row["Ativo"],
						Quant = (int)row["Quant"]
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

		// INSERT DESPESA GRUPO
		//------------------------------------------------------------------------------------------------------------
		public int InsertDespesaTipoGrupo(objDespesaTipoGrupo Grupo)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@DespesaTipoGrupo", Grupo.DespesaTipoGrupo);
				db.AdicionarParametros("@Ativo", Grupo.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesaTipoGrupo");

				//--- insert and Get new ID
				int newID = (int)db.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE DESPESA GRUPO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesaTipoGrupo(objDespesaTipoGrupo Grupo)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDDespesaTipoGrupo", Grupo.IDDespesaTipoGrupo);
				db.AdicionarParametros("@DespesaTipoGrupo", Grupo.DespesaTipoGrupo);
				db.AdicionarParametros("@Ativo", Grupo.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblDespesaTipoGrupo", "@IDDespesaTipoGrupo");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=================================================================================================
		// DESPESA TITULAR
		//=================================================================================================

		// GET DESPESA TITULAR
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaTitular> GetTitularList(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblDespesaTitular";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY Titular";

				List<objDespesaTitular> listagem = new List<objDespesaTitular>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objDespesaTitular titular = new objDespesaTitular()
					{
						IDTitular = (int)row["IDTitular"],
						Titular = (string)row["Titular"],
						CNP = row["CNP"] == DBNull.Value ? string.Empty : (string)row["CNP"],
						Ativo = (bool)row["Ativo"],
					};

					listagem.Add(titular);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT DESPESA TITULAR
		//------------------------------------------------------------------------------------------------------------
		public int InsertTitutar(objDespesaTitular titular)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Titular", titular.Titular);
				db.AdicionarParametros("@CNP", titular.CNP);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesaTitular");

				//--- insert and Get new ID
				int newID = (int)db.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE DESPESA TITULAR
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateTitular(objDespesaTitular titular)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDTitular", titular.IDTitular);
				db.AdicionarParametros("@Titular", titular.Titular);
				db.AdicionarParametros("@CNP", titular.CNP);
				db.AdicionarParametros("@Ativo", titular.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblDespesaTitular", "@IDTitular");

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
