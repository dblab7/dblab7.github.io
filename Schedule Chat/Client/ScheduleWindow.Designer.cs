using Calendar.NET;

namespace Client
{
    partial class ScheduleWindow
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
            this.insert = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.calendar1 = new Calendar.NET.Calendar();
            this.myLabel = new System.Windows.Forms.Label();
            this.frLabel = new System.Windows.Forms.Label();
            this.myBox = new System.Windows.Forms.TextBox();
            this.frBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(266, 408);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 23);
            this.insert.TabIndex = 1;
            this.insert.Text = "새로고침";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.refresh_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(347, 408);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(75, 23);
            this.register.TabIndex = 2;
            this.register.Text = "일정등록";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = false;
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.BackColor = System.Drawing.Color.Transparent;
            this.calendar1.CalendarDate = new System.DateTime(2012, 4, 24, 13, 16, 0, 0);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = true;
            this.calendar1.Location = new System.Drawing.Point(14, 11);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(615, 409);
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // myLabel
            // 
            this.myLabel.AutoSize = true;
            this.myLabel.Location = new System.Drawing.Point(648, 161);
            this.myLabel.Name = "myLabel";
            this.myLabel.Size = new System.Drawing.Size(29, 12);
            this.myLabel.TabIndex = 4;
            this.myLabel.Text = "본인";
            // 
            // frLabel
            // 
            this.frLabel.AutoSize = true;
            this.frLabel.Location = new System.Drawing.Point(642, 258);
            this.frLabel.Name = "frLabel";
            this.frLabel.Size = new System.Drawing.Size(41, 12);
            this.frLabel.TabIndex = 5;
            this.frLabel.Text = "상대방";
            // 
            // myBox
            // 
            this.myBox.Location = new System.Drawing.Point(642, 179);
            this.myBox.Multiline = true;
            this.myBox.Name = "myBox";
            this.myBox.Size = new System.Drawing.Size(40, 40);
            this.myBox.TabIndex = 6;
            // 
            // frBox
            // 
            this.frBox.Location = new System.Drawing.Point(642, 276);
            this.frBox.Multiline = true;
            this.frBox.Name = "frBox";
            this.frBox.Size = new System.Drawing.Size(40, 40);
            this.frBox.TabIndex = 7;
            // 
            // ScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 439);
            this.Controls.Add(this.frBox);
            this.Controls.Add(this.myBox);
            this.Controls.Add(this.frLabel);
            this.Controls.Add(this.myLabel);
            this.Controls.Add(this.register);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.calendar1);
            this.Name = "ScheduleWindow";
            this.Text = "일정공유";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button register;
        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.Label myLabel;
        private System.Windows.Forms.Label frLabel;
        private System.Windows.Forms.TextBox myBox;
        private System.Windows.Forms.TextBox frBox;
    }
}


