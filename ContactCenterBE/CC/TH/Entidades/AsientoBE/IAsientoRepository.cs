using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;

namespace ContactCenterBE.CC.TH.Entidades.AsientoBE
{
    public interface IAsientoRepository : IBaseRepository<Asiento>
    {
        List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime fecha,string token);
        List<AsientoZona> ListarTeatroAsiento(int idObra);
        bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, String token);
        bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporalTotal(string token);
        List<AsientoZona> ListAsientoByZona(int IdZona);
        bool UpdateAsientoDisponible(string asientos, string estado, int idZona);
        bool EliminarAsientoTemporalAntiguo();
        bool EliminarAsientoDisponible(string asientos, int idZona);
        List<Asiento> ListAsientoNoAsignado(int idObra, int idTeatro);
        bool InsertarAsientoZona(List<Asiento> listaAsientos, Zona zona);
    }
}
