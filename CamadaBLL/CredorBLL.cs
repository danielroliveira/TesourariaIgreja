﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- check duplicated CREDOR
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();
				db.AdicionarParametros("@Credor", credor.Credor);
				db.ConvertNullParams();

				//--- create and execute query
				string query = "SELECT * FROM tblCredor WHERE Credor = @Credor";
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					throw new AppException("Já existe um Credor cadastrado que possui o mesmo nome...");
				}

				//--- check duplicated CNP
				//------------------------------------------------------------------------------------------------------------
				string CNP = credor.CNP.Replace("/", "").Replace("-", "").Replace(".", "").Trim();

				if (!string.IsNullOrEmpty(CNP))
				{
					db.LimparParametros();
					db.AdicionarParametros("@CNP", credor.CNP);
					db.ConvertNullParams();

					//--- create and execute query
					query = "SELECT * FROM tblCredor WHERE CNP = @CNP";
					dt = db.ExecutarConsulta(CommandType.Text, query);

					if (dt.Rows.Count > 0)
					{
						throw new AppException("Já existe um Credor cadastrado que possui o mesmo CPF...");
					}
				}
				else
				{
					credor.CNP = string.Empty;
				}

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
				query = db.CreateInsertSQL("tblCredor");

				//--- insert
				int newID = (int)db.ExecutarInsertAndGetID(query);

				//--- COMMIT and RETURN
				db.CommitTransaction();
				return newID;
			}
			catch (SqlException ex)
			{
				//--- ROOLBACK
				db.RollBackTransaction();

				if (ex.Number == 2627)
				{
					throw new AppException("Já existe um Credor com o mesmo nome...");
				}
				else
				{
					throw ex;
				}
			}
			catch (Exception ex)
			{
				//--- ROOLBACK
				db.RollBackTransaction(); 
				throw ex;
			}
		}

		// UPDATE
		//------------------------------------------------------------------------------------------------------------
		public bool UpdateCredor(objCredor credor)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- check duplicated CREDOR
				//------------------------------------------------------------------------------------------------------------
				db.LimparParametros();
				db.AdicionarParametros("@Credor", credor.Credor);
				db.AdicionarParametros("@IDCredor", credor.IDCredor);
				db.ConvertNullParams();

				//--- create and execute query
				string query = "SELECT * FROM tblCredor WHERE Credor = @Credor AND IDCredor <> @IDCredor";
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					throw new AppException("Já existe um Credor cadastrado que possui o mesmo nome...");
				}

				//--- check duplicated CNP
				//------------------------------------------------------------------------------------------------------------
				string CNP = credor.CNP.Replace("/", "").Replace("-", "").Replace(".", "").Trim();

				if (!string.IsNullOrEmpty(CNP))
				{
					db.LimparParametros();
					db.AdicionarParametros("@CNP", credor.CNP);
					db.AdicionarParametros("@IDCredor", credor.IDCredor);
					db.ConvertNullParams();

					//--- create and execute query
					query = "SELECT * FROM tblCredor WHERE CNP = @CNP AND IDCredor <> @IDCredor";
					dt = db.ExecutarConsulta(CommandType.Text, query);

					if (dt.Rows.Count > 0)
					{
						throw new AppException("Já existe um Credor cadastrado que possui o mesmo CPF...");
					}
				}
				else
				{
					credor.CNP = string.Empty;
				}

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
				query = db.CreateUpdateSQL("tblCredor", "IDCredor");

				//--- UPDATE
				db.ExecutarManipulacao(CommandType.Text, query);

				//--- COMMIT
				db.CommitTransaction();
				return true;
			}
			catch (Exception ex)
			{
				//--- ROOLBACK
				db.RollBackTransaction();
				throw ex;
			}
		}
	}
}
