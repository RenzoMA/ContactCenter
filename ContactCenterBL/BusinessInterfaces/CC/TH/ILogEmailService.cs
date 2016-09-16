using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterCommon;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface ILogEmailService
    {
        void SendMail(IList<string> mailAdresses, IList<string> ccAddresses, Enumerables.MailAction action, Reserva reserva, byte[] attachment = null);
        LogEmail GetById(int id);
        IList<LogEmail> GetLista();
        List<LogEmail> GetCorreoFechas(DateTime fechaInic, DateTime fechaFin);
        bool Insert(LogEmail datos);
        bool Update(LogEmail datos);
        bool ReenviarCorreo(string v1, string v2, string documentText, string v3, LogEmail logemail);
    }
}
