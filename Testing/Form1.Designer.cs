using SolidEdgeConstants;
using System;

namespace ColorPalette_Winform
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
            if(disposing && (components != null))
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
            this.trackBarRed = new System.Windows.Forms.TrackBar();
            this.trackBarGreen = new System.Windows.Forms.TrackBar();
            this.trackBarBlue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butEnter = new System.Windows.Forms.Button();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.panelColor = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lstLocate = new System.Windows.Forms.ListBox();
            this.txbox_Msg = new System.Windows.Forms.TextBox();
            this.oopc_tbox = new System.Windows.Forms.TextBox();
            this.butClear = new System.Windows.Forms.Button();
            this.but10 = new System.Windows.Forms.Button();
            this.but11 = new System.Windows.Forms.Button();
            this.but12 = new System.Windows.Forms.Button();
            this.but13 = new System.Windows.Forms.Button();
            this.but14 = new System.Windows.Forms.Button();
            this.but15 = new System.Windows.Forms.Button();
            this.but16 = new System.Windows.Forms.Button();
            this.but17 = new System.Windows.Forms.Button();
            this.but18 = new System.Windows.Forms.Button();
            this.but19 = new System.Windows.Forms.Button();
            this.but20 = new System.Windows.Forms.Button();
            this.but21 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarRed
            // 
            this.trackBarRed.Location = new System.Drawing.Point(64, 164);
            this.trackBarRed.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.trackBarRed.Maximum = 255;
            this.trackBarRed.Name = "trackBarRed";
            this.trackBarRed.Size = new System.Drawing.Size(195, 56);
            this.trackBarRed.TabIndex = 0;
            this.trackBarRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRed.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // trackBarGreen
            // 
            this.trackBarGreen.Location = new System.Drawing.Point(64, 209);
            this.trackBarGreen.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.trackBarGreen.Maximum = 255;
            this.trackBarGreen.Name = "trackBarGreen";
            this.trackBarGreen.Size = new System.Drawing.Size(195, 56);
            this.trackBarGreen.TabIndex = 1;
            this.trackBarGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarGreen.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // trackBarBlue
            // 
            this.trackBarBlue.Location = new System.Drawing.Point(64, 254);
            this.trackBarBlue.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.trackBarBlue.Maximum = 255;
            this.trackBarBlue.Name = "trackBarBlue";
            this.trackBarBlue.Size = new System.Drawing.Size(195, 56);
            this.trackBarBlue.TabIndex = 2;
            this.trackBarBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBlue.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(4, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(4, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "B";
            // 
            // butEnter
            // 
            this.butEnter.BackColor = System.Drawing.SystemColors.Control;
            this.butEnter.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butEnter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butEnter.Location = new System.Drawing.Point(357, 304);
            this.butEnter.Name = "butEnter";
            this.butEnter.Size = new System.Drawing.Size(62, 37);
            this.butEnter.TabIndex = 11;
            this.butEnter.Text = "OK";
            this.butEnter.UseVisualStyleBackColor = false;
            this.butEnter.Click += new System.EventHandler(this.ButEnter_Click);
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(64, 299);
            this.trackBarOpacity.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.trackBarOpacity.Maximum = 255;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(195, 56);
            this.trackBarOpacity.TabIndex = 2;
            this.trackBarOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarOpacity.Value = 255;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelRed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRed.ForeColor = System.Drawing.Color.Black;
            this.labelRed.Location = new System.Drawing.Point(32, 164);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(24, 27);
            this.labelRed.TabIndex = 3;
            this.labelRed.Text = "0";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelGreen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGreen.ForeColor = System.Drawing.Color.Black;
            this.labelGreen.Location = new System.Drawing.Point(32, 209);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(24, 27);
            this.labelGreen.TabIndex = 4;
            this.labelGreen.Text = "0";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelBlue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBlue.ForeColor = System.Drawing.Color.Black;
            this.labelBlue.Location = new System.Drawing.Point(32, 254);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(24, 27);
            this.labelBlue.TabIndex = 5;
            this.labelBlue.Text = "0";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelOpacity.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpacity.ForeColor = System.Drawing.Color.Black;
            this.labelOpacity.Location = new System.Drawing.Point(32, 299);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(24, 27);
            this.labelOpacity.TabIndex = 5;
            this.labelOpacity.Text = "0";
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.White;
            this.panelColor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panelColor.Location = new System.Drawing.Point(265, 304);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(86, 37);
            this.panelColor.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "O";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // lstLocate
            // 
            this.lstLocate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstLocate.FormattingEnabled = true;
            this.lstLocate.ItemHeight = 15;
            this.lstLocate.Location = new System.Drawing.Point(9, 4);
            this.lstLocate.Name = "lstLocate";
            this.lstLocate.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstLocate.Size = new System.Drawing.Size(181, 139);
            this.lstLocate.Sorted = true;
            this.lstLocate.TabIndex = 12;
            // 
            // txbox_Msg
            // 
            this.txbox_Msg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbox_Msg.Location = new System.Drawing.Point(196, 4);
            this.txbox_Msg.Multiline = true;
            this.txbox_Msg.Name = "txbox_Msg";
            this.txbox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbox_Msg.Size = new System.Drawing.Size(301, 140);
            this.txbox_Msg.TabIndex = 13;
            // 
            // oopc_tbox
            // 
            this.oopc_tbox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oopc_tbox.Location = new System.Drawing.Point(265, 150);
            this.oopc_tbox.Name = "oopc_tbox";
            this.oopc_tbox.Size = new System.Drawing.Size(232, 25);
            this.oopc_tbox.TabIndex = 15;
            this.oopc_tbox.WordWrap = false;
            // 
            // butClear
            // 
            this.butClear.BackColor = System.Drawing.SystemColors.Control;
            this.butClear.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butClear.Location = new System.Drawing.Point(425, 304);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(66, 37);
            this.butClear.TabIndex = 11;
            this.butClear.Text = "ESC";
            this.butClear.UseVisualStyleBackColor = false;
            this.butClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // but10
            // 
            this.but10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but10.Location = new System.Drawing.Point(265, 181);
            this.but10.Name = "but10";
            this.but10.Size = new System.Drawing.Size(52, 35);
            this.but10.TabIndex = 17;
            this.but10.Text = "10";
            this.but10.UseVisualStyleBackColor = true;
            this.but10.Click += new System.EventHandler(this.Part_Click);
            // 
            // but11
            // 
            this.but11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but11.Location = new System.Drawing.Point(323, 181);
            this.but11.Name = "but11";
            this.but11.Size = new System.Drawing.Size(52, 35);
            this.but11.TabIndex = 17;
            this.but11.Text = "11";
            this.but11.UseVisualStyleBackColor = true;
            this.but11.Click += new System.EventHandler(this.Assembly_Click);
            // 
            // but12
            // 
            this.but12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but12.Location = new System.Drawing.Point(381, 181);
            this.but12.Name = "but12";
            this.but12.Size = new System.Drawing.Size(52, 35);
            this.but12.TabIndex = 17;
            this.but12.Text = "12";
            this.but12.UseVisualStyleBackColor = true;
            this.but12.Click += new System.EventHandler(this.Draft_Clict);
            // 
            // but13
            // 
            this.but13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but13.Location = new System.Drawing.Point(439, 181);
            this.but13.Name = "but13";
            this.but13.Size = new System.Drawing.Size(52, 35);
            this.but13.TabIndex = 17;
            this.but13.Text = "13";
            this.but13.UseVisualStyleBackColor = true;
            this.but13.Click += new System.EventHandler(this.AllDocument);
            // 
            // but14
            // 
            this.but14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but14.Location = new System.Drawing.Point(265, 222);
            this.but14.Name = "but14";
            this.but14.Size = new System.Drawing.Size(52, 35);
            this.but14.TabIndex = 17;
            this.but14.Text = "14";
            this.but14.UseVisualStyleBackColor = true;
            this.but14.Click += new System.EventHandler(this.but14_Click);
            // 
            // but15
            // 
            this.but15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but15.Location = new System.Drawing.Point(323, 222);
            this.but15.Name = "but15";
            this.but15.Size = new System.Drawing.Size(52, 35);
            this.but15.TabIndex = 17;
            this.but15.Text = "15";
            this.but15.UseVisualStyleBackColor = true;
            this.but15.Click += new System.EventHandler(this.But15_Click);
            // 
            // but16
            // 
            this.but16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but16.Location = new System.Drawing.Point(381, 222);
            this.but16.Name = "but16";
            this.but16.Size = new System.Drawing.Size(52, 35);
            this.but16.TabIndex = 17;
            this.but16.Text = "16";
            this.but16.UseVisualStyleBackColor = true;
            this.but16.Click += new System.EventHandler(this.But16_Click);
            // 
            // but17
            // 
            this.but17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but17.Location = new System.Drawing.Point(439, 222);
            this.but17.Name = "but17";
            this.but17.Size = new System.Drawing.Size(52, 35);
            this.but17.TabIndex = 17;
            this.but17.Text = "17";
            this.but17.UseVisualStyleBackColor = true;
            this.but17.Click += new System.EventHandler(this.But17_Click);
            // 
            // but18
            // 
            this.but18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but18.Location = new System.Drawing.Point(265, 263);
            this.but18.Name = "but18";
            this.but18.Size = new System.Drawing.Size(52, 35);
            this.but18.TabIndex = 17;
            this.but18.Text = "18";
            this.but18.UseVisualStyleBackColor = true;
            this.but18.Click += new System.EventHandler(this.But18_Click);
            // 
            // but19
            // 
            this.but19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but19.Location = new System.Drawing.Point(323, 263);
            this.but19.Name = "but19";
            this.but19.Size = new System.Drawing.Size(52, 35);
            this.but19.TabIndex = 17;
            this.but19.Text = "19";
            this.but19.UseVisualStyleBackColor = true;
            this.but19.Click += new System.EventHandler(this.But19_Click);
            // 
            // but20
            // 
            this.but20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but20.Location = new System.Drawing.Point(381, 263);
            this.but20.Name = "but20";
            this.but20.Size = new System.Drawing.Size(52, 35);
            this.but20.TabIndex = 17;
            this.but20.Text = "20";
            this.but20.UseVisualStyleBackColor = true;
            this.but20.Click += new System.EventHandler(this.but20_Click);
            // 
            // but21
            // 
            this.but21.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but21.Location = new System.Drawing.Point(439, 263);
            this.but21.Name = "but21";
            this.but21.Size = new System.Drawing.Size(52, 35);
            this.but21.TabIndex = 17;
            this.but21.Text = "21";
            this.but21.UseVisualStyleBackColor = true;
            this.but21.Click += new System.EventHandler(this.but21_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(500, 347);
            this.Controls.Add(this.but21);
            this.Controls.Add(this.but17);
            this.Controls.Add(this.but13);
            this.Controls.Add(this.but20);
            this.Controls.Add(this.but16);
            this.Controls.Add(this.but12);
            this.Controls.Add(this.but19);
            this.Controls.Add(this.but15);
            this.Controls.Add(this.but11);
            this.Controls.Add(this.but18);
            this.Controls.Add(this.but14);
            this.Controls.Add(this.but10);
            this.Controls.Add(this.oopc_tbox);
            this.Controls.Add(this.txbox_Msg);
            this.Controls.Add(this.lstLocate);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butEnter);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarOpacity);
            this.Controls.Add(this.trackBarBlue);
            this.Controls.Add(this.trackBarGreen);
            this.Controls.Add(this.trackBarRed);
            this.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Palette";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }


        #endregion

        private System.Windows.Forms.TrackBar trackBarRed;
        private System.Windows.Forms.TrackBar trackBarGreen;
        private System.Windows.Forms.TrackBar trackBarBlue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butEnter;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox lstLocate;
        private System.Windows.Forms.TextBox txbox_Msg;
        private System.Windows.Forms.TextBox oopc_tbox;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button but10;
        private System.Windows.Forms.Button but11;
        private System.Windows.Forms.Button but12;
        private System.Windows.Forms.Button but13;
        private System.Windows.Forms.Button but14;
        private System.Windows.Forms.Button but15;
        private System.Windows.Forms.Button but16;
        private System.Windows.Forms.Button but17;
        private System.Windows.Forms.Button but18;
        private System.Windows.Forms.Button but19;
        private System.Windows.Forms.Button but20;
        private System.Windows.Forms.Button but21;
    }
    }

