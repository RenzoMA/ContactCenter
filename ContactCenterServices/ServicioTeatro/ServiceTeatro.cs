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
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;

namespace ContactCenterServices.ServicioTeatro
{
    public class ServiceTeatro : IServiceTeatro
    {

        private IAsientoService _asientoService;
        private ITeatroService _teatroService;
        private IObraService _obraService;
        private IFuncionService _funcionService;
        private IReservaService _reservaService;
        private IClienteService _clienteService;
        private IPromocionService _promocionService;
        private ITipoPromocionService _tipoPromocionService;
        private IZonaService _zonaService;
        private ILogEmailService _emailService;
        private IEmpresaService _empresaService;

        public ServiceTeatro(
            IAsientoService asientoService,
            IAplicacionService aplicacionService,
            IUsuarioService usuarioService,
            ITeatroService teatroService,
            IObraService obraService,
            IFuncionService funcionService,
            IReservaService reservaService,
            IClienteService clienteService,
            IPromocionService promocionService,
            ITipoPromocionService tipoPromocionService,
            IZonaService zonaService,
            ILogEmailService emailService,
            IEmpresaService empresaService)
        {
            _clienteService = clienteService;
            _asientoService = asientoService;
            _teatroService = teatroService;
            _obraService = obraService;
            _funcionService = funcionService;
            _promocionService = promocionService;
            _reservaService = reservaService;
            _tipoPromocionService = tipoPromocionService;
            _zonaService = zonaService;
            _emailService = emailService;
            _empresaService = empresaService;
        }

        public void Dispose()
        {
            _clienteService = null;
            _asientoService = null;
            _teatroService = null;
            _obraService = null;
            _funcionService = null;
            _promocionService = null;
            _reservaService = null;
            _tipoPromocionService = null;
            _zonaService = null;
            _emailService = null;
            _empresaService = null;
        }

        public List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime FechaObra,string token)
        {
            return _asientoService.ListarAsientoDisponible(idObra, idFuncion, FechaObra,token);
        }

        public async Task<List<Asiento>> ListarAsientoDisponibleAsync(int idObra, int idFuncion, DateTime FechaObra,string token)
        {
            List<Asiento> lAsiento = null;
            await Task.Run(() =>
            {
                lAsiento = _asientoService.ListarAsientoDisponible(idObra, idFuncion, FechaObra,token);
            });
            return lAsiento;
        }

        public async Task<List<AsientoZona>> listarAsientoTeatroAsync(int idObra)
        {
            List<AsientoZona> lAsiento = null;
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
        public List<Obra> ComboManGetListaTeatro(int idTeatro)
        {
            return _obraService.ComboManGetListaTeatro(idTeatro);
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

        public bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            return _asientoService.InserAsientoTemporal(idFuncion, idAsiento, fechaObra, token);
        }

        public bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            return _asientoService.EliminarAsientoTemporal(idFuncion, idAsiento, fechaObra, token);
        }

