using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

namespace CalendarUtility
{
    public struct CalendarEvent
    {
        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? Duration { get; set; }

        public bool IsAllDayEvent { get; set; }

        public string Description { get; set; }
    }

    public static class CalendarHelper
    {
        public static int DefaultDurationMinutes = 60;

        public static string ToIsoString(this DateTime dateTime)
        {
            var ios = dateTime.ToString("O");
            var reg = new Regex("/-|:|\\.\\d+/g");
            return reg.Replace(ios, string.Empty);
        }

        public static string CalculateEndTime(CalendarEvent calendarEvent)
        {
            var duration = calendarEvent.Duration ?? DefaultDurationMinutes;

            return calendarEvent.EndTime.HasValue
                ? calendarEvent.EndTime.Value.ToIsoString()
                : calendarEvent.StartTime.AddMinutes(duration).ToIsoString();
        }

        public static string GenerateGoogleCalendarUrl(CalendarEvent calendarEvent)
        {
            var startTime = calendarEvent.IsAllDayEvent
                ? calendarEvent.StartTime.ToString("yyyyMMdd")
                : calendarEvent.StartTime.ToIsoString();
            var endTime = calendarEvent.IsAllDayEvent
                ? calendarEvent.StartTime.AddDays(1).ToString("yyyyMMdd")
                : CalculateEndTime(calendarEvent);

            var url = string.Join("", new[]
            {
                "https://www.google.com/calendar/render",
                "?action=TEMPLATE",
                $"&text={calendarEvent.Title}",
                $"&dates={startTime}",
                $"/{endTime}",
                $"&details={UnityWebRequest.EscapeURL(calendarEvent.Description)}",
                "&sprop=&sprop=name:"
            });

            return url;
        }
    }
}