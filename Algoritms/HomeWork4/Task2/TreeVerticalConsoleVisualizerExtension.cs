using System.Text;

namespace Task2
{
    public static class TreeVerticalConsoleVisualizerExtension
    {
        private const string Cross = " ├─";
        private const string Corner = " └─";
        private const string Vertical = " │ ";
        private const string Space = "   ";
        private static readonly StringBuilder Builder = new();

        public static string AsString(this ITree tree)
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

            // Loop through the children recursively, passing in the
            // indent, and the isLast parameter
            if (node.Left is not null)
                BuildChildPrefix(node.Left, indent, node.Right is null);

            if (node.Right is not null)
                BuildChildPrefix(node.Right, indent, true);
        }

        private static void BuildChildPrefix(TreeNode node, string indent, bool isLast)
        {
            // Print the provided pipes/spaces indent
            Builder.Append(indent);

            // Depending if this node is a last child, print the
            // corner or cross, and calculate the indent that will
            // be passed to its children
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