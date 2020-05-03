using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class EntradaBLL
	{
		//=================================================================================================
		// ENTRADA BLL
		//=================================================================================================

		// GET ENTRADA
		//------------------------------------------------------------------------------------------------------------
		public objEntrada GetEntrada(long IDEntrada, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryEntrada WHERE IDEntrada = @IDEntrada";
				db.LimparParametros();
				db.AdicionarParametros("@IDEntrada", IDEntrada);

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
		public objEntrada ConvertRowInClass(DataRow row)
		{
			objEntrada entrada = new objEntrada((long)row["IDEntrada"])
			{
				EntradaData = (DateTime)row["EntradaData"],
				IDOrigem = (long)row["IDOrigem"],
				Origem = (int)row["Origem"],
				EntradaValor = (decimal)row["EntradaValor"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"]
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertEntrada(objEntrada entrada, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				if (!db.isTran) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@EntradaData", entrada.EntradaData);
				db.AdicionarParametros("@EntradaValor", entrada.EntradaValor);
				db.AdicionarParametros("@IDOrigem", entrada.IDOrigem);
				db.AdicionarParametros("@Origem", entrada.Origem);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblEntradas");

				//--- insert and Get new ID
				int newID = db.ExecutarInsertAndGetID(query);

				//--- altera o saldo da CONTA
				new ContaBLL().ContaSaldoChange(entrada.IDConta, entrada.EntradaValor, db);

				//--- altera o saldo do SETOR
				new SetorBLL().SetorSaldoChange(entrada.IDSetor, entrada.EntradaValor, db);

				if (!db.isTran) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (!db.isTran) db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateEntrada(objEntrada entrada, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				// check and begin transaction
				if (!db.isTran) db.BeginTransaction();

				// get old Entrada IDSetor, IDConta, and Value
				var oldEntrada = GetEntrada((int)entrada.IDEntrada, db);

				// return old Values SALDO CONTA AND SETOR
				ContaBLL cBLL = new ContaBLL();
				SetorBLL sBLL = new SetorBLL();

				cBLL.ContaSaldoChange(oldEntrada.IDConta, oldEntrada.EntradaValor * (-1), db);
				sBLL.SetorSaldoChange(oldEntrada.IDSetor, oldEntrada.EntradaValor * (-1), db);

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDEntrada", entrada.IDEntrada);
				db.AdicionarParametros("@EntradaData", entrada.EntradaData);
				db.AdicionarParametros("@EntradaValor", entrada.EntradaValor);
				db.AdicionarParametros("@IDOrigem", entrada.IDOrigem);
				db.AdicionarParametros("@Origem", entrada.Origem);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblEntradas", "@IDEntrada");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- altera o saldo da CONTA e SETOR
				cBLL.ContaSaldoChange(entrada.IDConta, entrada.EntradaValor, db);
				sBLL.SetorSaldoChange(entrada.IDSetor, entrada.EntradaValor, db);

				//--- commit and return
				if (!db.isTran) db.CommitTransaction();
				return true;

			}
			catch (Exception ex)
			{
				if (!db.isTran) db.RollBackTransaction();
				throw ex;
			}
		}

		//=============================================================================
		//=============================================================================

		// GET ENTRADA FORMAS
		//------------------------------------------------------------------------------------------------------------
		public List<objEntradaForma> GetEntradaFormasList(bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblEntradaForma";

				// add params
				db.LimparParametros();

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					query += " WHERE Ativa = @Ativa";
				}

				query += " ORDER BY EntradaForma";

				List<objEntradaForma> listagem = new List<objEntradaForma>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objEntradaForma forma = new objEntradaForma((byte)row["IDEntradaForma"])
					{
						EntradaForma = (string)row["EntradaForma"],
						Ativa = (bool)row["Ativa"],
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
