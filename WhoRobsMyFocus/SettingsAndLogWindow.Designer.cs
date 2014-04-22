namespace WhoRobsMyFocus
{
    partial class SettingsAndLogWindow
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.lstLogList = new System.Windows.Forms.ListBox();
            this.numLogCount = new System.Windows.Forms.NumericUpDown();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.numWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.numWindowWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLogCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(142, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "历史记录总数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "检测间隔（毫秒）";
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(70, 101);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(96, 16);
            this.chkTopMost.TabIndex = 4;
            this.chkTopMost.Text = "窗口总在最前";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // lstLogList
            // 
            this.lstLogList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstLogList.FormattingEnabled = true;
            this.lstLogList.HorizontalScrollbar = true;
            this.lstLogList.ItemHeight = 12;
            this.lstLogList.Location = new System.Drawing.Point(236, 12);
            this.lstLogList.Name = "lstLogList";
            this.lstLogList.Size = new System.Drawing.Size(320, 240);
            this.lstLogList.TabIndex = 5;
            this.lstLogList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstLogList_DrawItem);
            this.lstLogList.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstLogList_MeasureItem);
            // 
            // numLogCount
            // 
            this.numLogCount.Location = new System.Drawing.Point(110, 50);
            this.numLogCount.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numLogCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLogCount.Name = "numLogCount";
            this.numLogCount.Size = new System.Drawing.Size(106, 21);
            this.numLogCount.TabIndex = 6;
            this.numLogCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(110, 13);
            this.numInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(106, 21);
            this.numInterval.TabIndex = 7;
            this.numInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWindowHeight
            // 
            this.numWindowHeight.Location = new System.Drawing.Point(110, 131);
            this.numWindowHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWindowHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWindowHeight.Name = "numWindowHeight";
            this.numWindowHeight.Size = new System.Drawing.Size(106, 21);
            this.numWindowHeight.TabIndex = 11;
            this.numWindowHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWindowWidth
            // 
            this.numWindowWidth.Location = new System.Drawing.Point(110, 168);
            this.numWindowWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numWindowWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWindowWidth.Name = "numWindowWidth";
            this.numWindowWidth.Size = new System.Drawing.Size(106, 21);
            this.numWindowWidth.TabIndex = 10;
            this.numWindowWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "主窗口高";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "主窗口宽";
            // 
            // SettingsAndLogWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(568, 259);
            this.Controls.Add(this.numWindowHeight);
            this.Controls.Add(this.numWindowWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numInterval);
            this.Controls.Add(this.numLogCount);
            this.Controls.Add(this.lstLogList);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsAndLogWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.numLogCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.ListBox lstLogList;
        private System.Windows.Forms.NumericUpDown numLogCount;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.NumericUpDown numWindowHeight;
        private System.Windows.Forms.NumericUpDown numWindowWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}