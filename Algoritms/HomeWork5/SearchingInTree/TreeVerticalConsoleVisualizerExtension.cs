using System.Text;

namespace SearchingInTree
{
    public static class TreeVerticalConsoleVisualizerExtension
    {
        private const string Cross = " ├─";
        private const string Corner = " └─";
        private const string Vertical = " │ ";
        private const string Space = "   ";
        private static readonly StringBuilder Builder = new();

        public static string AsString(this BinaryTree tree)
        {
            var root = tree.GetRoot();
            BuildLine(root,"");
            var result = Builder.ToString();
            Builder.Clear();
            return result;
        }

        private static void BuildLine(TreeNode node, string indent)
        {
            Builder.AppendLine(" " + node.Value);
            if (node.Left is not null)
                BuildChildPrefix(node.Left, indent, node.Right is null);

            if (node.Right is not null)
                BuildChildPrefix(node.Right, indent, true);
        }

        private static void BuildChildPrefix(TreeNode node, string indent, bool isLast)
        {
            Builder.Append(indent);

            if (isLast)
            {
                Builder.Append(Corner);
                indent += Space;
            }
            else
            {
                Builder.Append(Cross);
                indent += Vertical;
            }

            BuildLine(node, indent);
        }
    }
}