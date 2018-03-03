using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Proxy_Changer
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private const string text = "www.amngah.ir ";
        static int index = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_Pouya.Text = text.Substring(0, index) + "_";
            index++;
            if (index == text.Length + 1)
            {
                Lbl_Pouya.Text = text.Substring(0, index-2);
                index = 0;
                System.Threading.Thread.Sleep(1000);
               // timer1.Enabled = false;
            }
        }

        private void Lbl_Pouya_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pouya.tk");
        }



        #region Move Control

        int xposition = 0;
        int yposition = 0;
        Boolean isDraged = false;
        double HoldOpacity = 1;

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            xposition = e.X;
            yposition = e.Y;
            isDraged = true;
            this.Cursor = Cursors.SizeAll;
            HoldOpacity = Opacity;
        }

        private void Item_MouseMove(object sender, MouseEventArgs e)
        {
            if (!(sender is Control))// ONLY for prudence!!!!!!
                return;

            Control item = (Control)sender;

            if (isDraged)
            {
                this.Opacity = .5;
                item.Left += e.X - xposition;
                item.Top += e.Y - yposition;
            }
        }

        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            isDraged = false;
            this.Cursor = Cursors.Default;
            this.Opacity = HoldOpacity;
        }


        #endregion

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            lbl_Version.Text ="Ver: "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

    }
}
