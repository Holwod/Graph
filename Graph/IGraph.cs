using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    interface IGraph
    {
        int V();
        int E();
        bool HasEdge(int a, int b);
        int Degree(int a);
        IEnumerable<int> Adj(int a);
    }
}
