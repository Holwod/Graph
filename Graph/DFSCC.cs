﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DFSCC
    {
        private IGraph G;
        private bool[] visited;
        private MyList<int> list = new MyList<int>();
        private int ccount=0;

        public DFSCC(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];

            for (int v = 0; v < G.V(); v++)
            {
                if (!visited[v])
                {
                    DFS(v);
                    ccount++;
                }        
            }

        }

        private void DFS(int v)
        {
            visited[v] = true;
            list.Add(v);
            foreach (int w in G.Adj(v))
            {
                if (!visited[w])
                    DFS(w);
            }
        }

        public MyList<int> GetList()
        {
            return list;
        }

        public int Components()
        {
            return ccount;
        }

    }
}
