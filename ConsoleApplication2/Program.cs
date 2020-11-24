using System;

namespace ConsoleApplication2
{
    internal class Program
    {
    
    
        private static int MinimumDistance(int[] distance, bool[] shortestPath, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;
 
            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPath[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
 
            return minIndex;
        }

        public static int[] Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPath = new bool[verticesCount];
 
            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPath[i] = false;
            }
 
            distance[source] = 0;
 
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPath, verticesCount);
                shortestPath[u] = true;
 
                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPath[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            return distance;
            
        }
        
        public static void Main(string[] args)
        {
            int[,] graph =  {
                { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
            };
 
            var dist = Dijkstra(graph, 3, 9);
            
            Console.WriteLine("Вершина    Расстояние от источника");
 
            for (int i = 0; i < dist.Length; ++i)
                Console.WriteLine("{0}\t  {1}", i, dist[i]);
        }
    }
}