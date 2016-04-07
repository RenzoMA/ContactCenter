using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.Entidades
{
    public class UsuarioBE
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public String Login { get; set; }
        public String Contraseña { get; set; }
        public RolBE Rol { get; set; }
    }
}
