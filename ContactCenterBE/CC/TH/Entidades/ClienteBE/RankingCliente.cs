using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.TH.Entidades.ClienteBE
{
    public class RankingCliente : Cliente
    {
        public int CantidadReservas { get; set; }
        public String NombreObra { get; set; }

    }
}
