using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IEmpresaService
    {
        List<Empresa> ListEmpresa(string filtro);
        List<Empresa> ListEmpresa();
        bool EliminarEmpresa(int codigo);
        bool InsertarEmpresa(Empresa zona);
        bool ActualizarEmpresa(Empresa zona);
    }
}
