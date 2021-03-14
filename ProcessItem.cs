using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    public enum ProcessPriority { Low, Medium, High};

    class ProcessItem
    {
        private int _pid;

        private DateTime _creationTime;

        private ProcessPriority _processPriority;

        public ProcessPriority ProcessPriority { get { return _processPriority; } }

        public int PID { get { return _pid; } }

        public DateTime CreationTime { get { return _creationTime;}}

        public ProcessItem(int pid, ProcessPriority processPriority)         
        {
            _pid = pid;

            _processPriority = processPriority;

            _creationTime = DateTime.Now;
        
        }

        public void Kill() {
            Console.WriteLine(String.Format("Killed process PID:{0,3} with priority:{1,-6} created:{2} ms:{3}", _pid, _processPriority.ToString(), _creationTime, _creationTime.ToString("ffff")));
        }

        internal void WriteInfo()
        {
            Console.WriteLine(String.Format("Process PID:{0,3} with priority:{1,-6} created:{2} ms:{3}", _pid, _processPriority.ToString(), _creationTime, _creationTime.ToString("ffff")));
        }
    }
}
