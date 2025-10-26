namespace HOSPITAL_MANAGEMENT
{
    partial class Patient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnMedicine = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btndiagnosis = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnPatient = new Guna.UI.WinForms.GunaAdvenceButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAd = new Guna.UI.WinForms.GunaAdvenceButton();
            this.CbBloodGroup = new System.Windows.Forms.ComboBox();
            this.CbGender = new System.Windows.Forms.ComboBox();
            this.txtDisease = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtAge = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnReloa = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnDelet = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnUpadat = new Guna.UI.WinForms.GunaAdvenceButton();
            this.txtPatientPhone = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPatientAddress = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPatientName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPatientId = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.DGVPatients = new Guna.UI.WinForms.GunaDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnMedicine);
            this.panel1.Controls.Add(this.btndiagnosis);
            this.panel1.Controls.Add(this.btnPatient);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 881);
            this.panel1.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.AnimationHoverSpeed = 0.07F;
            this.btnLogout.AnimationSpeed = 0.03F;
            this.btnLogout.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnLogout.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnLogout.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnLogout.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogout.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.CheckedImage")));
            this.btnLogout.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogout.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogout.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLogout.Location = new System.Drawing.Point(-10, 839);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnLogout.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogout.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogout.OnHoverImage = null;
            this.btnLogout.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLogout.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogout.Size = new System.Drawing.Size(282, 42);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMedicine
            // 
            this.btnMedicine.AnimationHoverSpeed = 0.07F;
            this.btnMedicine.AnimationSpeed = 0.03F;
            this.btnMedicine.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnMedicine.BorderColor = System.Drawing.Color.Black;
            this.btnMedicine.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnMedicine.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnMedicine.CheckedForeColor = System.Drawing.Color.White;
            this.btnMedicine.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnMedicine.CheckedImage")));
            this.btnMedicine.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnMedicine.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMedicine.FocusedColor = System.Drawing.Color.Empty;
            this.btnMedicine.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicine.ForeColor = System.Drawing.Color.White;
            this.btnMedicine.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicine.Image")));
            this.btnMedicine.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMedicine.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnMedicine.Location = new System.Drawing.Point(3, 144);
            this.btnMedicine.Name = "btnMedicine";
            this.btnMedicine.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnMedicine.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMedicine.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMedicine.OnHoverImage = null;
            this.btnMedicine.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnMedicine.OnPressedColor = System.Drawing.Color.Black;
            this.btnMedicine.Size = new System.Drawing.Size(269, 42);
            this.btnMedicine.TabIndex = 5;
            this.btnMedicine.Text = "Medicine";
            this.btnMedicine.Click += new System.EventHandler(this.btnMedicine_Click);
            // 
            // btndiagnosis
            // 
            this.btndiagnosis.AnimationHoverSpeed = 0.07F;
            this.btndiagnosis.AnimationSpeed = 0.03F;
            this.btndiagnosis.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btndiagnosis.BorderColor = System.Drawing.Color.Black;
            this.btndiagnosis.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btndiagnosis.CheckedBorderColor = System.Drawing.Color.Black;
            this.btndiagnosis.CheckedForeColor = System.Drawing.Color.White;
            this.btndiagnosis.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btndiagnosis.CheckedImage")));
            this.btndiagnosis.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btndiagnosis.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btndiagnosis.FocusedColor = System.Drawing.Color.Empty;
            this.btndiagnosis.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndiagnosis.ForeColor = System.Drawing.Color.White;
            this.btndiagnosis.Image = ((System.Drawing.Image)(resources.GetObject("btndiagnosis.Image")));
            this.btndiagnosis.ImageSize = new System.Drawing.Size(20, 20);
            this.btndiagnosis.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btndiagnosis.Location = new System.Drawing.Point(0, 240);
            this.btndiagnosis.Name = "btndiagnosis";
            this.btndiagnosis.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btndiagnosis.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btndiagnosis.OnHoverForeColor = System.Drawing.Color.White;
            this.btndiagnosis.OnHoverImage = null;
            this.btndiagnosis.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btndiagnosis.OnPressedColor = System.Drawing.Color.Black;
            this.btndiagnosis.Size = new System.Drawing.Size(275, 42);
            this.btndiagnosis.TabIndex = 4;
            this.btndiagnosis.Text = "Diagnosis";
            this.btndiagnosis.Click += new System.EventHandler(this.btndiagnosis_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.AnimationHoverSpeed = 0.07F;
            this.btnPatient.AnimationSpeed = 0.03F;
            this.btnPatient.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPatient.BorderColor = System.Drawing.Color.Black;
            this.btnPatient.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnPatient.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnPatient.CheckedForeColor = System.Drawing.Color.White;
            this.btnPatient.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnPatient.CheckedImage")));
            this.btnPatient.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnPatient.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPatient.FocusedColor = System.Drawing.Color.Empty;
            this.btnPatient.Font = new System.Drawing.Font("Corbel", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatient.ForeColor = System.Drawing.Color.White;
            this.btnPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnPatient.Image")));
            this.btnPatient.ImageSize = new System.Drawing.Size(20, 20);
            this.btnPatient.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnPatient.Location = new System.Drawing.Point(0, 192);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnPatient.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPatient.OnHoverForeColor = System.Drawing.Color.White;
            this.btnPatient.OnHoverImage = null;
            this.btnPatient.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnPatient.OnPressedColor = System.Drawing.Color.Black;
            this.btnPatient.Size = new System.Drawing.Size(272, 42);
            this.btnPatient.TabIndex = 3;
            this.btnPatient.Text = "Patients";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.close);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(275, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1404, 88);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // close
            // 
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.Location = new System.Drawing.Point(1360, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(41, 37);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close.TabIndex = 8;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(413, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOSPITAL MANAGEMENT SYSTEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(908, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Patient\'s List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Patient\'s Details";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAd);
            this.panel4.Controls.Add(this.CbBloodGroup);
            this.panel4.Controls.Add(this.CbGender);
            this.panel4.Controls.Add(this.txtDisease);
            this.panel4.Controls.Add(this.txtAge);
            this.panel4.Controls.Add(this.btnReloa);
            this.panel4.Controls.Add(this.btnDelet);
            this.panel4.Controls.Add(this.btnUpadat);
            this.panel4.Controls.Add(this.txtPatientPhone);
            this.panel4.Controls.Add(this.txtPatientAddress);
            this.panel4.Controls.Add(this.txtPatientName);
            this.panel4.Controls.Add(this.txtPatientId);
            this.panel4.Location = new System.Drawing.Point(293, 126);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1361, 345);
            this.panel4.TabIndex = 12;
            // 
            // btnAd
            // 
            this.btnAd.AnimationHoverSpeed = 0.07F;
            this.btnAd.AnimationSpeed = 0.03F;
            this.btnAd.BackColor = System.Drawing.Color.Transparent;
            this.btnAd.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAd.BorderColor = System.Drawing.Color.Black;
            this.btnAd.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnAd.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnAd.CheckedForeColor = System.Drawing.Color.White;
            this.btnAd.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnAd.CheckedImage")));
            this.btnAd.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnAd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAd.FocusedColor = System.Drawing.Color.Empty;
            this.btnAd.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAd.ForeColor = System.Drawing.Color.White;
            this.btnAd.Image = ((System.Drawing.Image)(resources.GetObject("btnAd.Image")));
            this.btnAd.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAd.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnAd.Location = new System.Drawing.Point(266, 251);
            this.btnAd.Name = "btnAd";
            this.btnAd.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnAd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAd.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAd.OnHoverImage = null;
            this.btnAd.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnAd.OnPressedColor = System.Drawing.Color.Black;
            this.btnAd.Radius = 20;
            this.btnAd.Size = new System.Drawing.Size(167, 42);
            this.btnAd.TabIndex = 16;
            this.btnAd.Text = "Add";
            this.btnAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAd.Click += new System.EventHandler(this.btnAd_Click);
            // 
            // CbBloodGroup
            // 
            this.CbBloodGroup.FormattingEnabled = true;
            this.CbBloodGroup.Items.AddRange(new object[] {
            "A+",
            "B+",
            "AB+",
            "O+",
            "A-",
            "B-",
            "AB-",
            "O-",
            "Other"});
            this.CbBloodGroup.Location = new System.Drawing.Point(588, 142);
            this.CbBloodGroup.Name = "CbBloodGroup";
            this.CbBloodGroup.Size = new System.Drawing.Size(323, 32);
            this.CbBloodGroup.TabIndex = 15;
            this.CbBloodGroup.Text = "Select Blood Group";
            // 
            // CbGender
            // 
            this.CbGender.FormattingEnabled = true;
            this.CbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.CbGender.Location = new System.Drawing.Point(210, 142);
            this.CbGender.Name = "CbGender";
            this.CbGender.Size = new System.Drawing.Size(339, 32);
            this.CbGender.TabIndex = 14;
            this.CbGender.Text = "Select Gender";
            // 
            // txtDisease
            // 
            this.txtDisease.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisease.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisease.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDisease.HintForeColor = System.Drawing.Color.Empty;
            this.txtDisease.HintText = "Major Disease";
            this.txtDisease.isPassword = false;
            this.txtDisease.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtDisease.LineIdleColor = System.Drawing.Color.Gray;
            this.txtDisease.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtDisease.LineThickness = 4;
            this.txtDisease.Location = new System.Drawing.Point(960, 142);
            this.txtDisease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDisease.Name = "txtDisease";
            this.txtDisease.Size = new System.Drawing.Size(312, 34);
            this.txtDisease.TabIndex = 13;
            this.txtDisease.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtAge
            // 
            this.txtAge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAge.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAge.HintForeColor = System.Drawing.Color.Empty;
            this.txtAge.HintText = "Age";
            this.txtAge.isPassword = false;
            this.txtAge.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtAge.LineIdleColor = System.Drawing.Color.Gray;
            this.txtAge.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtAge.LineThickness = 4;
            this.txtAge.Location = new System.Drawing.Point(23, 140);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(167, 34);
            this.txtAge.TabIndex = 12;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnReloa
            // 
            this.btnReloa.AnimationHoverSpeed = 0.07F;
            this.btnReloa.AnimationSpeed = 0.03F;
            this.btnReloa.BackColor = System.Drawing.Color.Transparent;
            this.btnReloa.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnReloa.BorderColor = System.Drawing.Color.Black;
            this.btnReloa.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnReloa.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnReloa.CheckedForeColor = System.Drawing.Color.White;
            this.btnReloa.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnReloa.CheckedImage")));
            this.btnReloa.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnReloa.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReloa.FocusedColor = System.Drawing.Color.Empty;
            this.btnReloa.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloa.ForeColor = System.Drawing.Color.White;
            this.btnReloa.Image = ((System.Drawing.Image)(resources.GetObject("btnReloa.Image")));
            this.btnReloa.ImageSize = new System.Drawing.Size(20, 20);
            this.btnReloa.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnReloa.Location = new System.Drawing.Point(862, 251);
            this.btnReloa.Name = "btnReloa";
            this.btnReloa.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnReloa.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnReloa.OnHoverForeColor = System.Drawing.Color.White;
            this.btnReloa.OnHoverImage = null;
            this.btnReloa.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnReloa.OnPressedColor = System.Drawing.Color.Black;
            this.btnReloa.Radius = 20;
            this.btnReloa.Size = new System.Drawing.Size(167, 42);
            this.btnReloa.TabIndex = 9;
            this.btnReloa.Text = "Reload";
            this.btnReloa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDelet
            // 
            this.btnDelet.AnimationHoverSpeed = 0.07F;
            this.btnDelet.AnimationSpeed = 0.03F;
            this.btnDelet.BackColor = System.Drawing.Color.Transparent;
            this.btnDelet.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDelet.BorderColor = System.Drawing.Color.Black;
            this.btnDelet.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnDelet.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnDelet.CheckedForeColor = System.Drawing.Color.White;
            this.btnDelet.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnDelet.CheckedImage")));
            this.btnDelet.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnDelet.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelet.FocusedColor = System.Drawing.Color.Empty;
            this.btnDelet.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelet.ForeColor = System.Drawing.Color.White;
            this.btnDelet.Image = ((System.Drawing.Image)(resources.GetObject("btnDelet.Image")));
            this.btnDelet.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDelet.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnDelet.Location = new System.Drawing.Point(650, 251);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnDelet.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDelet.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDelet.OnHoverImage = null;
            this.btnDelet.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnDelet.OnPressedColor = System.Drawing.Color.Black;
            this.btnDelet.Radius = 20;
            this.btnDelet.Size = new System.Drawing.Size(167, 42);
            this.btnDelet.TabIndex = 10;
            this.btnDelet.Text = "Delete";
            this.btnDelet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDelet.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // btnUpadat
            // 
            this.btnUpadat.AnimationHoverSpeed = 0.07F;
            this.btnUpadat.AnimationSpeed = 0.03F;
            this.btnUpadat.BackColor = System.Drawing.Color.Transparent;
            this.btnUpadat.BaseColor = System.Drawing.Color.DarkOliveGreen;
            this.btnUpadat.BorderColor = System.Drawing.Color.Black;
            this.btnUpadat.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnUpadat.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnUpadat.CheckedForeColor = System.Drawing.Color.White;
            this.btnUpadat.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnUpadat.CheckedImage")));
            this.btnUpadat.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnUpadat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpadat.FocusedColor = System.Drawing.Color.Empty;
            this.btnUpadat.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpadat.ForeColor = System.Drawing.Color.White;
            this.btnUpadat.Image = ((System.Drawing.Image)(resources.GetObject("btnUpadat.Image")));
            this.btnUpadat.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpadat.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnUpadat.Location = new System.Drawing.Point(452, 251);
            this.btnUpadat.Name = "btnUpadat";
            this.btnUpadat.OnHoverBaseColor = System.Drawing.SystemColors.Highlight;
            this.btnUpadat.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUpadat.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUpadat.OnHoverImage = null;
            this.btnUpadat.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnUpadat.OnPressedColor = System.Drawing.Color.Black;
            this.btnUpadat.Radius = 20;
            this.btnUpadat.Size = new System.Drawing.Size(167, 42);
            this.btnUpadat.TabIndex = 11;
            this.btnUpadat.Text = "Update";
            this.btnUpadat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnUpadat.Click += new System.EventHandler(this.btnUpadat_Click);
            // 
            // txtPatientPhone
            // 
            this.txtPatientPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatientPhone.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatientPhone.HintForeColor = System.Drawing.Color.Empty;
            this.txtPatientPhone.HintText = "Patient Phone";
            this.txtPatientPhone.isPassword = false;
            this.txtPatientPhone.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPatientPhone.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPatientPhone.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPatientPhone.LineThickness = 4;
            this.txtPatientPhone.Location = new System.Drawing.Point(960, 33);
            this.txtPatientPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPatientPhone.Name = "txtPatientPhone";
            this.txtPatientPhone.Size = new System.Drawing.Size(312, 34);
            this.txtPatientPhone.TabIndex = 7;
            this.txtPatientPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtPatientAddress
            // 
            this.txtPatientAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatientAddress.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatientAddress.HintForeColor = System.Drawing.Color.Empty;
            this.txtPatientAddress.HintText = "Patient Address";
            this.txtPatientAddress.isPassword = false;
            this.txtPatientAddress.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPatientAddress.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPatientAddress.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPatientAddress.LineThickness = 4;
            this.txtPatientAddress.Location = new System.Drawing.Point(588, 33);
            this.txtPatientAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPatientAddress.Name = "txtPatientAddress";
            this.txtPatientAddress.Size = new System.Drawing.Size(323, 34);
            this.txtPatientAddress.TabIndex = 6;
            this.txtPatientAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatientName.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatientName.HintForeColor = System.Drawing.Color.Empty;
            this.txtPatientName.HintText = "Patient Name";
            this.txtPatientName.isPassword = false;
            this.txtPatientName.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPatientName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPatientName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPatientName.LineThickness = 4;
            this.txtPatientName.Location = new System.Drawing.Point(210, 33);
            this.txtPatientName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(339, 34);
            this.txtPatientName.TabIndex = 5;
            this.txtPatientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtPatientId
            // 
            this.txtPatientId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatientId.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatientId.HintForeColor = System.Drawing.Color.Empty;
            this.txtPatientId.HintText = "Patient Id";
            this.txtPatientId.isPassword = false;
            this.txtPatientId.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPatientId.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPatientId.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPatientId.LineThickness = 4;
            this.txtPatientId.Location = new System.Drawing.Point(14, 33);
            this.txtPatientId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(167, 34);
            this.txtPatientId.TabIndex = 4;
            this.txtPatientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // DGVPatients
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.DGVPatients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPatients.BackgroundColor = System.Drawing.Color.White;
            this.DGVPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGVPatients.ColumnHeadersHeight = 30;
            this.DGVPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPatients.DefaultCellStyle = dataGridViewCellStyle12;
            this.DGVPatients.EnableHeadersVisualStyles = false;
            this.DGVPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVPatients.Location = new System.Drawing.Point(294, 526);
            this.DGVPatients.Name = "DGVPatients";
            this.DGVPatients.RowHeadersVisible = false;
            this.DGVPatients.RowHeadersWidth = 51;
            this.DGVPatients.RowTemplate.Height = 24;
            this.DGVPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPatients.Size = new System.Drawing.Size(1361, 343);
            this.DGVPatients.TabIndex = 15;
            this.DGVPatients.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.DGVPatients.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVPatients.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVPatients.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVPatients.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVPatients.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVPatients.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVPatients.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVPatients.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGVPatients.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVPatients.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVPatients.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVPatients.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPatients.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVPatients.ThemeStyle.ReadOnly = false;
            this.DGVPatients.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVPatients.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVPatients.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVPatients.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVPatients.ThemeStyle.RowsStyle.Height = 24;
            this.DGVPatients.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVPatients.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPatients_CellContentClick);
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1679, 881);
            this.Controls.Add(this.DGVPatients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient";
            this.Load += new System.EventHandler(this.Patient_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaAdvenceButton btnLogout;
        private Guna.UI.WinForms.GunaAdvenceButton btnMedicine;
        private Guna.UI.WinForms.GunaAdvenceButton btndiagnosis;
        private Guna.UI.WinForms.GunaAdvenceButton btnPatient;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaAdvenceButton btnAd;
        private System.Windows.Forms.ComboBox CbBloodGroup;
        private System.Windows.Forms.ComboBox CbGender;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtDisease;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtAge;
        private Guna.UI.WinForms.GunaAdvenceButton btnReloa;
        private Guna.UI.WinForms.GunaAdvenceButton btnDelet;
        private Guna.UI.WinForms.GunaAdvenceButton btnUpadat;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPatientPhone;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPatientAddress;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPatientName;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPatientId;
        private Guna.UI.WinForms.GunaDataGridView DGVPatients;
    }
}