using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.ObraBE;

namespace ContactCenterBE.CC.TH.Entidades.FuncionBE
{
    [Serializable]
    public class Funcion : BaseEntity
    {
        public int IdFuncion { get; set; }
        public int Dia { get; set; }
        public string Horario { get; set; }
        public string Estado { get; set; }
        public Obra Obra { get; set; }

    }
}
