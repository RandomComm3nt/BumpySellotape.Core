using System;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    public class Stat
    {
        private float baseValue;

        //private DriftType driftType = DriftType.NoDrift;
        //private float driftTarget;
        //private float baseDriftRatePerDay = 0f;
        private float gainMultiplier = 1f;
        private float lossMultiplier = 1f;

        public StatType StatType { get; }

        public float Value => Mathf.Clamp(baseValue, MinValue, MaxValue);
        public float ValuePercent => 100 * Value / MaxValue;
        public float MinValue { get; private set; }
        public float MaxValue { get; private set; }
        //public float DriftTarget => ModifyValue(driftTarget, StatVariable.DriftTarget);
        //private float DriftRatePerDay => ModifyValue(baseDriftRatePerDay, StatVariable.DriftRate);

        [Obsolete]
        public delegate void ValueChange();
        public delegate void ValueChanged(float delta);
        [Obsolete]
        public event ValueChange OnValueChange;
        public event ValueChanged OnValueChanged;

        public Stat(StatType statType)
        {
            StatType = statType;
            baseValue = statType.DefaultValue;
            MinValue = statType.DefaultMinValue;
            MaxValue = statType.DefaultMaxValue;
            //driftType = statType.DriftType;
            //baseDriftRatePerDay = statType.DriftRatePerDay;
        }

        public void ChangeValue(float delta)
        {
            delta *= (delta > 0 ? gainMultiplier : lossMultiplier);
            baseValue = Mathf.Clamp(baseValue + delta, MinValue, MaxValue);
            OnValueChange?.Invoke();
            OnValueChanged?.Invoke(delta);
        }

        public void SetVariable(float value, StatVariable statVariable = StatVariable.Value)
        {
            switch (statVariable)
            {
                case StatVariable.Value:
                    baseValue = Mathf.Clamp(value, MinValue, MaxValue);
                    break;
                //case StatVariable.DriftTarget:
                //    driftTarget = value;
                //    break;
            }
            OnValueChange?.Invoke();
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
