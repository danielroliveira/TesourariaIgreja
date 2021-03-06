﻿using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CamadaBLL
{
	//=================================================================================================
	// APAGAR
	//=================================================================================================
	public class APagarBLL
	{
		// GET
		//------------------------------------------------------------------------------------------------------------
		public objAPagar GetAPagar(long IDAPagar)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryAPagar";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDAPagar", IDAPagar);
				query += " WHERE IDAPagar = @IDAPagar";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new AppException("ID procurado não retornou nenhum registro...");
				}

				return ConvertRowInClass(dt.Rows[0]);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagar(int? IDSituacao,
			int? IDAPagarForma = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryAPagar";
				bool myWhere = false;

				// add params
				db.LimparParametros();

				// add IDSituacao
				if (IDSituacao != null)
				{
					db.AdicionarParametros("@IDSituacao", IDSituacao);
					query += myWhere ? " AND IDSituacao = @IDSituacao" : " WHERE IDSituacao = @IDSituacao";
					myWhere = true;

				}

				// add IDDespesaTipo
				if (IDAPagarForma != null)
				{
					db.AdicionarParametros("@IDAPagarForma", IDAPagarForma);
					query += myWhere ? " AND IDAPagarForma = @IDAPagarForma" : " WHERE IDAPagarForma = @IDAPagarForma";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null && IDSituacao != 0)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND Vencimento >= @DataInicial" : " WHERE Vencimento >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null && IDSituacao != 0)
				{
					db.AdicionarParametros("@DataFinal", (DateTime)dataFinal);
					query += myWhere ? " AND Vencimento <= @DataFinal" : " WHERE Vencimento <= @DataFinal";
					myWhere = true;
				}

				// add IDCredor
				if (IDCredor != null)
				{
					db.AdicionarParametros("@IDCredor", IDCredor);
					query += myWhere ? " AND IDCredor = @IDCredor" : " WHERE IDCredor = @IDCredor";
					myWhere = true;
				}

				query += " ORDER BY Vencimento";

				List<objAPagar> listagem = new List<objAPagar>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClass(row));
				}

				// add APAGAR DESPESA PERIODICA
				//-------------------------------------------------------------------------------------------------
				if (IDSituacao == 1) // EM ABERTO
				{
					var periodica = GetListAPagarPeriodica(IDAPagarForma, IDCredor, dataInicial, dataFinal);
					listagem.AddRange(periodica);
				}

				// RETURN
				return listagem.OrderBy(p => p.Vencimento).ToList();

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET LIST OF APAGAR FROM ID DESPESA
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagarByDespesa(long IDDespesa, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryAPagar WHERE IDDespesa = @IDDespesa";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDDespesa", IDDespesa);

				query += " ORDER BY IDAPagar";

				List<objAPagar> listagem = new List<objAPagar>();
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

		// GET LIST OF APAGAR FROM DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagarPeriodica(
			int? IDAPagarForma = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			// get Despesa Periodica List
			List<objDespesaPeriodica> listPer = new DespesaPeriodicaBLL()
				.GetListDespesaPeriodica(true, null, null, IDCredor, IDAPagarForma, dataFinal);

			List<objAPagar> APagarList = new List<objAPagar>();

			foreach (objDespesaPeriodica desp in listPer)
			{
				APagarList.AddRange(CreateListAPagarPeriodica(desp, dataInicial, dataFinal));
			}

			return APagarList;
		}

		// CREATE LIST OF APAGAR FROM DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		private List<objAPagar> CreateListAPagarPeriodica(
			objDespesaPeriodica desp,
			DateTime? dataInicial,
			DateTime? dataFinal = null)
		{
			// Check dfInicial
			if (dataInicial == null) dataInicial = desp.IniciarData;

			// Create dtAtual => 'DataInicial' OR 'IniciarData' o que for MAIOR
			DateTime dtAtual = (DateTime)dataInicial >= desp.IniciarData ? (DateTime)dataInicial : desp.IniciarData;

			// Check dfFinal
			if (dataFinal == null) dataFinal = dtAtual.AddYears(1);

			// create list APagar
			List<objAPagar> list = new List<objAPagar>();

			switch (desp.RecorrenciaTipo)
			{
				case 1: // DIARIO

					//--- discover the first date
					while (dtAtual <= dataFinal)
					{
						list.Add(CreateAPagarByDespesa(desp, dtAtual));
						dtAtual = dtAtual.AddDays((int)desp.RecorrenciaRepeticao);
					}

					break;

				case 2: // SEMANAL

					//--- discover the first date
					while ((int)dtAtual.DayOfWeek != desp.RecorrenciaDia)
					{
						dtAtual = dtAtual.AddDays(1);
					}

					//--- creating Vencimentos
					while (dtAtual <= dataFinal)
					{
						list.Add(CreateAPagarByDespesa(desp, dtAtual));
						dtAtual = dtAtual.AddDays(7 * (int)desp.RecorrenciaRepeticao);
					}

					break;

				case 3: // MENSAL POR DIA

					//--- discover the first date
					if (dtAtual.Day != desp.RecorrenciaDia)
					{
						if (dtAtual.Day > desp.RecorrenciaDia)
						{
							dtAtual = dtAtual.AddMonths(1);
						}

						// create string of date
						string strDate = $"{(int)desp.RecorrenciaDia}/{dtAtual.Month}/{dtAtual.Year}";

						// try to convert in date (IF ReferenciaDia > 29 in FEBRUARY)
						if (!DateTime.TryParse(strDate, out DateTime new_dtAtual)) // se nao for data
						{
							int maxDays = DateTime.DaysInMonth(dtAtual.Year, dtAtual.Month);
							dtAtual = new DateTime(dtAtual.Year, dtAtual.Month, maxDays);
						}
						else // se for data possivel
						{
							dtAtual = new_dtAtual;
						}
					}

					//--- creating Vencimentos
					while (dtAtual <= dataFinal)
					{
						list.Add(CreateAPagarByDespesa(desp, dtAtual));
						dtAtual = dtAtual.AddMonths((int)desp.RecorrenciaRepeticao);
					}

					break;

				case 4: // MENSAL POR SEMANA

					//--- discover the first date
					while ((int)dtAtual.DayOfWeek != desp.RecorrenciaDia)
					{
						dtAtual = dtAtual.AddDays(1);
					}

					// check week number
					int semana = (int)Math.Ceiling((decimal)dtAtual.Day / 7);

					while (semana != desp.RecorrenciaSemana)
					{
						dtAtual = dtAtual.AddDays(7);
						semana = (int)Math.Ceiling((decimal)dtAtual.Day / 7);
					}

					//--- creating Vencimentos
					while (dtAtual <= dataFinal)
					{
						list.Add(CreateAPagarByDespesa(desp, dtAtual));
						dtAtual = dtAtual.AddMonths((int)desp.RecorrenciaRepeticao);
					}

					break;

				case 5: // ANUAL POR MES E DIA

					//--- discover the first date
					if (dtAtual.Month != desp.RecorrenciaMes)
					{
						if (dtAtual.Month > desp.RecorrenciaMes)
						{
							dtAtual = dtAtual.AddYears(1);
						}

						if (dtAtual.Day > desp.RecorrenciaDia)
						{
							dtAtual = dtAtual.AddMonths(1);
						}
					}
					else
					{
						if (dtAtual.Day > desp.RecorrenciaDia)
						{
							dtAtual = dtAtual.AddMonths(1);
						}
					}

					// create string of date
					string strDate2 = $"{(int)desp.RecorrenciaDia}/{(int)desp.RecorrenciaMes}/{dtAtual.Year}";

					// try to convert in date
					if (!DateTime.TryParse(strDate2, out DateTime new_dtAtual2))
					{
						int maxDays = DateTime.DaysInMonth((int)desp.RecorrenciaMes, dtAtual.Year);
						dtAtual = new DateTime(dtAtual.Year, (int)desp.RecorrenciaMes, maxDays);
					}
					else
					{
						dtAtual = new_dtAtual2;
					}

					//--- creating Vencimentos
					while (dtAtual <= dataFinal)
					{
						list.Add(CreateAPagarByDespesa(desp, dtAtual));
						dtAtual = dtAtual.AddYears((int)desp.RecorrenciaRepeticao);
					}
					break;

				case 6: // ANUAL POR MES E SEMANA

					//--- discover the first date
					while ((int)dtAtual.Month != desp.RecorrenciaMes)
					{
						dtAtual = dtAtual.AddMonths(1);
					}

					while ((int)dtAtual.DayOfWeek != desp.RecorrenciaDia)
					{
						dtAtual = dtAtual.AddDays(1);
					}

					// check week number
					int semana2 = (int)Math.Ceiling((decimal)dtAtual.Day / 7);

					while (semana2 != desp.RecorrenciaSemana)
					{
						dtAtual = dtAtual.AddDays(7);
						semana2 = (int)Math.Ceiling((decimal)dtAtual.Day / 7);
					}

					//--- creating Vencimentos
					while (dtAtual <= dataFinal)
					{
						list.Add(CreateAPagarByDespesa(desp, dtAtual));
						dtAtual = dtAtual.AddYears((int)desp.RecorrenciaRepeticao);
					}
					break;

				default:
					break;
			}

			return list;

		}

		// CREATE NEW APAGAR BY DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		private objAPagar CreateAPagarByDespesa(objDespesaPeriodica desp, DateTime dtAtual)
		{
			return new objAPagar(null)
			{
				APagarValor = desp.DespesaValor,
				Banco = desp.BancoNome,
				APagarForma = desp.APagarForma,
				Credor = desp.Credor,
				DespesaDescricao = desp.DespesaDescricao,
				DespesaOrigem = 2,
				IDBanco = desp.IDBanco,
				IDAPagarForma = desp.IDAPagarForma,
				IDCredor = desp.IDCredor,
				IDDespesa = (long)desp.IDDespesa,
				IDSituacao = 1,
				PagamentoData = null,
				Identificador = $"PER{desp.IDDespesa:D4} | {dtAtual.Year}{dtAtual.Month:D2}{dtAtual.Day:D2}",
				Parcela = null,
				Situacao = "Em Aberto",
				Vencimento = dtAtual,
				ReferenciaAno = dtAtual.Year,
				ReferenciaMes = dtAtual.Month,
			};
		}

		// CONVERT APAGAR PERIODICO IN REAL
		//------------------------------------------------------------------------------------------------------------
		public objAPagar ConvertPeriodicoInReal(objDespesaPeriodica desp, DateTime Vencimento)
		{
			AcessoDados dbTran = null;

			try
			{
				// init transaction
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				//--- check exists DESP PERIODICA before this
				var PeriodicoList = CreateListAPagarPeriodica(desp, desp.IniciarData, desp.IniciarData.AddMonths(1));

				if (PeriodicoList[0].Vencimento != Vencimento)
				{
					throw new AppException($"Não é possível converter em Despesa Real já que existem vencimentos " +
						$"anteriores dessa despesa periódica.\n" +
						$"Primeira Data: {PeriodicoList[0].Vencimento:d}");
				}

				// 1. update Despesa Periodica (IniciarData, DespesaValor)
				desp.IniciarData = Vencimento.AddDays(1);
				new DespesaPeriodicaBLL().UpdateDespesaPeriodica(desp, dbTran);

				// 2. create and save APagar
				objAPagar newPag = CreateAPagarByDespesa(desp, Vencimento);
				InsertAPagar(newPag, dbTran);

				// 3. return new APagar
				dbTran.CommitTransaction();
				return newPag;

			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objAPagar ConvertRowInClass(DataRow row)
		{
			objAPagar pagar = new objAPagar((long)row["IDAPagar"])
			{
				IDDespesa = (long)row["IDDespesa"],
				DespesaDescricao = (string)row["DespesaDescricao"],
				DespesaOrigem = (byte)row["DespesaOrigem"],
				Identificador = (string)row["Identificador"],
				Parcela = row["Parcela"] == DBNull.Value ? null : (byte?)row["Parcela"],
				IDAPagarForma = (int)row["IDAPagarForma"],
				APagarForma = (string)row["APagarForma"],
				IDPagFormaModo = (byte)row["IDPagFormaModo"],
				IDCartaoCredito = row["IDCartaoCredito"] == DBNull.Value ? null : (int?)row["IDCartaoCredito"],
				APagarValor = (decimal)row["APagarValor"],
				IDSituacao = (byte)row["IDSituacao"],
				Situacao = (string)row["Situacao"],
				IDBanco = row["IDBanco"] == DBNull.Value ? null : (int?)row["IDBanco"],
				Banco = row["BancoNome"] == DBNull.Value ? string.Empty : (string)row["BancoNome"],
				Vencimento = (DateTime)row["Vencimento"],
				PagamentoData = row["PagamentoData"] == DBNull.Value ? null : (DateTime?)row["PagamentoData"],
				Prioridade = (byte)row["Prioridade"],
				IDCredor = row["IDCredor"] == DBNull.Value ? null : (int?)row["IDCredor"],
				Credor = row["Credor"] == DBNull.Value ? string.Empty : (string)row["Credor"],
				ValorPago = (decimal)row["ValorPago"],
				ValorAcrescimo = (decimal)row["ValorAcrescimo"],
				ValorDesconto = (decimal)row["ValorDesconto"],
				ReferenciaMes = row["ReferenciaMes"] == DBNull.Value ? null : (int?)row["ReferenciaMes"],
				ReferenciaAno = row["ReferenciaMes"] == DBNull.Value ? null : (int?)row["ReferenciaAno"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
			};

			// SET IMAGEM
			pagar.Imagem.IDOrigem = (long)pagar.IDAPagar;
			pagar.Imagem.Origem = EnumImagemOrigem.APagar;
			pagar.Imagem.ImagemFileName = row["ImagemFileName"] == DBNull.Value ? string.Empty : (string)row["ImagemFileName"];
			pagar.Imagem.ImagemPath = row["ImagemPath"] == DBNull.Value ? string.Empty : (string)row["ImagemPath"];

			return pagar;

		}

		// INSERT APAGAR
		//------------------------------------------------------------------------------------------------------------
		private objAPagar InsertAPagar(objAPagar pag, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@APagarValor", pag.APagarValor);
				dbTran.AdicionarParametros("@IDBanco", pag.IDBanco);
				dbTran.AdicionarParametros("@IDAPagarForma", pag.IDAPagarForma);
				dbTran.AdicionarParametros("@IDDespesa", pag.IDDespesa);
				dbTran.AdicionarParametros("@Identificador", pag.Identificador);
				dbTran.AdicionarParametros("@IDSituacao", pag.IDSituacao);
				dbTran.AdicionarParametros("@Parcela", pag.Parcela);
				dbTran.AdicionarParametros("@Prioridade", pag.Prioridade);
				dbTran.AdicionarParametros("@ReferenciaAno", pag.ReferenciaAno);
				dbTran.AdicionarParametros("@ReferenciaMes", pag.ReferenciaMes);
				dbTran.AdicionarParametros("@ValorPago", pag.ValorPago);
				dbTran.AdicionarParametros("@ValorAcrescimo", pag.ValorAcrescimo);
				dbTran.AdicionarParametros("@ValorDesconto", pag.ValorDesconto);
				dbTran.AdicionarParametros("@Vencimento", pag.Vencimento);
				dbTran.AdicionarParametros("@PagamentoData", pag.PagamentoData);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblAPagar");

				//--- insert and Get new ID
				long newID = dbTran.ExecutarInsertAndGetID(query);
				pag.IDAPagar = newID;

				return pag;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> InsertAPagarList(List<objAPagar> list, AcessoDados dbTran)
		{
			try
			{
				var insertedList = new List<objAPagar>();

				foreach (var pag in list)
				{
					insertedList.Add(InsertAPagar(pag, dbTran));
				}

				return insertedList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAPagar(objAPagar pag, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAPagar", pag.IDAPagar);
				db.AdicionarParametros("@APagarValor", pag.APagarValor);
				db.AdicionarParametros("@IDBanco", pag.IDBanco);
				db.AdicionarParametros("@IDAPagarForma", pag.IDAPagarForma);
				db.AdicionarParametros("@IDDespesa", pag.IDDespesa);
				db.AdicionarParametros("@Identificador", pag.Identificador);
				db.AdicionarParametros("@IDSituacao", pag.IDSituacao);
				db.AdicionarParametros("@Parcela", pag.Parcela);
				db.AdicionarParametros("@Prioridade", pag.Prioridade);
				db.AdicionarParametros("@ReferenciaAno", pag.ReferenciaAno);
				db.AdicionarParametros("@ReferenciaMes", pag.ReferenciaMes);
				db.AdicionarParametros("@ValorPago", pag.ValorPago);
				db.AdicionarParametros("@ValorAcrescimo", pag.ValorAcrescimo);
				db.AdicionarParametros("@ValorDesconto", pag.ValorDesconto);
				db.AdicionarParametros("@Vencimento", pag.Vencimento);
				db.AdicionarParametros("@PagamentoData", pag.PagamentoData);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblAPagar", "IDAPagar");

				//--- insert and Get new ID
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE APAGAR
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteAPagar(objAPagar pagar, object dbTran = null)
		{
			try
			{
				if (pagar.Imagem != null && !string.IsNullOrEmpty(pagar.Imagem.ImagemFileName))
				{
					string errMessage = "Favor remover/desassociar as imagens do APagar se deseja EXCLUIR.";
					throw new AppException(errMessage);
				}

				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAPagar", pagar.IDAPagar);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "DELETE tblAPagar WHERE IDAPagar = @IDAPagar";

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// QUITAR A PAGAR AND INSERT NEW SAIDA
		//------------------------------------------------------------------------------------------------------------
		public long QuitarAPagar(
			objAPagar apagar,
			objMovimentacao saida,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// Verifica CONTA SALDO
				ContaBLL cBLL = new ContaBLL();

				decimal saldoAtual = cBLL.ContaSaldoGet((int)saida.IDConta, dbTran);

				if (Math.Abs(saida.MovValor) > saldoAtual)
				{
					throw new AppException("Não existe SALDO SUFICIENTE na conta para realizar esse débito...", 1);
				}

				// Verifica CONTA BLOQUEIO
				if (!cBLL.ContaDateBlockPermit((int)saida.IDConta, saida.MovData, dbTran))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data de Débito proposto...", 2);
				}

				// Inserir SAIDA
				saida.DescricaoOrigem = apagar.DespesaDescricao;
				long newID = new MovimentacaoBLL().InsertMovimentacao(saida, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);
				saida.IDMovimentacao = newID;

				// Change APAGAR
				decimal DoValor = Math.Abs(saida.MovValor) - (saida.AcrescimoValor ?? 0);

				apagar.ValorAcrescimo += saida.AcrescimoValor ?? 0;
				apagar.ValorPago += DoValor;
				if (apagar.ValorPago >= apagar.APagarValor - apagar.ValorDesconto)
				{
					apagar.PagamentoData = saida.MovData;
					apagar.IDSituacao = 2;
					apagar.Situacao = "Quitada";
				}

				// Update APAGAR
				UpdateAPagar(apagar, dbTran);

				dbTran.CommitTransaction();

				return newID;
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}

		}

		// ESTORNAR A PAGAR AND DELETE SAIDA
		//------------------------------------------------------------------------------------------------------------
		public bool EstornarAPagar(
			objAPagar apagar,
			objMovimentacao saida,
			Action<int, decimal> ContaSldLocalUpdate,
			Action<int, decimal> SetorSldLocalUpdate)
		{
			AcessoDados dbTran = null;

			try
			{
				dbTran = new AcessoDados();
				dbTran.BeginTransaction();

				// Verifica CONTA BLOQUEIO
				ContaBLL cBLL = new ContaBLL();

				if (!cBLL.ContaDateBlockPermit((int)saida.IDConta, saida.MovData, dbTran))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data proposta...", 2);
				}

				// CHECK SOURCE DESPESA IS DESPESA COMUM AND CHANGE SITUACAO
				if (apagar.DespesaOrigem == 1)
				{
					var dBLL = new DespesaComumBLL();
					dBLL.ChangeSituacaoDespesa(apagar.IDDespesa, 1, dbTran);
				}

				// DELETE REMOVE SAIDA
				new MovimentacaoBLL().DeleteMovimentacao((long)saida.IDMovimentacao, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);

				// Change APAGAR
				decimal DoValor = saida.MovValor - (saida.AcrescimoValor ?? 0);

				apagar.ValorAcrescimo -= saida.AcrescimoValor ?? 0;
				apagar.ValorPago += DoValor;
				apagar.PagamentoData = null;
				apagar.IDSituacao = 1;
				apagar.Situacao = "Em Aberto";

				// Update APAGAR
				UpdateAPagar(apagar, dbTran);

				dbTran.CommitTransaction();

				return true;
			}
			catch (Exception ex)
			{
				dbTran.RollBackTransaction();
				throw ex;
			}

		}

		//=================================================================================================
		// ACRESCIMO MOTIVO
		//=================================================================================================

		// GET LIST OF ACRESCIMO MOTIVO
		//------------------------------------------------------------------------------------------------------------
		public List<objAcrescimoMotivo> GetListMotivo(bool? Ativo = null, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM tblMovAcrescimoMotivo";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					if (haveWhere)
						query += " AND Ativo = @Ativo";
					else
						query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDAcrescimoMotivo";

				// execute datatable
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				// create list
				List<objAcrescimoMotivo> listagem = new List<objAcrescimoMotivo>();

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objAcrescimoMotivo cob = new objAcrescimoMotivo()
					{
						IDAcrescimoMotivo = (byte)row["IDAcrescimoMotivo"],
						AcrescimoMotivo = (string)row["AcrescimoMotivo"],
						Ativo = (bool)row["Ativo"],
					};

					listagem.Add(cob);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT ACRESCIMO MOTIVO
		//------------------------------------------------------------------------------------------------------------
		public int InsertAcrescimoMotivo(objAcrescimoMotivo motivo)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@AcrescimoMotivo", motivo.AcrescimoMotivo);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblMovAcrescimoMotivo");

				//--- insert
				return (int)db.ExecutarInsertAndGetID(query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE ACRESCIMO MOTIVO
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAcrescimoMotivo(objAcrescimoMotivo motivo)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAcrescimoMotivo", motivo.IDAcrescimoMotivo);
				db.AdicionarParametros("@AcrescimoMotivo", motivo.AcrescimoMotivo);
				db.AdicionarParametros("@Ativo", motivo.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblMovAcrescimoMotivo", "IDAcrescimoMotivo");

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

	//=================================================================================================
	// APAGAR FORMA
	//=================================================================================================
	public class APagarFormaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagarForma> GetListAPagarForma(bool? Ativo = null, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryAPagarForma";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					if (haveWhere)
						query += " AND Ativo = @Ativo";
					else
						query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDAPagarForma";

				// execute datatable
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				// create list
				List<objAPagarForma> listagem = new List<objAPagarForma>();

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objAPagarForma cob = new objAPagarForma((int)row["IDAPagarForma"])
					{
						APagarForma = (string)row["APagarForma"],
						IDPagFormaModo = (byte)row["IDPagFormaModo"],
						PagFormaModo = (string)row["PagFormaModo"],
						IDBanco = row["IDBanco"] == DBNull.Value ? null : (int?)row["IDBanco"],
						BancoNome = row["BancoNome"] == DBNull.Value ? string.Empty : (string)row["BancoNome"],
						IDCartaoCredito = row["IDCartaoCredito"] == DBNull.Value ? null : (int?)row["IDCartaoCredito"],
						Ativo = (bool)row["Ativo"],
					};

					if (cob.IDCartaoCredito != null)
					{
						cob.CartaoCredito.CartaoDescricao = (string)row["CartaoDescricao"];
						cob.CartaoCredito.IDCartaoBandeira = (int)row["IDCartaoBandeira"];
						cob.CartaoCredito.CartaoBandeira = (string)row["CartaoBandeira"];
						cob.CartaoCredito.CartaoNumeracao = (string)row["CartaoNumeracao"];
						cob.CartaoCredito.VencimentoDia = (byte)row["VencimentoDia"];
						cob.CartaoCredito.IDSetorCartao = (int)row["IDSetorCartao"];
						cob.CartaoCredito.IDCredorCartao = (int)row["IDCredorCartao"];
					}

					listagem.Add(cob);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertAPagarForma(objAPagarForma forma)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@APagarForma", forma.APagarForma);
				db.AdicionarParametros("@IDPagFormaModo", forma.IDPagFormaModo);
				db.AdicionarParametros("@IDBanco", forma.IDBanco);
				db.AdicionarParametros("@IDCartaoCredito", forma.IDCartaoCredito);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblAPagarForma");

				//--- insert
				return (int)db.ExecutarInsertAndGetID(query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateAPagarForma(objAPagarForma forma)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDAPagarForma", forma.IDAPagarForma);
				db.AdicionarParametros("@APagarForma", forma.APagarForma);
				db.AdicionarParametros("@IDPagFormaModo", forma.IDPagFormaModo);
				db.AdicionarParametros("@IDBanco", forma.IDBanco);
				db.AdicionarParametros("@IDCartaoCredito", forma.IDCartaoCredito);
				db.AdicionarParametros("@Ativo", forma.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblAPagarForma", "IDAPagarForma");

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

	//=================================================================================================
	// APAGAR CARTAO
	//=================================================================================================
	public class APagarCartaoBLL
	{
		// GET CARTAO CREDITO DE DESPESA
		//------------------------------------------------------------------------------------------------------------
		public objAPagarCartao GetCartaoCreditoDespesa(long IDCartaoCredito, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryCartaoCreditoDespesa WHERE IDCartaoCredito = @IDCartaoCredito";
				db.LimparParametros();
				db.AdicionarParametros("@IDCartaoCredito", IDCartaoCredito);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					throw new AppException("Não existe registro de Cartão de Crédito com esse número de Registro...");
				}

				var row = dt.Rows[0];

				var cartao = new objAPagarCartao(null)
				{
					IDCartaoCredito = (int)row["IDCartaoCredito"],
					CartaoDescricao = (string)row["CartaoDescricao"],
					IDCartaoBandeira = row["IDCartaoBandeira"] == DBNull.Value ? null : (int?)row["IDCartaoBandeira"],
					CartaoBandeira = row["CartaoBandeira"] == DBNull.Value ? string.Empty : (string)row["CartaoBandeira"],
					CartaoNumeracao = row["CartaoNumeracao"] == DBNull.Value ? string.Empty : (string)row["CartaoNumeracao"],
					IDCredorCartao = (int)row["IDCredor"],
					CredorCartao = (string)row["Credor"],
					IDSetorCartao = (int)row["IDSetor"],
					SetorCartao = (string)row["Setor"],
					VencimentoDia = (byte)row["VencimentoDia"],
					IDAPagarForma = (int)row["IDAPagarForma"],
					APagarForma = (string)row["APagarForma"],
				};

				return cartao;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET CARTAO CREDITO DE DESPESA
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagarCartao> GetCartaoCreditoDespesaList(object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryCartaoCreditoDespesa";
				db.LimparParametros();

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				var list = new List<objAPagarCartao>();

				foreach (DataRow row in dt.Rows)
				{
					var cartao = new objAPagarCartao(null)
					{
						IDCartaoCredito = (int)row["IDCartaoCredito"],
						CartaoDescricao = (string)row["CartaoDescricao"],
						IDCartaoBandeira = row["IDCartaoBandeira"] == DBNull.Value ? null : (int?)row["IDCartaoBandeira"],
						CartaoBandeira = row["CartaoBandeira"] == DBNull.Value ? string.Empty : (string)row["CartaoBandeira"],
						CartaoNumeracao = row["CartaoNumeracao"] == DBNull.Value ? string.Empty : (string)row["CartaoNumeracao"],
						IDCredorCartao = (int)row["IDCredor"],
						CredorCartao = (string)row["Credor"],
						IDSetorCartao = (int)row["IDSetor"],
						SetorCartao = (string)row["Setor"],
						VencimentoDia = (byte)row["VencimentoDia"],
						IDAPagarForma = (int)row["IDAPagarForma"],
						APagarForma = (string)row["APagarForma"],
					};

					list.Add(cartao);
				}

				return list;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT CARTAO CREDITO DE DESPESA
		//------------------------------------------------------------------------------------------------------------
		public int InsertCartaoCreditoDespesa(objAPagarCartao cartao, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				db = new AcessoDados();
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@CartaoDescricao", cartao.CartaoDescricao);
				db.AdicionarParametros("@VencimentoDia", cartao.VencimentoDia);
				db.AdicionarParametros("@IDCartaoBandeira", cartao.IDCartaoBandeira);
				db.AdicionarParametros("@CartaoNumeracao", cartao.CartaoNumeracao);
				db.AdicionarParametros("@IDSetor", cartao.IDSetorCartao);
				db.AdicionarParametros("@IDCredor", cartao.IDCredorCartao);
				db.AdicionarParametros("@IDAPagarForma", cartao.IDAPagarForma);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblCartaoCredito");

				//--- insert and Get new ID
				long newID = db.ExecutarInsertAndGetID(query);

				if (dbTran == null) db.CommitTransaction();
				return (int)newID;

			}
			catch (Exception ex)
			{
				if (dbTran == null) db.RollBackTransaction();
				throw ex;
			}
		}

		// UPDATE CARTAO CREDITO DE DESPESA
		//------------------------------------------------------------------------------------------------------------
		public void UpdateCartaoCreditoDespesa(objAPagarCartao cartao, object dbTran = null)
		{
			AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

			try
			{
				db = new AcessoDados();
				if (dbTran == null) db.BeginTransaction();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCartaoCredito", cartao.IDCartaoCredito);
				db.AdicionarParametros("@CartaoDescricao", cartao.CartaoDescricao);
				db.AdicionarParametros("@VencimentoDia", cartao.VencimentoDia);
				db.AdicionarParametros("@IDCartaoBandeira", cartao.IDCartaoBandeira);
				db.AdicionarParametros("@CartaoNumeracao", cartao.CartaoNumeracao);
				db.AdicionarParametros("@IDSetor", cartao.IDSetorCartao);
				db.AdicionarParametros("@IDCredor", cartao.IDCredorCartao);
				db.AdicionarParametros("@IDAPagarForma", cartao.IDAPagarForma);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateUpdateSQL("tblCartaoCredito", "IDCartaoCredito");

				//--- insert and Get new ID
				db.ExecutarManipulacao(CommandType.Text, query);

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
