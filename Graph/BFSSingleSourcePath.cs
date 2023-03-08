using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class BFSSingleSourcePath
    {
        private IGraph G;
        private bool[] visited;
        Queue<int> queue = new Queue<int>();
        private int[] pre;
        private int s;
        private int[] dis;

        public BFSSingleSourcePath(IGraph G,int s)
        {
            this.G = G;
            this.s = s;
            visited = new bool[G.V()];
            pre = new int[G.V()];
            dis = new int[G.V()];

            for (int i = 0; i < pre.Length; i++)
            {
                pre[i] = -1;
                dis[i] = -1;
            }
                

           BFS(s);

        }


        private void BFS(int s)
        {
            visited[s] = true;
            queue.Enqueue(s);
            dis[s] = 0;
            while (queue.Count != 0)
            {
                int v = queue.Dequeue();

                foreach (int w in G.Adj(v))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        pre[w] = v;
                        dis[w] = dis[v] + 1;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public int Dis(int t)
        {
            return dis[t];
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
