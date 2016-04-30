using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.CLienteBE;

namespace ContactCenterBL.BusinessInterfaces.CC
{
    public interface IClienteService
    {
        Cliente GetClienteByTelefono(string telefono);
    }
}
