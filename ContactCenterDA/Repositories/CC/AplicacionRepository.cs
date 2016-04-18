using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

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
                    objAplicacion.IdAplicacion = DataConvert.ToInt32(dtr["IdAplicacion"]);
                    objAplicacion.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                    objAplicacion.Version = dtr.GetValue(dtr.GetOrdinal("Version")).ToString();
                    objAplicacion.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                    objAplicacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                    objAplicacion.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UsuarioCrea")).ToString();
                    objAplicacion.FechaModificacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaMod")).ToString());
                    objAplicacion.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UsuarioMod")).ToString();

                }
            }
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
                    objAplicacion.IdAplicacion = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("IdAplicacion")).ToString());
                    objAplicacion.Nombre = dtr.GetValue(dtr.GetOrdinal("Nombre")).ToString();
                    objAplicacion.Version = dtr.GetValue(dtr.GetOrdinal("Version")).ToString();
                    objAplicacion.Estado = dtr.GetValue(dtr.GetOrdinal("Estado")).ToString();
                    objAplicacion.FechaCreacion = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("FechaCrea")).ToString());
                    objAplicacion.UsuarioCreacion = dtr.GetValue(dtr.GetOrdinal("UserCrea")).ToString();
                    objAplicacion.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objAplicacion.UsuarioModificacion = dtr.GetValue(dtr.GetOrdinal("UserMod")).ToString();
                    listaAplicacion.Add(objAplicacion);
                }
            }
            return listaAplicacion;
        }

        public void Insert(Aplicacion datos)
        {
            String sql = "INSERT INTO CC_APLICACION(Nombre, Version, Estado, Correo, FechaCrea, UserCrea) " +
                                       "values(@nombre,@version,@estado,@correo,@fechaCreacion,@UsuarioCrea)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter version = UtilDA.SetParameters("@version", OleDbType.VarChar, datos.Version);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCreacion", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter UsuarioCrea = UtilDA.SetParameters("@UsuarioCrea", OleDbType.VarChar, datos.UsuarioCreacion);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, version, estado, correo, fechaCreacion, UsuarioCrea);
        }

        public void Update(Aplicacion datos)
        {
            String sql = "UPDATE CC_APLICACION SET Nombre = @nombre, Version = @version, Estado = @estado, Correo = @correo," +
                                        "FechaMod = @fechaModificacion, UsuarioMod = @UsuarioMod where IdAplicacion = @idAplicacion";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter version = UtilDA.SetParameters("@version", OleDbType.VarChar, datos.Version);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter correo = UtilDA.SetParameters("@correo", OleDbType.VarChar, datos.Correo);
            OleDbParameter fechaModificacion = UtilDA.SetParameters("@fechaModificacion", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter UsuarioMod = UtilDA.SetParameters("@UsuarioMod", OleDbType.VarChar, datos.UsuarioCreacion);
            OleDbParameter idAplicacion = UtilDA.SetParameters("@idAplicacion", OleDbType.Integer, datos.IdAplicacion);

            UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, version, estado, correo, fechaModificacion, UsuarioMod, idAplicacion);

        }
    }
}
