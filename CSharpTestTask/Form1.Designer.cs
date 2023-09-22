using Bitlush;
using System;
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

        bool draw = false;

        double drawscale = 1.0D;

        private Bitlush.AvlTree<Int32, Task> TasksTree = new AvlTree<int, Task>();


        int x_task_dispose = 0;
        int y_task_dispose = 0;
        int x_scale = 24;

        Pen blackPen = new Pen(Color.Black, 4);
        Pen darkGrayPen = new Pen(Color.DarkGray, 4);
        Pen grayPen = new Pen(Color.Gray, 4);

        SolidBrush darkGrayBrush = new SolidBrush(Color.DarkGray);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        SolidBrush lightGrayBrush = new SolidBrush(Color.LightGray);

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush opacityBrush = new SolidBrush(Color.FromArgb(100, 170, 170, 170));


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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tasksXBar = new System.Windows.Forms.HScrollBar();
            this.tasksYBar = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.BackgroundImage = global::CSharpTestTask.Properties.Resources.Generate_Schedule;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(661, 39);
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
            this.CompletedIcon.Location = new System.Drawing.Point(12, 41);
            this.CompletedIcon.Name = "CompletedIcon";
            this.CompletedIcon.Size = new System.Drawing.Size(15, 15);
            this.CompletedIcon.TabIndex = 0;
            this.CompletedIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelpending
            // 
            this.labelpending.AutoSize = true;
            this.labelpending.Location = new System.Drawing.Point(254, 43);
            this.labelpending.Name = "labelpending";
            this.labelpending.Size = new System.Drawing.Size(25, 13);
            this.labelpending.TabIndex = 7;
            this.labelpending.Text = "123";
            // 
            // labeljeopardy
            // 
            this.labeljeopardy.AutoSize = true;
            this.labeljeopardy.Location = new System.Drawing.Point(144, 43);
            this.labeljeopardy.Name = "labeljeopardy";
            this.labeljeopardy.Size = new System.Drawing.Size(25, 13);
            this.labeljeopardy.TabIndex = 6;
            this.labeljeopardy.Text = "123";
            // 
            // labelCompleted
            // 
            this.labelCompleted.AutoSize = true;
            this.labelCompleted.Location = new System.Drawing.Point(33, 43);
            this.labelCompleted.Name = "labelCompleted";
            this.labelCompleted.Size = new System.Drawing.Size(25, 13);
            this.labelCompleted.TabIndex = 5;
            this.labelCompleted.Text = "123";
            // 
            // PendingIcon
            // 
            this.PendingIcon.BackgroundImage = global::CSharpTestTask.Properties.Resources.Completed;
            this.PendingIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PendingIcon.Location = new System.Drawing.Point(233, 41);
            this.PendingIcon.Name = "PendingIcon";
            this.PendingIcon.Size = new System.Drawing.Size(15, 15);
            this.PendingIcon.TabIndex = 4;
            // 
            // JeopardyIcon
            // 
            this.JeopardyIcon.BackgroundImage = global::CSharpTestTask.Properties.Resources.Completed;
            this.JeopardyIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.JeopardyIcon.Location = new System.Drawing.Point(123, 41);
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
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(287, 0);
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(392, 30);
            this.hScrollBar1.TabIndex = 8;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // tasksXBar
            // 
            this.tasksXBar.LargeChange = 1;
            this.tasksXBar.Location = new System.Drawing.Point(0, 430);
            this.tasksXBar.Maximum = 23;
            this.tasksXBar.Name = "tasksXBar";
            this.tasksXBar.Size = new System.Drawing.Size(772, 20);
            this.tasksXBar.TabIndex = 9;
            this.tasksXBar.Value = 1;
            this.tasksXBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tasksXBar_Scroll);
            // 
            // tasksYBar
            // 
            this.tasksYBar.Location = new System.Drawing.Point(762, 95);
            this.tasksYBar.Name = "tasksYBar";
            this.tasksYBar.Size = new System.Drawing.Size(20, 333);
            this.tasksYBar.TabIndex = 10;
            this.tasksYBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tasksYBar);
            this.Controls.Add(this.tasksXBar);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.labelpending);
            this.Controls.Add(this.CompletedIcon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labeljeopardy);
            this.Controls.Add(this.labelCompleted);
            this.Controls.Add(this.JeopardyIcon);
            this.Controls.Add(this.PendingIcon);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Form1_Scroll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.HScrollBar tasksXBar;
        private System.Windows.Forms.VScrollBar tasksYBar;
        private System.Windows.Forms.Label label1;
    }
}

