using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterBE.CC.Entidades.AplicacionBE
{
    public interface IAplicacionRepository : IBaseRepository<Aplicacion>
    {
        List<Aplicacion> ListarAplicacionUsuario(Usuario usuario);
    }
}
