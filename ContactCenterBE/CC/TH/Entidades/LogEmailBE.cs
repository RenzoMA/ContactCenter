using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class LogEmailBE : BaseEntity
    {
        public int IdLog { get; set; }
        public string CorreoOrigen { get; set; }
        public string CorreoDestino { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
        public ReservaBE Reserva { get; set; }
    }
}
