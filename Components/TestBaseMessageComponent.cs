namespace ConsoleEngine
{
    public class TestBaseMessageComponent : Component
    {
        int count = 0;
        int max = 3;

        public TestBaseMessageComponent(Composite root, int max) : base(root)
        {
            Max = max;
        }

        public int Max 
        {
            get => max;
            init => max = value;
        }
        
        public override void Update()
        {
            if(count < max)
            {
                // action here ...
                System.Console.WriteLine(Action());

                // count after action, here ...
                count++;

                if(count >= max)
                {
                    // notify about detach here ...
                    (Root as TestMessageController).RemoveComponent(this);
                }
            }
        }

        protected virtual string Action()
        {
            return $"Message, {count}, {Name}";
        }
    }
}