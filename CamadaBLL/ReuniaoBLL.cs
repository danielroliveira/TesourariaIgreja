using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class ReuniaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objReuniao> GetListReuniao(string reuniao, bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryReunioes";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(reuniao))
				{
					db.AdicionarParametros("@Reuniao", reuniao);
					query += " WHERE Reuniao LIKE '%'+@Reuniao+'%' ";
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

				query += " ORDER BY Reuniao";

				List<objReuniao> listagem = new List<objReuniao>();
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
		public objReuniao GetReuniao(int IDReuniao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryReunioes WHERE IDReuniao = @IDReuniao";
				db.LimparParametros();
				db.AdicionarParametros("@IDReuniao", IDReuniao);

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
		public objReuniao ConvertRowInClass(DataRow row)
		{
			objReuniao reuniao = new objReuniao((int)row["IDReuniao"])
			{ };

			reuniao.Reuniao = (string)row["Reuniao"];
			reuniao.IDCongregacao = row["IDCongregacao"] == DBNull.Value ? null : (int?)row["IDCongregacao"];
			reuniao.Congregacao = row["Congregacao"] == DBNull.Value ? "" : (string)row["Congregacao"];
			reuniao.RecorrenciaTipo = row["RecorrenciaTipo"] == DBNull.Value ? (byte)0 : (byte)row["RecorrenciaTipo"];
			reuniao.RecorrenciaTipoDescricao = row["RecorrenciaTipoDescricao"] == DBNull.Value ? "" : (string)row["RecorrenciaTipoDescricao"];
			reuniao.RecorrenciaRepeticao = row["RecorrenciaRepeticao"] == DBNull.Value ? (short)0 : (short)row["RecorrenciaRepeticao"];
			reuniao.RecorrenciaDia = row["RecorrenciaDia"] == DBNull.Value ? (byte)0 : (byte)row["RecorrenciaDia"];
			reuniao.RecorrenciaSemana = row["RecorrenciaSemana"] == DBNull.Value ? (byte)0 : (byte)row["RecorrenciaSemana"];
			reuniao.RecorrenciaMes = row["RecorrenciaMes"] == DBNull.Value ? (byte)0 : (byte)row["RecorrenciaMes"];
			if (row["IniciarData"] != DBNull.Value) reuniao.IniciarData = (DateTime)row["IniciarData"];
			reuniao.Ativa = (bool)row["Ativa"];

			return reuniao;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertReuniao(objReuniao reuniao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Reuniao", reuniao.Reuniao);
				db.AdicionarParametros("@IDCongregacao", reuniao.IDCongregacao);
				db.AdicionarParametros("@RecorrenciaTipo", reuniao.RecorrenciaTipo);
				db.AdicionarParametros("@RecorrenciaRepeticao", reuniao.RecorrenciaRepeticao);
				db.AdicionarParametros("@RecorrenciaDia", reuniao.RecorrenciaDia);
				db.AdicionarParametros("@RecorrenciaSemana", reuniao.RecorrenciaSemana);
				db.AdicionarParametros("@RecorrenciaMes", reuniao.RecorrenciaMes);
				db.AdicionarParametros("@IniciarData", reuniao.IniciarData);
				db.AdicionarParametros("@Ativa", reuniao.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "INSERT INTO tblReunioes (" +
							   "Reuniao, " +
							   "IDCongregacao, " +
							   "RecorrenciaTipo, " +
							   "RecorrenciaRepeticao, " +
							   "RecorrenciaDia, " +
							   "RecorrenciaSemana, " +
							   "RecorrenciaMes, " +
							   "IniciarData, " +
							   "Ativa " +
							   ") VALUES (" +
							   "@Reuniao, " +
							   "@IDCongregacao, " +
							   "@RecorrenciaTipo, " +
							   "@RecorrenciaRepeticao, " +
							   "@RecorrenciaDia, " +
							   "@RecorrenciaSemana, " +
							   "@RecorrenciaMes, " +
							   "@IniciarData, " +
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
		public bool UpdateReuniao(objReuniao reuniao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDReuniao", reuniao.IDReuniao);
				db.AdicionarParametros("@Reuniao", reuniao.Reuniao);
				db.AdicionarParametros("@IDCongregacao", reuniao.IDCongregacao);
				db.AdicionarParametros("@RecorrenciaTipo", reuniao.RecorrenciaTipo);
				db.AdicionarParametros("@RecorrenciaRepeticao", reuniao.RecorrenciaRepeticao);
				db.AdicionarParametros("@RecorrenciaDia", reuniao.RecorrenciaDia);
				db.AdicionarParametros("@RecorrenciaSemana", reuniao.RecorrenciaSemana);
				db.AdicionarParametros("@RecorrenciaMes", reuniao.RecorrenciaMes);
				db.AdicionarParametros("@IniciarData", reuniao.IniciarData);
				db.AdicionarParametros("@Ativa", reuniao.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "UPDATE tblReunioes SET " +
							   "Reuniao = @Reuniao, " +
							   "IDCongregacao = @IDCongregacao, " +
							   "RecorrenciaTipo = @RecorrenciaTipo, " +
							   "RecorrenciaRepeticao = @RecorrenciaRepeticao, " +
							   "RecorrenciaDia = @RecorrenciaDia, " +
							   "RecorrenciaSemana = @RecorrenciaSemana, " +
							   "RecorrenciaMes = @RecorrenciaMes, " +
							   "IniciarData = @IniciarData, " +
							   "Ativa = @Ativa " +
							   "WHERE " +
							   "IDReuniao = @IDReuniao";
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
