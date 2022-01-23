using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;

namespace SushiSite.Helpers
{
    public class EmailService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
           //MailjetClient client = new MailjetClient("71520fc81f7bfb11584d2c548c425c2d", "293d9a9a343e793acbeb1cd9b2149063");
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "supreme.chornogo@gmail.com")
               .Property(Send.FromName, "Vadim")
               .Property(Send.Subject, subject)
               .Property(Send.TextPart, "Dear passenger, welcome to Mailjet! May the delivery force be with you!")
               .Property(Send.HtmlPart, htmlMessage)
               .Property(Send.Recipients, new JArray {
            new JObject {
             {"Email", email}
             }
                });
            //MailjetResponse response = await client.PostAsync(request);





            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "supreme.chornogo@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("in-v3.mailjet.com", 25, false);
                await client.AuthenticateAsync("71520fc81f7bfb11584d2c548c425c2d", "293d9a9a343e793acbeb1cd9b2149063");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
