using System;
using System.Collections.Generic;
using System.Data;
using CamadaDAL;
using CamadaDTO;

namespace CamadaBLL
{
	public class CredorBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objCredor> GetListCredor(string Credor, bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCredor";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(Credor))
				{
					db.AdicionarParametros("@Credor", Credor);
					query += " WHERE Credor LIKE '%'+@Credor+'%' ";
					haveWhere = true;
				}

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					if (haveWhere)
						query += " AND Ativo = @Ativo";
					else
						query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY Credor";

				List<objCredor> listagem = new List<objCredor>();
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

		// GET CONGREGACAO
		//------------------------------------------------------------------------------------------------------------
		public objCredor GetCredor(int IDCredor)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCredor WHERE IDCredor = @IDCredor";
				db.LimparParametros();
				db.AdicionarParametros("@IDCredor", IDCredor);

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
		public objCredor ConvertRowInClass(DataRow row)
		{
			objCredor credor = new objCredor((int)row["IDCredor"])
			{
				Credor = (string)row["Credor"],
				CredorTipo = row["CredorTipo"] == DBNull.Value ? (byte)0 : (byte)row["CredorTipo"],
				CredorTipoDescricao = row["CredorTipoDescricao"] == DBNull.Value ? "" : (string)row["CredorTipoDescricao"],
				CNP = row["CNP"] == DBNull.Value ? "" : (string)row["CNP"],
				EnderecoLogradouro = row["EnderecoLogradouro"] == DBNull.Value ? "" : (string)row["EnderecoLogradouro"],
				EnderecoComplemento = row["EnderecoComplemento"] == DBNull.Value ? "" : (string)row["EnderecoComplemento"],
				EnderecoNumero = row["EnderecoNumero"] == DBNull.Value ? "" : (string)row["EnderecoNumero"],
				Bairro = row["Bairro"] == DBNull.Value ? "" : (string)row["Bairro"],
				Cidade = row["Cidade"] == DBNull.Value ? "" : (string)row["Cidade"],
				UF = row["UF"] == DBNull.Value ? "" : (string)row["UF"],
				CEP = row["CEP"] == DBNull.Value ? "" : (string)row["CEP"],
				TelefoneCelular = row["TelefoneCelular"] == DBNull.Value ? "" : (string)row["TelefoneCelular"],
				TelefoneFixo = row["TelefoneFixo"] == DBNull.Value ? "" : (string)row["TelefoneFixo"],
				Whatsapp = row["Whatsapp"] == DBNull.Value ? false : (bool)row["Whatsapp"],
				Email = row["Email"] == DBNull.Value ? "" : (string)row["Email"],
				Ativo = (bool)row["Ativo"]
			};

			return credor;

		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertCredor(objCredor credor)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Credor", credor.Credor);
				db.AdicionarParametros("@CredorTipo", credor.CredorTipo);
				db.AdicionarParametros("@CNP", credor.CNP);
				db.AdicionarParametros("@EnderecoLogradouro", credor.EnderecoLogradouro);
				db.AdicionarParametros("@EnderecoNumero", credor.EnderecoNumero);
				db.AdicionarParametros("@EnderecoComplemento", credor.EnderecoComplemento);
				db.AdicionarParametros("@Bairro", credor.Bairro);
				db.AdicionarParametros("@Cidade", credor.Cidade);
				db.AdicionarParametros("@UF", credor.UF);
				db.AdicionarParametros("@CEP", credor.CEP);
				db.AdicionarParametros("@TelefoneFixo", credor.TelefoneFixo);
				db.AdicionarParametros("@TelefoneCelular", credor.TelefoneCelular);
				db.AdicionarParametros("@Whatsapp", credor.Whatsapp);
				db.AdicionarParametros("@Email", credor.Email);
				db.AdicionarParametros("@Ativo", credor.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "INSERT INTO tblCredor (" +
							   "Credor, CredorTipo, CNP, EnderecoLogradouro, EnderecoNumero, EnderecoComplemento, " +
							   "Bairro, Cidade, UF, CEP, TelefoneFixo, TelefoneCelular, Email, Whatsapp, Ativo " +
							   ") VALUES (" +
							   "@Credor, @CredorTipo, @CNP, @EnderecoLogradouro, @EnderecoNumero, @EnderecoComplemento, " +
							   "@Bairro, @Cidade, @UF, @CEP, @TelefoneFixo, @TelefoneCelular, @Email, @Whatsapp, @Ativo) ";
				//--- insert
				return db.ExecutarInsertAndGetID(query);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCredor(objCredor credor)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDCredor", credor.IDCredor);
				db.AdicionarParametros("@Credor", credor.Credor);
				db.AdicionarParametros("@CredorTipo", credor.CredorTipo);
				db.AdicionarParametros("@CNP", credor.CNP);
				db.AdicionarParametros("@EnderecoLogradouro", credor.EnderecoLogradouro);
				db.AdicionarParametros("@EnderecoNumero", credor.EnderecoNumero);
				db.AdicionarParametros("@EnderecoComplemento", credor.EnderecoComplemento);
				db.AdicionarParametros("@Bairro", credor.Bairro);
				db.AdicionarParametros("@Cidade", credor.Cidade);
				db.AdicionarParametros("@UF", credor.UF);
				db.AdicionarParametros("@CEP", credor.CEP);
				db.AdicionarParametros("@TelefoneFixo", credor.TelefoneFixo);
				db.AdicionarParametros("@TelefoneCelular", credor.TelefoneCelular);
				db.AdicionarParametros("@Whatsapp", credor.Whatsapp);
				db.AdicionarParametros("@Email", credor.Email);
				db.AdicionarParametros("@Ativo", credor.Ativo);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "UPDATE tblCredor SET " +
							   "Credor = @Credor, " +
							   "CredorTipo = @CredorTipo, " +
							   "CNP = @CNP, " +
							   "EnderecoLogradouro = @EnderecoLogradouro, " +
							   "EnderecoNumero = @EnderecoNumero, " +
							   "EnderecoComplemento = @EnderecoComplemento, " +
							   "Bairro = @Bairro, " +
							   "Cidade = @Cidade, " +
							   "UF = @UF, " +
							   "CEP = @CEP, " +
							   "TelefoneCelular = @TelefoneCelular, " +
							   "TelefoneFixo = @TelefoneFixo, " +
							   "Whatsapp = @Whatsapp, " +
							   "Email = @Email, " +
							   "Ativo = @Ativo, " +
							   "WHERE " +
							   "IDCredor = @IDCredor";
				//--- UPDATE
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
