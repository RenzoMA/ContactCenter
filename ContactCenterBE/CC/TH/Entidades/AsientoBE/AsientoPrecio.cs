using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.TH.Entidades.AsientoBE
{
    [Serializable]
    public class AsientoPrecio : Asiento
    {
        public AsientoPrecio()
        {

        }
        public AsientoPrecio(AsientoPrecio asiento)
        {
            this.Precio = asiento.Precio;
            this.Disponible = asiento.Disponible;
            this.IdAsiento = asiento.IdAsiento;
            this.Descripcion = asiento.Descripcion;
            this.Fila = asiento.Fila;
        }
        public Single Precio { get; set; }
    }
}
