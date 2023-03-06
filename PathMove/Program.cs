using System;
using System.Numerics;
using System.Threading;

namespace PathMove
{
    class Program
    {
        public static float Time { get; set; }
        
        

        static void Main(string[] args)
        {
            Time = 0.0f;
            Initialize();

            Thread gameLoopThread = new Thread(new ThreadStart(GameLoop));
            gameLoopThread.Start();

            Thread inputExitThread = new Thread(new ThreadStart(ConsoleInputLoop));
            inputExitThread.Start();

            gameLoopThread.Join();
            inputExitThread.Join();
            System.Console.WriteLine("Exit game");
        }

        private static Point target;
        private static Unit unit;

        static void Initialize()
        {
            // Initialize here
            target = new Point() {X = 3.0f, Y = 3.0f};

            unit = new Unit(target) { X = 0.0f, Y = 0.0f };
            
            System.Console.WriteLine($"Unit position is: {unit}");
        }

        static int timeCounter = 0;

        static void GameLoop()
        {
            while(!exitCommand)
            {
                Thread.Sleep(100);
                timeCounter++;

                // Action here ...

                unit.Update(timeCounter);


                System.Console.WriteLine($"Game loop thread, seconds: {timeCounter}");
            }
            System.Console.WriteLine("Exit game loop");
        }



        static bool exitCommand = false;
        static void ConsoleInputLoop()
        {
            while(!exitCommand)
            {
                Thread.Sleep(50);
                //exitCommand = System.Console.ReadKey(intercept: true).Key == ConsoleKey.Escape;
            }
            System.Console.WriteLine("Exit console input thread");
        }


    }

}
