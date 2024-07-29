using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RestoreMonarchy.AssetModifier.Helpers
{
    internal static class ReflectionHelper
    {
        public static IEnumerable<MemberInfo> GetAllMembers(Type type)
        {
            var members = new HashSet<MemberInfo>();

            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty;

            // Traverse the type hierarchy
            while (type != null)
            {
                // Add fields
                foreach (var field in type.GetFields(bindingFlags))
                {
                    if (members.Any(x => x.DeclaringType == field.DeclaringType && x.Name == field.Name))
                    {
                        continue;
                    }
                    if (field.Name.EndsWith("k__BackingField"))
                    {
                        continue;
                    }

                    members.Add(field);
                }

                // Add properties
                foreach (var property in type.GetProperties(bindingFlags))
                {
                    if (members.Any(x => x.DeclaringType == property.DeclaringType && x.Name == property.Name))
                    {
                        continue;
                    }
                    if (property.Name.EndsWith("k__BackingField"))
                    {
                        continue;
                    }
                    if (!property.CanWrite)
                    {
                        continue;
                    }

                    members.Add(property);
                }

                // Move to the base type
                type = type.BaseType;
            }

            return members;
        }
    }
}
