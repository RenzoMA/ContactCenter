using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.Base
{
    [Serializable]
    public class BaseEntity
    {
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
