using System;
using System.Collections.Generic;

namespace BumpySellotape.Core.DateAndTime
{
    [Serializable]
    public class TimeTrackingConfig
    {
        public bool UsePeriods { get; private set; }
        public List<TimePeriod> AllowedTimePeriods { get; private set; } = new();
    }
}