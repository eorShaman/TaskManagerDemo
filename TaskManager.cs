using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public enum ProcessListOrder { PID, Priority };
    class TaskManager
    {
        const int maxProcessesInList = 10;

        protected List<ProcessItem> _processList = new List<ProcessItem>();

        protected int _lastPID = 0; //Starting PID numbering with 1

        protected int GetNextPIDNumber()
        {

            _lastPID++;

            return _lastPID;
        }

        public bool Kill(int pid)
        {

            foreach (ProcessItem processItem in _processList)
            {
                if (pid == processItem.PID)
                {
                    processItem.Kill();

                    _processList.Remove(processItem);

                    return true;
                }

            }

            Console.Out.WriteLine(string.Format("Process PID:{0} does not exists", pid));

            return false;

        }

        public int KillAll()
        {

            int removedProcessCount = _processList.Count;

            for (int i = _processList.Count - 1; i >= 0; i--)
            {
                _processList[i].Kill();

                _processList.RemoveAt(i);
            }

            return removedProcessCount;
        }

        public int KillGroup(ProcessPriority processPriority)
        {

            int removedProcessCount = 0;

            for (int i = _processList.Count - 1; i >= 0; i--)
            {
                if (processPriority == _processList[i].ProcessPriority)
                {
                    _processList[i].Kill();

                    _processList.RemoveAt(i);

                    removedProcessCount++;
                }
            }

            if (removedProcessCount == 0)
            {
                Console.WriteLine("Processes with priority:{0} don't exists", processPriority.ToString());
            }

            return removedProcessCount;
        }

        public void List(ProcessListOrder processListOrder = ProcessListOrder.PID)
        {
            List<ProcessItem> processList = _processList;

            if (processListOrder == ProcessListOrder.Priority) {

                processList = _processList.OrderBy(o=>o.ProcessPriority).ToList();

            }

            if (processList.Count == 0)
            {

                Console.WriteLine("Process list is empty");

                return;
            }

            Console.WriteLine(String.Format("Process list [{0}]", processList.Count));


            foreach (ProcessItem processItem in processList)
            {

                processItem.WriteInfo();

            }

            Console.WriteLine("-");

        }

        protected bool ProcessListIsFull()
        {

            return _processList.Count == maxProcessesInList;
        }

        public virtual bool Add(ProcessItem processItem)
        {

            if (ProcessListIsFull())
            {
                Console.WriteLine("Can't add process. Process list is full");

                return false;
            }

            _processList.Add(processItem); 

            return true;

        }

        public ProcessItem CreateNewProcess(ProcessPriority processPriority)
        {
            ProcessItem processItem;

            int pid = GetNextPIDNumber();

            processItem = new ProcessItem(pid, processPriority);

            Console.WriteLine(String.Format("Created process PID:{0,3} with priority:{1,-6} created:{2} ms:{3}",
                processItem.PID,
                processItem.ProcessPriority.ToString(),
                processItem.CreationTime,
                processItem.CreationTime.ToString("ffff")));

            return processItem;
        }
    }
}
