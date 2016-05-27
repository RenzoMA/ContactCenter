using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IFuncionService
    {
        List<Funcion> ListarFuncionDiaObra(int dia, int idObra);
        bool Delete(int id);
        Funcion GetById(int id);
        IList<Funcion> GetLista();
        bool Insert(Funcion datos);
        bool Update(Funcion datos);
        List<Funcion> ListarFuncionByObra(int idObra);
        //List<Funcion> ListarFuncionByObraGrilla(int idObra);
    }
}
