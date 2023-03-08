using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class LeetCode200
    {
        private int R;
        private int C;
        private char[][] grid;
        private bool[,] visited;
        private int count;
        private int[,] dirs = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };


        public int NumIslands(char[][] grid)
        {
            R = grid.Length;
            C = grid[0].Length;
            this.grid = grid;

            visited = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if(!visited[i,j] && grid[i][j] == '1')
                    {
                        DFS(i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS(int x, int y)
        {
            visited[x, y] = true;

            for (int d = 0; d < 4; d++)
            {
                int nextx = x + dirs[d, 0];
                int nexty = y + dirs[d, 1];
                if(InArea(nextx,nexty) && !visited[nextx,nexty] && grid[nextx][nexty] == '1')
                {
                    DFS(nextx, nexty);
                }
            }
        }

        private bool InArea(int x, int y)
        {
            return x >= 0 && x < R && y >= 0 && y < C;
        }
    }
}
