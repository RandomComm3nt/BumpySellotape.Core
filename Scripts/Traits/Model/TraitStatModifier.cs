using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Events.Model.Utilities;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Traits.Model
{
    [Serializable]
    public class TraitStatModifier
    {
        [field: SerializeField] public StatType StatType { get; private set; }
        [field: SerializeField] public StatVariable StatVariable { get; private set; } = StatVariable.Value;
        [field: SerializeField] public ModifierType ModifierType { get; private set; } = ModifierType.Additive;
        [field: SerializeField] public float Value { get; private set; }
    }
}
