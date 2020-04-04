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
	public class ContribuinteBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuinte> GetListContribuinte(string contribuinte, bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuinte";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(contribuinte))
				{
					db.AdicionarParametros("@Contribuinte", contribuinte);
					query += " WHERE Contribuinte LIKE '%'+@Contribuinte+'%' ";
					haveWhere = true;
				}

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					if (haveWhere)
						query += " AND Ativo = @Ativo";
					else
						query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY Contribuinte";

				List<objContribuinte> listagem = new List<objContribuinte>();
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
		public objContribuinte GetContribuinte(int IDContribuinte)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuinte WHERE IDContribuinte = @IDContribuinte";
				db.LimparParametros();
				db.AdicionarParametros("@IDContribuinte", IDContribuinte);

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
		public objContribuinte ConvertRowInClass(DataRow row)
		{
			objContribuinte contribuinte = new objContribuinte((int)row["IDContribuinte"])
			{
				Contribuinte = (string)row["Contribuinte"],
				NascimentoData = row["NascimentoData"] == DBNull.Value ? null : (DateTime?)row["NascimentoData"],
				IDMembro = row["IDMembro"] == DBNull.Value ? null : (int?)row["IDMembro"],
				Dizimista = row["Dizimista"] == DBNull.Value ? false : (bool)row["Dizimista"],
				CNP = row["CNP"] == DBNull.Value ? "" : (string)row["CNP"],
				Ativo = (bool)row["Ativo"],
				IDCongregacao = row["IDCongregacao"] == DBNull.Value ? null : (int?)row["IDCongregacao"],
				TelefoneCelular = row["TelefoneCelular"] == DBNull.Value ? "" : (string)row["TelefoneCelular"],
				Congregacao = row["Congregacao"] == DBNull.Value ? "" : (string)row["Congregacao"]
			};

			return contribuinte;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertContribuinte(objContribuinte congregacao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Contribuinte", congregacao.Contribuinte);
				db.AdicionarParametros("@NascimentoData", congregacao.NascimentoData);
				db.AdicionarParametros("@IDMembro", congregacao.IDMembro);
				db.AdicionarParametros("@Dizimista", congregacao.Dizimista);
				db.AdicionarParametros("@CNP", congregacao.CNP);
				db.AdicionarParametros("@IDCongregacao", congregacao.IDCongregacao);
				db.AdicionarParametros("@TelefoneCelular", congregacao.TelefoneCelular);
				db.AdicionarParametros("@Ativo", congregacao.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "INSERT INTO tblContribuinte (" +
							   "Contribuinte, NascimentoData, IDMembro, Dizimista, " +
							   "CNP, IDCongregacao, TelefoneCelular, Ativo " +
							   ") VALUES (" +
							   "@Contribuinte, @NascimentoData, @IDMembro, @Dizimista, " +
							   "@CNP, @IDCongregacao, @TelefoneCelular, @Ativo)";
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
		public bool UpdateContribuinte(objContribuinte congregacao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDContribuinte", congregacao.IDContribuinte);
				db.AdicionarParametros("@Contribuinte", congregacao.Contribuinte);
				db.AdicionarParametros("@NascimentoData", congregacao.NascimentoData);
				db.AdicionarParametros("@IDMembro", congregacao.IDMembro);
				db.AdicionarParametros("@Dizimista", congregacao.Dizimista);
				db.AdicionarParametros("@CNP", congregacao.CNP);
				db.AdicionarParametros("@IDCongregacao", congregacao.IDCongregacao);
				db.AdicionarParametros("@TelefoneCelular", congregacao.TelefoneCelular);
				db.AdicionarParametros("@Ativo", congregacao.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "UPDATE tblContribuinte SET " +
							   "Contribuinte = @Contribuinte, NascimentoData = @NascimentoData, " +
							   "IDMembro = @IDMembro, Dizimista = @Dizimista, TelefoneCelular = @TelefoneCelular, " +
							   "CNP = @CNP, IDCongregacao = @IDCongregacao, Ativo = @Ativo " +
							   "WHERE " +
							   "IDContribuinte = @IDContribuinte";
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
