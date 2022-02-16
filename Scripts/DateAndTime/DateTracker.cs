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

        public DateTracker(TimeTrackingConfig config)
        {
            this.config = config;
        }

        protected void AdvanceDay()
        {
            day++;
            DayOfWeek = (DayOfWeek)(((int)DayOfWeek + 1) % 7);
        }

        protected void OnTimeChanged()
        {
            TimeChanged?.Invoke(this);
        }
    }
}
