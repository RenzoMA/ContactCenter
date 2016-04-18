using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;


namespace ContactCenterBE.CC.Entidades.AplicacionBE
{
    public class Aplicacion : BaseEntity
    {
        public int IdAplicacion { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
    }
}
