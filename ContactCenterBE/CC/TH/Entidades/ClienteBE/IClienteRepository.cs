using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ClienteBE
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByTelefono(string telefono);
        int GetNewIdCliente(Cliente cliente);
    }
}
