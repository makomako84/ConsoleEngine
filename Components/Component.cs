namespace PathMove
{
    public class Component : ComponentEntity
    {
        public Composite Root { get; init; }

        public Component(Composite root)
        {
            Root = root;
        }

        public override void AddComponent(IComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override IComponent GetComponent<T>()
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveComponent(IComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            
        }
    }
}