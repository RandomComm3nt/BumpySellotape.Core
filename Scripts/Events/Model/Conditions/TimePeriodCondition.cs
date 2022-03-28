using Assets.Common.Scripts.Utilities;
using BumpySellotape.Core.DateAndTime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Events.Model.Conditions
{
    public class TimePeriodCondition : ICondition
    {
        [SerializeField, FoldoutGroup("@" + nameof(Label))] private TimePeriodFlag allowedPeriods = new();

        public string Label => $"Period is {allowedPeriods}";

        public string ConditionNotMetText => Label;

        bool ICondition.Evaluate(EvaluationContext evaluationContext)
        {
            var p = evaluationContext.SystemLinks.GetSystemSafe<DateAndPeriodTracker>().CurrentTimePeriod;
            return EnumUtils.FlagContainsNonFlagValue(allowedPeriods, p);
        }
    }
}
