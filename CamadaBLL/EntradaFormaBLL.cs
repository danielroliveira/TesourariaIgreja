using CamadaDAL;
using CamadaDTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CamadaBLL
{
	public class EntradaFormaBLL
	{
		// GET ENTRADA FORMAS
		//------------------------------------------------------------------------------------------------------------
		public List<objEntradaForma> GetEntradaFormasList(bool? Ativa = null)
		{
			try
			{
				AcessoDados db = new AcessoDados();

				string query = "SELECT * FROM tblEntradaForma";

				// add params
				db.LimparParametros();

				if (Ativa != null)
				{
					db.AdicionarParametros("@Ativa", Ativa);
					query += " WHERE Ativa = @Ativa";
				}

				query += " ORDER BY EntradaForma";

				List<objEntradaForma> listagem = new List<objEntradaForma>();
				DataTable dt = db.ExecutarConsulta(CommandType.Text, query);

				if (dt.Rows.Count == 0)
				{
					return listagem;
				}

				foreach (DataRow row in dt.Rows)
				{
					objEntradaForma forma = new objEntradaForma((byte)row["IDEntradaForma"])
					{
						EntradaForma = (string)row["EntradaForma"],
						Ativa = (bool)row["Ativa"],
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
