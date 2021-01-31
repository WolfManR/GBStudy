using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Task5
{
    class Program
    {
        private const string TempFile = "tasks.json";
        private static ToDo _todo;
        private static readonly StringBuilder Buffer = new ();
        
        static void Main(string[] args)
        {
            _todo = ToDo.Load(TempFile);

            var isWorkDone = false;
            do
            {
                RefreshTasks();
                
                WriteLine(
@"Input number if you wanna set task as Done, 
if you wana add new task input it's name and press enter, 
press Esc to exit");
                
                do
                {
                    var inputKey = ReadKey();
                    
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        isWorkDone = true;
                        break;
                    }
                    
                    // handle moving horizontally, deleting char's

                    if (inputKey.Key == ConsoleKey.Enter)
                        break;
                    
                    Buffer.Append(inputKey.KeyChar);
                } while (true);

                if (Buffer.Length <= 0) continue;
                
                var temp = Buffer.ToString();
                if (int.TryParse(temp, out var index))
                {
                    try
                    {
                        _todo.SetTaskAsDone(index);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        _todo.AddTask(temp);
                    }
                }
                else _todo.AddTask(temp);
                    
                RefreshTasks();
                Buffer.Clear();


            } while (!isWorkDone);
            
            _todo.Save(TempFile);
        }

        private static void RefreshTasks()
        {
            Clear();
            PrintTasks(_todo.GetTasks());
        }

        private static void PrintTasks(IEnumerable<string> tasks)
        {
            foreach (var task in tasks)
                WriteLine(task);
        }
    }
}