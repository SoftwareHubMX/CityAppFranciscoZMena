using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Mail;

namespace CityApp.Server.Servicios.Correo
{
    public class ServicioEnviarCorreo
    {
        private Codificador Codificador = new Codificador();
        public Response<object> Enviar(string correo, string data)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls13;
            Response<object> response = new Response<object>();

            try
            {
                string email = "capp@cityapp.mx";
                string pass = "y#GGs3NhNU7xY93t";
                string subject = "CityApp";
                string host = "smtp.dreamhost.com";

                MailMessage mensaje = new MailMessage();

                mensaje.From = new MailAddress(email);
                mensaje.To.Add(Codificador.DecryptCorreo(correo));
                //mensaje.To.Add(correo);
                mensaje.Subject = subject;
                mensaje.Body = data;

                mensaje.IsBodyHtml = true;
                mensaje.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Credentials = new System.Net.NetworkCredential(email, pass);
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mensaje);

                smtp.Dispose();
                response.Status.Exito = 1;
            }
            catch (Exception e)
            {
                response.Status.Exception = e.Message;
                response.Status.Mensaje = "No se pudo enviar el correo";
            }

            return response;
        }
    }
}
