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
        [SerializeField, FoldoutGroup("@Label")] private Target target;
        [SerializeField, FoldoutGroup("@Label")] private StatType statType;

        [SerializeField, FoldoutGroup("@Label"), ListDrawerSettings(CustomAddFunction = "GetDefaultFactor")] private List<CalculationFactor> additiveFactors = new();
        [SerializeField, FoldoutGroup("@Label"), ListDrawerSettings(CustomAddFunction = "GetDefaultFactor")] private List<CalculationFactor> multiplicativeFactors = new();

        public string Label => $"Change {(statType ? statType.DisplayName : "[stat]")} by [value]";

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
            return target switch
            {
                Target.Player => new() { context.SystemLinks.GetSystemSafe<StatCollection>() },
                Target.Self => new List<StatCollection>(),
                Target.Target1 => new List<StatCollection>(),
                _ => new List<StatCollection>(),
            };
        }

        private CalculationFactor GetDefaultFactor => new CalculationFactor();

        public List<string> GetParameters()
        {
            return additiveFactors.Union(multiplicativeFactors).Where(f => f.IsParamaterised).Select(f => f.ParameterName).ToList();
        }
    }
}
