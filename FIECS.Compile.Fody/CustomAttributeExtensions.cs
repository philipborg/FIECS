using Fody;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace FIECS.Compile.Fody
{
    public static class CustomAttributeExtensions
    {
        public static IEnumerable<TypeDefinition> GetTypesWithAttribute(this BaseModuleWeaver baseModuleWeaver, TypeReference attribute)
        {
            return baseModuleWeaver.ModuleDefinition.GetTypesWithAttribute(attribute);
        }
        
        public static IEnumerable<TypeDefinition> GetTypesWithAttribute(this ModuleDefinition moduleDefinition, TypeReference attribute)
        {
            return moduleDefinition.GetTypes().GetTypesWithAttribute(attribute);
        }

        public static IEnumerable<TypeDefinition> GetTypesWithAttribute(this IEnumerable<TypeDefinition> types, TypeReference attribute)
        {
            return types.Where(type => type.CustomAttributes.Any(ca => ca.AttributeType.Equals(attribute)));
        }
    }
}
