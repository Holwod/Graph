using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    //QuickFind
    class UnionFind1:IUF
    {
        private int[] id;

        public UnionFind1(int size)
        {
            id = new int[size];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public int GetSize()
        {
            return id.Length;
        }

        //查找顶点p所在集合 O（1）
        private int Find(int p)
        {
            return id[p];
        }

        //查看顶点p，q是否相连接 O（1）
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        //合并p，q 所在集合 O（n）
        public void Union(int p, int q)
        {
            int pId=Find(p);
            int qId=Find(q);

            if (pId == qId) return;

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                    id[i] = qId;
            }
        }
    }
}
