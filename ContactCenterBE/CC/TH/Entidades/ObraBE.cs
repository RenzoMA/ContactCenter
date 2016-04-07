using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class ObraBE : BaseEntity
    {
        public int IdObra { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Single Precio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public TeatroBE Teatro { get; set; }
}
}
