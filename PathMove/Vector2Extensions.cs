using System.Numerics;

namespace PathMove
{
    public static class Vector2E
    {
        private static float _divide = 5.0f;

        public static Vector2 GetMoveVector(Vector2 directionVector)
        {
            var moveVector = Vector2.Normalize(directionVector);
            moveVector = moveVector / _divide;
            System.Console.WriteLine($"Move vector is: {moveVector}");
            return moveVector;
        }

        public static Vector2 GetDirectionVector(float x1, float y1, float x2, float y2)
        {
            return new Vector2
            (
                x2 - x1,
                y2 - y1
            );
        }

        public static Vector2 GetDirectionVector(ITransformComponent transform1, ITransformComponent transform2)
        {
            return new Vector2
            (
                transform2.X - transform1.X,
                transform2.Y - transform1.Y
            );
        }
    }
}