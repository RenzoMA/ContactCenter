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
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;

namespace ContactCenterServices
{
    public class ServiceContactCenter : IServiceContactCenter
    {

        private IAsientoService _asientoService;
        private IAplicacionService _aplicacionService;
        private IUsuarioService _usuarioService;
        private ITeatroService _teatroService;
        private IObraService _obraService;
        private IFuncionService _funcionService;


        public ServiceContactCenter(
            IAsientoService asientoService,
            IAplicacionService aplicacionService,
            IUsuarioService usuarioService,
            ITeatroService teatroService,
            IObraService obraService,
            IFuncionService funcionService)
        {
            _asientoService = asientoService;
            _aplicacionService = aplicacionService;
            _usuarioService = usuarioService;
            _teatroService = teatroService;
            _obraService = obraService;
            _funcionService = funcionService;
        }

        public void Dispose()
        {
            _asientoService = null;
            _aplicacionService = null;
            _usuarioService = null;
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

        public List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime FechaObra)
        {
            return _asientoService.ListarAsientoDisponible(idObra, idFuncion, FechaObra);
        }

        public async Task<List<Asiento>> ListarAsientoDisponibleAsync(int idObra, int idFuncion, DateTime FechaObra)
        {
            List<Asiento> lAsiento = null;
            await Task.Run(() =>
            {
                lAsiento = _asientoService.ListarAsientoDisponible(idObra, idFuncion, FechaObra);
            });
            return lAsiento;
        }

        public async Task<List<AsientoPrecio>> listarAsientoTeatroAsync(int idObra)
        {
            List<AsientoPrecio> lAsiento = null;
            await Task.Run(() =>
            {
                lAsiento = _asientoService.ListarAsientoTeatro(idObra);
            });
            return lAsiento;
        }

        public List<Teatro> ListarTeatros()
        {
            return _teatroService.Listar();
        }

        public List<Obra> ListarObraTeatro(int idTeatro)
        {
            return _obraService.ListarObraTeatro(idTeatro);
        }

        public List<Funcion> ListarFuncionDiaObra(int dia, int idObra)
        {
            return _funcionService.ListarFuncionDiaObra(dia, idObra);
        }

        public async Task<List<Teatro>> ListarTeatrosAsync()
        {
            List<Teatro> lTeatro = null;
            await Task.Run(() =>
            {
                lTeatro = _teatroService.Listar();
            });
            return lTeatro;
        }

        public bool InsertarObra(Obra obra) {
            return _obraService.Insert(obra);
        }
        public bool ActualizarObra(Obra obra)
        {
            return _obraService.Update(obra);
        }
        public bool EliminarObra(int id)
        {
            return _obraService.Delete(id);
        }

        public Obra BuscarObra(int id)
        {
            return _obraService.GetById(id);
        }

        public IList<Obra> ListarObras() {
            return _obraService.GetLista();
        }
    }
}
