using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Core.Traits.Model;
using System.Collections.Generic;
using System.Linq;

namespace BumpySellotape.Core.Traits.Controller
{
    public class TraitCollection : IStatModifyingSystem
    {
        public delegate void TraitChanged(Trait trait);
        public event TraitChanged OnTraitAdded;
        public event TraitChanged OnTraitRemoved;

        public List<Trait> Traits { get; } = new List<Trait>();

        float IStatModifyingSystem.Priority => throw new System.NotImplementedException();

        public bool GetTrait(TraitType traitType, out Trait trait)
        {
            trait = Traits.FirstOrDefault(t => ReferenceEquals(t.TraitType, traitType));
            return (trait != null);
        }

        public bool AddTrait(TraitType traitType, uint stacks = 1)
        {
            if (GetTrait(traitType, out _))
                return false;
            Trait trait = new(traitType);
            Traits.Add(trait);
            OnTraitAdded?.Invoke(trait);
            return true;
        }

        public bool RemoveTrait(TraitType traitType, uint stacks = 1)
        {
            if (!GetTrait(traitType, out Trait trait))
                return false;
            Traits.Remove(trait);
            OnTraitRemoved?.Invoke(trait);
            return true;
        }

        float IStatModifyingSystem.ModifyStatValue(StatType statType, StatVariable statVariable, float statValue)
        {
            throw new System.NotImplementedException();
        }

        /*
        public List<Trait> GetTraitsByTargetCharacter(CharacterControllerBase characterController)
        {
            return Traits.Where(t => t.TargetCharacterController == characterController).ToList();
        }

        public List<Trait> GetTraitsByStatType(StatType statType)
        {
            return Traits.Where(t => t.HasModifierForStat(statType)).ToList();
        }

        public void AdvanceTime(int minutes)
        {/*
            foreach (var trait in Traits)
                trait.AdvanceTime(minutes);
    //      }
        */
    }
}
