using System;
using System.Numerics;
using System.Threading;

namespace PathMove
{
    class Program
    {
        public static float Time { get; set; }
        private static float _maxDistance = 0.5f;
        

        static void Main(string[] args)
        {
            Time = 0.0f;
            Initialize();

            Thread gameLoopThread = new Thread(new ThreadStart(GameLoop));
            gameLoopThread.Start();

            Thread inputExitThread = new Thread(new ThreadStart(ConsoleInputLoop));
            inputExitThread.Start();

            // Unit unit = new Unit();
            

            // for(int i = 0; i <= 150; i++)
            // {
            //     Time += i / 10;
            //     System.Console.WriteLine(Time);
            //     unit.Move();
            // }

            gameLoopThread.Join();
            inputExitThread.Join();
            System.Console.WriteLine("Exit game");
        }

        private static Obj obj;
        private static Point target;

        static void Initialize()
        {
            // Initialize here

            obj = new Obj() { X = 0.0f, Y = 0.0f};
            target = new Point() {X = 3.0f, Y = 3.0f};
            System.Console.WriteLine($"Obj position is: {obj}");
        }

        static int timeCounter = 0;

        static void GameLoop()
        {
            while(!exitCommand)
            {
                Thread.Sleep(100);
                timeCounter++;

                // Action here ...
                if(!moveActionFinished)
                {
                    MoveAction(obj, target);
                }

                System.Console.WriteLine($"Game loop thread, seconds: {timeCounter}");
            }
            System.Console.WriteLine("Exit game loop");
        }

        static bool moveActionFinished = false;
        static void MoveAction(ITransformComponent transform1, ITransformComponent transform2)
        {
                Vector2 dirvector = Vector2E.GetDirectionVector(transform1, transform2);
                System.Console.WriteLine($"Direction vector is: {dirvector}");

                if(dirvector.X < _maxDistance && dirvector.Y < _maxDistance)
                {
                    System.Console.WriteLine($"Finish move, steps: {timeCounter}");
                    moveActionFinished = true;
                    return;
                }
                
                Vector2 moveVector = Vector2E.GetMoveVector(dirvector);
                transform1.X += moveVector.X;
                transform1.Y += moveVector.Y;

                System.Console.WriteLine($"Obj position is: {transform1}");
                System.Console.WriteLine("------------------");
        }

        static bool exitCommand = false;
        static void ConsoleInputLoop()
        {
            while(!exitCommand)
            {
                Thread.Sleep(50);
                exitCommand = System.Console.ReadKey(intercept: true).Key == ConsoleKey.Escape;
            }
            System.Console.WriteLine("Exit console input thread");
        }


    }

}
