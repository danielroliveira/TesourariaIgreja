using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class EntradaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objEntrada> GetListEntrada(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryEntrada";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDEntrada";

				List<objEntrada> listagem = new List<objEntrada>();
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

		// GET ENTRADA
		//------------------------------------------------------------------------------------------------------------
		public objEntrada GetEntrada(int IDEntrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryEntrada WHERE IDEntrada = @IDEntrada";
				db.LimparParametros();
				db.AdicionarParametros("@IDEntrada", IDEntrada);

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
		public objEntrada ConvertRowInClass(DataRow row)
		{
			objEntrada entrada = new objEntrada((int)row["IDEntrada"])
			{
				EntradaData = (DateTime)row["EntradaData"],
				CompensacaoData = (DateTime)row["CompensacaoData"],
				IDEntradaForma = (byte)row["IDEntradaForma"],
				EntradaForma = (string)row["EntradaForma"],
				ValorBruto = (decimal)row["ValorBruto"],
				ValorLiquido = (decimal)row["ValorLiquido"],
				IDEntradaTipo = (byte)row["IDEntradaTipo"],
				EntradaTipo = (string)row["EntradaTipo"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				IDContribuinte = row["IDContribuinte"] == DBNull.Value ? null : (int?)row["IDContribuinte"],
				Contribuinte = row["Contribuinte"] == DBNull.Value ? null : (string)row["Contribuinte"],
				OrigemDescricao = row["OrigemDescricao"] == DBNull.Value ? null : (string)row["OrigemDescricao"],
				IDReuniao = row["IDReuniao"] == DBNull.Value ? null : (int?)row["IDReuniao"],
				Reuniao = row["Reuniao"] == DBNull.Value ? null : (string)row["Reuniao"],
				IDCampanha = row["IDCampanha"] == DBNull.Value ? null : (int?)row["IDCampanha"],
				Campanha = row["Campanha"] == DBNull.Value ? null : (string)row["Campanha"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertEntrada(objEntrada entrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@EntradaData", entrada.EntradaData);
				db.AdicionarParametros("@CompensacaoData", entrada.CompensacaoData);
				db.AdicionarParametros("@IDEntradaForma", entrada.IDEntradaForma);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@ValorLiquido", entrada.ValorLiquido);
				db.AdicionarParametros("@IDEntradaTipo", entrada.IDEntradaTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDContribuinte", entrada.IDContribuinte);
				db.AdicionarParametros("@OrigemDescricao", entrada.OrigemDescricao);
				db.AdicionarParametros("@IDReuniao", entrada.IDReuniao);
				db.AdicionarParametros("@IDCampanha", entrada.IDCampanha);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblEntradas");

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
		public bool UpdateEntrada(objEntrada entrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDEntrada", entrada.IDEntrada);
				db.AdicionarParametros("@EntradaData", entrada.EntradaData);
				db.AdicionarParametros("@CompensacaoData", entrada.CompensacaoData);
				db.AdicionarParametros("@IDEntradaForma", entrada.IDEntradaForma);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@ValorLiquido", entrada.ValorLiquido);
				db.AdicionarParametros("@IDEntradaTipo", entrada.IDEntradaTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDContribuinte", entrada.IDContribuinte);
				db.AdicionarParametros("@OrigemDescricao", entrada.OrigemDescricao);
				db.AdicionarParametros("@IDReuniao", entrada.IDReuniao);
				db.AdicionarParametros("@IDCampanha", entrada.IDCampanha);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblEntradas", "@IDEntrada");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=============================================================================
		//=============================================================================

		// GET ENTRADA FORMAS
		//------------------------------------------------------------------------------------------------------------
		public List<objEntradaForma> GetEntradaFormasList(bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblEntradaForma";

				// add params
				db.LimparParametros();

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					query += " WHERE Ativa = @Ativa";
				}

				query += " ORDER BY EntradaForma";

				List<objEntradaForma> listagem = new List<objEntradaForma>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objEntradaForma forma = new objEntradaForma((byte)row["IDEntradaForma"])
					{
						EntradaForma = (string)row["EntradaForma"],
						CompensacaoDias = (byte)row["CompensacaoDias"],
						TaxaComissao = (decimal)row["TaxaComissao"],
						Ativa = (bool)row["Ativa"]
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

		// GET ENTRADA TIPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objEntradaTipo> GetEntradaTiposList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblEntradaTipo";

				// add params
				db.LimparParametros();

				query += " ORDER BY EntradaTipo";

				List<objEntradaTipo> listagem = new List<objEntradaTipo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objEntradaTipo forma = new objEntradaTipo((byte)row["IDEntradaTipo"])
					{
						EntradaTipo = (string)row["EntradaTipo"],
						ComAtividade = (bool)row["ComAtividade"],
						ComCampanha = (bool)row["ComCampanha"],
						ComOrigem = (bool)row["ComOrigem"]
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
