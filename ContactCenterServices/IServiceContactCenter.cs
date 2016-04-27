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
        Task<List<Asiento>> ListarAsientoDisponibleAsync(int idObra, int idFuncion, DateTime FechaObra);
        Task<List<AsientoPrecio>> listarAsientoTeatroAsync(int idObra);
        List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime FechaObra);
        List<Teatro> ListarTeatros();
        Task<List<Teatro>> ListarTeatrosAsync();
        List<Obra> ListarObraTeatro(int idTeatro);
        List<Funcion> ListarFuncionDiaObra(int dia, int idObra);
    }
}
