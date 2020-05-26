using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CamadaBLL
{
	public class CartaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objCartaoTaxa> GetListCartaoTaxas(bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCartaoTaxas";

				// add params
				db.LimparParametros();

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY IDCartaoTaxa";

				List<objCartaoTaxa> listagem = new List<objCartaoTaxa>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
					return listagem;

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

		// GET CARTAO TAXA OF SPECIFIC OPERADORA | BANDEIRA | PARCELA
		//------------------------------------------------------------------------------------------------------------
		public objCartaoTaxa GetCartaoTaxa(int IDCartaoOperadora, int IDCartaoBandeira)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCartaoTaxas";

				// add params
				db.LimparParametros();

				db.AdicionarParametros("@IDCartaoOperadora", IDCartaoOperadora);

				query += " WHERE IDCartaoOperadora = @IDCartaoOperadora";
				query += " ORDER BY IDCartaoTaxa";

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
					return null;

				// create list to find Bandeira
				List<objCartaoTaxa> listagem = new List<objCartaoTaxa>();

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClass(row));
				}

				if (listagem.Count == 1)
				{
					return listagem[0];
				}
				else
				{
					return listagem.First(x => x.IDCartaoBandeira == IDCartaoBandeira);
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objCartaoTaxa ConvertRowInClass(DataRow row)
		{
			objCartaoTaxa taxa = new objCartaoTaxa((int)row["IDCartaoTaxa"])
			{
				IDCartaoOperadora = (int)row["IDCartaoOperadora"],
				CartaoOperadora = (string)row["CartaoOperadora"],
				IDContaProvisoria = (int)row["IDContaProvisoria"],
				ContaProvisoria = (string)row["ContaProvisoria"],
				IDCartaoBandeira = row["IDCartaoBandeira"] == DBNull.Value ? null : (int?)row["IDCartaoBandeira"],
				CartaoBandeira = row["CartaoBandeira"] == DBNull.Value ? "" : (string)row["CartaoBandeira"],
				PrazoDebito = (byte)row["PrazoDebito"],
				PrazoCredito = (byte)row["PrazoCredito"],
				TaxaDebito = row["TaxaDebito"] == DBNull.Value ? null : (decimal?)row["TaxaDebito"],
				TaxaCredito = row["TaxaCredito"] == DBNull.Value ? null : (decimal?)row["TaxaCredito"],
				Taxa2 = row["Taxa2"] == DBNull.Value ? null : (decimal?)row["Taxa2"],
				Taxa3 = row["Taxa3"] == DBNull.Value ? null : (decimal?)row["Taxa3"],
				Taxa4 = row["Taxa4"] == DBNull.Value ? null : (decimal?)row["Taxa4"],
				Taxa5 = row["Taxa5"] == DBNull.Value ? null : (decimal?)row["Taxa5"],
				Taxa6 = row["Taxa6"] == DBNull.Value ? null : (decimal?)row["Taxa6"],
				Taxa7 = row["Taxa7"] == DBNull.Value ? null : (decimal?)row["Taxa7"],
				Taxa8 = row["Taxa8"] == DBNull.Value ? null : (decimal?)row["Taxa8"],
				Taxa9 = row["Taxa9"] == DBNull.Value ? null : (decimal?)row["Taxa9"],
				Taxa10 = row["Taxa10"] == DBNull.Value ? null : (decimal?)row["Taxa10"],
				Taxa11 = row["Taxa11"] == DBNull.Value ? null : (decimal?)row["Taxa11"],
				Taxa12 = row["Taxa12"] == DBNull.Value ? null : (decimal?)row["Taxa12"],
				Ativo = (bool)row["Ativo"],
			};

			return taxa;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertCartaoTaxas(objCartaoTaxa taxa)
		{
			AcessoDados db = new AcessoDados();

			try
			{
				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCartaoOperadora", taxa.IDCartaoOperadora);
				db.AdicionarParametros("@IDCartaoBandeira", taxa.IDCartaoBandeira);
				db.AdicionarParametros("@PrazoDebito", taxa.PrazoDebito);
				db.AdicionarParametros("@PrazoCredito", taxa.PrazoCredito);
				db.AdicionarParametros("@TaxaDebito", taxa.TaxaDebito);
				db.AdicionarParametros("@TaxaCredito", taxa.TaxaCredito);
				db.AdicionarParametros("@Taxa2", taxa.Taxa2);
				db.AdicionarParametros("@Taxa3", taxa.Taxa3);
				db.AdicionarParametros("@Taxa4", taxa.Taxa4);
				db.AdicionarParametros("@Taxa5", taxa.Taxa5);
				db.AdicionarParametros("@Taxa6", taxa.Taxa6);
				db.AdicionarParametros("@Taxa7", taxa.Taxa7);
				db.AdicionarParametros("@Taxa8", taxa.Taxa8);
				db.AdicionarParametros("@Taxa9", taxa.Taxa9);
				db.AdicionarParametros("@Taxa10", taxa.Taxa10);
				db.AdicionarParametros("@Taxa11", taxa.Taxa11);
				db.AdicionarParametros("@Taxa12", taxa.Taxa12);
				db.AdicionarParametros("@Ativo", taxa.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				string query = db.CreateInsertSQL("tblCartaoTaxas");

				//--- insert and Get new ID
				int newID = (int)db.ExecutarInsertAndGetID(query);
				return newID;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCartaoTaxas(objCartaoTaxa taxa)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCartaoTaxa", taxa.IDCartaoTaxa);
				db.AdicionarParametros("@IDCartaoOperadora", taxa.IDCartaoOperadora);
				db.AdicionarParametros("@IDCartaoBandeira", taxa.IDCartaoBandeira);
				db.AdicionarParametros("@PrazoDebito", taxa.PrazoDebito);
				db.AdicionarParametros("@PrazoCredito", taxa.PrazoCredito);
				db.AdicionarParametros("@TaxaDebito", taxa.TaxaDebito);
				db.AdicionarParametros("@TaxaCredito", taxa.TaxaCredito);
				db.AdicionarParametros("@Taxa2", taxa.Taxa2);
				db.AdicionarParametros("@Taxa3", taxa.Taxa3);
				db.AdicionarParametros("@Taxa4", taxa.Taxa4);
				db.AdicionarParametros("@Taxa5", taxa.Taxa5);
				db.AdicionarParametros("@Taxa6", taxa.Taxa6);
				db.AdicionarParametros("@Taxa7", taxa.Taxa7);
				db.AdicionarParametros("@Taxa8", taxa.Taxa8);
				db.AdicionarParametros("@Taxa9", taxa.Taxa9);
				db.AdicionarParametros("@Taxa10", taxa.Taxa10);
				db.AdicionarParametros("@Taxa11", taxa.Taxa11);
				db.AdicionarParametros("@Taxa12", taxa.Taxa12);
				db.AdicionarParametros("@Ativo", taxa.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateUpdateSQL("tblCartaoTaxas", "@IDCartaoTaxa");

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=============================================================================
		//=============================================================================

		// GET CARTAO OPERADORA
		//------------------------------------------------------------------------------------------------------------
		public List<objCartaoOperadora> GetCartaoOperadora(bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCartaoOperadora";

				// add params
				db.LimparParametros();

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					query += " WHERE Ativa = @Ativa";
				}

				query += " ORDER BY CartaoOperadora";

				List<objCartaoOperadora> listagem = new List<objCartaoOperadora>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objCartaoOperadora operadora = new objCartaoOperadora()
					{
						IDCartaoOperadora = (int)row["IDCartaoOperadora"],
						CartaoOperadora = (string)row["CartaoOperadora"],
						IDConta = (int)row["IDConta"],
						Conta = (string)row["Conta"],
						Ativa = (bool)row["Ativa"],
					};

					listagem.Add(operadora);
				}

				return listagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET CARTAO BANDEIRAS
		//------------------------------------------------------------------------------------------------------------
		public List<objCartaoBandeira> GetCartaoBandeiras(bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblCartaoBandeira";

				// add params
				db.LimparParametros();

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					query += " WHERE Ativa = @Ativa";
				}

				query += " ORDER BY CartaoBandeira";

				List<objCartaoBandeira> listagem = new List<objCartaoBandeira>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objCartaoBandeira bandeira = new objCartaoBandeira()
					{
						IDCartaoBandeira = (int)row["IDCartaoBandeira"],
						CartaoBandeira = (string)row["CartaoBandeira"],
						Ativa = (bool)row["Ativa"],
					};

					listagem.Add(bandeira);
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
