using System;
using System.Windows.Forms;

namespace GameTimeConverter
{
    public class TimeConverter
    {
        private readonly Label labelTaipei;
        private readonly Label labelSeoul;
        private readonly Label labelNewYork;
        private readonly Label labelLosAngeles;
        private TimeZoneInfo gameTimeZone;

        public TimeConverter(
            Label taipeiLabel,
            Label seoulLabel,
            Label newYorkLabel,
            Label losAngelesLabel
        )
        {
            labelTaipei = taipeiLabel;
            labelSeoul = seoulLabel;
            labelNewYork = newYorkLabel;
            labelLosAngeles = losAngelesLabel;
            gameTimeZone = GameTimeZones.GetTimeZone("Last Z: Survival Shooter");
        }

        public void UpdateGameTimeZone(string gameName)
        {
            gameTimeZone = GameTimeZones.GetTimeZone(gameName);
        }

        public void ConvertAndDisplayTime(
            string gameName,
            int year,
            int month,
            int day,
            int hour,
            int minute
        )
        {
            DateTime gameDateTime = new DateTime(
                year,
                month,
                day,
                hour,
                minute,
                0,
                DateTimeKind.Unspecified
            );
            DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(gameDateTime, gameTimeZone);

            DateTime taipeiTime = TimeZoneInfo.ConvertTimeFromUtc(
                utcTime,
                TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time")
            );
            DateTime seoulTime = TimeZoneInfo.ConvertTimeFromUtc(
                utcTime,
                TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time")
            );
            DateTime newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(
                utcTime,
                TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
            );
            DateTime losAngelesTime = TimeZoneInfo.ConvertTimeFromUtc(
                utcTime,
                TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
            );

            labelTaipei.Text = $"{taipeiTime:yyyy-MM-dd HH:mm}";
            labelSeoul.Text = $"{seoulTime:yyyy-MM-dd HH:mm}";
            labelNewYork.Text = $"{newYorkTime:yyyy-MM-dd HH:mm}";
            labelLosAngeles.Text = $"{losAngelesTime:yyyy-MM-dd HH:mm}";
        }
    }
}
