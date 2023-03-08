using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DFSCycleDetection
    {
        private IGraph G;
        private bool[] visited;
        private int[] pre;
        private bool hasCycle;


        public DFSCycleDetection(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];
            pre = new int[G.V()];
            for (int i = 0; i < pre.Length; i++)
                pre[i] = -1;

            for (int v = 0; v < G.V(); v++)
                if (!visited[v])
                    DFS(v);

        }

        private void DFS(int v)
        {
            visited[v] = true;
            foreach (int w in G.Adj(v))
            {
                if (!visited[w])
                {
                    pre[w] = v;
                    DFS(w);
                }
                else if(w != pre[v])
                {
                    hasCycle = true;
                    break;
                }
                   
            }
        }

        public bool HasCycle()
        {
            return hasCycle;
        }
    }
}
