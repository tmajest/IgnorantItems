using System;

namespace CoffeeCat.RiotCommon.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string ToUnixTimestamp(this DateTime dateTime)
        {
            var unixTime = (long) dateTime.Subtract(Epoch).TotalMilliseconds;
            return unixTime.ToString();
        }

        public static DateTime FromUnixTimestamp(string timestamp)
        {
            var milliseconds = long.Parse(timestamp);
            return Epoch.AddMilliseconds(milliseconds);
        }
    }
}
