using System.Numerics;
using System.Collections.Generic;

namespace PathMove
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
        private List<ITransformComponent> source = new List<ITransformComponent>()
        {
            new Point(0, 0),
            new Point(1, 1),
            new Point(1, 2)
        };

        IPathActor actor;

        public PathDirector(IPathActor actor)
        {
            this.actor = actor;
        }

        public void Initialize()
        {
            targetPositionIndex = 0;
            actor.InitializeMove(source[targetPositionIndex]);
        }

        public void UpdateDirection()
        {      
            targetPositionIndex++;
            if(targetPositionIndex < source.Count)
            {
                actor.InitializeMove(source[targetPositionIndex]);
            }
            else
            {
                actor.FinishMove();
            }
        }
    }
}