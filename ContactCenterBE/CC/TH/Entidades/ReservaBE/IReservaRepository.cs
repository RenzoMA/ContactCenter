using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public interface IReservaRepository : IBaseRepository<Reserva>
    {
        List<Reserva> ReporteReservas(int idTeatro, DateTime fecha);
        List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin);
        bool CancelarReserva(int idReserva);
    }
}
