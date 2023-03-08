using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DFSBipartitionDetection
    {
        private IGraph G;
        private bool[] visited;
        private bool[] colors;
        private bool isBipartite = true;


        public DFSBipartitionDetection(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];
            colors = new bool[G.V()];

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
                    colors[w] = !colors[v];
                    DFS(w);
                }
                else if (colors[w] == colors[v])
                {
                    isBipartite = false;
                }                  
            }
        }

        public bool IsBipartite()
        {
            return isBipartite;
        }

    }
}
