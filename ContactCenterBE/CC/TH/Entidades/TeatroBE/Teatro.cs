using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.TeatroBE
{
    [Serializable]
    public class Teatro : BaseEntity
    {
        public int IdTeatro { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        public string frmTeatro { get; set; }
    }
}
