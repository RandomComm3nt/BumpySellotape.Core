using BumpySellotape.Core.Messaging;
using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Core.Traits.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Core.Traits.Controller
{
    public class TraitCollection : IStatModifyingSystem, IMessageReceiver
    {
        public delegate void TraitChanged(Trait trait);
        public event TraitChanged OnTraitAdded;
        public event TraitChanged OnTraitRemoved;

        public List<Trait> Traits { get; } = new List<Trait>();

        float IStatModifyingSystem.Priority => 1f;

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
            trait.OnTraitStacksChanged += OnTraitStacksChanged;
            Traits.Add(trait);
            OnTraitAdded?.Invoke(trait);
            return true;
        }

        private void OnTraitStacksChanged(Trait trait)
        {
            if (trait.Stacks == 0)
                RemoveTrait(trait);
        }

        public void RemoveTrait(Trait trait)
        {
            Traits.Remove(trait);
            OnTraitRemoved?.Invoke(trait);
        }

        public bool RemoveTrait(TraitType traitType, uint stacks = 1)
        {
            if (!GetTrait(traitType, out Trait trait))
                return false;
            RemoveTrait(trait);
            return true;
        }

        float IStatModifyingSystem.ModifyStatValue(StatType statType, StatVariable statVariable, float statValue)
        {
            throw new System.NotImplementedException();
        }

        public void GenerateFromTemplate(TraitCollectionGenerationData traitCollectionGenerationData)
        {
            traitCollectionGenerationData.GenerateTraits().ForEach(t =>
            {
                Traits.Add(t);
                t.OnTraitStacksChanged += OnTraitStacksChanged;
                OnTraitAdded?.Invoke(t);
            });
        }

        public void SendMessage(Message message)
        {
            // duplicate the list first as sendmessage can cause traits to be removed from the collection
            Traits.ToList().ForEach(t => t.SendMessage(message));
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
        */
    }
}
