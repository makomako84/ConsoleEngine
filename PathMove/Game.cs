using System.Threading;

namespace PathMove
{
    public class Game
    {
        static int timeCounter = 0;
        public static int Time { get => timeCounter; }
        private  Point target;
        private Unit unit;

        public Game()
        {
            Initialize();
        }

        private void Initialize()
        {
            // Initialize here
            target = new Point() {X = 3.0f, Y = 3.0f};

            unit = new Unit(target) { X = 0.0f, Y = 0.0f };
            
            System.Console.WriteLine($"Unit position is: {unit}");
        }

        public void GameLoop()
        {
            timeCounter++;
            // Action here ...

            unit.Update(timeCounter);
            System.Console.WriteLine($"Game loop thread, seconds: {timeCounter}");
        }


    }
}