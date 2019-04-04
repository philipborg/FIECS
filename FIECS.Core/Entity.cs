using System;

namespace FIECS.Core
{
    public sealed class Entity
    {
        public readonly Guid Id;
        public readonly IEngine engine;
        public Entity(Guid id, IEngine engine)
        {
            Id = id;
        }

        internal void AddComponent(dynamic component)
        {
            throw new NotImplementedException();
        }
    }
}
