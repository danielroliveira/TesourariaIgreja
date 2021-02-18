using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	//=================================================================================================
	// USUARIO
	//=================================================================================================
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

	//=================================================================================================
	// USUARIO MENSAGEM BLL
	//=================================================================================================
	public class MensagemBLL
	{
		// GET MENSAGEM BY ID RECURSIVE
		//------------------------------------------------------------------------------------------------------------
		public objMensagem GetMensagemByID(int IDMensagem, object dbTran)
		{
			try
			{
				AcessoDados db = (AcessoDados)dbTran;

				// define paramns
				db.LimparParametros();
				db.AdicionarParametros("@IDMensagem", IDMensagem);

				// define query
				string query = "SELECT * FROM qryUsuarioMensagem " +
					"WHERE IDMensagem = @IDMensagem";

				var mensagem = new objMensagem();

				// execute query
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					mensagem = ConvertRowInClass(dt.Rows[0]);

					if (mensagem.IDOrigem != null)
					{
						mensagem.MensagemOrigem = GetMensagemByID((int)mensagem.IDOrigem, db);
					}
				}

				return mensagem;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET MESSAGES RELATED AND RETURN A LIST OF OBJ MENSAGEM
		//------------------------------------------------------------------------------------------------------------
		public List<objMensagem> GetListMensagensRelacionadas(int IDMensagem)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				objMensagem mensagem = GetMensagemByID(IDMensagem, db);

				List<objMensagem> list = new List<objMensagem>();

				while (mensagem.MensagemOrigem != null)
				{
					list.Add(mensagem.MensagemOrigem);

					mensagem = mensagem.MensagemOrigem;
				}

				db.CommitTransaction();
				return list;

			}
			catch (Exception ex)
			{
				db.RollBackTransaction();
				throw ex;
			}
		}

		// OBTER MENSAGENS RECEBIDAS PELO DESTINATARIO
		//------------------------------------------------------------------------------------------------------------
		public List<objMensagem> Recebidas(int IDUsuarioDestino, bool? MensagemRecebidas = null, object dbTran = null)
		{
			try
			{
				// new acessso dados
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				// define query
				string query = "SELECT * FROM qryUsuarioMensagem " +
					"WHERE IDUsuarioDestino = @IDUsuarioDestino ";

				// define paramns
				db.LimparParametros();
				db.AdicionarParametros("@IDUsuarioDestino", IDUsuarioDestino);

				if (MensagemRecebidas != null)
				{
					db.AdicionarParametros("@Recebida", MensagemRecebidas);
					query += "AND Recebida = @Recebida";
				}

				query += " ORDER BY Recebida";

				var mensagens = new List<objMensagem>();

				// execute query
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow row in dt.Rows)
					{
						mensagens.Add(ConvertRowInClass(row));
					}
				}

				return mensagens;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// OBTER MENSAGENS ENVIADAS PELA ORIGEM
		//------------------------------------------------------------------------------------------------------------
		public List<objMensagem> Enviadas(int IDUsuarioOrigem, bool MensagemRecebidas = false, object dbTran = null)
		{
			try
			{
				// new acessso dados
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				// define paramns
				db.LimparParametros();
				db.AdicionarParametros("@IDUsuarioOrigem", IDUsuarioOrigem);
				db.AdicionarParametros("@Recebida", MensagemRecebidas);

				// define query
				string query = "SELECT * FROM qryUsuarioMensagem " +
					"WHERE IDUsuarioOrigem = @IDUsuarioOrigem " +
					"AND Recebida = @Recebida";

				var mensagens = new List<objMensagem>();

				// execute query
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow row in dt.Rows)
					{
						mensagens.Add(ConvertRowInClass(row));
					}
				}

				return mensagens;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// CONVERT ROW IN CLASS
		//------------------------------------------------------------------------------------------------------------
		public objMensagem ConvertRowInClass(DataRow row)
		{
			objMensagem mensagem = new objMensagem()
			{
				IDMensagem = (int)row["IDMensagem"],
				IDUsuarioDestino = (int)row["IDUsuarioDestino"],
				UsuarioDestino = (string)row["UsuarioDestino"],
				IDUsuarioOrigem = (int)row["IDUsuarioOrigem"],
				UsuarioOrigem = (string)row["UsuarioOrigem"],
				Recebida = (bool)row["Recebida"],
				Suporte = (bool)row["Suporte"],
				IsResposta = (bool)row["IsResposta"],
				Mensagem = (string)row["Mensagem"],
				MensagemData = (DateTime)row["MensagemData"],
				RecebidaData = row["RecebidaData"] == DBNull.Value ? null : (DateTime?)row["RecebidaData"],
				IDOrigem = row["IDOrigem"] == DBNull.Value ? null : (int?)row["IDOrigem"],
			};

			return mensagem;
		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertMensagem(objMensagem mensagem, object dbTran = null)
		{
			AcessoDados db = null;

			try
			{
				db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDUsuarioDestino", mensagem.IDUsuarioDestino);
				db.AdicionarParametros("@IDUsuarioOrigem", mensagem.IDUsuarioOrigem);
				db.AdicionarParametros("@Suporte", mensagem.Suporte);
				db.AdicionarParametros("@IsResposta", mensagem.IsResposta);
				db.AdicionarParametros("@Mensagem", mensagem.Mensagem);
				db.AdicionarParametros("@MensagemData", mensagem.MensagemData);

				//--- convert null parameters
				db.ConvertNullParams();

				//--- create query
				string query = db.CreateInsertSQL("tblUsuarioMensagem");

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
		public bool UpdateMensagem(objMensagem mensagem)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDMensagem", mensagem.IDMensagem);
				db.AdicionarParametros("@IDUsuarioDestino", mensagem.IDUsuarioDestino);
				db.AdicionarParametros("@IDUsuarioOrigem", mensagem.IDUsuarioOrigem);
				db.AdicionarParametros("@Suporte", mensagem.Suporte);
				db.AdicionarParametros("@IsResposta", mensagem.IsResposta);
				db.AdicionarParametros("@Mensagem", mensagem.Mensagem);
				db.AdicionarParametros("@MensagemData", mensagem.MensagemData);
				db.AdicionarParametros("@Recebida", mensagem.Recebida);
				db.AdicionarParametros("@RecebidaData", mensagem.RecebidaData);

				//--- convert null parameters
				db.ConvertNullParams();

				////--- create query
				string query = db.CreateUpdateSQL("tblUsuarioMensagem", "IDMensagem");

				//--- UPDATE
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// REMOVE DELETE MESSAGE
		//------------------------------------------------------------------------------------------------------------
		public bool DeleteMensagem(int IDMensagem)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@IDMensagem", IDMensagem);

				//--- convert null parameters
				db.ConvertNullParams();

				////--- create query
				string query = "DELETE tblUsuarioMensagem WHERE IDMensagem = @IDMensagem";

				//--- DELETE
				db.ExecutarManipulacao(CommandType.Text, query);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// SEND MESSAGE TO ALL ACTIVE USERS
		//------------------------------------------------------------------------------------------------------------
		public int SendToAllActiveUsers(objMensagem mensagem)
		{
			AcessoDados db = null;

			try
			{
				db = new AcessoDados();
				db.BeginTransaction();

				//--- get users list
				List<objUsuario> listUser = new UsuarioBLL().GetListUsuario("", true);

				foreach (var user in listUser)
				{
					//--- check if user is the sender user
					if (user.IDUsuario == mensagem.IDUsuarioOrigem)
					{
						continue;
					}

					//--- crete new message
					var newMensage = new objMensagem()
					{
						IDUsuarioDestino = (int)user.IDUsuario,
						IDUsuarioOrigem = mensagem.IDUsuarioOrigem,
						IsResposta = false,
						IDMensagem = null,
						IDOrigem = null,
						Mensagem = mensagem.Mensagem,
						MensagemData = mensagem.MensagemData,
						MensagemOrigem = null,
						Recebida = false,
						RecebidaData = null,
						Suporte = false,
						UsuarioOrigem = mensagem.UsuarioOrigem,
						UsuarioDestino = user.UsuarioApelido
					};

					//--- insert new message
					InsertMensagem(newMensage);
				}

				//--- COMMIT
				db.CommitTransaction();

				//--- RETURN WITH NUMBER OF SENDED MESSAGES
				return listUser.Count;
			}
			catch (Exception ex)
			{
				//--- ROOLBACK
				db.RollBackTransaction();
				throw ex;
			}
		}

		// CHECK FOR NEW USER MESSAGES
		//------------------------------------------------------------------------------------------------------------
		public int UserHasNewMessage(int IDUser, object dbTran = null)
		{
			try
			{
				// new acessso dados
				AcessoDados db = dbTran == null ? new AcessoDados() : (AcessoDados)dbTran;

				// define query
				string query = "SELECT COUNT(*) AS TOTAL FROM qryUsuarioMensagem " +
					"WHERE IDUsuarioDestino = @IDUser AND Recebida = 'False'";

				// define paramns
				db.LimparParametros();
				db.AdicionarParametros("@IDUser", IDUser);

				// execute query
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);
				int MensagensTotal = 0;

				if (dt.Rows.Count > 0)
				{
					MensagensTotal = (int)dt.Rows[0][0];
				}

				return MensagensTotal;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
