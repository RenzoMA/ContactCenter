using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBL.BusinessInterfaces.CC;
using ContactCenterBL.BusinessServices.CC.TH;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterServices
{
    public class ServiceContactCenter : IServiceContactCenter
    {

        private IAsientoService _asientoService;
        private IAplicacionService _aplicacionService;
        private IUsuarioService _usuarioService;


        public ServiceContactCenter(
            IAsientoService asientoService,
            IAplicacionService aplicacionService,
            IUsuarioService usuarioService)
        {
            _asientoService = asientoService;
            _aplicacionService = aplicacionService;
            _usuarioService = usuarioService;
        }

        public void Dispose()
        {
            _asientoService = null;
            _aplicacionService = null;
            _usuarioService = null;
        }

        public void InsertarAplicacion(Aplicacion aplicacion)
        {
            _aplicacionService.Insertar(aplicacion);
        }


        public List<Aplicacion> ListarAplicaciones()
        {
            return _aplicacionService.Listar();
        }

        public List<Aplicacion> ListarAplicacionUsuario(Usuario usuario)
        {
            return _aplicacionService.ListarAplicacionUsuario(usuario);
        }

        public Usuario ValidarUsuario(string login, string password)
        {
            return _usuarioService.ValidarUsuario(login, password);
        }

        public async Task<Usuario> ValidarUsuarioAsync(string login, string password)
        {
            Usuario usuario = null;
            await Task.Run(() =>
            {
                usuario = _usuarioService.ValidarUsuario(login, password);
            });
            return usuario;
        }

        public async Task<List<Aplicacion>> ListarAplicacionUsuarioAsync(Usuario usuario)
        {
            List<Aplicacion> lAplicacion = null;
            await Task.Run(() =>
            {
                lAplicacion = _aplicacionService.ListarAplicacionUsuario(usuario);
            });
            return lAplicacion;
        }
    }
}
