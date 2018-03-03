namespace Proxy_Changer
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_FirefoxStatus = new System.Windows.Forms.Label();
            this.lbl_IEstatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_FirefoxProxy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_IEproxy = new System.Windows.Forms.Button();
            this.linkLabel_About = new System.Windows.Forms.LinkLabel();
            this.linkLabel_Settings = new System.Windows.Forms.LinkLabel();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_FirefoxStatus);
            this.groupBox1.Controls.Add(this.lbl_IEstatus);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_FirefoxProxy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_IEproxy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(288, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "وضعیت پراکسی:";
            // 
            // lbl_FirefoxStatus
            // 
            this.lbl_FirefoxStatus.AutoSize = true;
            this.lbl_FirefoxStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_FirefoxStatus.ForeColor = System.Drawing.Color.Red;
            this.lbl_FirefoxStatus.Location = new System.Drawing.Point(5, 148);
            this.lbl_FirefoxStatus.Name = "lbl_FirefoxStatus";
            this.lbl_FirefoxStatus.Size = new System.Drawing.Size(126, 13);
            this.lbl_FirefoxStatus.TabIndex = 8;
            this.lbl_FirefoxStatus.Text = "پراکسی غیرفعال است";
            this.lbl_FirefoxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_IEstatus
            // 
            this.lbl_IEstatus.AutoSize = true;
            this.lbl_IEstatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_IEstatus.ForeColor = System.Drawing.Color.Red;
            this.lbl_IEstatus.Location = new System.Drawing.Point(158, 148);
            this.lbl_IEstatus.Name = "lbl_IEstatus";
            this.lbl_IEstatus.Size = new System.Drawing.Size(126, 13);
            this.lbl_IEstatus.TabIndex = 7;
            this.lbl_IEstatus.Text = "پراکسی غیرفعال است";
            this.lbl_IEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(20, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mozilla Firefox";
            // 
            // btn_FirefoxProxy
            // 
            this.btn_FirefoxProxy.BackgroundImage = global::Proxy_Changer.Properties.Resources.firefox2;
            this.btn_FirefoxProxy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FirefoxProxy.Location = new System.Drawing.Point(14, 41);
            this.btn_FirefoxProxy.Name = "btn_FirefoxProxy";
            this.btn_FirefoxProxy.Size = new System.Drawing.Size(100, 100);
            this.btn_FirefoxProxy.TabIndex = 5;
            this.btn_FirefoxProxy.UseVisualStyleBackColor = true;
            this.btn_FirefoxProxy.Click += new System.EventHandler(this.btn_FirefoxProxy_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(168, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Internet Explorer";
            // 
            // btn_IEproxy
            // 
            this.btn_IEproxy.BackgroundImage = global::Proxy_Changer.Properties.Resources.IE2;
            this.btn_IEproxy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_IEproxy.Location = new System.Drawing.Point(170, 41);
            this.btn_IEproxy.Name = "btn_IEproxy";
            this.btn_IEproxy.Size = new System.Drawing.Size(100, 100);
            this.btn_IEproxy.TabIndex = 3;
            this.btn_IEproxy.UseVisualStyleBackColor = true;
            this.btn_IEproxy.Click += new System.EventHandler(this.btn_IEproxy_Click);
            // 
            // linkLabel_About
            // 
            this.linkLabel_About.AutoSize = true;
            this.linkLabel_About.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.linkLabel_About.Location = new System.Drawing.Point(15, 182);
            this.linkLabel_About.Name = "linkLabel_About";
            this.linkLabel_About.Size = new System.Drawing.Size(78, 14);
            this.linkLabel_About.TabIndex = 1;
            this.linkLabel_About.TabStop = true;
            this.linkLabel_About.Text = "درباره برنامه";
            this.linkLabel_About.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_About_LinkClicked);
            // 
            // linkLabel_Settings
            // 
            this.linkLabel_Settings.AutoSize = true;
            this.linkLabel_Settings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.linkLabel_Settings.Location = new System.Drawing.Point(217, 182);
            this.linkLabel_Settings.Name = "linkLabel_Settings";
            this.linkLabel_Settings.Size = new System.Drawing.Size(54, 14);
            this.linkLabel_Settings.TabIndex = 2;
            this.linkLabel_Settings.TabStop = true;
            this.linkLabel_Settings.Text = "تنظیمات";
            this.linkLabel_Settings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Settings_LinkClicked);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackgroundImage = global::Proxy_Changer.Properties.Resources.refresh;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.Location = new System.Drawing.Point(126, 175);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(30, 30);
            this.btn_Refresh.TabIndex = 3;
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 207);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.linkLabel_Settings);
            this.Controls.Add(this.linkLabel_About);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy Changer!";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_FirefoxProxy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_IEproxy;
        private System.Windows.Forms.Label lbl_FirefoxStatus;
        private System.Windows.Forms.Label lbl_IEstatus;
        private System.Windows.Forms.LinkLabel linkLabel_About;
        private System.Windows.Forms.LinkLabel linkLabel_Settings;
        private System.Windows.Forms.Button btn_Refresh;
    }
}

