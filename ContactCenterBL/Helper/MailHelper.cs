using System;
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
using System.Drawing;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using System.Windows.Forms;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;

namespace ContactCenterBL.Helper
{
    public static class MailHelper
    {
        

        public static void SendMail(IList<string> mailAdresses, IList<string> ccAddresses, Enumerables.MailAction action, ILogEmailRepository logEmailRepository, Reserva reserva, byte[] attachment = null)
        {
            ContactCenterDA.Repositories.CC.TH.ObraRepository  obraRepository = new ContactCenterDA.Repositories.CC.TH.ObraRepository() ;
            string htmlBody = "";
            string subject = "";

            try
            {
                var smtpClient = new SmtpClient();

                #region Get Config Variables
                var mailAccount = ConfigurationManager.AppSettings["mailAccount"];
                var mailPassword = ConfigurationManager.AppSettings["mailPassword"];
                var smtp = ConfigurationManager.AppSettings["smtp"];
                var mailDisplayName = ConfigurationManager.AppSettings["mailDisplayName"];
                var port = ConfigurationManager.AppSettings["port"];
                var sslEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["sslEnabled"]);

                #endregion

                #region Create SMTP
                smtpClient.Host = smtp;
                smtpClient.Port = Convert.ToInt16(port);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword);
                smtpClient.EnableSsl = sslEnabled;
                #endregion Create SMTP

                #region Create Mail an recievers
                var mail = new MailMessage();
                mail.From = new MailAddress(mailAccount, mailDisplayName);
                foreach (var mailDirection in mailAdresses.Where(x => !string.IsNullOrEmpty(x)))
                {
                    mail.To.Add(new MailAddress(mailDirection.ToLower()));
                }
                foreach (var mailCC in ccAddresses.Where(x => !string.IsNullOrEmpty(x)))
                {
                    mail.CC.Add(new MailAddress(mailCC.ToLower()));
                }

                #endregion

                #region Create Mail Variables

                
                var nombre = reserva.Cliente.Nombre + " " + reserva.Cliente.ApellidoPaterno + " " + reserva.Cliente.Apellidomaterno;
                var obra = reserva.Obra.Nombre;
                var fecha = reserva.FechaReserva;
                var teatro = reserva.Obra.Teatro.Nombre;
                var hora = reserva.Horario;
                var totalObras = reserva.ListaDetalles.Count();
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
                        htmlBody = htmlBody.Replace("%Fecha", fecha.ToString("dd/MM/yy"));
                        htmlBody = htmlBody.Replace("%Obra", obra);
                        htmlBody = htmlBody.Replace("%Teatro", teatro);
                        htmlBody = htmlBody.Replace("%Hora", hora);
                        htmlBody = htmlBody.Replace("%Total", totalObras.ToString());
                        htmlBody = htmlBody.Replace("%Ubicacion", ubicacion);
                        htmlBody = htmlBody.Replace("%Precio", precio.ToString());

                        string detalle = "";
                        foreach (DetalleReserva detalleRes in reserva.ListaDetalles)
                        {
                            detalle += "<tr><td>"+detalleRes.NombreZona+ "</td><td>" + detalleRes.NombreFila + "</td><td>" + detalleRes.NombreAsiento + "</td></tr>";
                        }
                        htmlBody = htmlBody.Replace("varDetalle", detalle);
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


               Byte[] ba = obraRepository.GetImage(reserva.Obra.IdObra);
               MemoryStream ms = new MemoryStream(ba);
                
                #endregion Get Mail Body embedded images paths

                #region Set embedded images mail id
                   
                var logo = new LinkedResource(ms, MediaTypeNames.Image.Jpeg);
                

                logo.ContentId = "ImagenObra";
                //logo.TransferEncoding = TransferEncoding.Base64;

                #endregion

                #region Set Body and Images

                var html = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                //html.TransferEncoding = TransferEncoding.Base64;

