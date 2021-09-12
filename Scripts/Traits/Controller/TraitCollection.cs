namespace BumpySellotape.Common.Traits.Model
{
    public class TraitCollection
    {
        /*
        public delegate void TraitChanged(CharacterTrait trait);
        public event TraitChanged OnTraitAdded;
        public event TraitChanged OnTraitRemoved;

        public List<CharacterTrait> Traits { get; } = new List<CharacterTrait>();

        public bool DoesCharacterHaveTrait(TraitBase traitType, out CharacterTrait traitInstance)
        {
            traitInstance = Traits.FirstOrDefault(t => ReferenceEquals(t.Trait, traitType) || ReferenceEquals(t.TraitFamily, traitType));
            return (traitInstance != null);
        }

        public bool AddTrait(Trait traitType, uint stacks = 1)
        {
            if (DoesCharacterHaveTrait(traitType, out _))
                return false;
            CharacterTrait trait = new CharacterTrait(traitType);
            Traits.Add(trait);
            OnTraitAdded?.Invoke(trait);
            return true;
        }

        public bool RemoveTrait(Trait traitType, uint stacks = 1)
        {
            if (!DoesCharacterHaveTrait(traitType, out CharacterTrait trait))
                return false;
            Traits.Remove(trait);
            OnTraitRemoved?.Invoke(trait);
            return true;
        }

        public List<CharacterTrait> GetTraitsByTargetCharacter(CharacterControllerBase characterController)
        {
            return Traits.Where(t => t.TargetCharacterController == characterController).ToList();
        }

        public List<CharacterTrait> GetTraitsByStatType(StatType statType)
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
