using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class TransferenciaBLL
	{
		//=================================================================================================
		// ENTRADA BLL
		//=================================================================================================

		// GET ENTRADA
		//------------------------------------------------------------------------------------------------------------
		public objTransferencia GetTransferencia(long IDTransferencia, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryTransferencia WHERE IDTransferencia = @IDTransferencia";
				db.LimparParametros();
				db.AdicionarParametros("@IDTransferencia", IDTransferencia);

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
		public objTransferencia ConvertRowInClass(DataRow row)
		{
			objTransferencia entrada = new objTransferencia((long)row["IDTransferencia"])
			{
				TransferenciaData = (DateTime)row["TransferenciaData"],
				IDOrigem = (long)row["IDOrigem"],
				Origem = (int)row["Origem"],
				TransferenciaValor = (decimal)row["TransferenciaValor"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				IDCaixa = row["IDCaixa"] == DBNull.Value ? null : (long?)row["IDCaixa"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertTransferencia(objTransferencia transf,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", transf.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", transf.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", transf.IDOrigem);
				db.AdicionarParametros("@Origem", transf.Origem);
				db.AdicionarParametros("@IDSetor", transf.IDSetor);
				db.AdicionarParametros("@IDConta", transf.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblTransferencias");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA
				new ContaBLL().ContaSaldoChange(transf.IDConta, transf.TransferenciaValor, db, ContaSdlUpdate);

				//--- altera o saldo do SETOR
				new SetorBLL().SetorSaldoChange(transf.IDSetor, transf.TransferenciaValor, db, SetorSdlUpdate);

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// REMOVE DELETE TRANSFERENCIA BY ORIGEM AND IDORIGEM
		//------------------------------------------------------------------------------------------------------------
		public void RemoveTransferenciaByOrigem(
			int Origem,
			long IDOrigem,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;
			List<objTransferencia> ListTransf = new List<objTransferencia>();
			string query = "";

			try
			{
				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDOrigem", IDOrigem);
				db.AdicionarParametros("@Origem", Origem);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create SELECT query
				query = "SELECT * FROM qryTransferencia WHERE Origem = @Origem AND IDOrigem = @IDOrigem";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);
				if (dt.Rows.Count == 0)
				{
					throw new AppException("Não foi encontrada nenhuma transferência com a Origem informada...");
				}

				foreach (DataRow row in dt.Rows)
				{
					var transf = ConvertRowInClass(row);

					//--- Check is Caixa
					if (transf.IDCaixa != null)
					{
						throw new AppException("A Transferência não pode ser removida porque está anexada a um caixa...");
					}

					//--- Check is ContaDateBlock
					if (!new ContaBLL().ContaDateBlockPermit(transf.IDConta, transf.TransferenciaData, db))
					{
						throw new AppException("A Transferência não pode ser removida porque a Data está bloqueada na Conta...");
					}

					ListTransf.Add(transf);
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- Get OLD Values
				foreach (objTransferencia transf in ListTransf)
				{
					//--- clear Params
					db.LimparParametros();

					//--- define Params
					db.AdicionarParametros("@IDOrigem", IDOrigem);
					db.AdicionarParametros("@Origem", Origem);
					db.AdicionarParametros("@IDConta", transf.IDConta);

					//--- convert null parameters
					db.ConvertNullParams();

					//--- Delete Transferencia
					query = "DELETE tblTransferencias WHERE Origem = @Origem AND IDOrigem = @IDOrigem AND IDConta = @IDConta";
					db.ExecutarManipulacao(CommandType.Text, query);

					//--- altera o saldo da CONTA
					new ContaBLL().ContaSaldoChange(transf.IDConta, transf.TransferenciaValor * (-1), db, ContaSdlUpdate);

					//--- altera o saldo do SETOR
					new SetorBLL().SetorSaldoChange(transf.IDSetor, transf.TransferenciaValor * (-1), db, SetorSdlUpdate);
				}

				if (dbTran == null) db.CommitTransaction();

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

	}
}
