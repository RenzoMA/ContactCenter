using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;



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

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaMod, userMod, codigo);
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
            List<Asiento> listaAsiento = new List<Asiento>();

            String sql = "SELECT * FROM TH_Asiento A INNER JOIN TH_TEATRO T ON A.IdTeatro = T.IdTeatro";

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx))
            {
                while (dtr.Read())
                {
                    Asiento objAsiento = new Asiento();
                    objAsiento.IdAsiento = DataConvert.ToInt(dtr["IdAsiento"]);
                    objAsiento.Descripcion = DataConvert.ToString(dtr["Descripcion"]);
                    objAsiento.Fila = DataConvert.ToString(dtr["Fila"]);
                    objAsiento.FechaCreacion = DataConvert.ToDateTime(dtr["A.FechaCrea"]);
                    objAsiento.UsuarioCreacion = DataConvert.ToString(dtr["A.UserCrea"]);
                    objAsiento.FechaModificacion = DataConvert.ToDateTime(dtr["A.FechaMod"]);
                    objAsiento.UsuarioModificacion = DataConvert.ToString(dtr["A.UserMod"]);
                    objAsiento.Teatro = new Teatro()
                    {
                        IdTeatro = DataConvert.ToInt(dtr["T.IdTeatro"]),
                        Estado = DataConvert.ToString(dtr["T.Estado"]),
                        Nombre = DataConvert.ToString(dtr["Nombre"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["T.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["T.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["T.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["T.UserMod"]),
                        frmTeatro = DataConvert.ToString(dtr["frmTeatro"])
                    };
                    listaAsiento.Add(objAsiento);
                }
            }
            UtilDA.Close(cnx);
            return listaAsiento;
        }

        public bool Insert(Asiento datos)
        {
            String sql = "INSERT INTO TH_Asiento(Descripcion, Fila, FechaCrea, UserCrea) " +
                            "VALUES(@descripciom, @fila, @fechaCrea, @usuarioCrea)";

            OleDbParameter descripcion = UtilDA.SetParameters("@nombre", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fila = UtilDA.SetParameters("@fila", OleDbType.VarChar, datos.Fila);
            OleDbParameter fechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioCrea = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, descripcion, fila, fechaCreacion, usuarioCrea);
        }

        public bool Update(Asiento datos)
        {
            String sql = "UPDATE TH_Asiento SET Descripcion = @descripcion, Fila = @fila,   " +
                            "FechaMod = @fechaMod, UserMod = @usuarioMod WHERE IdAsiento = @idAsiento";

            OleDbParameter descripcion = UtilDA.SetParameters("@descripcion", OleDbType.VarChar, datos.Descripcion);
            OleDbParameter fila = UtilDA.SetParameters("@fila", OleDbType.VarChar, datos.Fila);
            OleDbParameter fechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter usuarioMod = UtilDA.SetParameters("@usuarioMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter idAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, datos.IdAsiento);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, descripcion, fila, fechaMod, usuarioMod, idAsiento);
        }

        public List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime fechaReserva,string token)
        {
            cmd = new OleDbCommand();
            cnx = new OleDbConnection();
            List<Asiento> lAsiento = new List<Asiento>();
            Asiento asiento = null;

            string sql = "SELECT IdAsiento, Estado FROM TH_DETALLE_RESERVA DR INNER JOIN TH_RESERVA R ON R.IDRESERVA = DR.IDRESERVA WHERE R.IDOBRA = @IdObra AND R.IDFUNCION = @IdFuncion AND R.FECHARESERVA = @fechaReserva AND IdEstadoReserva = 1 UNION SELECT idAsiento, ESTADO FROM TH_ASIENTO_TEMPORAL WHERE IdFuncion =@IdFuncion2 AND FECHAOBRA = @fechaReserva2 AND TOKEN <> @token";

            OleDbParameter obra = UtilDA.SetParameters("@IdObra", OleDbType.Integer, idObra);
            OleDbParameter funcion = UtilDA.SetParameters("@IdFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter reserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date,fechaReserva);
            OleDbParameter funcion2 = UtilDA.SetParameters("@IdFuncion2", OleDbType.Integer, idFuncion);
            OleDbParameter reserva2 = UtilDA.SetParameters("@fechaReserva2", OleDbType.Date, fechaReserva);
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);
            OleDbParameter pFechaActual = UtilDA.SetParameters("@fechaActual", OleDbType.Date, DateTime.Now);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, obra, funcion, reserva,funcion2, reserva2, pToken, pFechaActual))
            {
                while (dtr.Read())
                {
                    asiento = new Asiento()
                    {
                        IdAsiento = DataConvert.ToInt(dtr["IdAsiento"])
                    };
                    lAsiento.Add(asiento);
                }
            }
            UtilDA.Close(cnx);
            return lAsiento;
        }

        public List<AsientoZona> ListarTeatroAsiento(int idObra)
        {
            List<AsientoZona> lAsientoZona = new List<AsientoZona>();
            AsientoZona asiento = null;

            string sql = "SELECT * FROM (TH_ZONA Z INNER JOIN TH_ASIENTO_ZONA AZ ON AZ.IDZONA = Z.IDZONA) INNER JOIN TH_ASIENTO A ON A.IDASIENTO = AZ.IDASIENTO WHERE Z.IDOBRA = @IdObra AND Z.ESTADO = 'A'";

            OleDbParameter pIdObra = UtilDA.SetParameters("@IdObra", OleDbType.Integer, idObra);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdObra))
            {
                while (dtr.Read())
                {
                    asiento = new AsientoZona()
                    {
                        Zona = new Zona()
                        {
                            IdZona = DataConvert.ToInt(dtr["Z.IdZona"]),
                            Nombre = DataConvert.ToString(dtr["Nombre"]),
                            Descripcion = DataConvert.ToString(dtr["Z.Descripcion"]),
                            Estado = DataConvert.ToString(dtr["Z.Estado"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["Z.UserCrea"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["Z.FechaCrea"]),
                            FechaModificacion = DataConvert.ToDateTime(dtr["Z.FechaMod"]),
                            UsuarioModificacion = DataConvert.ToString(dtr["Z.UserMod"]),
                            Precio = DataConvert.ToSingle(dtr["Precio"]),
                            R = DataConvert.ToInt(dtr["R"]),
                            G = DataConvert.ToInt(dtr["G"]),
                            B = DataConvert.ToInt(dtr["B"]),
                        },
                        IdAsientoZona = DataConvert.ToInt(dtr["IdAsientoZona"]),
                        Disponible = DataConvert.ToString(dtr["Disponible"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["AZ.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["AZ.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["AZ.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["AZ.UserMod"]),
                        Asiento = new Asiento()
                        {
                            IdAsiento = DataConvert.ToInt(dtr["A.IdAsiento"]),
                            Descripcion = DataConvert.ToString(dtr["A.Descripcion"]),
                            Fila = DataConvert.ToString(dtr["Fila"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["A.FechaCrea"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["A.UserCrea"]),
                            FechaModificacion = DataConvert.ToDateTime(dtr["A.FechaMod"]),
                            UsuarioModificacion = DataConvert.ToString(dtr["A.UserMod"])
                        }
                    };
                    lAsientoZona.Add(asiento);
                }
            }
            UtilDA.Close(cnx);
            return lAsientoZona;
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
            return UtilDA.ExecuteQueryValidador(cmd, CommandType.Text, sqlValida, sqlInsert, cnx, false, pIdFuncion, pIdAsiento, pFechaObra, pToken, pUserCrea,pFechaCrea);

        }

        public bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            string sql = "DELETE FROM TH_ASIENTO_TEMPORAL WHERE IdFuncion = @idFuncion and idAsiento = @IdAsiento and FechaObra = @FechaObra and token = @token";
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, idAsiento);
            OleDbParameter pFechaObra = UtilDA.SetParameters("@fechaObra", OleDbType.Date, fechaObra);
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pIdFuncion, pIdAsiento, pFechaObra, pToken);

        }
        public bool EliminarAsientoTemporalTotal(string token)
        {
            string sql = "DELETE FROM TH_ASIENTO_TEMPORAL WHERE token = @token";
            OleDbParameter pToken = UtilDA.SetParameters("@token", OleDbType.VarChar, token);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pToken);

        }

        public List<AsientoZona> ListAsientoByZona(int IdZona)
        {
            List<AsientoZona> listaAsiento = new List<AsientoZona>();
            AsientoZona asiento = null;

            string sql = "SELECT * FROM TH_ASIENTO_ZONA AZ INNER JOIN TH_ASIENTO A ON A.IDASIENTO = AZ.IDASIENTO  WHERE AZ.IdZona = @IdZona ORDER BY A.IdAsiento";
            OleDbParameter pIdZona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, IdZona);


            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdZona))
            {
                while (dtr.Read())
                {
                    asiento = new AsientoZona()
                    {
                        IdAsientoZona = DataConvert.ToInt(dtr["IdAsientoZona"]),
                        IdAsiento = DataConvert.ToInt(dtr["A.IdAsiento"]),
                        Asiento = new Asiento()
                        {
                            IdAsiento = DataConvert.ToInt(dtr["A.IdAsiento"]),
                            Descripcion = DataConvert.ToString(dtr["Descripcion"]),
                            Fila = DataConvert.ToString(dtr["Fila"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["A.FechaCrea"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["A.UserCrea"])
                        },
                        Disponible = DataConvert.ToString(dtr["Disponible"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["AZ.FechaCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["AZ.FechaMod"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["AZ.UserCrea"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["AZ.UserMod"])
                    };
                    listaAsiento.Add(asiento);
                }
            }
            UtilDA.Close(cnx);

            return listaAsiento;
        }

        public bool UpdateAsientoDisponible(string asientos, string estado, int idZona)
        {
            string sql = "UPDATE TH_ASIENTO_ZONA SET DISPONIBLE = @Disponible WHERE IdAsiento IN (" + asientos + ") AND IdZona = @IdZona";
            OleDbParameter pEstado = UtilDA.SetParameters("@Disponible", OleDbType.VarChar, estado);
            OleDbParameter pIdZona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, idZona);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pEstado, pIdZona);
        }

        public bool EliminarAsientoTemporalAntiguo()
        {
            string sql = "DELETE FROM TH_ASIENTO_TEMPORAL WHERE FECHACREA < @fechaActual";
            OleDbParameter fechaActual = UtilDA.SetParameters("@fechaActual", OleDbType.Date, DateTime.Now.AddMinutes(-18));
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, fechaActual);
        }

        public bool EliminarAsientoDisponible(string asientos, int idZona)
        {
            string sql = "DELETE FROM TH_ASIENTO_ZONA WHERE IdAsiento IN (" + asientos + ") AND IdZona = @IdZona";
            OleDbParameter pIdZona = UtilDA.SetParameters("@IdZona", OleDbType.Integer, idZona);
            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pIdZona);
        }

        public List<Asiento> ListAsientoNoAsignado(int idObra, int idTeatro)
        {
            List<Asiento> listaAsiento = new List<Asiento>();
            Asiento asiento = null;
            string sql = "SELECT * FROM TH_ASIENTO A LEFT JOIN (SELECT * FROM TH_ASIENTO_ZONA AZ INNER JOIN TH_ZONA Z ON Z.IDZONA = AZ.IDZONA WHERE Z.IDOBRA = @IdObra AND Z.ESTADO = 'A') AS RES ON RES.IDASIENTO = A.IDASIENTO WHERE IDTEATRO = @IdTeatro AND IDASIENTOZONA IS NULL ORDER BY A.IDASIENTO";
            OleDbParameter pIdObra = UtilDA.SetParameters("@IdObra", OleDbType.Integer, idObra);
            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdObra, pIdTeatro))
            {
                while (dtr.Read())
                {
                    asiento = new Asiento()
                    {
                        IdAsiento = DataConvert.ToInt(dtr["A.IdAsiento"]),
                        Descripcion = DataConvert.ToString(dtr["A.Descripcion"]),
                        Fila = DataConvert.ToString(dtr["Fila"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["A.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["A.UserCrea"]),

                    };
                    listaAsiento.Add(asiento);
                }
            }
            UtilDA.Close(cnx);

            return listaAsiento;
        }

        public bool InsertarAsientoZona(List<Asiento> listaAsientos, Zona zona)
        {
            String sql = "INSERT INTO TH_ASIENTO_ZONA(IdAsiento, IdZona, Disponible, FechaCrea,UserCrea) " +
                            "VALUES(@idAsiento, @idZona,'S', @fechaCrea, @usuarioCrea)";

                UtilDA.ExecuteBeginTransaction(cmd, cnx);
                foreach (Asiento asiento in listaAsientos)
                {
                    OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, asiento.IdAsiento);
                    OleDbParameter pIdZona = UtilDA.SetParameters("@idZona", OleDbType.Integer, zona.IdZona);
                    OleDbParameter pFechaCreacion = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                    OleDbParameter pUsuarioCreacion = UtilDA.SetParameters("@usuarioCrea", OleDbType.VarChar, Sesion.usuario.Login);
                    if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, true, pIdAsiento, pIdZona, pFechaCreacion, pUsuarioCreacion))
                    {
                        UtilDA.ExecuteRollback(cmd, cnx);
                        return false;
                    }
                }
            UtilDA.ExecuteCommit(cmd, cnx);
            return true;
        }
    }
}