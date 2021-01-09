using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CamadaBLL
{
	public class ReuniaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objReuniao> GetListReuniao(string reuniao, bool? Ativa = null, int? IDCongregacao = null)
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

					haveWhere = true;
				}

				if (IDCongregacao != null)
				{
					db.AdicionarParametros("@IDCongregacao", IDCongregacao);
					if (haveWhere)
						query += " AND IDCongregacao = @IDCongregacao";
					else
						query += " WHERE IDCongregacao = @IDCongregacao";
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
		public int InsertReuniao(objReuniao reuniao, object dbTran = null)
		{
			AcessoDados db = (AcessoDados)dbTran;

			try
			{
				if (db == null) db = new AcessoDados();

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
				string query = db.CreateInsertSQL("tblReunioes");

				//--- insert
				return (int)db.ExecutarInsertAndGetID(query);

			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627)
				{
					if (db.isTran) // reuniao duplicada mas esta inserindo em grupo de congregacoes
					{
						return 0;
					}
					else // reuniao duplicada
					{
						throw new AppException("Já existe um Reunião com o mesmo nome...");
					}
				}
				else
				{
					throw ex;
				}
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
				string query = db.CreateUpdateSQL("tblReunioes", "IDReuniao");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT REUNIAO FOR ALL CONGREGACOES ATIVAS
		//------------------------------------------------------------------------------------------------------------
		public int InsertReuniaoAllCongregacoes(objReuniao reuniao)
		{
			AcessoDados dbTran = null;

			try
			{
				// create transaction
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// get list of congregacoes ATIVAS
				List<objCongregacao> listCong = new CongregacaoBLL().GetListCongregacao(true);

				// check count congregacoes
				if (listCong.Count == 0)
				{
					throw new Exception("Não existe nenhuma congregação cadastrada ainda...");
				}

				// last Inserted ID
				int ID = 0;

				foreach (var cong in listCong)
				{
					try
					{
						int lastID;
						reuniao.IDCongregacao = cong.IDCongregacao;
						reuniao.Congregacao = cong.Congregacao;
						lastID = InsertReuniao(reuniao, dbTran);
						ID = lastID;
					}
					catch (AppException)
					{
						continue;
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}

				dbTran.CommitTransaction();
				return ID;
			}
			catch (Exception)
			{
				dbTran.RollBackTransaction();
				throw;
			}
		}

		// DELETE REUNIAO IF IS POSSIBLE
		//------------------------------------------------------------------------------------------------------------
		public void DeleteReuniao(objReuniao reuniao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				// 1. check unused reuniao
				//-------------------------------------------------------------------------

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDReuniao", reuniao.IDReuniao);

				//--- create query
				string query = "SELECT COUNT(IDContribuicao) AS Total " +
					"FROM tblContribuicao " +
					"WHERE IDReuniao = @IDReuniao";

				//--- QUERY
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new AppException("Não houve retorno do número de registro associados à reunião...");
				}
				else if ((int)dt.Rows[0][0] > 0)
				{
					throw new AppException($"Essa reunião não pode ser excluída porque existem {(int)dt.Rows[0][0]} contribuições ligadas a ela...");
				}

				// 2. DELETE
				//-------------------------------------------------------------------------

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDReuniao", reuniao.IDReuniao);

				//--- create query
				query = "DELETE tblReunioes WHERE IDReuniao = @IDReuniao";

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
