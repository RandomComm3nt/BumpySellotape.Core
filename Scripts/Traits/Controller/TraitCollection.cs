using BumpySellotape.Core.Messaging;
using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Core.Traits.Model;
using BumpySellotape.Events.Model.Utilities;
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

        public bool AddTrait(TraitType traitType, out Trait trait, uint stacks = 1)
        {
            trait = null;
            if (GetTrait(traitType, out _))
                return false;
            trait = new(traitType);
            trait.OnTraitStacksChanged += OnTraitStacksChanged;
            Traits.Add(trait);
            OnTraitAdded?.Invoke(trait);
            Debug.Log($"Trait {traitType.name} added");
            return true;
        }

        public bool AddTrait(TraitType traitType, uint stacks = 1)
        {
            return AddTrait(traitType, out var _, stacks);
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
            var modifiers = Traits
                .SelectMany(t => t.TraitType.StatModifiers
                    .Where(sm => sm.StatType == statType && sm.StatVariable == statVariable)
                    .Select(sm => (t.Stacks, sm))
                 );

            float additive = modifiers.Where(m => m.sm.ModifierType == ModifierType.Additive).Sum(m => m.Stacks * m.sm.Value);
            float multiplier = modifiers.Where(m => m.sm.ModifierType == ModifierType.Multiplicative).Aggregate(1f, (total, next) => total * Mathf.Pow(next.sm.Value, next.Stacks));
            return statValue * multiplier + additive;
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

        public void OnAnyStatChanged(Stat stat)
        {
            stat.UpdateThresholdTraits(this);
        }
    }
}