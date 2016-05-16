using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IZonaService
    {
        List<Zona> ListZonaByTeatro(int IdTeatro);
    }
}
