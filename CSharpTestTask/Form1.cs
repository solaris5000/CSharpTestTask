using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CSharpTestTask
{

    public partial class Form1 : Form
    {

        private void generate_tasks()
        {
            this.tasks_completed = 0;
            this.tasks_pending = 0;
            this.tasks_jeopardy = 0;

            for (int i = 0; i < 500; i++)
            {
                Task temp = new Task();

                if (temp.getStatus() == TaskStatus.Completed)
                {
                    tasks_completed++;
                }

                if (temp.getStatus() == TaskStatus.Jeopardy)
                {
                    tasks_jeopardy++;
                }

                if (temp.getStatus() == TaskStatus.Pending)
                {
                    tasks_pending++;
                }
                TasksTree.Insert(temp.getId(), temp);
            }

            foreach (var task in this.TasksTree)
            {
                task.Value.consoleOutput();
            }

            labelCompleted.Text = "Completed " + this.tasks_completed.ToString();
            labeljeopardy.Text = "Pending " + this.tasks_pending.ToString();
            labelpending.Text = "Jeopardy " + this.tasks_jeopardy.ToString();

            Task drop = new Task();
            drop.dropId();
        }
        public Form1()
        {
            InitializeComponent();


            this.second_bar_y = 70;
            this.button1.Location = new System.Drawing.Point(this.Width - 200, second_bar_y - this.button1.Size.Height / 6);

            this.CompletedIcon.Location = new System.Drawing.Point(10, second_bar_y);
            this.labelCompleted.Location = new System.Drawing.Point(this.CompletedIcon.Location.X + 30, second_bar_y);



            this.JeopardyIcon.Location = new System.Drawing.Point(130, second_bar_y);
            this.labeljeopardy.Location = new System.Drawing.Point(this.JeopardyIcon.Location.X + 30, second_bar_y);


            this.PendingIcon.Location = new System.Drawing.Point(250, second_bar_y);
            this.labelpending.Location = new System.Drawing.Point(this.PendingIcon.Location.X + 30, second_bar_y);


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


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.button1.Location = new Point(this.Size.Width - 200, this.button1.Location.Y);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 4);
            Pen darkGrayPen = new Pen(Color.DarkGray, 4);
            Pen grayPen = new Pen(Color.Gray, 4);

            SolidBrush darkGrayBrush = new SolidBrush(Color.DarkGray);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush lightGrayBrush = new SolidBrush(Color.LightGray);

            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush orangeBrush = new SolidBrush(Color.Orange);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            // Рисуем красиввенькие разделения экрана
            var topBar = new Rectangle(0, 0, this.Size.Width, 60);
            var midBar = new Rectangle(0, 60, this.Size.Width, 40);
            var botBar = new Rectangle(0, 100, this.Size.Width, this.Size.Height - 100);
            e.Graphics.FillRectangle(darkGrayBrush, topBar);
            e.Graphics.FillRectangle(lightGrayBrush, midBar);
            e.Graphics.FillRectangle(grayBrush, botBar);

            //  Рисуем сами таски
            foreach (var task in this.TasksTree)
            {
                var start_percent = (task.Value.getStartTime() - DateTime.Today).TotalDays;
                var end_percent = (task.Value.getEndTime() - DateTime.Today).TotalDays;
                var rand = new Random();

                //Console.WriteLine("Id " + task.Value.getId() + " start :  " + start_percent + " end " + end_percent);

                var x_x = this.Size.Width;
                var rect = new Rectangle((int)(this.Size.Width * start_percent), 200 + task.Value.getLayer() * 25, (int)(this.Size.Width * (end_percent - start_percent)), (int)(25 * drawscale));




                if (task.Value.getStatus() == TaskStatus.Completed)
                {
                    e.Graphics.FillRectangle(greenBrush, rect);
                }
                else if (task.Value.getStatus() == TaskStatus.Pending)
                {
                    e.Graphics.FillRectangle(orangeBrush, rect);
                }
                else
                {
                    e.Graphics.FillRectangle(redBrush, rect);
                }

                e.Graphics.DrawString(task.Value.getId().ToString(), drawFont, drawBrush, rect.X, rect.Y, drawFormat);
            }



            // Рисуем линию прогресса дня
            int x = (int)(this.Size.Width * this.day_left_percentage);
            int X1 = x, Y1 = 0, X2 = x, Y2 = this.Size.Height;
            e.Graphics.DrawLine(blackPen, X1, Y1, X2, Y2);

            blackPen.Dispose();
        }

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.drawscale = hScrollBar1.Value / 100.0;
        }
    }
}
