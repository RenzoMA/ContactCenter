using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterBL.BusinessInterfaces.CC
{
    public interface IAplicacionService
    {
        bool Insertar(Aplicacion aplicacion);
        List<Aplicacion> Listar();
        List<Aplicacion> ListarAplicacionUsuario(Usuario usuario);
    }
}
