using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class AsientoBE : BaseEntity
    {
        public int IdAsiento { get; set; }
        public string Descripcion { get; set; }
        public string Fila { get; set; }
        public string Disponible { get; set; }
        public ZonaBE Zona { get; set; }
    }
}
