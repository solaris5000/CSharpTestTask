using Bitlush;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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
        DateTime dttemp = DateTime.Today;
        private void generate_tasks()
        {
            this.tasks_completed = 0;
            this.tasks_pending = 0;
            this.tasks_jeopardy = 0;

            if (TasksTree.Count() > 0)
            {

                TasksTree = new AvlTree<DateTime, Task>();
            }

            for (int i = 0; i < 50; i++)
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

                if (temp.getEndTime() > dttemp)
                {
                    dttemp = temp.getEndTime();
                }
                TasksTree.Insert(temp.getStartTime(), temp);
                
            }

            labelCompleted.Text = "Completed " + this.tasks_completed.ToString();
            labeljeopardy.Text = "Pending " + this.tasks_pending.ToString();
            labelpending.Text = "Jeopardy " + this.tasks_jeopardy.ToString();

            Task drop = new Task();
            drop.dropId();

            cutOffStartDT = TasksTree.First().Value.getStartTime();

            cutOffEndDT = dttemp;

            //cutOffEndDT = TasksTree.Last().Value.getEndTime();
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
            topBar.Size = new Size(this.Size.Width, 60);
            midBar.Size = new Size(this.Size.Width, 40);
            botBar.Size = new Size(this.Size.Width, this.Size.Height - 100);

            tasksXBar.Location = new System.Drawing.Point(0, this.Height - 56);
            tasksXBar.Width = this.Width - 35;
            tasksYBar.Location = new System.Drawing.Point(this.Width - 35, tasksYBar.Location.Y);
            tasksYBar.Height = this.Height - 156;

            var taskYBarHeight = (25 * 21) - (this.Height - 156);
            if (taskYBarHeight <= 0)
            {
                tasksYBar.Visible = false;
                tasksYBar.Value = 0;
            }
            else
            {
                tasksYBar.Visible = true;
                tasksYBar.Maximum = taskYBarHeight + 25;
            }
            
            this.button1.Location = new Point(this.Size.Width - 200, this.button1.Location.Y);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelCompleted.BackColor = System.Drawing.Color.Transparent;
            labeljeopardy.BackColor = System.Drawing.Color.Transparent;
            labelpending.BackColor = System.Drawing.Color.Transparent;
            button1.BackColor = System.Drawing.Color.Transparent;
            CompletedIcon.BackColor = System.Drawing.Color.Transparent;
            PendingIcon.BackColor = System.Drawing.Color.Transparent;
            JeopardyIcon.BackColor = System.Drawing.Color.Transparent;

            labelCompleted.Text = "Completed " + this.tasks_completed.ToString();
            labeljeopardy.Text = "Pending " + this.tasks_pending.ToString();
            labelpending.Text = "Jeopardy " + this.tasks_jeopardy.ToString();

            topBar = new Rectangle(0, 0, this.Size.Width, 60);
            midBar = new Rectangle(0, 60, this.Size.Width, 40);
            botBar = new Rectangle(0, 100, this.Size.Width, this.Size.Height - 100);


                

            tasksYBar.Height = this.Height - 156;
            this.DoubleBuffered = true;

            tasksXBar.Location = new System.Drawing.Point(0, this.Height - 56);
            tasksXBar.Width = this.Width - 35;
            tasksYBar.Location = new System.Drawing.Point(this.Width - 35, 100);
            tasksYBar.Height = this.Height - 156;

            var taskYBarHeight = (25 * 21) - (this.Height - 156);
            if (taskYBarHeight <= 0)
            {
                tasksYBar.Visible = false;
                tasksYBar.Value = 0;
            }
            else
            {
                tasksYBar.Visible = true;
                tasksYBar.Maximum = taskYBarHeight + 25;
            }
            tasksXBar.Maximum = x_scale * 20;
            this.button1.Location = new Point(this.Size.Width - 200, this.button1.Location.Y);

            var xbarmax = (int)(x_scale / 2) * 50;
            if (xbarmax == 0)
            {
                tasksXBar.Maximum = 1;
                tasksXBar.Value = 0;
                tasksXBar.Enabled = false;
            }
            else
            {
                tasksXBar.Maximum = xbarmax;
                tasksXBar.Enabled = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();




            int render_w = this.Size.Width;

            //Откуда и докуда рисовать трафик надо
            if (TasksTree.Count() != 0)
            {
                //cutOffStartDT = TasksTree.First().Value.getStartTime();

                //cutOffEndDT = TasksTree.Last().Value.getEndTime();
                label2.Text = cutOffStartDT.ToString() + " " + TasksTree.Last().Value.getEndTime();
            }
            double displace_to_left = (cutOffStartDT - DateTime.Today).TotalSeconds / TimeSpan.FromDays(1).TotalSeconds;
            TimeSpan renderTime = cutOffEndDT - cutOffStartDT;
            double timeBasedScale = TimeSpan.FromDays(1).TotalSeconds / (cutOffEndDT - cutOffStartDT).TotalSeconds;
            
            
            //double x_scale = this.x_scale * timeBasedScale;
            
            
            label1.Text = displace_to_left.ToString() + " | " + timeBasedScale.ToString();

            // Рисуем поле для тасков
            e.Graphics.FillRectangle(grayBrush, botBar);
            e.Graphics.DrawRectangle(borderPen, botBar);
            // Рисуем меню сверху
            e.Graphics.FillRectangle(darkGrayBrush, topBar);
            e.Graphics.DrawRectangle(borderPen, topBar);

            int rowlines_start = 100 - 15;
            int rowlines_y = 0;
            //Рисуем серенько-тёмносерые полосочки
            for (int row = 0; true; row++)
            {
                if (row > 20)
                {
                    break;
                }

                rowlines_y = rowlines_start + row * TASK_ROW_HEIGHT - tasksYBar.Value;
                if (rowlines_y < rowlines_start)
                {
                    continue;
                }

                if (row % 2 == 0)
                {
                    e.Graphics.DrawLine(taskBackgroundPenDark,
                        0,
                        rowlines_y,
                        this.Width,
                        rowlines_y);
                } else
                {
                    e.Graphics.DrawLine(taskBackgroundPenLight,
                        0,
                        rowlines_y,
                        this.Width,
                        rowlines_y);
                }
            }


            // Рисуем временную разметку наверху и на поле тасков.
            var tl_j = 0;
            var tl_x = 0;
            
                for (int i = 0; i < 24; i++)
                {
                    tl_x = (int)((
                    (this.Width / 24.0D) * i * x_scale * timeBasedScale) - 
                    ((this.Width / tasksXBar.Maximum) * tasksXBar.Value) * x_scale * timeBasedScale - 
                    (displace_to_left*this.Width) * x_scale * timeBasedScale);


                    if (tl_x > this.Width)
                    {
                        break;
                    }
                    e.Graphics.DrawLine(darkSlateGrayPen,
                        tl_x,
                        0,
                        tl_x,
                        this.Height);
                    e.Graphics.DrawString(
                            i.ToString(),
                            drawFont, drawBrush, tl_x + 5, 15, drawFormat);

                    tl_j = (int)(((
                    ((this.Width / 24.0D) * (i + 1) * x_scale * timeBasedScale) - 
                    ((this.Width / tasksXBar.Maximum) * tasksXBar.Value) * x_scale * timeBasedScale - 
                    (displace_to_left * this.Width) * x_scale * timeBasedScale) - tl_x) / 2);

                    if (tl_x + tl_j / 2 + tl_j < 0)
                    {
                        continue;
                    }
                    // Каждые 30 минут
                    e.Graphics.DrawLine(darkSlateGrayPen,
                            tl_j + tl_x,
                            30,
                            tl_j + tl_x ,
                            60);

                    // Каждые 15-45 минут


                    e.Graphics.DrawLine(darkSlateGrayPen,
                            tl_x + tl_j / 2,
                            45,
                            tl_x + tl_j / 2,
                            60);
                    // Каждые 15-45 минут
                    e.Graphics.DrawLine(darkSlateGrayPen,
                            tl_x + tl_j / 2 + tl_j,
                            45,
                            tl_x + tl_j / 2 + tl_j,
                            60);
                }


                //  Рисуем сами таски
                foreach (var task in this.TasksTree)
            {
                // Пропускаем рендер таски, если данный ресурс не в нужно время
                /*if (task.Value.getEndTime() < current_hour_view || task.Value.getStartTime() > current_hour_view)
                {
                    continue;
                }*/

                var start_percent = (task.Value.getStartTime() - DateTime.Today).TotalDays;
                var end_percent = (task.Value.getEndTime() - DateTime.Today).TotalDays;
                var rand = new Random();

                //Console.WriteLine("Id " + task.Value.getId() + " start :  " + start_percent + " end " + end_percent);

                var x_x = this.Size.Width;
                //var rect = new Rectangle((int)(this.Size.Width * start_percent) - (this.Width / x_scale) * (x_scale - tasksXBar.Value), 200 + task.Value.getLayer() * 25, (int)(this.Size.Width * (end_percent - start_percent)), (int)(25 * drawscale));
                taskRectangle.Location = new Point(
                /*x*/(int)(
                (this.Width * start_percent * x_scale * timeBasedScale) 
                - ((this.Width / tasksXBar.Maximum) * tasksXBar.Value) * x_scale * timeBasedScale
                - (int)(displace_to_left * this.Width) * x_scale * timeBasedScale),
                //(int)(this.Size.Width * start_percent) - (this.Size.Width / x_scale) * tasksXBar.Value + 50,
                /*y*/    100 - 30 + task.Value.getLayer() * TASK_ROW_HEIGHT - tasksYBar.Value + 2);

                taskRectangle.Width = (int)(this.Size.Width * (end_percent - start_percent) * x_scale * timeBasedScale);
                taskRectangle.Height = (int)(TASK_ROW_HEIGHT * drawscale-2);

                if (!(
                    (taskRectangle.Location.X >= 0 && taskRectangle.Location.X < this.Width) || 
                    (taskRectangle.Location.X + taskRectangle.Width >= 0)))
                {
                    continue;
                }

                if (taskRectangle.Location.Y < 100 - 25)
                {
                    continue;
                }
                
                if (task.Value.isEnabled()) {
                    if (task.Value.getStatus() == TaskStatus.Completed)
                    {
                        e.Graphics.FillRectangle(completedBrush, taskRectangle);
                    }
                    else if (task.Value.getStatus() == TaskStatus.Pending)
                    {
                        e.Graphics.FillRectangle(orangeBrush, taskRectangle);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(redBrush, taskRectangle);
                    }
                } else
                {
                    e.Graphics.FillRectangle(opacityBrush, taskRectangle);
                }
                e.Graphics.DrawRectangle(borderPen, taskRectangle);
                if (taskRectangle.X > 0)
                {
                    e.Graphics.DrawString(
                        task.Value.getStartTime().TimeOfDay.ToString() + " | " + task.Value.getEndTime().TimeOfDay.ToString() +  
                        " X = " + taskRectangle.X.ToString() + "| X + W = "+ (taskRectangle.X + taskRectangle.Width).ToString(),
                        drawFont, drawBrush, taskRectangle.X, taskRectangle.Y, drawFormat);
                }
                else
                {
                    e.Graphics.DrawString(
                        task.Value.getStartTime().TimeOfDay.ToString() + " | " + task.Value.getEndTime().TimeOfDay.ToString() + 
                        " X = " + taskRectangle.X.ToString() + "| X + W = " + (taskRectangle.X + taskRectangle.Width).ToString(),
                        drawFont, drawBrush, 50, taskRectangle.Y, drawFormat);
                }
            }

            
            

            // рисуем среднюю менюшку, чтобы она перекрывала чот
            e.Graphics.FillRectangle(lightGrayBrush, midBar);
            e.Graphics.DrawRectangle(borderPen, midBar);
            
            //label1.Text = "View near " + current_hour_view + " hrs | x_scale = " + x_scale;
            // Рисуем линию прогресса дня
            int x = (int)(
                (this.Width * this.day_left_percentage * x_scale * timeBasedScale) - 
                ((this.Width / tasksXBar.Maximum) * tasksXBar.Value) * x_scale * timeBasedScale - 
                (int)(displace_to_left * this.Width) * x_scale * timeBasedScale);
            //int x = (int)(this.Size.Width * this.day_left_percentage) - (this.Width / x_scale) * tasksXBar.Value;
            int X1 = x, Y1 = 0, X2 = x, Y2 = this.Size.Height;
            e.Graphics.DrawLine(blackPen, X1, Y1, X2, Y2);
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
/*
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.drawscale = hScrollBar1.Value / 100.0;
        }
*/
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void tasksXBar_Scroll(object sender, ScrollEventArgs e)
        {
            //x_task_dispose = tasksXBar.Value;

            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool doubled = false; 
            if (e.KeyChar == '+')
            {
                if (x_scale < 32)
                {
                    x_scale*=2;
                    doubled = true;
                }
            }

            if (e.KeyChar == '-')
            {
                if (x_scale > 1)
                {
                    x_scale/=2;
                }
                
            }

            var xbarmax = (int)(x_scale / 2) * 50;
            if (xbarmax == 0)
            {
                tasksXBar.Maximum = 1;
                tasksXBar.Value = 0;
                tasksXBar.Enabled = false; 
            }else
            {
                tasksXBar.Maximum = xbarmax;
                tasksXBar.Enabled = true;
                if (doubled)
                {
                    tasksXBar.Value *= 2;
                } else
                {
                    tasksXBar.Value /= 2;
                }
            }
                

            tasksXBar.Invalidate();
            Console.WriteLine(e.KeyChar.ToString() + " " + x_scale + " " + tasksXBar.Maximum);
        }
    }
}
