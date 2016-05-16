namespace Client
{
    partial class Clients
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.p_login = new System.Windows.Forms.Panel();
            this.bt_joincom = new System.Windows.Forms.Button();
            this.b_login = new System.Windows.Forms.Button();
            this.tx_psw = new System.Windows.Forms.TextBox();
            this.tx_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.p_join = new System.Windows.Forms.Panel();
            this.bt_back = new System.Windows.Forms.Button();
            this.bt_join = new System.Windows.Forms.Button();
            this.tx_join = new System.Windows.Forms.TextBox();
            this.tx_pwd1 = new System.Windows.Forms.TextBox();
            this.tx_pwd2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_reset = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tree_friend = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.메신저정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.p_login.SuspendLayout();
            this.p_join.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "login.bmp");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(323, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // p_login
            // 
            this.p_login.Controls.Add(this.bt_joincom);
            this.p_login.Controls.Add(this.b_login);
            this.p_login.Controls.Add(this.tx_psw);
            this.p_login.Controls.Add(this.tx_id);
            this.p_login.Controls.Add(this.label4);
            this.p_login.Controls.Add(this.label3);
            this.p_login.Controls.Add(this.label2);
            this.p_login.Location = new System.Drawing.Point(0, 8);
            this.p_login.Name = "p_login";
            this.p_login.Size = new System.Drawing.Size(324, 427);
            this.p_login.TabIndex = 4;
            // 
            // bt_joincom
            // 
            this.bt_joincom.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_joincom.Location = new System.Drawing.Point(56, 301);
            this.bt_joincom.Name = "bt_joincom";
            this.bt_joincom.Size = new System.Drawing.Size(206, 31);
            this.bt_joincom.TabIndex = 6;
            this.bt_joincom.Text = "회원가입";
            this.bt_joincom.UseVisualStyleBackColor = true;
            this.bt_joincom.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_login
            // 
            this.b_login.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b_login.Location = new System.Drawing.Point(56, 253);
            this.b_login.Name = "b_login";
            this.b_login.Size = new System.Drawing.Size(206, 42);
            this.b_login.TabIndex = 5;
            this.b_login.Text = "로그인";
            this.b_login.UseVisualStyleBackColor = true;
            this.b_login.Click += new System.EventHandler(this.b_login_Click);
            // 
            // tx_psw
            // 
            this.tx_psw.Location = new System.Drawing.Point(162, 213);
            this.tx_psw.Name = "tx_psw";
            this.tx_psw.PasswordChar = '●';
            this.tx_psw.Size = new System.Drawing.Size(100, 21);
            this.tx_psw.TabIndex = 4;
            // 
            // tx_id
            // 
            this.tx_id.Location = new System.Drawing.Point(162, 184);
            this.tx_id.Name = "tx_id";
            this.tx_id.Size = new System.Drawing.Size(100, 21);
            this.tx_id.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Snap ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 63);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bonfire";
            // 
            // p_join
            // 
            this.p_join.Controls.Add(this.p_login);
            this.p_join.Controls.Add(this.bt_back);
            this.p_join.Controls.Add(this.bt_join);
            this.p_join.Controls.Add(this.tx_join);
            this.p_join.Controls.Add(this.tx_pwd1);
            this.p_join.Controls.Add(this.tx_pwd2);
            this.p_join.Controls.Add(this.label5);
            this.p_join.Controls.Add(this.label6);
            this.p_join.Controls.Add(this.label8);
            this.p_join.Controls.Add(this.label7);
            this.p_join.Controls.Add(this.bt_reset);
            this.p_join.Location = new System.Drawing.Point(0, 27);
            this.p_join.Name = "p_join";
            this.p_join.Size = new System.Drawing.Size(324, 427);
            this.p_join.TabIndex = 5;
            // 
            // bt_back
            // 
            this.bt_back.Location = new System.Drawing.Point(53, 312);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(104, 31);
            this.bt_back.TabIndex = 4;
            this.bt_back.Text = "취소";
            this.bt_back.UseVisualStyleBackColor = true;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // bt_join
            // 
            this.bt_join.Location = new System.Drawing.Point(53, 271);
            this.bt_join.Name = "bt_join";
            this.bt_join.Size = new System.Drawing.Size(205, 35);
            this.bt_join.TabIndex = 3;
            this.bt_join.Text = "가입하기";
            this.bt_join.UseVisualStyleBackColor = true;
            this.bt_join.Click += new System.EventHandler(this.bt_join_Click);
            // 
            // tx_join
            // 
            this.tx_join.Location = new System.Drawing.Point(158, 179);
            this.tx_join.Name = "tx_join";
            this.tx_join.Size = new System.Drawing.Size(100, 21);
            this.tx_join.TabIndex = 1;
            // 
            // tx_pwd1
            // 
            this.tx_pwd1.Location = new System.Drawing.Point(158, 211);
            this.tx_pwd1.Name = "tx_pwd1";
            this.tx_pwd1.PasswordChar = '●';
            this.tx_pwd1.Size = new System.Drawing.Size(100, 21);
            this.tx_pwd1.TabIndex = 1;
            // 
            // tx_pwd2
            // 
            this.tx_pwd2.Location = new System.Drawing.Point(158, 241);
            this.tx_pwd2.Name = "tx_pwd2";
            this.tx_pwd2.PasswordChar = '●';
            this.tx_pwd2.Size = new System.Drawing.Size(100, 21);
            this.tx_pwd2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Snap ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 63);
            this.label5.TabIndex = 0;
            this.label5.Text = "Join";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(116, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "ID : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(71, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Repeat :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Password : ";
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(158, 312);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(100, 31);
            this.bt_reset.TabIndex = 5;
            this.bt_reset.Text = "다시쓰기";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(315, 421);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tree_friend);
            this.tabPage1.Font = new System.Drawing.Font("휴먼매직체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(307, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "친구목록";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tree_friend
            // 
            this.tree_friend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree_friend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tree_friend.ImageIndex = 0;
            this.tree_friend.ImageList = this.imageList1;
            this.tree_friend.Location = new System.Drawing.Point(0, 0);
            this.tree_friend.Name = "tree_friend";
            this.tree_friend.SelectedImageIndex = 0;
            this.tree_friend.Size = new System.Drawing.Size(307, 396);
            this.tree_friend.TabIndex = 0;
            this.tree_friend.Click += new System.EventHandler(this.tree_friend_Click);
            this.tree_friend.DoubleClick += new System.EventHandler(this.tree_friend_DoubleClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 0;
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그아웃ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Enabled = false;
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 친구ToolStripMenuItem
            // 
            this.친구ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.친구추가ToolStripMenuItem,
            this.친구삭제ToolStripMenuItem});
            this.친구ToolStripMenuItem.Name = "친구ToolStripMenuItem";
            this.친구ToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.친구ToolStripMenuItem.Text = "친구";
            // 
            // 친구추가ToolStripMenuItem
            // 
            this.친구추가ToolStripMenuItem.Enabled = false;
            this.친구추가ToolStripMenuItem.Name = "친구추가ToolStripMenuItem";
            this.친구추가ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.친구추가ToolStripMenuItem.Text = "친구추가";
            this.친구추가ToolStripMenuItem.Click += new System.EventHandler(this.친구추가ToolStripMenuItem_Click);
            // 
            // 친구삭제ToolStripMenuItem
            // 
            this.친구삭제ToolStripMenuItem.Enabled = false;
            this.친구삭제ToolStripMenuItem.Name = "친구삭제ToolStripMenuItem";
            this.친구삭제ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.친구삭제ToolStripMenuItem.Text = "친구삭제";
            this.친구삭제ToolStripMenuItem.Click += new System.EventHandler(this.친구삭제ToolStripMenuItem_Click);
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메신저정보ToolStripMenuItem});
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.도움말ToolStripMenuItem.Text = "도움말";
            // 
            // 메신저정보ToolStripMenuItem
            // 
            this.메신저정보ToolStripMenuItem.Name = "메신저정보ToolStripMenuItem";
            this.메신저정보ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.메신저정보ToolStripMenuItem.Text = "메신저정보";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("휴먼모음T", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.친구ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(323, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Cilent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(323, 480);
            this.Controls.Add(this.p_join);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Cilent";
            this.Text = "모닥불";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cilent_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.p_login.ResumeLayout(false);
            this.p_login.PerformLayout();
            this.p_join.ResumeLayout(false);
            this.p_join.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel p_login;
        private System.Windows.Forms.Button b_login;
        private System.Windows.Forms.TextBox tx_psw;
        private System.Windows.Forms.TextBox tx_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bt_joincom;
        private System.Windows.Forms.Panel p_join;
        private System.Windows.Forms.TextBox tx_join;
        private System.Windows.Forms.TextBox tx_pwd1;
        private System.Windows.Forms.TextBox tx_pwd2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_join;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView tree_friend;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메신저정보ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

