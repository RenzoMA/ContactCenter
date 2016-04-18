using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.CLienteBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBE.Base;

namespace ContactCenterBE.CC.TH.Entidades.ReservaBE
{
    public class Reserva : BaseEntity
    {
        public int IdReserva { get; set; }
        public string NombrePromocion { get; set; }
        public TimeSpan Horario { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
        public Obra Obra { get; set; }
        public Funcion Funcion { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public Promocion Promocion { get; set; }
        
    }
}
