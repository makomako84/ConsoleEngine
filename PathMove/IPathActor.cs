using System.Numerics;

namespace ConsoleEngine
{
    public interface IPathActor
    {
        void InitializeMove(ITransformable target);
        void FinishMove();
        void PathFinishedNotify();
    }
}