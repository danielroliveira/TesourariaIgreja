using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class DespesaPeriodicaBLL
	{
		//=============================================================================
		// DESPESA
		//=============================================================================

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaPeriodica> GetListDespesaPeriodica()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaPeriodica";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDDespesa";

				List<objDespesaPeriodica> listagem = new List<objDespesaPeriodica>();
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

		// GET LIST OF WITH DETAILS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaPeriodica> GetListDespesaPeriodica(
			bool Ativa,
			int? IDSetor = null,
			int? IDDespesaTipo = null,
			int? IDCredor = null,
			int? IDAPagarForma = null,
			DateTime? IniciarData = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaPeriodica";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add Ativa
				db.AdicionarParametros("@Ativa", Ativa);
				query += " WHERE Ativa = @Ativa";
				myWhere = true;

				// add IDSetor
				if (IDSetor != null)
				{
					db.AdicionarParametros("@IDSetor", IDSetor);
					query += myWhere ? " AND IDSetor = @IDSetor" : " WHERE IDSetor = @IDSetor";
					myWhere = true;
				}

				// add IDDespesaTipo
				if (IDDespesaTipo != null)
				{
					db.AdicionarParametros("@IDDespesaTipo", IDDespesaTipo);
					query += myWhere ? " AND IDDespesaTipo = @IDDespesaTipo" : " WHERE IDDespesaTipo = @IDDespesaTipo";
					myWhere = true;
				}

				// add IniciarData
				if (IniciarData != null)
				{
					db.AdicionarParametros("@IniciarData", (DateTime)IniciarData);
					query += myWhere ? " AND IniciarData <= @IniciarData" : " WHERE IniciarData <= @IniciarData";
					myWhere = true;
				}

				// add IDCredor
				if (IDCredor != null)
				{
					db.AdicionarParametros("@IDCredor", IDCredor);
					query += myWhere ? " AND IDCredor = @IDCredor" : " WHERE IDCredor = @IDCredor";
					myWhere = true;
				}

				// add IDAPagarForma
				if (IDAPagarForma != null)
				{
					db.AdicionarParametros("@IDAPagarForma", IDAPagarForma);
					query += myWhere ? " AND IDAPagarForma = @IDAPagarForma" : " WHERE IDAPagarForma = @IDAPagarForma";
					myWhere = true;
				}

				query += " ORDER BY IniciarData";

				List<objDespesaPeriodica> listagem = new List<objDespesaPeriodica>();
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

		// GET DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		public objDespesaPeriodica GetDespesaPeriodica(long IDDespesa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaPeriodica WHERE IDDespesa = @IDDespesa";
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", IDDespesa);

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
		public objDespesaPeriodica ConvertRowInClass(DataRow row)
		{
			objDespesaPeriodica despesa = new objDespesaPeriodica((long)row["IDDespesa"])
			{
				DespesaOrigem = 2,
				DespesaDescricao = (string)row["DespesaDescricao"],
				DespesaData = (DateTime)row["DespesaData"],
				DespesaValor = (decimal)row["DespesaValor"],
				IDCredor = (int)row["IDCredor"],
				Credor = (string)row["Credor"],
				IDDespesaTipo = (int)row["IDDespesaTipo"],
				DespesaTipo = (string)row["DespesaTipo"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDAPagarForma = (int)row["IDAPagarForma"],
				APagarForma = (string)row["APagarForma"],
				IniciarData = (DateTime)row["IniciarData"],
				RecorrenciaTipo = (byte)row["RecorrenciaTipo"],
				RecorrenciaTipoDescricao = (string)row["RecorrenciaTipoDescricao"],
				RecorrenciaDia = row["RecorrenciaDia"] == DBNull.Value ? null : (byte?)row["RecorrenciaDia"],
				RecorrenciaMes = row["RecorrenciaMes"] == DBNull.Value ? null : (byte?)row["RecorrenciaMes"],
				RecorrenciaRepeticao = row["RecorrenciaRepeticao"] == DBNull.Value ? null : (short?)row["RecorrenciaRepeticao"],
				RecorrenciaSemana = row["RecorrenciaSemana"] == DBNull.Value ? null : (byte?)row["RecorrenciaSemana"],
				Ativa = (bool)row["Ativa"],
				Instalacao = row["Instalacao"] == DBNull.Value ? string.Empty : (string)row["Instalacao"],
			};

			return despesa;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesa(objDespesaPeriodica desp)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

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

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesa");

				//--- insert and Get new ID
				long newID = dbTran.ExecutarInsertAndGetID(query);

				//--- insert Despesa Periodica
				desp.IDDespesa = newID;
				InsertDespesaPeriodica(desp, dbTran);

				dbTran.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		private void InsertDespesaPeriodica(objDespesaPeriodica desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@IDAPagarForma", desp.IDAPagarForma);
				dbTran.AdicionarParametros("@IniciarData", desp.IniciarData);
				dbTran.AdicionarParametros("@RecorrenciaTipo", desp.RecorrenciaTipo);
				dbTran.AdicionarParametros("@RecorrenciaDia", desp.RecorrenciaDia);
				dbTran.AdicionarParametros("@RecorrenciaMes", desp.RecorrenciaMes);
				dbTran.AdicionarParametros("@RecorrenciaRepeticao", desp.RecorrenciaRepeticao);
				dbTran.AdicionarParametros("@RecorrenciaSemana", desp.RecorrenciaSemana);
				dbTran.AdicionarParametros("@Instalacao", desp.Instalacao);
				dbTran.AdicionarParametros("@Ativa", desp.Ativa);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesaPeriodica");

				//--- insert
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesa(objDespesaPeriodica desp, object dbTran = null)
		{
			bool isLocal = dbTran == null;

			try
			{
				if (isLocal)
				{
					dbTran = new AcessoDados();
					((AcessoDados)dbTran).BeginTransaction();
				}

				//--- clear Params
				((AcessoDados)dbTran).LimparParametros();

				//--- define Params
				((AcessoDados)dbTran).AdicionarParametros("@IDDespesa", desp.IDDespesa);
				((AcessoDados)dbTran).AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				((AcessoDados)dbTran).AdicionarParametros("@DespesaOrigem", desp.DespesaOrigem);
				((AcessoDados)dbTran).AdicionarParametros("@DespesaValor", desp.DespesaValor);
				((AcessoDados)dbTran).AdicionarParametros("@DespesaData", desp.DespesaData);
				((AcessoDados)dbTran).AdicionarParametros("@IDCredor", desp.IDCredor);
				((AcessoDados)dbTran).AdicionarParametros("@IDSetor", desp.IDSetor);
				((AcessoDados)dbTran).AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);

				//--- convert null parameters
				((AcessoDados)dbTran).ConvertNullParams();

				string query = ((AcessoDados)dbTran).CreateUpdateSQL("tblDespesa", "@IDDespesa");

				//--- UPDATE
				((AcessoDados)dbTran).ExecutarManipulacao(CommandType.Text, query);

				//--- UPDATE Despesa Periodica
				UpdateDespesaPeriodica(desp, (AcessoDados)dbTran);

				if (isLocal) ((AcessoDados)dbTran).CommitTransaction();
				return true;

			}
			catch (Exception ex)
			{
				if (isLocal) ((AcessoDados)dbTran).RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		private void UpdateDespesaPeriodica(objDespesaPeriodica desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@IDAPagarForma", desp.IDAPagarForma);
				dbTran.AdicionarParametros("@IniciarData", desp.IniciarData);
				dbTran.AdicionarParametros("@RecorrenciaTipo", desp.RecorrenciaTipo);
				dbTran.AdicionarParametros("@RecorrenciaDia", desp.RecorrenciaDia);
				dbTran.AdicionarParametros("@RecorrenciaMes", desp.RecorrenciaMes);
				dbTran.AdicionarParametros("@RecorrenciaRepeticao", desp.RecorrenciaRepeticao);
				dbTran.AdicionarParametros("@RecorrenciaSemana", desp.RecorrenciaSemana);
				dbTran.AdicionarParametros("@Ativa", desp.Ativa);
				dbTran.AdicionarParametros("@Instalacao", desp.Instalacao);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateUpdateSQL("tblDespesaPeriodica", "@IDDespesa");

				//--- update
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE VALOR DA DESPESA
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesaValor(long IDDespesa, decimal newValor)
		{
			try
			{
				var db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDDespesa", IDDespesa);
				db.AdicionarParametros("@DespesaValor", newValor);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblDespesa", "@IDDespesa");

				//--- UPDATE
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE DESPESA ATIVO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesaPeriodicaAtiva(long IDDespesa, bool ativo)
		{
			try
			{
				var db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDDespesa", IDDespesa);
				db.AdicionarParametros("@Ativa", ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblDespesaPeriodica", "@IDDespesa");

				//--- UPDATE
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteDespesaPeriodica(objDespesaPeriodica periodica)
		{
			AcessoDados dbTran = null;

			//--- get despesa from periodica
			objDespesa despesa = new objDespesa(periodica.IDDespesa)
			{
				DespesaDescricao = periodica.DespesaDescricao,
				DespesaOrigem = periodica.DespesaOrigem,
				DespesaValor = periodica.DespesaValor,
				DespesaData = periodica.DespesaData,
				IDCredor = periodica.IDCredor,
				IDSetor = periodica.IDSetor,
				IDDespesaTipo = periodica.IDDespesaTipo,
			};

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// 1 - CHECK APagar and Movimentacao Saida
				//------------------------------------------------------------------------------------------------------------
				List<objAPagar> listAPagar = new List<objAPagar>();
				List<objMovimentacao> listMovSaidas = new List<objMovimentacao>();

				DespesaBLL dBLL = new DespesaBLL();

				if (!dBLL.VerifyBeforeDelete(despesa, ref listAPagar, ref listMovSaidas, dbTran)) return false;

				// 2 - delete ALL APAGAR 
				//------------------------------------------------------------------------------------------------------------
				if (listAPagar.Count > 0)
				{
					APagarBLL pBLL = new APagarBLL();

					foreach (objAPagar pagar in listAPagar)
					{
						pBLL.DeleteAPagar(pagar, dbTran);
					}
				}

				// 3 - delete DESPESA COMUM
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", despesa.IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				string query = "DELETE tblDespesaPeriodica WHERE IDDespesa = @IDDespesa";

				//--- DELETE
				dbTran.ExecutarManipulacao(CommandType.Text, query);

				// 4 - delete DESPESA DATA PERIODO
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", despesa.IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				query = "DELETE tblDespesaDataPeriodo WHERE IDDespesa = @IDDespesa";

				//--- DELETE
				dbTran.ExecutarManipulacao(CommandType.Text, query);

				// 5 - delete DESPESA
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", despesa.IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				query = "DELETE tblDespesa WHERE IDDespesa = @IDDespesa";

				//--- DELETE
				dbTran.ExecutarManipulacao(CommandType.Text, query);

				// 7 - COMMIT AND RETURN
				//------------------------------------------------------------------------------------------------------------
				dbTran.CommitTransaction();
				return true;
			}
			catch (AppException ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}


	}
}
