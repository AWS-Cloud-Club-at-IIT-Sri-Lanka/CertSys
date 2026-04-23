using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CertSys.Services
{
    public class MailService
    {
        private readonly string logDirectory = @"C:\aws_cloud_club\CertSys\Log\";

        public async Task SendMailAsync(
            string fromEmail,
            string password,
            string toEmail,
            string subject,
            string body,
            string pdfFilePath = null)
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFile = Path.Combine(
                logDirectory,
                $"email_log_{DateTime.Now:yyyyMMdd}.txt"
            );

            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(fromEmail);
                        mailMessage.To.Add(toEmail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        if (!string.IsNullOrEmpty(pdfFilePath) && File.Exists(pdfFilePath))
                        {
                            var attachment = new Attachment(pdfFilePath, "application/pdf");
                            mailMessage.Attachments.Add(attachment);
                        }

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                // SUCCESS LOG (Append)
                string successLog = $@"
--------------------------------------------------
[SUCCESS]
Time     : {DateTime.Now}
To       : {toEmail}
Subject  : {subject}
--------------------------------------------------";

                File.AppendAllText(logFile, successLog);
            }
            catch (Exception ex)
            {
                // FAILURE LOG (Readable)
                string errorLog = $@"
==================================================
[FAILED]
Time     : {DateTime.Now}
To       : {toEmail}
Subject  : {subject}
Error    : {ex.Message}
Stack    : {ex.StackTrace}
==================================================";

                File.AppendAllText(logFile, errorLog);

                throw;
            }
        }
    }
}