using BumpySellotape.Core.Traits.Model;

namespace BumpySellotape.Core.Traits.Controller
{
    /// <summary>
    /// Wrapper around Trait, allowing for information to be recorded against a particular character's trait
    /// </summary>
    public class Trait
    {
        //public bool knownToPlayer = true;
        //public float minValue;
        //public float maxValue;

        //public TraitFamily TraitFamily { get; }
        public TraitType TraitType { get; private set; }
        public string DisplayName => TraitType.TraitName;
        //public bool IsVisible => !TraitType.Hidden && knownToPlayer && TargetCharacterController == null;

        //public CharacterControllerBase TargetCharacterController { get; }
        //public bool WillExpire { get; private set; } = false;
        //public int DaysUntilExpiry { get; private set; }
        //public bool HasExpired { get; private set; }
        //public float Value { get; private set; }
        //public bool IsChanging { get; private set; } = false;
        //public float ValueChangePerDay { get; private set; }

        public Trait(TraitType traitType)
        {
            TraitType = traitType;
            //Value = 1f;
        }
        /*
        public Trait SetExpiryDays(int days)
        {
            //WillExpire = true;
            //DaysUntilExpiry = days;
            return this;
        }

        public Trait SetValue(float value)
        {
            Value = value;
            return this;
        }

        public Trait SetValueChange(float changePerDay, float minValue = Mathf.NegativeInfinity, float maxValue = Mathf.Infinity)
        {
            IsChanging = true;
            ValueChangePerDay = changePerDay;
            this.minValue = minValue;
            this.maxValue = maxValue;
            return this;
        }

        public Trait RampDownToExpiry()
        {
            return SetValueChange(Value / DaysUntilExpiry, Value > 0 ? 0 : Mathf.NegativeInfinity, Value < 0 ? 0 : Mathf.Infinity);
        }

        public float ModifierForStat(StatType statType, StatVariable statVariable, ModifierType statModifierType)
        {
            return Value * Trait.StatModifiers.FirstOrDefault(sm => sm.StatType == statType && sm.StatVariable == statVariable && sm.StatModifierType == statModifierType)?.Value ?? (statModifierType == ModifierType.Additive ? 0f : 1f);
        }

        /// <returns>True if trait has expired and should be removed</returns>
        public bool AdvanceDay()
        {
            if (IsChanging)
            {
                Value = Mathf.Clamp(Value + ValueChangePerDay, minValue, maxValue);
            }

            if (WillExpire)
            {
                DaysUntilExpiry--;
                if (DaysUntilExpiry == 0)
                {
                    Value = 0;
                    IsChanging = false;
                    HasExpired = true;
                    return true;
                }
            }
            return false;
        }

        public bool HasModifierForStat(StatType statType)
        {
            return Trait.StatModifiers.Any(tsm => tsm.StatType == statType);
        }
        */
    }
}