                html.LinkedResources.Add(logo);

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
                    logEmail.IdObra = reserva.Obra.IdObra;
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
                    if (e.Error != null)
                    {
                        MessageBox.Show("No se envió el correo\n\n" +
                                        "Cliente: \n"+nombre + "\n" +
                                        "Obra: \n"+obra + "\n" +
                                        "Fecha Reserva: \n" + reserva.FechaReserva.ToShortDateString() + "\n" +
                                        "Correo: \n" + reserva.Cliente.Correo +"\n\n" +
                                        "Error: \n"+ e.Error.InnerException.Message, "Error enviando email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    smtpClient.Dispose();
                    mail.Dispose();
                    logo.Dispose();
                };

                #endregion Send Mail

            }
            catch (Exception ex)
            {

                LogEmail logEmail = new LogEmail();
                logEmail.Asunto = subject;
                logEmail.CorreoDestino = string.Join(",", mailAdresses.Select(x => x.ToString()).ToArray());
                logEmail.CorreoDestinoCC = string.Join(",", ccAddresses.Select(x => x.ToString()).ToArray());
                logEmail.Estado = "OK";
                logEmail.IdObra = reserva.Obra.IdObra;
                logEmail.FechaEnvio = DateTime.Now;
                logEmail.FechaCreacion = DateTime.Now;
                logEmail.UsuarioCreacion = Sesion.usuario.Login;
                logEmail.Mensaje = htmlBody;
                logEmail.Intento = 1;
                logEmail.Estado = "FALLO";
                logEmail.Descripcion = ex.Message;

                logEmailRepository.Insert(logEmail);

                MessageBox.Show("No se envió el correo\n\n" +
                                        "Cliente: \n" + reserva.Cliente.Nombre+" "+reserva.Cliente.ApellidoPaterno+" "+reserva.Cliente.Apellidomaterno + "\n" +
                                        "Obra: \n" + reserva.Obra.Nombre + "\n" +
                                        "Fecha Reserva: \n" + reserva.FechaReserva.ToShortDateString() + "\n" +
                                        "Correo: \n" + reserva.Cliente.Correo + "\n\n" +
                                        "Error: \n" + ex.Message, "Error enviando email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool SendMail(IList<string> mailAdresses, IList<string> ccAddresses, string originalHtml,string originalSubject, ILogEmailRepository logEmailRepository, byte[] attachment, LogEmail logEmail)
        {
            ContactCenterDA.Repositories.CC.TH.ObraRepository obraRepository = new ContactCenterDA.Repositories.CC.TH.ObraRepository();
            try
            {
                var smtpClient = new SmtpClient();

                #region Get Config Variables
                var mailAccount = ConfigurationManager.AppSettings["mailAccount"];
                var mailPassword = ConfigurationManager.AppSettings["mailPassword"];
                var smtp = ConfigurationManager.AppSettings["smtp"];
                var mailDisplayName = ConfigurationManager.AppSettings["mailDisplayName"];
                var port = ConfigurationManager.AppSettings["port"];
                var sslEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["sslEnabled"]);
                #endregion

                #region Create SMTP
                smtpClient.Host = smtp;
                smtpClient.Port = Convert.ToInt16(port);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword);
                smtpClient.EnableSsl = sslEnabled;
                #endregion Create SMTP

                #region Create Mail an recievers
                var mail = new MailMessage();
                mail.From = new MailAddress(mailAccount, mailDisplayName);
                foreach (var mailDirection in mailAdresses.Where(x => !string.IsNullOrEmpty(x)))
                {
                    mail.To.Add(new MailAddress(mailDirection.ToLower()));
                }
                foreach (var mailCC in ccAddresses.Where(x => !string.IsNullOrEmpty(x)))
                {
                    mail.CC.Add(new MailAddress(mailCC.ToLower()));
                }

                #endregion

                #region Create Mail Variables

                string htmlBody = originalHtml;
                string subject = originalSubject;

                #endregion Create Mail Variables


                #region Get Mail Body embedded images paths

                Byte[] ba = obraRepository.GetImage(logEmail.IdObra);
                MemoryStream ms = new MemoryStream(ba);

                #endregion Get Mail Body embedded images paths

                #region Set embedded images mail id

                var logo = new LinkedResource(ms, MediaTypeNames.Image.Jpeg);

                logo.ContentId = "ImagenObra";

                #endregion

                #region Set Body and Images

                var html = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                html.LinkedResources.Add(logo);

                #endregion Get Mail Body embedded images paths

                #region Set values to mail

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.AlternateViews.Add(html);

                #endregion Set values to mail

                #region Send Mail

                smtpClient.Send(mail);
                logEmail.Asunto = subject;
                logEmail.CorreoDestino = string.Join(",", mailAdresses.Select(x => x.ToString()).ToArray());
                logEmail.CorreoDestinoCC = string.Join(",", ccAddresses.Select(x => x.ToString()).ToArray());
                logEmail.Estado = "OK";
                logEmail.FechaEnvio = DateTime.Now;
                logEmail.FechaModificacion = DateTime.Now;
                logEmail.UsuarioModificacion = Sesion.usuario.Login;
                logEmail.Mensaje = htmlBody;
                logEmail.Intento = logEmail.Intento + 1;
                logEmail.Descripcion = String.Empty;
                logEmailRepository.Update(logEmail);
                smtpClient.Dispose();
                mail.Dispose();
                logo.Dispose();
                return true;
                #endregion Send Mail

            }
            catch (Exception ex)
            {
                logEmail.CorreoDestino = string.Join(",", mailAdresses.Select(x => x.ToString()).ToArray());
                logEmail.CorreoDestinoCC = string.Join(",", ccAddresses.Select(x => x.ToString()).ToArray());
                logEmail.FechaEnvio = DateTime.Now;
                logEmail.FechaModificacion = DateTime.Now;
                logEmail.UsuarioModificacion = Sesion.usuario.Login;
                logEmail.Intento = logEmail.Intento + 1;
                logEmail.Estado = "FALLO";
                logEmail.Descripcion = ex.Message;
                logEmailRepository.Update(logEmail);
                return false;
            }
        }
    }
}
