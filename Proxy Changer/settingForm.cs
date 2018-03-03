using System;
using System.Windows.Forms;
using System.Reflection;

namespace Proxy_Changer
{
    public partial class settingForm : Form
    {
        public settingForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };


            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ProxyServerIP=ipAddressControl1.Text;
            Properties.Settings.Default.ProxyPort = numericUpDown1.Value.ToString();
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            ipAddressControl1.Text=Properties.Settings.Default.ProxyServerIP;
            numericUpDown1.Value =Convert.ToInt32(Properties.Settings.Default.ProxyPort);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
