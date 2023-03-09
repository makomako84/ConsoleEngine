using System.Numerics;
using System.Collections.Generic;

namespace ConsoleEngine
{
    /*
        Когда в Unit происходит событие Finished
        PathDirector в ответ на это событие
        Меняет цель для Unit.
        Причем именно для той компоненты, которая отвечает
        за перемещение (другие компоненты в данном случае не важны)
    */
    public class PathDirector : IPathDirector
    {
        private  int targetPositionIndex;
        private List<ITransformable> source = new List<ITransformable>()
        {
            new Point(0, 0) { Name = "Point1"},
            new Point(1, 1) { Name = "Point2"},
            new Point(1, 2) { Name = "Point3"},
            new Point(2, 4) { Name = "Point4"},
            new Point(5, 5) { Name = "Point5"}
        };

        IPathActor actor;


        public void Initialize()
        {
            targetPositionIndex = 0;
            actor.InitializeMove(source[targetPositionIndex]);
        }

        public void AttachActor(IPathActor actor)
        {
            this.actor = actor;
        }



        public void UpdateActorDirection()
        {      
            targetPositionIndex++;
            System.Console.WriteLine($"PathDirector.Update: targetPositionIndex: {targetPositionIndex}");
            if(targetPositionIndex < source.Count)
            {
                System.Console.WriteLine("SET NEW TARGET");
                actor.InitializeMove(source[targetPositionIndex]);
            }
            else
            {
                System.Console.WriteLine("FINISH MOVE");
                actor.FinishMove();
            }
        }
    }
}