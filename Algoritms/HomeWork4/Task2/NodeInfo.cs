namespace Task2
{
    public class NodeInfo
    {
        public int Depth { get; }
        public TreeNode Node { get; init; }
        
        public NodeInfo() { }
        public NodeInfo(int depth, TreeNode node)
        {
            Depth = depth;
            Node = node;
        }
        
        /// <inheritdoc />
        public override string ToString() => 
            $"{nameof(Depth)}: {Depth}, {nameof(Node)}: {Node}";
    }
}