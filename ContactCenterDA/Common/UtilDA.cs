using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ContactCenterCommon;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace ContactCenterDA.Common
{
    static class UtilDA
    {
        
        /// <summary>
        /// Metodo de extension para obtener la cadena de conexión.
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private static String GetConexion(this OleDbConnection con)
        {
            //string ruta = System.IO.Directory.GetCurrentDirectory();
            //if (ruta.Contains("TestResults"))
            //{
            //    int since = ruta.LastIndexOf("TestResults");
            //    ruta = ruta.Substring(0, since) + "ContactCenterDA";
            //}

            //if (ruta.Contains("ContactCenterGUI\\bin\\Debug"))
            //    ruta = ruta.Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA");

            //if(ruta.Contains("ContactCenterUnitTest\\bin\\Debug"))
            //    ruta = ruta.Replace("ContactCenterUnitTest\\bin\\Debug", "ContactCenterDA");

            //string ip = @"\\DESKTOP-IP4QSRA\ContactCenterBD\ContactCenter.accdb"; 
            //string strCnx =
            //    "Provider = Microsoft.ACE.OLEDB.12.0; Data Source="+ ip + "; Persist Security Info = True;";
            string strCnx = ConfigurationManager.ConnectionStrings["Teatros"].ConnectionString;
#if DEBUG
            if (strCnx.Contains("reemplazame"))
            {
                strCnx = strCnx.Replace("reemplazame", System.IO.Directory.GetCurrentDirectory().Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA"));
            }
#endif

            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }

        /// <summary>
        /// Devuelve un objeto OleDbParameter con los parametros establecidos
        /// </summary>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="type">Tipo del parametro</param>
        /// <param name="value">Valor del parametro</param>
        /// <param name="parameterDirection">Direccion del parametro</param>
        /// <returns></returns>
        public static OleDbParameter SetParameters(string name, OleDbType type, object value, ParameterDirection parameterDirection)
        {
            OleDbParameter parameter = new OleDbParameter(name, type);
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            return parameter;
        }

        /// <summary>
        /// Devuelve un objeto OleDbParameter con los parametros establecidos
        /// </summary>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="type">Tipo del parametro</param>
        /// <param name="value">Valor del parametro</param>
        /// <returns></returns>
        public static OleDbParameter SetParameters(string name, OleDbType type, object value)
        {
            OleDbParameter parameter = new OleDbParameter(name, type);
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// Guarda el log en la tabla CC_LOG_ERROR
        /// </summary>
        /// <param name="oleDbException">Exception lanzada</param>
        /// <param name="sql">Cadena sql que genero el error</param>
        /// <param name="parameters">Parametros enviados en la cadena SQL</param>
        private static void SaveLog(Exception oleDbException, string sql, params OleDbParameter[] parameters)
        {
            string concatParameters = string.Join(" , ",
                          parameters.Select(x => x.ParameterName + " : " + x.Value + "(" + x.OleDbType + ")").ToArray());

            OleDbConnection cnx = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            string sqlLog = "INSERT INTO CC_LOG_ERROR(IdAplicacion, SQLQuery, Parametros, UserCrea, FechaCrea, MsgException) " +
                            " VALUES (@IdAplicacion,@SQL,@Parametros,@UserCrea,@FechaCrea,@Exception)";

            OleDbParameter IdAplicacion = SetParameters("@IdAplicacion", OleDbType.Integer, Sesion.aplicacion == null ? 0 : Sesion.aplicacion.IdAplicacion );
            OleDbParameter sqlOrigen = SetParameters("@SQL", OleDbType.VarChar, sql);
            OleDbParameter Params = SetParameters("@Parametros", OleDbType.VarChar, concatParameters);
            OleDbParameter UserCrea = SetParameters("@UserCrea", OleDbType.VarChar, Sesion.usuario == null ? "anonymous" : Sesion.usuario.Login );
            OleDbParameter FechaCrea = SetParameters("@FechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter Exception = SetParameters("@Exception", OleDbType.VarChar, oleDbException.Message);
            ExecuteNonQueryLog(cmd, CommandType.Text, sqlLog, cnx, IdAplicacion, sqlOrigen, Params, UserCrea,FechaCrea, Exception);

        }

        /// <summary>
        /// Ejecuta una sentencia SQL en la base de datos
        /// </summary>
        /// <param name="oleDbCommand">Objeto Command</param>
        /// <param name="commandType">Tipo de commando</param>
        /// <param name="sql">Cadena SQL a ejecutar</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        /// <param name="transaction">Si debe ser tratado como transacción</param>
        /// <param name="parameters">Lista de parametros</param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, bool transaction, params OleDbParameter[] parameters)
        {
            try
            {
                if (!transaction)
                {
                    oleDbCommand.Connection = oleDbConnection;
                    oleDbConnection.ConnectionString = oleDbConnection.GetConexion();
                }

                oleDbCommand.Parameters.Clear();
                foreach (OleDbParameter parameter in parameters)
                {
                    oleDbCommand.Parameters.Add(parameter);
                }

                oleDbCommand.CommandType = commandType;
                oleDbCommand.CommandText = sql;
                if (!transaction)
                {
                    oleDbConnection.Open();
                }
                oleDbCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                SaveLog(ex, sql, parameters);
                return false;
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open && !transaction)
                {
                    oleDbConnection.Close();
                }
            }
        }
        
        /// <summary>
        /// Comienza una transaccion en la BD
        /// </summary>
        /// <param name="oleDbCommand">Objeto Command</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        public static void ExecuteBeginTransaction(OleDbCommand oleDbCommand, OleDbConnection oleDbConnection)
        {
            try
            {
                oleDbCommand.Connection = oleDbConnection;
                oleDbConnection.ConnectionString = oleDbConnection.GetConexion();
                oleDbCommand.Parameters.Clear();
                oleDbConnection.Open();
                oleDbCommand.CommandText = "BEGIN TRANSACTION";
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SaveLog(ex, "BEGIN TRANSACTION", null);
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Devuelve el ID autogenerado del ultimo objeto insertado en la BD
        /// </summary>
        /// <param name="oleDbCommand">Objeto Command</param>
        /// <param name="commandType">Tipo de comando</param>
        /// <param name="sql">Cadena SQL de inserción</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        /// <param name="transaction">Si debe ser tratado como transacción</param>
        /// <param name="parameters">Lista de parametros</param>
        /// <returns></returns>
        public static int ExecuteNonQueryGetId(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, bool transaction, params OleDbParameter[] parameters)
        {
            try
            {
                if (!transaction)
                {
                    oleDbCommand.Connection = oleDbConnection;
                    oleDbConnection.ConnectionString = oleDbConnection.GetConexion();
                }
                oleDbCommand.Parameters.Clear();

                foreach (OleDbParameter parameter in parameters)
                {
                    oleDbCommand.Parameters.Add(parameter);
                }

                oleDbCommand.CommandType = commandType;
                if (!transaction)
                {
                    oleDbConnection.Open();
                }
             
                oleDbCommand.CommandText = sql;
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "SELECT @@Identity";
                int id = (int)oleDbCommand.ExecuteScalar();
                return id;

            }
            catch (Exception ex)
            {
                oleDbCommand.CommandText = "ROLLBACK";
                oleDbCommand.ExecuteNonQuery();
                SaveLog(ex, sql, parameters);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open && !transaction)
                {
                    oleDbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Commit al lote de ejecución actual
        /// </summary>
        /// <param name="oleDbCommand">Objeto Comando</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        public static void ExecuteCommit(OleDbCommand oleDbCommand,OleDbConnection oleDbConnection)
        {
            try
            {
                oleDbCommand.CommandText = "COMMIT";
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SaveLog(ex, "COMMIT", null);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close();
                }
            }

        }

        /// <summary>
        /// Realiza el rollback de el lote de instrucciones actual
        /// </summary>
        /// <param name="oleDbCommand">Objeto Comando</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        public static void ExecuteRollback(OleDbCommand oleDbCommand,OleDbConnection oleDbConnection)
        {
            try
            {
                oleDbCommand.CommandText = "ROLLBACK";
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SaveLog(ex, "ROLLBACK", null);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Ejecuta dos instrucciones SQL, si el SQLValidador devuelve alguna fila, no se ejecutara el SQLEjecución
        /// </summary>
        /// <param name="oleDbCommand">Objeto Comando</param>
        /// <param name="commandType">Tipo de comando</param>
        /// <param name="sqlValidador">SQL con validación</param>
        /// <param name="sqlEjecucion">SQL a ejecutar de pasar la validación</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        /// <param name="transaction">Si debe ser tratado como transacción</param>
        /// <param name="parameters">Listado de parametros</param>
        /// <returns></returns>
        public static bool ExecuteQueryValidador(OleDbCommand oleDbCommand, CommandType commandType, String sqlValidador, String sqlEjecucion, OleDbConnection oleDbConnection, bool transaction, params OleDbParameter[] parameters)
        {
            try
            {
                if (!transaction)
                {
                    oleDbCommand = new OleDbCommand();
                    oleDbConnection = new OleDbConnection();
                    oleDbCommand.Connection = oleDbConnection;
                    oleDbConnection.ConnectionString = oleDbConnection.GetConexion();
                }
                oleDbCommand.Parameters.Clear();

                foreach (OleDbParameter parameter in parameters)
                {
                    oleDbCommand.Parameters.Add(parameter);
                }

                oleDbCommand.CommandType = commandType;
                if (!transaction)
                {
                    oleDbConnection.Open();
                }
                oleDbCommand.CommandText = sqlValidador;
                OleDbDataReader dtr = oleDbCommand.ExecuteReader();
                if (!dtr.HasRows)
                {
                    dtr.Close();
                    oleDbCommand.CommandText = sqlEjecucion;
                    oleDbCommand.ExecuteNonQuery();
                    return true;
                }
                dtr.Close();
                return false;

            }
            catch (Exception ex)
            {
                SaveLog(ex, sqlEjecucion, parameters);
                return false;
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open && !transaction)
                {
                    oleDbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Metodo exclusivo para guardar los LOG.
        /// </summary>
        /// <param name="oleDbCommand">Objeto Comando</param>
        /// <param name="commandType">Tipo comando</param>
        /// <param name="sql">SQL Insertando el LOG</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        /// <param name="parameters">Listado parametros</param>
        private static void ExecuteNonQueryLog(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
        {
            try
            {
                oleDbCommand.Connection = oleDbConnection;
                oleDbConnection.ConnectionString = oleDbConnection.GetConexion();
                oleDbCommand.Parameters.Clear();

                foreach (OleDbParameter parameter in parameters)
                {
                    oleDbCommand.Parameters.Add(parameter);
                }

                oleDbCommand.CommandType = commandType;
                oleDbCommand.CommandText = sql;
                oleDbConnection.Open();
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close();
                }
            }
        }

        /// <summary>
        /// Cierra la conexión actual en caso de estar abierta
        /// </summary>
        /// <param name="oleDbConnection"></param>
        public static void Close(OleDbConnection oleDbConnection)
        {
            if (oleDbConnection.State == ConnectionState.Open)
            {
                oleDbConnection.Close();
            }
        }

        /// <summary>
        /// Devuelve un OleDbDataReader con el resultado de la consulta SQL
        /// </summary>
        /// <param name="oleDbCommand">Objeto Command</param>
        /// <param name="commandType">Tipo comando</param>
        /// <param name="sql">Cadena SQL</param>
        /// <param name="oleDbConnection">Objeto Conexión</param>
        /// <param name="parameters">Listado parametros</param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
        {
            try
            {
                oleDbCommand.Connection = oleDbConnection;
                oleDbConnection.ConnectionString = oleDbConnection.GetConexion();
                oleDbCommand.Parameters.Clear();

                foreach (OleDbParameter parameter in parameters)
                {
                    oleDbCommand.Parameters.Add(parameter);
                }

                oleDbCommand.CommandType = commandType;
                oleDbCommand.CommandText = sql;
                oleDbConnection.Open();
                return oleDbCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                SaveLog(ex, sql, parameters);
                UtilDA.Close(oleDbConnection);
                throw new Exception(ex.Message);
            }
            
        }

        public static OleDbDataReader ExecuteSubReader(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
        {
            try
            {
                oleDbCommand.Connection = oleDbConnection;
                oleDbCommand.Parameters.Clear();

                foreach (OleDbParameter parameter in parameters)
                {
                    oleDbCommand.Parameters.Add(parameter);
                }

                oleDbCommand.CommandType = commandType;
                oleDbCommand.CommandText = sql;
                return oleDbCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                SaveLog(ex, sql, parameters);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna el Id Generado en una transacción
        /// </summary>
        /// <param name="oleDbCommand"></param>
        /// <param name="oleDbConnection"></param>
        /// <param name="transaction"></param>
        /// <returns>Id Generado</returns>
        public static int GetIdentity(OleDbCommand oleDbCommand, OleDbConnection oleDbConnection, bool transaction)
        {
            try
            {
                oleDbCommand.CommandText = "SELECT @@Identity";
                int id = (int)oleDbCommand.ExecuteScalar();
                return id;

            }
            catch (Exception ex)
            {
                oleDbCommand.CommandText = "ROLLBACK";
                oleDbCommand.ExecuteNonQuery();
                SaveLog(ex, "SELECT @@Identity", null);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open && !transaction)
                {
                    oleDbConnection.Close();
                }
            }
        }

    }
}
