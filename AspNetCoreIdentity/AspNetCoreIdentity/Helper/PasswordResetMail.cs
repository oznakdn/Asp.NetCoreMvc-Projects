using System.Net;
using System.Net.Mail;

namespace AspNetCoreIdentity.Helper
{
    public static class PasswordResetMail
    {
        public static void PasswordResetSendMail(string link)
        {
            MailMessage mail = new();
          
            mail.From = new MailAddress("info@myblog.com");
            mail.Subject = "Password Reset Mail";
            mail.Body = "<h2>For your password reseting, please click the down link.</h2><hr/>";
            mail.Body += $"<a href='{link}'>Password Reset Link</a>";
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new("mail.myblog.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("myusername", "mypassword");

            smtpClient.Send(mail);
        }
    }
}
