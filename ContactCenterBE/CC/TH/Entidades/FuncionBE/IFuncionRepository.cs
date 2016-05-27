using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.FuncionBE
{
    public interface IFuncionRepository : IBaseRepository<Funcion>
    {
        List<Funcion> ListarFuncionDiaObra(int dia, int obra);
        List<Funcion> ListarFuncionByObra(int idObra);
        List<Funcion> ListarFuncionByObraGrilla(int idObra);
    }
}
