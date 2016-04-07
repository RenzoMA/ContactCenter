using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class PromocionBE : BaseEntity
    {
        public int IdPromocion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public FuncionBE Funcion { get; set; }
        public TipoPromocionBE TipoPromocion { get; set; }

    }
}
