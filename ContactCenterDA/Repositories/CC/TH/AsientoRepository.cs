using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterCommon;


namespace ContactCenterDA.Repositories.CC.TH
{
    public class AsientoRepository : IAsientoRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            String sql = "UPDATE TH_Asiento SET ESTADO = 'I', FechaMod = @FechaMod, UserMod = @UserMod WHERE IdAsiento = @codigo";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);
            OleDbParameter fechaMod = UtilDA.SetParameters("@FechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter userMod = UtilDA.SetParameters("@UserMod", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, fechaMod, userMod, codigo);
        }

        public Asiento GetById(int id)
        {
            Asiento objAsiento = null;

            String sql = "SELECT * FROM TH_Asiento A INNER JOIN TH_Zona Z ON Z.IdZona = A.IdZona INNER JOIN TH_TEATRO T ON T.IdTeatro = Z.IdTeatro WHERE IdAsiento = @codigo ";

            OleDbParameter codigo = UtilDA.SetParameters("@codigo", OleDbType.Integer, id);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, codigo))
            {
                objAsiento = new Asiento();
                objAsiento.IdAsiento = DataConvert.ToInt(dtr["IdAsiento"]);
                objAsiento.Descripcion = DataConvert.ToString(dtr["A.Descripcion"]);
                objAsiento.Fila = DataConvert.ToString(dtr["Fila"]);
                objAsiento.Disponible = DataConvert.ToString(dtr["Disponible"]);
                objAsiento.Zona = new Zona()
                {
                    IdZona = DataConvert.ToInt(dtr["Z.IdZona"]),
                    Nombre = DataConvert.ToString(dtr["Z.Nombre"]),
                    Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]),
                    Estado = DataConvert.ToString(dtr["Z.Estado"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"])
                    },
                };
                objAsiento.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                objAsiento.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                objAsiento.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                objAsiento.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
            }
            UtilDA.Close(cnx);
            return objAsiento;
        }

        public IList<Asiento> GetLista()
        {
            List<Asiento> listaAsiento = null;

            String sql = "SELECT * FROM TH_Asiento A INNER JOIN TH_Zona Z ON Z.IdZona = A.IdZona INNER JOIN TH_TEATRO T ON T.IdTeatro = Z.IdTeatro";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                Asiento objAsiento = new Asiento();
                objAsiento.IdAsiento = DataConvert.ToInt(dtr["IdAsiento"]);
                objAsiento.Descripcion = DataConvert.ToString(dtr["A.Descripcion"]);
                objAsiento.Fila = DataConvert.ToString(dtr["Fila"]);
                objAsiento.Disponible = DataConvert.ToString(dtr["Disponible"]);
                objAsiento.Zona = new Zona()
                {
                    IdZona = DataConvert.ToInt(dtr["Z.IdZona"]),
                    Nombre = DataConvert.ToString(dtr["Z.Nombre"]),
                    Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]),
                    Estado = DataConvert.ToString(dtr["Z.Estado"]),
                    Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Nombre = DataConvert.ToString(dtr["T.Nombre"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"])
                    },
                };
                objAsiento.FechaCreacion = DataConvert.ToDateTime(dtr["FechaCrea"]);
                objAsiento.UsuarioCreacion = DataConvert.ToString(dtr["UserCrea"]);
                objAsiento.FechaModificacion = DataConvert.ToDateTime(dtr["FechaMod"]);
                objAsiento.UsuarioModificacion = DataConvert.ToString(dtr["UserMod"]);
                listaAsiento.Add(objAsiento);
            }
            UtilDA.Close(cnx);
            return listaAsiento;
        }

        public bool Insert(Asiento datos)
        {
            String sql = "INSERT INTO TH_Asiento(Descripcion, Fila, Disponible, IdZona, FechaCrea, UserCrea) " +
                            "VALUES(@descripciom, @fila, @disponible, @idZona, @fechaCrea, @usuarioCrea)";

            OleDbParameter descripcion = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fila = UtilDA.SetParameters("@fila", OleDbType.VarBinary, datos.Fila);
            OleDbParameter disponible = UtilDA.SetParameters("@disponible", OleDbType.VarChar, datos.Disponible);
            OleDbParameter idzona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, datos.Zona.IdZona);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, descripcion, fila, disponible, idzona, fechaCreacion, usuarioCrea);
        }

        public bool Update(Asiento datos)
        {
            String sql = "UPDATE TH_Asiento SET Descripcion = @descripcion, Fila = @fila, Disponible = @disponible, IdZona = @IdZona " +
                            "FechaMod = @fechaMod, UserMod = @usuarioMod WHERE IdAsiento = @idAsiento";

            OleDbParameter descripcion = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fila = UtilDA.SetParameters("@fila", OleDbType.VarBinary, datos.Fila);
            OleDbParameter disponible = UtilDA.SetParameters("@disponible", OleDbType.VarBinary, datos.Disponible);
            OleDbParameter idzona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, datos.Zona.IdZona);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, datos.IdAsiento);
            //atochipi
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, descripcion, fila, disponible, idzona, fechaMod, usuarioMod, idAsiento);
        }
    }
}