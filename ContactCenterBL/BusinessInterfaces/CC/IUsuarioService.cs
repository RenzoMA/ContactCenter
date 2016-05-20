using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterBL.BusinessInterfaces.CC
{
    public interface IUsuarioService
    {
        Usuario ValidarUsuario(string login, string contraseña);
        List<Usuario> SearchByName(string name);
        bool InsertarUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario,bool CambioContraseña);
    }
}
