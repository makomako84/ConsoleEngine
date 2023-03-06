/*
    Некий исполнитель
    Что хочет этот исполнитель?
    Достичь данной ему точки.
    Вернее, исполнитель всего лишь движется.
    Это его компонента - двигаться.
*/

using System.Numerics;
using System.Collections.Generic;

namespace PathMove
{
    public class Unit : ITransformComponent
    {
        public float X { get; set; }
        public float Y { get; set; }

        private float speed = 0.1f;
        private Vector2 targetPosition;
        private Vector2 currentPosition;


        private ITransformComponent target;

        private float _maxDistance = 0.5f;

        /*
            Некоторый источник CurrentPosition
            Не обязательно внутри класса.
        */
        protected Vector2 CurrentPosition
        {
            get => currentPosition;
        }


        public void Move()
        {
            if(CurrentPosition == targetPosition)
            {
                targetPosition = GetNext();
            }
            else
            {
                Vector2 dir = currentPosition - targetPosition;
                dir = Vector2.Normalize(dir);
                currentPosition += dir * speed;
            }
            System.Console.WriteLine($"cur: {currentPosition}, targ: {targetPosition}");
        }

        public void Update(int timeCounter)
        {
            if(!moveActionFinished)
            {
                MoveAction(this, target, timeCounter);
            }
        }

        bool moveActionFinished = false;
        void MoveAction(ITransformComponent transform1, ITransformComponent transform2, int timeCounter)
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


        private static int index = 0;
        private static List<Vector2> source = new List<Vector2>()
        {
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,2)
        };

        public Unit(ITransformComponent target)
        {
            this.target = target;
        }

        private Vector2 GetNext()
        {
            index++;
            return source[index]; 
        }
    }
}