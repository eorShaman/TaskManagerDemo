using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {

            string menuTitle;
            TaskManager taskManager;

            Console.WriteLine("1:Task manager");
            Console.WriteLine("2:Task manager FIFO");
            Console.WriteLine("3:Task manager Priority");
            Console.Write("Choose number (default 1)? ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();

            switch (key.Key)
            {
                case ConsoleKey.D2:
                    taskManager = new TaskManagerFIFO();
                    menuTitle = "FIFO task manager";
                    break;
                case ConsoleKey.D3:
                    taskManager = new TaskManagerPriority();
                    menuTitle = "Priority task manager";
                    break;
                default:
                    taskManager = new TaskManager();
                    menuTitle = "Default task manager";
                    break;
            }

            do
            {
                Console.WriteLine(menuTitle);
                Console.WriteLine("1:Add process: Low priority");
                Console.WriteLine("2:Add process: Medium priority");
                Console.WriteLine("3:Add process: High priority");
                Console.WriteLine("4:List processes by ID");
                Console.WriteLine("5:Kill all processes");
                Console.WriteLine("6:Kill group: Low priority");
                Console.WriteLine("7:Kill group: Medium priority");
                Console.WriteLine("8:Kill group: High priority");
                Console.WriteLine("9:Kill PID");
                Console.WriteLine("0:List processes by priority");
                Console.WriteLine("<ESC> Close");
                key = Console.ReadKey(true);
                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        taskManager.Add(taskManager.CreateNewProcess(ProcessPriority.Low));
                        break;
                    case ConsoleKey.D2:
                        taskManager.Add(taskManager.CreateNewProcess(ProcessPriority.Medium));
                        break;
                    case ConsoleKey.D3:
                        taskManager.Add(taskManager.CreateNewProcess(ProcessPriority.High));
                        break;
                    case ConsoleKey.D4:
                        taskManager.List();
                        break;
                    case ConsoleKey.D5:
                        taskManager.KillAll();
                        break;
                    case ConsoleKey.D6:
                        taskManager.KillGroup(ProcessPriority.Low);
                        break;
                    case ConsoleKey.D7:
                        taskManager.KillGroup(ProcessPriority.Medium);
                        break;
                    case ConsoleKey.D8:
                        taskManager.KillGroup(ProcessPriority.High);
                        break;
                    case ConsoleKey.D9:
                        taskManager.List();
                        Console.Write("Kill PID number?");
                        string line = Console.ReadLine();
                        int pid;
                        if (Int32.TryParse(line, out pid))
                        {
                            taskManager.Kill(pid);
                        }
                        break;
                    case ConsoleKey.D0:
                        taskManager.List(ProcessListOrder.Priority);
                        break;
                    default:
                        break;
                };
                Console.Write("Press any key to continue.");
                Console.ReadKey(true);
                Console.Clear();
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
