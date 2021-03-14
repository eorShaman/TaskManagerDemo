using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    class TaskManagerFIFO : TaskManager
    {
        public override bool Add(ProcessItem processItem)
        {
            //FIFO: remove first (oldest) element if process list is full
            if (ProcessListIsFull())
            {
                _processList.RemoveAt(0);
            }

            _processList.Add(processItem);
            
            return true;
        }
    }
}
