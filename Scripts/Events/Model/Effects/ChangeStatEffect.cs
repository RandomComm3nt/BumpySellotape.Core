using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using CcgCore.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class ChangeStatEffect : IEffect
    {
        [SerializeField, FoldoutGroup("@DisplayLabel")] private Target target;
        [SerializeField, FoldoutGroup("@DisplayLabel")] private StatType statType;

        [SerializeField, FoldoutGroup("@DisplayLabel"), ListDrawerSettings(CustomAddFunction = "GetDefaultFactor")] private List<CalculationFactor> additiveFactors = new List<CalculationFactor>();
        [SerializeField, FoldoutGroup("@DisplayLabel"), ListDrawerSettings(CustomAddFunction = "GetDefaultFactor")] private List<CalculationFactor> multiplicativeFactors = new List<CalculationFactor>();

        string IEffect.Label => $"Change {(statType ? statType.DisplayName : "[stat]")} by [value]";

        void IEffect.Process(ProcessingContext context)
        {
            var targets = GetTargetStatCollections(context);
            foreach (var statCollection in targets)
            {
                if (statCollection.GetStat(statType, out var stat))
                {
                    float additiveFactor = additiveFactors?.Sum(f => f.GetValue(context, statCollection, 0f)) ?? 0f;
                    float multiplicativeFactor = multiplicativeFactors?.Select(f => f.GetValue(context, statCollection, 1f)).Aggregate(1f, (a, b) => a * b) ?? 1f;
                    float value = additiveFactor * multiplicativeFactor;
                    stat.ChangeValue(value);
                }
            }
        }

        private List<StatCollection> GetTargetStatCollections(ProcessingContext context)
        {
            switch (target)
            {
                case Target.Player:
                    return new List<StatCollection>();
                case Target.Self:
                    return new List<StatCollection>();
                case Target.Target1:
                    return new List<StatCollection>();
                default:
                    return new List<StatCollection>();
            }
        }

        private CalculationFactor GetDefaultFactor => new CalculationFactor();

        public List<string> GetParameters()
        {
            return additiveFactors.Union(multiplicativeFactors).Where(f => f.IsParamaterised).Select(f => f.ParameterName).ToList();
        }
    }
}
