using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.TarifaBE
{
    public interface ITarifaRepository : IBaseRepository<Tarifa>
    {
        List<Tarifa> GetListaByTeatroObra(int IdObra);
    }
}
