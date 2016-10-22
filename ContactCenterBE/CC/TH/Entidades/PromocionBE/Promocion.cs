using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;

namespace ContactCenterBE.CC.TH.Entidades.PromocionBE
{
    [Serializable]
    public class Promocion : BaseEntity
    {
        public int IdPromocion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public TipoPromocion TipoPromocion { get; set; }
        public List<PromocionZona> PromocionZonas { get; set; }
        public List<PromocionFuncion> PromocionFunciones { get; set; }
        public bool RequiereEmpresa { get; set; }

    }
}
