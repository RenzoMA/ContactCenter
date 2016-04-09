using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ZonaBE
{
    public class Zona : BaseEntity
    {
        public int IdZona { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public Teatro Teatro { get; set; }
    }
}
