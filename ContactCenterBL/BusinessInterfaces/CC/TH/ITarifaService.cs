using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface ITarifaService
    {
        List<TarifaView> GetListaByTeatroObra(int IdObra);

        bool Insert(Tarifa tarifa);

        bool Update(Tarifa tarifa);
    }

}
