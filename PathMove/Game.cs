using System.Threading;

namespace PathMove
{
    public class Game
    {
        static int timeCounter = 0;
        public static int Time { get => timeCounter; }
        private Unit unit;
        private PathDirector pathDirector;

        public Game()
        {
            Initialize();
        }

        private void Initialize()
        {
            pathDirector = new PathDirector();

            unit = new Unit(pathDirector);
            unit.X = 0.0f;
            unit.Y = 0.0f;
            unit.Name = "John Cena";

            pathDirector.AttachActor(unit);
            pathDirector.Initialize();
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