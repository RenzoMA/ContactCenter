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
using ContactCenterBE.CC.Entidades.CLienteBE;

namespace ContactCenterServices
{
    public interface IServiceContactCenter : IDisposable
    {
        bool InsertarAplicacion(Aplicacion aplicacion);
        List<Aplicacion> ListarAplicaciones();
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

        bool InsertarObra(Obra obra);
        bool EliminarObra(int id);
        bool ActualizarObra(Obra obra);
        IList<Obra> ListarObras();
        Obra BuscarObra(int id);    
        bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        Task<bool> InserAsientoTemporalAsync(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        Task<bool> EliminarAsientoTemporalAsync(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporalTotal(string token);
        Task<bool> EliminarAsientoTemporalTotalAsync(string token);
        bool InsertarReserva(Reserva reserva,Cliente cliente);
        Task<bool> InsertarReservaAsync(Reserva reserva,Cliente cliente);
        Cliente GetClienteByTelefono(string telefono);
        Task<Cliente> GetClienteByTelefonoAsync(string telefono);
    }
}
