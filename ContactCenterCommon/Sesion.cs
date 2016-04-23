using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.Entidades.AplicacionBE;

namespace ContactCenterCommon
{
    public static class Sesion
    {
        public static Usuario usuario { get; set; }
        public static Aplicacion aplicacion { get; set; }
    }
}
