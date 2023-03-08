using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    //QuickUnion
    class UnionFind2:IUF
    {
        private int[] parent;

        public UnionFind2(int size)
        {
            parent = new int[size];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
        }

        public int GetSize()
        {
            return parent.Length;
        }

        //查找顶点p所在集合 O（h）
        private int Find(int p)
        {
            while (p != parent[p])
            {
                p = parent[p];
            }
            return p;
        }

        //查看顶点p，q是否相连接 O（h）
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        //合并p，q 所在集合 O（h）
        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot) return;

            parent[pRoot] = qRoot;
        }
    }
}
