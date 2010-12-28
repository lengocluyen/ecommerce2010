using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace Libs
{
    public class LibMail
    {
        public LibMail() { }
        private List<string> _listStringEmail;
        private string _subjec;
        private string _content;
        private bool _isHtml;

        public List<string> ListMailSend
        {
            get { return _listStringEmail; }
            set { _listStringEmail = value; }
        }
        public string Subject
        {
            get { return _subjec; }
            set { _subjec = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public bool IsHtml
        {
            get { return _isHtml; }
            set { _isHtml = value; }
        }

        //Send

        public static bool Send(LibMail mail)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("Sender"), ConfigurationManager.AppSettings.Get("MailPass"));
            smtp.Host = ConfigurationManager.AppSettings.Get("SmtpHost");
            smtp.Port = LibConvert.ConvertToInt(ConfigurationManager.AppSettings.Get("SmtpPort"), 25);
            smtp.EnableSsl = true;
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(ConfigurationManager.AppSettings.Get("defaultSender"));
                for (int i = 0; i < mail.ListMailSend.Count; i++)
                {
                    message.To.Add(mail.ListMailSend[i]);
                }
                message.Subject = mail.Subject;
                message.Body = mail.Content;
                message.IsBodyHtml = mail.IsHtml;
                message.Priority = MailPriority.High;
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
