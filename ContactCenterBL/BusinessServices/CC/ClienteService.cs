using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC;
using ContactCenterBE.CC.Entidades.CLienteBE;

namespace ContactCenterBL.BusinessServices.CC
{
    public class ClienteService : IClienteService
    {

       private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }

        public Cliente GetClienteByTelefono(string telefono)
        {
            return clienteRepository.GetByTelefono(telefono);
        }
    }
}
