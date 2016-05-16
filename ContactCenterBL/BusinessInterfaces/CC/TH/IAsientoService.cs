using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;


namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IAsientoService
    {
        List<Asiento> ListarAsientoDisponible(int idObra,int idFuncion,DateTime fecha, string token);
        List<AsientoPrecio> ListarAsientoTeatro(int idObra);
        bool InserAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporal(int idFuncion, int idAsiento, DateTime fechaObra, string token);
        bool EliminarAsientoTemporalTotal(string token);
        List<Asiento> ListAsientoByZona(int IdZona);
        bool UpdateAsientoDisponible(string asientos, string estado);
    }
}
