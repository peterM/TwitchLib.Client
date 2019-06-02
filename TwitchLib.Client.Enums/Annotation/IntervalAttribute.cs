using System;

namespace TwitchLib.Client.Enums.Annotation
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class IntervalAttribute : Attribute
    {
        public IntervalAttribute(int from, int to)
        {
            To = to;
            From = from;
        }

        public int To { get; }

        public int From { get; }
    }
}
