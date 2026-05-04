using CertSys.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertSys
{
    public partial class Home : Form
    {
        private readonly CertGenerateService _certService;
        public Home()
        {
            InitializeComponent();
            _certService = new CertGenerateService();
        }   

        private void user_list_location_selectBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select User List Excel File";
                dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    user_list_location_txtBox.Text = dialog.FileName;
                }
            }
        }

        private void certificate_template_location_selectBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Certificate Template PDF";
                dialog.Filter = "PDF Files (*.pdf)|*.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    certificate_template_location_txtBox.Text = dialog.FileName;
                }
            }
        }

        private void GenCertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string excelPath = user_list_location_txtBox.Text;
                string templatePath = certificate_template_location_txtBox.Text;

                if (string.IsNullOrWhiteSpace(excelPath) || string.IsNullOrWhiteSpace(templatePath))
                {
                    MessageBox.Show("Please select both Excel file and Certificate template.");
                    return;
                }

                _certService.GenerateCertificates(excelPath, templatePath);

                MessageBox.Show("Certificates generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // Updated: async send emails handler — generates certificates and sends PDFs as attachments
        private async void SendEmailsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string excelPath = user_list_location_txtBox.Text;
                string templatePath = certificate_template_location_txtBox.Text;
                string smtpUser = smtp_username_txtBox.Text;
                string smtpPass = smtp_password_txtBox.Text;
                string emailBody = email_body_richtxtBox.Text ?? string.Empty;

                if (string.IsNullOrWhiteSpace(excelPath) || string.IsNullOrWhiteSpace(templatePath))
                {
                    MessageBox.Show("Please select both Excel file and Certificate template.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(smtpUser) || string.IsNullOrWhiteSpace(smtpPass))
                {
                    MessageBox.Show("Please enter SMTP username and password.");
                    return;
                }

                SendEmailsBtn.Enabled = false;
                GenCertBtn.Enabled = false;

                // Generate certificates and get list of (email, filePath)
                var generated = _certService.GenerateCertificatesAndReturn(excelPath, templatePath);

                if (generated == null || generated.Count == 0)
                {
                    MessageBox.Show("No certificates generated.");
                    return;
                }

                var mailService = new MailService();

                int success = 0;
                var failures = new List<string>();

                // Send one by one (sequential). Change to parallel if desired (consider SMTP limits).
                foreach (var item in generated)
                {
                    try
                    {
                        string toEmail = item.Email;
                        string pdfPath = item.FilePath;
                        string subject = "Your Certificate";

                        await mailService.SendMailAsync(smtpUser, smtpPass, toEmail, subject, emailBody, pdfPath);
                        success++;
                    }
                    catch (Exception ex)
                    {
                        // Collect failed recipient and error for summary (detailed info in MailService logs)
                        failures.Add($"{item.Email}: {ex.Message}");
                    }
                }

                string summary = $"Emails processed: {generated.Count}\nSent: {success}\nFailed: {failures.Count}";
                if (failures.Count > 0)
                {
                    summary += "\n\nSee log file for details. First failures:\n" + string.Join("\n", failures.Take(5));
                }

                MessageBox.Show(summary);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending emails: " + ex.Message);
            }
            finally
            {
                SendEmailsBtn.Enabled = true;
                GenCertBtn.Enabled = true;
            }
        }
    }
}
