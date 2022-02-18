using System;
using UnityEngine;

namespace BumpySellotape.Core.DateAndTime
{
    [Serializable]
    public class TimeTrackingConfig
    {
        [field: SerializeField] public bool UsePeriods { get; private set; }
        [field: SerializeField] public TimePeriodFlag AllowedTimePeriods { get; private set; }
    }
}