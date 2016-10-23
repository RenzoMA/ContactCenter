using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCenterBE.CC.Entidades.LogBackup
{
    public class LogBackup
    {
        public int IdLogBackup { get; set; }
        public string ComputerName { get; set; }
        public string FileName { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}
