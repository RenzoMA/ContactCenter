using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;

namespace ContactCenterBE.CC.TH.Entidades.ZonaBE
{
    public class Zona : BaseEntity
    {
        public Zona() { }
        public Zona(Zona zona)
        {
            this.IdZona = zona.IdZona;
            this.Nombre = zona.Nombre;
            this.Descripcion = zona.Descripcion;
            this.Estado = zona.Estado;
            this.Obra = zona.Obra;
            this.Precio = zona.Precio;
            this.R = zona.R;
            this.G = zona.G;
            this.B = zona.B;
            this.AsientoZona = zona.AsientoZona;
        }

        public int IdZona { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public Obra Obra { get; set; }
        public Single Precio { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public List<AsientoZona> AsientoZona { get; set; }
    }
}
