using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public class ReservaObra : Reserva
    {
        public int CantidadReservas { get; set; }
        public String NombreObra { get; set; }
    }
}
