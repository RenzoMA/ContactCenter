using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.AsientoBE
{
    public interface IAsientoRepository : IBaseRepository<Asiento>
    {
        List<Asiento> ListarAsientoDisponible(int idObra, int idFuncion, DateTime fecha);
        List<Asiento> ListarTeatroAsiento(int idTeatro);
    }
}
