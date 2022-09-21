using System;
using System.Net;
using System.Net.Mail;
using VMS.Models;

namespace VMS.Infrastructure
{
    public class SendEmail
    {
        public void sendEmail(Application application, Opportunity opp, bool approved)
        {
            var mail = new MailMessage("no-reply@volunteen.com", application.Volunteer.Email);
            mail.IsBodyHtml = true;
            mail.Subject = "Application status update";
            if (approved)
            {
                mail.Body = $"<p> <h1>VolunTEEN</h1> \n" +
                $" Hi, {application.Volunteer.FirstName}! \n</p>" +
                $"<p>You have been approved for the opportunity: {opp.OpportunityName}, " +
                $"<h3>Congratulations!</h3></p>" + 
                $"<p> {opp.CreateUser} will contact you soon.</p>";
            }
            else
            {
                mail.Body = $"<p> <h1>VolunTEEN</h1> \n" +
                $" Hi, {application.Volunteer.FirstName}! \n</p>" +
                $"<p>Unfortunately, you have not been approved for the {opp.OpportunityName} opportunity, " +
                
                $"<p> You can still apply other opportunities </p>" +
                $"<p> Best of luck, VolunTEEN Team</p>";
            }

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("lilirezerata@gmail.com", "gnudwovjaaaykfhl"),
                EnableSsl = true,
            };
            smtpClient.Send(mail);

        }
    }
}


