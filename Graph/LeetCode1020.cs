using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class LeetCode1020
    {
        private int R;
        private int C;
        private int[][] grid;
        private bool[,] visited;
        private int[,] dirs = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
        private int num;

        public int NumEnclaves(int[][] grid)
        {
            R = grid.Length;
            C = grid[0].Length;
            this.grid = grid;
            visited = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                if (!visited[i,0] && grid[i][0] == 1)
                    DFS(i, 0);
                if (!visited[i,C-1] && grid[i][C - 1] == 1)
                    DFS(i, C - 1);
            }

            for (int j = 0; j < C; j++)
            {
                if (!visited[0, j] && grid[0][j] == 1)
                    DFS(0, j);
                if (!visited[R - 1, j] && grid[R - 1][j] == 1)
                    DFS(R - 1, j);
            }

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    num += grid[i][j];
                }
            }

            return num;
        }

        private void DFS(int x, int y)
        {
            visited[x, y] = true;
            grid[x][y] = 0;

            for (int d = 0; d < 4; d++)
            {
                int nextx = x + dirs[d, 0];
                int nexty = y + dirs[d, 1];
                if(InArea(nextx,nexty) && !visited[nextx,nexty] && grid[nextx][nexty]==1)
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
