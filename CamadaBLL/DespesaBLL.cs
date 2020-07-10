using CamadaDAL;
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

				string query = "SELECT * FROM qryDespesaComum";

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
		public objDespesa GetDespesa(long IDDespesa, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryDespesaComum WHERE IDDespesa = @IDDespesa";
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
			};

			return despesa;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesa(objDespesa desp, ref List<objAPagar> listAPagar, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				db = new AcessoDados();
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@DespesaDescricao", desp.DespesaDescricao);
				db.AdicionarParametros("@DespesaOrigem", desp.DespesaOrigem);
				db.AdicionarParametros("@DespesaValor", desp.DespesaValor);
				db.AdicionarParametros("@DespesaData", desp.DespesaData);
				db.AdicionarParametros("@IDCredor", desp.IDCredor);
				db.AdicionarParametros("@IDSetor", desp.IDSetor);
				db.AdicionarParametros("@IDDespesaTipo", desp.IDDespesaTipo);
				db.AdicionarParametros("@IDTitular", desp.IDTitular);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesa");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- insert Despesa Comum
				desp.IDDespesa = newID;
				InsertDespesaComum(desp, db);

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
		private void InsertDespesaComum(objDespesa desp, AcessoDados dbTran)
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

		// INSERT DESPESA REALIZADA | GASTO | DESPESA QUITADA
		//------------------------------------------------------------------------------------------------------------
		public long InsertDespesaRealizada(
			objDespesa despesa,
			objAPagar pagar,
			objMovimentacao saida,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate)
		{
			AcessoDados dbTran = null;

			try
			{
				// create transaction
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

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

				// create APaga list
				List<objAPagar> listPag = new List<objAPagar>();
				listPag.Add(pagar);

				// insert Despesa AND APagar
				long newID = InsertDespesa(despesa, ref listPag, dbTran);

				// insert Saida
				saida.MovTipo = 2;
				saida.Origem = EnumMovOrigem.APagar;
				saida.IDOrigem = (long)listPag[0].IDAPagar;
				saida.DescricaoOrigem = $"DESPESA: {despesa.DespesaDescricao}";
				new MovimentacaoBLL().InsertMovimentacao(saida, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);

				// commit and return
				dbTran.CommitTransaction();
				return newID;
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}

		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateDespesa(objDespesa desp)
		{
			try
			{

				throw new NotImplementedException("Ainda não foi implementada essa função");

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteDespesaComum(long IDDespesa)
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

				if (!VerifyBeforeDelete(IDDespesa, ref listAPagar, ref listMovSaidas, dbTran)) return false;

				// 2 - delete ALL APAGAR 
				//------------------------------------------------------------------------------------------------------------
				if (listAPagar.Count > 0)
				{
					APagarBLL pBLL = new APagarBLL();

					foreach (objAPagar pagar in listAPagar)
					{
						pBLL.DeleteAPagar((long)pagar.IDAPagar, dbTran);
					}
				}

				// 3 - delete DESPESA COMUM
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				string query = "DELETE tblDespesaComum WHERE IDDespesa = @IDDespesa";

				//--- DELETE
				dbTran.ExecutarManipulacao(CommandType.Text, query);

				// 4 - delete DESPESA
				//------------------------------------------------------------------------------------------------------------

				//--- define Params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDDespesa", IDDespesa);
				dbTran.ConvertNullParams();

				//--- create query
				query = "DELETE tblDespesa WHERE IDDespesa = @IDDespesa";

				//--- DELETE
				dbTran.ExecutarManipulacao(CommandType.Text, query);

				// 5 - COMMIT AND RETURN
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
		private bool VerifyBeforeDelete(long IDDespesa,
			ref List<objAPagar> listAPagar,
			ref List<objMovimentacao> listMovSaidas,
			AcessoDados dbTran)
		{
			try
			{
				// GET APAGAR
				//------------------------------------------------------------------------------------------------------------
				listAPagar = new APagarBLL().GetListAPagarByDespesa(IDDespesa, dbTran);

				// VERIFY APAGAR
				//------------------------------------------------------------------------------------------------------------
				bool err = false;
				string errMessage = "Os a PAGAR abaixo possuem pagamentos...\n";

				foreach (objAPagar pagar in listAPagar)
				{
					if (pagar.IDSituacao == 2)
					{
						errMessage += $"Reg.: {pagar.IDAPagar:D4}    {pagar.Vencimento.ToShortDateString()}\n";
						err = true;
					}
				}

				if (err == true)
				{
					errMessage += "Favor estornar antes os pagamentos se deseja EXCLUIR a despesa.";
					throw new AppException(errMessage);
				}

				// VERIFY MOVIMENTACAO SAIDA FROM ARECEBER
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

				foreach (objMovimentacao saida in listMovSaidas)
				{
					if (saida.IDCaixa != null)
					{
						errMessage += $"Reg.: {saida.IDMovimentacao:D4} | {saida.MovData.ToShortDateString()} | Caixa: {saida.IDCaixa:D4}\n";
						err = true;
					}
				}

				if (err == true)
				{
					errMessage += "Favor remover o(s) caixa(s) se desejar EXCLUIR a(s) DESPESA.";
					throw new AppException(errMessage);
				}

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
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

				string query = "SELECT * FROM qryDespesaTipo";

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
					objDespesaTipo forma = new objDespesaTipo((int)row["IDDespesaTipo"])
					{
						DespesaTipo = (string)row["DespesaTipo"],
						Periodicidade = (byte)row["Periodicidade"],
						DespesaFixa = (bool)row["DespesaFixa"],
						IDDespesaTipoGrupo = (byte)row["IDDespesaTipoGrupo"],
						DespesaTipoGrupo = (string)row["DespesaTipoGrupo"],
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
				int newID = (int)db.ExecutarInsertAndGetID(query);

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

				string query = "SELECT * FROM tblDespesaTipoGrupo";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY DespesaTipoGrupo";

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
						IDDespesaTipoGrupo = (byte)row["IDDespesaTipoGrupo"],
						DespesaTipoGrupo = (string)row["DespesaTipoGrupo"],
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

				string query = db.CreateInsertSQL("tblDespesaTipoGrupo");

				//--- insert and Get new ID
				int newID = (int)db.ExecutarInsertAndGetID(query);

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
				string query = db.CreateUpdateSQL("tblDespesaTipoGrupo", "@IDDespesaTipoGrupo");

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

		//=================================================================================================
		// DESPESA TITULAR
		//=================================================================================================

		// GET DESPESA TITULAR
		//------------------------------------------------------------------------------------------------------------
		public List<objDespesaTitular> GetTitularList(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblDespesaTitular";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY Titular";

				List<objDespesaTitular> listagem = new List<objDespesaTitular>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objDespesaTitular titular = new objDespesaTitular()
					{
						IDTitular = (int)row["IDTitular"],
						Titular = (string)row["Titular"],
						CNP = row["CNP"] == DBNull.Value ? string.Empty : (string)row["CNP"],
						Ativo = (bool)row["Ativo"],
					};

					listagem.Add(titular);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT DESPESA TITULAR
		//------------------------------------------------------------------------------------------------------------
		public int InsertTitutar(objDespesaTitular titular)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Titular", titular.Titular);
				db.AdicionarParametros("@CNP", titular.CNP);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblDespesaTitular");

				//--- insert and Get new ID
				int newID = (int)db.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE DESPESA TITULAR
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateTitular(objDespesaTitular titular)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDTitular", titular.IDTitular);
				db.AdicionarParametros("@Titular", titular.Titular);
				db.AdicionarParametros("@CNP", titular.CNP);
				db.AdicionarParametros("@Ativo", titular.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblDespesaTitular", "@IDTitular");

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
