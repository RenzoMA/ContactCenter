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
        public string HorarioDia { get {
                if (IdFuncion != 0)
                {
                    switch (Dia)
                    {
                        case 0: return "Lunes -" + Horario;
                        case 1: return "Martes -" + Horario;
                        case 2: return "Miércoles -" + Horario;
                        case 3: return "Jueves -" + Horario;
                        case 4: return "Viernes -" + Horario;
                        case 5: return "Sabado -" + Horario;
                        case 6: return "Domingo -" + Horario;
                        default: return "";
                    }
                }
                return "" + Horario;
            } }
        public string Estado { get; set; }
        public Obra Obra { get; set; }

    }
}
