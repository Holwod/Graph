using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DFSGraphnr
    {
        private IGraph G;
        private bool[] visited;
        Stack<int> stack = new Stack<int>();
        private MyList<int> list = new MyList<int>();

        public DFSGraphnr(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];

            for (int v = 0; v < G.V(); v++)
            {
                if (!visited[v])
                {
                    DFSnr(v);
                }
                    
            }
        }


        private void DFSnr(int s)
        {
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                int v = stack.Pop();
                list.Add(v);

                foreach (int w in G.Adj(v))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        stack.Push(w);
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
