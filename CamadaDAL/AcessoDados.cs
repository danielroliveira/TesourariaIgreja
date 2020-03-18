using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDAL
{
    public class AcessoDados
    {
        //-------------------------------------------------------------------------------------------------------
        // DECLARAÇÃO DAS VARIÁVEIS
        //-------------------------------------------------------------------------------------------------------
        SqlConnection conn;
        SqlCommand cmd;
        private SqlTransaction trans;
        public List<SqlParameter> ParamList = new List<SqlParameter>();

        // ==============================================================================
        #region CONEXAO

        // NEW CONSTRUCTOR
        //-------------------------------------------------------------------------------------------------
        public AcessoDados()
        {
            if (!Connect())
            {
                return;
            }
        }

        // GET CONNECTION STRING
        //------------------------------------------------------------------------------------------------------------
        public string GetConnectionString()
        {
            string retorno = string.Empty;

            try
            {
                string connFile = ConfigurationManager.AppSettings["ConexaoStringFile"];
                string connName = ConfigurationManager.AppSettings["ConexaoStringName"];
                GetConnection getConn = new GetConnection();

                retorno = getConn.LoadConnectionString(connFile, connName);

                if (string.IsNullOrEmpty(retorno.Trim()))
                {
                    throw new Exception("Arquivo de Conexão Database inválido...");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            /*
            //--- verifica se há retorno da |DataDirectory|
            //--- substitui o |DataDirectory| pelo "CamadaDAL\Dados"
            If retorno.Contains("|DataDirectory|") Then
            Dim BaseDir As String = AppDomain.CurrentDomain.BaseDirectory

            Dim findI As Integer

            findI = BaseDir.IndexOf("\", 0)
            findI = BaseDir.IndexOf("\", findI + 1)
            findI = BaseDir.IndexOf("\", findI + 1)

            BaseDir = BaseDir.Substring(0, findI) + "\CamadaDAL"

            retorno = retorno.Replace("|DataDirectory|", BaseDir)

            End If 
            */

            return retorno;

        }

        // OPEN CONNECTION
        private bool Connect()
        {
            string connstr = "";
            bool bln = false;

            if (conn == null)
            {
                try
                {
                    connstr = GetConnectionString();

                    if (connstr != string.Empty)
                    {
                        conn = new SqlConnection(connstr);
                        bln = true;
                    }
                    else
                    {
                        bln = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return bln;

        }

        // CLOSE CONNECTION
        public void CloseConn()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        // CLEAR PARAMETERS
        public void LimparParametros()
        {
            ParamList.Clear();
        }

        // ADD PARAMETERS
        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            ParamList.Add(new SqlParameter(nomeParametro, valorParametro));
        }
               
        #endregion

        // ==============================================================================
        #region DATABASE CRUD COMMANDS

        // EXECUTAR MANIPULACAO
        public void ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTextoSQL)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    // try connect
                    Connect();
                    // Check Again
                    if (conn.State == ConnectionState.Closed)
                        throw new Exception("Sem conexão ao Database...");
                }

                cmd = new SqlConnection().CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = commandType;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = nomeStoredProcedureOuTextoSQL;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                 cmd.CommandTimeout = 7200;

                ParamList.ForEach(p => cmd.Parameters.Add(p));

                if (!isTran)
                {
                    cmd.ExecuteScalar();
                    CloseConn();
                }
                else
                {
                    cmd.Transaction = trans;
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcedureOuTextoSQL)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    // try connect
                    Connect();
                    // Check Again
                    if (conn.State == ConnectionState.Closed)
                        throw new Exception("Sem conexão ao Database...");
                }

                cmd = new SqlConnection().CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = commandType;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = nomeStoredProcedureOuTextoSQL;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandTimeout = 7200;

                if (isTran) cmd.Transaction = trans;

                ParamList.ForEach(p => cmd.Parameters.Add(p));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (!isTran) CloseConn();

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        // ==============================================================================
        #region TRANSACTION

        // BEGIN TRANSACTION
        public void BeginTransaction()
        {
            if (isTran) return;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            trans = conn.BeginTransaction();
            isTran = true;

        }

        // COMMIT TRANSACTION
        public void CommitTransaction()
        {
            if (!isTran) return;
            trans.Commit();
            conn.Close();
            trans = null;
            isTran = false;
        }

        // ROOLBACK TRANSACTION
        public void RollBackTransaction()
        {
            if (!isTran) return;
            trans.Rollback();
            conn.Close();
            trans = null;
            isTran = false;
        }

        // PROPERTY ISTRAN
        public bool isTran { get; set; } = false;

        #endregion

    }
}
