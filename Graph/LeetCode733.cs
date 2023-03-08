using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class LeetCode733
    {
        private int R;
        private int C;
        private int[][] image;
        private bool[,] visited;
        private int[,] dirs = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
        private int oldColor;

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            R = image.Length;
            C = image[0].Length;
            this.image = image;
            visited = new bool[R, C];
            oldColor=image[sr][sc];

            DFS(sr, sc, newColor);
            return image;

        }

        private void DFS(int x, int y, int newColor)
        {
            visited[x, y] = true;
            image[x][y] = newColor;

            for (int d = 0; d < 4; d++)
            {
                int nextx = x + dirs[d, 0];
                int nexty = y + dirs[d, 1];
                if(InArea(nextx,nexty) && !visited[nextx,nexty] && image[nextx][nexty] == oldColor)
                {
                    DFS(nextx, nexty, newColor);
                }
            }

        }

        private bool InArea(int x, int y)
        {
            return x >= 0 && x < R && y >= 0 && y < C;
        }
    }
}
