using System;

namespace BumpySellotape.Core.DateAndTime
{
    public enum TimePeriod
    {
        EarlyMorning = 0, // 2 - 6
        Morning = 1,  // 6 - 10
        Midday = 2, // 10 - 14
        Afternoon = 3, // 14 - 18
        Evening = 4, // 18 - 22
        Night = 5,  // 22 - 2
        LateNight = 6,  // 2 - 6 (same as EarlyMorning but easier to treat as being in the same day)
    }

    [Flags]
    public enum TimePeriodFlag
    {
        EarlyMorning = 2 << TimePeriod.EarlyMorning,
        Morning = 2 << TimePeriod.Morning,
        Midday = 2 << TimePeriod.Midday,
        Afternoon = 2 << TimePeriod.Afternoon,
        Evening = 2 << TimePeriod.Evening,
        Night = 2 << TimePeriod.Night,
        LateNight = 2 << TimePeriod.LateNight,
        NotOvernight = Morning | Midday | Afternoon | Evening | Night,
        All = EarlyMorning | LateNight | NotOvernight,
    }
}