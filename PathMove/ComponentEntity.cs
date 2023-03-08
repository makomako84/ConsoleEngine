using System.Collections.Generic;
using System;

namespace PathMove
{
    public class ComponentEntity : Entity, IComponent
    {
        private Dictionary<Type, IComponent> components;

        public ComponentEntity()
        {
            this.components = new Dictionary<Type, IComponent>();
        }

        public void AddComponent(IComponent component)
        {
            components.Add(component.GetType(), component);
        }
        public void RemoveComponent(IComponent component)
        {
            components.Remove(component.GetType());
        }

        public IComponent GetComponent<T>()
        {
            var component = default(T);
            Type type =component.GetType();
            return components[type];
        }


    }
}