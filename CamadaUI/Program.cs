using CamadaBLL;
using CamadaDTO;
using System;
using System.Windows.Forms;

namespace CamadaUI
{
	static class Program
	{
		public static objUsuario usuarioAtual;

		/// <summary>
		/// The Main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);


			//--- Check Server Access
			if (!CheckServerAccess())
			{
				Application.Exit();
				return;
			}

			Application.Run(new frmPrincipal());
		}

		//--- VERIFICA SE EXISTE SERVER CONFIG TO GET CONN STRING
		//------------------------------------------------------------------------------------------------------------
		private static bool CheckServerAccess()
		{
			AcessoControlBLL acessoBLL = new AcessoControlBLL();
			string TestAcesso = acessoBLL.GetConnString();

			//--- open FRMCONNSTRING: to define the string de conexao
			if (string.IsNullOrEmpty(TestAcesso))
			{
				Main.frmConnString fcString = new Main.frmConnString();
				fcString.ShowDialog();

				if (fcString.DialogResult != DialogResult.OK)
				{
					return false;
				}

				return true;
			}

			return true;
		}

	}
}
