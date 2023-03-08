/*
    Некий исполнитель
    Что хочет этот исполнитель?
    Достичь данной ему точки.
    Вернее, исполнитель всего лишь движется.
    Это его компонента - двигаться.
*/

/*
    Unit просто движется по точке.
    А некий Director (PathMove)
    в данном случае управляет
    Движением юнита.
    Двигаться - это главное свойство юнита,
    его воля внутри трехмерного пространства.
*/

using System.Numerics;
using System.Collections.Generic;

namespace PathMove
{
    public class Unit : Entity, ITransformComponent, IPathActor
    {
        public float X { get; set; }
        public float Y { get; set; }


        private ITransformComponent target;
        private IPathDirector pathDirector;
        private PathActorState state;

        private float _maxDistance = 0.15f;



        public Unit(
            IPathDirector pathDirector)
        { 
            this.pathDirector = pathDirector;
            state = PathActorState.Wait;
        }

        /*
            Должно возникнуть некое событие - 
            движение закончилось.
        */
        public void Update(int timeCounter)
        {
            if(state == PathActorState.Move)
            {
                MoveAction(this, target, timeCounter);
            }
        }

        void MoveAction(ITransformComponent transform1, ITransformComponent transform2, int timeCounter)
        {
                Vector2 dirvector = Vector2E.GetDirectionVector(transform1, transform2);
                System.Console.WriteLine($"Direction vector is: {dirvector}");

                if(dirvector.X < _maxDistance && dirvector.Y < _maxDistance)
                {
                    state = PathActorState.Wait;
                    System.Console.WriteLine($"Finish move, steps: {timeCounter}");
                    System.Console.WriteLine($"State is: {state}");
                    System.Console.WriteLine("=======================");
                    PathFinishedNotify();
                    return;
                }
                
                Vector2 moveVector = Vector2E.GetMoveVector(dirvector);
                transform1.X += moveVector.X;
                transform1.Y += moveVector.Y;

                System.Console.WriteLine($"Obj position is: {transform1.X}, {transform1.Y}");
                System.Console.WriteLine($"Target position is: {transform2.X}, {transform2.Y}");
                System.Console.WriteLine($"Target name is: {(transform2 as Entity).Name}");
                System.Console.WriteLine($"State is: {state}");
                System.Console.WriteLine("------------------");
        }

#region IPathActor
        public void PathFinishedNotify()
        {
            pathDirector.UpdateActorDirection();
        }

        public void InitializeMove(ITransformComponent target)
        {
            this.target = target;
            state = PathActorState.Move;
        }

        public void FinishMove()
        {
            state = PathActorState.Wait;
        }
        #endregion
    }
}