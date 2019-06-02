using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using TwitchLib.Client.Enums.Annotation;

namespace TwitchLib.Client.Models.Annotation
{
    public static class AnnotationExtensions
    {
        public static T GetFromInterval<T>(this int value)
            where T : Enum
        {
            Dictionary<T, List<IntervalAttribute>> items = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary<T, T, List<IntervalAttribute>>(d => d, d => GetAttributes<IntervalAttribute>(d).ToList());

            if (items.Count > 0)
            {
                foreach (KeyValuePair<T, List<IntervalAttribute>> item in items)
                {
                    var result = item.Value.FirstOrDefault(d => d.From <= value && value <= d.To);
                    if (result != null)
                    {
                        return item.Key;
                    }
                }
            }

            return default;
        }

        public static T GetFromMap<T>(this string map)
            where T : Enum
        {
            Dictionary<T, List<MapAttribute>> items = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary<T, T, List<MapAttribute>>(d => d, d => GetAttributes<MapAttribute>(d).ToList());

            if (items.Count > 0)
            {
                foreach (KeyValuePair<T, List<MapAttribute>> item in items)
                {
                    var result = item.Value.FirstOrDefault(d => string.Equals(d.Value, map, StringComparison.InvariantCultureIgnoreCase));
                    if (result != null)
                    {
                        return item.Key;
                    }
                }
            }

            return default;
        }

        public static IEnumerable<T> GetAttributes<T>(this Enum enumValue)
            where T : Attribute
        {
            IEnumerable<T> attributes = Enumerable.Empty<T>();

            MemberInfo memberInfo = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (memberInfo != null)
            {
                attributes = memberInfo.GetCustomAttributes(typeof(T), false).Cast<T>().ToList();
            }

            return attributes;
        }
    }
}
