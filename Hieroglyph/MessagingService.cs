using SendGridMail;
using SendGridMail.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hieroglyph
{
    public class MessagingService
    {
        private string _sendGridUserName;
        private string _sendGridApiKey;

        public MessagingService(string sendGridUserName, string sendGridApiKey)
        {
            _sendGridUserName = sendGridUserName;
            _sendGridApiKey = sendGridApiKey;
        }

        public async Task<bool> SendEmail(List<String> recipients, string subject, string bodyHtml, string fromEmail, string fromName)
        {
            bool isSuccess = false;

            // Create the email object first, then add the properties.
            var myMessage = SendGrid.GetInstance();

            // Add the message properties.
            myMessage.From = new MailAddress(fromEmail);
            myMessage.Header.AddTo(recipients);
            myMessage.AddTo(fromEmail);
            myMessage.Subject = subject;

            //Add the HTML and Text bodies
            myMessage.Html = bodyHtml;
            //myMessage.Text = “Hello World plain text!”;

            // Create network credentials to access your SendGrid account.
            var username = _sendGridUserName;
            var pswd = _sendGridApiKey;
            var credentials = new NetworkCredential(username, pswd);

            // Create a Web transport for sending email.
            var transportWeb = Web.GetInstance(credentials);

            // Send the email.
            transportWeb.Deliver(myMessage);

            isSuccess = true;

            return isSuccess;
        }
    }
}
