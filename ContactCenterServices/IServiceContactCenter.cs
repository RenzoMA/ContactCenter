using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.Entidades.CLienteBE;
using ContactCenterBE.CC.Entidades.RolBE;

namespace ContactCenterServices
{
    public interface IServiceContactCenter : IDisposable
    {
        bool EliminarAsientoTemporalAntiguo();
        bool InsertarAplicacion(Aplicacion aplicacion);
        List<Aplicacion> ListarAplicaciones();
        bool UpdateAplicacion(Aplicacion aplicacion);
        Usuario ValidarUsuario(string login, string password);
        Task<Usuario> ValidarUsuarioAsync(string login, string password);
        List<Aplicacion> ListarAplicacionUsuario(Usuario usuario);
        Task<List<Aplicacion>> ListarAplicacionUsuarioAsync(Usuario usuario);
        Task<List<Asiento>> ListarAsientoDisponibleAsync(int idObra, int idFuncion, DateTime FechaObra,string token);
        Task<List<AsientoPrecio>> listarAsientoTeatroAsync(int idObra);
        List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime FechaObra, string token);
        List<Teatro> ListarTeatros();
        Task<List<Teatro>> ListarTeatrosAsync();
        List<Obra> ListarObraTeatro(int idTeatro);
        List<Funcion> ListarFuncionDiaObra(int dia, int idObra);

        //OBRA
        bool InsertarObra(Obra obra);
        bool EliminarObra(int id);
        bool ActualizarObra(Obra obra);
        IList<Obra> ListarObras();
        Obra BuscarObra(int id);
        Obra BuscarObraPorNombre(string name);
        List<Obra> ListarObraByTeatro(int idTeatro);

        //ASIENTO
        bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        Task<bool> InserAsientoTemporalAsync(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        Task<bool> EliminarAsientoTemporalAsync(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporalTotal(string token);
        Task<bool> EliminarAsientoTemporalTotalAsync(string token);

        //FUNCION//
        bool InsertarFuncion(Funcion funcion);
        bool EliminarFuncion(int id);
        bool ActualizarFuncion(Funcion funcion);
        IList<Funcion> ListarFunciones();
        Funcion BuscarFuncion(int id);
        bool InsertarReserva(Reserva reserva,Cliente cliente);
        Task<bool> InsertarReservaAsync(Reserva reserva,Cliente cliente);
        Cliente GetClienteByTelefono(string telefono);
        Task<Cliente> GetClienteByTelefonoAsync(string telefono);

        //PROMOCION
        List<Promocion> ListPromocionByFuncionTipoPromo(int idFuncion, int idTipoPromocion);
        List<TipoPromocion> GetListaTipoPromocionSeleccionable();
        List<TipoPromocion> GetListaTipoPromocion();

        List<Reserva> ReporteReservas(int idTeatro, DateTime fecha);
        List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin);
        bool CancelarReserva(int idReserva);
        List<Zona> ListZonaByTeatro(int IdTeatro);
        List<Asiento> ListAsientoByZona(int IdZona);
        bool UpdateAsientoDisponible(string asientos, string estado);
        List<Usuario> SearchUsuarioByName(string name);
        List<Rol> ListarRol();
        bool InsertarUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario,bool cambioContraseña);

        //Tarifa

        List<Tarifa> GetListaByTeatroObra(int IdObra);

        bool InsertarTarifa(Tarifa tarifa);
        List<Funcion> ListarFuncionByObra(int idObra);
        List<Funcion> ListarFuncionByObraGrilla(int idObra);
        bool Uptade(Tarifa tarifa);

        List<Promocion> ListarPromocionByFuncion(int idFuncion);
        bool UpdatePromocion(Promocion datos);
        bool InsertPromocion(Promocion datos);
    }
}
