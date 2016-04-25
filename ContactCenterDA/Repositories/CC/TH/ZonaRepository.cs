using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterCommon;


namespace ContactCenterDA.Repositories.CC.TH
{
    public class ZonaRepository : IZonaRepository
    {

        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_Zona SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdZona = @codigo";

            OleDbParameter FechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter UserMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, FechaMod, UserMod, codigo);
        }

        public Zona GetById(int id)
        {
            Zona objZona = null;

            String sql = "SELECT * FROM TH_Zona Z INNER JOIN TH_Teatro T ON T.IdTeatro  = T.IdTeatro WHERE IdZona = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = (UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo)))
            {
                while(dtr.Read())
                {
                    objZona = new Zona();
                    objZona.IdZona = DataConvert.ToInt(dtr["Z.IdZona"]);
                    objZona.Nombre = DataConvert.ToString(dtr["Z.Nombre"]);
                    objZona.Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]);
                    objZona.Estado = DataConvert.ToString(dtr["Z.Estado"]);
                    objZona.Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"])
                    };
                    objZona.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objZona.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objZona.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objZona.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                }
            }
            UtilDA.Close(cnx);
            return objZona;
        }

        public IList<Zona> GetLista()
        {
            List<Zona> listaZona = null;

            String sql = "SELECT * FROM TH_Zona Z INNER JOIN TH_Teatro T ON T.IdTeatro  = T.IdTeatro";

            using (var dtr = (UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx)))
            {
                while (dtr.Read())
                {
                    Zona objZona = new Zona();
                    objZona.IdZona = DataConvert.ToInt(dtr["Z.IdZona"]);
                    objZona.Nombre = DataConvert.ToString(dtr["Z.Nombre"]);
                    objZona.Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]);
                    objZona.Estado = DataConvert.ToString(dtr["Z.Estado"]);
                    objZona.Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"])
                    };
                    objZona.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objZona.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objZona.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objZona.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    listaZona.Add(objZona);
                }
            }
            UtilDA.Close(cnx);
            return listaZona;

        }

        public bool Insert(Zona datos)
        {
            String sql = "INSERT INTO TH_Zona(Nombre, Descripcion, Estado, IdTeatro, FechaCrea, UserCrea) " +
                        "VALUES(@nombre, @descripcion, @estado, @idTeatro, @fechaCrea, @userCrea)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idTeatro = UtilDA.SetParameters("@idTeatro", OleDbType.Integer, datos.Teatro.IdTeatro);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, descripcion, estado, idTeatro, fechaCreacion, usuarioCrea);
        }

        public bool Update(Zona datos)
        {
            String sql = "UPDATE TH_Zona SET Nombre = @nombre, Descripcion = @descripcion, Estado = @estado, IdTeatro = @idTeatro, FechaMod = @fechaMod, UserMod = @usuarioMod " +
                        "WHERE IdZona = @idZona";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter idTeatro = UtilDA.SetParameters("@idTeatro", OleDbType.Integer, datos.Teatro.IdTeatro);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idZona = UtilDA.SetParameters("@idZona", OleDbType.VarChar, datos.IdZona);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, nombre, descripcion, estado, idTeatro, fechaMod, usuarioMod, idZona);
        }
    }

}
