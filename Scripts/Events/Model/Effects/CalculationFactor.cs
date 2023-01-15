using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Core.Utilities;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Core.Model.Effects
{
    [HideReferenceObjectPicker]
    public class CalculationFactor
    {
        public enum FactorType
        {
            FixedValue,
            ValueRange,
            Stat,
            Parameter,
            Addition,
            Multiplication,
        }

        public enum MultiplierTarget
        {
            This,
            Target,
        }

        [SerializeField, HorizontalGroup("HGroup"), HideLabel] private FactorType factorType;
        [SerializeField, HorizontalGroup("HGroup"), HideLabel, ShowIf("factorType", FactorType.FixedValue)] private float value;
        [SerializeField, HorizontalGroup("HGroup"), HideLabel, ShowIf("factorType", FactorType.ValueRange)] private Vector2 valueRange;
        [SerializeField, HorizontalGroup("HGroup"), HideLabel, ShowIf("factorType", FactorType.Stat)] private MultiplierTarget statOwner;
        [SerializeField, HorizontalGroup("HGroup"), HideLabel, ShowIf("factorType", FactorType.Stat)] private StatType multiplierStatType;
        [SerializeField, HorizontalGroup("HGroup"), HideLabel, ShowIf("factorType", FactorType.Parameter)] private string parameterName;
        [SerializeField, HorizontalGroup("HGroup"), HideLabel, ShowIf("factorType", FactorType.Addition), ShowIf("factorType", FactorType.Multiplication)] private List<CalculationFactor> factors = new();

        public bool IsParameterised => factorType == FactorType.Parameter || ((factorType == FactorType.Addition || factorType == FactorType.Multiplication) && (factors?.Any(f => f.IsParameterised) ?? false));
        public string ParameterName => parameterName;

        public string DisplayValue => factorType == FactorType.FixedValue ? value.ToString() : "X";

        public void SetToFixedValue(float value)
        {
            factorType = FactorType.FixedValue;
            this.value = value;
        }

        public virtual float GetValue(EvaluationContext context, StatCollection statCollection, float defaultValue)
        {
            return factorType switch
            {
                FactorType.FixedValue => value,
                FactorType.ValueRange => Random.Range(valueRange.x, valueRange.y),
                FactorType.Stat => GetStatValue(statCollection, defaultValue),
                FactorType.Parameter => context.parameters.FirstOrDefault(p => p.key == parameterName)?.GetValue(context, statCollection, defaultValue) ?? defaultValue,
                FactorType.Addition => factors.Sum(f => f.GetValue(context, statCollection, defaultValue)),
                FactorType.Multiplication => factors.Product(f => f.GetValue(context, statCollection, defaultValue)),
                _ => throw new System.NotImplementedException(),
            };
        }

        private float GetStatValue(StatCollection targetActor, float defaultValue)
        {
            if (!targetActor.GetStat(multiplierStatType, out var stat))
                return defaultValue;
            return stat.Value;
        }

        public List<string> GetParameterNames() => IsParameterised
            ? (factorType == FactorType.Parameter 
                ? new() { parameterName } 
                : factors.Select(f => f.GetParameterNames()).Aggregate((l1, l2) => l1.Union(l2).ToList()))
            : new () ;
    }
}