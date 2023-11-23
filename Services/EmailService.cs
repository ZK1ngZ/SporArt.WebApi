using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Crypto.Tls;

namespace SporArt.Services
{
    public class EmailService
    {
        public async Task Send(List<string> destinarios,
                              string assunto,
                              string corpoEmail,
                              string remetente)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(remetente));

            foreach (var item in destinarios)
            {
                email.To.Add(MailboxAddress.Parse(item));
            }

            email.Subject = assunto;

            email.Body = new TextPart() { Text = corpoEmail };

            var smtpHost = "smtp.gmail.com";
            var smtpPort = 465;
            var usuario = "brunotavaresguimaraes2@gmail.com";
            var password = "senha";

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(smtpHost, smtpPort, true);

            await smtp.AuthenticateAsync(usuario, password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}
