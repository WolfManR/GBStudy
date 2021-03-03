namespace Task2
{
    public class TreeNode
    {
        public TreeNode(int value) => Value = value;
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

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