using BumpySellotape.Core.DateAndTime;
using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    public class AdvanceTimePeriodEffect : IEffect
    {
        [SerializeField, FoldoutGroup("@" + nameof(Label))] private bool setTime = false;
        [SerializeField, FoldoutGroup("@" + nameof(Label)), HideIf(nameof(setTime))] private int periodsToAdvance = 1;
        [SerializeField, FoldoutGroup("@" + nameof(Label)), ShowIf(nameof(setTime))] private TimePeriod advanceToPeriod = TimePeriod.LateNight;
        [SerializeField, FoldoutGroup("@" + nameof(Label))] private bool allowDayRollover = false;

        public string Label => "Advance Time " + (setTime
            ? "to " + advanceToPeriod.ToString()
            : $"by {periodsToAdvance} periods");

        public void Process(ProcessingContext processingContext)
        {
            var tracker = processingContext.SystemLinks.GetSystemSafe<DateAndPeriodTracker>();
            if (setTime)
            {
                tracker.AdvanceToTimePeriod(advanceToPeriod, allowDayRollover);
            }
            else
            {
                tracker.AdvanceTimePeriod(periodsToAdvance, allowDayRollover);
            }
        }
    }
}