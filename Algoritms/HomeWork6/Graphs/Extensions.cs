namespace Graphs
{
    public static class Extensions
    {
        public static string ToVisit(this bool self) => self ? "Visited" : "Not Visited";
    }
}