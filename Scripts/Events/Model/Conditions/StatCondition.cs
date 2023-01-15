using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Conditions
{
    public class StatCondition : ICondition
    {
        [SerializeField, FoldoutGroup("@Label")] private StatType statType;
        [SerializeField, FoldoutGroup("@Label")] private ComparisonOperator comparisonOperator;
        [SerializeField, FoldoutGroup("@Label")] private float value;

        public bool Evaluate(EvaluationContext evaluationContext)
        {
            return Evaluate(evaluationContext.SystemLinks.GetSystemSafe<StatCollection>());
        }

        public bool Evaluate(StatCollection statCollection)
        {
            var statValue = statCollection.GetStatSafe(statType).Value;
            return ComparisonUtility.CompareValue(statValue, comparisonOperator, value);
        }

        public string Label => $"{(statType ? statType.DisplayName : "[stat]")} {ComparisonUtility.GetDisplayString(comparisonOperator)} {value}";

        public string ConditionNotMetText => Label;
    }
}
