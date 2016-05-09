using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterBE.CC.TH.Entidades.ObraBE
{
    [Serializable]
    public class Obra : BaseEntity
    {
        public int IdObra { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public Teatro Teatro { get; set; }
}
}
