using TwitchLib.Client.Models.Annotation;

namespace TwitchLib.Client.Models
{
    /// <summary>Class representing cheer badge.</summary>
    public class CheerBadge
    {
        /// <summary>Property representing raw cheer amount represented by badge.</summary>
        public int CheerAmount { get; }

        /// <summary>Property representing the color of badge via an enum.</summary>
        public Enums.BadgeColor Color { get; }

        /// <summary>Constructor for CheerBadge</summary>
        public CheerBadge(int cheerAmount)
        {
            CheerAmount = cheerAmount;
            Color = GetColor(cheerAmount);
        }

        private Enums.BadgeColor GetColor(int cheerAmount)
        {
            return cheerAmount.GetFromInterval<Enums.BadgeColor>();
        }
    }
}
