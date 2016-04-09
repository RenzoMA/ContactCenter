using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public class EstadoReserva : BaseEntity
    {
        public int IdEstadoReserva { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}
