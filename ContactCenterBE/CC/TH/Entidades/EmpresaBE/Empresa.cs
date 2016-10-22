using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.EmpresaBE
{
    public class Empresa : BaseEntity
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public bool Cortesias { get; set; }
        public int CantidadCorteisas { get; set; }
        public string Estado { get; set; }
    }
}
