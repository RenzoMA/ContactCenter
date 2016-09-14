﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using ContactCenterCommon;
using System.ComponentModel;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;

namespace ContactCenterBL.Helper
{
    public static class MailHelper
    {
        public static void SendMail(IList<string> mailAdresses, IList<string> ccAddresses, Enumerables.MailAction action, ILogEmailRepository logEmailRepository, Reserva reserva, byte[] attachment = null)
        {
            try
            {
                var smtpClient = new SmtpClient();

                #region Get Config Variables
                var mailAccount = ConfigurationManager.AppSettings["mailAccount"];
                var mailPassword = ConfigurationManager.AppSettings["mailPassword"];
                var smtp = ConfigurationManager.AppSettings["smtp"];
                var mailDisplayName = ConfigurationManager.AppSettings["mailDisplayName"];
                var port = ConfigurationManager.AppSettings["port"];
                #endregion

                #region Create SMTP
                smtpClient.Host = smtp;
                smtpClient.Port = Convert.ToInt16(port);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword);
                #endregion Create SMTP

                #region Create Mail an recievers
                var mail = new MailMessage();
                mail.From = new MailAddress(mailAccount, mailDisplayName);
                foreach (var mailDirection in mailAdresses.Where(x => !string.IsNullOrEmpty(x)))
                {
                    mail.To.Add(new MailAddress(mailDirection));
                }
                foreach (var mailCC in ccAddresses.Where(x => !string.IsNullOrEmpty(x)))
                {
                    mail.CC.Add(new MailAddress(mailCC));
                }

                #endregion

                #region Create Mail Variables

                string htmlBody;
                string subject;
                var nombre = reserva.Cliente.Nombre + reserva.Cliente.ApellidoPaterno + reserva.Cliente.ApellidoPaterno;
                var obra = reserva.Obra.Nombre;
                var fecha = reserva.FechaReserva;
                var teatro = reserva.Obra.Teatro.Nombre;
                var hora = reserva.Horario;
                //var totalObras
                //var zona = reserva.Obra.
                var ubicacion = reserva.Asientos;
                var precio = reserva.PrecioTotal;

                #endregion Create Mail Variables

                #region Set Mail Variable Values


                #endregion Set Mail Variable Values

                #region Set Mail Body

                switch (action)
                {
                    case Enumerables.MailAction.TeatroConfirmacionReserva:
                        htmlBody = Constantes.Mails.TeatroConfirmacionReserva;
                        htmlBody = htmlBody.Replace("%Nombre", nombre);
                        htmlBody = htmlBody.Replace("%Obra", obra);
                        htmlBody = htmlBody.Replace("%Fecha", fecha.ToShortDateString());
                        htmlBody = htmlBody.Replace("%Obra", obra);
                        htmlBody = htmlBody.Replace("%Teatro", teatro);
                        //htmlBody = htmlBody.Replace("%Zona", zona);
                        //htmlBody = htmlBody.Replace("%Zona", zona);
                        htmlBody = htmlBody.Replace("%Ubicacion", ubicacion);
                        htmlBody = htmlBody.Replace("%Precio", precio.ToString());

                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(action), action, null);
                }

                #endregion Set Mail Body

                #region Set Mail Subject

                switch (action)
                {
                    case Enumerables.MailAction.TeatroConfirmacionReserva:
                        subject = Constantes.Subjects.TeatroConfirmacionReserva;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(action), action, null);
                }

                #endregion Set Mail Subject

                #region Get Mail Body embedded images paths

                //var rootFolder = AppDomain.CurrentDomain.BaseDirectory;
                //var logopath = Path.Combine(rootFolder, "MailImages/logo.png");
                //var iconpath = Path.Combine(rootFolder, "MailImages/tree-icon.png");

                #endregion Get Mail Body embedded images paths

                #region Set embedded images mail id
               // var logo = new LinkedResource(logopath, MediaTypeNames.Image.Jpeg);
                //var treeicon = new LinkedResource(iconpath, MediaTypeNames.Image.Jpeg);

                //logo.ContentId = "logo";
                //treeicon.ContentId = "tree-icon";

                #endregion

                #region Set Body and Images

                var html = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                //html.LinkedResources.Add(logo);
                //html.LinkedResources.Add(treeicon);

                #endregion Set Body and Images

                #region Set values to mail

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.AlternateViews.Add(html);

                #endregion Set values to mail

                #region Send Mail

                smtpClient.SendAsync(mail, null);

                smtpClient.SendCompleted += (s, e) =>
                {
                    LogEmail logEmail = new LogEmail();
                    logEmail.Asunto = subject;
                    logEmail.CorreoDestino = string.Join(",", mailAdresses.Select(x => x.ToString()).ToArray());
                    logEmail.CorreoDestinoCC = string.Join(",", ccAddresses.Select(x => x.ToString()).ToArray());
                    logEmail.Estado = "OK";
                    logEmail.FechaEnvio = DateTime.Now;
                    logEmail.FechaCreacion = DateTime.Now;
                    logEmail.UsuarioCreacion = Sesion.usuario.Login;
                    logEmail.Mensaje = htmlBody;
                    logEmail.Intento = 1;
                    logEmail.Descripcion = String.Empty;
                    if (e.Error != null)
                    {
                        logEmail.Estado = "FALLO";
                        logEmail.Descripcion = e.Error.InnerException.Message;
                    }
                    
                    logEmailRepository.Insert(logEmail);
                    smtpClient.Dispose();
                    mail.Dispose();
                    //logo.Dispose();
                    //treeicon.Dispose();
                };

                #endregion Send Mail

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
