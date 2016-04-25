using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;


namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IAsientoService
    {
        List<Asiento> ListarAsientoDisponible(int idObra,int idFuncion,DateTime fecha);
        List<Asiento> ListarAsientoTeatro(int idTeatro);
    }
}
