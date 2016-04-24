using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.RolBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

namespace ContactCenterDA.Repositories.CC
{
    public class RolRepository : IRolRepository
    {
        
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE CC_Rol SET ESTADO = 'I' WHERE IdRol = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, codigo);
        }

        public Rol GetById(int id)
        {
            Rol objRol = null;

            String sql = "SELECT * FROM CC_Rol WHERE IdRol = @idRol";

            OleDbParameter codigo = UtilDA.SetParameters("@idRol", OleDbType.Integer, id);

            using(var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                while(dtr.Read())
                {
                    objRol = new Rol();
                    objRol.IdRol = DataConvert.ToInt(dtr["IdRol"]);
                    objRol.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objRol.Estado = DataConvert.ToString(dtr["Estado"]);
                    objRol.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objRol.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objRol.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objRol.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                }
            }
            UtilDA.Close(cnx);
            return objRol;
        }


        public IList<Rol> GetLista()
        {
            List<Rol> listaRol = null;

            String sql = "SELECT * FROM CC_Rol";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while(dtr.Read())
                {
                    Rol objRol = new Rol();
                    objRol.IdRol = DataConvert.ToInt(dtr["IdRol"]);
                    objRol.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objRol.Estado = DataConvert.ToString(dtr["Estado"]);
                    objRol.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objRol.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objRol.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objRol.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    listaRol.Add(objRol);
                }
                UtilDA.Close(cnx);
                return listaRol;
            }
            
        }

        public bool Insert(Rol datos)
        {
            String sql = "INSERT INTO CC_Rol(Nombre, Estado, FechaCrea, UserCrea) " +
                         " VALUES(@nombre, @estado, @fechaCrea, @usuarioCrea)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, datos.FechaCreacion);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, datos.UsuarioCreacion);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, estado, fechaCrea, usuarioCrea);
        }

        public bool Update(Rol datos)
        {
            String sql = "UPDATE CC_Rol SET Nombre = @nombre, Estado = @estado, FechaMod = @fechaMod, UserMod = @usuarioMod WHERE IdRol = @idRol";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, datos.FechaModificacion);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, datos.UsuarioModificacion);
            OleDbParameter idRol = UtilDA.SetParameters("@idRol", OleDbType.Integer, datos.IdRol);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, estado, fechaMod, usuarioMod, idRol);
        }
    }
}
