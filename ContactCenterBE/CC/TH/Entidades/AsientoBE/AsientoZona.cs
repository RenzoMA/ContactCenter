using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Drawing;

namespace ContactCenterBE.CC.TH.Entidades.AsientoBE
{
    public class AsientoZona : BaseEntity
    {
        public int IdAsientoZona { get; set; }
        public int IdAsiento { get; set; }
        public Asiento Asiento { get; set; }
        public string AsientoDescripcion { get { return Asiento.Descripcion; } }
        public string AsientoFila { get { return Asiento.Fila; } }
        public Zona Zona { get; set; }
        public string Disponible { get; set; }
        public string NombrePromocion { get; set; }

        public string EstadoTemporal { get; set; }
        public Color ColorTemporal { get; set; }
        public bool PromocionAplicada { get; set; }

        public AsientoZona(AsientoZona asientoZona)
        {
            this.IdAsientoZona = asientoZona.IdAsientoZona;
            this.IdAsiento = asientoZona.IdAsiento;
            this.Asiento = asientoZona.Asiento;
            this.Zona = asientoZona.Zona;
            this.Disponible = asientoZona.Disponible;
            this.EstadoTemporal = asientoZona.EstadoTemporal;
            this.PromocionAplicada = false;
        }
        public AsientoZona() { }
    }
}
