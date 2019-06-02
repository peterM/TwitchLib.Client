using TwitchLib.Client.Enums.Annotation;

namespace TwitchLib.Client.Enums
{
    /// <summary>Color enum representing color based on cheer amount.</summary>
    public enum BadgeColor
    {
        /// <summary>Red = 10000+</summary>
        [Interval(10000, int.MaxValue)]
        Red = 10000,

        /// <summary>Blue = 5000 -> 9999</summary>
        [Interval(5000, 9999)]
        Blue = 5000,

        /// <summary>Green = 1000 -> 4999</summary>
        [Interval(1000, 4999)]
        Green = 1000,

        /// <summary>Purple = 100 -> 999</summary>
        [Interval(100, 999)]
        Purple = 100,

        /// <summary>Gray = 1 -> 99</summary>
        [Interval(1, 99)]
        Gray = 1
    }
}
