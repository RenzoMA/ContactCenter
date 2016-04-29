using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Drawing;

namespace ContactCenterBE.CC.TH.Entidades.AsientoBE
{
    public class Asiento : BaseEntity
    {
        public int IdAsiento { get; set; }
        public string Descripcion { get; set; }
        public string Fila { get; set; }
        public string Disponible { get; set; }
        public Zona Zona { get; set; }
        public string EstadoTemporal { get; set; }
        public Color ColorTemporal { get; set; }
    }
}
