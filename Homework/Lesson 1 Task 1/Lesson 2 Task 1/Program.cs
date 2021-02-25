using System;
using System.Collections.Generic;
using System.Collections;

namespace Lesson_2_Task_1
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }
        public class LinkedList : ILinkedList
        {
            public Node startNode { get; set; }
            public Node lastNode { get; set; }
            public int count = 0;

            public void AddNode(int value)
            {
                var node = startNode;

                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }

                var newNode = new Node { Value = value };
                node.NextNode = newNode;


            }

            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };
                var nextItem = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode = nextItem;
            }

            public Node FindNode(int searchValue)
            {
                var currentNode = startNode;

                while (currentNode != null)
                {
                    if (currentNode.Value == searchValue)
                        return currentNode;

                    currentNode = currentNode.NextNode;
                }

                return null; // если ничего не нашли, то null

            }


            public int GetCount()
            {
                throw new NotImplementedException();
            }

            public void RemoveNode(int index)
            {
                int currentIndex = 0;
                Node currentNode = startNode;
                while (true)
                    if (index == 0 && currentIndex == index)
                    {
                        Node nodeNextItem = currentNode.NextNode;
                        nodeNextItem.PrevNode = null;
                        currentNode.NextNode = null;
                        break;
                    }
                    else if (currentNode.NextNode == null && currentIndex == index)
                    {
                        Node nodePrevItem = currentNode.PrevNode;
                        nodePrevItem.NextNode = null;
                        currentNode.PrevNode = null;
                        break;
                    }
                    else if ( index == currentIndex)
                    {
                        Node nodePrevItem = currentNode.PrevNode;
                        Node nodeNextItem = currentNode.NextNode;
                        nodePrevItem.NextNode = nodeNextItem;
                        nodeNextItem.PrevNode = nodePrevItem;
                        currentNode.NextNode = null;
                        currentNode.PrevNode = null;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.NextNode;
                        currentIndex++;
                    }

                
                

                

            }

            public void RemoveNode(Node node)
            {
                if (node.NextNode == null)
                {
                    lastNode = node.PrevNode;
                    node.PrevNode.NextNode = null;
                }
                else if (node.PrevNode == null)
                {
                    startNode = node.NextNode;
                    node.NextNode.PrevNode = null;
                }
                else
                {
                    node.NextNode.PrevNode = node.PrevNode;
                    node.PrevNode.NextNode = node.NextNode;
                }
            }
        }


        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            /*int GetCount();*/ // возвращает количество элементов в списке
            public Node startNode { get; set; }
            public Node lastNode { get; set; }
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        static void Main(string[] args)
        {
            var node = new Node { Value = 10 };
            LinkedList List = new LinkedList();
            List.AddNodeAfter(node, 68);
            List.AddNode(641);

            
        }
    }
}
