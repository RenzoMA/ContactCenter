using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.Base;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;

namespace ContactCenterBE.CC.TH.Entidades.LogEmailBE
{
    public interface ILogEmailRepository : IBaseRepository<LogEmail>
    {
        List<LogEmail> GetCorreoFechas(DateTime fechaIni, DateTime fechaFin);
    }
}
