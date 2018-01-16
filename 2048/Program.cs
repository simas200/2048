using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static int[,] board = new int[4, 4];
        public static int Score { get; set; }
        private static char play = 'Y';
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;
            getNew();
            getNew();
                Drawing.draw(board, Score);
                keyInfo = Console.ReadKey();
                bool moveDone = false;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        move(eDirection.Up);
                        moveDone = true;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        move(eDirection.Down);
                        moveDone = true;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        move(eDirection.Left);
                        moveDone = true;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        move(eDirection.Right);
                        moveDone = true;
                        break;
                }
                try
                {
                    if (moveDone)
                    {
                        getNew();
                    }
                }
                catch (GameOverException)
                {
                    Drawing.gameOverScreen(Score);                    
                }
        }

        static void move(eDirection direction)
        {
            int[] temp = new int[4];
            int j;
            IEnumerable<int> tempEnu;
            for(int i = 0; i < 4; i++)
            {
                switch (direction)
                {
                    case eDirection.Down:
                        j = 3;
                        tempEnu = sum(new int[4] { board[3, i], board[2, i], board[1, i], board[0, i] });
                        for(int k = 0; k < 4; k++)
                        {
                            board[k,i] = 0;
                        }
                        foreach (int h in tempEnu)
                        {
                            board[j, i] = h;
                            j--;
                        }
                        break;
                    case eDirection.Up:
                        j = 0;
                        tempEnu = sum(new int[4] { board[0, i], board[1, i], board[2, i], board[3, i] });
                        for (int k = 0; k < 4; k++)
                        {
                            board[k, i] = 0;
                        }
                        foreach (int h in tempEnu)
                        {
                            board[j, i] = h;
                            j++;
                        }
                        break;
                    case eDirection.Left:
                        j = 0;
                        tempEnu = sum(new int[4] { board[i, 0], board[i, 1], board[i, 2], board[i, 3] });
                        for (int k = 0; k < 4; k++)
                        {
                            board[i, k] = 0;
                        }
                        foreach (int h in tempEnu)
                        {
                            board[i, j] = h;
                            j++;
                        }
                        break;
                    case eDirection.Right:
                        j = 3;
                        tempEnu = sum(new int[4] { board[i, 3], board[i, 2], board[i, 1], board[i, 0] });
                        for (int k = 0; k < 4; k++)
                        {
                            board[i, k] = 0;
                        }
                        foreach (int h in tempEnu)
                        {
                            board[i, j] = h;
                            j--;
                        }
                        break;
                }
                
            }
        }

        private static void getNew()
        {
            int count = 0;
            foreach(int i in board)
            {
                if(i != 0)
                {
                    count++;
                }
            }
            if(count == 16)
            {
                throw new GameOverException();
            }
            bool found = false;
            Random random = new Random();
            while (!found) {
                int i = random.Next(16);
                if (board[i/4, i%4] == 0)
                {
                    int j = random.Next(16);
                    if (j > 12)
                    {
                        board[i / 4, i % 4] = 4;
                    }
                    else
                    {
                        board[i / 4, i % 4] = 2;
                    }
                    found = true;
                }
            }

        }

        private static IEnumerable<int> sum(int[] v)
        {
            int current = v[0];
            List<int> res = new List<int>();
            for(int t = 1; t < v.Length; t++)
            {
                if ((v[t] == current)&&(v[t] != 0)&&(current != 0))
                {
                    res.Add(current * 2);
                    Score += current * 2;
                    current = 0;
                }
                else if((v[t] != current) && (v[t] != 0)&&(current != 0))
                {
                    res.Add(current);
                    current = v[t];
                }
                else if(current == 0)
                {
                    current = v[t];
                }
            }
            if(current != 0)
            {
                res.Add(current);
            }
            return res;
        }
    }

    enum eDirection
    {
        Up, Down, Left, Right
    };
}
