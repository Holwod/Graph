using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class BFSCC
    {
        private IGraph G;
        private bool[] visited;
        Queue<int> queue = new Queue<int>();
        private int cccount;


        public BFSCC(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];

            for (int v = 0; v < G.V(); v++)
            {
                if (!visited[v])
                {
                    BFS(v);
                    cccount++;
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
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public int Components()
        {
            return cccount;
        }
    }
}
