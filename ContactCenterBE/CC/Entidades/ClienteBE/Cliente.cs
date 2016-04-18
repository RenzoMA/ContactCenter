using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;


namespace ContactCenterBE.CC.Entidades.CLienteBE
{
    public class Cliente : BaseEntity
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Apellidomaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

    }
}
