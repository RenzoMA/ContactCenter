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
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;

namespace ContactCenterServices.ServicioTeatro
{
    public interface IServiceTeatro : IDisposable
    {

        List<Obra> ListarObraTeatroCombo(int idTeatro);
        bool CargaMasiva(string path);
        bool EliminarAsientoTemporalAntiguo();
        Task<List<Asiento>> ListarAsientoDisponibleAsync(int idObra, int idFuncion, DateTime FechaObra,string token);
        Task<List<AsientoZona>> listarAsientoTeatroAsync(int idObra);
        Task<bool> CargaMasivaAsync(string path);
        List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime FechaObra, string token);
        List<Teatro> ListarTeatros();
        Task<List<Teatro>> ListarTeatrosAsync();
        List<Obra> ListarObraTeatro(int idTeatro);
        Task<bool> ReenviarCorreo(string v1, string v2, string documentText, string v3, LogEmail logEmail);
        List<Obra> ComboManGetListaTeatro(int idTeatro);
        List<Funcion> ListarFuncionDiaObra(int dia, int idObra);
        List<Asiento> ListAsientoNoAsignado(int idObra, int idTeatro);
        bool ActualizarZona(Zona zona);

        bool EliminarAsientoDisponible(string asientos, int idZona);
        bool InsertarAsientoZona(List<Asiento> listaAsientos, Zona zona);
        Task<bool> InsertarAsientoZonaAsync(List<Asiento> listaAsientos, Zona zona);
        bool InsertarZona(Zona zona);
        Task<bool> InsertarZonaAsync(Zona zona);

        //OBRA
        bool InsertarObra(Obra obra);
        bool EliminarObra(int id);
        bool ActualizarObra(Obra obra);
        IList<Obra> ListarObras();
        Obra BuscarObra(int id);
        Obra BuscarObraPorNombre(string name);
        List<Obra> ComboListarObraByTeatro(int idTeatro);
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
        byte[] GetObraImage(int id);

        //PROMOCION
        List<Promocion> ListPromocionByFuncionTipoPromo(int idFuncion, int idTipoPromocion);
        List<TipoPromocion> GetListaTipoPromocionSeleccionable();
        List<TipoPromocion> GetListaTipoPromocion();

        List<DetalleReserva> ReporteReservas(int idTeatro, DateTime fecha, DateTime fechaFin);
        Task<List<DetalleReserva>> ReporteReservasAsync(int idTeatro, DateTime fecha, DateTime fechaFin);
        List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin);
        bool CancelarReserva(int idReserva);
        List<Zona> ComboListZonaByObra(int IdObra);
        List<Zona> ListZonaByObra(int IdObra);
        List<AsientoZona> ListAsientoByZona(int IdZona);
        bool UpdateAsientoDisponible(string asientos, string estado, int idZona);

        //Tarifa

        List<Funcion> ListarFuncionByObra(int idObra);
        List<Funcion> ListarFuncionByObraGrilla(int idObra);


        List<Promocion> ListarPromocionByFuncion(int idFuncion);
        bool UpdatePromocion(Promocion datos);
        bool InsertPromocion(Promocion datos);

        List<RankingCliente> ObtenerRankingCliente(DateTime fechaInicio, DateTime fechaFin);
        Task<List<RankingCliente>> ObtenerRankingClienteAsync(DateTime fechaInicio, DateTime fechaFin);
        List<ReservaObra> ReporteReservaObra(DateTime fechaInicio, DateTime fechaFin);
        Task<List<ReservaObra>> ReporteReservaObraAsync(DateTime fechaInicio, DateTime fechaFin);
        //LogEmail
        bool UpdateLogEmail(LogEmail datos);
        IList<LogEmail> ListarEmail();
        LogEmail BuscarEmail(int id);
        List<LogEmail> ListaCorreoFechas(DateTime fechaIni, DateTime fechaFin);
        List<Promocion> ListPromocionByObra(int idObra);
    }
}
