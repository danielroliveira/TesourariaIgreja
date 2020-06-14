using CamadaDAL;
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
		public objAPagar GetAPagar()
		{
			throw new NotImplementedException();
		}

		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagar(int? IDSituacao,
			int? IDCobrancaForma = null,
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
				if (IDCobrancaForma != null)
				{
					db.AdicionarParametros("@IDCobrancaForma", IDCobrancaForma);
					query += myWhere ? " AND IDCobrancaForma = @IDCobrancaForma" : " WHERE IDCobrancaForma = @IDCobrancaForma";
					myWhere = true;
				}

				// add DataInicial
				if (dataInicial != null)
				{
					db.AdicionarParametros("@DataInicial", (DateTime)dataInicial);
					query += myWhere ? " AND Vencimento >= @DataInicial" : " WHERE Vencimento >= @DataInicial";
					myWhere = true;
				}

				// add DataFinal
				if (dataFinal != null)
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
					var periodica = GetListAPagarPeriodica(IDCobrancaForma, IDCredor, dataInicial, dataFinal);
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

		// GET LIST OF
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

		// GET LIST OF DESPESA PERIODICA
		//------------------------------------------------------------------------------------------------------------
		public List<objAPagar> GetListAPagarPeriodica(
			int? IDCobrancaForma = null,
			int? IDCredor = null,
			DateTime? dataInicial = null,
			DateTime? dataFinal = null)
		{
			// get Despesa Periodica List
			List<objDespesaPeriodica> listPer = new DespesaPeriodicaBLL()
				.GetListDespesaPeriodica(true, null, null, IDCredor, IDCobrancaForma, dataInicial);

			List<objAPagar> APagarList = new List<objAPagar>();

			foreach (objDespesaPeriodica desp in listPer)
			{
				APagarList.AddRange(CreateListAPagarPeriodica(desp, dataInicial, dataFinal));
			}

			return APagarList;
		}

		// CREATE LIST OF DESPESA PERIODICA
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

						// try to convert in date
						if (!DateTime.TryParse(strDate, out dtAtual))
						{
							int maxDays = DateTime.DaysInMonth(dtAtual.Month, dtAtual.Year);
							dtAtual = new DateTime(dtAtual.Year, dtAtual.Month, maxDays);
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
					if (!DateTime.TryParse(strDate2, out dtAtual))
					{
						int maxDays = DateTime.DaysInMonth((int)desp.RecorrenciaMes, dtAtual.Year);
						dtAtual = new DateTime(dtAtual.Year, (int)desp.RecorrenciaMes, maxDays);
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
				CobrancaForma = desp.CobrancaForma,
				Credor = desp.Credor,
				DespesaDescricao = desp.DespesaDescricao,
				DespesaOrigem = 2,
				IDBanco = desp.IDBanco,
				IDCobrancaForma = desp.IDCobrancaForma,
				IDCredor = desp.IDCredor,
				IDDespesa = (long)desp.IDDespesa,
				IDSituacao = 1,
				Imagem = false,
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

				// 1. update Despesa Periodica (IniciarData, DespesaValor)
				desp.IniciarData = Vencimento.AddDays(1);
				new DespesaPeriodicaBLL().UpdateDespesa(desp, dbTran);

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
		private objAPagar ConvertRowInClass(DataRow row)
		{
			objAPagar despesa = new objAPagar((long)row["IDAPagar"])
			{
				IDDespesa = (long)row["IDDespesa"],
				DespesaDescricao = (string)row["DespesaDescricao"],
				DespesaOrigem = (byte)row["DespesaOrigem"],
				Identificador = (string)row["Identificador"],
				Parcela = row["Parcela"] == DBNull.Value ? null : (byte?)row["Parcela"],
				IDCobrancaForma = (int)row["IDCobrancaForma"],
				CobrancaForma = (string)row["CobrancaForma"],
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
				Imagem = (bool)row["Imagem"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
			};

			return despesa;

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
				dbTran.AdicionarParametros("@IDCobrancaForma", pag.IDCobrancaForma);
				dbTran.AdicionarParametros("@IDDespesa", pag.IDDespesa);
				dbTran.AdicionarParametros("@Identificador", pag.Identificador);
				dbTran.AdicionarParametros("@IDSituacao", pag.IDSituacao);
				dbTran.AdicionarParametros("@Imagem", pag.Imagem);
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
				db.AdicionarParametros("@IDCobrancaForma", pag.IDCobrancaForma);
				db.AdicionarParametros("@IDDespesa", pag.IDDespesa);
				db.AdicionarParametros("@Identificador", pag.Identificador);
				db.AdicionarParametros("@IDSituacao", pag.IDSituacao);
				db.AdicionarParametros("@Imagem", pag.Imagem);
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

		// QUITAR A PAGAR AND INSERT NEW SAIDA
		//------------------------------------------------------------------------------------------------------------
		public long QuitarAPagar(
			objAPagar apagar,
			objSaida saida,
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

				decimal saldoAtual = cBLL.ContaSaldoGet(saida.IDConta, dbTran);

				if (saida.SaidaValor > saldoAtual)
				{
					throw new AppException("Não existe SALDO SUFICIENTE na conta para realizar esse débito...", 1);
				}

				// Verifica CONTA BLOQUEIO
				if (!cBLL.ContaDateBlockPermit(saida.IDConta, saida.SaidaData, dbTran))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data de Débito proposto...", 2);
				}

				// Inserir SAIDA
				long newID = new SaidaBLL().InsertSaida(saida, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);
				saida.IDSaida = newID;

				// Change APAGAR
				decimal DoValor = saida.SaidaValor - saida.AcrescimoValor ?? 0;

				apagar.ValorAcrescimo += saida.AcrescimoValor ?? 0;
				apagar.ValorPago += DoValor;
				if (apagar.ValorPago >= apagar.APagarValor)
				{
					apagar.PagamentoData = saida.SaidaData;
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
			objSaida saida,
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

				if (!cBLL.ContaDateBlockPermit(saida.IDConta, saida.SaidaData, dbTran))
				{
					throw new AppException("A Data da Conta está BLOQUEADA nesta Data proposta...", 2);
				}

				// DELETE REMOVE SAIDA
				new SaidaBLL().RemoveSaida(saida, ContaSldLocalUpdate, SetorSldLocalUpdate, dbTran);

				// Change APAGAR
				decimal DoValor = saida.SaidaValor - saida.AcrescimoValor ?? 0;

				apagar.ValorAcrescimo -= saida.AcrescimoValor ?? 0;
				apagar.ValorPago -= DoValor;
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
	}

	//=================================================================================================
	// COBRANCA FORMA
	//=================================================================================================
	public class CobrancaFormaBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objCobrancaForma> GetListCobrancaForma(bool? Ativo = null, object dbTran = null)
		{
			try
			{
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				string query = "SELECT * FROM qryCobrancaForma";
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

				query += " ORDER BY IDCobrancaForma";

				// execute datatable
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				// create list
				List<objCobrancaForma> listagem = new List<objCobrancaForma>();

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objCobrancaForma cob = new objCobrancaForma((int)row["IDCobrancaForma"])
					{
						CobrancaForma = (string)row["CobrancaForma"],
						IDBanco = row["IDBanco"] == DBNull.Value ? null : (int?)row["IDBanco"],
						BancoNome = row["BancoNome"] == DBNull.Value ? string.Empty : (string)row["BancoNome"],
						IDCartaoBandeira = row["IDCartaoBandeira"] == DBNull.Value ? null : (int?)row["IDCartaoBandeira"],
						CartaoBandeira = row["CartaoBandeira"] == DBNull.Value ? string.Empty : (string)row["CartaoBandeira"],
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

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertCobrancaForma(objCobrancaForma forma)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@CobrancaForma", forma.CobrancaForma);
				db.AdicionarParametros("@IDBanco", forma.IDBanco);
				db.AdicionarParametros("@IDCartaoBandeira", forma.IDCartaoBandeira);
				db.AdicionarParametros("@Ativo", true);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblCobrancaForma");

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
		public bool UpdateCobrancaForma(objCobrancaForma forma)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCobrancaForma", forma.IDCobrancaForma);
				db.AdicionarParametros("@CobrancaForma", forma.CobrancaForma);
				db.AdicionarParametros("@IDBanco", forma.IDBanco);
				db.AdicionarParametros("@IDCartaoBandeira", forma.IDCartaoBandeira);
				db.AdicionarParametros("@Ativo", forma.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblCobrancaForma", "IDCobrancaForma");

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
