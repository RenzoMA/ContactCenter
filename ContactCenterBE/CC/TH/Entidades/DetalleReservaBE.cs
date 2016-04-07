using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class DetalleReservaBE : BaseEntity
    {
        public int IdDetalleReserva { get; set; }
        public Single Precio { get; set; }
        public string Estado { get; set; }
        public AsientoBE Asiento { get; set; }

    }
}
