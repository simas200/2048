using System;

namespace _2048
{
    internal static class Drawing
    {
        private const string EDGE = " +====+====+====+====+";
        private const string LINE = " +----+----+----+----+";
        private const string BLANK = "||    |    |    |    ||";

        internal static void gameOverScreen(int score)
        {
            Console.WriteLine("Final score: " + score);
            Console.ReadLine();
            //Console.WriteLine("Want to play again?(Y/N)");
        }
        internal static void draw(int[,] board, int score)
        {
            Console.Clear();
            Console.WriteLine("Current score: " + score);
            Console.WriteLine(EDGE);
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(BLANK);
                Console.WriteLine("||{0,4}|{1,4}|{2,4}|{3,4}||", board[i, 0], board[i, 1], board[i, 2], board[i, 3]);
                Console.WriteLine(BLANK);
                Console.WriteLine(LINE);
            }
            Console.WriteLine(BLANK);
            Console.WriteLine("||{0,4}|{1,4}|{2,4}|{3,4}||", board[3, 0], board[3, 1], board[3, 2], board[3, 3]);
            Console.WriteLine(BLANK);
            Console.WriteLine(EDGE);

        } 
    }
}