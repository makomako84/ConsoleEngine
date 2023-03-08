using System.Numerics;

namespace PathMove
{
    public interface IPathActor
    {
        void InitializeMove(ITransformComponent target);
        void FinishMove();
        void PathFinishedNotify();
    }
}