using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class BFSCycleDetection
    {
        private IGraph G;
        private bool[] visited;
        Queue<int> queue = new Queue<int>();
        private int[] pre;
        private bool hasCycle = false;


        public BFSCycleDetection(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];
            pre = new int[G.V()];
            for (int i = 0; i < pre.Length; i++)
                pre[i] = -1;


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
                        pre[w] = v;
                        visited[w] = true;
                        queue.Enqueue(w);
                    }
                    else if (w != pre[v])
                        hasCycle = true;
                }
            }
        }

        public bool HasCycle()
        {
            return hasCycle;
        }
    }
}
