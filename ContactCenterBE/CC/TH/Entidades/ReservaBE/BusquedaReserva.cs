using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public class BusquedaReserva : Reserva
    {
        public string nombreObra { get { return Obra.Nombre; } }
        public string estadoReserva { get { return EstadoReserva.Nombre; } }
        public string Correo { get { return CorreoCliente; } }
        public string Telefono { get { return Cliente.Telefono; } }
    }
}
