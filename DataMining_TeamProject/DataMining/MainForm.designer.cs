namespace DataMining
{
    partial class MainForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.radCoveringAlgorithm = new System.Windows.Forms.RadioButton();
            this.radDecisionTree = new System.Windows.Forms.RadioButton();
            this.radNaiveBayesian = new System.Windows.Forms.RadioButton();
            this.radOneRule = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtAccuracy = new System.Windows.Forms.TextBox();
            this.txtAppClass = new System.Windows.Forms.TextBox();
            this.lblLesesAccuracy = new System.Windows.Forms.Label();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.lblAtrr1 = new System.Windows.Forms.Label();
            this.lblAtrr2 = new System.Windows.Forms.Label();
            this.lblAtrr3 = new System.Windows.Forms.Label();
            this.cmbAttr1 = new System.Windows.Forms.ComboBox();
            this.cmbAttr4 = new System.Windows.Forms.ComboBox();
            this.lblAtrr4 = new System.Windows.Forms.Label();
            this.cmbAttr2 = new System.Windows.Forms.ComboBox();
            this.cmbAttr3 = new System.Windows.Forms.ComboBox();
            this.cmbAttr5 = new System.Windows.Forms.ComboBox();
            this.lblAtrr5 = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblAtrr7 = new System.Windows.Forms.Label();
            this.cmbAttr7 = new System.Windows.Forms.ComboBox();
            this.cmbAttr6 = new System.Windows.Forms.ComboBox();
            this.lblAtrr6 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.grpAlgorithm.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(436, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(8, 8);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.Controls.Add(this.radCoveringAlgorithm);
            this.grpAlgorithm.Controls.Add(this.radDecisionTree);
            this.grpAlgorithm.Controls.Add(this.radNaiveBayesian);
            this.grpAlgorithm.Controls.Add(this.radOneRule);
            this.grpAlgorithm.Location = new System.Drawing.Point(479, 12);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(140, 140);
            this.grpAlgorithm.TabIndex = 20;
            this.grpAlgorithm.TabStop = false;
            this.grpAlgorithm.Text = "Algorithm";
            // 
            // radCoveringAlgorithm
            // 
            this.radCoveringAlgorithm.AutoSize = true;
            this.radCoveringAlgorithm.Location = new System.Drawing.Point(6, 108);
            this.radCoveringAlgorithm.Name = "radCoveringAlgorithm";
            this.radCoveringAlgorithm.Size = new System.Drawing.Size(130, 16);
            this.radCoveringAlgorithm.TabIndex = 24;
            this.radCoveringAlgorithm.TabStop = true;
            this.radCoveringAlgorithm.Text = "Covering Algorithm";
            this.radCoveringAlgorithm.UseVisualStyleBackColor = true;
            // 
            // radDecisionTree
            // 
            this.radDecisionTree.AutoSize = true;
            this.radDecisionTree.Location = new System.Drawing.Point(6, 80);
            this.radDecisionTree.Name = "radDecisionTree";
            this.radDecisionTree.Size = new System.Drawing.Size(98, 16);
            this.radDecisionTree.TabIndex = 23;
            this.radDecisionTree.TabStop = true;
            this.radDecisionTree.Text = "DecisionTree";
            this.radDecisionTree.UseVisualStyleBackColor = true;
            // 
            // radNaiveBayesian
            // 
            this.radNaiveBayesian.AutoSize = true;
            this.radNaiveBayesian.Location = new System.Drawing.Point(6, 53);
            this.radNaiveBayesian.Name = "radNaiveBayesian";
            this.radNaiveBayesian.Size = new System.Drawing.Size(112, 16);
            this.radNaiveBayesian.TabIndex = 22;
            this.radNaiveBayesian.TabStop = true;
            this.radNaiveBayesian.Text = "Naive Bayesian";
            this.radNaiveBayesian.UseVisualStyleBackColor = true;
            // 
            // radOneRule
            // 
            this.radOneRule.AutoSize = true;
            this.radOneRule.Location = new System.Drawing.Point(6, 25);
            this.radOneRule.Name = "radOneRule";
            this.radOneRule.Size = new System.Drawing.Size(75, 16);
            this.radOneRule.TabIndex = 21;
            this.radOneRule.TabStop = true;
            this.radOneRule.Text = "One Rule";
            this.radOneRule.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(312, 158);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(161, 64);
            this.btnApply.TabIndex = 25;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(479, 158);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 64);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(30, 55);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(38, 12);
            this.lblClass.TabIndex = 16;
            this.lblClass.Text = "Class";
            this.lblClass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAccuracy
            // 
            this.txtAccuracy.BackColor = System.Drawing.Color.White;
            this.txtAccuracy.Location = new System.Drawing.Point(74, 79);
            this.txtAccuracy.Name = "txtAccuracy";
            this.txtAccuracy.ReadOnly = true;
            this.txtAccuracy.Size = new System.Drawing.Size(80, 21);
            this.txtAccuracy.TabIndex = 19;
            // 
            // txtAppClass
            // 
            this.txtAppClass.BackColor = System.Drawing.Color.White;
            this.txtAppClass.Location = new System.Drawing.Point(74, 52);
            this.txtAppClass.Name = "txtAppClass";
            this.txtAppClass.ReadOnly = true;
            this.txtAppClass.Size = new System.Drawing.Size(80, 21);
            this.txtAppClass.TabIndex = 17;
            // 
            // lblLesesAccuracy
            // 
            this.lblLesesAccuracy.AutoSize = true;
            this.lblLesesAccuracy.Location = new System.Drawing.Point(9, 82);
            this.lblLesesAccuracy.Name = "lblLesesAccuracy";
            this.lblLesesAccuracy.Size = new System.Drawing.Size(59, 12);
            this.lblLesesAccuracy.TabIndex = 18;
            this.lblLesesAccuracy.Text = "Accuracy";
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.lblLesesAccuracy);
            this.grpOutput.Controls.Add(this.txtAppClass);
            this.grpOutput.Controls.Add(this.txtAccuracy);
            this.grpOutput.Controls.Add(this.lblClass);
            this.grpOutput.Location = new System.Drawing.Point(312, 12);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(160, 140);
            this.grpOutput.TabIndex = 15;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // lblAtrr1
            // 
            this.lblAtrr1.AutoSize = true;
            this.lblAtrr1.Location = new System.Drawing.Point(88, 28);
            this.lblAtrr1.Name = "lblAtrr1";
            this.lblAtrr1.Size = new System.Drawing.Size(46, 12);
            this.lblAtrr1.TabIndex = 1;
            this.lblAtrr1.Text = "Gender";
            // 
            // lblAtrr2
            // 
            this.lblAtrr2.AutoSize = true;
            this.lblAtrr2.Location = new System.Drawing.Point(98, 53);
            this.lblAtrr2.Name = "lblAtrr2";
            this.lblAtrr2.Size = new System.Drawing.Size(34, 12);
            this.lblAtrr2.TabIndex = 3;
            this.lblAtrr2.Text = "Time";
            // 
            // lblAtrr3
            // 
            this.lblAtrr3.AutoSize = true;
            this.lblAtrr3.Location = new System.Drawing.Point(95, 79);
            this.lblAtrr3.Name = "lblAtrr3";
            this.lblAtrr3.Size = new System.Drawing.Size(37, 12);
            this.lblAtrr3.TabIndex = 5;
            this.lblAtrr3.Text = "Place";
            // 
            // cmbAttr1
            // 
            this.cmbAttr1.FormattingEnabled = true;
            this.cmbAttr1.Location = new System.Drawing.Point(138, 24);
            this.cmbAttr1.Name = "cmbAttr1";
            this.cmbAttr1.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr1.TabIndex = 2;
            // 
            // cmbAttr4
            // 
            this.cmbAttr4.FormattingEnabled = true;
            this.cmbAttr4.Location = new System.Drawing.Point(138, 102);
            this.cmbAttr4.Name = "cmbAttr4";
            this.cmbAttr4.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr4.TabIndex = 8;
            // 
            // lblAtrr4
            // 
            this.lblAtrr4.AutoSize = true;
            this.lblAtrr4.Location = new System.Drawing.Point(85, 105);
            this.lblAtrr4.Name = "lblAtrr4";
            this.lblAtrr4.Size = new System.Drawing.Size(47, 12);
            this.lblAtrr4.TabIndex = 7;
            this.lblAtrr4.Text = "Holiday";
            // 
            // cmbAttr2
            // 
            this.cmbAttr2.FormattingEnabled = true;
            this.cmbAttr2.Location = new System.Drawing.Point(138, 50);
            this.cmbAttr2.Name = "cmbAttr2";
            this.cmbAttr2.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr2.TabIndex = 4;
            // 
            // cmbAttr3
            // 
            this.cmbAttr3.FormattingEnabled = true;
            this.cmbAttr3.Location = new System.Drawing.Point(138, 76);
            this.cmbAttr3.Name = "cmbAttr3";
            this.cmbAttr3.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr3.TabIndex = 6;
            // 
            // cmbAttr5
            // 
            this.cmbAttr5.FormattingEnabled = true;
            this.cmbAttr5.Location = new System.Drawing.Point(138, 128);
            this.cmbAttr5.Name = "cmbAttr5";
            this.cmbAttr5.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr5.TabIndex = 10;
            // 
            // lblAtrr5
            // 
            this.lblAtrr5.AutoSize = true;
            this.lblAtrr5.Location = new System.Drawing.Point(81, 131);
            this.lblAtrr5.Name = "lblAtrr5";
            this.lblAtrr5.Size = new System.Drawing.Size(53, 12);
            this.lblAtrr5.TabIndex = 9;
            this.lblAtrr5.Text = "FreeWifi ";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.lblAtrr7);
            this.grpInput.Controls.Add(this.cmbAttr7);
            this.grpInput.Controls.Add(this.cmbAttr6);
            this.grpInput.Controls.Add(this.lblAtrr6);
            this.grpInput.Controls.Add(this.lblAtrr5);
            this.grpInput.Controls.Add(this.cmbAttr5);
            this.grpInput.Controls.Add(this.cmbAttr3);
            this.grpInput.Controls.Add(this.cmbAttr2);
            this.grpInput.Controls.Add(this.lblAtrr4);
            this.grpInput.Controls.Add(this.cmbAttr4);
            this.grpInput.Controls.Add(this.cmbAttr1);
            this.grpInput.Controls.Add(this.lblAtrr3);
            this.grpInput.Controls.Add(this.lblAtrr2);
            this.grpInput.Controls.Add(this.lblAtrr1);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(294, 210);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Smartphone Application";
            // 
            // lblAtrr7
            // 
            this.lblAtrr7.AutoSize = true;
            this.lblAtrr7.Location = new System.Drawing.Point(48, 180);
            this.lblAtrr7.Name = "lblAtrr7";
            this.lblAtrr7.Size = new System.Drawing.Size(84, 12);
            this.lblAtrr7.TabIndex = 13;
            this.lblAtrr7.Text = "Data Remains";
            // 
            // cmbAttr7
            // 
            this.cmbAttr7.FormattingEnabled = true;
            this.cmbAttr7.Location = new System.Drawing.Point(138, 180);
            this.cmbAttr7.Name = "cmbAttr7";
            this.cmbAttr7.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr7.TabIndex = 14;
            // 
            // cmbAttr6
            // 
            this.cmbAttr6.FormattingEnabled = true;
            this.cmbAttr6.Location = new System.Drawing.Point(138, 154);
            this.cmbAttr6.Name = "cmbAttr6";
            this.cmbAttr6.Size = new System.Drawing.Size(150, 20);
            this.cmbAttr6.TabIndex = 12;
            // 
            // lblAtrr6
            // 
            this.lblAtrr6.AutoSize = true;
            this.lblAtrr6.Location = new System.Drawing.Point(34, 157);
            this.lblAtrr6.Name = "lblAtrr6";
            this.lblAtrr6.Size = new System.Drawing.Size(98, 12);
            this.lblAtrr6.TabIndex = 11;
            this.lblAtrr6.Text = "Battery Remains";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Location = new System.Drawing.Point(12, 228);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(607, 50);
            this.txtResult.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 286);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpAlgorithm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpInput);
            this.Name = "MainForm";
            this.Text = "DataMining";
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.RadioButton radCoveringAlgorithm;
        private System.Windows.Forms.RadioButton radDecisionTree;
        private System.Windows.Forms.RadioButton radNaiveBayesian;
        private System.Windows.Forms.RadioButton radOneRule;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtAccuracy;
        private System.Windows.Forms.TextBox txtAppClass;
        private System.Windows.Forms.Label lblLesesAccuracy;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Label lblAtrr1;
        private System.Windows.Forms.Label lblAtrr2;
        private System.Windows.Forms.Label lblAtrr3;
        private System.Windows.Forms.ComboBox cmbAttr1;
        private System.Windows.Forms.ComboBox cmbAttr4;
        private System.Windows.Forms.Label lblAtrr4;
        private System.Windows.Forms.ComboBox cmbAttr2;
        private System.Windows.Forms.ComboBox cmbAttr3;
        private System.Windows.Forms.ComboBox cmbAttr5;
        private System.Windows.Forms.Label lblAtrr5;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblAtrr7;
        private System.Windows.Forms.ComboBox cmbAttr7;
        private System.Windows.Forms.ComboBox cmbAttr6;
        private System.Windows.Forms.Label lblAtrr6;
        private System.Windows.Forms.TextBox txtResult;
    }
}

