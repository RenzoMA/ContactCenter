using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterUnitTest.GenericInterface
{
    public interface GenericCrud
    {
        void Crear();
        void Actualizar();
        void Consultar();
        void Listar();
        void Eliminar();

    }
}
