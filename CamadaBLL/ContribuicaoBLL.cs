using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CamadaBLL
{
	public class ContribuicaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicao> GetListContribuicao(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDContribuicao";

				List<objContribuicao> listagem = new List<objContribuicao>();
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

		// GET CONTRIBUICAO
		//------------------------------------------------------------------------------------------------------------
		public objContribuicao GetContribuicao(int IDContribuicao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryContribuicao WHERE IDContribuicao = @IDContribuicao";
				db.LimparParametros();
				db.AdicionarParametros("@IDContribuicao", IDContribuicao);

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
		public objContribuicao ConvertRowInClass(DataRow row)
		{
			objContribuicao entrada = new objContribuicao((int)row["IDContribuicao"])
			{
				ContribuicaoData = (DateTime)row["ContribuicaoData"],
				IDEntradaForma = (byte)row["IDEntradaForma"],
				EntradaForma = (string)row["EntradaForma"],
				ValorBruto = (decimal)row["ValorBruto"],
				IDContribuicaoTipo = (byte)row["IDContribuicaoTipo"],
				ContribuicaoTipo = (string)row["ContribuicaoTipo"],
				IDSetor = (int)row["IDSetor"],
				Setor = (string)row["Setor"],
				IDConta = (int)row["IDConta"],
				Conta = (string)row["Conta"],
				IDContribuinte = row["IDContribuinte"] == DBNull.Value ? null : (int?)row["IDContribuinte"],
				Contribuinte = row["Contribuinte"] == DBNull.Value ? null : (string)row["Contribuinte"],
				OrigemDescricao = row["OrigemDescricao"] == DBNull.Value ? null : (string)row["OrigemDescricao"],
				IDReuniao = row["IDReuniao"] == DBNull.Value ? null : (int?)row["IDReuniao"],
				Reuniao = row["Reuniao"] == DBNull.Value ? null : (string)row["Reuniao"],
				IDCampanha = row["IDCampanha"] == DBNull.Value ? null : (int?)row["IDCampanha"],
				Campanha = row["Campanha"] == DBNull.Value ? null : (string)row["Campanha"],
			};

			return entrada;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertContribuicao(objContribuicao cont, object forma = null)
		{
			AcessoDados db = new AcessoDados();
			int newID = 0;

			try
			{
				db.BeginTransaction();

				switch (cont.IDContribuicaoTipo)
				{
					case 1: // DINHEIRO

						//--- Insert Contribuicao
						newID = AddContribuicao(cont, db);

						//--- Create NEW Entrada
						var entrada = new objEntrada(null)
						{
							IDConta = cont.IDConta,
							IDSetor = cont.IDSetor,
							IDOrigem = newID,
							Origem = 1,
							EntradaData = cont.ContribuicaoData,
							EntradaValor = cont.ValorBruto,
						};

						//--- Insert Entrada
						new EntradaBLL().InsertEntrada(entrada, db);

						break;

					case 2: // CHEQUE

						if (forma == null || forma.GetType() != typeof(objContribuicaoCheque))
							throw new Exception("Não há registro de informação do cheque...");

						//--- Insert Contribuicao
						newID = AddContribuicao(cont, db);
						cont.IDContribuicao = newID;

						//--- Insert ContribuicaoCheque
						objContribuicaoCheque cheque = (objContribuicaoCheque)forma;

						cheque.IDContribuicao = newID;
						AddContribuicaoCheque(cheque, db);

						//--- Create AReceber
						var areceber = new objAReceber(null)
						{
							CompensacaoData = cheque.DepositoData,
							IDContaProvisoria = cont.IDConta,
							IDContribuicao = (long)cont.IDContribuicao,
							Situacao = 1,
							ValorBruto = cont.ValorBruto,
							ValorLiquido = cont.ValorBruto,
							ValorRecebido = 0
						};

						//--- Insert AReceber Parcela
						new AReceberBLL().InsertAReceber(areceber);

						break;
					case 3: // CARTAO

						if (forma == null || forma.GetType() != typeof(objContribuicaoCartao))
							throw new Exception("Não há registro de informação do cartão...");

						//--- Insert Contribuicao
						newID = AddContribuicao(cont, db);
						cont.IDContribuicao = newID;

						//--- Insert ContribuicaoCartao
						objContribuicaoCartao cartao = (objContribuicaoCartao)forma;

						cartao.IDContribuicao = newID;
						AddContribuicaoCartao(cartao, db);

						//--- Insert ListOf AReceber
						var listAReceber = new List<objAReceber>();

						for (int i = 0; i < cartao.Parcelas; i++)
						{
							var parcela = new objAReceber(null)
							{
								CompensacaoData = cont.ContribuicaoData.AddDays(cartao.Prazo * (i + 1)),
								IDContaProvisoria = cartao.IDContaProvisoria,
								IDContribuicao = (long)cont.IDContribuicao,
								Situacao = 1,
								ValorBruto = cont.ValorBruto,
								ValorLiquido = cont.ValorBruto * (100 - cartao.TaxaAplicada),
								ValorRecebido = 0
							};

							listAReceber.Add(parcela);
						}

						var rBLL = new AReceberBLL();

						//--- Insert ListOf AReceber Parcelas
						foreach (var parcela in listAReceber)
						{
							rBLL.InsertAReceber(parcela);
						}

						break;
					default:
						break;
				}

				if (newID == 0)
				{
					throw new Exception("Não foi possível inserir um novo registro de Contribuição...");
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

		// INSERT CONTRIBUICAO SIMPLES
		//------------------------------------------------------------------------------------------------------------
		private int AddContribuicao(objContribuicao cont, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@ContribuicaoData", cont.ContribuicaoData);
				dbTran.AdicionarParametros("@IDEntradaForma", cont.IDEntradaForma);
				dbTran.AdicionarParametros("@ValorBruto", cont.ValorBruto);
				dbTran.AdicionarParametros("@IDContribuicaoTipo", cont.IDContribuicaoTipo);
				dbTran.AdicionarParametros("@IDSetor", cont.IDSetor);
				dbTran.AdicionarParametros("@IDConta", cont.IDConta);
				dbTran.AdicionarParametros("@IDContribuinte", cont.IDContribuinte);
				dbTran.AdicionarParametros("@OrigemDescricao", cont.OrigemDescricao);
				dbTran.AdicionarParametros("@IDReuniao", cont.IDReuniao);
				dbTran.AdicionarParametros("@IDCampanha", cont.IDCampanha);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblContribuicao");

				//--- insert and Get new ID
				int newID = dbTran.ExecutarInsertAndGetID(query);

				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateContribuicao(objContribuicao entrada)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDContribuicao", entrada.IDContribuicao);
				db.AdicionarParametros("@ContribuicaoData", entrada.ContribuicaoData);
				db.AdicionarParametros("@IDEntradaForma", entrada.IDEntradaForma);
				db.AdicionarParametros("@ValorBruto", entrada.ValorBruto);
				db.AdicionarParametros("@IDContribuicaoTipo", entrada.IDContribuicaoTipo);
				db.AdicionarParametros("@IDSetor", entrada.IDSetor);
				db.AdicionarParametros("@IDConta", entrada.IDConta);
				db.AdicionarParametros("@IDContribuinte", entrada.IDContribuinte);
				db.AdicionarParametros("@OrigemDescricao", entrada.OrigemDescricao);
				db.AdicionarParametros("@IDReuniao", entrada.IDReuniao);
				db.AdicionarParametros("@IDCampanha", entrada.IDCampanha);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblContribuicaos", "@IDContribuicao");

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
		// CONTRIBUICAO CARTAO / CHEQUE
		//=================================================================================================

		// INSERT CONTRIBUICAO CARTAO
		//------------------------------------------------------------------------------------------------------------
		private void AddContribuicaoCartao(objContribuicaoCartao cartao, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDContribuicao", cartao.IDContribuicao);
				dbTran.AdicionarParametros("@IDEntradaForma", cartao.CartaoTipo);
				dbTran.AdicionarParametros("@ValorBruto", cartao.IDCartaoBandeira);
				dbTran.AdicionarParametros("@IDContribuicaoTipo", cartao.IDCartaoOperadora);
				dbTran.AdicionarParametros("@IDSetor", cartao.IDContaProvisoria);
				dbTran.AdicionarParametros("@IDConta", cartao.Parcelas);
				dbTran.AdicionarParametros("@IDContribuinte", cartao.TaxaAplicada);
				dbTran.AdicionarParametros("@Prazo", cartao.Prazo);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblContribuicaoCartao");

				//--- insert and Get new ID
				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// INSERT CONTRIBUICAO CHEQUE
		//------------------------------------------------------------------------------------------------------------
		private void AddContribuicaoCheque(objContribuicaoCheque cheque, AcessoDados dbTran)
		{
			try
			{
				//--- clear Params
				dbTran.LimparParametros();

				//--- define Params
				dbTran.AdicionarParametros("@IDContribuicao", cheque.IDContribuicao);
				dbTran.AdicionarParametros("@IDEntradaForma", cheque.ChequeNumero);
				dbTran.AdicionarParametros("@ValorBruto", cheque.DepositoData);
				dbTran.AdicionarParametros("@IDContribuicaoTipo", cheque.IDBanco);

				//--- convert null parameters
				dbTran.ConvertNullParams();

				string query = dbTran.CreateInsertSQL("tblContribuicaoCheque");

				//--- insert and Get new ID
				dbTran.ExecutarManipulacao(CommandType.Text, query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=============================================================================
		//=============================================================================

		// GET CONTRIBUICAO TIPOS
		//------------------------------------------------------------------------------------------------------------
		public List<objContribuicaoTipo> GetContribuicaoTiposList()
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblContribuicaoTipo";

				// add params
				db.LimparParametros();

				query += " ORDER BY ContribuicaoTipo";

				List<objContribuicaoTipo> listagem = new List<objContribuicaoTipo>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objContribuicaoTipo forma = new objContribuicaoTipo((byte)row["IDContribuicaoTipo"])
					{
						ContribuicaoTipo = (string)row["ContribuicaoTipo"],
						ComAtividade = (bool)row["ComAtividade"],
						ComCampanha = (bool)row["ComCampanha"],
						ComOrigem = (bool)row["ComOrigem"]
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
