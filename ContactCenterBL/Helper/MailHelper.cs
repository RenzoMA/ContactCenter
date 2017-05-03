using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
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
            string htmlImageBody = "";
            string subject = "";

            try
            {
                var smtpClient = new SmtpClient();

                #region Get Config Variables
                String correo = "";
                String password = "";
                if (Sesion.aplicacion.CorreoNotificacion.Equals(String.Empty))
                {
                    correo = ConfigurationManager.AppSettings["mailAccount"];
                    password = ConfigurationManager.AppSettings["mailPassword"];
                }
                else
                {
                    correo = Sesion.aplicacion.CorreoNotificacion;
                    password = Sesion.aplicacion.Contraseña;
                }
                var mailAccount = correo;
                var mailPassword = password;

                var smtp = ConfigurationManager.AppSettings["smtp"];
                var mailDisplayName = ConfigurationManager.AppSettings["mailDisplayName"];
                var port = ConfigurationManager.AppSettings["port"];
                var sslEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["sslEnabled"]);
                var domain = ConfigurationManager.AppSettings["Domain"];

                #endregion

                #region Create SMTP
                smtpClient.Host = smtp;
                smtpClient.Port = Convert.ToInt16(port);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                if(domain != null)
                {
                    smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword, domain);
                }
                else
                {
                    smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword);
                }
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

                //System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("es-PE");
                var nombre = reserva.Cliente.Nombre + " " + reserva.Cliente.ApellidoPaterno + " " + reserva.Cliente.Apellidomaterno;
                var obra = reserva.Obra.Nombre;
                var fecha = reserva.FechaReserva.ToString("dd/MM/yyyy"/*, cultureinfo*/);
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
                        htmlBody = ContactCenterBL.Properties.Resources.nuevomail;
                        htmlBody = htmlBody.Replace("%Nombre", nombre);
                        htmlBody = htmlBody.Replace("%Obra", obra);
                        htmlBody = htmlBody.Replace("%Fecha", fecha);
                        htmlBody = htmlBody.Replace("%Teatro", teatro);
                        htmlBody = htmlBody.Replace("%Hora", fecha + " - " + hora);
                        htmlBody = htmlBody.Replace("%Total", totalObras.ToString());
                        htmlBody = htmlBody.Replace("%Ubicacion", ubicacion);
                        htmlBody = htmlBody.Replace("%Precio", precio.ToString("#.00"));

                        htmlImageBody = ContactCenterBL.Properties.Resources.detail;
                        htmlImageBody = htmlImageBody.Replace("%Nombre", nombre);
                        htmlImageBody = htmlImageBody.Replace("%Obra", obra);
                        htmlImageBody = htmlImageBody.Replace("%Fecha", fecha);
                        htmlImageBody = htmlImageBody.Replace("%Teatro", teatro);
                        htmlImageBody = htmlImageBody.Replace("%Hora", fecha + " - " + hora);
                        htmlImageBody = htmlImageBody.Replace("%Total", totalObras.ToString());
                        htmlImageBody = htmlImageBody.Replace("%Ubicacion", ubicacion);
                        htmlImageBody = htmlImageBody.Replace("%Precio", precio.ToString("#.00"));

                        List<String> zonas = new List<String>();
                        foreach (DetalleReserva detalleRes in reserva.ListaDetalles.OrderBy(tx => tx.NombreZona).ToList())
                        {
                            if (!zonas.Contains(detalleRes.NombreZona)) 
                            {
                                zonas.Add(detalleRes.NombreZona);
                            }
                        }

                        string detalle = "";
                        string filAsiento = "";
                        int contador = 0;
                        foreach (String nomZona in zonas)
                        {
                            foreach (DetalleReserva detalleRes2 in reserva.ListaDetalles.Where(tx => tx.NombreZona == nomZona))
                            {
                                    filAsiento += detalleRes2.NombreFila + " / " + detalleRes2.NombreAsiento + ", ";
                                
                            }
                            filAsiento = filAsiento.TrimEnd(',',' ');
                            //detalle += "<tr><td style= 'text-align:right;'>Sector</td><td>:</td><td></td><td></td><td style= 'text-align:left;'>" + nomZona + "</td></tr><tr><td style= 'text-align:right;' >Ubicaciones</td><td>:</td><td></td><td></td><td style= 'text-align:left;'>" + filAsiento + "</td></tr>";
                            detalle += $"<p style='margin-top:3%; margin-bottom: 2%'>ZONA: {nomZona}</p> <p style='margin-top:3%; margin-bottom: 2%'> UBICACIÓN: {filAsiento}</p>";
                            filAsiento = "";
                        }

                        htmlBody = htmlBody.Replace("varDetalle", detalle);
                        htmlImageBody = htmlImageBody.Replace("varDetalle", detalle);
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
                //var cabeceraImgPath = Path.Combine("../../Resources/cabecera_correo2.jpg");
                //var rootFolder = AppDomain.CurrentDomain.BaseDirectory;
                //var cabepath = Path.Combine(rootFolder, "../../Resources/cabecera_correo2.jpg");
                Image ImageCabe = ContactCenterBL.Properties.Resources.cabecera;
                Byte[] imageCabeByte = Convertir_Imagen_Bytes(ImageCabe);
                MemoryStream ca = new MemoryStream(imageCabeByte);


                Image image = Image.FromStream(ca);
                Guid id = Guid.NewGuid();
                image.Save($"C:\\BackupTeatro\\{id.ToString()}.jpg");
                string path = $"C:\\BackupTeatro\\{id.ToString()}.jpg";


                Image image2 = Image.FromStream(ms);
                Guid id2 = Guid.NewGuid();
                image2.Save($"C:\\BackupTeatro\\{id2.ToString()}.jpg");
                string path2 = $"C:\\BackupTeatro\\{id2.ToString()}.jpg";

                htmlBody = htmlBody.Replace("%Cabecera", path);
                htmlBody = htmlBody.Replace("%ImagenObra", path2);

                htmlImageBody = htmlImageBody.Replace("%Cabecera", path);
                htmlImageBody = htmlImageBody.Replace("%ImagenObra", path2);


                Image imageMail = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImageGdiPlus(htmlImageBody);
                //imageMail.Save($"C:\\BackupTeatro\\test2.jpg");
                //Image imagex = Image.FromFile($"C:\\BackupTeatro\\test2.jpg");
                Byte[] imageMailBytes = Convertir_Imagen_Bytes(imageMail);
                MemoryStream imageMailMemoryStream = new MemoryStream(imageMailBytes);
                //mail.Attachments.Add(new Attachment(imageMailMemoryStream, "Compra.jpg"));

                


                var imageMailLinked = new LinkedResource(imageMailMemoryStream, MediaTypeNames.Image.Jpeg);
                imageMailLinked.ContentId = "obraimagen";

                Byte[] pdfFile = PdfSharpConvert(htmlBody);
                MemoryStream pdfStream = new MemoryStream(pdfFile);
                mail.Attachments.Add(new Attachment(pdfStream, "Confirmación de compra.pdf"));

                if (File.Exists(path2))
                {
                    File.Delete(path2);
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                htmlBody = htmlBody.Replace($"C:\\BackupTeatro\\{id.ToString()}.jpg", "%Cabecera");
                htmlBody = htmlBody.Replace($"C:\\BackupTeatro\\{id2.ToString()}.jpg", "%ImagenObra");
                htmlImageBody = htmlImageBody.Replace($"C:\\BackupTeatro\\{id.ToString()}.jpg", "%Cabecera");
                htmlImageBody = htmlImageBody.Replace($"C:\\BackupTeatro\\{id2.ToString()}.jpg", "%ImagenObra");

                #endregion Get Mail Body embedded images paths

                #region Set embedded images mail id

                //var cabecera = new LinkedResource(ca, MediaTypeNames.Image.Jpeg);
                //cabecera.ContentId = "Cabecera";
                ////cabecera.TransferEncoding = TransferEncoding.Base64;

                //var logo = new LinkedResource(ms, MediaTypeNames.Image.Jpeg);
                //logo.ContentId = "ImagenObra";
                ////logo.TransferEncoding = TransferEncoding.Base64;

                #endregion

                #region Set Body and Images

                var newHtml = ContactCenterBL.Properties.Resources._base;

                var html = AlternateView.CreateAlternateViewFromString(newHtml, null, MediaTypeNames.Text.Html);
                //html.TransferEncoding = TransferEncoding.Base64;
                html.LinkedResources.Add(imageMailLinked);
                //html.LinkedResources.Add(cabecera);

                #endregion Set Body and Images

                #region Set values to mail

                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
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
                    logEmail.MensajeImagen = htmlImageBody;
                    logEmail.FechaCreacion = DateTime.Now;
                    logEmail.UsuarioCreacion = Sesion.usuario.Login;
                    logEmail.Mensaje = htmlBody;
                    logEmail.Intento = 1;
                    logEmail.Descripcion = String.Empty;
                    if (e.Error != null)
                    {
                        logEmail.Estado = "FALLO";
                        if (e.Error.InnerException != null)
                        {
                            logEmail.Descripcion = e.Error.InnerException.Message;
                        }
                        else
                        {
                            logEmail.Descripcion = e.Error.Message;
                        }

                    }

                    logEmailRepository.Insert(logEmail);
                    if (e.Error != null)
                    {
                        MessageBox.Show("No se envió el correo\n\n" +
                                        "Cliente: \n"+nombre + "\n" +
                                        "Obra: \n"+obra + "\n" +
                                        "Fecha Reserva: \n" + reserva.FechaReserva.ToShortDateString() + "\n" +
                                        "Correo: \n" + reserva.Cliente.Correo +"\n\n" +
                                        "Error: \n"+ e.Error.Message, "Error enviando email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    smtpClient.Dispose();
                    mail.Dispose();
                    //logo.Dispose();
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
                logEmail.MensajeImagen = htmlImageBody;
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
                String correo = "";
                String password = "";
                if (Sesion.aplicacion.CorreoNotificacion.Equals(String.Empty))
                {
                    correo = ConfigurationManager.AppSettings["mailAccount"];
                    password = ConfigurationManager.AppSettings["mailPassword"];
                }
                else
                {
                    correo = Sesion.aplicacion.CorreoNotificacion;
                    password = Sesion.aplicacion.Contraseña;
                }
                var mailAccount = correo;
                var mailPassword = password;
                var smtp = ConfigurationManager.AppSettings["smtp"];
                var mailDisplayName = ConfigurationManager.AppSettings["mailDisplayName"];
                var port = ConfigurationManager.AppSettings["port"];
                var sslEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["sslEnabled"]);
                var domain = ConfigurationManager.AppSettings["Domain"];
                #endregion

                #region Create SMTP
                smtpClient.Host = smtp;
                smtpClient.Port = Convert.ToInt16(port);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                if (domain != null)
                {
                    smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword, domain);
                }
                else
                {
                    smtpClient.Credentials = new NetworkCredential(mailAccount, mailPassword);
                }
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

                Image ImageCabe = ContactCenterBL.Properties.Resources.cabecera;
                Byte[] imageCabeByte = Convertir_Imagen_Bytes(ImageCabe);
                MemoryStream ca = new MemoryStream(imageCabeByte);
                #endregion Get Mail Body embedded images paths

                #region Set embedded images mail id
                var cabecera = new LinkedResource(ca, MediaTypeNames.Image.Jpeg);
                cabecera.ContentId = "Cabecera";
                //cabecera.TransferEncoding = TransferEncoding.Base64;
                var logo = new LinkedResource(ms, MediaTypeNames.Image.Jpeg);
                //logo.TransferEncoding = TransferEncoding.Base64;
                logo.ContentId = "ImagenObra";

                var imageText = logEmail.MensajeImagen;

                Image imageMail;
                AlternateView html = null;
                if (imageText.Equals(String.Empty)) // legacy emails
                {
                    html = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
                    html.LinkedResources.Add(logo);
                    html.LinkedResources.Add(cabecera);
                }
                else
                {
                    Image image = Image.FromStream(ca);
                    Guid id = Guid.NewGuid();
                    image.Save($"C:\\BackupTeatro\\{id.ToString()}.jpg");
                    string path = $"C:\\BackupTeatro\\{id.ToString()}.jpg";


                    Image image2 = Image.FromStream(ms);
                    Guid id2 = Guid.NewGuid();
                    image2.Save($"C:\\BackupTeatro\\{id2.ToString()}.jpg");
                    string path2 = $"C:\\BackupTeatro\\{id2.ToString()}.jpg";

                    htmlBody = htmlBody.Replace("%Cabecera", path);
                    htmlBody = htmlBody.Replace("%ImagenObra", path2);
                    imageText = imageText.Replace("%Cabecera", path);
                    imageText = imageText.Replace("%ImagenObra", path2);

                    imageMail = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImageGdiPlus(imageText);
                    //imageMail.Save($"C:\\BackupTeatro\\test2.jpg");
                    //Image imagex = Image.FromFile($"C:\\BackupTeatro\\test2.jpg");
                    Byte[] imageMailBytes = Convertir_Imagen_Bytes(imageMail);
                    MemoryStream imageMailMemoryStream = new MemoryStream(imageMailBytes);
                    var imageMailLinked = new LinkedResource(imageMailMemoryStream, MediaTypeNames.Image.Jpeg);
                    imageMailLinked.ContentId = "obraimagen";
                    Byte[] pdfFile = PdfSharpConvert(htmlBody);
                    MemoryStream pdfStream = new MemoryStream(pdfFile);
                    mail.Attachments.Add(new Attachment(pdfStream, "Confirmación de compra.pdf"));

                    if (File.Exists(path2))
                    {
                        File.Delete(path2);
                    }
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    htmlBody = htmlBody.Replace($"C:\\BackupTeatro\\{id.ToString()}.jpg", "%Cabecera");
                    htmlBody = htmlBody.Replace($"C:\\BackupTeatro\\{id2.ToString()}.jpg", "%ImagenObra");
                    imageText = imageText.Replace($"C:\\BackupTeatro\\{id.ToString()}.jpg", "%Cabecera");
                    imageText = imageText.Replace($"C:\\BackupTeatro\\{id2.ToString()}.jpg", "%ImagenObra");
                    var newHtml = ContactCenterBL.Properties.Resources._base;
                    html = AlternateView.CreateAlternateViewFromString(newHtml, null, MediaTypeNames.Text.Html);
                    //html.TransferEncoding = TransferEncoding.Base64;
                    html.LinkedResources.Add(imageMailLinked);
                }

                
                

                //mail.Attachments.Add(new Attachment(imageMailMemoryStream, "Compra.jpg"));


                

                
                #endregion

                #region Set Body and Images

                
                //html.LinkedResources.Add(cabecera);

                #endregion Get Mail Body embedded images paths

                #region Set values to mail

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                //Attachment inlineLogo = new Attachment(@"../../Resources/cabecera_correo2.jpg");
                //string contentID = "cabe";
                //inlineLogo.ContentId = contentID;
                //inlineLogo.ContentDisposition.Inline = true;
                //inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                //mail.Attachments.Add(inlineLogo);

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

        private static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        public static Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html,PdfSharp.PageSize.A4,margin: 0);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }

    }
}
