using System;
using UnityEngine;

namespace BumpySellotape.Core.DateAndTime
{
    public class DateAndTime
    {
        public const int SECONDS_PER_MINUTE = 60;
        public const int MINUTES_PER_DAY = 1440;

        private float timeRatio = 60f;
        private float seconds = 0f;

        public int Minutes { get; private set; } = 0;
        public int Day { get; private set; } = 0;
        public DayOfWeek DayOfWeek { get; private set; } = DayOfWeek.Monday;

        public delegate void TimeChanged(DateAndTime source);
        public event TimeChanged OnTimeChanged;

        public void AddMinutes(int deltaMinutes)
        {
            if (deltaMinutes <= 0)
                throw new ArgumentException($"Expected to add a positive number of minutes, received {deltaMinutes}");

            Minutes += deltaMinutes;
            if (Minutes >= MINUTES_PER_DAY)
            {
                Minutes -= MINUTES_PER_DAY;
                Day++;
                DayOfWeek = (DayOfWeek)(((int)DayOfWeek + 1) % 7);
            }
            OnTimeChanged?.Invoke(this);
        }

        public void ProgressTime()
        {
            seconds += Time.fixedDeltaTime * timeRatio;
            if (seconds >= SECONDS_PER_MINUTE)
            {
                AddMinutes(Mathf.FloorToInt(seconds / SECONDS_PER_MINUTE));
                seconds %= SECONDS_PER_MINUTE;
            }
        }

        public void SetTime(int minutes)
        {
            Minutes = minutes;
            OnTimeChanged?.Invoke(this);
        }
    }
}
