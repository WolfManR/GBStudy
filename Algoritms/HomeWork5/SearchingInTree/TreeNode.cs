namespace SearchingInTree
{
    public class TreeNode
    {
        public TreeNode(int value) => Value = value;
        public int Value { get; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}