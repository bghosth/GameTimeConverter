using System;

namespace GameTimeConverter
{
    public static class GameTimeZones
    {
        public static TimeZoneInfo GetTimeZone(string gameName) =>
            gameName switch
            {
                "Last Z: Survival Shooter" => TimeZoneInfo.CreateCustomTimeZone(
                    "EGT",
                    TimeSpan.FromHours(-2),
                    "Eastern Greenland Time",
                    "EGT"
                ),
                _ => TimeZoneInfo.Utc,
            };
    }
}
