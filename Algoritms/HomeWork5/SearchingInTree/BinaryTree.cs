namespace SearchingInTree
{
    public class BinaryTree
    {
        private TreeNode _root;
        
        public BinaryTree(params int[] values)
        {
            foreach (var t in values) AddItem(t);
        }

        public TreeNode GetRoot() => _root;

        private void AddItem(int value)
        {
            if (_root is null)
            {
                _root = new(value);
                return;
            }

            var tmp = _root;
            while (true)
            {
                if (value > tmp.Value)
                {
                    if (tmp.Right is not null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }

                    tmp.Right = new(value);
                    return;
                }

                if (value < tmp.Value)
                {
                    if (tmp.Left is not null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }

                    tmp.Left = new(value);
                    return;
                }

                if (value != tmp.Value) continue;
                break;
            }
        }
    }
}