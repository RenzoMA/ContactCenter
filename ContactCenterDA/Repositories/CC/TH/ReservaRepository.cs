using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
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
            string sql = "INSERT INTO TH_RESERVA (FECHARESERVA,HORARIO,idEstadoReserva,idObra,idFuncion,idCliente,idUsuario,idPromocion,NombrePromocion,FechaCrea,userCrea,PrecioTotal) " +
                         "values(@fechaReserva,@horario,@idEstadoReserva,@idObra,@idFuncion,@idCliente,@idUsuario,@idPromocion,@nombrePromocion,@fechaCrea,@userCrea,@PrecioTotal)";

            OleDbParameter pFechaReserva = UtilDA.SetParameters("@fechaReserva", OleDbType.Date, datos.FechaReserva);
            OleDbParameter pHorario = UtilDA.SetParameters("@horario", OleDbType.VarChar, datos.Horario);
            OleDbParameter pEstadoReserva = UtilDA.SetParameters("@idEstadoReserva", OleDbType.Integer, 1);
            OleDbParameter pIdObra = UtilDA.SetParameters("@idObra", OleDbType.Integer, datos.Funcion.Obra.IdObra);
            OleDbParameter pIdFuncion = UtilDA.SetParameters("@idFuncion", OleDbType.Integer, datos.Funcion.IdFuncion);
            OleDbParameter pIdCliente = UtilDA.SetParameters("@idCliente", OleDbType.VarChar, datos.Cliente.IdCliente);
            OleDbParameter pIdUsuario = UtilDA.SetParameters("@idUsuario", OleDbType.Integer, datos.Usuario.IdUsuario);
            OleDbParameter pPromocion = UtilDA.SetParameters("@idPromocion", OleDbType.Integer, 1);
            OleDbParameter pNombrePromo = UtilDA.SetParameters("@nombrePromocion", OleDbType.VarChar, "N/A");
            OleDbParameter pFechaCrea = UtilDA.SetParameters("@fechaCrea", OleDbType.Date, DateTime.Now);
            OleDbParameter pUserCrea = UtilDA.SetParameters("@userCrea", OleDbType.VarChar, Sesion.usuario.Login);
            OleDbParameter pTotal = UtilDA.SetParameters("@PrecioTotal", OleDbType.Single, datos.PrecioTotal);

            int id = UtilDA.ExecuteNonQueryTransactionId(cmd, CommandType.Text, sql, cnx, pFechaReserva, pHorario, pEstadoReserva, pIdObra, pIdFuncion, pIdCliente,
                pIdUsuario, pPromocion, pNombrePromo, pFechaCrea, pUserCrea, pTotal);

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

                if (!UtilDA.ExecuteNonQueryTransactionDetalle(cmd, sqlDetalle, pIdReserva, pPrecio, pEstado, pIdAsiento, pFechaCrea2, pUserCrea2))
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
    }
}
