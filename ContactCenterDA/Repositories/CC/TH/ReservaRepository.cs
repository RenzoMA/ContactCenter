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
            string sql = "INSERT INTO TH_RESERVA (FECHARESERVA,HORARIO,idEstadoReserva,idObra,idFuncion,idCliente,idUsuario,NombrePromocion,FechaCrea,userCrea,PrecioTotal,Asientos,NombreCliente,Empresa) " +
                         "values(@fechaReserva,@horario,@idEstadoReserva,@idObra,@idFuncion,@idCliente,@idUsuario,@nombrePromocion,@fechaCrea,@userCrea,@PrecioTotal,@Asientos,@NombreCliente,@Empresa)";

            OleDbParameter pFechaReserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date, datos.FechaReserva);
            OleDbParameter pHorario = UtilDA.SetParameters("@horario", OleDbType.VarChar, datos.Horario);
            OleDbParameter pEstadoReserva = UtilDA.SetParameters("@idEstadoReserva", OleDbType.Integer, 1);
            OleDbParameter pIdObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.Funcion.Obra.IdObra);
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, datos.Funcion.IdFuncion);
            OleDbParameter pIdCliente = UtilDA.SetParameters("@idCliente", OleDbType.VarChar, datos.Cliente.IdCliente);
            OleDbParameter pIdUsuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, datos.Usuario.IdUsuario);
            OleDbParameter pNombrePromo = UtilDA.SetParameters("@nombrePromocion", OleDbType.VarChar, DataConvert.ToString(datos.NombrePromocion));
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pTotal = UtilDA.SetParameters("@PrecioTotal", OleDbType.Single, datos.PrecioTotal);
            OleDbParameter pAsientos = UtilDA.SetParameters("@Asientos", OleDbType.VarChar, datos.Asientos);
            OleDbParameter pNombreCliente = UtilDA.SetParameters("@NombreCliente", OleDbType.VarChar, datos.Cliente.ApellidoPaterno + " "+datos.Cliente.Apellidomaterno+ " "+datos.Cliente.Nombre);
            OleDbParameter pEmpresa = UtilDA.SetParameters("@Empresa", OleDbType.VarChar, datos.Empresa);

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
                    pIdUsuario, pNombrePromo, pFechaCrea, pUserCrea, pTotal, pAsientos, pNombreCliente, pEmpresa);

            string sqlDetalle = "INSERT INTO TH_DETALLE_RESERVA (idReserva,Precio,Estado,idAsiento,FechaCrea,UserCrea,NombreZona,NombreFila,NombreAsiento,NombrePromocion) " +
                                "VALUES (@idReserva,@precio,@estado,@idAsiento,@fechaCrea,@userCrea,@NombreZona,@NombreFila,@NombreAsiento,@NombrePromocion)";

            foreach (DetalleReserva det in datos.ListaDetalles)
            {
                OleDbParameter pIdReserva = UtilDA.SetParameters("@idReserva", OleDbType.Integer, id);
                OleDbParameter pPrecio = UtilDA.SetParameters("@precio", OleDbType.Single, det.Precio);
                OleDbParameter pEstado = UtilDA.SetParameters("@estado", OleDbType.VarChar, "A");
                OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, det.Asiento.IdAsiento);
                OleDbParameter pFechaCrea2 = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                OleDbParameter pUserCrea2 = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
                OleDbParameter pNombreZona = UtilDA.SetParameters("@NombreZona", OleDbType.VarChar, det.NombreZona);
                OleDbParameter pNombreFila = UtilDA.SetParameters("@NombreFila", OleDbType.VarChar, det.NombreFila);
                OleDbParameter pNombreAsiento = UtilDA.SetParameters("@NombreAsiento", OleDbType.VarChar, det.NombreAsiento);
                OleDbParameter pNombrePromocion = UtilDA.SetParameters("@NombrePromocion", OleDbType.VarChar, DataConvert.ToString(det.NombrePromocion));

                if (!UtilDA.ExecuteNonQuery(cmd,CommandType.Text, sqlDetalle,cnx, true, pIdReserva, pPrecio, pEstado, pIdAsiento, pFechaCrea2, pUserCrea2,pNombreZona,pNombreFila,pNombreAsiento, pNombrePromocion))
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

        public List<Reserva> ReporteReservas(int idTeatro, DateTime fecha,DateTime fechaFin)
        {
            List<Reserva> listaReserva = new List<Reserva>();
            Reserva reserva = null;

            string sql = "SELECT * FROM (((TH_RESERVA R INNER JOIN TH_OBRA O ON O.IDOBRA = R.IDOBRA) INNER JOIN TH_FUNCION F ON F.IDFUNCION = R.IDFUNCION) INNER JOIN TH_CLIENTE C ON C.IDCLIENTE = R.IDCLIENTE) INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro AND IdEstadoReserva = 1 AND R.FechaReserva between @FechaReserva and @fechaFin ORDER BY C.Nombre ASC";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            OleDbParameter pFecha = UtilDA.SetParameters("@FechaReserva", OleDbType.Date, fecha);
            OleDbParameter pFechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.Date, fechaFin);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx,pIdTeatro, pFecha, pFechaFin))
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
                        NombreCliente = DataConvert.ToString(dtr["NombreCliente"]),
                        Empresa = DataConvert.ToString(dtr["Empresa"]),
                        Obra = new Obra()
                        {
                            IdObra = DataConvert.ToInt(dtr["O.IdObra"]),
                            Nombre = DataConvert.ToString(dtr["O.Nombre"]),
                        },
                        Cliente = new Cliente()
                        {
                            IdCliente = DataConvert.ToInt(dtr["C.IdCliente"]),
                            Nombre = DataConvert.ToString(dtr["C.Nombre"]),
                            ApellidoPaterno = DataConvert.ToString(dtr["ApePaterno"]),
                            Apellidomaterno = DataConvert.ToString(dtr["ApeMaterno"])
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
                        NombreCliente = DataConvert.ToString(dtr["NombreCliente"]),
                        Empresa = DataConvert.ToString(dtr["Empresa"]),
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
                            Correo = DataConvert.ToString(dtr["Correo"])
                        },
                        NombrePromocion = DataConvert.ToString(dtr["NombrePromocion"]),
                        Asientos = DataConvert.ToString(dtr["Asientos"]),
                        PrecioTotal = DataConvert.ToSingle(dtr["PrecioTotal"]),
                        FechaCreacion = DataConvert.ToDateTime(dtr["R.FechaCrea"]),
                        UsuarioCreacion = DataConvert.ToString(dtr["R.UserCrea"]),
                        FechaModificacion = DataConvert.ToDateTime(dtr["R.FechaMod"]),
                        UsuarioModificacion = DataConvert.ToString(dtr["R.UserMod"])
                        
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


            OleDbParameter pFechaMod = UtilDA.SetParameters("@fechaMod", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserMod = UtilDA.SetParameters("@userMod", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pIdReserva = UtilDA.SetParameters("@idReserva", OleDbType.Integer, idReserva);

            return UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sql, cnx, false, pFechaMod, pUserMod, pIdReserva);
        }


        //Reporte Cantidad de reservas por obra entre dos fechas
        public List<ReservaObra> ReporteReservaObra(DateTime fechaInicio, DateTime fechaFin )
        {
            List<ReservaObra> listaReservaObra = new List<ReservaObra>();

            String sql = "SELECT O.Nombre AS NombreO, COUNT(*) AS TotalR from TH_RESERVA R INNER JOIN TH_OBRA O ON R.IdObra = O.IdObra where R.IdEstadoReserva <> 2 and R.FechaReserva BETWEEN @FechaIni AND @FechaFin GROUP BY O.Nombre";

            OleDbParameter pFechaInicio = UtilDA.SetParameters("@FechaIni", OleDbType.Date, fechaInicio);
            OleDbParameter pFechaFin = UtilDA.SetParameters("@FechaFin", OleDbType.Date, fechaFin);
            

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pFechaInicio, pFechaFin))
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

        public bool InsertMasivo(List<Reserva> listaReserva)
        {
            UtilDA.ExecuteBeginTransaction(cmd, cnx);
            foreach (Reserva datos in listaReserva)
            {
                string sql = "INSERT INTO TH_RESERVA (FECHARESERVA,HORARIO,idEstadoReserva,idObra,idFuncion,idCliente,idUsuario,NombrePromocion,FechaCrea,userCrea,PrecioTotal,Asientos,NombreCliente,Empresa) " +
                             "values(@fechaReserva,@horario,@idEstadoReserva,@idObra,@idFuncion,@idCliente,@idUsuario,@nombrePromocion,@fechaCrea,@userCrea,@PrecioTotal,@Asientos,@NombreCliente,@Empresa)";

                OleDbParameter pFechaReserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date, datos.FechaReserva);
                OleDbParameter pHorario = UtilDA.SetParameters("@horario", OleDbType.VarChar, datos.Horario);
                OleDbParameter pEstadoReserva = UtilDA.SetParameters("@idEstadoReserva", OleDbType.Integer, 1);
                OleDbParameter pIdObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.Funcion.Obra.IdObra);
                OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, datos.Funcion.IdFuncion);
                OleDbParameter pIdCliente = UtilDA.SetParameters("@idCliente", OleDbType.VarChar, datos.Cliente.IdCliente);
                OleDbParameter pIdUsuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, datos.Usuario.IdUsuario);
                OleDbParameter pNombrePromo = UtilDA.SetParameters("@nombrePromocion", OleDbType.VarChar, DataConvert.ToString(datos.NombrePromocion));
                OleDbParameter pFechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                OleDbParameter pUserCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, datos.UsuarioCreacion);
                OleDbParameter pTotal = UtilDA.SetParameters("@PrecioTotal", OleDbType.Single, datos.PrecioTotal);
                OleDbParameter pAsientos = UtilDA.SetParameters("@Asientos", OleDbType.VarChar, datos.Asientos);
                OleDbParameter pNombreCliente = UtilDA.SetParameters("@NombreCliente", OleDbType.VarChar, datos.Cliente.ApellidoPaterno + " " + datos.Cliente.Apellidomaterno + " " + datos.Cliente.Nombre);
                OleDbParameter pEmpresa = UtilDA.SetParameters("@Empresa", OleDbType.VarChar, datos.Empresa);

                string asientos = "";
                datos.ListaDetalles.ForEach(tx =>
                {
                    asientos += tx.Asiento.IdAsiento + ",";
                });
                asientos = asientos.Substring(0, asientos.Length - 1);

                String ValidaRegistroAsientos = "SELECT R.IDRESERVA FROM TH_RESERVA R INNER JOIN TH_DETALLE_RESERVA DR ON DR.IDRESERVA = R.IDRESERVA WHERE R.IDESTADORESERVA = 1 AND R.FECHARESERVA = @fechaReserva AND R.IDFUNCION = @idFuncion AND DR.IDASIENTO IN (" + asientos + ")";

                

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
                    pIdUsuario, pNombrePromo, pFechaCrea, pUserCrea, pTotal, pAsientos, pNombreCliente, pEmpresa);

                string sqlDetalle = "INSERT INTO TH_DETALLE_RESERVA (idReserva,Precio,Estado,idAsiento,FechaCrea,UserCrea,NombreZona,NombreFila,NombreAsiento,NombrePromocion) " +
                                    "VALUES (@idReserva,@precio,@estado,@idAsiento,@fechaCrea,@userCrea,@NombreZona,@NombreFila,@NombreAsiento,@NombrePromocion)";

                foreach (DetalleReserva det in datos.ListaDetalles)
                {
                    OleDbParameter pIdReserva = UtilDA.SetParameters("@idReserva", OleDbType.Integer, id);
                    OleDbParameter pPrecio = UtilDA.SetParameters("@precio", OleDbType.Single, det.Precio);
                    OleDbParameter pEstado = UtilDA.SetParameters("@estado", OleDbType.VarChar, "A");
                    OleDbParameter pIdAsiento = UtilDA.SetParameters("@idAsiento", OleDbType.Integer, det.Asiento.IdAsiento);
                    OleDbParameter pFechaCrea2 = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
                    OleDbParameter pUserCrea2 = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
                    OleDbParameter pNombreZona = UtilDA.SetParameters("@NombreZona", OleDbType.VarChar, det.NombreZona);
                    OleDbParameter pNombreFila = UtilDA.SetParameters("@NombreFila", OleDbType.VarChar, det.NombreFila);
                    OleDbParameter pNombreAsiento = UtilDA.SetParameters("@NombreAsiento", OleDbType.VarChar, det.NombreAsiento);
                    OleDbParameter pNombrePromocion = UtilDA.SetParameters("@NombreAsiento", OleDbType.VarChar, DataConvert.ToString(det.NombrePromocion));

                    if (!UtilDA.ExecuteNonQuery(cmd, CommandType.Text, sqlDetalle, cnx, true, pIdReserva, pPrecio, pEstado, pIdAsiento, pFechaCrea2, pUserCrea2, pNombreZona,pNombreFila,pNombreAsiento, pNombrePromocion))
                    {
                        UtilDA.ExecuteRollback(cmd, cnx);
                        return false;
                    }
                }
                
            }
            UtilDA.ExecuteCommit(cmd, cnx);
            return true;
        }

        public Reserva ReservaExiste(DateTime fechaReserva, int idFuncion, int idCliente)
        {
            Reserva reserva = null;
            string sql = "SELECT * FROM TH_RESERVA WHERE FechaReserva = @fechaReserva AND IdFuncion = @idFuncion AND IdCliente = @idCliente AND IdEstadoReserva = 1";
            OleDbParameter pFechaReserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date, fechaReserva);
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, idFuncion);
            OleDbParameter pIdCliente = UtilDA.SetParameters("@idCliente", OleDbType.Integer, idCliente);
            
            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pFechaReserva, pIdFuncion, pIdCliente))
            {
                while (dtr.Read())
                {
                    reserva = new Reserva()
                    {
                        IdReserva = DataConvert.ToInt(dtr["IdReserva"])
                    };
                }
            }
            UtilDA.Close(cnx);
            return reserva;
        }

        public List<DetalleReserva> ReporteReservasDetallado(int idTeatro, DateTime fechaInicio, DateTime fechaFin)
        {
            List<DetalleReserva> listaDetalle = new List<DetalleReserva>();
            DetalleReserva detalle = null;
            //string sql = "SELECT * FROM (((TH_RESERVA R INNER JOIN TH_OBRA O ON O.IDOBRA = R.IDOBRA) INNER JOIN TH_FUNCION F ON F.IDFUNCION = R.IDFUNCION) INNER JOIN TH_CLIENTE C ON C.IDCLIENTE = R.IDCLIENTE) INNER JOIN TH_TEATRO T ON T.IDTEATRO = O.IDTEATRO WHERE T.IDTEATRO = @IdTeatro AND IdEstadoReserva = 1 AND R.FechaReserva between @FechaReserva and @fechaFin ORDER BY C.Nombre ASC";
            string sql = "SELECT * FROM ((TH_DETALLE_RESERVA DR INNER JOIN TH_RESERVA R ON R.IDRESERVA = DR.IDRESERVA) INNER JOIN TH_OBRA O ON O.IDOBRA = R.IDOBRA) INNER JOIN TH_CLIENTE C ON C.IDCLIENTE = R.IDCLIENTE WHERE R.IDESTADORESERVA = 1  AND O.IDTEATRO = @IdTeatro AND R.FechaReserva between @FechaReserva and @fechaFin ORDER BY R.FechaReserva,C.ApePaterno, C.ApeMaterno, C.Nombre ;";

            OleDbParameter pIdTeatro = UtilDA.SetParameters("@IdTeatro", OleDbType.Integer, idTeatro);
            OleDbParameter pFecha = UtilDA.SetParameters("@FechaReserva", OleDbType.Date, fechaInicio);
            OleDbParameter pFechaFin = UtilDA.SetParameters("@fechaFin", OleDbType.Date, fechaFin);

            using (var dtr = UtilDA.ExecuteReader(cmd, CommandType.Text, sql, cnx, pIdTeatro, pFecha, pFechaFin))
            {
                while (dtr.Read())
                {
                    detalle = new DetalleReserva()
                    {
                        IdDetalleReserva = DataConvert.ToInt(dtr["IdDetalleReserva"]),
                        Precio = DataConvert.ToSingle(dtr["Precio"]),
                        NombreZona = DataConvert.ToString(dtr["NombreZona"]),
                        NombreFila = DataConvert.ToString(dtr["NombreFila"]),
                        NombreAsiento = DataConvert.ToString(dtr["NombreAsiento"]),
                        NombrePromocion = DataConvert.ToString(dtr["DR.NombrePromocion"]),
                        Reserva = new Reserva()
                        {
                            IdReserva = DataConvert.ToInt(dtr["R.IdReserva"]),
                            FechaReserva = DataConvert.ToDateTime(dtr["FechaReserva"]),
                            Horario = DataConvert.ToString(dtr["Horario"]),
                            NombrePromocion = DataConvert.ToString(dtr["R.NombrePromocion"]),
                            PrecioTotal = DataConvert.ToSingle(dtr["PrecioTotal"]),
                            Asientos = DataConvert.ToString(dtr["Asientos"]),
                            FechaCreacion = DataConvert.ToDateTime(dtr["R.FechaCrea"]),
                            UsuarioCreacion = DataConvert.ToString(dtr["R.UserCrea"]),
                            NombreCliente = DataConvert.ToString(dtr["NombreCliente"]),
                            Empresa = DataConvert.ToString(dtr["Empresa"]),
                            Obra = new Obra()
                            {
                                IdObra = DataConvert.ToInt(dtr["O.IdObra"]),
                                Nombre = DataConvert.ToString(dtr["O.Nombre"])
                            },
                            Cliente = new Cliente()
                            {
                                Nombre = DataConvert.ToString(dtr["ApePaterno"]) + " " + DataConvert.ToString(dtr["ApeMaterno"]) + " " + DataConvert.ToString(dtr["C.Nombre"])
                            }
                        }
                        
                        
                    };
                    listaDetalle.Add(detalle);
                }
            }
            UtilDA.Close(cnx);
            return listaDetalle;
        }
    }
}
