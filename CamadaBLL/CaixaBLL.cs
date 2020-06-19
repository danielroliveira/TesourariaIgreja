using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CamadaBLL
{
	class CaixaBLL
	{
		// GET Caixa
		//------------------------------------------------------------------------------------------------------------
		public objCaixa GetCaixaByID(long IDCaixa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCaixa WHERE IDCaixa = @IDCaixa";
				db.LimparParametros();
				db.AdicionarParametros("@IDCaixa", IDCaixa);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowInClass(dt.Rows[0]);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET Movimentacao LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objCaixa> GetCaixaList(
			int? IDConta = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null,
			object dbTran = null)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryCaixa";
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

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND DataInicial >= @DataInicial" : " WHERE DataInicial >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND DataInicial <= @DataFinal" : " WHERE DataInicial <= @DataFinal";
					myWhere = true;
				}

				query += " ORDER BY IDCaixa";

				List<objCaixa> listagem = new List<objCaixa>();
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
		public objCaixa ConvertRowInClass(DataRow row)
		{
			objCaixa Movimentacao = new objCaixa((long)row["IDCaixa"])
			{
				FechamentoData = (DateTime)row["FechamentoData"],
				IDConta = (int)row["IDConta"],
				Conta = row["Conta"] == DBNull.Value ? null : (string)row["Conta"],
				ContaSaldo = (decimal)row["ContaSaldo"],
				ContaBloqueioData = row["ContaBloqueioData"] == DBNull.Value ? null : (DateTime?)row["ContaBloqueioData"],
				DataFinal = (DateTime)row["DataFinal"],
				DataInicial = (DateTime)row["DataInicial"],
				SaldoAnterior = (decimal)row["SaldoAnterior"],
				SaldoFinal = (decimal)row["SaldoFinal"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				IDUsuario = (int)row["IDUsuario"],
				UsuarioApelido = (string)row["UsuarioApelido"],
				CaixaFinalDoDia = (bool)row["CaixaFinalDoDia"],
				Observacao = (string)row["Observacao"],
			};

			return Movimentacao;
		}

		// INSERT CAIXA
		//------------------------------------------------------------------------------------------------------------
		public objCaixa InsertCaixa(objCaixa caixa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@FechamentoData", caixa.FechamentoData);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataInicial", caixa.DataInicial);
				db.AdicionarParametros("@DataFinal", caixa.DataFinal);
				db.AdicionarParametros("@SaldoAnterior", caixa.SaldoAnterior);
				db.AdicionarParametros("@SaldoFinal", caixa.SaldoFinal);
				db.AdicionarParametros("@IDSituacao", caixa.IDSituacao);
				db.AdicionarParametros("@IDUsuario", caixa.IDUsuario);
				db.AdicionarParametros("@CaixaFinalDoDia", caixa.CaixaFinalDoDia);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblCaixa");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);
				caixa.IDCaixa = newID;

				return caixa;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE CAIXA
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCaixa(objCaixa caixa)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCaixa", caixa.IDCaixa);
				db.AdicionarParametros("@FechamentoData", caixa.FechamentoData);
				db.AdicionarParametros("@IDConta", caixa.IDConta);
				db.AdicionarParametros("@DataInicial", caixa.DataInicial);
				db.AdicionarParametros("@DataFinal", caixa.DataFinal);
				db.AdicionarParametros("@SaldoAnterior", caixa.SaldoAnterior);
				db.AdicionarParametros("@SaldoFinal", caixa.SaldoFinal);
				db.AdicionarParametros("@IDSituacao", caixa.IDSituacao);
				db.AdicionarParametros("@IDUsuario", caixa.IDUsuario);
				db.AdicionarParametros("@CaixaFinalDoDia", caixa.CaixaFinalDoDia);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblCaixa", "IDCaixa");

				//--- execute update
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- change observacao
				ObservacaoBLL oBLL = new ObservacaoBLL();
				oBLL.SaveObservacao(3, (long)caixa.IDCaixa, caixa.Observacao, db);

				//--- commit and return
				db.CommitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

	}
}
