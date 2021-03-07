namespace Task2
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public int Balance { get; set; }
        
        public TreeNode(int value) => Value = value;
        
        public override bool Equals(object obj)
        {
            if (!(obj is TreeNode node))
                return false;

            return node.Value == Value;
        }
        
        /// <inheritdoc />
        public override string ToString() => $"{nameof(Value)}: {Value}";
    }
}