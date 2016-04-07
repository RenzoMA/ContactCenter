using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;


namespace ContactCenterBE.CC.Entidades
{
    public class AplicacionBE : BaseEntity
    {
        public int IdAplicacion { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Correo { get; set; }
    }
}
