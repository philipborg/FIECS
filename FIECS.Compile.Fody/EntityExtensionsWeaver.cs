using Fody;
using Mono.Cecil;
using System.Linq;

namespace FIECS.Compile.Fody
{
    public sealed class EntityExtensionsWeaver
    {
        BaseModuleWeaver _weaver;
        TypeReference _componentAttribute;

        public EntityExtensionsWeaver(BaseModuleWeaver moduleWeaver, TypeReference componentAttribute)
        {
            _weaver = moduleWeaver;
        }

        public void Execute()
        {
            ComponentEntityExtensions();
        }

        private void ComponentEntityExtensions()
        {
            var components = _weaver.GetTypesWithAttribute(_componentAttribute).Where(typeRef => typeRef.Attributes.HasFlag(TypeAttributes.Public));
            for(var component in components)
            {
                var method = new MethodDefinition(
                    $"Add{component.Name}",
                    MethodAttributes.Static | MethodAttributes.Final | MethodAttributes.Public,
                    );
            }
        }
    }
}
