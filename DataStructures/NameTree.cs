using NutriWeek.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NutriWeek.DataStructures
{
    /// <summary>
    /// Custom tree structure to allow very fast searching of food names
    /// </summary>
    [Serializable]
    public class TreeNode
    {
        public string FoodName = "";
        public TreeNode Left = null;
        public TreeNode Middle = null;
        public TreeNode Right = null;
        public TreeNode Parent = null;
        public TreeNode Root = null;
        public TreeNode(String Name)
        {
            FoodName = Name;
        }
    }

    [Serializable]
    public class NameTree
    {
        public TreeNode Root = null;
        public void Insert(TreeNode Node)
        {
            if (Root == null)
            {
                Root = Node;
                Root.Parent = null;
                return;
            }

            TreeNode Cur = Root;

            while (Cur != null)
            {
                if (Node.FoodName[0].CompareTo(Cur.FoodName[0]) < 0)
                {
                    if (Cur.Left == null)
                    {
                        Cur.Left = Node;
                        Node.Parent = Cur;
                        Cur = null;
                    }
                    else
                    {
                        Cur = Cur.Left;
                    }
                }
                else if (Node.FoodName[0].CompareTo(Cur.FoodName[0]) > 0)
                {
                    if (Cur.Right == null)
                    {
                        Cur.Right = Node;
                        Node.Parent = Cur;
                        Cur = null;
                    }
                    else
                    {
                        Cur = Cur.Right;
                    }
                }
                else
                {
                    if (Cur.Middle == null)
                    {
                        Cur.Middle = Node;
                        Node.Parent = Cur;
                        Cur = null;
                    }
                    else
                    {
                        Cur = Cur.Middle;
                    }
                }
            }
        }
    }
}
