using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;

namespace ContactCenterBE.CC.TH.Entidades.LogEmailBE
{
    public class LogEmail : BaseEntity
    {
        public int IdLog { get; set; }
        public string CorreoDestino { get; set; }
        public string CorreoDestinoCC { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Mensaje { get; set; }
        public string Asunto { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int Intento { get;  set;} 
        public int IdObra { get; set; }
    }
}
