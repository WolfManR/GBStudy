namespace SearchingInTree
{
    public class TreeNode
    {
        public int Value { get; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        
        
        public TreeNode(int value) => Value = value;
    }
}