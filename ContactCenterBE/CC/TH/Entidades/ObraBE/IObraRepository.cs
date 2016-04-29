using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ObraBE
{
    public interface IObraRepository : IBaseRepository<Obra>
    {
        List<Obra> GetListaTeatro(int idTeatro);
        

    }
}
