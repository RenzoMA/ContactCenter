using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.Entidades.UsuarioBE
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario ValidarUsuario(string login, string password);
    }
}
