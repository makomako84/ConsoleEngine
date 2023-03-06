namespace PathMove
{
    public class Obj : ITransformComponent
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override string ToString()
        {
            return $"<{X} {Y}>";
        }
    }
}