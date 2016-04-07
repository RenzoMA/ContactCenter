using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class ReservaBE : BaseEntity
    {
        public int IdReserva { get; set; }
        public string NombrePromocion { get; set; }
        public TimeSpan Horario { get; set; }
        public EstadoReservaBE EstadoReserva { get; set; }
        public ObraBE Obra { get; set; }
        public FuncionBE Funcion { get; set; }
        public ClienteBE Cliente { get; set; }
        public UsuarioBE Usuario { get; set; }
        public PromocionBE Promocion { get; set; }
        
    }
}
