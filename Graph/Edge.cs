using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Edge :IComparable<Edge>
    {
        private int a;
        private int b;
        private int w;

        public Edge(int a,int b,int w)
        {
            this.a = a;
            this.b = b;
            this.w = w;
        }

        public int CompareTo(Edge other)
        {
            return this.w - other.w;
        }

        public int GetA()
        {
            return a;
        }

        public int GetB()
        {
            return b;
        }

        public int GetW()
        {
            return w;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1} : {2}", a, b, w);
        }
    }
}
