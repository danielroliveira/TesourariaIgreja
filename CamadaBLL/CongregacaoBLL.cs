using System;
using System.Collections.Generic;
using System.Data;
using CamadaDAL;
using CamadaDTO;

namespace CamadaBLL
{
	class CongregacaoBLL
	{
		// GET LIST OF
		//------------------------------------------------------------------------------------------------------------
		public List<objCongregacao> GetListCongregacao(bool? Ativas = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCongregacao";

				if (!Ativas == null)
				{
					db.LimparParametros();
					db.AdicionarParametros("@Ativos", Ativas);
					query += " WHERE Ativo = @Ativo";
				}

				query += " ORDER BY Congregacao";

				List<objCongregacao> listagem = new List<objCongregacao>();
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
		public objCongregacao GetCongregacao(int IDCongregacao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM qryCongregacao WHERE IDCongregacao = @IDCongregacao";
				db.LimparParametros();
				db.AdicionarParametros("@IDCongregacao", IDCongregacao);

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
		public objCongregacao ConvertRowInClass(DataRow row)
		{
			objCongregacao congregacao = new objCongregacao((int)row["IDCongregacao"])
			{
				Congregacao = (string)row["Congregacao"],
				EnderecoLogradouro = row["EnderecoLogradouro"] == DBNull.Value ? "" : (string)row["EnderecoLogradouro"],
				EnderecoComplemento = row["EnderecoComplemento"] == DBNull.Value ? "" : (string)row["EnderecoComplemento"],
				EnderecoNumero = row["EnderecoNumero"] == DBNull.Value ? "" : (string)row["EnderecoNumero"],
				Bairro = row["Bairro"] == DBNull.Value ? "" : (string)row["Bairro"],
				Cidade = row["Cidade"] == DBNull.Value ? "" : (string)row["Cidade"],
				UF = row["UF"] == DBNull.Value ? "" : (string)row["UF"],
				CEP = row["CEP"] == DBNull.Value ? "" : (string)row["CEP"],
				TelefoneDirigente = row["TelefoneDirigente"] == DBNull.Value ? "" : (string)row["TelefoneDirigente"],
				TelefoneFixo = row["TelefoneFixo"] == DBNull.Value ? "" : (string)row["TelefoneFixo"],
				Dirigente = row["Dirigente"] == DBNull.Value ? "" : (string)row["Dirigente"],
				Tesoureiro = row["Tesoureiro"] == DBNull.Value ? "" : (string)row["Tesoureiro"],
				Ativo = (bool)row["Ativo"],
				IDCongregacaoSetor = row["IDCongregacaoSetor"] == DBNull.Value ? null : (int?)row["IDCongregacaoSetor"],
				CongregacaoSetor = row["CongregacaoSetor"] == DBNull.Value ? "" : (string)row["CongregacaoSetor"]
			};

			return congregacao;

		}

		// INSERT
		//------------------------------------------------------------------------------------------------------------
		public int InsertCongregacao(objCongregacao congregacao)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				//--- clear Params
				db.LimparParametros();

				//--- define Params
				db.AdicionarParametros("@Congregacao", congregacao.Congregacao);
				db.AdicionarParametros("@EnderecoLogradouro", congregacao.EnderecoLogradouro);
				db.AdicionarParametros("@EnderecoNumero", congregacao.EnderecoNumero);
				db.AdicionarParametros("@EnderecoComplemento", congregacao.EnderecoComplemento);
				db.AdicionarParametros("@Bairro", congregacao.Bairro);
				db.AdicionarParametros("@Cidade", congregacao.Cidade);
				db.AdicionarParametros("@UF", congregacao.UF);
				db.AdicionarParametros("@CEP", congregacao.CEP);
				db.AdicionarParametros("@TelefoneDirigente", congregacao.TelefoneDirigente);
				db.AdicionarParametros("@TelefoneFixo", congregacao.TelefoneFixo);
				db.AdicionarParametros("@Dirigente", congregacao.Dirigente);
				db.AdicionarParametros("@IDCongregacaoSetor", congregacao.IDCongregacaoSetor == null ? DBNull.Value : congregacao.IDCongregacaoSetor as object);
				db.AdicionarParametros("@Tesoureiro", congregacao.Tesoureiro);
				db.AdicionarParametros("@Ativo", congregacao.Ativo);

				//--- create query
				string query = "INSERT INTO tblCongregacao (" +
							   "Congregacao, EnderecoLogradouro, EnderecoNumero, EnderecoComplemento, " +
							   "Bairro, Cidade, UF, CEP, Dirigente, TelefoneDirigente, TelefoneFixo, " +
							   "IDCongregacaoSetor, Tesoureiro " +
							   ") VALUES (" +
							   "@Congregacao, @EnderecoLogradouro, @EnderecoNumero, @EnderecoComplemento, " +
							   "@Bairro, @Cidade, @UF, @CEP, @Dirigente, @TelefoneDirigente, @TelefoneFixo, " +
							   "@IDCongregacaoSetor, @Tesoureiro)";
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
		public bool UpdateCongregacao(objCongregacao congregacao)
		{
			return true;
		}
	}
}
