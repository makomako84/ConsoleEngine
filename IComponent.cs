namespace PathMove
{
    public interface IComponent
    {
        string Name { get; set; }
        void AddComponent(IComponent component);
        void RemoveComponent(IComponent component);
        IComponent GetComponent<T>();

        void Update();
    }
}