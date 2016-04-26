using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface ITeatroService
    {
        List<Teatro> Listar();
    }
}
