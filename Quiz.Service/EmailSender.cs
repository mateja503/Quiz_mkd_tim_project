using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using Quiz.Utility.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Net.Mail;
using MailKit.Net.Smtp;

namespace Quiz.Utility
{
    public class EmailSender(IOptions<SmtpOptions> options) : IEmailSender
    {

        private readonly SmtpOptions _options = options.Value;
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic for sending email
            //return Task.CompletedTask;
            //throw new NotImplementedException();
            using var body = new TextPart(TextFormat.Html);
            body.Text = htmlMessage;

            using var message = new MimeMessage();
            message.From.Add(new MailboxAddress(// configure this for my application 
                    null,
                    "noreply@example.com"
                ));

            message.To.Add(new MailboxAddress(//sending message to user 
                        null,
                        email
                   ));

            message.Subject = subject;
            message.Body = body;    

            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Host,_options.Port);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

        }
    }
}
