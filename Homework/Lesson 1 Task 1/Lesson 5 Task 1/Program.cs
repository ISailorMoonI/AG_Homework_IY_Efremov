using System;
using System.Collections.Generic;
using System.Collections;

namespace Lesson_5_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new MyBinaryTree();

            binaryTree.AddItem(50);
            binaryTree.AddItem(33);
            binaryTree.AddItem(64);
            binaryTree.AddItem(11);
            binaryTree.AddItem(10);
            binaryTree.AddItem(42);
            binaryTree.AddItem(52);

            var getRoot = binaryTree.GetRoot();

            binaryTree.PrintTree();

            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();
        }
    }
}
