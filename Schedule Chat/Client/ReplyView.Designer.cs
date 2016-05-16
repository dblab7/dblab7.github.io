namespace Client
{
    partial class ReplyView
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
            this.tx_com = new System.Windows.Forms.RichTextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tx_com
            // 
            this.tx_com.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tx_com.Location = new System.Drawing.Point(12, 12);
            this.tx_com.Name = "tx_com";
            this.tx_com.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.tx_com.Size = new System.Drawing.Size(506, 257);
            this.tx_com.TabIndex = 0;
            this.tx_com.Text = "";
            this.tx_com.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_com_KeyDown);
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(362, 275);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 41);
            this.bt_send.TabIndex = 1;
            this.bt_send.Text = "보내기";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(443, 275);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 41);
            this.bt_close.TabIndex = 2;
            this.bt_close.Text = "닫기";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(530, 321);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tx_com);
            this.Name = "Form5";
            this.Text = "답장";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tx_com;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Button bt_close;
    }
}