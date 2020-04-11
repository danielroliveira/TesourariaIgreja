using System;
using System.Data;
using CamadaDAL;
using CamadaDTO;

namespace CamadaBLL
{
	public class AcessoControlBLL
	{
		public int TentativasAcesso { get; set; }

		public AcessoControlBLL()
		{
			TentativasAcesso = 0;
		}

		//=================================================================================================
		// GET NEW LOGIN ACESSO
		//=================================================================================================
		public objUsuario GetAuthorization(
			string UsuarioApelido,
			string UsuarioSenha, EnumAcessoTipo UsuarioAcesso = EnumAcessoTipo.Usuario_Local, // usuario_local = 4
			string AuthDescription = "Acesso Login"
			)
		{
			AcessoDados db = new AcessoDados();

			db.LimparParametros();
			db.AdicionarParametros("@UsuarioApelido", UsuarioApelido);
			db.AdicionarParametros("@UsuarioSenha", UsuarioSenha);
			db.AdicionarParametros("@UsuarioAcesso", UsuarioAcesso);
			db.AdicionarParametros("@AuthDescription", AuthDescription);
			db.AdicionarParametros("@AuthDate", DateTime.Now);

			try
			{
				DataTable dt = db.ExecutarConsulta(CommandType.StoredProcedure, "uspUserGetAuthorization");

				if (dt.Rows.Count == 0)
				{
					TentativasAcesso += 1;
					throw new AppException("Não há Usuários no sistema, comunique com o administrador...");
				}

				DataRow row = dt.Rows[0];

				if (row.ItemArray.Length == 1)
				{
					TentativasAcesso += 1;
					throw new AppException(dt.Rows[0].ItemArray[0].ToString());
				}

				objUsuario UsuarioAtual = new objUsuario((int)row["IDUsuario"])
				{
					UsuarioAcesso = (byte)row["UsuarioAcesso"],
					UsuarioApelido = (string)row["UsuarioApelido"]
				};

				return UsuarioAtual;
			}
			catch (AppException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		//=================================================================================================
		// SAVE STRING CONNECTION
		//=================================================================================================
		public bool SaveConnString(string SourceXMLFile, string stringName)
		{
			try
			{
				GetConnection conn = new GetConnection();
				conn.SaveConnectionStringLocation(SourceXMLFile, stringName);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//=================================================================================================
		// GET STRING CONNECTION TO VISUALIZATION
		//=================================================================================================
		public string GetConnString()
		{
			try
			{
				return AcessoDados.GetConnectionString();
			}
			catch
			{
				return null;
			}
		}

		//=================================================================================================
		// GET ACESSO + TRANSACTION
		//=================================================================================================
		public object GetNewAcessoWithTransaction()
		{
			AcessoDados myDB = new AcessoDados();
			myDB.BeginTransaction();

			//return
			return myDB;
		}

		//=================================================================================================
		// COMMIT ACESSO + TRANSACTION
		//=================================================================================================
		public bool CommitAcessoWithTransaction(object myDB)
		{
			if (myDB.GetType() == typeof(AcessoDados))
			{
				AcessoDados DB = (AcessoDados)myDB;
				DB.CommitTransaction();

				// return
				return true;
			}
			else
			{
				return false;
			}
		}

		//=================================================================================================
		// ROLLBACK ACESSO + TRANSACTION 
		//=================================================================================================
		public bool RollbackAcessoWithTransaction(object myDB)
		{
			if (myDB.GetType() == typeof(AcessoDados))
			{
				AcessoDados DB = (AcessoDados)myDB;
				DB.RollBackTransaction();

				// return
				return true;
			}
			else
			{
				return false;
			}
		}

		//=================================================================================================
		// GET CONFIG DB - CONNECTION XML PATH
		//=================================================================================================
		public string GetConfigXMLPath()
		{
			try
			{
				return AcessoDados.GetConfigXMLPath();
			}
			catch
			{
				return null;
			}
		}
	}
}
