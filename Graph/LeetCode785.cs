using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class LeetCode785
    {
        private bool[] visited;
        private bool[] colors;
        private int[][] graph;
        private bool isBipartite = true;

        public bool IsBipartite(int[][] graph)
        {
            this.graph = graph;
            int V = graph.Length;
            visited = new bool[V];
            colors = new bool[V];

            for (int v = 0; v < V; v++)
            {
                if (!visited[v])
                {
                    DFS(v);
                }
            }

            return isBipartite;
        }

        private void DFS(int v)
        {
            visited[v] = true;
            foreach (var w in graph[v])
            {
                if (!visited[w])
                {
                    colors[w] = !colors[v];
                    DFS(w);
                }
                else if (colors[w] == colors[v])
                {
                    isBipartite = false;
                }
            }
        }

        static void Main(string[] args)
        {
            int[][] graph1 =
            {
                new int[]{1,2,3},
                new int[]{0,2},
                new int[]{0,1,3},
                new int[]{0,2},

            };

            int[][] graph2 =
            {
                new int[]{1,3},
                new int[]{0,2},
                new int[]{1,3},
                new int[]{0,2},

            };


            Console.WriteLine(new LeetCode785().IsBipartite(graph1));
            Console.WriteLine(new LeetCode785().IsBipartite(graph2));



            Console.Read();
        }

    }
}
