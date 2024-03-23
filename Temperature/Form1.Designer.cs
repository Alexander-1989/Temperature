﻿
namespace Temperature
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.comPortsComboBox = new System.Windows.Forms.ComboBox();
            this.comPortTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.startMinimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.autoConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.darkThemeCheckBox = new System.Windows.Forms.CheckBox();
            this.minimizeOnCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.autoRunCheckBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comPortsComboBox
            // 
            this.comPortsComboBox.FormattingEnabled = true;
            this.comPortsComboBox.Location = new System.Drawing.Point(6, 11);
            this.comPortsComboBox.Name = "comPortsComboBox";
            this.comPortsComboBox.Size = new System.Drawing.Size(121, 21);
            this.comPortsComboBox.TabIndex = 2;
            this.comPortsComboBox.SelectedIndexChanged += new System.EventHandler(this.ComPortsComboBox_SelectedIndexChanged);
            // 
            // comPortTimer
            // 
            this.comPortTimer.Interval = 1000;
            this.comPortTimer.Tick += new System.EventHandler(this.ComPortTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Temperature";
            this.notifyIcon1.Visible = true;
            // 
            // startMinimizeCheckBox
            // 
            this.startMinimizeCheckBox.AutoSize = true;
            this.startMinimizeCheckBox.Location = new System.Drawing.Point(135, 47);
            this.startMinimizeCheckBox.Name = "startMinimizeCheckBox";
            this.startMinimizeCheckBox.Size = new System.Drawing.Size(91, 17);
            this.startMinimizeCheckBox.TabIndex = 6;
            this.startMinimizeCheckBox.Text = "Start Minimize";
            this.startMinimizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoConnectCheckBox
            // 
            this.autoConnectCheckBox.AutoSize = true;
            this.autoConnectCheckBox.Location = new System.Drawing.Point(135, 65);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.Size = new System.Drawing.Size(91, 17);
            this.autoConnectCheckBox.TabIndex = 7;
            this.autoConnectCheckBox.Text = "Auto Connect";
            this.autoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(3, 99);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(262, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel.Text = "Status: Disconnect";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.darkThemeCheckBox);
            this.groupBox1.Controls.Add(this.minimizeOnCloseCheckBox);
            this.groupBox1.Controls.Add(this.autoRunCheckBox);
            this.groupBox1.Controls.Add(this.comPortsComboBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.autoConnectCheckBox);
            this.groupBox1.Controls.Add(this.startMinimizeCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 108);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // darkThemeCheckBox
            // 
            this.darkThemeCheckBox.AutoSize = true;
            this.darkThemeCheckBox.Location = new System.Drawing.Point(135, 83);
            this.darkThemeCheckBox.Name = "darkThemeCheckBox";
            this.darkThemeCheckBox.Size = new System.Drawing.Size(85, 17);
            this.darkThemeCheckBox.TabIndex = 15;
            this.darkThemeCheckBox.Text = "Dark Theme";
            this.darkThemeCheckBox.UseVisualStyleBackColor = true;
            // 
            // minimizeOnCloseCheckBox
            // 
            this.minimizeOnCloseCheckBox.AutoSize = true;
            this.minimizeOnCloseCheckBox.Location = new System.Drawing.Point(135, 29);
            this.minimizeOnCloseCheckBox.Name = "minimizeOnCloseCheckBox";
            this.minimizeOnCloseCheckBox.Size = new System.Drawing.Size(109, 17);
            this.minimizeOnCloseCheckBox.TabIndex = 14;
            this.minimizeOnCloseCheckBox.Text = "Minimize on close";
            this.minimizeOnCloseCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoRunCheckBox
            // 
            this.autoRunCheckBox.AutoSize = true;
            this.autoRunCheckBox.Location = new System.Drawing.Point(135, 11);
            this.autoRunCheckBox.Name = "autoRunCheckBox";
            this.autoRunCheckBox.Size = new System.Drawing.Size(71, 17);
            this.autoRunCheckBox.TabIndex = 13;
            this.autoRunCheckBox.Text = "Auto Run";
            this.autoRunCheckBox.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(114, 92);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.showToolStripMenuItem.Text = "Hide";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.connectToolStripMenuItem.Text = "Start";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.RefreshToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 124);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comPortsComboBox;
        private System.Windows.Forms.Timer comPortTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox startMinimizeCheckBox;
        private System.Windows.Forms.CheckBox autoConnectCheckBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox autoRunCheckBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox minimizeOnCloseCheckBox;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.CheckBox darkThemeCheckBox;
    }
}

