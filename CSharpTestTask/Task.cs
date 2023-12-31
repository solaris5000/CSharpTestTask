﻿using Bitlush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestTask
{
    enum TaskStatus
    {
        Pending,
        Jeopardy,
        Completed
    }

    class Task
    {
        private static Random random = new Random();
        private static Int32 idCounter = 1;

        private DateTime startTime;
        private DateTime endTime;
        private bool enabled;
        private TaskStatus status;
        private Int32 id;
        private int layer = random.Next(1, 21);

        public DateTime getStartTime() { return startTime; }
        public DateTime getEndTime() { return endTime; }
        public bool isEnabled() { return enabled; }
        public TaskStatus getStatus() { return status; }

        public Int32 getId() { return id; } 

        public void dropId() { idCounter = 1; }

        public int getLayer() { return layer; }

        public void consoleOutput()
        {
            Console.WriteLine(
                "ID: " + id +
                "\nStart: " + startTime +
                "\nEnd: " + endTime +
                "\nStatus: " + status +
                "\nEnabled? " + enabled
                );
        }

        public Task()
        {
            startTime = DateTime.Today.AddSeconds(random.Next(random.Next(0, 43000), 86000)); ;
            //startTime = DateTime.Today.AddDays(random.Next(0, 5)).AddSeconds(random.Next(1700, 86000));
            endTime = startTime.AddSeconds(random.Next(100, (int)(DateTime.Today.AddDays(1) - startTime).TotalSeconds) / 5);
            enabled = random.Next(0, 2) == 1;
            id = idCounter++;

            if (random.Next(0, 2) == 1)
            {
                status = TaskStatus.Completed;
            }
            else if (DateTime.Now < endTime)
            {
                status = TaskStatus.Pending;
            }
            else
            {
                status = TaskStatus.Jeopardy;
            }
        }

        ~Task()
        {
            //Console.WriteLine("Dropping task");
        }
    }
}
