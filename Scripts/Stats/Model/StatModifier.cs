using System;

namespace BumpySellotape.Core.Stats.Model
{
    [Serializable]
    public class StatModifier
    {
        public StatModifierType statModifierType = StatModifierType.Additive;
        public StatType statType;
        public StatVariable statVariable = StatVariable.Value;
        public float value = 0f;
        public string source;

        public float ModifyValue(float baseValue)
        {
            return statModifierType == StatModifierType.Additive
                ? baseValue + value
                : baseValue * value;
        }

        public float ModifyValueWithFactor(float baseValue, float factor)
        {
            return statModifierType == StatModifierType.Additive
                ? baseValue + (value * factor)
                : baseValue + (value - 1f) * baseValue * factor;
        }
    }

    public enum StatModifierType
    {
        Additive = 0,
        Multiplicative
    }
}
