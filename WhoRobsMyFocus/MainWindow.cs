using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoRobsMyFocus
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<LogEntry> log = new List<LogEntry>();

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            var logitem = NativeMethods.GetTopWindowInfo();
            if (logitem == null) return;
            if (!logitem.Equals(log.LastOrDefault()))
            {
                log.Add(logitem);
                if (log.Count > Properties.Settings.Default.LogCount)
                {
                    log.RemoveAt(0);
                }
                lblHint.Text = logitem.ToString();
            }
        }

        SettingsAndLogWindow settingWindow = new SettingsAndLogWindow();

        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                tmrMain.Stop();
                settingWindow.ShowDialog(log);
                if (settingWindow.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    tmrMain.Interval = Properties.Settings.Default.Interval;
                    this.TopMost = Properties.Settings.Default.TopMost;
                    this.Height = Properties.Settings.Default.MainWindowHeight;
                    this.Width = Properties.Settings.Default.MainWindowWidth;
                }
                tmrMain.Start();
            }
            else if (e.KeyChar == 'x')
            {
                this.Close();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainWindowTop = this.Top;
            Properties.Settings.Default.MainWindowLeft = this.Left;
            Properties.Settings.Default.Save();
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            NativeMethods.DoCaptionDown(this.Handle);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.TopMost = Properties.Settings.Default.TopMost;
            this.Height = Properties.Settings.Default.MainWindowHeight;
            this.Width = Properties.Settings.Default.MainWindowWidth;
            this.Left = Properties.Settings.Default.MainWindowLeft;
            this.Top = Properties.Settings.Default.MainWindowTop;
        }
    }
}
