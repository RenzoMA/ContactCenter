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

        public string prueba()
        {
            return _asientoService.probarMensaje();
        }

        public List<Aplicacion> ListarAplicaciones()
        {
            return _aplicacionService.Listar();
        }

        public Usuario ValidarUsuario(string login, string password)
        {
            return _usuarioService.ValidarUsuario(login, password);
        }
    }
}
