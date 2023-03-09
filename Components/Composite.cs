using System;
using System.Collections.Generic;

namespace PathMove
{
    public class Composite : ComponentEntity
    {

        protected Dictionary<Type, IComponent> components;

        public Composite()
        {
            this.components = new Dictionary<Type, IComponent>();
        }

        public override void Update()
        {
            foreach(var item in components)
            {
                item.Value.Update();
            }
        }

        public override void AddComponent(IComponent component)
        {
            components.Add(component.GetType(), component);
        }
        public override void RemoveComponent(IComponent component)
        {
            System.Console.WriteLine($"Before remove: {components.Count}");
            components.Remove(component.GetType());
            System.Console.WriteLine($"After remove: {components.Count}");
        }

        public override IComponent GetComponent<T>()
        {
            var component = default(T);
            Type type = component.GetType();
            return components[type];
        }
    }
}