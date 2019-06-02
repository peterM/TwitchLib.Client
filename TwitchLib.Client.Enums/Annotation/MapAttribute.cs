using System;

namespace TwitchLib.Client.Enums.Annotation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MapAttribute : Attribute
    {
        public MapAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
