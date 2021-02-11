using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task5
{
    internal class ToDo
    {
        private readonly List<ToDoTask> _todo;

        private ToDo(List<ToDoTask> todo = null) => _todo = todo ?? new ();

        
        internal IEnumerable<string> GetTasks()
        {
            for (var i = 0; i < _todo.Count; i++)
                yield return $"{i}. {_todo[i]}";
        }

        internal void AddTask(string title) => _todo.Add(new(title));
        internal void SetTaskAsDone(int index)
        {
            var currentTasksCount = _todo.Count;
            if (index < 0 || index > currentTasksCount)
                throw new IndexOutOfRangeException();
            _todo[index].Done();
        }

        
        internal static ToDo Load(string file)
        {
            if (!File.Exists(file)) return new();
            
            var json = File.ReadAllText(file);
            var tasks = JsonSerializer.Deserialize<List<ToDoTask>>(json);
            return new(tasks);
        }
        
        internal void Save(string file)
        {
            var tasks = JsonSerializer.Serialize(_todo, new (){WriteIndented = true});
            File.WriteAllText(file, tasks);
        }
    }
}