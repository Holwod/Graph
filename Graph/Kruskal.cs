using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Kruskal
    {
        private IGraph G;
        private MyList<Edge> list = new MyList<Edge>();

        public Kruskal(IGraph G)
        {
            this.G = G;

            DFSCC cc = new DFSCC(G);
            if (cc.Components() > 1) return;

            MyList<Edge> edges = new MyList<Edge>();
            for (int a = 0; a < G.V(); a++)
            {
                foreach (int b in G.Adj(a))
                {
                    if (a < b)
                        edges.Add(new Edge(a, b, ((AdjDictionary)G).GetWeight(a, b)));
                }
            }

            edges.Sort();

            IUF uf = new UnionFind2(G.V());
            foreach (Edge edge in edges)
            {
                int a = edge.GetA();
                int b = edge.GetB();
                if (!uf.IsConnected(a, b))
                {
                    list.Add(edge);
                    uf.Union(a, b);
                }
            }

        }

        public MyList<Edge> GetList()
        {
            return list;
        }
    }
}
