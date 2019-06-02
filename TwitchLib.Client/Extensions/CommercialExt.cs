using System;

using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
    /// <summary>
    /// Extension for implementing Commercial functionality in TwitchClient.
    /// </summary>
    public static class CommercialExt
    {
        /// <summary>
        /// Sends command to start a commercial of variable length.
        /// </summary>
        /// <param name="client">Client reference used to identify extension.</param>
        /// <param name="channel">JoinedChannel representation of the channel to send the ad to.</param>
        /// <param name="length">Enum representing the length of advertisement should be.</param>
        /// <exception cref="ArgumentOutOfRangeException">length - null</exception>
        public static void StartCommercial(this ITwitchClient client, JoinedChannel channel, Enums.CommercialLength length)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (channel == null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            client.SendMessage(channel, $".commercial {(int)length}");
        }

        /// <summary>
        /// Sends command to start a commercial of variable length.
        /// </summary>
        /// <param name="client">Client reference used to identify extension.</param>
        /// <param name="channel">String representation of the channel to send the ad to.</param>
        /// <param name="length">Enum representing the length of advertisement should be.</param>
        /// <exception cref="ArgumentOutOfRangeException">length - null</exception>
        public static void StartCommercial(this ITwitchClient client, string channel, Enums.CommercialLength length)
        {
            if (string.IsNullOrWhiteSpace(channel))
            {
                throw new ArgumentNullException(nameof(channel));
            }

            StartCommercial(client, new JoinedChannel(channel), length);
        }
    }
}
