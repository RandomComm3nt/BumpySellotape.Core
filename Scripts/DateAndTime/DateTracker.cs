using BumpySellotape.Core.Utilities;
using System;

namespace BumpySellotape.Core.DateAndTime
{
    public abstract class DateTracker
    {
        protected readonly TimeTrackingConfig config;
        protected int day;
        public virtual int Day => day;
        public DayOfWeek DayOfWeek { get; private set; } = DayOfWeek.Monday;

        public event SimpleEventHandler<DateTracker> TimeChanged;
        public delegate void IntervalPassedDelegate(TimeInterval timeInterval, int intervalCount);
        public event IntervalPassedDelegate IntervalPassed;

        public DateTracker(TimeTrackingConfig config)
        {
            this.config = config;
        }

        protected void AdvanceDay()
        {
            day++;
            DayOfWeek = (DayOfWeek)(((int)DayOfWeek + 1) % 7);
            IntervalPassed?.Invoke(TimeInterval.Day, 1);
        }

        protected void OnTimeChanged()
        {
            TimeChanged?.Invoke(this);
        }

        protected void OnIntervalPassed(TimeInterval timeInterval, int intervalCount)
        {
            IntervalPassed?.Invoke(timeInterval, intervalCount);
        }
    }
}
