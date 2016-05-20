using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.RolBE;

namespace ContactCenterBL.BusinessInterfaces.CC
{
    public interface IRolService
    {
        List<Rol> GetLista();
    }
}
