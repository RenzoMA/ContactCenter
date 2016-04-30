using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public class DetalleReserva : BaseEntity
    {
        public int IdDetalleReserva { get; set; }
        public Single Precio { get; set; }
        public string Estado { get; set; }
        public AsientoPrecio Asiento { get; set; }

    }
}
