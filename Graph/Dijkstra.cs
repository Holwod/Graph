using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Dijkstra
    {
        private IGraph G;
        private int s;
        private int[] dis;
        private bool[] visited;

        public Dijkstra(IGraph G,int s)
        {
            this.G = G;
            this.s = s;
            dis = new int[G.V()];
            visited = new bool[G.V()];

            for (int i = 0; i < dis.Length; i++)
                dis[i] = int.MaxValue;

            dis[s] = 0;

            while (true)
            {

                int cur = -1;
                int curdis = int.MaxValue;

                for (int v = 0; v < G.V(); v++)
                {
                    if(!visited[v] && dis[v]< curdis)
                    {
                        curdis = dis[v];
                        cur = v;
                    }
                }

                if (cur == -1) break;

                visited[cur] = true;

                foreach (int w in G.Adj(cur))
                {
                    if (!visited[w])
                    {
                        if(dis[cur] + ((AdjDictionary)G).GetWeight(cur,w) < dis[w])
                        {
                            dis[w] = dis[cur] + ((AdjDictionary)G).GetWeight(cur, w);
                        }
                    }
                }

            }
        }

        public bool IsConnected(int v)
        {
            return visited[v];
        }

        public int Disto(int v)
        {
            return dis[v];
        }
    }
}
