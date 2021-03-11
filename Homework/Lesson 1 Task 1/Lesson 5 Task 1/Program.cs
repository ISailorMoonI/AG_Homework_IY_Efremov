using System;
using System.Collections.Generic;
using System.Collections;

namespace Lesson_5_Task_1
{
    class Program
    {
        public class TreeNode
        {
            private TreeNode rightNode;
            public TreeNode RightNode
            {
                get { return rightNode; }
                set { rightNode = value; }
            }//Right Child

            private TreeNode leftNode;
            public TreeNode LeftNode
            {
                get { return leftNode; }
                set { leftNode = value; }
            }//left Child
            private int data;
            public int Data { get; set; }

            private bool isDeleted;//soft delete variable
            public bool IsDeleted
            {
                get { return isDeleted; }
            }
            public void Delete()
            {
                isDeleted = true;
            }
            public TreeNode(int value)
            {
                data = value;
            }
            public TreeNode Root { get; set; }

            public void AddItem(int value)
            {
                if (value >= data)
                {
                    if (rightNode == null)
                    {
                        rightNode = new TreeNode(value);
                    }
                    else
                    {
                        rightNode.AddItem(value);
                    }
                }
                else
                {
                    if (leftNode == null)
                    {
                        leftNode = new TreeNode(value);
                    }
                    else
                    {
                        leftNode.AddItem(value);
                    }
                }
            }
            public TreeNode Find(int value)
            {
                TreeNode currentNode = this;
                while (currentNode != null)
                {
                    if (value == currentNode.data && isDeleted == false)
                    {
                        return currentNode;
                    }
                    else if (value > currentNode.data)
                    {
                        currentNode = currentNode.rightNode;
                    }
                    else
                    {
                        currentNode = currentNode.leftNode;
                    }
                }
                return null;
            }

            public TreeNode GetRoot()
            {
                throw new NotImplementedException();
            }

            public void PrintTree()
            {
                throw new NotImplementedException();
            }
            public void Remove(int value)
            {
                this.Root = Remove(this.Root, value);
            }

            private TreeNode Remove(TreeNode parent, int key)
            {
                if (parent == null) return parent;
                if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
                else if (key > parent.Data)
                    parent.RightNode = Remove(parent.RightNode, key);
                else
                {
                    if (parent.LeftNode == null)
                        return parent.RightNode;
                    else if (parent.RightNode == null)
                        return parent.LeftNode;

                    parent.Data = MinValue(parent.RightNode);
                    parent.RightNode = Remove(parent.RightNode, parent.Data);
                }
                return parent;
            }
            private int MinValue(TreeNode node)
            {
                int minv = node.Data;
                while (node.LeftNode != null)
                {
                    minv = node.LeftNode.Data;
                    node = node.LeftNode;
                }
                return minv;
            }

            public static class TreeHelper
            {
                public static NodeInfo[] GetTreeInLine(ITree tree)
                {
                    var bufer = new Queue<NodeInfo>();
                    var returnArray = new List<NodeInfo>();
                    var root = new NodeInfo() { Node = tree.GetRoot() };
                    bufer.Enqueue(root);

                    while (bufer.Count != 0)
                    {
                        var element = bufer.Dequeue();
                        returnArray.Add(element);

                        var depth = element.Depth + 1;

                        if (element.Node.LeftNode != null)
                        {
                            var left = new NodeInfo()
                            {
                                Node = element.Node.LeftNode,
                                Depth = depth,
                            };
                            bufer.Enqueue(left);
                        }
                        if (element.Node.RightNode != null)
                        {
                            var right = new NodeInfo()
                            {
                                Node = element.Node.RightNode,
                                Depth = depth,
                            };
                            bufer.Enqueue(right);
                        }
                    }

                    return returnArray.ToArray();
                }
            }

            public class NodeInfo
            {
                public int Depth { get; set; }
                public TreeNode Node { get; set; }
            }
        }
        public interface ITree
        {
            TreeNode GetRoot();
            void AddItem(int value); // добавить узел
            void Remove(int value); // удалить узел по значению
            TreeNode Find(int value); //получить узел дерева по значению
            void PrintTree(); //вывести дерево в консоль
        }


        public class BinaryTree
        {
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
