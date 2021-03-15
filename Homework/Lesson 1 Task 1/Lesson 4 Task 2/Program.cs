using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_Task_2
{

    class Program
    {
            static void Main(string[] args)
            {
            var binaryTree = new MyBinaryTree();

            binaryTree.AddItem(22);
            binaryTree.AddItem(45);
            binaryTree.AddItem(54);
            binaryTree.AddItem(34);
            binaryTree.AddItem(90);
            binaryTree.AddItem(11);
            binaryTree.AddItem(99);
            binaryTree.AddItem(1);
            binaryTree.AddItem(49);

            var findeNode = binaryTree.GetNodeByValue(80);

            binaryTree.RemoveItem(80);

            var getRoot = binaryTree.GetRoot();

            binaryTree.PrintTree();
        }

            
        
    }
}


