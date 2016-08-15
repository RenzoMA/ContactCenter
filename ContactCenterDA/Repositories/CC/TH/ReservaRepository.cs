using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;
using ContactCenterCommon;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class ReservaRepository : IReservaRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Reserva GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Reserva> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Reserva datos)
        {
            string sql = "INSERT INTO TH_RESERVA (FECHARESERVA,HORARIO,idEstadoReserva,idObra,idFuncion,idCliente,idUsuario,idPromocion,NombrePromocion,FechaCrea,userCrea,PrecioTotal,Asientos) " +
                         "values(@fechaReserva,@horario,@idEstadoReserva,@idObra,@idFuncion,@idCliente,@idUsuario,@idPromocion,@nombrePromocion,@fechaCrea,@userCrea,@PrecioTotal,@Asientos)";

            OleDbParameter pFechaReserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date, datos.FechaReserva);
            OleDbParameter pHorario = UtilDA.SetParameters("@horario", OleDbType.VarChar, datos.Horario);
            OleDbParameter pEstadoReserva = UtilDA.SetParameters("@idEstadoReserva", OleDbType.Integer, 1);
            OleDbParameter pIdObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.Funcion.Obra.IdObra);
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, datos.Funcion.IdFuncion);
            OleDbParameter pIdCliente = UtilDA.SetParameters("@idCliente", OleDbType.VarChar, datos.Cliente.IdCliente);
            OleDbParameter pIdUsuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, datos.Usuario.IdUsuario);
            OleDbParameter pPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, datos.Promocion == null ? 0 : datos.Promocion.IdPromocion);
            OleDbParameter pNombrePromo = UtilDA.SetParameters("@nombrePromocion", OleDbType.VarChar, datos.Promocion == null ? "" : datos.Promocion.Descripcion);
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pTotal = UtilDA.SetParameters("@PrecioTotal", OleDbType.Single, datos.PrecioTotal);
            OleDbParameter pAsientos = UtilDA.SetParameters("@Asientos", OleDbType.VarChar, datos.Asientos);

            string asientos = "";
            datos.ListaDetalles.ForEach(tx => {
                asientos += tx.Asiento.IdAsiento+",";
            });
            asientos = asientos.Substring(0, asientos.Length - 1);

            String ValidaRegistroAsientos = "SELECT R.IDRESERVA FROM TH_RESERVA R INNER JOIN TH_DETALLE_RESERVA DR ON DR.IDRESERVA = R.IDRESERVA WHERE R.IDESTADORESERVA = 1 AND R.FECHARESERVA = @fechaReserva AND R.IDFUNCION = @idFuncion AND DR.IDASIENTO IN (" + asientos + ")";

            UtilDA.ExecuteBeginTransaction(cmd, cnx);

            using (var dtr = UtilDA.ExecuteSubReader(cmd, CommandType.Text, ValidaRegistroAsientos, cnx, pFechaReserva, pIdFuncion))
            {
                if (dtr.HasRows)
                {
                    dtr.Close();
                    UtilDA.ExecuteRollback(cmd, cnx);
                    return false;
                }
            }

                int id = UtilDA.ExecuteNonQueryGetId(cmd, CommandType.Text, sql, cnx, true, pFechaReserva, pHorario, pEstadoReserva, pIdObra, pIdFuncion, pIdCliente,
                    pIdUsuario, pPromocion, pNombrePromo, pFechaCrea, pUserCrea, pTotal, pAsientos);

            string sqlDetalle = "INSERT INTO TH_DETALLE_RESERVA (idReserva,Precio,Estado,idAsiento,FechaCrea,UserCrea) " +
                                "VALUES (@idReserva,@precio,@estado,@idAsiento,@fechaCrea,@userCrea)";

            foreach (DetalleReserva det in datos.ListaDetalles)
            {
                OleDbParameter pIdReserva = UtilDA.SetParameters("@idReserva", OleDbType.Integer, id);
                OleDbParameter pPrecio = UtilDA.SetParameters("@precio", OleDbType.Single, det.Precio);
                OleDbParameter pEstado = UtilDA.SetParameters("@estado", OleDbType.VarChar, "A");
                OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, det.Asiento.IdAsiento);
                OleDbParameter pFechaCrea2 = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                OleDbParameter pUserCrea2 = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);

                if (!UtilDA.ExecuteNonQuery(cmd,CommandType.Text, sqlDetalle,cnx, true, pIdReserva, pPrecio, pEstado, pIdAsiento, pFechaCrea2, pUserCrea2))
                {
                    UtilDA.ExecuteRollback(cmd,cnx);
                    return false;
                }
            }
            UtilDA.ExecuteCommit(cmd, cnx);
            return true;

        }

        public bool Update(Reserva datos)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ReporteReservas(int idTeatro, DateTime fecha)
        {
            List<Reserva> listaReserva = new List<Reserva>();
            Reserva reserva = null;

            string sql = "SELECT * FROM (((TH_RESERVA R INNER JOIN TH_OBRA O ON O.IDOBRA = R.IDOBRA) INNER JOIN TH_FUNCION F ON F.IDFUNCION = R.IDFUNCION) INNER JOIN TH_CLIENTE C ON C.IDCLIENTE = R.IDCLIENTE) INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro AND R.FechaReserva = @FechaReserva AND IdEstadoReserva = 1 ORDER BY C.Nombre ASC";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            OleDbParameter pFecha = UtilDA.SetParameters("@FechaReserva", OleDbType.Date, fecha);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx,pIdTeatro,pFecha))
            {
                while (dtr.Read())
                {
                    reserva = new Reserva()
                    {
                        IdReserva = DataConvert.ToInt(dtr["IdReserva"]),
                        FechaReserva = DataConvert.ToDateTime(dtr["FechaReserva"]),
                        Horario = DataConvert.ToString(dtr["R.Horario"]),
                        NombrePromocion = DataConvert.ToString(dtr["NombrePromocion"]),
                        PrecioTotal = DataConvert.ToSingle(dtr["PrecioTotal"]),
                        Asientos = DataConvert.ToString(dtr["Asientos"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["R.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["R.UserCrea"]),

                        Obra = new Obra()
                        {
                            IdObra = DataConvert.ToInt(dtr["O.IdObra"]),
                            Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                        },
                        Cliente = new Cliente()
                        {
                            IdCliente = DataConvert.ToInt(dtr["C.IdCliente"]),
                            Nombre = DataConvert.ToString(dtr["C.Nombre"]) + " " + DataConvert.ToString(dtr["ApePaterno"]) + " " + DataConvert.ToString(dtr["ApeMaterno"])
                        }
                    };
                    listaReserva.Add(reserva);
                }
            }
            UtilDA.Close(cnx);
            return listaReserva;
        }

        public List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio, DateTime fechaFin)
        {
            List<BusquedaReserva> listaReserva = new List<BusquedaReserva>();
            BusquedaReserva reserva = null;

             string sql = "SELECT * FROM (((TH_RESERVA R INNER JOIN TH_CLIENTE C ON R.IDCLIENTE = C.IDCLIENTE) INNER JOIN TH_OBRA O ON O.IDOBRA = R.IDOBRA) INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO) INNER JOIN TH_ESTADO_RESERVA ER ON ER.IDESTADORESERVA = R.IDESTADORESERVA WHERE (C.NOMBRE + APEPATERNO + APEMATERNO + TELEFONO) LIKE '%' & @busqueda & '%' AND FECHARESERVA BETWEEN @fecha AND @fechaFin";

            OleDbParameter pNombrePhone = UtilDA.SetParameters("@busqueda", OleDbType.VarChar, nombrePhone);
            OleDbParameter pFecha = UtilDA.SetParameters("@fecha", OleDbType.Date, fechaInicio);
            OleDbParameter pFechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.Date, fechaFin);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pNombrePhone, pFecha,pFechaFin))
            {
                while (dtr.Read())
                {
                    reserva = new BusquedaReserva()
                    {
                        IdReserva = DataConvert.ToInt(dtr["IdReserva"]),
                        FechaReserva = DataConvert.ToDateTime(dtr["FechaReserva"]),
                        Horario = DataConvert.ToString(dtr["Horario"]),
                        EstadoReserva = new EstadoReserva()
                        {
                            IdEstadoReserva = DataConvert.ToInt(dtr["ER.IdEstadoReserva"]),
                            Nombre = DataConvert.ToString(dtr["ER.Nombre"]),
                            Estado = DataConvert.ToString(dtr["ER.Estado"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["ER.FechaCrea"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["ER.UserCrea"]),
                        },
                        Obra = new Obra()
                        {
                            IdObra = DataConvert.ToInt(dtr["O.IdObra"]),
                            Nombre = DataConvert.ToString(dtr["O.Nombre"])
                        },
                        Cliente = new Cliente()
                        {
                            IdCliente = DataConvert.ToInt(dtr["C.IdCliente"]),
                            Nombre = DataConvert.ToString(dtr["C.Nombre"]),
                            ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]),
                            Apellidomaterno = DataConvert.ToString(dtr["ApeMaterno"]),
                            Telefono = DataConvert.ToString(dtr["Telefono"]),
                            Correo = DataConvert.ToString(dtr["Correo"]),
                            DNI = DataConvert.ToString(dtr["DNI"])
                        },
                        NombrePromocion = DataConvert.ToString(dtr["NombrePromocion"]),
                        Asientos = DataConvert.ToString(dtr["Asientos"]),
                        PrecioTotal = DataConvert.ToSingle(dtr["PrecioTotal"])
                    };
                    listaReserva.Add(reserva);
                }
            }


            UtilDA.Close(cnx);
            return listaReserva;
        }

        public bool CancelarReserva(int idReserva)
        {
            string sql = "UPDATE TH_RESERVA SET IdEstadoReserva = 2,FechaMod = @fechaMod, UserMod = @userMod WHERE IdReserva = @idReserva";


            OleDbParameter pFechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Today);
            OleDbParameter pUserMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pIdReserva = UtilDA.SetParameters("@idReserva", OleDbType.Integer, idReserva);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pFechaMod, pUserMod, pIdReserva);
        }


        //Reporte Cantidad de reservas por obra entre dos fechas
        public List<ReservaObra> ReporteReservaObra(DateTime fechaInicio, DateTime fechaFin, int idObra )
        {
            List<ReservaObra> listaReservaObra = new List<ReservaObra>();

            String sql = "SELECT O.Nombre AS NombreO, COUNT(*) AS TotalR from TH_RESERVA R INNER JOIN TH_OBRA O ON R.IdObra = O.IdObra where R.IdEstadoReserva <> 2 and R.FechaReserva BETWEEN @FechaIni AND @FechaFin AND R.IdObra = @idObra GROUP BY O.Nombre";

            OleDbParameter pFechaInicio = UtilDA.SetParameters("@FechaIni", OleDbType.Date, fechaInicio);
            OleDbParameter pFechaFin = UtilDA.SetParameters("@FechaFin", OleDbType.Date, fechaFin);
            OleDbParameter pObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, idObra);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pFechaInicio, pFechaFin, pObra))
            {
                while (dtr.Read())
                {
                    ReservaObra objReservaObra = new ReservaObra();
                    objReservaObra.NombreObra = DataConvert.ToString(dtr["NombreO"]);
                    objReservaObra.CantidadReservas = DataConvert.ToInt(dtr["TotalR"]);

                    listaReservaObra.Add(objReservaObra);
                }
            }
            UtilDA.Close(cnx);
            return listaReservaObra;
        }




    }
}
