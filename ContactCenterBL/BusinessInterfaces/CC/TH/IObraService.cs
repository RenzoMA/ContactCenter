using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ObraBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IObraService
    {
        List<Obra> ListarObraTeatro(int idTeatro);
    }
}
