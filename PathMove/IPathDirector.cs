namespace ConsoleEngine
{
    public interface IPathDirector
    {
        void AttachActor(IPathActor actor);
        void UpdateActorDirection();
    }
}