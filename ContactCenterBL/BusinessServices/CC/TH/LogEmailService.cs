using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBL.Helper;
using ContactCenterCommon;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class LogEmailService : ILogEmailService
    {
        private readonly ILogEmailRepository logEmailRepository;

        public LogEmailService(ILogEmailRepository _logEmailRepository)
        {
            logEmailRepository = _logEmailRepository;
        }

        public LogEmail GetById(int id)
        {
            return logEmailRepository.GetById(id);
        }

        public IList<LogEmail> GetLista()
        {
            return logEmailRepository.GetLista();
        }

        public bool Insert(LogEmail datos)
        {
            return logEmailRepository.Insert(datos);
        }

        public bool ReenviarCorreo(string v1, string v2, string documentText, string v3, LogEmail logEmail)
        {
            List<string> email;
            email = v1.Replace(';', ',').Split(',').ToList();
            List<string> emailCC;
            emailCC = v2.Replace(';', ',').Split(',').ToList();
            
            MailHelper.SendMail(email, emailCC, documentText, v3, logEmailRepository, null, logEmail);
            return true;
        }

        public void SendMail(IList<string> mailAdresses, IList<string> ccAddresses, Enumerables.MailAction action, Reserva reserva, byte[] attachment = null)
        {
            MailHelper.SendMail(mailAdresses, ccAddresses, action, logEmailRepository, reserva, attachment);
        }

        public bool Update(LogEmail datos)
        {
            return logEmailRepository.Update(datos);
        }
    }
}
