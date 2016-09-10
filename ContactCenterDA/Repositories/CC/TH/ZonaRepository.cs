    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;


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

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, FechaMod, UserMod, codigo);
        }

        public Zona GetById(int id)
        {
            Zona objZona = null;

            String sql = "SELECT * FROM TH_Zona";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = (UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo)))
            {
                while(dtr.Read())
                {
                    objZona = new Zona();
                    objZona.IdZona = DataConvert.ToInt(dtr["IdZona"]);
                    objZona.Nombre = DataConvert.ToString(dtr["Nombre"]);
                    objZona.Descripcion = DataConvert.ToString(dtr["Descripcion"]);
                    objZona.Estado = DataConvert.ToString(dtr["Estado"]);
                    objZona.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                    objZona.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                    objZona.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                    objZona.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                    objZona.Precio = DataConvert.ToSingle(dtr["Precio"]);
                    objZona.R = DataConvert.ToInt(dtr["R"]);
                    objZona.G = DataConvert.ToInt(dtr["G"]);
                    objZona.B = DataConvert.ToInt(dtr["B"]);
                }
            }
            UtilDA.Close(cnx);
            return objZona;
        }

        public IList<Zona> GetLista()
        {
            List<Zona> listaZona = new List<Zona>();

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
            String sql = "INSERT INTO TH_Zona(Nombre, Descripcion, Estado, FechaCrea, UserCrea,Precio,R,G,B,idObra) " +
                        "VALUES(@nombre, @descripcion, @estado, @fechaCrea, @userCrea,@precio,@r,@g,@b,@idObra)";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter precio = UtilDA.SetParameters("@precio", OleDbType.Integer, datos.Precio);
            OleDbParameter r = UtilDA.SetParameters("@r", OleDbType.Integer, datos.R);
            OleDbParameter g = UtilDA.SetParameters("@g", OleDbType.Integer, datos.G);
            OleDbParameter b = UtilDA.SetParameters("@b", OleDbType.Integer, datos.B);
            OleDbParameter idObra = UtilDA.SetParameters("@b", OleDbType.Integer, datos.Obra.IdObra);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, descripcion, estado, fechaCreacion, usuarioCrea,precio,r,g,b,idObra);
        }

        public bool Update(Zona datos)
        {
            String sql = "UPDATE TH_Zona SET Nombre = @nombre, Descripcion = @descripcion, Estado = @estado, FechaMod = @fechaMod, UserMod = @usuarioMod,Precio = @precio, R = @r, G = @g, B = @b " +
                        "WHERE IdZona = @idZona";

            OleDbParameter nombre = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Nombre);
            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter estado = UtilDA.SetParameters("@estado", OleDbType.VarChar, datos.Estado);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter precio = UtilDA.SetParameters("@precio", OleDbType.Single, datos.Precio);
            OleDbParameter r = UtilDA.SetParameters("@r", OleDbType.Integer, datos.R);
            OleDbParameter g = UtilDA.SetParameters("@g", OleDbType.Integer, datos.G);
            OleDbParameter b = UtilDA.SetParameters("@b", OleDbType.Integer, datos.B);
            OleDbParameter idZona = UtilDA.SetParameters("@idZona", OleDbType.VarChar, datos.IdZona);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, nombre, descripcion, estado, fechaMod, usuarioMod, precio, r, g, b, idZona);
        }

        public List<Zona> ListZonaByObra(int IdObra)
        {
            List<Zona> listaZona = new List<Zona>();
            Zona zona = null;
            String sql = "SELECT * FROM TH_Zona Z INNER JOIN TH_OBRA T ON T.IDOBRA  = Z.IDOBRA WHERE T.IdObra = @IdObra";
            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdObra", OleDbType.Integer, IdObra);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdTeatro))
            {
                while (dtr.Read())
                {
                    zona = new Zona();
                    zona.IdZona = DataConvert.ToInt(dtr["IdZona"]);
                    zona.Nombre = DataConvert.ToString(dtr["Z.Nombre"]);
                    zona.Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]);
                    zona.Estado = DataConvert.ToString(dtr["Z.Estado"]);
                    zona.FechaCreacion = DataConvert.ToDateTime(dtr["Z.FechaCrea"]);
                    zona.UsuarioCreacion = DataConvert.ToString(dtr["Z.UserCrea"]);
                    zona.FechaModificacion = DataConvert.ToDateTime(dtr["Z.FechaMod"]);
                    zona.UsuarioModificacion = DataConvert.ToString(dtr["Z.UserMod"]);
                    zona.Precio = DataConvert.ToSingle(dtr["Precio"]);
                    zona.R = DataConvert.ToInt(dtr["R"]);
                    zona.G = DataConvert.ToInt(dtr["G"]);
                    zona.B = DataConvert.ToInt(dtr["B"]);
                    zona.Obra = new Obra
                    {
                        IdObra = DataConvert.ToInt(dtr["T.IdObra"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        FechaInicio = DataConvert.ToDateTime(dtr["FechaInicio"]),
                        FechaFin = DataConvert.ToDateTime(dtr["FechaFin"]),
                        Descripcion = DataConvert.ToString(dtr["T.Descripcion"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["T.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["T.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["T.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["T.UserMod"])
                    };
                    listaZona.Add(zona);
                }
            }
            UtilDA.Close(cnx);
            return listaZona;
        }
    }

}
