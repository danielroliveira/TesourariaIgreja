using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class CampanhaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objCampanha> GetListCampanha(string campanha, bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCampanha";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(campanha))
				{
					db.AdicionarParametros("@Campanha", campanha);
					query += " WHERE Campanha LIKE '%'+@Campanha+'%' ";
					haveWhere = true;
				}

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					if (haveWhere)
						query += " AND Ativa = @Ativa";
					else
						query += " WHERE Ativa = @Ativa";
				}

				query += " ORDER BY Campanha";

				List<objCampanha> listagem = new List<objCampanha>();
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

		// GET CAMPANHA
		//------------------------------------------------------------------------------------------------------------
		public objCampanha GetCampanha(int IDCampanha)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCampanha WHERE IDCampanha = @IDCampanha";
				db.LimparParametros();
				db.AdicionarParametros("@IDCampanha", IDCampanha);

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
		public objCampanha ConvertRowInClass(DataRow row)
		{
			objCampanha campanha = new objCampanha((int)row["IDCampanha"])
			{

				Campanha = (string)row["Campanha"],
				IDSetor = row["IDSetor"] == DBNull.Value ? null : (int?)row["IDSetor"],
				Setor = row["Setor"] == DBNull.Value ? "" : (string)row["Setor"],
				CampanhaSaldo = row["CampanhaSaldo"] == DBNull.Value ? 0 : (decimal)row["CampanhaSaldo"],
				InicioData = row["InicioData"] == DBNull.Value ? DateTime.Today : (DateTime)row["InicioData"],
				ConclusaoData = row["ConclusaoData"] == DBNull.Value ? null : (DateTime?)row["ConclusaoData"],
				Ativa = (bool)row["Ativa"],
				ObjetivoValor = (decimal)row["ObjetivoValor"],

			};

			return campanha;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertCampanha(objCampanha campanha)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Campanha", campanha.Campanha);
				db.AdicionarParametros("@IDSetor", campanha.IDSetor);
				db.AdicionarParametros("@CampanhaSaldo", campanha.CampanhaSaldo);
				db.AdicionarParametros("@ObjetivoValor", campanha.ObjetivoValor);
				db.AdicionarParametros("@InicioData", campanha.InicioData);
				db.AdicionarParametros("@Ativa", campanha.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblCampanha");

				//--- insert
				return (int)db.ExecutarInsertAndGetID(query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCampanha(objCampanha campanha)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCampanha", campanha.IDCampanha);
				db.AdicionarParametros("@Campanha", campanha.Campanha);
				db.AdicionarParametros("@IDSetor", campanha.IDSetor);
				db.AdicionarParametros("@CampanhaSaldo", campanha.CampanhaSaldo);
				db.AdicionarParametros("@ObjetivoValor", campanha.ObjetivoValor);
				db.AdicionarParametros("@InicioData", campanha.InicioData);
				db.AdicionarParametros("@ConclusaoData", campanha.ConclusaoData);
				db.AdicionarParametros("@Ativa", campanha.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblCampanha", "IDCampanha");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET TOTAL SALDO CAMPANHA
		//------------------------------------------------------------------------------------------------------------
		public decimal GetCampanhaSaldo(int IDCampanha)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT SUM(ValorRecebido) AS Total FROM qryContribuicao WHERE IDCampanha = @IDCampanha";
				db.LimparParametros();
				db.AdicionarParametros("@IDCampanha", IDCampanha);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				decimal saldo = dt.Rows[0][0] == DBNull.Value ? 0 : (decimal)dt.Rows[0][0];

				return saldo;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
