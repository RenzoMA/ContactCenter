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
            OleDbParameter fila = UtilDA.SetParameters("@fila", OleDbType.VarChar, datos.Fila);
            OleDbParameter disponible = UtilDA.SetParameters("@disponible", OleDbType.VarChar, datos.Disponible);
            OleDbParameter idzona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, datos.Zona.IdZona);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, descripcion, fila, disponible, idzona, fechaCreacion, usuarioCrea);
        }

        public bool Update(Asiento datos)
        {
            String sql = "UPDATE TH_Asiento SET Descripcion = @descripcion, Fila = @fila, Disponible = @disponible, IdZona = @IdZona, " +
                            "FechaMod = @fechaMod, UserMod = @usuarioMod WHERE IdAsiento = @idAsiento";

            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fila = UtilDA.SetParameters("@fila", OleDbType.VarChar, datos.Fila);
            OleDbParameter disponible = UtilDA.SetParameters("@disponible", OleDbType.VarChar, datos.Disponible);
            OleDbParameter idzona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, datos.Zona.IdZona);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, datos.IdAsiento);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, descripcion, fila, disponible, idzona, fechaMod, usuarioMod, idAsiento);
        }

        public List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime fechaReserva,string token)
        {
            cmd = new OleDbCommand();
            cnx = new OleDbConnection();
            List<Asiento> lAsiento = new List<Asiento>();
            Asiento asiento = null;

            string sql = "SELECT IdAsiento, Estado FROM TH_DETALLE_RESERVA DR INNER JOIN TH_RESERVA R ON R.IDRESERVA = DR.IDRESERVA WHERE R.IDOBRA = @IdObra AND R.IDFUNCION = @IdFuncion AND R.FECHARESERVA = @fechaReserva UNION SELECT idAsiento, ESTADO FROM TH_ASIENTO_TEMPORAL WHERE IdFuncion =@IdFuncion2 AND FECHAOBRA = @fechaReserva2 AND TOKEN <> @token";

            OleDbParameter obra = UtilDA.SetParameters("@IdObra", OleDbType.Integer, idObra);
            OleDbParameter funcion = UtilDA.SetParameters("@IdFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter reserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date,fechaReserva);
            OleDbParameter funcion2 = UtilDA.SetParameters("@IdFuncion2", OleDbType.Integer, idFuncion);
            OleDbParameter reserva2 = UtilDA.SetParameters("@fechaReserva2", OleDbType.Date, fechaReserva);
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, obra, funcion, reserva,funcion2, reserva2, pToken))
            {
                while (dtr.Read())
                {
                    asiento = new Asiento()
                    {
                        Disponible = DataConvert.ToString(dtr["Estado"]),
                        IdAsiento = DataConvert.ToInt(dtr["IdAsiento"])
                    };
                    lAsiento.Add(asiento);
                }
            }
            UtilDA.Close(cnx);
            return lAsiento;
        }

        public List<AsientoPrecio> ListarTeatroAsiento(int idObra)
        {
            List<AsientoPrecio> lAsiento = new List<AsientoPrecio>();
            AsientoPrecio asiento = null;

            string sql = "SELECT * FROM TH_ASIENTO A "+
                         "INNER JOIN TH_TARIFA T "+
                         "ON A.IDZONA = T.IDZONA "+
                         "WHERE "+
                         "T.IDOBRA = @IdObra";

            OleDbParameter _idTeatro = UtilDA.SetParameters("@IdObra", OleDbType.Integer, idObra);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, _idTeatro))
            {
                while (dtr.Read())
                {
                    asiento = new AsientoPrecio()
                    {
                        Disponible = DataConvert.ToString(dtr["Disponible"]),
                        IdAsiento = DataConvert.ToInt(dtr["IdAsiento"]),
                        Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                        Fila = DataConvert.ToString(dtr["Fila"]),
                        Precio = DataConvert.ToSingle(dtr["Precio"])
                    };
                    lAsiento.Add(asiento);
                }
            }
            UtilDA.Close(cnx);
            return lAsiento;
        }

        public bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            string sqlValida = "SELECT * FROM TH_ASIENTO_TEMPORAL WHERE IdFuncion = @idFuncion and idAsiento = @IdAsiento and FechaObra = @FechaObra and token <> @token";

            string sqlInsert = "INSERT INTO TH_ASIENTO_TEMPORAL (IdFuncion,IdAsiento,FechaObra,Token,UserCrea,FechaCrea,Estado) VALUES " +
                         "(@idFuncion,@idAsiento,@fechaObra,@token,@userCrea,@fechaCrea,'A')";

            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, idAsiento);
            OleDbParameter pFechaObra = UtilDA.SetParameters("@fechaObra", OleDbType.Date, fechaObra);
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            return UtilDA.ExecuteQueryValidador(cmd, CommandType.Text, sqlValida, sqlInsert, cnx, pIdFuncion, pIdAsiento, pFechaObra, pToken, pUserCrea,pFechaCrea);

        }

        public bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            string sql = "DELETE FROM TH_ASIENTO_TEMPORAL WHERE IdFuncion = @idFuncion and idAsiento = @IdAsiento and FechaObra = @FechaObra and token = @token";
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, idAsiento);
            OleDbParameter pFechaObra = UtilDA.SetParameters("@fechaObra", OleDbType.Date, fechaObra);
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, pIdFuncion, pIdAsiento, pFechaObra, pToken);

        }
        public bool EliminarAsientoTemporalTotal(string token)
        {
            string sql = "DELETE FROM TH_ASIENTO_TEMPORAL WHERE token = @token";
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, pToken);

        }
    }
}