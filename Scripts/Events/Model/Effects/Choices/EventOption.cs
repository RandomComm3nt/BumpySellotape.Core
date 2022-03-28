using BumpySellotape.Core.Events.Model.Nodes;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects.Choices
{
    [HideReferenceObjectPicker]
    public class EventOption
    {
        [field: SerializeField, FoldoutGroup("$" + nameof(Label))] public string Label { get; private set; }
        [field: SerializeField, FoldoutGroup("$" + nameof(Label)), HideReferenceObjectPicker] public List<ICondition> DisplayConditions { get; private set; } = new();
        [field: SerializeField, FoldoutGroup("$" + nameof(Label)), HideReferenceObjectPicker] public List<ICondition> AvailableConditions { get; private set; } = new();
        [field: SerializeField, FoldoutGroup("$" + nameof(Label))] public EffectSource TargetEffect { get; private set; } = new();
    }
}