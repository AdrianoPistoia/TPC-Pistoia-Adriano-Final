using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DataManager
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("capibaralevel5@gmail.com", "Barbalocklevel5");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceprogramacioniii.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>Codigo de seguridad para recuperacion de contraseña</h1> <br>Hola, tu codigo es ";
            //email.Body = cuerpo;

        }

        public void enviarCodigo(string emailDestino, int codigo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceprogramacioniii.com");
            email.To.Add(emailDestino);
            email.Subject = "Codigo de Recuperacion - Systema Academico";
            email.IsBodyHtml = true;
            email.Body = "<h1>Codigo de seguridad para recuperacion de contraseña</h1> <br>Hola, tu codigo es <h1>" + codigo + "</h1>";
            //email.Body = cuerpo;
            
        }

        public void enviarContra(string emailDestino,string contra)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceprogramacioniii.com");
            email.To.Add(emailDestino);
            email.Subject = "Contraseña - Systema Academico";
            email.Body = " tu contraseña es "+contra ;
            
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}