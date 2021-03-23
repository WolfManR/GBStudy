namespace Graphs
{
    public class Edge
    {
        public bool IsTwoSideConnection { get; set; }
        public int Weight { get; set; }
        public Node Node { get; set; }

        public Edge(int weight, Node node, bool isTwoSideConnection = false )
        {
            IsTwoSideConnection = isTwoSideConnection;
            Weight = weight;
            Node = node;
        }
    }
}