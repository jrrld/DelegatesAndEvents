﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();

            //Raise event
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if(del != null)
            {    
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }

        }
    }
}
