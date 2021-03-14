using System;

namespace TaskManager
{
    class TaskManagerPriority : TaskManager
    {
        public override bool Add(ProcessItem processItem)
        {
            int foundProcessAtIndex = -1;

            ProcessPriority currentProcessPriority = processItem.ProcessPriority;

            //Priority: if exists, remove oldest process that has lower priority when the process list is full
            if (ProcessListIsFull())
            {
                for (int i = _processList.Count - 1; i >= 0; i--)
                {
                    //List is ordered, so this will find oldest process with lowest priority
                    if (_processList[i].ProcessPriority <= currentProcessPriority)
                    {
                        foundProcessAtIndex = i;
                        currentProcessPriority = _processList[i].ProcessPriority;
                    }
                }
                //if currentProcessPriority is not lower than processPriority of the new process
                //we didnt find the process with lower priority
                if (currentProcessPriority == processItem.ProcessPriority)
                {
                    Console.WriteLine("Can't add process. Process list is full");
                    return false;
                }

                _processList[foundProcessAtIndex].Kill();

                _processList.RemoveAt(foundProcessAtIndex);
            }

            _processList.Add(processItem);

            return true;
        }
    }
}
