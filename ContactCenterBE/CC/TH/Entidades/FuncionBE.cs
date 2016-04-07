using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Base;

namespace ContactCenterBE.CC.TH.Entidades
{
    public class FuncionBE : BaseEntity
    {
        public int IdFuncion { get; set; }
        public int Dia { get; set; }
        public TimeSpan Horario { get; set; }
        public string Estado { get; set; }
        public ObraBE Obra { get; set; }

    }
}
