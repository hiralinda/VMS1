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
            mail.Subject = "VolunTEEN: Application status update";
            if (approved)
            {
                mail.Body =
                $"<p> <h1>VolunTEEN UPDATE</h1> \n</p>" +
                $"<p> Hi, {application.Volunteer.FirstName}! \n</p>" +
                $"<p> Thank you for your interest in volunteering.\n</p>" +
                $"<p>You have been approved for the \"{opp.OpportunityName}\" opportunity,</p>" +
                $"<p><h3>Congratulations!</h3></p>" + 
                $"<p> The non-profit will contact you soon with more information.</p>" + 
                $"<p><a href=\"https://volunteen.azurewebsites.net/Opportunities/ViewApplications\">Click here to see your opportunities</a></p>" +
                $"<p><img src=\"https://volunteen.azurewebsites.net/Images/volunteenLogo-min.png\" alt=volunTEEN logo width=\"150\" height=\"150\"></p>";
                
            }
            else
            {
                mail.Body =
                $"<p> <h1>VolunTEEN UPDATE</h1> \n</p>" +
                $"<p> Hi, {application.Volunteer.FirstName}! \n</p>" +
                $"<p> Thank you for your interest in volunteering.\n</p>" +
                $"<p> Unfortunately, you have not been approved for the \"{opp.OpportunityName}\" opportunity,</p>" +
                $"<p> You can still apply to other opportunities! </p>" +
                $"<p><a href=\"https://volunteen.azurewebsites.net/Opportunities/List\">Click here to check more opportunities</a></p>" +
                $"<p> Best of luck, " +
                $"<p><img src=\"https://volunteen.azurewebsites.net/Images/volunteenLogo-min.png\" alt=volunTEEN logo width=\"150\" height=\"150\"></p>";

                
            }

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("volunteenjax@gmail.com", "otqcnbojxicqcpgg"), 
                EnableSsl = true,
            };
            smtpClient.Send(mail);

        }
    }
}


