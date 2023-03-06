using System;
using System.Numerics;
using System.Threading;

namespace PathMove
{
    class Program
    {
        public static float Time { get; set; }
        private static float _maxDistance = 0.5f;
        private static float _divide = 5.0f;

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
                if(!action1Finished)
                {
                    Action1();
                }

                System.Console.WriteLine($"Game loop thread, seconds: {timeCounter}");
            }
            System.Console.WriteLine("Exit game loop");
        }

        static bool action1Finished = false;
        static void Action1()
        {
                Vector2 dirvector = GetDirectionVector(obj.X, obj.Y, target.X, target.Y);
                System.Console.WriteLine($"Direction vector is: {dirvector}");

                if(dirvector.X < _maxDistance && dirvector.Y < _maxDistance)
                {
                    System.Console.WriteLine($"Finish move, steps: {timeCounter}");
                    action1Finished = true;
                    return;
                }
                
                Vector2 moveVector = GetMoveVector(dirvector);
                obj.X += moveVector.X;
                obj.Y += moveVector.Y;
                System.Console.WriteLine($"Obj position is: {obj}");
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

        private static Vector2 GetMoveVector(Vector2 directionVector)
        {
            var moveVector = Vector2.Normalize(directionVector);
            moveVector = moveVector / _divide;
            System.Console.WriteLine($"Move vector is: {moveVector}");
            return moveVector;
        }

        private static Vector2 GetDirectionVector(float x1, float y1, float x2, float y2)
        {
            return new Vector2
            (
                x2 - x1,
                y2 - y1
            );
        }
    }

    

    public class Obj
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override string ToString()
        {
            return $"<{X} {Y}>";
        }
    }

    public struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
}
