using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class LogEmailRepository : ILogEmailRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LogEmail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LogEmail> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(LogEmail datos)
        {
            String sql = "INSERT INTO TH_LOG_EMAIL(CorreoDestino, CorreoDestinoCC, FechaEnvio, Mensaje, Asunto, Estado, Descripcion,FechaCrea,UserCrea,Intento) " +
                         "VALUES(@correoDestino, @correoDestinoCC, @fechaEnvio, @mensaje, @asunto, @estado, @descripcion, @fechaCrea, @userCrea, @intento)";

            OleDbParameter correoDestino = UtilDA.SetParameters("@correoDestino", OleDbType.VarChar, datos.CorreoDestino);
            OleDbParameter correoDestinoCC = UtilDA.SetParameters("@correoDestinoCC", OleDbType.VarChar, datos.CorreoDestinoCC);
            OleDbParameter fechaEnvio = UtilDA.SetParameters("@fechaEnvio", OleDbType.Date, datos.FechaEnvio);
            OleDbParameter mensaje = UtilDA.SetParameters("@mensaje", OleDbType.VarChar, datos.Mensaje);
            OleDbParameter asunto = UtilDA.SetParameters("@asunto", OleDbType.VarChar, datos.Asunto);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter intento = UtilDA.SetParameters("@intento", OleDbType.Integer, datos.Intento);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, correoDestino, correoDestinoCC, fechaEnvio, mensaje, asunto, estado, descripcion, fechaCreacion, usuarioCrea, intento);
            
        }

        public bool Update(LogEmail datos)
        {
            throw new NotImplementedException();
        }
    }
}
