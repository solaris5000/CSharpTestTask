using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpTestTask
{
    public partial class Form1 : Form
    {

        private void generate_tasks()
        {
            var rand = new Random();
            this.tasks_completed = rand.Next(0, 100);
            this.tasks_pending = rand.Next(0, 100);
            this.tasks_jeopardy = rand.Next(0, 100);

            labelCompleted.Text = "Completed " + this.tasks_completed.ToString();
            labeljeopardy.Text = "Pending " + this.tasks_pending.ToString();
            labelpending.Text = "Jeopardy " + this.tasks_jeopardy.ToString();
        }
        public Form1()
        {
            InitializeComponent();


            this.second_bar_y = 70;
            this.button1.Location = new System.Drawing.Point(this.panel6.Width - 200, second_bar_y-this.button1.Size.Height/6);

            this.CompletedIcon.Location = new System.Drawing.Point(10, second_bar_y);
            this.labelCompleted.Location = new System.Drawing.Point(this.CompletedIcon.Location.X+30, second_bar_y);
            

            
            this.JeopardyIcon.Location = new System.Drawing.Point(130, second_bar_y);
            this.labeljeopardy.Location = new System.Drawing.Point(this.JeopardyIcon.Location.X+30, second_bar_y);

            
            this.PendingIcon.Location = new System.Drawing.Point(250, second_bar_y);
            this.labelpending.Location = new System.Drawing.Point(this.PendingIcon.Location.X+30, second_bar_y);


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate_tasks();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Generate_Schedule_pressed;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Generate_Schedule_hover;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Generate_Schedule;


        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Generate_Schedule;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Generate_Schedule_hover;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            day_left_percentage = 1.00D - (TimeSpan.FromDays(1) + (DateTime.Today - DateTime.Now)).TotalDays;
            this.Refresh();
        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 4);
            Pen darkGrayPen = new Pen(Color.DarkGray, 4);
            Pen grayPen = new Pen(Color.Gray, 4);

            SolidBrush darkGrayBrush = new SolidBrush(Color.DarkGray);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush lightGrayBrush = new SolidBrush(Color.LightGray);

            var topBar = new Rectangle(0, 0, this.Size.Width, 60);
            var midBar = new Rectangle(0, 60, this.Size.Width, 40);
            var botBar = new Rectangle(0, 100, this.Size.Width, this.Size.Height-100);

            e.Graphics.FillRectangle(darkGrayBrush, topBar);
            e.Graphics.FillRectangle(lightGrayBrush, midBar);
            e.Graphics.FillRectangle(grayBrush, botBar);
            int x = (int)(this.Size.Width * this.day_left_percentage);
            int X1 = x, Y1 = 0, X2 = x, Y2 = this.Size.Height;
            e.Graphics.DrawLine(blackPen, X1, Y1, X2, Y2);

            blackPen.Dispose();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.button1.Location = new Point(this.Size.Width - 200, this.button1.Location.Y);
            this.panel6.Size = new Size(this.Size.Width, this.Size.Height);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
