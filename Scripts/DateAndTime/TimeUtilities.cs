using UnityEngine;

namespace BumpySellotape.Core.DateAndTime
{
    public static class TimeUtilities
    {
        public static string FormatTimeInMinutes24Hour(int minutes)
        {
            return $"{Mathf.Floor(minutes / 60f):00}:{(minutes % 60):00}";
        }
    }
}
