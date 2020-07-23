using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

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

		// GET CONTRIBUINTE
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
		public int InsertContribuinte(objContribuinte contribuinte)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- check duplicated CONTRIBUINTE
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();
				db.AdicionarParametros("@Contribuinte", contribuinte.Contribuinte);
				db.ConvertNullParams();

				//--- create and execute query
				string query = "SELECT * FROM tblContribuinte WHERE Contribuinte = @Contribuinte";
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					throw new AppException("Já existe um Contribuinte cadastrado que possui o mesmo nome...");
				}

				//--- check duplicated CNP
				//------------------------------------------------------------------------------------------------------------
				string CNP = contribuinte.CNP.Replace("/", "").Replace("-", "").Replace(".", "").Trim();

				if (!string.IsNullOrEmpty(CNP))
				{
					db.LimparParametros();
					db.AdicionarParametros("@CNP", contribuinte.CNP);
					db.ConvertNullParams();

					//--- create and execute query
					query = "SELECT * FROM tblContribuinte WHERE CNP = @CNP";
					dt = db.ExecutarConsulta(CommandType.Text, query);

					if (dt.Rows.Count > 0)
					{
						throw new AppException("Já existe um Contribuinte cadastrado que possui o mesmo CPF...");
					}
				}
				else
				{
					contribuinte.CNP = string.Empty;
				}

				// INSERT Contribuinte
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Contribuinte", contribuinte.Contribuinte);
				db.AdicionarParametros("@NascimentoData", contribuinte.NascimentoData);
				db.AdicionarParametros("@IDMembro", contribuinte.IDMembro);
				db.AdicionarParametros("@Dizimista", contribuinte.Dizimista);
				db.AdicionarParametros("@CNP", contribuinte.CNP);
				db.AdicionarParametros("@IDCongregacao", contribuinte.IDCongregacao);
				db.AdicionarParametros("@TelefoneCelular", contribuinte.TelefoneCelular);
				db.AdicionarParametros("@Ativo", contribuinte.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				query = "INSERT INTO tblContribuinte (" +
						"Contribuinte, NascimentoData, IDMembro, Dizimista, " +
						"CNP, IDCongregacao, TelefoneCelular, Ativo " +
						") VALUES (" +
						"@Contribuinte, @NascimentoData, @IDMembro, @Dizimista, " +
						"@CNP, @IDCongregacao, @TelefoneCelular, @Ativo)";

				//--- insert
				int newID = (int)db.ExecutarInsertAndGetID(query);

				//--- COMMIT and RETURN
				db.CommitTransaction();
				return newID;

			}
			catch (SqlException ex)
			{
				//--- ROLLBACK
				db.RollBackTransaction();

				if (ex.Number == 2627)
				{
					throw new AppException("Já existe um Contribuinte com o mesmo nome...");
				}
				else
				{
					throw ex;
				}
			}
			catch (Exception ex)
			{
				//--- ROLLBACK
				db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateContribuinte(objContribuinte contribuinte)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- check duplicated CONTRIBUINTE
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();
				db.AdicionarParametros("@Contribuinte", contribuinte.Contribuinte);
				db.AdicionarParametros("@IDContribuinte", contribuinte.IDContribuinte);
				db.ConvertNullParams();

				//--- create and execute query
				string query = "SELECT * FROM tblContribuinte WHERE Contribuinte = @Contribuinte AND IDContribuinte <> @IDContribuinte";
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					throw new AppException("Já existe um Contribuinte cadastrado que possui o mesmo nome...");
				}

				//--- check duplicated CNP
				//------------------------------------------------------------------------------------------------------------
				string CNP = contribuinte.CNP.Replace("/", "").Replace("-", "").Replace(".", "").Trim();

				if (!string.IsNullOrEmpty(CNP))
				{
					db.LimparParametros();
					db.AdicionarParametros("@CNP", contribuinte.CNP);
					db.AdicionarParametros("@IDContribuinte", contribuinte.IDContribuinte);
					db.ConvertNullParams();

					//--- create and execute query
					query = "SELECT * FROM tblContribuinte WHERE CNP = @CNP AND IDContribuinte <> @IDContribuinte";
					dt = db.ExecutarConsulta(CommandType.Text, query);

					if (dt.Rows.Count > 0)
					{
						throw new AppException("Já existe um Contribuinte cadastrado que possui o mesmo CPF...");
					}
				}
				else
				{
					contribuinte.CNP = string.Empty;
				}

				//--- UPDATE
				//------------------------------------------------------------------------------------------------------------//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDContribuinte", contribuinte.IDContribuinte);
				db.AdicionarParametros("@Contribuinte", contribuinte.Contribuinte);
				db.AdicionarParametros("@NascimentoData", contribuinte.NascimentoData);
				db.AdicionarParametros("@IDMembro", contribuinte.IDMembro);
				db.AdicionarParametros("@Dizimista", contribuinte.Dizimista);
				db.AdicionarParametros("@CNP", contribuinte.CNP);
				db.AdicionarParametros("@IDCongregacao", contribuinte.IDCongregacao);
				db.AdicionarParametros("@TelefoneCelular", contribuinte.TelefoneCelular);
				db.AdicionarParametros("@Ativo", contribuinte.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				query = "UPDATE tblContribuinte SET " +
					    "Contribuinte = @Contribuinte, NascimentoData = @NascimentoData, " +
					    "IDMembro = @IDMembro, Dizimista = @Dizimista, TelefoneCelular = @TelefoneCelular, " +
					    "CNP = @CNP, IDCongregacao = @IDCongregacao, Ativo = @Ativo " +
					    "WHERE " +
					    "IDContribuinte = @IDContribuinte";
				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				db.CommitTransaction();
				return true;

			}
			catch (SqlException ex)
			{
				//--- ROLLBACK
				db.RollBackTransaction();

				if (ex.Number == 2627)
				{
					throw new AppException("Já existe um Contribuinte com o mesmo nome...");
				}
				else
				{
					throw ex;
				}
			}
			catch (Exception ex)
			{
				//--- ROLLBACK
				db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
