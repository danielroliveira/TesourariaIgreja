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
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertTransferencia(objTransferencia entrada,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (!db.isTran) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@TransferenciaData", entrada.TransferenciaData);
				db.AdicionarParametros("@TransferenciaValor", entrada.TransferenciaValor);
				db.AdicionarParametros("@IDOrigem", entrada.IDOrigem);
				db.AdicionarParametros("@Origem", entrada.Origem);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblTransferencias");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA
				new ContaBLL().ContaSaldoChange(entrada.IDConta, entrada.TransferenciaValor, db, ContaSdlUpdate);

				//--- altera o saldo do SETOR
				new SetorBLL().SetorSaldoChange(entrada.IDSetor, entrada.TransferenciaValor, db, SetorSdlUpdate);

				if (!db.isTran) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (!db.isTran) db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
