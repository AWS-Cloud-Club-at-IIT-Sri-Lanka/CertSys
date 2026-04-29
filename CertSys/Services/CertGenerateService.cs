using CertSys.Modals;
using ClosedXML.Excel;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace CertSys.Services
{
    public class CertGenerateService
    {
        public void GenerateCertificates(string excelPath, string templatePath)
        {
            var users = ReadUsersFromExcel(excelPath);

            ValidateEmails(users);

            string folderPath = CreateOutputFolder();

            foreach (var user in users)
            {
                string uniqueId = Guid.NewGuid().ToString().Substring(0, 8);
                string safeEmail = user.Email.Replace(",", "_");

                string fileName = $"{safeEmail}_{uniqueId}.pdf";
                string fullPath = Path.Combine(folderPath, fileName);

                GeneratePdf(templatePath, user.Username, fullPath);
            }
        }

        // Read Excel using ClosedXML
        private List<UserModel> ReadUsersFromExcel(string path)
        {
            var users = new List<UserModel>();

            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1);

                var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

                foreach (var row in rows)
                {
                    string username = row.Cell(1).GetString(); // Column A
                    string emailCell = row.Cell(2).GetString(); // Column B

                    var emails = emailCell.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(e => e.Trim());

                    foreach (var email in emails)
                    {
                        users.Add(new UserModel
                        {
                            Username = username,
                            Email = email
                        });
                    }
                }
            }

            return users;
        }

        // Ensure emails are unique
        private void ValidateEmails(List<UserModel> users)
        {
            var duplicates = users.GroupBy(u => u.Email)
                                  .Where(g => g.Count() > 1)
                                  .Select(g => g.Key)
                                  .ToList();

            if (duplicates.Any())
            {
                throw new Exception("Duplicate emails found: " + string.Join(", ", duplicates));
            }
        }

        // Create folder
        private string CreateOutputFolder()
        {
            string basePath = @"C:\AWS_CLOUD_CLUB_CERT_SYS";
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string fullPath = Path.Combine(basePath, timestamp);

            Directory.CreateDirectory(fullPath);

            return fullPath;
        }


        private (float width, float height) GetPdfSize(string templatePath)
        {
            using var reader = new PdfReader(templatePath);
            using var pdf = new PdfDocument(reader);

            var page = pdf.GetFirstPage();
            var size = page.GetPageSize();

            return (size.GetWidth(), size.GetHeight());
        }

        // Generate simple PDF
        private void GeneratePdf(string templatePath, string username, string outputPath)
        {
            using (PdfReader reader = new PdfReader(templatePath))
            using (PdfWriter writer = new PdfWriter(outputPath))
            {
                PdfDocument pdfDoc = new PdfDocument(reader, writer);
                Document document = new Document(pdfDoc);

                // Get specific page (e.g., page 1)
                PdfPage page = pdfDoc.GetPage(1);
                var pageSize = page.GetPageSize();

                // Calculate position based on landscape dimensions
                float x = pageSize.GetWidth() / 2; // Center
                float y = pageSize.GetHeight() - 50; // Top margin

                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                // Add text at fixed position
                document.ShowTextAligned(new Paragraph(username).SetFontSize(40).SetFont(font).SetFontColor(ColorConstants.WHITE),
                    x, y, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                pdfDoc.Close();
            }
        }
    }
}