namespace PathMove
{
    public interface IPathDirector
    {
        void AttachActor(IPathActor actor);
        void UpdateActorDirection();
    }
}