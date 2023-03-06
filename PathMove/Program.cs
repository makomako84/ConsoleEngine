using System;
using System.Numerics;
using System.Threading;

namespace PathMove
{
    class Program
    {
        private static bool exitCommand = false;

        public static bool ExitCommand {get => exitCommand;}

        private static Game game;

        static void Main(string[] args)
        {
            game = new Game();

            Thread inputExitThread = new Thread(new ThreadStart(ConsoleInputLoop));
            inputExitThread.Start();

            Thread gameLoopThread = new Thread(new ThreadStart(GameLoop));
            gameLoopThread.Start();

            gameLoopThread.Join();
            inputExitThread.Join(); 
            System.Console.WriteLine("Exit system");
        }


        static void ConsoleInputLoop()
        {
            while(!exitCommand)
            {
                Thread.Sleep(50);
                exitCommand = System.Console.ReadKey(intercept: true).Key == ConsoleKey.Escape;
            }
            System.Console.WriteLine("Exit console input thread");
        }

        static void GameLoop()
        {
            while(!Program.ExitCommand)
            {
                Thread.Sleep(100);
                game.GameLoop();
            }
            System.Console.WriteLine("Exit game");
        }
    }

}
