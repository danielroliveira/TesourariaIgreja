using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
			int? IDCartaoCredito = null,
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
				if (IDCartaoCredito != null)
				{
					db.AdicionarParametros("@IDCartaoCredito", IDCartaoCredito);
					query += " WHERE IDCartaoCredito = @IDCartaoCredito";
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

				var descricao = $"Fatura de Cartão {cartao.CartaoDescricao}";
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

		// GET LIST APAGAR OF CARTAO CREDITO
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> ListAPagarCartaoVinculadas(long IDDespesaCartao, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryDespesaCartaoAPagar WHERE IDDespesaCartao = @IDDespesaCartao";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesaCartao", IDDespesaCartao);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				var list = new List<objAPagar>();

				if (dt.Rows.Count == 0)
				{
					return list;
				}

				var pBLL = new APagarBLL();

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

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteDespesaCartao(objDespesaCartao despesa)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// 1 - CHECK APagar and Movimentacao Saida
				//------------------------------------------------------------------------------------------------------------
				List<objAPagar> listAPagar = new List<objAPagar>();
				List<objMovimentacao> listMovSaidas = new List<objMovimentacao>();

				if (!VerifyBeforeDelete(despesa, ref listAPagar, ref listMovSaidas, dbTran)) return false;

				// 2 - Return with all APAGAR vinculadas --> convert all to EM ABERTO
				//------------------------------------------------------------------------------------------------------------
				var ListVinculadas = ListAPagarCartaoVinculadas((long)despesa.IDDespesa, dbTran);

				foreach (var pag in ListVinculadas)
				{
					RemoverVinculoAPagarItem((long)pag.IDAPagar, dbTran);
				}

				// 3 - delete ALL APAGAR 
				//------------------------------------------------------------------------------------------------------------
				if (listAPagar.Count > 0)
				{
					APagarBLL pBLL = new APagarBLL();

					foreach (objAPagar pagar in listAPagar)
					{
						pBLL.DeleteAPagar(pagar, dbTran);
					}
				}

				// 4 - delete DESPESA CARTAO
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", despesa.IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				string query = "DELETE tblDespesaCartao WHERE IDDespesa = @IDDespesa";

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

				// 6 - COMMIT AND RETURN
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

		// VERIFY DESPESA BEFORE DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool VerifyBeforeDelete(objDespesaCartao despesa,
			ref List<objAPagar> listAPagar,
			ref List<objMovimentacao> listMovSaidas,
			AcessoDados dbTran)
		{
			try
			{
				long IDDespesa = (long)despesa.IDDespesa;

				// VERIFY IMAGEM
				//------------------------------------------------------------------------------------------------------------
				if (despesa.Imagem != null && !string.IsNullOrEmpty(despesa.Imagem.ImagemFileName))
				{
					throw new AppException("A despesa não pode ser excluída pois possui uma imagem vinculada a ela...");
				}

				// GET APAGAR
				//------------------------------------------------------------------------------------------------------------
				listAPagar = new APagarBLL().GetListAPagarByDespesa(IDDespesa, dbTran);

				// VERIFY APAGAR
				//------------------------------------------------------------------------------------------------------------
				bool err = false;
				string errMessage = "Os a PAGAR abaixo possuem pagamentos...\n";

				Action<objAPagar> addMessage = (pagar) =>
				{
					errMessage += $"Reg.: {pagar.IDAPagar:D4}    {pagar.Vencimento.ToShortDateString()}\n";
					err = true;
				};

				listAPagar.Where(x => x.IDSituacao == 2).ToList().ForEach(addMessage);

				if (err == true)
				{
					errMessage += "Favor estornar antes os pagamentos se deseja EXCLUIR a despesa.";
					throw new AppException(errMessage);
				}

				// VERIFY APAGAR IMAGES
				//------------------------------------------------------------------------------------------------------------
				errMessage = "Os APagar abaixo possuem IMAGEM associada\n";

				listAPagar.Where(x => x.Imagem != null && !string.IsNullOrEmpty(x.Imagem.ImagemFileName)).ToList().ForEach(addMessage);

				if (err == true)
				{
					errMessage += "Favor remover/desassociar as imagens do APagar se deseja EXCLUIR a despesa.";
					throw new AppException(errMessage);
				}

				// VERIFY MOVIMENTACAO SAIDA FROM APAGAR
				//------------------------------------------------------------------------------------------------------------
				MovimentacaoBLL mBLL = new MovimentacaoBLL();
				listMovSaidas = new List<objMovimentacao>();

				if (listAPagar.Count > 0)
				{
					foreach (objAPagar pagar in listAPagar)
					{
						listMovSaidas.AddRange(mBLL.GetMovimentacaoListByOrigem(EnumMovOrigem.APagar, (long)pagar.IDAPagar, true, dbTran));
					}
				}

				// VERIFY RECEBIMENTOS WITH CAIXA OR BLOCKED
				//------------------------------------------------------------------------------------------------------------
				errMessage = "Essa Despesa possui pagamentos que foram inseridas no caixa...\n";

				Action<objMovimentacao> addMessageMov = (saida) =>
				{
					errMessage += $"Reg.: {saida.IDMovimentacao:D4} | {saida.MovData.ToShortDateString()} | Caixa: {saida.IDCaixa:D4}\n";
					err = true;
				};

				listMovSaidas.Where(x => x.IDCaixa != null).ToList().ForEach(addMessageMov);

				if (err == true)
				{
					errMessage += "Favor remover o(s) caixa(s) se desejar EXCLUIR a(s) DESPESA.";
					throw new AppException(errMessage);
				}

				// VERIFY MOVIMENTACAO SAIDA IMAGES
				//------------------------------------------------------------------------------------------------------------
				errMessage = "As Saídas abaixo possuem IMEGEM associada\n";

				listMovSaidas.Where(x => x.Imagem != null && !string.IsNullOrEmpty(x.Imagem.ImagemFileName)).ToList().ForEach(addMessageMov);

				if (err == true)
				{
					errMessage += "Favor remover/desassociar as imagens das Saídas se deseja EXCLUIR a despesa.";
					throw new AppException(errMessage);
				}

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// ANEXAR A PAGAR LIST COM DESPESA CARTAO
		//------------------------------------------------------------------------------------------------------------
		public void VincularAPagarList(List<objAPagar> list, long IDDespesa, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				foreach (var item in list)
				{
					VincularAPagarItem((long)item.IDAPagar, IDDespesa, db);
				}

				if (dbTran == null) db.CommitTransaction();
			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// VINCULAR A PAGAR ITEM COM DESPESA CARTAO
		//------------------------------------------------------------------------------------------------------------
		public void VincularAPagarItem(long IDAPagar, long IDDespesa, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- create insert
				string query = "INSERT INTO tblAPagarCartao " +
					"(IDAPagarSubtituido, IDDespesaCartao) " +
					"VALUES (@IDAPagarSubtituido, @IDDespesaCartao)";

				db.LimparParametros();
				db.AdicionarParametros("@IDAPagarSubtituido", IDAPagar);
				db.AdicionarParametros("@IDDespesaCartao", IDDespesa);

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- update APAGAR to SUBSTITUIDA situacao
				query = "UPDATE tblAPagar SET IDSituacao = 6 WHERE IDAPagar = @IDAPagar";

				db.LimparParametros();
				db.AdicionarParametros("@IDAPagar", IDAPagar);

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- commit
				if (dbTran == null) db.CommitTransaction();
			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// DESVINCULAR A PAGAR ITEM COM DESPESA CARTAO
		//------------------------------------------------------------------------------------------------------------
		public void RemoverVinculoAPagarItem(long IDAPagar, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- create DELETE
				string query = "DELETE tblAPagarCartao WHERE IDAPagarSubtituido = @IDAPagarSubtituido";

				db.LimparParametros();
				db.AdicionarParametros("@IDAPagarSubtituido", IDAPagar);

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- update APAGAR to EM ABERTO situacao
				query = "UPDATE tblAPagar SET IDSituacao = 1 WHERE IDAPagar = @IDAPagar";

				db.LimparParametros();
				db.AdicionarParametros("@IDAPagar", IDAPagar);

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- commit
				if (dbTran == null) db.CommitTransaction();
			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// CONCLUIR DESPESA CARTAO
		//------------------------------------------------------------------------------------------------------------
		public void ConcluirDespesaCartao(objDespesaCartao despesa)
		{
			AcessoDados db = null;

			try
			{
				//--- INIT DATABASE
				db = new AcessoDados();
				db.BeginTransaction();

				//--- 1. BLOCK ALL DESPESA CARTAO WITH SAME IDCARTAO
				string query = "UPDATE tblDespesaCartao " +
					"SET IDSituacao = 3 " +
					"WHERE IDCartaoCredito = @IDCartaoCredito AND IDSituacao = 2";

				db.LimparParametros();
				db.AdicionarParametros("@IDCartaoCredito", despesa.IDCartaoCredito);

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- 2. UPDATE TBL DESPESA
				new DespesaBLL().UpdateDespesa(despesa, db);

				//--- 3. FINALIZE THIS DESPESA CARTAO
				query = "UPDATE tblDespesaCartao " +
					"SET IDSituacao = 2 " +
					"WHERE IDDespesa = @IDDespesa";

				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", despesa.IDDespesa);

				db.ExecutarManipulacao(CommandType.Text, query);

				//--- 4. GET CARTAO OBJECT
				var cartao = new APagarCartaoBLL().GetCartaoCreditoDespesa(despesa.IDCartaoCredito, db);

				//--- 5. GENERATE NEW APAGAR WITH SUM OF VALUES
				var newPag = new objAPagar(null)
				{
					IDSetor = despesa.IDSetor,
					IDSituacao = 1,
					APagarValor = despesa.DespesaValor,
					IDAPagarForma = cartao.IDAPagarForma,
					IDCredor = despesa.IDCredor,
					IDDespesa = (long)despesa.IDDespesa,
					Identificador = $"{despesa.ReferenciaData.Month:D2}-{despesa.ReferenciaData.Year}",
					Parcela = 1,
					Vencimento = despesa.ReferenciaData,
					ReferenciaMes = despesa.ReferenciaData.Month,
					ReferenciaAno = despesa.ReferenciaData.Year,
				};

				new APagarBLL().InsertAPagarList(new List<objAPagar>() { newPag }, db);

				//--- COMMIT TRANSACTION
				db.CommitTransaction();

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
