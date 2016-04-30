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

namespace ContactCenterDA.Common
{
    static class UtilDA
    {
        public static String GetConexion(this OleDbConnection con)
        {

            string ruta = System.IO.Directory.GetCurrentDirectory();
            if (ruta.Contains("TestResults"))
            {
                int since = ruta.LastIndexOf("TestResults");
                ruta = ruta.Substring(0, since) + "ContactCenterDA";
            }

            if (ruta.Contains("ContactCenterGUI\\bin\\Debug"))
                ruta = ruta.Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA");

            if(ruta.Contains("ContactCenterUnitTest\\bin\\Debug"))
                ruta = ruta.Replace("ContactCenterUnitTest\\bin\\Debug", "ContactCenterDA");

            string strCnx =
                "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + ruta + "\\ContactCenter.accdb; Persist Security Info = True;";

            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }

        public static OleDbParameter SetParameters(string name, OleDbType type, object value, ParameterDirection parameterDirection)
        {
            OleDbParameter parameter = new OleDbParameter(name, type);
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            return parameter;
        }
        public static OleDbParameter SetParameters(string name, OleDbType type, object value)
        {
            OleDbParameter parameter = new OleDbParameter(name, type);
            parameter.Value = value;
            return parameter;
        }
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

        public static bool ExecuteNonQuery(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
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
                return true;
            }
            catch (OleDbException ex)
            {
                SaveLog(ex, sql, parameters);
                throw new Exception(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                SaveLog(ex, sql, parameters);
                throw new Exception(ex.Message);
                return false;
            }
            finally
            {
                if (oleDbConnection.State == ConnectionState.Open)
                {
                    oleDbConnection.Close();
                }
            }
        }

        public static bool ExecuteQueryValidador(OleDbCommand oleDbCommand, CommandType commandType, String sqlValidador, String sqlEjecucion, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
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
                oleDbConnection.Open();
                oleDbCommand.CommandText = sqlValidador;
                OleDbDataReader dtr = oleDbCommand.ExecuteReader();
                if (!dtr.HasRows)
                {
                    dtr.Close();
                    oleDbCommand.CommandText = sqlEjecucion;
                    oleDbCommand.ExecuteNonQuery();
                    return true;
                }
                return false;

            }
            catch (OleDbException ex)
            {
                SaveLog(ex, sqlEjecucion, parameters);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                SaveLog(ex, sqlEjecucion, parameters);
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
            catch (OleDbException ex)
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

        public static void Close(OleDbConnection oleDbConnection)
        {
            if (oleDbConnection.State == ConnectionState.Open)
            {
                oleDbConnection.Close();
            }
        }
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
            catch (OleDbException ex)
            {
                SaveLog(ex, sql, parameters);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                SaveLog(ex, sql, parameters);
                throw new Exception(ex.Message);
            }
        }

    }
}
