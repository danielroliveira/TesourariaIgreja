using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class SaidaBLL
	{
		//=================================================================================================
		// SAIDA BLL
		//=================================================================================================

		// GET SAIDA
		//------------------------------------------------------------------------------------------------------------
		public objSaida GetSaida(long IDSaida, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qrySaida WHERE IDSaida = @IDSaida";
				db.LimparParametros();
				db.AdicionarParametros("@IDSaida", IDSaida);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				return ConvertRowInClass(dt.Rows[0]);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET SAIDA LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objSaida> GetSaidaList(int Origem, long IDOrigem, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qrySaida WHERE Origem = @Origem AND IDOrigem = @IDOrigem";
				db.LimparParametros();
				db.AdicionarParametros("@Origem", Origem);
				db.AdicionarParametros("@IDOrigem", IDOrigem);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				List<objSaida> list = new List<objSaida>();

				if (dt.Rows.Count == 0)
					return list;

				foreach (DataRow row in dt.Rows)
				{
					list.Add(ConvertRowInClass(row));
				}

				return list;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objSaida ConvertRowInClass(DataRow row)
		{
			objSaida saida = new objSaida((long)row["IDSaida"])
			{
				SaidaData = (DateTime)row["SaidaData"],
				IDOrigem = (long)row["IDOrigem"],
				Origem = (int)row["Origem"],
				SaidaValor = (decimal)row["SaidaValor"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				AcrescimoValor = row["AcrescimoValor"] == DBNull.Value ? null : (decimal?)row["AcrescimoValor"],
				Imagem = (bool)row["Imagem"],
				Observacao = row["Observacao"] == DBNull.Value ? string.Empty : (string)row["Observacao"]
			};

			return saida;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertSaida(
			objSaida saida,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null
			)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@SaidaData", saida.SaidaData);
				db.AdicionarParametros("@SaidaValor", saida.SaidaValor);
				db.AdicionarParametros("@IDOrigem", saida.IDOrigem);
				db.AdicionarParametros("@Origem", saida.Origem);
				db.AdicionarParametros("@IDSetor", saida.IDSetor);
				db.AdicionarParametros("@IDConta", saida.IDConta);
				db.AdicionarParametros("@AcrescimoValor", saida.AcrescimoValor == 0 ? null : saida.AcrescimoValor);
				db.AdicionarParametros("@Imagem", saida.Imagem);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblSaidas");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- insert OBSERVACAO
				new ObservacaoBLL().SaveObservacao(2, newID, saida.Observacao, db);

				//--- altera o saldo da CONTA
				new ContaBLL().ContaSaldoChange(saida.IDConta, saida.SaidaValor * (-1), db, ContaSdlUpdate);

				//--- altera o saldo do SETOR
				new SetorBLL().SetorSaldoChange(saida.IDSetor, saida.SaidaValor * (-1), db, SetorSdlUpdate);

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// REMOVE
		//------------------------------------------------------------------------------------------------------------
		public bool RemoveSaida(
			objSaida saida,
			Action<int, decimal> ContaSdlUpdate,
			Action<int, decimal> SetorSdlUpdate,
			object dbTran = null
			)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDSaida", saida.IDSaida);
				string query = "DELETE tblSaidas WHERE IDSaida = @IDSaida";

				//--- convert null parameters
				db.ConvertNullParams();

				//--- DELETE
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- DELETE OBSERVACAO
				new ObservacaoBLL().DeleteObservacao(2, (long)saida.IDSaida, db);

				//--- altera o saldo da CONTA
				new ContaBLL().ContaSaldoChange(saida.IDConta, saida.SaidaValor, db, ContaSdlUpdate);

				//--- altera o saldo do SETOR
				new SetorBLL().SetorSaldoChange(saida.IDSetor, saida.SaidaValor, db, SetorSdlUpdate);

				if (dbTran == null) db.CommitTransaction();
				return true;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
