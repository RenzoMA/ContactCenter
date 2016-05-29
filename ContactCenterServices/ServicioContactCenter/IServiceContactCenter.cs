using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterServices.ServicioContactCenter
{
    public interface IServiceContactCenter
    {
        bool InsertarAplicacion(Aplicacion aplicacion);
        List<Aplicacion> ListarAplicaciones();
        List<Aplicacion> ListarAplicacionUsuario(Usuario usuario);
        Usuario ValidarUsuario(string login, string password);
        Task<Usuario> ValidarUsuarioAsync(string login, string password);
        Task<List<Aplicacion>> ListarAplicacionUsuarioAsync(Usuario usuario);
        bool UpdateAplicacion(Aplicacion aplicacion);
        List<Usuario> SearchUsuarioByName(string name);
        bool InsertarUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario, bool CambioContraseña);
        List<Rol> ListarRol();
    }
}
