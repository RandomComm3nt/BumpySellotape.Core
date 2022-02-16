namespace BumpySellotape.Core.DateAndTime
{
    public struct DayAndMinutes
    {
        public const int MINUTES_PER_DAY = 1440;

        public int days;
        public int minutes;
        public int TotalMinutes => days * MINUTES_PER_DAY + minutes;

        public DayAndMinutes(int day, int minutes)
        {
            this.minutes = minutes;
            this.days = day;
        }

        public static DayAndMinutes operator -(DayAndMinutes a, DayAndMinutes b)
        {
            if (a.minutes > b.minutes)
                return new DayAndMinutes(a.days - b.days, a.minutes - b.minutes);
            else
                return new DayAndMinutes(a.days - b.days - 1, a.minutes + MINUTES_PER_DAY - b.minutes);
        }
    }
}
