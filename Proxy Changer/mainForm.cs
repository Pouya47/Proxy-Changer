using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace Proxy_Changer
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        bool settingsReturn, refreshReturn;



        private void mainForm_Load(object sender, EventArgs e)
        {
            refreshStatus();
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            refreshStatus();
        }
        private void refreshStatus()
        {
            Check_IE_ProxyStatus();

            if (IS_FirefoxInstall())
                Check_Firefox_ProxyStatus();
            else
            {
                btn_FirefoxProxy.Enabled = false;
                lbl_FirefoxStatus.Text="نصب نیست";
                lbl_FirefoxStatus.ForeColor = Color.Gray;
            }
        }


        private Boolean IS_FirefoxInstall()
        {
            //This function looks for Firefoxes prefs.js file for the current user
            string RootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToLower() + "\\Mozilla\\Firefox\\Profiles\\";
            return Directory.Exists(RootPath);
        }


        #region Firefox Change Proxy

        private void btn_FirefoxProxy_Click(object sender, EventArgs e)
        {
            try
            {

                if (Firefox_IsRunning())
                {
                    if (MessageBox.Show(" در حال اجراست Firefox " + "\n" + "آیا می خواهید بسته شود؟", "فایرفاکس درحال اجرا", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        Kill_Firefox();
                    else
                        return;
                }
               
                //if proxy is enable Disable it and ...
                Boolean prxState = Check_Firefox_ProxyStatus();
                ChangeFirefoxProxy(!prxState);
                Check_Firefox_ProxyStatus();
            }
             catch (Exception exx)
            {
   MessageBox.Show("تغییر پراکسی Firefox به علت خطای زیر انجام نشد" + "\n" + exx.Message, "خطا در تغییر فایرفاکس", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Check Firefox Proxy Status
        /// </summary>
        /// <returns>If firefox proxy is enable retrn true</returns>
        private Boolean Check_Firefox_ProxyStatus()
        {
            Boolean disable = false;
            DirectoryInfo RootInf = Get_FirefoxSettingPath();
            foreach (DirectoryInfo DInfo in RootInf.GetDirectories())
            {
                foreach (FileInfo FInfo in DInfo.GetFiles())
                {
                    if (FInfo.Name.ToLower() == "prefs.js")
                    {
                        if (is_Firefox_Proxy_Disable(FInfo) == true)
                        {
                            disable = true;
                            break;
                        }
                    }
                }
            }
            if (disable)
            {
               
                lbl_FirefoxStatus.Text = "پراکسی غیر فعال است";
                lbl_FirefoxStatus.ForeColor = Color.Red;
                btn_FirefoxProxy.BackgroundImage = Properties.Resources.firefox2;
                return false;
            }
            else // if proxy is enable
                {
                    lbl_FirefoxStatus.Text = "پراکسی فعال است";
                    lbl_FirefoxStatus.ForeColor = Color.Green;
                    btn_FirefoxProxy.BackgroundImage = Properties.Resources.firefox;
                    return true;
                }
        }


        private Boolean Firefox_IsRunning()
        {

         Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "firefox")
                {
                    return true;
                }
            }
            return false;
        }
        private void Kill_Firefox()
        {
                Process[] prs = Process.GetProcesses();
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName == "firefox")
                    {
                        pr.Kill();
                    }
                }
        }


        /// <summary>
        /// Read Firefox Proxy setting by reading>> prefs.js if proxy is disable Return True
        /// </summary>
        /// <param name="FInfo">Path of file>> prefs.js</param>
        /// 
        private Boolean is_Firefox_Proxy_Disable(FileInfo FInfo)
        {
            //This function edits firefoxes prefs.js file to turn the proxy server on/off
            System.IO.FileStream FS = FInfo.OpenRead();
            byte[] Data = new byte[FS.Length];
            if (Data.Length > FS.Length)
                Data = new byte[FS.Length];
            FS.Read(Data, 0, Data.Length);
            FS.Close();
            string FileData = ASCIIEncoding.ASCII.GetString(Data).Replace(Environment.NewLine, "¬");
            string[] Lines = FileData.Split('¬'); 
            Boolean ProxyDisable=true;
            foreach (string Line in Lines)
            {
                if (Line.ToLower().Contains("network.proxy.type\", 1"))
                   ProxyDisable=false;
            }
            return ProxyDisable;


            //---------------------Note------------------------------------
            //user.js may contain disable proxy setting we should delete it!
            //-------------------------------------------------------------

        }



        private DirectoryInfo Get_FirefoxSettingPath()
        {
            //This function looks for Firefoxes prefs.js file for the current user
            string RootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToLower() + "\\Mozilla\\Firefox\\Profiles\\";
            DirectoryInfo RootInfo = new DirectoryInfo(RootPath);
            return RootInfo;
        }
        private void ChangeFirefoxProxy(Boolean EnableProxy)
        {
             DirectoryInfo RootInf=Get_FirefoxSettingPath();
            foreach (DirectoryInfo DInfo in RootInf.GetDirectories())
            {
                foreach (FileInfo FInfo in DInfo.GetFiles())
                {
                    if (FInfo.Name.ToLower() == "prefs.js")
                    {
                        EditPrefsJS(FInfo, Properties.Settings.Default.ProxyPort, Properties.Settings.Default.ProxyServerIP,EnableProxy);
                    }
                }
            }
        }

        /// <summary>
        /// Edit Firefox Proxy setting by editing>> prefs.js
        /// </summary>
        /// <param name="FInfo">Path of file>> prefs.js</param>
        /// <param name="Port">Proxy port</param>
        /// <param name="IPAddress">Proxy Server IP</param>
        private void EditPrefsJS(FileInfo FInfo, String Port, string IPAddress,Boolean Enable)
        {
          //This function edits firefoxes prefs.js file to turn the proxy server on/off
            bool HasIP = false;
            bool HasPort = false;
            bool HasSSLip = false; //for HTTPS
            bool HasSSLPort = false;
            bool HasEnabled = false;
            string NewData = "";
            System.IO.FileStream FS = FInfo.OpenRead();
            byte[] Data = new byte[FS.Length];
            if (Data.Length > FS.Length)
                Data = new byte[FS.Length];
            FS.Read(Data, 0, Data.Length);
            FS.Close();
            string FileData = ASCIIEncoding.ASCII.GetString(Data).Replace(Environment.NewLine, "¬");
            string[] Lines = FileData.Split('¬'); ;
            foreach (string Line in Lines)
            {
                string LineOutput = Line;
                if (Line.ToLower().IndexOf("user_pref(\"network.proxy.") > -1)
                {
                    if (Line.ToLower().IndexOf(".http\"") > -1)
                    {
                        HasIP = true;
                        NewData += "user_pref(\"network.proxy.http\", \"" + IPAddress + "\");" + Environment.NewLine;
                    }
                    if (Line.ToLower().IndexOf("http_port") > -1)
                    {
                        HasPort = true;
                        NewData += "user_pref(\"network.proxy.http_port\"," + Port + ");" + Environment.NewLine;
                    }
                    if (Line.ToLower().IndexOf(".ssl\"") > -1)
                    {
                        HasSSLip = true;
                        NewData += "user_pref(\"network.proxy.ssl\", \"" + IPAddress + "\");" + Environment.NewLine;
                    }
                    if (Line.ToLower().IndexOf("ssl_port") > -1)
                    {
                        HasSSLPort = true;
                        NewData += "user_pref(\"network.proxy.ssl_port\"," + Port + ");" + Environment.NewLine;
                    }
                    if (Line.ToLower().IndexOf("proxy.type") > -1 && Enable)
                    {
                        HasEnabled = true;
                        NewData += "user_pref(\"network.proxy.type\", 1);" + Environment.NewLine;
                    }
                    if (Line.ToLower().IndexOf("proxy.type") > -1 && !Enable)
                    {
                        HasEnabled = true;
                        NewData += "user_pref(\"network.proxy.type\", 0);" + Environment.NewLine;
                    }
                }
                else
                    NewData += Line + Environment.NewLine;
            }
            //If the prefs.js file did not contain the correct user_pref then add them to the end of the file
            if (!HasIP)
                NewData += "user_pref(\"network.proxy.http\", \"" + IPAddress + "\");" + Environment.NewLine;
            if (!HasPort)
                NewData += "user_pref(\"network.proxy.http_port\"," + Port + ");" + Environment.NewLine;
            if (!HasSSLip)
                NewData += "user_pref(\"network.proxy.ssl\", \"" + IPAddress + "\");" + Environment.NewLine;
            if (!HasSSLPort)
                NewData += "user_pref(\"network.proxy.ssl_port\"," + Port + ");" + Environment.NewLine;
            if (!HasEnabled)
            {
                if (Enable)
                    NewData += "user_pref(\"network.proxy.type\", 1);" + Environment.NewLine;
                else
                    NewData += "user_pref(\"network.proxy.type\", 0);" + Environment.NewLine;
            }
           
            
             File.WriteAllText(FInfo.FullName, NewData);//Calls function to simply save the new file


            //---------------------Note------------------------------------
            //user.js may contain disable proxy setting we should delete it!
            //-------------------------------------------------------------

        }


       

        #endregion


        #region Change IE Proxy

        private void Check_IE_ProxyStatus()
        {
           
                RegistryKey regist = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", false);
           
            
          try
          {
              if (regist.GetValue("ProxyEnable") == null)
              {
                  regist = regist.CreateSubKey("ProxyEnable");
                  regist.SetValue("ProxyServer", 0);
              }
          }
            catch(Exception exc)
          {
                MessageBox.Show("در دسترسی به تنظیمات پراکسی خطای زیر رخ داد"+"\n"+exc.Message,"خطا در دسترسی به پراکسی",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btn_IEproxy.Enabled=false;
                lbl_IEstatus.Text="غیرفعال";
                lbl_IEstatus.ForeColor=Color.Gray;
                return;
          }
           
            
                //Check proxy status
                    if ((int)regist.GetValue("ProxyEnable")==1)
                    {
                        lbl_IEstatus.Text = "پراکسی فعال است";
                        lbl_IEstatus.ForeColor = Color.Green;
                        btn_IEproxy.BackgroundImage = Properties.Resources.IE;
                    }
                    else
                    {
                        lbl_IEstatus.Text = "پراکسی غیرفعال است";
                        lbl_IEstatus.ForeColor = Color.Red;
                        btn_IEproxy.BackgroundImage = Properties.Resources.IE2;
                    }
                
        }
        private void btn_IEproxy_Click(object sender, EventArgs e)
        {
           if( Change_IE_Proxy())
            Check_IE_ProxyStatus();
        }
        private Boolean Change_IE_Proxy()
        {
            try
            {
                RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);

                //Check proxy status
                if ((int)registry.GetValue("ProxyEnable") == 1)
                    registry.SetValue("ProxyEnable", 0);
                else //set Proxy
                {
                    registry.SetValue("ProxyEnable", 1);

                    if (registry.OpenSubKey("ProxyServer",true) != null)
                    {
                        registry.SetValue("ProxyServer",Properties.Settings.Default.ProxyServerIP + ":" + Properties.Settings.Default.ProxyPort);
                    }
                    else //if key don't exists create it 
                    {
                        registry=registry.CreateSubKey("ProxyServer");
                        registry.SetValue("ProxyServer", Properties.Settings.Default.ProxyServerIP + ":" + Properties.Settings.Default.ProxyPort);
                    }
                }
                // These lines implement the Interface in the beginning of program 
                // They cause the OS to refresh the settings, causing IP to realy update
                settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
                refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

               // MessageBox.Show("تغییرات با موفقیت انجام شد","IE Change Proxy",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("تغییر پراکسی IE به علت خطای زیر انجام نشد" + "\n" + ex.Message, "خطا در تغییر پراکسی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void linkLabel_Settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            settingForm fr = new settingForm();
            fr.ShowDialog();
        }

        private void linkLabel_About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AboutBox1 abx = new AboutBox1();
            abx.ShowDialog();
            this.Show();
        }

        
    }
}
