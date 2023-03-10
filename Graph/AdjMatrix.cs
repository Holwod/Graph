using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class AdjMatrix:IGraph
    {
        private int v;
        private int e;
        private int[,] graph;

        public AdjMatrix(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] str=line.Split(' ');

            v = int.Parse(str[0]);
            e = int.Parse(str[1]);

            //空间复杂度 O（V*V）
            graph = new int[v, v];

            //建图时间复杂度 O（E）
            for (int i = 0; i < e; i++)
            {
                line = sr.ReadLine();
                str = line.Split(' ');
                int a = int.Parse(str[0]);
                int b = int.Parse(str[1]);
                graph[a, b] = 1;
                graph[b, a] = 1;
            }
            fs.Close();
            sr.Close();
        }

        public int V() { return v; }

        public int E() { return e; }

        //查看两点是否相邻 O（1）
        public bool HasEdge(int a,int b)
        {
            return graph[a, b] == 1;
        }

        //求一个点的相邻顶点 O（V）
        public IEnumerable<int> Adj(int a)
        {
            List<int> res = new List<int>();
            for (int b = 0; b < v; b++)
            {
                if (graph[a, b] == 1)
                    res.Add(b);
            }
            return res;
        }

        public int Degree(int a)
        {
            return ((List<int>)Adj(a)).Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("V = {0}, E={1}\n", v, e));
            for (int a = 0; a < v; a++)
            {
                for (int b = 0; b < v; b++)
                {
                    sb.Append(graph[a, b] + " ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
