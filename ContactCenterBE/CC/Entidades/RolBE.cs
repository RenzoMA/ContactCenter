using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;


namespace ContactCenterBE.CC.Entidades
{
    public class RolBE : BaseEntity
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}
