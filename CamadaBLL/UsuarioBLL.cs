using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class UsuarioBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objUsuario> GetListUsuario(string usuarioApelido = "", bool? Ativo = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblUsuario WHERE UsuarioAcesso <> 0 ";

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(usuarioApelido))
				{
					db.AdicionarParametros("@UsuarioApelido", usuarioApelido);
					query += " AND UsuarioApelido LIKE '%'+@UsuarioApelido+'%' ";
				}

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					query += " AND UsuarioAtivo = @Ativo";
				}

				query += " ORDER BY UsuarioApelido";

				List<objUsuario> listagem = new List<objUsuario>();
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

		// GET USUARIO
		//------------------------------------------------------------------------------------------------------------
		public objUsuario GetUsuario(int IDUsuario)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblUsuario WHERE IDUsuario = @IDUsuario";
				db.LimparParametros();
				db.AdicionarParametros("@IDUsuario", IDUsuario);

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
		public objUsuario ConvertRowInClass(DataRow row)
		{
			objUsuario usuario = new objUsuario((int)row["IDUsuario"])
			{ };

			usuario.UsuarioApelido = (string)row["UsuarioApelido"];
			usuario.UsuarioAcesso = row["UsuarioAcesso"] == DBNull.Value ? (byte)0 : (byte)row["UsuarioAcesso"];
			usuario.UsuarioAtivo = (bool)row["UsuarioAtivo"];
			usuario.Email = row["Email"] == DBNull.Value ? string.Empty : (string)row["Email"];

			return usuario;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertUsuario(objUsuario usuario)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@UsuarioApelido", usuario.UsuarioApelido);
				db.AdicionarParametros("@UsuarioAcesso", usuario.UsuarioAcesso);
				db.AdicionarParametros("@UsuarioSenha", usuario.UsuarioSenha);
				db.AdicionarParametros("@Email", usuario.Email);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblUsuario");

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
		public bool UpdateUsuario(objUsuario usuario)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- create query
				string query = "UPDATE tblUsuario SET " +
							   "UsuarioApelido = @UsuarioApelido, " +
							   "UsuarioAcesso = @UsuarioAcesso, " +
							   "UsuarioAtivo = @UsuarioAtivo, " +
							   "Email = @Email";

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDUsuario", usuario.IDUsuario);
				db.AdicionarParametros("@UsuarioApelido", usuario.UsuarioApelido);
				db.AdicionarParametros("@UsuarioAcesso", usuario.UsuarioAcesso);
				db.AdicionarParametros("@UsuarioAtivo", usuario.UsuarioAtivo);
				db.AdicionarParametros("@Email", usuario.Email);

				if (!string.IsNullOrEmpty(usuario.UsuarioSenha))
				{
					db.AdicionarParametros("@UsuarioSenha", usuario.UsuarioSenha);
					query += ", UsuarioSenha = @UsuarioSenha";
				}

				query += " WHERE IDUsuario = @IDUsuario";

				//--- convert null parameters
				db.ConvertNullParams();

				//--- update
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONFIRM PASSWORD OF USER
		//------------------------------------------------------------------------------------------------------------
		public bool ConfirmPassword(objUsuario User, string Password)
		{
			try
			{
				AcessoControlBLL acesso = new AcessoControlBLL();

				objUsuario returnedUser = acesso.GetAuthorization(
					User.UsuarioApelido,
					Password,
					(EnumAcessoTipo)User.UsuarioAcesso,
					"Confirmar Password");

				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=================================================================================================
		// USER ACCESS PERMISSION
		//=================================================================================================

		// GET USER ACCESS CONTA LIST
		//------------------------------------------------------------------------------------------------------------
		public List<objUsuarioConta> GetUserPermitedContaList(int IDUsuario)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryUserConta WHERE IDUsuario = @IDUsuario ORDER BY Conta";

				// add params
				db.LimparParametros();
				db.AdicionarParametros("@IDUsuario", IDUsuario);

				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				List<objUsuarioConta> listagem = new List<objUsuarioConta>();

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					listagem.Add(ConvertRowInClassUserConta(row));
				}

				return listagem;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objUsuarioConta ConvertRowInClassUserConta(DataRow row)
		{
			objUsuarioConta usuario = new objUsuarioConta((int)row["IDUsuario"], (int)row["IDConta"])
			{
				IDUserConta = (int)row["IDUserConta"],
				UsuarioApelido = (string)row["UsuarioApelido"],
				Conta = (string)row["Conta"],
				LiberacaoData = row["LiberacaoData"] == DBNull.Value ? new DateTime() : (DateTime)row["LiberacaoData"],
				Ativo = (bool)row["Ativo"],
			};

			return usuario;
		}

		// ADD USER PERMISSION CONTA
		//------------------------------------------------------------------------------------------------------------
		public int InsertUserPermissionConta(objUsuarioConta usuarioConta)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDUsuario", usuarioConta.IDUsuario);
				db.AdicionarParametros("@IDConta", usuarioConta.IDConta);
				db.AdicionarParametros("@LiberacaoData", DateTime.Today);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "INSERT INTO tblUserConta (" +
							   "IDUsuario, " +
							   "IDConta, " +
							   "LiberacaoData " +
							   ") VALUES (" +
							   "@IDUsuario, " +
							   "@IDConta, " +
							   "@LiberacaoData)";
				//--- insert
				return (int)db.ExecutarInsertAndGetID(query);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE / REMOVE USER CONTA ACCESS
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteUserPermissionConta(int IDUserConta)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDUserConta", IDUserConta);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = "DELETE tblUserConta WHERE " +
							   "IDUserConta = @IDUserConta";
				//--- insert
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
