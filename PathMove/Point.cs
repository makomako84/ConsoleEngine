namespace PathMove
{
    public class Point : Entity, ITransformComponent
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"<{X} {Y}>";
        }
    }
}