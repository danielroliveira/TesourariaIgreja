using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class DespesaCartaoBLL
	{
		// GET LIST OF WITH DETAILS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaCartao> GetListDespesaCartao(
			int? IDSetor = null,
			int? IDDespesaTipo = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaCartao";
				bool myWhere = false;

				// add params
				db.LimparParametros();

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

				// add IDCredor
				if (IDCredor != null)
				{
					db.AdicionarParametros("@IDCredor", IDCredor);
					query += myWhere ? " AND IDCredor = @IDCredor" : " WHERE IDCredor = @IDCredor";
					myWhere = true;
				}

				query += " ORDER BY DespesaData";

				List<objDespesaCartao> listagem = new List<objDespesaCartao>();
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

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objDespesaCartao ConvertRowInClass(DataRow row)
		{
			var despesa = new objDespesaCartao((long)row["IDDespesaCartao"])
			{
				DespesaDescricao = (string)row["DespesaDescricao"],
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
				ParcelaDataFinal = row["ParcelaDataFinal"] == DBNull.Value ? null : (DateTime?)row["ParcelaDataFinal"],
				ParcelaDataInicial = row["ParcelaDataInicial"] == DBNull.Value ? null : (DateTime?)row["ParcelaDataInicial"],
				IDCartaoCredito = (int)row["IDCartaoCredito"],
				CartaoDescricao = (string)row["CartaoDescricao"],
				IDDespesaDestino = (long)row["IDDespesaDestino"],
				VencimentoDia = (byte)row["VencimentoDia"],

			};

			// SET IMAGEM
			despesa.Imagem.IDOrigem = (long)despesa.IDDespesaCartao;
			despesa.Imagem.Origem = EnumImagemOrigem.Despesa;
			despesa.Imagem.ImagemFileName = row["ImagemFileName"] == DBNull.Value ? string.Empty : (string)row["ImagemFileName"];
			despesa.Imagem.ImagemPath = row["ImagemPath"] == DBNull.Value ? string.Empty : (string)row["ImagemPath"];

			// RETURN
			return despesa;
		}

		// INSERT DESPESA DESTINO CARTAO
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesaCartaoDestino(objAPagarCartao cartao, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				db = new AcessoDados();
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@DespesaDescricao", ("Despesa Destino Cartão: " + cartao.CartaoDescricao).Substring(0, 199));
				db.AdicionarParametros("@DespesaOrigem", 3);
				db.AdicionarParametros("@DespesaValor", 0);
				db.AdicionarParametros("@DespesaData", DateTime.Today);
				db.AdicionarParametros("@IDCredor", cartao.IDCredorCartao);
				db.AdicionarParametros("@IDSetor", cartao.IDSetorCartao);
				db.AdicionarParametros("@IDDespesaTipo", 0);
				db.AdicionarParametros("@IDTitular", null);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesa");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
