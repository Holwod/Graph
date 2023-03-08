using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {

       
        static void Main(string[] args)
        {
            AdjDictionary g = new AdjDictionary("带权图最短路径/g.txt");
            Dijkstra dijkstra = new Dijkstra(g, 0);

            for (int v = 0; v < g.V(); v++)
            {
                Console.Write(dijkstra.Disto(v) +" ");
            }


            Console.Read();
        }
    }
}
