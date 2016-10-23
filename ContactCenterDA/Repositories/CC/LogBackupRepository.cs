using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.LogBackup;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;


namespace ContactCenterDA.Repositories.CC
{
    public class LogBackupRepository : ILogBackupRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LogBackup GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LogBackup> GetLista()
        {
            List<LogBackup> listaLogBackup = new List<LogBackup>();

            String sql = "SELECT * FROM CC_LOG_BACKUP WHERE FechaCreacion = @fechaActual AND ComputerName = @computerName";
            OleDbParameter pFechaActual = UtilDA.SetParameters("@fechaActual", OleDbType.Date, DateTime.Today);
            OleDbParameter pComputerName = UtilDA.SetParameters("@computerName", OleDbType.VarChar, Environment.MachineName);
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pFechaActual, pComputerName))
            {
                while (dtr.Read())
                {
                    LogBackup logBackup = new LogBackup()
                    {
                        IdLogBackup = DataConvert.ToInt(dtr["IdLogBackup"]),
                        ComputerName = DataConvert.ToString(dtr["ComputerName"]),
                        FileName = DataConvert.ToString(dtr["FileName"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCreacion"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"])
                    };
                    listaLogBackup.Add(logBackup);
                }
            }
            UtilDA.Close(cnx);
            return listaLogBackup;
        }

        public bool Insert(LogBackup datos)
        {
            String sql = "INSERT INTO CC_LOG_BACKUP(ComputerName, FileName, FechaCreacion, UserCrea) " +
                        " VALUES(@computerName, @fileName, @fechaCreacion, @userCrea)";

            OleDbParameter pComputerName = UtilDA.SetParameters("@computerName", OleDbType.VarChar, datos.ComputerName);
            OleDbParameter pFileName = UtilDA.SetParameters("@fileName", OleDbType.VarChar, datos.FileName);
            OleDbParameter pFechaCreacion = UtilDA.SetParameters("@fechaCreacion", OleDbType.Date, DateTime.Now.Date);
            OleDbParameter pUsuarioCreacion = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pComputerName, pFileName, pFechaCreacion, pUsuarioCreacion);

        }

        public bool Update(LogBackup datos)
        {
            throw new NotImplementedException();
        }

    }
}
