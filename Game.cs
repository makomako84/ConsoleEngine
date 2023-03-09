using System.Threading;

namespace ConsoleEngine
{
    public class Game
    {
        static int timeCounter = 0;
        public static int Time { get => timeCounter; }
        private Unit unit;
        private PathDirector pathDirector;
        private TestMessageController controller;
        private TestMessageController controller1;

        public Game()
        {
            Initialize();
        }

        private void Initialize()
        {
            // pathDirector = new PathDirector();

            // unit = new Unit(pathDirector);
            // unit.X = 0.0f;
            // unit.Y = 0.0f;
            // unit.Name = "John Cena";

            // pathDirector.AttachActor(unit);
            // pathDirector.Initialize();
            // System.Console.WriteLine($"Unit position is: {unit}");


            this.controller = new TestMessageController();
            controller.Name = "Test message controller1";
            controller.AddComponent(new TestMessageComponent1(controller, 3) {Name = "Uwawa"});

            this.controller1 = new TestMessageController();
            controller1.Name = "Test message controller 2";
            controller1.AddComponent(new TestMessageComponent1(controller1, 5) {Name = "lololo"});
            controller1.AddComponent(new TestMessageComponent2(controller1, 9, "some secret ") {Name = "chuwawa"});
            

        }

        public void GameLoop()
        {
            timeCounter++;
            // Action here ...

            // unit.Update(timeCounter);
            controller.Update();
            controller1.Update();
            

            System.Console.WriteLine($"Game loop thread, seconds: {timeCounter}");
        }
    }
}