        public async Task<bool> InserAsientoTemporalAsync(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = _asientoService.InserAsientoTemporal(idFuncion, idAsiento, fechaObra, token);
            });
            return result;
        }

        public async Task<bool> EliminarAsientoTemporalAsync(int idFuncion, int idAsiento, DateTime fechaObra, string token)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = _asientoService.EliminarAsientoTemporal(idFuncion, idAsiento, fechaObra, token);
            });
            return result;
        }

        public bool EliminarAsientoTemporalTotal(string token)
        {
            return _asientoService.EliminarAsientoTemporalTotal(token);
        }

        public async Task<bool> EliminarAsientoTemporalTotalAsync(string token)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = _asientoService.EliminarAsientoTemporalTotal(token);
            });
            return result;
        }


        //OBRA
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

        public Obra BuscarObraPorNombre(string name) {

            return _obraService.GetByName(name);
        }

        public IList<Obra> ListarObras() {
            return _obraService.GetLista();
        }

        //obra listar por teatro
        public List<Obra> ListarObraByTeatro(int idTeatro)
        {
            return _obraService.ListarObraByTeatro(idTeatro);
        }

        public bool InsertarReserva(Reserva reserva,Cliente cliente)
        {
            return _reservaService.InsertarReserva(reserva,cliente);
        }

        public async Task<bool> InsertarReservaAsync(Reserva reserva,Cliente cliente)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = _reservaService.InsertarReserva(reserva, cliente);
            });
            return result;
        }

        public Cliente GetClienteByTelefono(string telefono)
        {
            return _clienteService.GetClienteByTelefono(telefono);
        }

        public async Task<Cliente> GetClienteByTelefonoAsync(string telefono)
        {
            Cliente obj = null;
            await Task.Run(() =>
            {
                obj = _clienteService.GetClienteByTelefono(telefono);
            });
            return obj;
        }

        public bool InsertarFuncion(Funcion funcion)
        {
           return  _funcionService.Insert(funcion);
        }

        public bool EliminarFuncion(int id)
        {
            return _funcionService.Delete(id);
        }

        public bool ActualizarFuncion(Funcion funcion)
        {
            return _funcionService.Update(funcion);
        }

        public IList<Funcion> ListarFunciones()
        {
            return _funcionService.GetLista();
        }

        public Funcion BuscarFuncion(int id)
        {
            throw new NotImplementedException();
        }

        public List<Promocion> ListPromocionByFuncionTipoPromo(int idFuncion, int idTipoPromocion,string zonas)
        {
            return _promocionService.ListByFuncionTipoPromo(idFuncion, idTipoPromocion,zonas);
        }

        public List<TipoPromocion> GetListaTipoPromocionSeleccionable()
        {
            return _tipoPromocionService.GetListaSeleccionable();
        }

        public List<DetalleReserva> ReporteReservas(int idTeatro, DateTime fecha, DateTime fechaFin)
        {
            return _reservaService.ReporteReservas(idTeatro, fecha, fechaFin);
        }

        public List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin)
        {
            return _reservaService.BuscarByNamePhoneDate(nombrePhone, fechaInicio, fechaFin);
        }

        public bool CancelarReserva(int idReserva)
        {
            return _reservaService.CancelarReserva(idReserva);
        }

        public List<Zona> ComboListZonaByObra(int IdObra)
        {
            return _zonaService.ComboListZonaByObra(IdObra);
        }
        public List<Zona> ListZonaByObra(int IdObra)
        {
            return _zonaService.ListZonaByObra(IdObra);
        }

        public List<AsientoZona> ListAsientoByZona(int IdZona)
        {
            return _asientoService.ListAsientoByZona(IdZona);
        }

        public bool UpdateAsientoDisponible(string asientos, string estado, int idZona)
        {
            return _asientoService.UpdateAsientoDisponible(asientos, estado, idZona);
        }
        

        public List<Funcion> ListarFuncionByObra(int idObra)
        {
            return _funcionService.ListarFuncionByObra(idObra);
        }

        public List<Funcion> ListarFuncionByObraGrilla(int idObra)
        {
            return _funcionService.ListarFuncionByObraGrilla(idObra);
        }

        public List<Promocion> ListarPromocionByFuncion(int idFuncion)
        {
            return _promocionService.ListarPromocionByFuncion(idFuncion);
        }

        public List<TipoPromocion> GetListaTipoPromocion()
        {
            return _tipoPromocionService.GetLista();
        }

        public bool UpdatePromocion(Promocion datos)
        {
            return _promocionService.Update(datos);
        }


        public bool InsertPromocion(Promocion datos)
        {
            return _promocionService.Insert(datos);
        }
        public bool EliminarAsientoTemporalAntiguo()
        {
            return _asientoService.EliminarAsientoTemporalAntiguo();
        }


        public List<RankingCliente> ObtenerRankingCliente(DateTime fechaInicio, DateTime fechaFin)
        {
            return _clienteService.ObtenerRankingCliente(fechaInicio, fechaFin);
        }

        public List<ReservaObra> ReporteReservaObra(DateTime fechaInicio, DateTime fechaFin)
        {
            return _reservaService.ReporteReservaObra(fechaInicio, fechaFin);
        }

        public bool EliminarAsientoDisponible(string asientos, int idZona)
        {
            return _asientoService.EliminarAsientoDisponible(asientos, idZona);
        }

        public List<Asiento> ListAsientoNoAsignado(int idObra, int idTeatro)
        {
            return _asientoService.ListAsientoNoAsignado(idObra, idTeatro);
        }

        public bool InsertarAsientoZona(List<Asiento> listaAsientos, Zona zona)
        {
            return _asientoService.InsertarAsientoZona(listaAsientos, zona);
        }

        public bool InsertarZona(Zona zona)
        {
            return _zonaService.InsertarZona(zona);
        }

        public async Task<bool> InsertarZonaAsync(Zona zona)
        {
            bool obj = false;
            await Task.Run(() =>
            {
                obj = _zonaService.InsertarZona(zona);
            });
            return obj;
        }

        public async Task<bool> InsertarAsientoZonaAsync(List<Asiento> listaAsientos, Zona zona)
        {
            bool obj = false;
            await Task.Run(() =>
            {
                obj = _asientoService.InsertarAsientoZona(listaAsientos, zona);
            });
            return obj;
        }

        public bool ActualizarZona(Zona zona)
        {
            return _zonaService.ActualizarZona(zona);
        }

        public List<Obra> ComboListarObraByTeatro(int idTeatro)
        {
            return _obraService.ComboListarObraByTeatro(idTeatro);
        }

        public bool CargaMasiva(string path)
        {
            return _reservaService.CargaMasiva(path);
        }
        public async Task<bool> CargaMasivaAsync(string path)
        {
            bool obj = false;
            await Task.Run(() =>
            {
                obj = _reservaService.CargaMasiva(path);
            });
            return obj;
        }

        //Email

        public bool UpdateLogEmail(LogEmail datos)
        {
            return _emailService.Update(datos);
        }

        public IList<LogEmail> ListarEmail()
        {
            return _emailService.GetLista();
        }

        public LogEmail BuscarEmail(int id)
        {
            return _emailService.GetById(id);
        }

        public async Task<bool> ReenviarCorreo(string v1, string v2, string documentText, string v3, LogEmail logEmail)
        {
            bool obj = false;
            await Task.Run(() =>
            {
                obj = _emailService.ReenviarCorreo(v1, v2, documentText, v3, logEmail);
            });
            return obj;
        }

        public byte[] GetObraImage(int id)
        {
            return _obraService.GetImage(id);
        }

        public List<LogEmail> ListaCorreoFechas(DateTime fechaIni, DateTime fechaFin)
        {
            return _emailService.GetCorreoFechas(fechaIni, fechaFin);
        }

        public List<Obra> ListarObraTeatroCombo(int idTeatro)
        {
            return _obraService.ListarObraTeatroCombo(idTeatro);
        }

        public async Task<List<RankingCliente>> ObtenerRankingClienteAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            List<RankingCliente> lista = null;
            await Task.Run(() =>
            {
                lista = _clienteService.ObtenerRankingCliente(fechaInicio, fechaFin);
            });
            return lista;
        }

        public async Task<List<DetalleReserva>> ReporteReservasAsync(int idTeatro, DateTime fecha, DateTime fechaFin)
        {
            List<DetalleReserva> lista = null;
            await Task.Run(() =>
            {
                lista = _reservaService.ReporteReservas(idTeatro, fecha, fechaFin);
            });
            return lista;

        }

        public async Task<List<ReservaObra>> ReporteReservaObraAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReservaObra> lista = null;
            await Task.Run(() =>
            {
                lista = _reservaService.ReporteReservaObra(fechaInicio, fechaFin);
            }
            );
            return lista;
        }

        public List<Promocion> ListPromocionByObra(int idObra)
        {
            return _promocionService.ListPromocionByObra(idObra);
        }

        public async Task<List<Promocion>> ListPromocionByObraAsync(int idObra)
        {
            List<Promocion> lista = null;
            await Task.Run(() =>
            {
                lista = _promocionService.ListPromocionByObra(idObra);
            });
            return lista;
        }

        public async Task<List<Promocion>> ListPromocionByFuncionTipoPromoAsync(int idFuncion, int idTipoPromocion, string zonas)
        {
            List<Promocion> listaPromocion = null;
            await Task.Run(() =>
            {
                listaPromocion = _promocionService.ListByFuncionTipoPromo(idFuncion, idTipoPromocion, zonas);
            });
            return listaPromocion;
        }

        public async Task<List<Empresa>> ListEmpresa(string filtro)
        {
            List<Empresa> listaEmpresa = null;
            await Task.Run(() =>
            {
                listaEmpresa = _empresaService.ListEmpresa(filtro);
            });
            return listaEmpresa;
        }

        public bool InsertEmpresa(Empresa empresa)
        {
            return _empresaService.InsertarEmpresa(empresa);
        }

        public bool UpdateEmpresa(Empresa empresa)
        {
            return _empresaService.ActualizarEmpresa(empresa);
        }
    }
}
