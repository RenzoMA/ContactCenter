using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class TipoPromocionBE : BaseEntity
    {
        public int IdTipoPromocion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
