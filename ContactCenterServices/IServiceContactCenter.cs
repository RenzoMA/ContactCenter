using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;

namespace ContactCenterServices
{
    public interface IServiceContactCenter : IDisposable
    {
        string prueba();
        void InsertarAplicacion(Aplicacion aplicacion);
    }
}
