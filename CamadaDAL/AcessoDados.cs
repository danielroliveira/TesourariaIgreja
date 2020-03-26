﻿using System;
using System.Collections.Generic;
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
        public static string GetConnectionString()
        {
            string retorno;

            try
            {
                //string connFile = ConfigurationManager.AppSettings["ConexaoStringFile"];
                string connFile = Properties.Settings.Default.ConexaoStringFile;

                //string connName = ConfigurationManager.AppSettings["ConexaoStringName"];
                string connName = Properties.Settings.Default.ConexaoStringName;

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

            return retorno;

        }

        // GET CONFIG DB - CONNECTION XML PATH
        //------------------------------------------------------------------------------------------------------------
        public static string GetConfigXMLPath()
        {
            try
            {
                return Properties.Settings.Default.ConexaoStringFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        //------------------------------------------------------------------------------------------------------------
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

        // EXECUTE QUERY RETURN DATATABLE
        //------------------------------------------------------------------------------------------------------------
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

        // EXECUTAR INSERT AND RETURN NEW ID
        //------------------------------------------------------------------------------------------------------------
        public int ExecutarInsertAndGetID(string query)
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
                cmd.CommandType = CommandType.Text;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = query;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandTimeout = 7200;

                ParamList.ForEach(p => cmd.Parameters.Add(p));

                if (!isTran)
                {
                    //--- EXECUTE
                    cmd.ExecuteScalar();

                    //--- GET NEW ID
                    int? obj = GetNewID();

                    //--- CLOSE DB CONNECTION
                    CloseConn();

                    if (obj == null)
                    {
                        throw new Exception("Não foi retornado novo ID...");
                    }
                    
                    //--- RETURN
                    return (int)obj;
                }
                else
                {
                    //--- ADD TRANSACTION TO COMMAND
                    cmd.Transaction = trans;

                    //--- EXECUTE
                    cmd.ExecuteScalar();

                    //--- GET NEW ID
                    int? obj = GetNewID();

                    if (obj == null)
                    {
                        throw new Exception("Não foi retornado novo ID...");
                    }

                    //--- RETURN
                    return (int)obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET NEW ID OF INSERT
        //------------------------------------------------------------------------------------------------------------
        private int? GetNewID()
        {
            //--- obter NewID
            LimparParametros();
            string myQuery = "SELECT @@IDENTITY As LastID";
            DataTable dt = ExecutarConsulta(CommandType.Text, myQuery);
        
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            object newID = dt.Rows[0][0];

            if (int.TryParse(newID.ToString(), out int j))
            {
                return j;
            }
            else
            {
                throw new Exception(newID.ToString());
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
