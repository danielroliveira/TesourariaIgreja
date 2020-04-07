using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDTO;
using CamadaDAL;

namespace CamadaBLL
{
	public class SetorBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objSetor> GetListSetor(string setor, bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qrySetor";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(setor))
				{
					db.AdicionarParametros("@Setor", setor);
					query += " WHERE Setor LIKE '%'+@Setor+'%' ";
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

				query += " ORDER BY Setor";

				List<objSetor> listagem = new List<objSetor>();
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

		// GET CONGREGACAO
		//------------------------------------------------------------------------------------------------------------
		public objSetor GetSetor(int IDSetor)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qrySetor WHERE IDSetor = @IDSetor";
				db.LimparParametros();
				db.AdicionarParametros("@IDSetor", IDSetor);

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
		public objSetor ConvertRowInClass(DataRow row)
		{
			objSetor setor = new objSetor((int)row["IDSetor"])
			{ };

			setor.Setor = (string)row["Setor"];
			setor.SetorSaldo = row["SetorSaldo"] == DBNull.Value ? 0 : (decimal)row["SetorSaldo"];
			setor.IDCongregacao = row["IDCongregacao"] == DBNull.Value ? null : (int?)row["IDCongregacao"];
			setor.Congregacao = row["Congregacao"] == DBNull.Value ? "" : (string)row["Congregacao"];
			setor.Ativa = (bool)row["Ativa"];

			return setor;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertSetor(objSetor congregacao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Setor", congregacao.Setor);
				db.AdicionarParametros("@SetorSaldo", congregacao.SetorSaldo);
				db.AdicionarParametros("@IDCongregacao", congregacao.IDCongregacao);
				db.AdicionarParametros("@Ativa", congregacao.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "INSERT INTO tblSetor (" +
							   "Setor, " +
							   "SetorSaldo, " +
							   "IDCongregacao, " +
							   "Ativa " +
							   ") VALUES (" +
							   "@Setor, " +
							   "@SetorSaldo, " +
							   "@IDCongregacao, " +
							   "@Ativa)";
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
		public bool UpdateSetor(objSetor congregacao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDSetor", congregacao.IDSetor);
				db.AdicionarParametros("@Setor", congregacao.Setor);
				db.AdicionarParametros("@SetorSaldo", congregacao.SetorSaldo);
				db.AdicionarParametros("@IDCongregacao", congregacao.IDCongregacao);
				db.AdicionarParametros("@Ativa", congregacao.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "UPDATE tblSetor SET " +
							   "Setor = @Setor, " +
							   "SetorSaldo = @SetorSaldo, " +
							   "IDCongregacao = @IDCongregacao, " +
							   "Ativa = @Ativa " +
							   "WHERE " +
							   "IDSetor = @IDSetor";
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
