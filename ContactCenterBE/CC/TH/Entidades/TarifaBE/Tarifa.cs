using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.Base;


namespace ContactCenterBE.CC.TH.Entidades.TarifaBE
{
    public class Tarifa : BaseEntity
    {
        public int IdTarifa { get; set; }

        public Zona Zona {get; set;}

        public Obra Obra { get; set; }

        public Single Precio { get; set; }
    }
}
