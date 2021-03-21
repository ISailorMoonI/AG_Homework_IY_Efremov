using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6_Task_1
{
    class clsGraph
    {
        private int Vertices;
        private List<Int32>[] adj;

        public clsGraph(int v)
        {
            Vertices = v;
            adj = new List<Int32>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<Int32>();
            }
        }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }
        void BFS(int s)
        {
            bool[] visited = new bool[Vertices];
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);
            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                Console.WriteLine("next->" + s);
                foreach (Int32 next in adj[s])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
        }
        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);
            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine("next->" + s);
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }

        public void PrintAdjacecnyMatrix()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in adj[i])
                {
                    s = s + (k + ",");
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                clsGraph graph = new clsGraph(16);
                graph.AddEdge(0, 1);
                graph.AddEdge(0, 2);
                graph.AddEdge(1, 2);
                graph.AddEdge(2, 0);
                graph.AddEdge(2, 3);
                graph.AddEdge(3, 3);
                graph.AddEdge(4, 2);
                graph.AddEdge(4, 3);
                graph.AddEdge(4, 4);
                graph.AddEdge(5, 4);
                graph.AddEdge(6, 4);
                graph.AddEdge(7, 1);
                graph.AddEdge(8, 0);
                graph.AddEdge(9, 5);
                graph.AddEdge(10, 9);
                graph.AddEdge(11, 2);
                graph.AddEdge(12, 5);
                graph.AddEdge(13, 10);
                graph.AddEdge(14, 10);
                graph.AddEdge(15, 4);

                graph.PrintAdjacecnyMatrix();

                Console.WriteLine("BFS traversal starting from vertex 10:");
                graph.BFS(10); // 10>9>5>4>2>3>0>1
                Console.WriteLine("BFS traversal starting from vertex 15:");
                graph.BFS(15); // 15>4>2>3>0>1
                Console.WriteLine("BFS traversal starting from vertex 7:");
                graph.BFS(7); // 7>1>2>0>3
                Console.WriteLine("BFS traversal starting from vertex 6:");
                graph.BFS(6); // 6>4>2>3>0>1
                Console.WriteLine("BFS traversal starting from vertex 8:");
                graph.BFS(8); // 8>0>1>2>3
                


                Console.WriteLine("DFS traversal starting from vertex 14:");
                graph.DFS(14); // 14>10>9>5>4>3>2>0>1
                Console.WriteLine("DFS traversal starting from vertex 9:");
                graph.DFS(9); // 9>5>4>3>2>0>1
                Console.WriteLine("DFS traversal starting from vertex 5:");
                graph.DFS(5); // 5>4>3>2>0>1
                Console.WriteLine("DFS traversal starting from vertex 13:");
                graph.DFS(13); // 13>10>9>5>4>3>2>0>1
                Console.WriteLine("DFS traversal starting from vertex 10:");
                graph.DFS(10); // 10>9>5>4>3>2>0>1
            }
        }
    }
}

