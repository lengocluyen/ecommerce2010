using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Configuration;
using System.Xml;
using System.Text;
public class SendMail
{
    public SendMail() { }
    public static int Send(string to, string subject, string content)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("Sender"), ConfigurationManager.AppSettings.Get("Pass"));
        smtp.Host = ConfigurationManager.AppSettings.Get("SmtpHost");
        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SmtpPort"));
        smtp.EnableSsl = true;
        using (MailMessage message = new MailMessage())
        {
            try
            {
                message.From = new MailAddress(ConfigurationManager.AppSettings.Get("defaultSender"));
                message.To.Add(to);
                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = true;
                smtp.Send(message);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
    public static int Send(string[] To, string Subject, string Content)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("Sender"), ConfigurationManager.AppSettings.Get("Pass"));
        smtp.Host = ConfigurationManager.AppSettings.Get("SmtpHost");
        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SmtpPort"));
        smtp.EnableSsl = true;
        using (MailMessage message = new MailMessage())
        {
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("defaultSender"));
            foreach (string item in To)
            {
                message.To.Add(item);
            }
            message.Subject = Subject;
            message.Body = Content;
            message.IsBodyHtml = true;
            try
            {
                smtp.Send(message);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
    public int Send(string[] To)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("Sender"), ConfigurationManager.AppSettings.Get("Pass"));
        smtp.Host = ConfigurationManager.AppSettings.Get("SmtpHost");
        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SmtpPort"));
        smtp.EnableSsl = true;
        using (MailMessage message = new MailMessage())
        {
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("defaultSender"));
            foreach (string item in To)
            {
                message.To.Add(item);
            }
            message.Subject = this.Subject;
            message.Body = this.Body;
            message.IsBodyHtml = true;
            try
            {
                smtp.Send(message);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
    //********************************************************
    List<Replacement> replacements;
    public List<Replacement> Replacements
    {
        get
        {
            if (replacements == null)
                replacements = new List<Replacement>();
            return replacements;
        }
    }
    public SendMail(string mailType):this(mailType,new Replacement[0])
    {
    } 
    public SendMail(string mailType, params Replacement[] replacements)
    {
        foreach (Replacement item in replacements)
            Replacements.Add(item);
        XmlDocument Doc = new XmlDocument();
        Doc.Load(AppDomain.CurrentDomain.BaseDirectory+ConfigurationManager.AppSettings.Get("MailTemplatePath"));
        foreach (XmlNode mail in Doc.SelectSingleNode("EmailTemplates"))
        {
            if (mail.Attributes["Type"].Value.ToLower() == mailType.ToLower())
            {
                this.body = mail.SelectSingleNode("Body").InnerXml;
                this.htmlTagReplacement = mail.SelectSingleNode("Body").Attributes["HtmlTagReplacement"].Value;
                this.subject = mail.SelectSingleNode("Subject").InnerXml.Replace(Environment.NewLine, " ");//Không cho phép xuống dòng trên tiêu đề

                string replacementTag = mail.SelectSingleNode("ReplacementTag").InnerText;
                int index = replacementTag.IndexOf('_');
                this.rBeginTag = replacementTag.Substring(0, index);
                this.rEndTag = replacementTag.Substring(index + 1);
            }
        }
    }
    private string body;
    private string subject;
    private string htmlTagReplacement;
    private string rBeginTag;
    private string rEndTag;
    public string REndTag
    {
        get { return rEndTag; }
        set { rEndTag = value; }
    }
    public string RBeginTag
    {
        get { return rBeginTag; }
        set { rBeginTag = value; }
    }
    public string HtmlTagReplacement
    {
        get { return htmlTagReplacement; }
        set { htmlTagReplacement = value; }
    }
    public string Subject
    {
        get { return GetStringAfterReplace(subject); }
        set { subject = value; }
    }
    public string Body
    {
        get { return GetStringAfterReplace(body); }
        set { body = value; }
    }
    private string GetStringAfterReplace(string source)
    {
        if (string.IsNullOrEmpty(source))
            return source;
        string result = source;
        //Thay thế các nguồn dữ liệu đưa vào: [ Đổ dữ liệu ]
        if (replacements != null)
            foreach (Replacement item in replacements)
            {
                result = result.Replace(rBeginTag + item.RKey + rEndTag, item.RValue);
            }
        //Chuyển ký tự thay thế của html thành kí tự tag html (</>); Nếu có
        if (htmlTagReplacement.Length > 0)
        {
            result = result.Replace(htmlTagReplacement.Substring(0, htmlTagReplacement.IndexOf('_')), "<");
            result = result.Replace(htmlTagReplacement.Substring(htmlTagReplacement.IndexOf('_') + 1), ">");
        }
        return result;
    }
}
//*****************************************************************
public class Replacement
{
    string rKey;
    string rValue;
    public string RKey
    {
        get { return rKey; }
    }
    public string RValue
    {
        get { return rValue; }
    }
    public Replacement(string rKey, string rValue)
    {
        this.rKey = rKey;
        this.rValue = rValue;
    }
}
