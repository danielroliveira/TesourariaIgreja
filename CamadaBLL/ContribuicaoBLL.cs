using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class ContribuicaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicao> GetListContribuicao(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDContribuicao";

				List<objContribuicao> listagem = new List<objContribuicao>();
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

		// GET CONTRIBUICAO
		//------------------------------------------------------------------------------------------------------------
		public objContribuicao GetContribuicao(int IDContribuicao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao WHERE IDContribuicao = @IDContribuicao";
				db.LimparParametros();
				db.AdicionarParametros("@IDContribuicao", IDContribuicao);

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
		public objContribuicao ConvertRowInClass(DataRow row)
		{
			objContribuicao entrada = new objContribuicao((int)row["IDContribuicao"])
			{
				ContribuicaoData = (DateTime)row["ContribuicaoData"],
				IDEntradaForma = (byte)row["IDEntradaForma"],
				EntradaForma = (string)row["EntradaForma"],
				ValorBruto = (decimal)row["ValorBruto"],
				IDContribuicaoTipo = (byte)row["IDContribuicaoTipo"],
				ContribuicaoTipo = (string)row["ContribuicaoTipo"],
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
		public int InsertContribuicao(objContribuicao entrada)
		{
			AcessoDados db = new AcessoDados();

			try
			{
				db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@ContribuicaoData", entrada.ContribuicaoData);
				db.AdicionarParametros("@IDEntradaForma", entrada.IDEntradaForma);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@IDContribuicaoTipo", entrada.IDContribuicaoTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDContribuinte", entrada.IDContribuinte);
				db.AdicionarParametros("@OrigemDescricao", entrada.OrigemDescricao);
				db.AdicionarParametros("@IDReuniao", entrada.IDReuniao);
				db.AdicionarParametros("@IDCampanha", entrada.IDCampanha);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblContribuicaos");

				//--- insert and Get new ID
				int newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA
				//  new ContaBLL().ContaSaldoChange(entrada.IDConta, entrada.ValorLiquido, db);

				//--- altera o saldo do SETOR


				db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateContribuicao(objContribuicao entrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDContribuicao", entrada.IDContribuicao);
				db.AdicionarParametros("@ContribuicaoData", entrada.ContribuicaoData);
				db.AdicionarParametros("@IDEntradaForma", entrada.IDEntradaForma);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@IDContribuicaoTipo", entrada.IDContribuicaoTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDContribuinte", entrada.IDContribuinte);
				db.AdicionarParametros("@OrigemDescricao", entrada.OrigemDescricao);
				db.AdicionarParametros("@IDReuniao", entrada.IDReuniao);
				db.AdicionarParametros("@IDCampanha", entrada.IDCampanha);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblContribuicaos", "@IDContribuicao");

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

		// GET CONTRIBUICAO TIPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicaoTipo> GetContribuicaoTiposList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblContribuicaoTipo";

				// add params
				db.LimparParametros();

				query += " ORDER BY ContribuicaoTipo";

				List<objContribuicaoTipo> listagem = new List<objContribuicaoTipo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objContribuicaoTipo forma = new objContribuicaoTipo((byte)row["IDContribuicaoTipo"])
					{
						ContribuicaoTipo = (string)row["ContribuicaoTipo"],
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
