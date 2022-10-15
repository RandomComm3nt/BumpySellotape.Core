using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
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
            Parameter
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

        public bool IsParamaterised => factorType == FactorType.Parameter;
        public string ParameterName => parameterName;

        public string DisplayValue => factorType == FactorType.FixedValue ? value.ToString() : "X";

        public virtual float GetValue(EvaluationContext context, StatCollection statCollection, float defaultValue)
        {
            return factorType switch
            {
                FactorType.FixedValue => value,
                FactorType.ValueRange => Random.Range(valueRange.x, valueRange.y),
                FactorType.Stat => GetStatValue(statCollection, defaultValue),
                FactorType.Parameter => context.parameters.FirstOrDefault(p => p.key == parameterName)?.GetValue(context, statCollection, defaultValue) ?? defaultValue,
                _ => throw new System.NotImplementedException(),
            };
        }

        private float GetStatValue(StatCollection targetActor, float defaultValue)
        {
            if (!targetActor.GetStat(multiplierStatType, out var stat))
                return defaultValue;
            return stat.Value;
        }

        public List<string> GetParameterNames() => IsParamaterised ? new() { parameterName } : new () ;
    }
}