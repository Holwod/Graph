using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DFSSingleSourcePath
    {
        private IGraph G;
        private bool[] visited;
        private int s;
        private int[] pre;
        

        public DFSSingleSourcePath(IGraph G,int s)
        {
            this.G = G;
            this.s = s;
            visited = new bool[G.V()];
            pre = new int[G.V()];
            for (int i = 0; i < pre.Length; i++)
                pre[i] = -1;

            
           DFS(s);

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
            }
        }

        public bool IsConnectedTo(int t)
        {
            return visited[t];
        }

        public MyList<int> Path(int t)
        {
            MyList<int> res = new MyList<int>();
            if (!IsConnectedTo(t)) return res;

            int cur = t;
            while (cur != s)
            {
                res.Add(cur);
                cur = pre[cur];
            }
            res.Add(s);

            res.Reverse();

            return res;
        }

    }
}
