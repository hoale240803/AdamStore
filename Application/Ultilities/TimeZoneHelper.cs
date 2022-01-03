using System;
using TimeZoneConverter;

namespace Application.Ultilities
{
    public static class TimeZoneHelper
    {
        public static DateTime ConvertUtcTimeToTimeZone(this DateTime serverTime, string timeZoneId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(serverTime, timeZoneInfo);
        }

        public static DateTime ConvertTimeZoneToUtcTime(this DateTime serverTime, string timeZoneId)
        {
            var timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);
            return TimeZoneInfo.ConvertTimeToUtc(serverTime, timeZoneInfo);
        }

        public static DateTime ChangeUtcToNewTimeZone(this DateTime utcTime, string oldTimezoneParam, string newTimezoneParam)
        {
            var oldTimezone = TZConvert.GetTimeZoneInfo(oldTimezoneParam);
            var newTimezone = TZConvert.GetTimeZoneInfo(newTimezoneParam);
            var oldTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, oldTimezone);

            return TimeZoneInfo.ConvertTimeToUtc(oldTime, newTimezone);
        }

        public static void GetStartTimeAndEndTime(TimeZoneInfo timeZoneInfo, ref DateTime startTime, ref DateTime endTime)
        {
            var isStartTimeInValid = timeZoneInfo.IsInvalidTime(startTime);
            var isEndTimeInValid = timeZoneInfo.IsInvalidTime(endTime);

            if (isStartTimeInValid)
                startTime = startTime.AddHours(1);
            if (isEndTimeInValid)
                endTime = endTime.AddHours(1);
        }  
    }
}