using BumpySellotape.Core.Events.Model.Nodes;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    [HideReferenceObjectPicker]
    public class ConditionOption
    {
        [field: SerializeField] public Condition Condition { get; private set; }
        [field: SerializeField] public EffectSource Effect { get; private set; } = new();
    }
}
