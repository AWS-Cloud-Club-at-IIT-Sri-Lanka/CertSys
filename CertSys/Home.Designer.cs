namespace CertSys
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            pictureBox1 = new PictureBox();
            Header = new Label();
            subtitle = new Label();
            labelCertTemplate = new Label();
            labelUserList = new Label();
            certificate_template_location_txtBox = new TextBox();
            user_list_location_txtBox = new TextBox();
            certificate_template_location_selectBtn = new Button();
            user_list_location_selectBtn = new Button();
            certGenerateBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            smtp_password_txtBox = new TextBox();
            smtp_username_txtBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            email_body_richtxtBox = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(673, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Header
            // 
            Header.AutoSize = true;
            Header.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold);
            Header.ForeColor = Color.FromArgb(128, 128, 255);
            Header.Location = new Point(12, 12);
            Header.Name = "Header";
            Header.Size = new Size(159, 40);
            Header.TabIndex = 1;
            Header.Text = "CertSys";
            Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtitle
            // 
            subtitle.AutoSize = true;
            subtitle.Font = new Font("Calibri", 8F);
            subtitle.ForeColor = Color.FromArgb(128, 128, 255);
            subtitle.Location = new Point(17, 48);
            subtitle.Name = "subtitle";
            subtitle.Size = new Size(211, 13);
            subtitle.TabIndex = 2;
            subtitle.Text = "Creating certificate and shares with holders";
            subtitle.TextAlign = ContentAlignment.MiddleCenter;
            subtitle.Click += this.subtitle_Click;
            // 
            // labelCertTemplate
            // 
            labelCertTemplate.AutoSize = true;
            labelCertTemplate.Font = new Font("Calibri", 12F, FontStyle.Bold);
            labelCertTemplate.Location = new Point(103, 232);
            labelCertTemplate.Name = "labelCertTemplate";
            labelCertTemplate.Size = new Size(157, 19);
            labelCertTemplate.TabIndex = 4;
            labelCertTemplate.Text = "Certificate Template:  ";
            // 
            // labelUserList
            // 
            labelUserList.AutoSize = true;
            labelUserList.Font = new Font("Calibri", 12F, FontStyle.Bold);
            labelUserList.Location = new Point(184, 265);
            labelUserList.Name = "labelUserList";
            labelUserList.Size = new Size(74, 19);
            labelUserList.TabIndex = 5;
            labelUserList.Text = "User List: ";
            // 
            // certificate_template_location_txtBox
            // 
            certificate_template_location_txtBox.Location = new Point(266, 228);
            certificate_template_location_txtBox.Name = "certificate_template_location_txtBox";
            certificate_template_location_txtBox.Size = new Size(291, 23);
            certificate_template_location_txtBox.TabIndex = 6;
            // 
            // user_list_location_txtBox
            // 
            user_list_location_txtBox.Location = new Point(266, 261);
            user_list_location_txtBox.Name = "user_list_location_txtBox";
            user_list_location_txtBox.Size = new Size(291, 23);
            user_list_location_txtBox.TabIndex = 7;
            // 
            // certificate_template_location_selectBtn
            // 
            certificate_template_location_selectBtn.Location = new Point(561, 228);
            certificate_template_location_selectBtn.Name = "certificate_template_location_selectBtn";
            certificate_template_location_selectBtn.Size = new Size(164, 23);
            certificate_template_location_selectBtn.TabIndex = 8;
            certificate_template_location_selectBtn.Text = "Select Certificate Template";
            certificate_template_location_selectBtn.UseVisualStyleBackColor = true;
            // 
            // user_list_location_selectBtn
            // 
            user_list_location_selectBtn.Location = new Point(561, 261);
            user_list_location_selectBtn.Name = "user_list_location_selectBtn";
            user_list_location_selectBtn.Size = new Size(164, 23);
            user_list_location_selectBtn.TabIndex = 9;
            user_list_location_selectBtn.Text = "Select User List";
            user_list_location_selectBtn.UseVisualStyleBackColor = true;
            // 
            // certGenerateBtn
            // 
            certGenerateBtn.Location = new Point(556, 400);
            certGenerateBtn.Name = "certGenerateBtn";
            certGenerateBtn.Size = new Size(169, 38);
            certGenerateBtn.TabIndex = 10;
            certGenerateBtn.Text = "Generate and Send Emails";
            certGenerateBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 128, 255);
            label1.Location = new Point(104, 185);
            label1.Name = "label1";
            label1.Size = new Size(316, 40);
            label1.TabIndex = 11;
            label1.Text = "File Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 128, 255);
            label2.Location = new Point(104, 76);
            label2.Name = "label2";
            label2.Size = new Size(337, 40);
            label2.TabIndex = 12;
            label2.Text = "SMTP Management";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // smtp_password_txtBox
            // 
            smtp_password_txtBox.Location = new Point(267, 151);
            smtp_password_txtBox.Name = "smtp_password_txtBox";
            smtp_password_txtBox.Size = new Size(291, 23);
            smtp_password_txtBox.TabIndex = 16;
            // 
            // smtp_username_txtBox
            // 
            smtp_username_txtBox.Location = new Point(267, 118);
            smtp_username_txtBox.Name = "smtp_username_txtBox";
            smtp_username_txtBox.Size = new Size(291, 23);
            smtp_username_txtBox.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.Location = new Point(175, 155);
            label3.Name = "label3";
            label3.Size = new Size(86, 19);
            label3.TabIndex = 14;
            label3.Text = "Password:  ";
            label3.Click += this.label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.Location = new Point(125, 122);
            label4.Name = "label4";
            label4.Size = new Size(136, 19);
            label4.TabIndex = 13;
            label4.Text = "Email (Username): ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.Location = new Point(206, 294);
            label5.Name = "label5";
            label5.Size = new Size(52, 19);
            label5.TabIndex = 17;
            label5.Text = "Body: ";
            // 
            // email_body_richtxtBox
            // 
            email_body_richtxtBox.Location = new Point(267, 298);
            email_body_richtxtBox.Name = "email_body_richtxtBox";
            email_body_richtxtBox.Size = new Size(458, 96);
            email_body_richtxtBox.TabIndex = 18;
            email_body_richtxtBox.Text = "";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(email_body_richtxtBox);
            Controls.Add(label5);
            Controls.Add(smtp_password_txtBox);
            Controls.Add(smtp_username_txtBox);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(certGenerateBtn);
            Controls.Add(user_list_location_selectBtn);
            Controls.Add(certificate_template_location_selectBtn);
            Controls.Add(user_list_location_txtBox);
            Controls.Add(certificate_template_location_txtBox);
            Controls.Add(labelUserList);
            Controls.Add(labelCertTemplate);
            Controls.Add(subtitle);
            Controls.Add(Header);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            Text = "CertSys - AWS Cloud Club at Informatics Institute of Technology";
            Load += this.Home_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Header;
        private Label subtitle;
        private Label labelCertTemplate;
        private Label labelUserList;
        private TextBox certificate_template_location_txtBox;
        private TextBox user_list_location_txtBox;
        private Button certificate_template_location_selectBtn;
        private Button user_list_location_selectBtn;
        private Button certGenerateBtn;
        private Label label1;
        private Label label2;
        private TextBox smtp_password_txtBox;
        private TextBox smtp_username_txtBox;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox email_body_richtxtBox;
    }
}
