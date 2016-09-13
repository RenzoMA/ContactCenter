using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IReservaService
    {
        bool InsertarReserva(Reserva reserva,Cliente cliente);
        List<DetalleReserva> ReporteReservas(int idTeatro, DateTime fecha, DateTime fechaFin);
        List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin);
        bool CancelarReserva(int idReserva);
        List<ReservaObra> ReporteReservaObra(DateTime fechaInicio, DateTime fechaFin);
        bool CargaMasiva(string path);
    }
}
