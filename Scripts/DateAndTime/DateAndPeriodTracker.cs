using System;
using System.Collections.Generic;

namespace BumpySellotape.Core.DateAndTime
{
    public class DateAndPeriodTracker : DateTracker
    {
        public TimePeriod CurrentTimePeriod { get; private set; }
        private readonly List<TimePeriod> allowedTimePeriods;

        public DateAndPeriodTracker(TimeTrackingConfig config) : base(config)
        {

        }

        public void AdvanceTimePeriod(int incrementCount, bool allowRollover)
        {
            var i = allowedTimePeriods.IndexOf(CurrentTimePeriod);
            var j = i + incrementCount;
            if (j > allowedTimePeriods.Count - 1)
            {
                j = allowRollover ? j % allowedTimePeriods.Count : allowedTimePeriods.Count - 1;
                if (allowRollover)
                    AdvanceDay();
            }
            SetTimePeriod(allowedTimePeriods[j]);
        }

        public void SetTimePeriod(TimePeriod timePeriod)
        {
            if (!allowedTimePeriods.Contains(timePeriod))
                throw new Exception("Time is being set to a period not in the list: " + timePeriod.ToString());
            CurrentTimePeriod = timePeriod;
            OnTimeChanged();
        }
    }
}