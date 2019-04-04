using Fody;
using Mono.Cecil;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FIECS.Compile.Fody
{
    public sealed class EntityExtensionsWeaver
    {
        readonly TypeReference _componentAttribute;
        readonly ModuleDefinition _moduleDefinition;
        readonly CustomAttribute _extensionAttribute;

        public EntityExtensionsWeaver(ModuleDefinition moduleDefinition, TypeReference componentAttribute)
        {
            _componentAttribute = componentAttribute;
            _moduleDefinition = moduleDefinition;
            _extensionAttribute = _moduleDefinition.GetCustomAttribute(typeof(ExtensionAttribute));
        }

        public void Execute()
        {
            ComponentEntityExtensions();
        }

        private void ComponentEntityExtensions()
        {
            var components = _moduleDefinition.GetTypesWithAttribute(_componentAttribute).Select(v => v.Key);
            foreach(var component in components)
            {
                var method = new MethodDefinition(
                    $"Put{component.Name.ToPascalCase(false)}",
                    MethodAttributes.Static | MethodAttributes.Final | MethodAttributes.Public,
                    null
                    );

                var entityParameter = new ParameterDefinition("entity", ParameterAttributes.None, _moduleDefinition.GetType("FIECS.Core", "Entity"));
                entityParameter.CustomAttributes.Add(_extensionAttribute);
                method.Parameters.Add(entityParameter);

                var valueParameter = new ParameterDefinition(component.Name.ToCamelCase(false), ParameterAttributes.None, component);
                method.Parameters.Add(valueParameter);

                component.Methods.Add(method);
            }
        }
    }
}
