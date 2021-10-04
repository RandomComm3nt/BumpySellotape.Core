using System;

namespace BumpySellotape.Core.DateAndTime
{
    [Flags]
    public enum DayOfWeekFlag
    {
        Sunday = 2 << DayOfWeek.Sunday,
        Monday = 2 << DayOfWeek.Monday,
        Tuesday = 2 << DayOfWeek.Tuesday,
        Wednesday = 2 << DayOfWeek.Wednesday,
        Thursday = 2 << DayOfWeek.Thursday,
        Friday = 2 << DayOfWeek.Friday,
        Saturday = 2 << DayOfWeek.Saturday,
        All = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday,
        Weekends = Saturday | Sunday,
        Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
    }
}
