using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prog6
{
    class BinarySearchTree
    {
        public TreeNode Root { get; set; }
        private TreeNode current;

        public int Count { get; set; }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(int newNodeValue)
        {
            if (IsEmpty())
            {
                Root = new TreeNode {Value = newNodeValue};
                Count++;
            }
            if (Search(newNodeValue))
            {
                return;
            }
            current = Root;
            while (true)
            {
                if (newNodeValue < current.Value)
                {
                    current.LeftNodesCount++;
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode {Value = newNodeValue};
                        return;
                    }
                    current = current.Left;
                }
                else if (newNodeValue > current.Value)
                {
                    current.RightNodesCount++;
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode {Value = newNodeValue};
                        return;
                    }
                    current = current.Right;
                }
            }
        }

        public bool Search(int node)
        {
            current = Root;
            while (true)
            {
                if (current == null)
                {
                    return false;
                }
                if (current.Value == node)
                {
                    return true;
                }
                if (current.Value > node)
                {
                    current = current.Left;
                    continue;
                }
                if (current.Value < node)
                {
                    current = current.Right;
                }
            }
        }

        public bool IsBalanced(TreeNode node)
        {
            if (node == null) return true;
            return Math.Abs(node.LeftNodesCount - node.RightNodesCount) <= 1 && IsBalanced(node.Left) && IsBalanced(node.Right);
        }
    }
}
