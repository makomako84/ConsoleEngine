namespace PathMove
{
    public class TestMessageComponent2 : TestBaseMessageComponent
    {
        public string Secret { get; init; }
        public TestMessageComponent2(Composite root, int max, string secret) : base(root, max)
        {
            this.Secret = secret;
        }

        protected string Action()
        {
            return base.Action() + " " + Secret;
        }
    }
}