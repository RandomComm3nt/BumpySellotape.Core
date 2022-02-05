using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CcgCore.Model.Effects
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

        public float GetValue(EvaluationContext context, StatCollection statCollection, float defaultValue)
        {
            return factorType switch
            {
                FactorType.FixedValue => value,
                FactorType.ValueRange => Random.Range(valueRange.x, valueRange.y),
                //FactorType.Stat => GetStatValue(context.triggerActor.Actor, statCollection, defaultValue),
                //FactorType.Parameter => context.parameters.FirstOrDefault(p => p.key == parameterName)?.GetValue(context, statCollection, defaultValue) ?? defaultValue,
                _ => throw new System.NotImplementedException(),
            };
        }

        private float GetStatValue(StatCollection thisActor, StatCollection targetActor, float defaultValue)
        {
            if (!(statOwner == MultiplierTarget.This ? thisActor : targetActor).GetStat(multiplierStatType, out var stat))
                return defaultValue;
            return stat.Value;
        }
    }
}