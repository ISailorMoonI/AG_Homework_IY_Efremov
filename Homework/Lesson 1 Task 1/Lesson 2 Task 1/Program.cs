using System;
using System.Collections.Generic;
using System.Collections;

namespace Lesson_2_Task_1
{
    class Program
    {
        public class Node : LinkedList
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
                var newNode = new Node { Value = value};

                if (startNode == null)
                {
                    startNode = newNode;
                    lastNode = newNode;
                    return;
                }
                newNode.PrevNode = lastNode;
                lastNode.NextNode = newNode;
                lastNode = newNode;
                count++;
            }
            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };
                var nextItem = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode = nextItem;
                newNode.PrevNode = node;
                count++;
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
                return count;
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
                count--;
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
                count--;
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
            LinkedList List = new LinkedList();
            List.AddNode(80);
            List.AddNode(44);
            List.AddNode(55);
            List.AddNode(33);
            List.FindNode(80);
            List.AddNodeAfter(List.FindNode(55), 66);
            List.AddNodeAfter(List.FindNode(80), 23);
            List.AddNodeAfter(List.FindNode(66), 23);
            List.AddNodeAfter(List.FindNode(23), 11);
            List.FindNode(23);
            List.FindNode(11);
            List.RemoveNode(3);//remove by index
            List.RemoveNode(2);//remove by index
            List.RemoveNode(List.FindNode(80)); // remove by value
            List.RemoveNode(List.FindNode(11)); // remove by value
            List.RemoveNode(List.FindNode(23)); // remove by value
            List.GetCount();







        }
    }
}
