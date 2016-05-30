﻿using System;
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
using ContactCenterBE.CC.TH.Entidades.TarifaBE;

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
        private ITarifaService _tarifaService;

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
            ITarifaService tarifaService)
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
            _tarifaService = tarifaService;
        }

        public void Dispose()
        {
            _asientoService = null;
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

        public List<Promocion> ListPromocionByFuncionTipoPromo(int idFuncion, int idTipoPromocion)
        {
            return _promocionService.ListByFuncionTipoPromo(idFuncion, idTipoPromocion);
        }

        public List<TipoPromocion> GetListaTipoPromocionSeleccionable()
        {
            return _tipoPromocionService.GetListaSeleccionable();
        }

        public List<Reserva> ReporteReservas(int idTeatro, DateTime fecha)
        {
            return _reservaService.ReporteReservas(idTeatro, fecha);
        }

        public List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin)
        {
            return _reservaService.BuscarByNamePhoneDate(nombrePhone, fechaInicio, fechaFin);
        }

        public bool CancelarReserva(int idReserva)
        {
            return _reservaService.CancelarReserva(idReserva);
        }

        public List<Zona> ListZonaByTeatro(int IdTeatro)
        {
            return _zonaService.ListZonaByTeatro(IdTeatro);
        }

        public List<Asiento> ListAsientoByZona(int IdZona)
        {
            return _asientoService.ListAsientoByZona(IdZona);
        }

        public bool UpdateAsientoDisponible(string asientos, string estado)
        {
            return _asientoService.UpdateAsientoDisponible(asientos, estado);
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

        public List<TarifaView> GetListaByTeatroObra(int IdObra)
        {
            return _tarifaService.GetListaByTeatroObra(IdObra);
        }

        public bool InsertarTarifa(Tarifa tarifa)
        {
            return _tarifaService.Insert(tarifa);
        }

        public bool InsertPromocion(Promocion datos)
        {
            return _promocionService.Insert(datos);
        }
        public bool EliminarAsientoTemporalAntiguo()
        {
            return _asientoService.EliminarAsientoTemporalAntiguo();
        }

        public bool Uptade(Tarifa tarifa)
        {
            return _tarifaService.Update(tarifa);
        }
    }
}