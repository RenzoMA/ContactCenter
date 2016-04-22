using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterServices
{
    public interface IServiceContactCenter : IDisposable
    {
        string prueba();
        void InsertarAplicacion(Aplicacion aplicacion);
        List<Aplicacion> ListarAplicaciones();
        Usuario ValidarUsuario(string login, string password);
        List<Aplicacion> ListarAplicacionUsuario(Usuario usuario);
    }
}
