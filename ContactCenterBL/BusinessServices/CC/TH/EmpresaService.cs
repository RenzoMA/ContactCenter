using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository empresaRepository;
        public EmpresaService(IEmpresaRepository _empresaRepository)
        {
            empresaRepository = _empresaRepository;
        }

        public bool ActualizarEmpresa(Empresa zona)
        {
            throw new NotImplementedException();
        }

        public bool EliminarEmpresa(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<Empresa> ListEmpresa()
        {
            List<Empresa> lista = empresaRepository.GetLista().ToList();
            return lista;
        }
        public List<Empresa> ListEmpresa(string filtro)
        {
            if (filtro.Equals(String.Empty))
            {
                return ListEmpresa();
            }
            else
            {
                List<Empresa> lista = empresaRepository.GetLista().Where(tx => tx.Nombre.ToLower().Contains(filtro.ToLower())).ToList();
                return lista;
            }
        }

        public bool InsertarEmpresa(Empresa zona)
        {
            throw new NotImplementedException();
        }
    }
}
