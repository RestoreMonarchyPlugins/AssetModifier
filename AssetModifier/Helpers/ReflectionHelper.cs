using System;
using System.Collections.Generic;
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
                    members.Add(field);
                }

                // Add properties
                foreach (var property in type.GetProperties(bindingFlags))
                {
                    members.Add(property);
                }

                // Move to the base type
                type = type.BaseType;
            }

            return members;
        }
    }
}
