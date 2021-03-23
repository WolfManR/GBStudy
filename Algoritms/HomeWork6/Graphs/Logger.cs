using System;

namespace Graphs
{
    public class Logger
    {
        private ConsoleColor infoColor = ConsoleColor.Green;
        private ConsoleColor edgeColor = ConsoleColor.DarkYellow;

        private ConsoleColor stepColor(Step step) =>
            step switch
            {
                Step.Check      => ConsoleColor.DarkBlue,
                Step.OuterCheck => ConsoleColor.DarkCyan
            };

        private ConsoleColor wayColor(Way way) =>
            way switch
            {
                Way.In  => ConsoleColor.Cyan,
                Way.Out => ConsoleColor.Yellow
            };

        private ConsoleColor visitColor(bool isVisit) => isVisit
            ? ConsoleColor.DarkGreen
            : ConsoleColor.Red;

        private ConsoleColor behaviorColor(Behavior behavior) =>
            behavior switch
            {
                Behavior.Enqueue => ConsoleColor.Magenta,
                Behavior.Dequeue => ConsoleColor.DarkRed
            };

        
        public void LogInfo(string message)
        {
            Header("info", infoColor);
            Console.WriteLine(message);
        }

        public void LogStep(Step step, int nodeValue, bool isVisited)
        {
            Header("step", ConsoleColor.Blue);
            Header($"{step}", stepColor(step));
            Header($"{isVisited.ToVisit()}", visitColor(isVisited));
            Console.WriteLine(nodeValue);
        }

        public void LogStep(Way way, string message = null)
        {
            Header("step", ConsoleColor.Blue);
            Header($"{way}", wayColor(way));
            Console.WriteLine(message ?? "");
        }

        public void LogStep(Step step, Edge edge)
        {
            Header("step", ConsoleColor.Blue);
            Header($"{step}", stepColor(step));
            Header("edge", edgeColor);
            Header($"{edge.Node.IsVisited.ToVisit()}", visitColor(edge.Node.IsVisited));
            Console.WriteLine($"Weight: {edge.Weight} --> Node: {edge.Node.Value}");
        }

        public void LogStep(Behavior behavior, int value)
        {
            Header("step", ConsoleColor.Blue);
            Header($"{behavior}", behaviorColor(behavior));
            Console.WriteLine($" with value {value}");
        }

        
        private void Header(string header, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"[{header.ToUpper()}]");
            Separator();
        }

        private void Separator()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" - ");
        }
    }
}