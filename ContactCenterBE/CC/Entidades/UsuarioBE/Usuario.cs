using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterBE.Base;


namespace ContactCenterBE.CC.Entidades.UsuarioBE
{
    [Serializable]
    public class Usuario : BaseEntity
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public String Login { get; set; }
        public String Contraseña { get; set; }
        public Rol Rol { get; set; }
        public string Estado { get; set; }
    }
}
