using System;
using System.Net;
using System.Net.Mail;

namespace VMS.Infrastructure
{
    public class SendEmail
    {
        public void sendEmail(string email)
        {
            using var smtpClient = new SmtpClient("smtp.gmail.com") 
            {
                Port = 587,
                Credentials = new NetworkCredential("lilirezerata@gmail.com", "gnudwovjaaaykfhl"),
                EnableSsl = true,
            };
            var messageApproved = $"<p>Welcome to SiteName. To activate your account, visit this URL: \n    " +
                $"<a href=\"http://sitename.com/a?key=1234%22%3Ehttp://SiteName.com/a?key=1234</a>.\n</p>";





            var mail = new MailMessage("lilirezerata@gmail.com", email, "VolunTEEN Updated", messageApproved);
            mail.IsBodyHtml = true;
            smtpClient.Send(mail);

        }
    }
}


