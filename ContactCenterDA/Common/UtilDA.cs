using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ContactCenterDA.Common
{
    static class UtilDA
    {
        public static String GetConexion(this OleDbConnection con)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory().Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA\\");

            string strCnx =
                "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + ruta + "ContactCenter.accdb; Persist Security Info = True";

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

        public static void ExecuteNonQuery(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
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

        public static OleDbDataReader ExecuteReader(OleDbCommand oleDbCommand, CommandType commandType, String sql, OleDbConnection oleDbConnection, params OleDbParameter[] parameters)
        {
            try
            {
                oleDbCommand.Connection = oleDbConnection;
                oleDbConnection.ConnectionString = oleDbConnection.GetConexion();

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
                throw new Exception(ex.Message);
            }
            
        }

    }
}
