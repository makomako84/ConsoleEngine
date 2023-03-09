using System.Collections.Generic;
using System;

namespace ConsoleEngine
{
    public abstract class ComponentEntity : Entity, IComponent
    {
        public abstract void AddComponent(IComponent component);
        public abstract void RemoveComponent(IComponent component);
        public abstract IComponent GetComponent<T>();

        public abstract void Update();
    }
}