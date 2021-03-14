using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    class TaskManagerFIFO : TaskManager
    {
        public override bool Add(ProcessPriority processPriority)
        {
            //FIFO: remove first (oldest) element if process list is full
            if (ProcessListIsFull())
            {
                _processList.RemoveAt(0);
            }

            return AddNewProcess(processPriority);
        }
    }
}
