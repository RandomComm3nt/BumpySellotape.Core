using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BumpySellotape.Core.DateAndTime
{
    [HideReferenceObjectPicker, Serializable]
    [HideLabel]
    public class TimeRange
    {
        [field: SerializeField, Range(0, 1440), FoldoutGroup("$" + nameof(Label))]
        public int FromMinutes { get; private set; } = 0;

        [field: SerializeField, Range(0, 1440), FoldoutGroup("$" + nameof(Label))]
        public int ToMinutes { get; private set; } = 1440;

        private string Label => $"Time: {TimeUtilities.FormatTimeInMinutes24Hour(FromMinutes)} to {TimeUtilities.FormatTimeInMinutes24Hour(ToMinutes)}";
    }
}
