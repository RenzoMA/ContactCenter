using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IClienteService
    {
        Cliente GetClienteByTelefono(string telefono);
    }
}
