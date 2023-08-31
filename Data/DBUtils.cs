using System.Net.Mail;
using System.Net;

namespace EcommerceFull.Data
{
    public class DBUtils
    {
        private readonly IConfiguration _configuration;

        public DBUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<bool> Enviar(string email, string subject, string message, string name)
        {
            try
            {
                string host = _configuration["EMail:Host"];
                string nome = name;
                string username = _configuration["EMail:UserName"];
                string senha = _configuration["EMail:Senha"];
                int porta = Convert.ToInt32(_configuration["EMail:Porta"]);

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                // Gravar log de erro ao enviar e-mail
                Console.WriteLine("email nao enviado" + ex.Message);
                return false;
            }
        }
    }
}
