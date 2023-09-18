using System.Drawing;
using System.Threading.Tasks;

namespace CSharpTestTask
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected int tasks_jeopardy; 
        protected int tasks_completed; 
        protected int tasks_pending;
        protected double day_left_percentage;
        int second_bar_y;

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
            this.button1 = new System.Windows.Forms.Button();
            this.CompletedIcon = new System.Windows.Forms.Panel();
            this.labelpending = new System.Windows.Forms.Label();
            this.labeljeopardy = new System.Windows.Forms.Label();
            this.labelCompleted = new System.Windows.Forms.Label();
            this.PendingIcon = new System.Windows.Forms.Panel();
            this.JeopardyIcon = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.BackgroundImage = global::CSharpTestTask.Properties.Resources.Generate_Schedule;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(661, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 28);
            this.button1.TabIndex = 1;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // CompletedIcon
            // 
            this.CompletedIcon.BackgroundImage = global::CSharpTestTask.Properties.Resources.Completed;
            this.CompletedIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CompletedIcon.Location = new System.Drawing.Point(12, 17);
            this.CompletedIcon.Name = "CompletedIcon";
            this.CompletedIcon.Size = new System.Drawing.Size(15, 15);
            this.CompletedIcon.TabIndex = 0;
            this.CompletedIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelpending
            // 
            this.labelpending.AutoSize = true;
            this.labelpending.Location = new System.Drawing.Point(254, 19);
            this.labelpending.Name = "labelpending";
            this.labelpending.Size = new System.Drawing.Size(25, 13);
            this.labelpending.TabIndex = 7;
            this.labelpending.Text = "123";
            // 
            // labeljeopardy
            // 
            this.labeljeopardy.AutoSize = true;
            this.labeljeopardy.Location = new System.Drawing.Point(144, 19);
            this.labeljeopardy.Name = "labeljeopardy";
            this.labeljeopardy.Size = new System.Drawing.Size(25, 13);
            this.labeljeopardy.TabIndex = 6;
            this.labeljeopardy.Text = "123";
            // 
            // labelCompleted
            // 
            this.labelCompleted.AutoSize = true;
            this.labelCompleted.Location = new System.Drawing.Point(33, 19);
            this.labelCompleted.Name = "labelCompleted";
            this.labelCompleted.Size = new System.Drawing.Size(25, 13);
            this.labelCompleted.TabIndex = 5;
            this.labelCompleted.Text = "123";
            // 
            // PendingIcon
            // 
            this.PendingIcon.BackgroundImage = global::CSharpTestTask.Properties.Resources.Completed;
            this.PendingIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PendingIcon.Location = new System.Drawing.Point(233, 17);
            this.PendingIcon.Name = "PendingIcon";
            this.PendingIcon.Size = new System.Drawing.Size(15, 15);
            this.PendingIcon.TabIndex = 4;
            // 
            // JeopardyIcon
            // 
            this.JeopardyIcon.BackgroundImage = global::CSharpTestTask.Properties.Resources.Completed;
            this.JeopardyIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.JeopardyIcon.Location = new System.Drawing.Point(123, 17);
            this.JeopardyIcon.Name = "JeopardyIcon";
            this.JeopardyIcon.Size = new System.Drawing.Size(15, 15);
            this.JeopardyIcon.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelpending);
            this.panel6.Controls.Add(this.CompletedIcon);
            this.panel6.Controls.Add(this.labeljeopardy);
            this.panel6.Controls.Add(this.JeopardyIcon);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.PendingIcon);
            this.panel6.Controls.Add(this.labelCompleted);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(800, 450);
            this.panel6.TabIndex = 4;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel CompletedIcon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PendingIcon;
        private System.Windows.Forms.Panel JeopardyIcon;
        private System.Windows.Forms.Label labelpending;
        private System.Windows.Forms.Label labeljeopardy;
        private System.Windows.Forms.Label labelCompleted;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel6;
    }
}

