using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Prim
    {
        private IGraph G;
        private MyList<Edge> list = new MyList<Edge>();
        private bool[] colors;

        public Prim(IGraph G)
        {
            this.G = G;

            DFSCC cc = new DFSCC(G);
            if (cc.Components() > 1) return;

            colors = new bool[G.V()];

            colors[0] = true;

            for (int i = 1; i < G.V(); i++)
            {

                Edge minEdge = new Edge(-1, -1, int.MaxValue);
                for (int a = 0; a < G.V(); a++)
                {
                    if (colors[a])
                    {
                        foreach (int b in G.Adj(a))
                        {
                            if (!colors[b] && ((AdjDictionary)G).GetWeight(a, b) < minEdge.GetW())
                                minEdge = new Edge(a, b, ((AdjDictionary)G).GetWeight(a, b));
                        }
                    }
                }

                list.Add(minEdge);
                colors[minEdge.GetA()] = true;
                colors[minEdge.GetB()] = true;

            }

        }

        public MyList<Edge> GetList()
        {
            return list;
        }
    }
}
