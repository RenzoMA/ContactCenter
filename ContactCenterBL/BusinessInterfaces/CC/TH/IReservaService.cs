using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.Entidades.CLienteBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IReservaService
    {
        bool InsertarReserva(Reserva reserva,Cliente cliente);
    }
}
