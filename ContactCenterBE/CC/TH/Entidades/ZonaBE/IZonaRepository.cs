using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ZonaBE
{
    public interface IZonaRepository : IBaseRepository<Zona>
    {
        List<Zona> ListZonaByTeatro(int IdTeatro);
    }
}
