using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class RandomGraph
    {
        private IGraph G;
        private bool[] visited;
        RandomQueue<int> queue = new RandomQueue<int>();
        private MyList<int> list = new MyList<int>();

        public RandomGraph(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];

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
                list.Add(v);

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

        public MyList<int> GetList()
        {
            return list;
        }
    }
}
