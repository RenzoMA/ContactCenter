using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class TeatroBE : BaseEntity
    {
        public int IdTeatro { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }

    }
}
