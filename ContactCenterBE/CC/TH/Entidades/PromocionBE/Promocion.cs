using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;

namespace ContactCenterBE.CC.TH.Entidades.PromocionBE
{
    public class Promocion : BaseEntity
    {
        public int IdPromocion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Funcion Funcion { get; set; }
        public TipoPromocion TipoPromocion { get; set; }

    }
}
