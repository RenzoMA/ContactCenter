using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterDA.Repositories.CC
{
    public class AplicacionRepository : IAplicacionRepository
    {
        
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();


        public void Delete(int id)
        {
            String sql = "DELETE FROM CC_APLICACION WHERE IdAplicacion = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, codigo);
        }

        public Aplicacion GetById(int id)
        {
            Aplicacion objAplicacion = null;

            String sql = "SELECT * FROM CC_Aplicacion WHERE IdAplicacion = @idAplicacion";

            OleDbParameter codigo = UtilDA.SetParameters("@idAplicacion", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                while (dtr.Read())
                {
                    objAplicacion = new Aplicacion();
                    objAplicacion.IdAplicacion = DataConvert.ToInt(dtr["IdAplicacion"]);
                    objAplicacion.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objAplicacion.Version = DataConvert.ToString(dtr["Version"]);
                    objAplicacion.Estado = DataConvert.ToString(dtr["Estado"]);
                    objAplicacion.Correo = DataConvert.ToString(dtr["Correo"]);
                    objAplicacion.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objAplicacion.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objAplicacion.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objAplicacion.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);

                }
            }
            UtilDA.Close(cnx);
            return objAplicacion;
            
        }

        public IList<Aplicacion> GetLista()
        {
            List<Aplicacion> listaAplicacion = new List<Aplicacion>();
            String sql = "SELECT * FROM CC_Aplicacion";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Aplicacion objAplicacion = new Aplicacion();
                    objAplicacion.IdAplicacion = DataConvert.ToInt(dtr["IdAplicacion"]);
                    objAplicacion.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objAplicacion.Version = DataConvert.ToString(dtr["Version"]);
                    objAplicacion.Estado = DataConvert.ToString(dtr["Estado"]);
                    objAplicacion.Correo = DataConvert.ToString(dtr["Correo"]);
                    objAplicacion.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objAplicacion.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objAplicacion.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objAplicacion.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    listaAplicacion.Add(objAplicacion);
                }
            }
            UtilDA.Close(cnx);
            return listaAplicacion;
        }

        public void Insert(Aplicacion datos)
        {
            String sql = "INSERT INTO CC_APLICACION(Nombre, Version, Estado, Correo, FechaCrea, UserCrea) " +
                                       "VALUES(@nombre,@version,@estado,@correo,@fechaCrea,@usuarioCrea)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter version = UtilDA.SetParameters("@version", OleDbType.VarChar, datos.Version);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter UsuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, datos.UsuarioCreacion);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, version, estado, correo, fechaCreacion, UsuarioCrea);
        }

        public void Update(Aplicacion datos)
        {
            String sql = "UPDATE CC_APLICACION SET Nombre = @nombre, Version = @version, Estado = @estado, Correo = @correo," +
                                        "FechaMod = @fechaMod, UserMod = @usuarioMod WHERE IdAplicacion = @idAplicacion";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter version = UtilDA.SetParameters("@version", OleDbType.VarChar, datos.Version);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter fechaModificacion = UtilDA.SetParameters("@fechaMod", OleDbType.Date, datos.FechaModificacion);
            OleDbParameter UsuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, datos.FechaModificacion);
            OleDbParameter idAplicacion = UtilDA.SetParameters("@idAplicacion", OleDbType.Integer, datos.IdAplicacion);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, version, estado, correo, fechaModificacion, UsuarioMod, idAplicacion);

        }

        public List<Aplicacion> ListarAplicacionUsuario(Usuario usuario)
        {
            List<Aplicacion> listaAplicacion = new List<Aplicacion>();
            String sql = "SELECT A.IdAplicacion, A.Nombre, A.Version, A.Estado, A.Correo, A.FechaCrea, A.UserCrea, A.UserMod, A.FechaMod, A.FormInicio FROM CC_USUARIO_APLICACION UA INNER JOIN CC_APLICACION A ON A.IDAPLICACION = UA.IDAPLICACION WHERE UA.IDUSUARIO = @IDUSUARIO";
            OleDbParameter idUsuario = UtilDA.SetParameters("@IDUSUARIO", OleDbType.VarChar, usuario.IdUsuario);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, idUsuario))
            {
                while (dtr.Read())
                {
                    Aplicacion objAplicacion = new Aplicacion();
                    objAplicacion.IdAplicacion = DataConvert.ToInt(dtr["IdAplicacion"]);
                    objAplicacion.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objAplicacion.Version = DataConvert.ToString(dtr["Version"]);
                    objAplicacion.Estado = DataConvert.ToString(dtr["Estado"]);
                    objAplicacion.Correo = DataConvert.ToString(dtr["Correo"]);
                    objAplicacion.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objAplicacion.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objAplicacion.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objAplicacion.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objAplicacion.FormInicio = DataConvert.ToString(dtr["FormInicio"]);
                    listaAplicacion.Add(objAplicacion);
                }
            }
            UtilDA.Close(cnx);
            return listaAplicacion;

        }
    }
}
