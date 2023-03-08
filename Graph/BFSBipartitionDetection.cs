using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class BFSBipartitionDetection
    {
        private IGraph G;
        private bool[] visited;
        Queue<int> queue = new Queue<int>();
        private bool[] colors;
        private bool isBipartite = true;


        public BFSBipartitionDetection(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];
            colors = new bool[G.V()];

            for (int v = 0; v < G.V(); v++)
            {
                if (!visited[v])
                {
                    BFS(v);
                }
                    
            }
        }


        private void BFS(int s)
        {
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                int v = queue.Dequeue();

                foreach (int w in G.Adj(v))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        colors[w] = !colors[v];
                        queue.Enqueue(w);
                    }
                    else if (colors[w] == colors[v])
                    {
                        isBipartite = false;
                    }
                }
            }
        }

        public bool IsBipartite()
        {
            return isBipartite;
        }

    }
}
