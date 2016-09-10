using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using System.Drawing;

namespace ContactCenterBE.CC.TH.Entidades.AsientoBE
{
    public class Asiento : BaseEntity
    {
        public int IdAsiento { get; set; }
        public string Descripcion { get; set; }
        public string Fila { get; set; }
        public string DescripcionFila { get { return "Fila: "+ Fila +" - "+ "Asiento: "+Descripcion; } }
        public Teatro Teatro { get; set; }
        public string EstadoTemporal { get; set; }
        public Color ColorTemporal { get; set; }
        public List<AsientoZona> AsientoZona { get; set; }
    }
}
