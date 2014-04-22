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
    public partial class SettingsAndLogWindow : Form
    {
        public SettingsAndLogWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Interval = (int)numInterval.Value;
            Properties.Settings.Default.LogCount = (int)numLogCount.Value;
            Properties.Settings.Default.TopMost = chkTopMost.Checked;
            Properties.Settings.Default.MainWindowHeight = (int)numWindowHeight.Value;
            Properties.Settings.Default.MainWindowWidth = (int)numWindowWidth.Value;
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public DialogResult ShowDialog(List<LogEntry> lstLog)
        {
            lstLogList.Items.Clear();
            lstLogList.Items.AddRange(lstLog.ToArray());
            numInterval.Value = Properties.Settings.Default.Interval;
            numLogCount.Value = Properties.Settings.Default.LogCount;
            numWindowWidth.Value = Properties.Settings.Default.MainWindowWidth;
            numWindowHeight.Value = Properties.Settings.Default.MainWindowHeight;
            chkTopMost.Checked = Properties.Settings.Default.TopMost;
            return this.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void lstLogList_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 60;
        }
        private static StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
        private void lstLogList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString((lstLogList.Items[e.Index] as LogEntry).ToString(true), e.Font, new SolidBrush(e.ForeColor), e.Bounds, format);
        }
    }
}
