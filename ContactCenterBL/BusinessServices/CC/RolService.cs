using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterBL.BusinessInterfaces.CC;

namespace ContactCenterBL.BusinessServices.CC
{
    public class RolService : IRolService
    {
        private readonly IRolRepository rolRepository;
        public RolService(IRolRepository _rolRepository)
        {
            rolRepository = _rolRepository;
        }

        public List<Rol> GetLista()
        {
            return rolRepository.GetLista().ToList();
        }
    }
}
