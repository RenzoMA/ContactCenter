using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
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
    }
}
