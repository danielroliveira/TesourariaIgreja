using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class DespesaCartaoBLL
	{
		// GET DESPESA CARTAO BY ID
		//------------------------------------------------------------------------------------------------------------
		public objDespesaCartao GetDespesaCartaoByID(long IDDespesa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaCartao WHERE IDDespesa = @IDDespesa";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", IDDespesa);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new Exception("Registro de Despesa não encontrado...");
				}

				return ConvertRowInClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST OF WITH DETAILS
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaCartao> GetListDespesaCartao(
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
			var despesa = new objDespesaCartao((long)row["IDDespesa"])
			{
				DespesaDescricao = (string)row["DespesaDescricao"],
				IDCredor = (int)row["IDCredor"],
				Credor = (string)row["Credor"],
				DespesaData = (DateTime)row["DespesaData"],
				IDDespesaTipo = (int)row["IDDespesaTipo"],
				DespesaTipo = (string)row["DespesaTipo"],
				DespesaValor = (decimal)row["DespesaValor"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				IDCartaoCredito = (int)row["IDCartaoCredito"],
				CartaoDescricao = (string)row["CartaoDescricao"],
				VencimentoDia = (byte)row["VencimentoDia"],
				ReferenciaData = (DateTime)row["ReferenciaData"],
			};

			// SET IMAGEM
			despesa.Imagem.IDOrigem = (long)despesa.IDDespesa;
			despesa.Imagem.Origem = EnumImagemOrigem.Despesa;
			despesa.Imagem.ImagemFileName = row["ImagemFileName"] == DBNull.Value ? string.Empty : (string)row["ImagemFileName"];
			despesa.Imagem.ImagemPath = row["ImagemPath"] == DBNull.Value ? string.Empty : (string)row["ImagemPath"];

			// RETURN
			return despesa;
		}

		// INSERT DESPESA AND DESPESA CARTAO
		//------------------------------------------------------------------------------------------------------------
		public objDespesaCartao InsertDespesaCartao(objAPagarCartao cartao, DateTime ReferenciaData, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				db = new AcessoDados();
				if (dbTran == null) db.BeginTransaction();

				var descricao = $"Despesa Destino Cartão: {cartao.CartaoDescricao}";
				if (descricao.Length > 200) descricao = descricao.Substring(0, 199);

				var despesa = new objDespesaCartao(null)
				{
					IDCredor = cartao.IDCredorCartao,
					Credor = cartao.CredorCartao,
					DespesaDescricao = descricao,
					DespesaOrigem = 3, // CARTAO
					DespesaValor = 0,
					DespesaData = ReferenciaData,
					IDSetor = cartao.IDSetorCartao,
					Setor = cartao.SetorCartao,
					IDDespesaTipo = 0,
					IDTitular = null,
					DespesaTipo = "Outras",
					CartaoDescricao = cartao.CartaoDescricao,
					IDCartaoCredito = (int)cartao.IDCartaoCredito,
					VencimentoDia = cartao.VencimentoDia,
					IDSituacao = 1,
					Situacao = "Em Aberto",
					Imagem = null,
					ReferenciaData = ReferenciaData,

				};

				//--- insert DESPESA and Get new ID
				long newID = new DespesaBLL().InsertDespesa(despesa, db);

				despesa.IDDespesa = newID;

				//--- insert DESPESA CARTAO
				InsertDespesaCartao(despesa, db);

				if (dbTran == null) db.CommitTransaction();
				return despesa;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT DESPESA CARTAO
		//------------------------------------------------------------------------------------------------------------
		private void InsertDespesaCartao(objDespesaCartao desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@IDCartaoCredito", desp.IDCartaoCredito);
				dbTran.AdicionarParametros("@ReferenciaData", desp.ReferenciaData);
				dbTran.AdicionarParametros("@IDSituacao", desp.IDSituacao);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesaCartao");

				//--- insert
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LAST DESPESA CARTAO BY IDCARTAO
		//------------------------------------------------------------------------------------------------------------
		public objDespesaCartao GetLastDespesaCartaoByCartao(int IDCartaoCredito)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT TOP 1 * FROM qryDespesaCartao " +
					"WHERE IDCartaoCredito = @IDCartaoCredito " +
					"ORDER BY DespesaData DESC";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDCartaoCredito", IDCartaoCredito);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return null;
				}

				return ConvertRowInClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST APAGAR OF CARTAO CREDITO
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> ListAPagarCartaoEmAberto(int IDCartaoCredito)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryAPagar WHERE IDCartaoCredito = @IDCartaoCredito AND IDSituacao = 1";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDCartaoCredito", IDCartaoCredito);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return null;
				}

				var pBLL = new APagarBLL();
				var list = new List<objAPagar>();

				foreach (DataRow row in dt.Rows)
				{
					list.Add(pBLL.ConvertRowInClass(row));
				}

				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
