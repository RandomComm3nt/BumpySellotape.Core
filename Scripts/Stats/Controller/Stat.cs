using BumpySellotape.Core.Stats.Model;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Controller
{
    public class Stat
    {
        /// <summary>
        /// The value of the stat before clamping or modifiers are applied
        /// </summary>
        public float RawValue { get; private set; }
        /// <summary>
    /// The min value of the stat before modifiers are applied
    /// </summary>
        public float RawMinValue { get; private set; }
        /// <summary>
        /// The max value of the stat before modifiers are applied
        /// </summary>
        public float RawMaxValue { get; private set; }

        //private DriftType driftType = DriftType.NoDrift;
        //private float driftTarget;
        //private float baseDriftRatePerDay = 0f;
        private float gainMultiplier = 1f;
        private float lossMultiplier = 1f;

        public StatType StatType { get; }
        public StatCollection StatCollection { get; }

        /// <summary>
        /// The value with modifiers, but without taking into account the min or the max value
        /// </summary>
        public float UnclampedValue => StatCollection.ModifyStatValue(StatType, StatVariable.Value, RawValue);
        /// <summary>
        /// The min value including modifiers
        /// </summary>
        public float MinValue => StatCollection.ModifyStatValue(StatType, StatVariable.MinValue, RawMinValue);
        /// <summary>
        /// The max value including modifiers
        /// </summary>
        public float MaxValue => StatCollection.ModifyStatValue(StatType, StatVariable.MaxValue, RawMaxValue);
        /// <summary>
        /// The effective value of the stat with modifiers and min/max restrictions applied
        /// </summary>
        public float Value => Mathf.Clamp(UnclampedValue, MinValue, MaxValue);
        /// <summary>
        /// Value as a percentage of MaxValue, in range [0, 100]
        /// </summary>
        public float ValuePercent => 100 * Value / MaxValue;
        //public float DriftTarget => ModifyValue(driftTarget, StatVariable.DriftTarget);
        //private float DriftRatePerDay => ModifyValue(baseDriftRatePerDay, StatVariable.DriftRate);


        public delegate void ValueChanged(float delta);
        public event ValueChanged OnValueChanged;

        public Stat(StatType statType, StatCollection statCollection)
        {
            StatType = statType;
            StatCollection = statCollection;
            RawValue = statType.DefaultValue;
            RawMinValue = statType.DefaultMinValue;
            RawMaxValue = statType.DefaultMaxValue;
            //driftType = statType.DriftType;
            //baseDriftRatePerDay = statType.DriftRatePerDay;
        }

        public void ChangeValue(float delta)
        {
            delta *= (delta > 0 ? gainMultiplier : lossMultiplier);
            RawValue = Mathf.Clamp(RawValue + delta, RawMinValue, RawMaxValue);
            OnValueChanged?.Invoke(delta);
        }

        public void SetVariable(float value, StatVariable statVariable = StatVariable.Value)
        {
            switch (statVariable)
            {
                case StatVariable.Value:
                    RawValue = Mathf.Clamp(value, RawMinValue, RawMaxValue);
                    break;
                //case StatVariable.DriftTarget:
                //    driftTarget = value;
                //    break;
            }
            OnValueChanged?.Invoke(0f);
        }

        /*
        public void AdvanceTime(int minutes)
        {
            affectingTraits.RemoveAll(ct => ct.HasExpired);
            // baseValue drifts towards DriftTarget
            // this means traits affecting Value are unaffected by drift
            float diff = DriftTarget - baseValue;
            float timeDelta = minutes / 1440f;
            switch (driftType)
            {
                case DriftType.ConstantDrift:
                    baseValue += (Mathf.Min(Mathf.Abs(diff), DriftRatePerDay * timeDelta)) * Mathf.Sign(diff);
                    break;
                case DriftType.ProportionalDrift:
                    // if reducing at x% a day then e^-k = (100-x)/100 gives y(t) = y(0)*e^(-kt)
                    // so y(t) = y(0) * [(100-x)/100]^t
                    baseValue += diff * (Mathf.Pow((100 - DriftRatePerDay) / 100, timeDelta) - 1);
                    break;
                default:
                    break;
            }
            OnValueChange?.Invoke();
        }
        */
    }
}
