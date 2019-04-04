using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FIECS.Compile.Fody
{
    public static class TypeExtensions
    {
        public static IDictionary<TypeDefinition, ICollection<CustomAttribute>>  GetTypesWithAttribute(this ModuleDefinition moduleDefinition, TypeReference attribute)
        {
            return moduleDefinition.GetTypes().GetTypesWithAttribute(attribute);
        }

        public static IDictionary<TypeDefinition, ICollection<CustomAttribute>> GetTypesWithAttribute(this IEnumerable<TypeDefinition> types, TypeReference attribute)
        {
            return 
                types
                .Select(type =>
                    (
                        typeReference: type,
                        customAttributes: type
                            .CustomAttributes
                            .Where(ca => ca.AttributeType.Equals(attribute))
                            .ToList()
                    )
                )
                .Where(tuple => tuple.customAttributes.Any())
                .ToDictionary(tuple => tuple.typeReference, tuple => (ICollection<CustomAttribute>) tuple.customAttributes);
        }

        public static MethodReference GetConstructorReference(this ModuleDefinition moduleDefinition, Type type, Type[] parameters = null)
        {
            var constructor = type.GetConstructor(parameters ?? Array.Empty<Type>());
            return moduleDefinition.ImportReference(constructor);
        }

        public static CustomAttribute GetCustomAttribute(this ModuleDefinition moduleDefinition, Type type, Type[] parameter = null)
        {
            return new CustomAttribute(moduleDefinition.GetConstructorReference(type, parameter));
        }
    }
}
