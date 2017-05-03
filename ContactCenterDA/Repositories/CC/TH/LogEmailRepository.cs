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
using ContactCenterBE.Base;

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
            LogEmail objLogEmail = null;

            String sql = "SELECT * FROM TH_LOG_EMAIL WHERE IDLOGEMAIL = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objLogEmail = new LogEmail();
                objLogEmail.IdLog = DataConvert.ToInt(dtr["IdLogEmail"]);
                objLogEmail.CorreoDestino = DataConvert.ToString(dtr["CorreoDestino"]);
                objLogEmail.CorreoDestinoCC = DataConvert.ToString(dtr["CorreoDestinoCC"]);
                objLogEmail.FechaEnvio = DataConvert.ToDateTime(dtr["FechaEnvio"]);
                objLogEmail.Mensaje = DataConvert.ToString(dtr["Mensaje"]);
                objLogEmail.Asunto = DataConvert.ToString(dtr["Asunto"]);
                objLogEmail.Estado = DataConvert.ToString(dtr["Estado"]);
                objLogEmail.Descripcion = DataConvert.ToString(dtr["Descripcion"]);
                objLogEmail.Intento = DataConvert.ToInt32(dtr["Intento"]);
                objLogEmail.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                objLogEmail.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                objLogEmail.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                objLogEmail.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                objLogEmail.MensajeImagen = DataConvert.ToString(dtr["MensajeImage"]);
                objLogEmail.IdObra = DataConvert.ToInt(dtr["IdObra"]);
            }

            UtilDA.Close(cnx);

            return objLogEmail;

        }

        public List<LogEmail> GetCorreoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            String sql = "SELECT * FROM TH_LOG_EMAIL WHERE FechaCrea BETWEEN  @fechaInicio AND @fechaFin ORDER BY FECHACREA DESC";

            OleDbParameter pFecha = UtilDA.SetParameters("@fechaInicio", OleDbType.Date, fechaInicio);
            OleDbParameter pFechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.Date, fechaFin);

            LogEmail objLogEmail = null;

            List<LogEmail> ListaLogEmail = new List<LogEmail>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pFecha, pFechaFin))
            {
                while (dtr.Read())
                {
                    objLogEmail = new LogEmail()
                    {

                        IdLog = DataConvert.ToInt(dtr["IdLogEmail"]),
                        CorreoDestino = DataConvert.ToString(dtr["CorreoDestino"]),
                        CorreoDestinoCC = DataConvert.ToString(dtr["CorreoDestinoCC"]),
                        FechaEnvio = DataConvert.ToDateTime(dtr["FechaEnvio"]),
                        Mensaje = DataConvert.ToString(dtr["Mensaje"]),
                        Asunto = DataConvert.ToString(dtr["Asunto"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Intento = DataConvert.ToInt(dtr["Intento"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]),
                        MensajeImagen = DataConvert.ToString(dtr["MensajeImagen"]),
                        IdObra = DataConvert.ToInt(dtr["IdObra"])
                    };
                    ListaLogEmail.Add(objLogEmail);
                }
            }

            UtilDA.Close(cnx);
            return ListaLogEmail;
        }


        public bool Insert(LogEmail datos)
        {
            String sql = "INSERT INTO TH_LOG_EMAIL(CorreoDestino, CorreoDestinoCC, FechaEnvio, Mensaje, Asunto, Estado, Descripcion,FechaCrea,UserCrea,Intento,IdObra, MensajeImagen) " +
                         "VALUES(@correoDestino, @correoDestinoCC, @fechaEnvio, @mensaje, @asunto, @estado, @descripcion, @fechaCrea, @userCrea, @intento,@idObra,@mensajeImagen)";

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
            OleDbParameter idobra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.IdObra);
            OleDbParameter mensajeImagen = UtilDA.SetParameters("@mensajeImagen", OleDbType.VarChar, datos.MensajeImagen);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, correoDestino, correoDestinoCC, fechaEnvio, mensaje, asunto, estado, descripcion, fechaCreacion, usuarioCrea, intento, idobra, mensajeImagen);
            
        }

        public bool Update(LogEmail datos)
        {
            String sql = "UPDATE TH_LOG_EMAIL SET CorreoDestino = @correoDestino, CorreoDestinoCC = @correoDestinoCC, Estado = @estado, Intento = @intento, " +
                         "FechaEnvio = @fechaEnvio, Descripcion = @descripcion, FechaMod = @fechaMod, UserMod = @usuarioMod,MensajeImagen = @mensajeImagen WHERE IDLOGEMAIL = @idLog ";

            OleDbParameter correoDestino = UtilDA.SetParameters("@correoDestino", OleDbType.VarChar, datos.CorreoDestino);
            OleDbParameter correoDestinoCC = UtilDA.SetParameters("@correoDestinoCC", OleDbType.VarChar, datos.CorreoDestinoCC);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter intento = UtilDA.SetParameters("@intento", OleDbType.Integer, datos.Intento);
            OleDbParameter fechaEnvio = UtilDA.SetParameters("@fechaEnvio", OleDbType.Date, datos.FechaEnvio);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fechaMod = UtilDA.SetParameters("@userCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter mensajeImagen = UtilDA.SetParameters("@mensajeImagen", OleDbType.VarChar, datos.MensajeImagen);
            OleDbParameter idLog = UtilDA.SetParameters("@idLog", OleDbType.Integer, datos.IdLog);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, correoDestino, correoDestinoCC, estado, intento,fechaEnvio, descripcion, fechaMod, usuarioMod,mensajeImagen,idLog);
        }

        public IList<LogEmail> GetLista()
        {
            String sql = "SELECT * FROM TH_LOG_EMAIL ORDER BY FECHACREA DESC";

            LogEmail objLogEmail = null;
            List<LogEmail> ListaLogEmail = new List<LogEmail>();

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    objLogEmail = new LogEmail()
                    {

                        IdLog = DataConvert.ToInt(dtr["IdLogEmail"]),
                        CorreoDestino = DataConvert.ToString(dtr["CorreoDestino"]),
                        CorreoDestinoCC = DataConvert.ToString(dtr["CorreoDestinoCC"]),
                        FechaEnvio = DataConvert.ToDateTime(dtr["FechaEnvio"]),
                        Mensaje = DataConvert.ToString(dtr["Mensaje"]),
                        Asunto = DataConvert.ToString(dtr["Asunto"]),
                        Estado = DataConvert.ToString(dtr["Estado"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Intento = DataConvert.ToInt(dtr["Intento"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]),
                        MensajeImagen = DataConvert.ToString(dtr["MensajeImagen"]),
                        IdObra = DataConvert.ToInt(dtr["IdObra"])
                    };
                    ListaLogEmail.Add(objLogEmail);
                }
            }

            UtilDA.Close(cnx);
            return ListaLogEmail;
        }
    }
}
