namespace Task2
{
    public class TreeNode
    {
        public int Value { get; set; }
        
        #region Left

        private TreeNode _left;
        public TreeNode Left
        {
            get => _left;
            set
            {
                _left.Parent = null;
                _left = value;
                value.Parent = this;
            }
        }
        
        #endregion

        #region Right

        private TreeNode _right;
        public TreeNode Right
        {
            get => _right;
            set
            {
                _right.Parent = null;
                _right = value;
                value.Parent = this;
            }
        }
        
        #endregion

        public int Balance { get; set; }
        public TreeNode Parent { get; set; }
        
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