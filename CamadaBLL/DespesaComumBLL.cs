using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CamadaBLL
{
	public class DespesaComumBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaComum> GetListDespesa()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaComum";

				// add params
				db.LimparParametros();

				query += " ORDER BY IDDespesa";

				List<objDespesaComum> listagem = new List<objDespesaComum>();
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
		public List<objDespesaComum> GetListDespesa(
			int? IDSetor = null,
			int? IDDespesaTipo = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryDespesaComum";
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

				List<objDespesaComum> listagem = new List<objDespesaComum>();
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
		public objDespesaComum GetDespesa(long IDDespesa, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryDespesaComum WHERE IDDespesa = @IDDespesa";
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", IDDespesa);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new AppException("Não existe registro de Despesa com esse número de Registro...");
				}

				return ConvertRowInClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objDespesaComum ConvertRowInClass(DataRow row)
		{
			objDespesaComum despesa = new objDespesaComum((long)row["IDDespesa"])
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
				Prioridade = (byte)row["Prioridade"],
				IDTitular = row["IDTitular"] == DBNull.Value ? null : (int?)row["IDTitular"],
				Titular = row["Titular"] == DBNull.Value ? null : (string)row["Titular"],
				CNP = row["CNP"] == DBNull.Value ? null : (string)row["CNP"],
				DataFinal = row["DataFinal"] == DBNull.Value ? null : (DateTime?)row["DataFinal"],
				DataInicial = row["DataInicial"] == DBNull.Value ? null : (DateTime?)row["DataInicial"],
			};

			// SET IMAGEM
			despesa.Imagem.IDOrigem = (long)despesa.IDDespesa;
			despesa.Imagem.Origem = EnumImagemOrigem.Despesa;
			despesa.Imagem.ImagemFileName = row["ImagemFileName"] == DBNull.Value ? string.Empty : (string)row["ImagemFileName"];
			despesa.Imagem.ImagemPath = row["ImagemPath"] == DBNull.Value ? string.Empty : (string)row["ImagemPath"];

			// RETURN
			return despesa;
		}

		// INSERT DESPESA COMUM
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesaComum(objDespesaComum desp, ref List<objAPagar> listAPagar, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				//--- Init Transaction
				if (dbTran == null) db.BeginTransaction();

				//--- insert Despesa
				var newID = new DespesaBLL().InsertDespesa(desp, db);

				//--- insert Despesa Comum
				desp.IDDespesa = newID;
				InsertDespesaComum(desp, db);

				//--- insert DespesaDataPeriodo if necessary
				InsertDespesaDataPeriodo(desp, db);

				//--- insert IDDespesa in APagar List items
				listAPagar.ForEach(x => x.IDDespesa = newID);

				//--- save APagar items
				new APagarBLL().InsertAPagarList(listAPagar, db);

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// INSERT DESPESA COMUM
		//------------------------------------------------------------------------------------------------------------
		private void InsertDespesaComum(objDespesaComum desp, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@DocumentoNumero", desp.DocumentoNumero);
				dbTran.AdicionarParametros("@IDDocumentoTipo", desp.IDDocumentoTipo);
				dbTran.AdicionarParametros("@IDSituacao", desp.IDSituacao);
				dbTran.AdicionarParametros("@Parcelas", desp.Parcelas);
				dbTran.AdicionarParametros("@Prioridade", desp.Prioridade);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesaComum");

				//--- insert
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT DESPESA DATA PERIODO
		//------------------------------------------------------------------------------------------------------------
		private void InsertDespesaDataPeriodo(objDespesaComum desp, AcessoDados dbTran)
		{
			try
			{
				//--- check DataInicial and DataFinal
				if (desp.DataInicial == null || desp.DataFinal == null)
				{
					return;
				}

				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDDespesa", desp.IDDespesa);
				dbTran.AdicionarParametros("@DataInicial", desp.DataInicial);
				dbTran.AdicionarParametros("@DataFinal", desp.DataFinal);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblDespesaDataPeriodo");

				//--- insert
				dbTran.ExecutarManipulacao(CommandType.Text, query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		// INSERT DESPESA REALIZADA | GASTO | DESPESA QUITADA
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesaRealizada(
			objDespesaComum despesa,
			objAPagar pagar,
			objMovimentacao saida,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate,
			object dbTran = null)
		{
			bool IsTran = dbTran != null;

			try
			{
				// create transaction
				if (!IsTran) dbTran = new AcessoDados();
				if (!IsTran) ((AcessoDados)dbTran).BeginTransaction();

				// Verifica CONTA SALDO
				ContaBLL cBLL = new ContaBLL();

				decimal saldoAtual = cBLL.ContaSaldoGet((int)saida.IDConta, dbTran);

				if (saida.MovValor > saldoAtual)
				{
					throw new AppException("Não existe SALDO SUFICIENTE na conta para realizar esse débito...", 1);
				}

				// Verifica CONTA BLOQUEIO
				if (!cBLL.ContaDateBlockPermit((int)saida.IDConta, saida.MovData, dbTran))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data de Débito proposto...", 2);
				}

				// create APagar list
				List<objAPagar> listPag = new List<objAPagar>();
				listPag.Add(pagar);

				// insert Despesa AND APagar
				despesa.IDSituacao = 2; // quitada
				long newID = InsertDespesaComum(despesa, ref listPag, dbTran);

				// insert Saida
				saida.MovTipo = 2;
				saida.Origem = EnumMovOrigem.APagar;
				saida.IDOrigem = (long)listPag[0].IDAPagar;
				saida.DescricaoOrigem = $"DESPESA: {despesa.DespesaDescricao}";
				if (saida.DescricaoOrigem.Length > 250) saida.DescricaoOrigem = saida.DescricaoOrigem.Substring(0, 250);

				new MovimentacaoBLL().InsertMovimentacao(saida, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);

				// commit and return
				if (!IsTran) ((AcessoDados)dbTran).CommitTransaction();
				return newID;
			}
			catch (Exception ex)
			{
				if (!IsTran) ((AcessoDados)dbTran).RollBackTransaction();
				throw ex;
			}

		}

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteDespesaComum(objDespesaComum despesa)
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
				string query = "DELETE tblDespesaComum WHERE IDDespesa = @IDDespesa";

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

				// 6 - UPDATE REMOVE DESPESA COMISSAO reference
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", despesa.IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				query = "UPDATE tblComissoes SET IDDespesa = null WHERE IDDespesa = @IDDespesa";

				//--- UPDATE
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

		// VERIFY DESPESA BEFORE DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool VerifyBeforeDelete(objDespesaComum despesa,
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

		// VERIFY DESPESA SITUACAO BY LIST OF APAGAR
		//------------------------------------------------------------------------------------------------------------
		public bool CheckSituacaoDespesa(objDespesaComum despesa)
		{
			// return TRUE when IDSitucao is Changed | FALSE when nothing changed
			try
			{
				var dbTran = new AcessoDados();

				var lstAPagar = new APagarBLL().GetListAPagarByDespesa((long)despesa.IDDespesa, dbTran);

				if (lstAPagar.Count == 0)
				{
					throw new Exception("Não foram encontrados registros de APagar referentes a essa Despesa...");
				}

				byte? newSituacao = null;

				foreach (objAPagar item in lstAPagar)
				{
					switch (item.IDSituacao)
					{
						case 1: // EM ABERTO
							if (newSituacao == null || newSituacao == 2) newSituacao = 1;
							break;
						case 2: // QUITADA
							if (newSituacao == null) newSituacao = 2;
							break;
						case 3: // CANCELADA
							if (newSituacao == null || newSituacao < 3) newSituacao = 3;
							break;
						case 4: // NEGOCIADA
							if (newSituacao == null || newSituacao < 4) newSituacao = 4;
							break;
						case 5: // NEGATIVADA
							if (newSituacao == null || newSituacao < 5) newSituacao = 5;
							break;
						default:
							break;
					}
				}

				if ((byte)newSituacao != despesa.IDSituacao)
				{
					despesa.IDSituacao = (byte)newSituacao;

					// change situacao 
					ChangeSituacaoDespesa((long)despesa.IDDespesa, (byte)newSituacao, dbTran);

					// return
					return true;
				}
				else
				{
					// return nothing changed
					return false;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CHANGE DESPESA SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public bool ChangeSituacaoDespesa(long IDDespesa, byte newIDSituacao, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "UPDATE tblDespesaComum SET IDSituacao = @IDSituacao WHERE IDDespesa = @IDDespesa";

				db.LimparParametros();
				db.AdicionarParametros("@IDSituacao", newIDSituacao);
				db.AdicionarParametros("@IDDespesa", IDDespesa);

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
		public List<objDespesaDocumentoTipo> GetDespesaDocumentoTipos(bool? Ativo = null, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM tblDespesaDocumentoTipo";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY DocumentoTipo";

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
						IDDocumentoTipo = (byte)row["IDDocumentoTipo"],
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
