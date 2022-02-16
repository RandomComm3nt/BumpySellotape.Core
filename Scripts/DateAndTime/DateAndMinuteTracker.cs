using System;
using UnityEngine;

namespace BumpySellotape.Core.DateAndTime
{
    public class DateAndMinuteTracker : DateTracker
    {
        public const int MINUTES_PER_DAY = 1440;
        public const int SECONDS_PER_MINUTE = 60;
        private float timeRatio = 60f;
        private float seconds = 0f;

        private DayAndMinutes dayAndMinutes = new();

        public DayAndMinutes CurrentDayAndMinutes => dayAndMinutes;

        public override int Day => dayAndMinutes.days;
        public int Minutes => dayAndMinutes.minutes;

        public DateAndMinuteTracker(TimeTrackingConfig config) : base(config)
        {
        }

        public void AddMinutes(int deltaMinutes)
        {
            if (config.UsePeriods)
                return;
            if (deltaMinutes <= 0)
                throw new ArgumentException($"Expected to add a positive number of minutes, received {deltaMinutes}");

            dayAndMinutes.minutes += deltaMinutes;
            if (Minutes >= MINUTES_PER_DAY)
            {
                dayAndMinutes.minutes -= MINUTES_PER_DAY;
                dayAndMinutes.days++;
                AdvanceDay();
            }
            OnTimeChanged();
        }

        public void ProgressTime()
        {
            if (config.UsePeriods)
                return;
            seconds += Time.fixedDeltaTime * timeRatio;
            if (seconds >= SECONDS_PER_MINUTE)
            {
                AddMinutes(Mathf.FloorToInt(seconds / SECONDS_PER_MINUTE));
                seconds %= SECONDS_PER_MINUTE;
            }
        }

        public void SetTime(int minutes)
        {
            if (config.UsePeriods)
                return;
            dayAndMinutes.minutes = minutes;
            OnTimeChanged();
        }
    }
}