using CertSys.Services;

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


        private void SendEmailsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
