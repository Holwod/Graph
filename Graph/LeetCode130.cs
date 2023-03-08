using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class LeetCode130
    {
        private int R;
        private int C;
        private char[][] board;
        private bool[,] visited;
        private int[,] dirs = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        public void Solve(char[][] board)
        {
            R = board.Length;
            C = board[0].Length;
            this.board = board;
            visited = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                if (!visited[i, 0] && board[i][0] == 'O')
                    DFS(i, 0);
                if (!visited[i, R-1] && board[i][R - 1] == 'O')
                    DFS(i, R - 1);
            }

            for (int j = 0; j < C; j++)
            {
                if (!visited[0, j] && board[0][j] == 'O')
                    DFS(0, j);
                if (!visited[R - 1, j] && board[R - 1][j] == 'O')
                    DFS(R - 1, j);
            }

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    else if (board[i][j] == '#')
                        board[i][j] = 'O';
                }
            }

        }

        private void DFS(int x, int y)
        {
            visited[x, y] = true;
            board[x][y] = '#';

            for (int d = 0; d < 4; d++)
            {
                int nextx = x + dirs[d, 0];
                int nexty = y + dirs[d, 1];

                if (InArea(nextx, nexty) && !visited[nextx, nexty] && board[nextx][nexty] == 'O')
                    DFS(nextx, nexty);
            }
        }

        private bool InArea(int x, int y)
        {
            return x >= 0 && x < R && y >= 0 && y < C;
        }
    }
}
