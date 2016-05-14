﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public class BusquedaReserva : Reserva
    {
        public string nombreObra { get { return Obra.Nombre; } }
        public string nombreCliente { get { return Cliente.Nombre + " " + Cliente.ApellidoPaterno + " " + Cliente.Apellidomaterno; } }
        public string estadoReserva { get { return EstadoReserva.Nombre; } }
    }
}
