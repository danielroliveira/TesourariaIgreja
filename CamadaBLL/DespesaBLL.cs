﻿using CamadaDAL;
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

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesa> GetListDespesa()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesa";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDDespesa";

				List<objDespesa> listagem = new List<objDespesa>();
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
		public List<objDespesa> GetListDespesa(
			int? IDConta = null,
			int? IDSetor = null,
			byte? IDEntradaForma = null,
			byte? IDDespesaTipo = null,
			int? IDContribuinte = null,
			int? IDCampanha = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesa";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add IDConta
				if (IDConta != null)
				{
					db.AdicionarParametros("@IDConta", IDConta);
					query += myWhere ? " AND IDConta = @IDConta" : " WHERE IDConta = @IDConta";
					myWhere = true;
				}

				// add IDSetor
				if (IDSetor != null)
				{
					db.AdicionarParametros("@IDSetor", IDSetor);
					query += myWhere ? " AND IDSetor = @IDSetor" : " WHERE IDSetor = @IDSetor";
					myWhere = true;
				}

				// add IDEntradaForma
				if (IDEntradaForma != null)
				{
					db.AdicionarParametros("@IDEntradaForma", IDEntradaForma);
					query += myWhere ? " AND IDEntradaForma = @IDEntradaForma" : " WHERE IDEntradaForma = @IDEntradaForma";
					myWhere = true;
				}

				// add IDDespesaTipo
				if (IDDespesaTipo != null)
				{
					db.AdicionarParametros("@IDDespesaTipo", IDDespesaTipo);
					query += myWhere ? " AND IDDespesaTipo = @IDDespesaTipo" : " WHERE IDDespesaTipo = @IDDespesaTipo";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND DespesaData >= @DataInicial" : " WHERE DespesaData >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND DespesaData <= @DataFinal" : " WHERE DespesaData <= @DataFinal";
					myWhere = true;
				}

				// add IDContribuinte
				if (IDContribuinte != null)
				{
					db.AdicionarParametros("@IDContribuinte", IDContribuinte);
					query += myWhere ? " AND IDContribuinte = @IDContribuinte" : " WHERE IDContribuinte = @IDContribuinte";
					myWhere = true;
				}

				// add IDCampanha
				if (IDCampanha != null)
				{
					db.AdicionarParametros("@IDCampanha", IDCampanha);
					query += myWhere ? " AND IDCampanha = @IDCampanha" : " WHERE IDCampanha = @IDCampanha";
					myWhere = true;
				}

				query += " ORDER BY DespesaData";

				List<objDespesa> listagem = new List<objDespesa>();
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

		// GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		public objDespesa GetDespesa(int IDDespesa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesa WHERE IDDespesa = @IDDespesa";
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
		public objDespesa ConvertRowInClass(DataRow row)
		{
			objDespesa despesa = new objDespesa((long)row["IDDespesa"])
			{
				DespesaDescricao = (string)row["DespesaDesricao"],
				IDCredor = (int)row["IDCredor"],
				Credor = (string)row["Credor"],
				DespesaData = (DateTime)row["DespesaData"],
				IDDespesaTipo = (int)row["IDDespesaTipo"],
				DespesaTipo = (string)row["DespesaTipo"],
				IDDocumentoTipo = (byte)row["IDDocumentoTipo"],
				DocumentoTipo = (string)row["DocumentoTipo"],
				DespesaValor = (decimal)row["DespesaValor"],
				DocumentoNumero = (string)row["DocumentoNumero"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				Parcelas = (byte)row["Parcelas"],
				Prioridade = (byte)row["Prioridade"],
			};

			return despesa;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertDespesa(objDespesa desp)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				db.AdicionarParametros("@DespesaValor", desp.DespesaValor);
				db.AdicionarParametros("@DocumentoNumero", desp.DocumentoNumero);
				db.AdicionarParametros("@DespesaData", desp.DespesaData);
				db.AdicionarParametros("@IDCredor", desp.IDCredor);
				db.AdicionarParametros("@IDSetor", desp.IDSetor);
				db.AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);
				db.AdicionarParametros("@IDDocumentoTipo", desp.IDDocumentoTipo);
				db.AdicionarParametros("@IDSituacao", desp.IDSituacao);
				db.AdicionarParametros("@Parcelas", desp.Parcelas);
				db.AdicionarParametros("@Prioridade", desp.Prioridade);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesa");

				//--- insert and Get new ID
				int newID = db.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesa(objDespesa desp)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				db.AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				db.AdicionarParametros("@DespesaValor", desp.DespesaValor);
				db.AdicionarParametros("@DocumentoNumero", desp.DocumentoNumero);
				db.AdicionarParametros("@DespesaData", desp.DespesaData);
				db.AdicionarParametros("@IDCredor", desp.IDCredor);
				db.AdicionarParametros("@IDSetor", desp.IDSetor);
				db.AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);
				db.AdicionarParametros("@IDDocumentoTipo", desp.IDDocumentoTipo);
				db.AdicionarParametros("@IDSituacao", desp.IDSituacao);
				db.AdicionarParametros("@Parcelas", desp.Parcelas);
				db.AdicionarParametros("@Prioridade", desp.Prioridade);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblDespesa", "@IDDespesa");

				//--- update
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
		public bool DeleteDespesa(int IDDespesa)
		{
			throw new NotImplementedException("Em implementação");
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

				string query = "SELECT * FROM tblDespesaTipo";

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
					objDespesaTipo forma = new objDespesaTipo((byte)row["IDDespesaTipo"])
					{
						DespesaTipo = (string)row["DespesaTipo"],
						Periodicidade = (byte)row["Periodicidade"],
						DespesaFixa = (bool)row["DespesaFixa"],
						IDDespesaTipoGrupo = (byte)row["IDDespesaTipoGrupo"],
						Ativo = (bool)row["DespesaFixa"],
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
				int newID = db.ExecutarInsertAndGetID(query);

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

				string query = "SELECT * FROM tblDespesaGrupo";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY DespesaGrupo";

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
						IDDespesaTipoGrupo = (int)row["IDDespesaGrupo"],
						DespesaTipoGrupo = (string)row["DespesaGrupo"],
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

				string query = db.CreateInsertSQL("tblDespesaGrupo");

				//--- insert and Get new ID
				int newID = db.ExecutarInsertAndGetID(query);

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
				string query = db.CreateUpdateSQL("tblDespesaGrupo", "@IDDespesaGrupo");

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
		// DESPESA DOCUMENTO TIPO
		//=================================================================================================

		// GET DESPESA DOCUMENTO TIPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaDocumentoTipo> GetDespesaDocumentoTipos(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblDespesaDocumentoTipo";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY DespesaDocumentoTipo";

				List<objDespesaDocumentoTipo> listagem = new List<objDespesaDocumentoTipo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objDespesaDocumentoTipo forma = new objDespesaDocumentoTipo()
					{
						IDDocumentoTipo = (int)row["IDDocumentoTipo"],
						DocumentoTipo = (string)row["DocumentoTipo"],
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
	}
}