using Assets.Common.Scripts.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.DateAndTime
{
    public class DateAndPeriodTracker : DateTracker
    {
        public TimePeriod CurrentTimePeriod { get; private set; }
        private readonly List<TimePeriod> allowedTimePeriods;

        public DateAndPeriodTracker(TimeTrackingConfig config) : base(config)
        {
            var values = Enum.GetValues(typeof(TimePeriod));
            allowedTimePeriods = new();
            foreach (var o in values)
            {
                if (EnumUtils.FlagContainsNonFlagValue(config.AllowedTimePeriods, (TimePeriod)o))
                    allowedTimePeriods.Add((TimePeriod)o);
            }
        }

        public void AdvanceTimePeriod(int incrementCount, bool allowRollover)
        {
            var periodsIncremented = incrementCount;
            var i = allowedTimePeriods.IndexOf(CurrentTimePeriod);
            var j = i + incrementCount;
            if (j > allowedTimePeriods.Count - 1)
            {
                j = allowRollover ? j % allowedTimePeriods.Count : allowedTimePeriods.Count - 1;
                if (allowRollover)
                    AdvanceDay();
                else
                {
                    periodsIncremented = j - i;
                }
            }
            
            OnIntervalPassed(TimeInterval.Period, periodsIncremented);
            SetTimePeriod(allowedTimePeriods[j]);
        }

        public void AdvanceToTimePeriod(TimePeriod advanceToPeriod, bool allowRollover)
        {
            var advanceToIndex = allowedTimePeriods.IndexOf(advanceToPeriod);
            var currentIndex = allowedTimePeriods.IndexOf(CurrentTimePeriod);
            if (advanceToIndex > currentIndex)
            {
                OnIntervalPassed(TimeInterval.Period, advanceToIndex - currentIndex);
                SetTimePeriod(advanceToPeriod);
            }
            else if (allowRollover)
            {
                OnIntervalPassed(TimeInterval.Period, currentIndex + allowedTimePeriods.Count - advanceToIndex);
                AdvanceDay();
            }
            else
            {
                Debug.Log($"Tried to advance to {advanceToPeriod}, currently {CurrentTimePeriod}, but rollover not allowed");
            }
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