using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;

namespace ContactCenterBL.BusinessInterfaces.CC
{
    public interface IAplicacionService
    {
        void Insertar(Aplicacion aplicacion);
    }
}
