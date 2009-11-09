using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Coal.Util
{
    /// <summary>
    /// mailHelper is a helper class that takes the System.Net.Mail library
    /// and provides a simple library for anyone to use.
    /// </summary>
    public class MailHelper
    {
        #region public members

        /// <summary>
        /// The status of the mail being sent using the async method
        /// </summary>
        public static string mailStatus = String.Empty;

        /// <summary>
        /// Notifies the calling application of the email status
        /// </summary>
        public static event EventHandler notifyCaller;

        #endregion

        #region private members

        private string _fromAddress;
        private string _subject;
        private string _body;
        private string _smtpServer;
        private bool _isHtmlEmail = false;
        private SmtpClient _mailClient = null;
        private MailMessage _mailMessage = null;
        private MailAddress _mailFromAddress = null;

        #endregion

        #region properties

        /// <summary>
        /// Gets the SmtpClient
        /// </summary>
        private SmtpClient mailClient
        {
            get
            {
                return _mailClient;
            }
        }

        /// <summary>
        /// Gets the MailMessage
        /// </summary>
        private MailMessage mailMessage
        {
            get
            {
                return _mailMessage;
            }
        }

        /// <summary>
        /// Gets the from MailAddress
        /// </summary>
        private MailAddress mailFromAddress
        {
            get
            {
                return _mailFromAddress;
            }
        }

        /// <summary>
        /// Gets or Sets the address the email is from
        /// </summary>
        public string fromAddress
        {
            get
            {
                return _fromAddress;
            }
            set
            {
                if (value != "")
                {
                    _fromAddress = value;
                }
            }
        }

        /// <summary>
        /// Gets or Sets the subject of the email
        /// </summary>
        public string subject
        {
            get
            {
                return _subject;
            }
            set
            {
                if (value != "")
                {
                    _subject = value;
                }
            }
        }

        /// <summary>
        /// Gets or Sets the body of the email
        /// </summary>
        public string body
        {
            get
            {
                return _body;
            }
            set
            {
                if (value != "")
                {
                    _body = value;
                }
            }
        }

        /// <summary>
        /// Gets or Sets the smtp server address
        /// </summary>
        public string smtpServer
        {
            get
            {
                return _smtpServer;
            }
            set
            {
                if (value != "")
                {
                    _smtpServer = value;
                }
            }
        }

        /// <summary>
        /// Gets or Sets if this is a html email.  True for html false for text
        /// </summary>
        public bool isHtmlEmail
        {
            get
            {
                return _isHtmlEmail;
            }
            set
            {
                _isHtmlEmail = value;
            }
        }

        #endregion

        #region events

        /// <summary>
        /// Notifies the calling application about the status of the email being sent
        /// </summary>
        protected static void OnNotifyCaller()
        {
            if (notifyCaller != null)
            {
                notifyCaller(mailStatus, EventArgs.Empty);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Creates the base mail objects needed to generate an SMTP based email
        /// </summary>
        public void CreateMailObjects()
        {
            try
            {
                _mailClient = new SmtpClient();
                _mailMessage = new MailMessage();
                _mailFromAddress = new MailAddress(fromAddress);

                mailClient.Host = smtpServer;

                if (mailFromAddress != null)
                {
                    mailMessage.From = mailFromAddress;
                }

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtmlEmail;
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        #region email methods

        /// <summary>
        /// Using the assigned properties generates an email message object
        /// and sends it using the assigned smtp server.  To use this method
        /// use createMailObjects, set the properties for the email information
        /// and use the AddToAddress, AddCCAddress, AddBCCAddress, AddAttachments 
        /// and AuthenticateToServer methods to finish the setup of the mail objects
        /// </summary>
        public void SendEmail(Boolean asyncEmail)
        {
            try
            {
                if (asyncEmail == true)
                {
                    mailClient.SendCompleted += new SendCompletedEventHandler(MailClient_SendCompleted);
                    mailClient.SendAsync(mailMessage, mailMessage.To.ToString());
                }
                else
                {
                    mailClient.Send(mailMessage);
                }
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String subject,
            String body, Boolean htmlEmail, String mailServer)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, null, null, null, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String subject,
            String body, Boolean htmlEmail, String mailServer, String filePath)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, null, null, null, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String subject,
            String body, Boolean htmlEmail, String mailServer, Attachment attachData)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, null, null, null, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, null, null, null, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, null, null, null, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, null, null, null, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, null, null, null, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, null, null, null, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, null, null, null, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncEmail"></param>
        /// <param name="from"></param>
        /// <param name="toAddrs"></param>
        /// <param name="ccAddrs"></param>
        /// <param name="bccAddrs"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="htmlEmail"></param>
        /// <param name="mailServer"></param>
        public void SendEmail(Boolean asyncEmail, String from, String[] toAddrs, String[] ccAddrs, String[] bccAddrs, String subject, String body, Boolean htmlEmail, String mailServer) 
        {
            Send(asyncEmail, from, toAddrs, ccAddrs, bccAddrs, subject, body, htmlEmail, mailServer, null, null, null, null, null);
        }


        #region username password based email

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to,
            String subject, String body, Boolean htmlEmail, String mailServer,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, username, password, null, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, username, password, null, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, username, password, null, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, username, password, null, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, username, password, null, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, username, password, null, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, username, password, null, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, username, password, null, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        /// <param name="username">The username/email address of the authentication account to the mail server</param>
        /// <param name="password">The password of the authentication account</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData,
            String username, String password)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, username, password, null, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region network credential based email

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to,
            String subject, String body, Boolean htmlEmail, String mailServer,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, null, null, credential, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, null, null, credential, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, null, null, subject, body, htmlEmail, mailServer, null, null, credential, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, null, null, credential, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, null, null, credential, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, cc, null, subject, body, htmlEmail, mailServer, null, null, credential, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, null, null, credential, null, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="filePath">The path to the attachment</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer, String filePath,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, null, null, credential, filePath, null);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Generates an email and sends it, requires no additional properties to be set
        /// prior to this call
        /// </summary>
        /// <param name="asyncEmail">Used it you want a response from the SMTP server</param>
        /// <param name="from">The address the email is from</param>
        /// <param name="to">The address the email is to</param>
        /// <param name="cc">The addess the email is being copied to</param>
        /// <param name="bcc">The addess the email is being blind copied to</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="htmlEmail">Is this an html based email</param>
        /// <param name="mailServer">The smtp server for the email to be sent through</param>
        /// <param name="attachData">An attachment created from a file resource</param>
        /// <param name="credential">A network credential representing the account that has access to the mail server</param>
        public void SendEmail(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer, Attachment attachData,
            System.Net.NetworkCredential credential)
        {
            try
            {
                Send(asyncEmail, from, to, cc, bcc, subject, body, htmlEmail, mailServer, null, null, credential, null, attachData);
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }

        #endregion

        private void Send(Boolean asyncEmail, String from, String to, String cc, String bcc,
            String subject, String body, Boolean htmlEmail, String mailServer,
            String username, String password, System.Net.NetworkCredential credential,
            String filePath, Attachment attachData)
        {
            String[] toAddrs = null;
            String[] ccAddrs = null; 
            String[] bccAddrs = null;
            if (to != null)
            {
                toAddrs = new String[] { to };
            }

            if (cc != null)
            {
                ccAddrs = new String[] { cc };
            }

            if (bcc != null)
            {
                bccAddrs = new String[] { bcc };
            }

            Send(asyncEmail, from, toAddrs, ccAddrs, bccAddrs,subject, body, htmlEmail, mailServer,username, password, credential,filePath, attachData);      
        }


        private void Send(Boolean asyncEmail, String from, String[] to, String[] cc, String[] bcc,
            String subject, String body, Boolean htmlEmail, String mailServer,
            String username, String password, System.Net.NetworkCredential credential,
            String filePath, Attachment attachData)
        {
            try
            {
                _body = body;
                _subject = subject;
                _isHtmlEmail = htmlEmail;

                if (mailServer != null)
                {
                    _smtpServer = mailServer;
                }

                if (from != null)
                {
                    _fromAddress = from;
                }

                CreateMailObjects();

                if (to != null)
                {
                    foreach (string toAddr in to)
                    {
                        AddToAddress(toAddr);
                    }
                }

                if (cc != null)
                {
                    foreach (string ccAddr in cc)
                    {
                        AddToAddress(ccAddr);
                    }
                }

                if (bcc != null)
                {
                    foreach (string bccAddr in bcc)
                    {
                        AddToAddress(bccAddr);
                    }
                }

                if (credential != null)
                {
                    AuthenticateToServer(credential);
                }

                if ((username != null) && (password != null))
                {
                    AuthenticateToServer(username, password);
                }

                if (filePath != null)
                {
                    AddAttachments(filePath);
                }

                if (attachData != null)
                {
                    AddAttachments(attachData);
                }

                if (asyncEmail == true)
                {
                    mailClient.SendCompleted += new SendCompletedEventHandler(MailClient_SendCompleted);
                    mailClient.SendAsync(mailMessage, mailMessage.To.ToString());
                }
                else
                {
                    mailClient.Send(mailMessage);
                }
            }
            catch (SmtpException ex)
            {
                throw (ex);
            }
        }


        static void MailClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                mailStatus = token + " Send canceled.";
            }
            if (e.Error != null)
            {
                mailStatus = "Error on " + token + ": " + e.Error.ToString();
            }
            else
            {
                mailStatus = token + " mail sent.";
            }

            OnNotifyCaller();
        }

        #endregion

        #region authentication

        /// <summary>
        /// Creates authentication credentials that are passed to the mail client
        /// to access the SMTP server
        /// </summary>
        /// <param name="username">The users account to access the SMTP server</param>
        /// <param name="password">The users password to access the SMTP server</param>
        public void AuthenticateToServer(String username, String password)
        {
            NetworkCredential credentials = new NetworkCredential(username, password);

            mailClient.Credentials = credentials;
        }

        /// <summary>
        /// Credentials that are passed to the mail client to access the SMTP server
        /// </summary>
        /// <param name="credentials">Network credential to access the SMTP server</param>
        public void AuthenticateToServer(System.Net.NetworkCredential credentials)
        {
            mailClient.Credentials = credentials;
        }

        #endregion

        #region attachments
        /// <summary>
        /// Creates an attachment and adds it to the mail message
        /// </summary>
        /// <param name="path">The path to the attachment</param>
        public void AddAttachments(string path)
        {
            Attachment attachData = new Attachment(path);

            mailMessage.Attachments.Add(attachData);
        }

        /// <summary>
        /// Adds an attachment to the mail message
        /// </summary>
        /// <param name="attachData">An attachment object</param>
        public void AddAttachments(Attachment attachData)
        {
            mailMessage.Attachments.Add(attachData);
        }
        #endregion

        #region add recipient addresses

        /// <summary>
        /// Used to add a to address to the To Address collection
        /// </summary>
        /// <param name="toAddress">The email address to add</param>
        public void AddToAddress(String toAddress)
        {
            mailMessage.To.Add(toAddress);
        }

        /// <summary>
        /// Used to add a cc address to the CC Address collection
        /// </summary>
        /// <param name="ccAddress">The email address to add</param>
        public void AddCCAddress(String ccAddress)
        {
            mailMessage.CC.Add(ccAddress);
        }

        /// <summary>
        /// Used to add a bcc address to the Bcc Address collection
        /// </summary>
        /// <param name="bccAddress">The email address to add</param>
        public void AddBCCAddress(String bccAddress)
        {
            mailMessage.Bcc.Add(bccAddress);
        }

        #endregion

        #endregion
    }
}