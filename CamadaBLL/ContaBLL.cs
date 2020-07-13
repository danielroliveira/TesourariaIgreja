using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class ContaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objConta> GetListConta(string conta, bool? Ativa = null, bool SemOperadoras = true)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryConta";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(conta))
				{
					db.AdicionarParametros("@Conta", conta);
					query += " WHERE Conta LIKE '%'+@Conta+'%' ";
					haveWhere = true;
				}

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					if (haveWhere)
						query += " AND Ativa = @Ativa";
					else
						query += " WHERE Ativa = @Ativa";

					haveWhere = true;
				}

				if (SemOperadoras == true)
				{
					if (haveWhere)
						query += " AND OperadoraCartao = 'false'";
					else
						query += " WHERE OperadoraCartao = 'false'";
				}

				query += " ORDER BY Conta";

				List<objConta> listagem = new List<objConta>();
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

		// GET CONTA
		//------------------------------------------------------------------------------------------------------------
		public objConta GetConta(int IDConta, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryConta WHERE IDConta = @IDConta";
				db.LimparParametros();
				db.AdicionarParametros("@IDConta", IDConta);

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
		public objConta ConvertRowInClass(DataRow row)
		{
			objConta conta = new objConta((int)row["IDConta"])
			{ };

			conta.Conta = (string)row["Conta"];
			conta.ContaSaldo = row["ContaSaldo"] == DBNull.Value ? 0 : (decimal)row["ContaSaldo"];
			conta.BloqueioData = row["BloqueioData"] == DBNull.Value ? null : (DateTime?)row["BloqueioData"];
			conta.OperadoraCartao = row["OperadoraCartao"] == DBNull.Value ? false : (bool)row["OperadoraCartao"];
			conta.Bancaria = row["Bancaria"] == DBNull.Value ? false : (bool)row["Bancaria"];
			conta.IDCongregacao = row["IDCongregacao"] == DBNull.Value ? null : (int?)row["IDCongregacao"];
			conta.Congregacao = row["Congregacao"] == DBNull.Value ? "" : (string)row["Congregacao"];
			conta.Ativa = (bool)row["Ativa"];


			return conta;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertConta(objConta conta,
			objCaixaAjuste ajuste = null,
			Action<int, decimal> ContaSldUpdate = null,
			Action<int, decimal> SetorSldUpdate = null)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Conta", conta.Conta);
				db.AdicionarParametros("@ContaSaldo", 0.0m);
				db.AdicionarParametros("@BloqueioData", conta.BloqueioData);
				db.AdicionarParametros("@Bancaria", conta.Bancaria);
				db.AdicionarParametros("@OperadoraCartao", conta.OperadoraCartao);
				db.AdicionarParametros("@IDCongregacao", conta.IDCongregacao);
				db.AdicionarParametros("@Ativa", conta.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblConta");

				//--- insert
				var newID = (int)db.ExecutarInsertAndGetID(query);

				//--- check Saldo INICIAL and insert
				if (ajuste != null)
				{
					ajuste.IDConta = newID;
					new AjusteBLL().InsertAjuste(ajuste, ContaSldUpdate, SetorSldUpdate, null, db);
				}

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
		public bool UpdateConta(objConta conta)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDConta", conta.IDConta);
				db.AdicionarParametros("@Conta", conta.Conta);
				db.AdicionarParametros("@ContaSaldo", conta.ContaSaldo);
				db.AdicionarParametros("@BloqueioData", conta.BloqueioData);
				db.AdicionarParametros("@Bancaria", conta.Bancaria);
				db.AdicionarParametros("@OperadoraCartao", conta.OperadoraCartao);
				db.AdicionarParametros("@IDCongregacao", conta.IDCongregacao);
				db.AdicionarParametros("@Ativa", conta.Ativa);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblConta", "IDConta");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONTA SALDO GET
		//------------------------------------------------------------------------------------------------------------
		public decimal ContaSaldoGet(int IDConta, object dbTran)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT ContaSaldo FROM tblConta WHERE IDConta = @IDConta";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDConta", IDConta);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new Exception("ID da CONTA não foi identificado...");
				}
				else if (decimal.TryParse(dt.Rows[0][0].ToString(), out decimal Saldo))
				{
					return Saldo;
				}
				else
				{
					throw new Exception(dt.Rows[0][0].ToString());
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONTA SALDO ALTERAR
		//------------------------------------------------------------------------------------------------------------
		public decimal ContaSaldoChange(int IDConta, decimal valor, AcessoDados dbTran, Action<int, decimal> ContaSldUpdate)
		{
			try
			{
				decimal saldo = ContaSaldoGet(IDConta, dbTran);
				decimal newSaldo = saldo + valor;

				//--- check NEGATIVE SALDO after change
				if (newSaldo < 0)
				{
					throw new AppException("O Saldo da Conta se tornará negativo após movimentação...");
				}

				string query = "UPDATE tblConta SET ContaSaldo = @newSaldo WHERE IDConta = @IDConta";

				// add params
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDConta", IDConta);
				dbTran.AdicionarParametros("@newSaldo", newSaldo);

				dbTran.ExecutarManipulacao(CommandType.Text, query);

				decimal SaldoAtual = ContaSaldoGet(IDConta, dbTran);

				// DELEGATE altera o saldo da conta local
				ContaSldUpdate(IDConta, valor);

				return SaldoAtual;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONTA SALDO RECALCULAR
		//------------------------------------------------------------------------------------------------------------
		public bool ContaSaldoRecalcular(objConta conta)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				db.LimparParametros();
				db.AdicionarParametros("@IDConta", conta.IDConta);

				DataTable dt = db.ExecutarConsulta(CommandType.StoredProcedure, "uspContaSaldoCorrect");

				if (dt.Rows.Count == 0)
				{
					throw new Exception("Não houve retorno da função de Recalcular o Saldo...");
				}

				decimal saldoAtual = (decimal)dt.Rows[0]["Saldo"];

				if (conta.ContaSaldo != saldoAtual)
				{
					decimal oldSaldo = conta.ContaSaldo;
					conta.ContaSaldo = saldoAtual;

					throw new AppException("Valor do Saldo da Conta foi alterado\n" +
						$"de: {oldSaldo:c}\n" +
						$"para: {saldoAtual:c}");
				}

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONTA BLOQUEIO DATA PERMIT
		//------------------------------------------------------------------------------------------------------------
		public bool ContaDateBlockPermit(int IDConta, DateTime DataMovimento, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT BloqueioData FROM tblConta WHERE IDConta = @IDConta";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDConta", IDConta);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new Exception("ID da CONTA não foi identificado...");
				}

				DateTime? bloqueioData = dt.Rows[0][0] == DBNull.Value ? null : (DateTime?)dt.Rows[0][0];

				if (bloqueioData != null)
				{
					return DataMovimento >= bloqueioData;
				}
				else
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
