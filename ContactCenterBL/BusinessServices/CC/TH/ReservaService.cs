using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBE.CC.Entidades.CLienteBE;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository reservaRepository;
        private readonly IClienteRepository clienteRepository;

        public ReservaService(IReservaRepository _reservaRepository,
                              IClienteRepository _clienteRepository)
        {
            reservaRepository = _reservaRepository;
            clienteRepository = _clienteRepository;
        }

        public bool InsertarReserva(Reserva reserva,Cliente cliente)
        {
            Cliente tempCliente = clienteRepository.GetByTelefono(cliente.Telefono);
            if (tempCliente == null)
            {
               cliente.IdCliente = clienteRepository.GetNewIdCliente(cliente);
            }
            else
            {
                cliente.IdCliente = tempCliente.IdCliente;
                clienteRepository.Update(cliente);
            }
            reserva.Cliente = cliente;

            return reservaRepository.Insert(reserva);
        }

        public List<Reserva> ReporteReservas(int idTeatro, DateTime fecha)
        {
            return reservaRepository.ReporteReservas(idTeatro, fecha);
        }
    }
}
