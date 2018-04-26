using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Personel.Util
{
    public class EmailHelper
    {
        private IConfigurationRoot ConfigRoot { get; set; }

        public EmailHelper(IConfigurationRoot configRoot)
        {
            ConfigRoot = configRoot;
        }

        public async Task<bool> sendResetPasswordMail(string from, string to, string subject, string link, string domain, string apiKey)
        {
            MailService ms = new MailService();
            return await ms.sendmail(from, to, subject, link, domain, apiKey);
        }

        public async Task<bool> SendMail(string forgottenPasswordToken, string userEmail, string requestValue)
        {
            var EmailSettings = ConfigRoot.GetSection("EmailSettings");

            var domain = EmailSettings["Domain"];
            var apiKey = EmailSettings["ApiKey"];
            var from = EmailSettings["FromEmail"];

            string paragraph1 = "Please click the link below to reset your password.";
            var link = string.Format("http://{0}/Account/ResetPassword?forgottenPasswordToken={1}", requestValue, forgottenPasswordToken);
            string message = string.Format("{0}<br>{1}", paragraph1, link);
            link = string.Format("<a href='{0}'>{1}</a>", link, link);
            return await sendResetPasswordMail(from, userEmail, "Dream Reset Password", link, domain, apiKey);
        }

        public async Task<bool> SendWelcomeEmail(string forgottenPasswordToken, string userEmail, string name, string requestValue)
        {
            var EmailSettings = ConfigRoot.GetSection("EmailSettings");

            var domain = EmailSettings["Domain"];
            var apiKey = EmailSettings["ApiKey"];
            var from = EmailSettings["FromEmail"];

            string welcome = string.Format("Hi {0}, ", name);
            string paragraph1 = "Welcome to Dream Platform.";
            string paragraph2 = string.Format("Username : {0}", userEmail);

            var link = string.Format("http://{0}/Account/ResetPassword?forgottenPasswordToken={1}", requestValue, forgottenPasswordToken);
            link = string.Format("<a href='{0}'>{1}</a>", link, link);

            string message = string.Format("{0}<br>{1}<br>{2}<br>{3}", welcome, paragraph1, paragraph2, link);

            return await sendResetPasswordMail(from, userEmail, "Dream New Login", message, domain, apiKey);
        }

        public async Task<bool> SendVerifyAccountEmail(string memberSerialKey, string userEmail, string requestValue)
        {

            var EmailSettings = ConfigRoot.GetSection("EmailSettings");

            var domain = EmailSettings["Domain"];
            var apiKey = EmailSettings["ApiKey"];
            var from = EmailSettings["FromEmail"];

            string welcome = string.Format("Welcome to the Dream platform, ");
            string paragraph1 = "Please click the following link to verify your account.";

            var link = string.Format("http://{0}/CompleteProfile/VerifyAccount?verifyAccountToken={1}", requestValue, memberSerialKey);
            link = string.Format("<a href='{0}'>{1}</a>", link, link);

            string message = string.Format("{0}<br>{1}<br>{2}", welcome, paragraph1, link);

            return await sendResetPasswordMail(from, userEmail, "Dream Account Verification", message, domain, apiKey);
        }
    }
}
