namespace Client
{
    partial class ReceiveView
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.s_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_resend = new System.Windows.Forms.Button();
            this.tx_com = new System.Windows.Forms.TextBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s_time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 314);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // s_time
            // 
            this.s_time.Name = "s_time";
            this.s_time.Size = new System.Drawing.Size(0, 17);
            // 
            // bt_close
            // 
            this.bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_close.Location = new System.Drawing.Point(425, 280);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 31);
            this.bt_close.TabIndex = 2;
            this.bt_close.Text = "닫기";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_resend
            // 
            this.bt_resend.Location = new System.Drawing.Point(344, 280);
            this.bt_resend.Name = "bt_resend";
            this.bt_resend.Size = new System.Drawing.Size(75, 31);
            this.bt_resend.TabIndex = 3;
            this.bt_resend.Text = "답장";
            this.bt_resend.UseVisualStyleBackColor = true;
            this.bt_resend.Click += new System.EventHandler(this.bt_resend_Click);
            // 
            // tx_com
            // 
            this.tx_com.BackColor = System.Drawing.Color.Cornsilk;
            this.tx_com.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tx_com.Location = new System.Drawing.Point(12, 12);
            this.tx_com.Multiline = true;
            this.tx_com.Name = "tx_com";
            this.tx_com.Size = new System.Drawing.Size(488, 262);
            this.tx_com.TabIndex = 4;
            this.tx_com.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_com_KeyDown);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(12, 280);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 31);
            this.bt_ok.TabIndex = 5;
            this.bt_ok.Text = "대화수락";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Visible = false;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.bt_close;
            this.ClientSize = new System.Drawing.Size(512, 336);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.tx_com);
            this.Controls.Add(this.bt_resend);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form2";
            this.Text = "쪽지";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel s_time;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_resend;
        private System.Windows.Forms.TextBox tx_com;
        private System.Windows.Forms.Button bt_ok;
    }
}