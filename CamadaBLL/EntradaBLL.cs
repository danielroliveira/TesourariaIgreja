﻿using CamadaDAL;
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

		// GET LIST ENTRADAS OR ORIGEM AND IDORIGEM
		//------------------------------------------------------------------------------------------------------------
		public List<objEntrada> GetEntradaListByOrigem(int Origem, long IDOrigem, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryEntrada WHERE Origem = @Origem AND IDOrigem = @IDOrigem";
				db.LimparParametros();
				db.AdicionarParametros("@IDOrigem", IDOrigem);
				db.AdicionarParametros("@Origem", Origem);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				List<objEntrada> list = new List<objEntrada>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow row in dt.Rows)
					{
						list.Add(ConvertRowInClass(row));
					}
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
				Conta = (string)row["Conta"],
				Consolidado = (bool)row["Consolidado"],
				Observacao = row["Observacao"] == DBNull.Value ? string.Empty : (string)row["Observacao"],
				IDCaixa = row["IDCaixa"] == DBNull.Value ? null : (long?)row["IDCaixa"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public long InsertEntrada(objEntrada entrada,
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
				db.AdicionarParametros("@EntradaData", entrada.EntradaData);
				db.AdicionarParametros("@EntradaValor", entrada.EntradaValor);
				db.AdicionarParametros("@IDOrigem", entrada.IDOrigem);
				db.AdicionarParametros("@Origem", entrada.Origem);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@Consolidado", entrada.Consolidado);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblEntradas");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				//--- insert OBSERVACAO
				new ObservacaoBLL().SaveObservacao(1, newID, entrada.Observacao, db);

				//--- altera o saldo da CONTA
				new ContaBLL().ContaSaldoChange(entrada.IDConta, entrada.EntradaValor, db, ContaSdlUpdate);

				//--- altera o saldo do SETOR
				new SetorBLL().SetorSaldoChange(entrada.IDSetor, entrada.EntradaValor, db, SetorSdlUpdate);

				if (dbTran == null) db.CommitTransaction();
				return newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE CONSOLIDADO FOR IDARECEBER
		//------------------------------------------------------------------------------------------------------------
		public void UpdateEntradaConsolidado(long IDAReceber, bool Consolidado, AcessoDados dbTran)
		{
			try
			{
				dbTran.LimparParametros();
				dbTran.AdicionarParametros("@IDAReceber", IDAReceber);
				dbTran.AdicionarParametros("@Consolidado", Consolidado);

				string query = "UPDATE tblEntradas SET Consolidado = @Consolidado WHERE IDOrigem = @IDAReceber AND Origem = 2";

				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE ENTRADA
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteEntrada(long IDEntrada, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDEntrada", IDEntrada);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "DELETE tblEntradas WHERE IDEntrada = @IDEntrada";

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//==================================================================================================================
		//==================================================================================================================

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
