using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;

namespace ContactCenterBL.BusinessServices.CC.TH
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
