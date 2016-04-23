using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBL.BusinessInterfaces.CC;

namespace ContactCenterBL.BusinessServices.CC
{
    public class AplicacionService : IAplicacionService
    {
        private readonly IAplicacionRepository aplicacionRepository;

        public AplicacionService(IAplicacionRepository _aplicacionRepository)
        {
            aplicacionRepository = _aplicacionRepository;
        }

        public void Insertar(Aplicacion aplicacion)
        {
            aplicacionRepository.Insert(aplicacion);
        }

        public List<Aplicacion> Listar()
        {
            return aplicacionRepository.GetLista().ToList();
        }

        public List<Aplicacion> ListarAplicacionUsuario(Usuario usuario)
        {
            return aplicacionRepository.ListarAplicacionUsuario(usuario);
        }
    }
}
