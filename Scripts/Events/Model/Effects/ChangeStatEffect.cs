﻿using BumpySellotape.Core.Model.Effects;
using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public abstract class ChangeStatEffectBase : IEffect
    {
        [SerializeField, FoldoutGroup("@Label")] private StatType statType;

        [SerializeField, FoldoutGroup("@Label"), ListDrawerSettings(CustomAddFunction = nameof(GetDefaultFactor))] private List<CalculationFactor> additiveFactors = new();
        [SerializeField, FoldoutGroup("@Label"), ListDrawerSettings(CustomAddFunction = nameof(GetDefaultFactor))] private List<CalculationFactor> multiplicativeFactors = new();
        [SerializeField, FoldoutGroup("@Label")] private RoundingType roundingType;

        public string Label => $"Change {(statType ? statType.DisplayName : "[stat]")} by [value]";

        void IEffect.Process(ProcessingContext context)
        {
            var targets = GetTargetStatCollections(context);
            foreach (var statCollection in targets)
            {
                ApplyStatChange(context, statCollection);
            }
        }

        protected abstract List<StatCollection> GetTargetStatCollections(ProcessingContext context);

        protected void ApplyStatChange(ProcessingContext context, StatCollection statCollection)
        {
            if (statCollection.GetStat(statType, out var stat))
            {
                float additiveFactor = additiveFactors?.Sum(f => f.GetValue(context, statCollection, 0f)) ?? 0f;
                float multiplicativeFactor = multiplicativeFactors?.Select(f => f.GetValue(context, statCollection, 1f)).Aggregate(1f, (a, b) => a * b) ?? 1f;
                float value = additiveFactor * multiplicativeFactor;
                float roundedValue = roundingType switch
                {
                    RoundingType.NoRounding => value,
                    RoundingType.RoundToInt => Mathf.Round(value),
                    RoundingType.CeilToInt => Mathf.Ceil(value),
                    RoundingType.FloorToInt => Mathf.Floor(value),
                    _ => throw new System.NotImplementedException(),
                };
                stat.ChangeValue(roundedValue);
            }
        }

        private CalculationFactor GetDefaultFactor => new();

        public List<string> GetParameterNames()
        {
            return additiveFactors.Union(multiplicativeFactors).Where(f => f.IsParameterised).Select(f => f.ParameterName).ToList();
        }

        private enum RoundingType
        {
            NoRounding = 0,
            RoundToInt = 1,
            CeilToInt = 2,
            FloorToInt = 3,
        }
    }

    public class ChangeStatEffect : ChangeStatEffectBase, IEffect
    {
        [SerializeField, FoldoutGroup("@Label")] private Target target;

        protected override List<StatCollection> GetTargetStatCollections(ProcessingContext context)
        {
            return target switch
            {
                Target.Player => new() { context.SystemLinks.GetSystemSafe<StatCollection>() },
                Target.Self => new List<StatCollection>(),
                Target.Target1 => new List<StatCollection>(),
                _ => new List<StatCollection>(),
            };
        }
    }
}
