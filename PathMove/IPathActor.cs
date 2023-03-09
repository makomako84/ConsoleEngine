using System.Numerics;

namespace PathMove
{
    public interface IPathActor
    {
        void InitializeMove(ITransformable target);
        void FinishMove();
        void PathFinishedNotify();
    }
}