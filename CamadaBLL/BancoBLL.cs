using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class BancoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objBanco> GetListBanco(string banco = "", bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblBancos";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(banco))
				{
					db.AdicionarParametros("@BancoNome", banco);
					query += " WHERE BancoNome LIKE '%'+@BancoNome+'%' ";
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

				query += " ORDER BY BancoNome";

				List<objBanco> listagem = new List<objBanco>();
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

		// GET BANCO
		//------------------------------------------------------------------------------------------------------------
		public objBanco GetBanco(int IDBanco)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblBancos WHERE IDBanco = @IDBanco";
				db.LimparParametros();
				db.AdicionarParametros("@IDBanco", IDBanco);

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
		public objBanco ConvertRowInClass(DataRow row)
		{
			objBanco banco = new objBanco((int)row["IDBanco"]) { };

			banco.BancoNome = (string)row["BancoNome"];
			banco.Sigla = row["Sigla"] == DBNull.Value ? string.Empty : (string)row["Sigla"];
			banco.Ativo = (bool)row["Ativo"];

			return banco;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertBanco(objBanco banco)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@BancoNome", banco.BancoNome);
				db.AdicionarParametros("@Sigla", banco.Sigla);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblBancos");

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
		public bool UpdateBanco(objBanco banco)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDBanco", banco.IDBanco);
				db.AdicionarParametros("@BancoNome", banco.BancoNome);
				db.AdicionarParametros("@Sigla", banco.Sigla);
				db.AdicionarParametros("@Ativo", banco.Ativo); ;

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblBancos", "IDBanco");

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
