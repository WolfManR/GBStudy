using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Console;
namespace Tasker
{
    internal class Program
    {
        private const char Prefix = '-';
        private const string IncorrectArgsMsg = "Incorrect arguments line";
        private static void Main(string[] args)
        {
            HandleCommandLine(args);

            WriteLine("Work Done");
        }

        static void HandleCommandLine(string[] args)
        {
            if(args.Length == 0) return;
            
            List<(char, string)> pairs = new();
            for (var i = 0; i < args.Length; i++)
            {
                if(args[i].StartsWith(Prefix))
                    pairs.Add((args[i].TrimStart(Prefix)[0], null));
                else
                {
                    if (pairs.Count == 0)
                    {
                        WriteLine(IncorrectArgsMsg);
                        return;
                    }
                    var (key, value) = pairs.Last();
                    if (value is null)
                    {
                        pairs[^1] = (key,args[i]);
                    }
                    else
                    {
                        WriteLine(IncorrectArgsMsg);
                        return;
                    }
                }
            }
            

            try
            {
                foreach (var (arg, value) in pairs)
                {
                    switch (arg)
                    {
                        case 'h':
                            PrintHelp();
                            break;
                        case 'v' when value is not null && int.TryParse(value, out var pid):
                            PrintProcess(pid);
                            break;
                        case 'v' when value is not null:
                            PrintProcess(value);
                            break;
                        case 'v':
                            PrintProcesses();
                            break;
                        case 'k' when value is not null && int.TryParse(value, out var pid):
                            KillProcess(pid);
                            break;
                        case 'k' when value is not null:
                            KillProcess(value);
                            break;
                        default:
                            throw new ArgumentException(
                                $"Argument {arg} has incorrect command or incorrect value {value}");
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        
        
        private const int ProcessNameColumnSize = 50;
        private static readonly int Width = BufferWidth - 1;
        private static readonly string RowSeparator = new('-', Width);
        private const string ColumnShift = "     |";
        private static readonly int PidsColumnSize = Width - (ProcessNameColumnSize + ColumnShift.Length);
        
        private static void PrintHelp()
        {
            var help = $@"
-h              - help
-v              - print processes
-v [PID]        - print process with PID
-v [Name]       - print process with Name
-k [PID]        - shutdown process";
            WriteLine(help);
        }

        
        private static void PrintProcess(int pid)
        {
            var process = Process.GetProcessById(pid);
            PrintHeader();
            PrintRow(NormalizeName(process.ProcessName.AsSpan()),pid.ToString());
        }
        
        private static void PrintProcess(string name) => 
            PrintGroupedProcesses(GroupProcesses(Process.GetProcessesByName(name)));
        
        private static void PrintProcesses() =>
            PrintGroupedProcesses(GroupProcesses(Process.GetProcesses()));
        
        
        private static void KillProcess(int pid)
        {
            try
            {
                Process.GetProcessById(pid).Kill(true);
            } catch { throw; }
        }
        
        private static void KillProcess(string name)
        {
            try
            {
                var processes = Process.GetProcessesByName(name);
                processes[0].Kill(true);
            } catch { throw; }
        }

        
        
        
        
        private static void PrintHeader()
        {
            // Header
            WriteLine($"{"Name",-ProcessNameColumnSize}{ColumnShift}PID");
            WriteLine(RowSeparator);
        }

        private static void PrintRow(string name, string pids)
        {
            // Row
            WriteLine($"{name,-ProcessNameColumnSize}{ColumnShift}{pids}" );
            WriteLine(RowSeparator);
        }
        
        private static string NormalizeName(ReadOnlySpan<char> name) => 
            (name.Length > ProcessNameColumnSize ? name.Slice(0,ProcessNameColumnSize) : name).ToString();
        
        private static string NormalizePIDs(IReadOnlyList<int> pids)
        {
            var linePids = pids.Count == 1 ? pids[0].ToString() : string.Join(", ", pids);
            if (linePids.Length > PidsColumnSize) linePids = linePids[..PidsColumnSize];
            return linePids;
        }
        
        
        private static void PrintGroupedProcesses(Dictionary<string, List<int>> processes)
        {
            PrintHeader();
            foreach (var (key, pids) in processes)
                PrintRow(NormalizeName(key.AsSpan()),NormalizePIDs(pids));
        }

        private static Dictionary<string, List<int>> GroupProcesses(IReadOnlyList<Process> processes)
        {
            Dictionary<string, List<int>> groups = new();
            for (var i = 0; i < processes.Count; i++)
            {
                var current = processes[i];
                var name = current.ProcessName;
                if (groups.ContainsKey(name))
                    groups[name].Add(current.Id);
                else groups.Add(name,new (new []{current.Id}));
            }

            return groups;
        }
    }
}