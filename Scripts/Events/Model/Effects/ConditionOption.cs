using BumpySellotape.Core.Events.Model.Nodes;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    [HideReferenceObjectPicker]
    public class ConditionOption
    {
        [field: SerializeField, FoldoutGroup("$" + nameof(Label)), HideLabel] public ICondition Condition { get; private set; }
        [field: SerializeField, FoldoutGroup("$" + nameof(Label)), HideLabel] public EffectSource Effect { get; private set; } = new();

        private string Label => $"IF {Condition?.Label ?? "[Condition]"}";
    }
}
