using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterBL.BusinessInterfaces.CC;

namespace ContactCenterServices.ServicioContactCenter
{
    public class ServiceContactCenter : IServiceContactCenter
    {
        private IAplicacionService _aplicacionService;
        private IUsuarioService _usuarioService;
        private IRolService _rolService;

        public ServiceContactCenter(
            IAplicacionService aplicacionService,
            IUsuarioService usuarioService,
            IRolService rolService)
        {
            _aplicacionService = aplicacionService;
            _usuarioService = usuarioService;
            _rolService = rolService;
        }
        public bool InsertarAplicacion(Aplicacion aplicacion)
        {
            return _aplicacionService.Insertar(aplicacion);
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
        public bool UpdateAplicacion(Aplicacion aplicacion)
        {
            return _aplicacionService.Update(aplicacion);
        }
        public List<Usuario> SearchUsuarioByName(string name)
        {
            return _usuarioService.SearchByName(name);
        }
        public bool InsertarUsuario(Usuario usuario)
        {
            return _usuarioService.InsertarUsuario(usuario);
        }
        public bool UpdateUsuario(Usuario usuario, bool CambioContraseña)
        {
            return _usuarioService.UpdateUsuario(usuario, CambioContraseña);
        }
        public List<Rol> ListarRol()
        {
            return _rolService.GetLista();
        }

    }
}
