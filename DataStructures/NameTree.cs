using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriWeek.DataStructures
{
    /// <summary>
    /// Custom tree structure to allow very fast searching of food names
    /// </summary>
    public static class NameTree
    {
        static TreeNode Root = new TreeNode();
    }

    class TreeNode
    {
        char Value;
        TreeNode? Parent;
        List<TreeNode> Children = new List<TreeNode>();
        public TreeNode() { }
        public TreeNode(char value, TreeNode parent)
        {
            Value = value;
            Parent = parent;
        }
        void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }
}
