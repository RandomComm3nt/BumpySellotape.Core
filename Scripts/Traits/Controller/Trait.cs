using BumpySellotape.Core.Messaging;
using BumpySellotape.Core.Traits.Model;
using Sirenix.Utilities;
using System.Linq;

namespace BumpySellotape.Core.Traits.Controller
{
    /// <summary>
    /// Wrapper around Trait, allowing for information to be recorded against a particular character's trait
    /// </summary>
    public class Trait : IMessageReceiver
    {
        //public bool knownToPlayer = true;

        //public TraitFamily TraitFamily { get; }
        public TraitType TraitType { get; private set; }
        public string DisplayName => TraitType.TraitName;
        //public bool IsVisible => !TraitType.Hidden && knownToPlayer && TargetCharacterController == null;
        public int Stacks { get; private set; }

        public delegate void TraitStacksChanged(Trait trait);
        public event TraitStacksChanged OnTraitStacksChanged;

        public Trait(TraitType traitType)
        {
            TraitType = traitType;
            Stacks = 1;
        }

        public void SendMessage(Message message)
        {
            TraitType.StackChangeRules
                .Where(cr => cr.MessageFilter.Equals(message.MessageFilter))
                .ForEach(cr => ChangeStacks(cr.StackChangeAmount));
        }

        public void ChangeStacks(int delta)
        {
            Stacks += delta;
            OnTraitStacksChanged?.Invoke(this);
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
