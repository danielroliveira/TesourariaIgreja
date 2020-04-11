using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDTO;
using CamadaDAL;

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

				string query = "SELECT * FROM tblUsuario";
				bool haveWhere = false;

				// add params
				db.LimparParametros();

				if (!string.IsNullOrEmpty(usuarioApelido))
				{
					db.AdicionarParametros("@UsuarioApelido", usuarioApelido);
					query += " WHERE UsuarioApelido LIKE '%'+@UsuarioApelido+'%' ";
					haveWhere = true;
				}

				if (Ativo != null)
				{
					db.AdicionarParametros("@Ativo", Ativo);
					if (haveWhere)
						query += " AND UsuarioAtivo = @Ativo";
					else
						query += " WHERE UsuarioAtivo = @Ativo";
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

		// GET CONGREGACAO
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
			usuario.Email = row["UsuarioAcesso"] == DBNull.Value ? "" : (string)row["Email"];

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
				string query = "INSERT INTO tblUsuario (" +
							   "UsuarioApelido, " +
							   "UsuarioAcesso, " +
							   "UsuarioSenha, " +
							   "Email" +
							   ") VALUES (" +
							   "@UsuarioApelido, " +
							   "@UsuarioAcesso, " +
							   "@UsuarioSenha, " +
							   "@Email)";
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
	}
}
