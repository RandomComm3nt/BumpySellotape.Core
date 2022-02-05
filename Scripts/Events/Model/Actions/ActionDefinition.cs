using BumpySellotape.Events.Model.Conditions;
using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Events.Model.Actions
{
    [CreateAssetMenu(menuName = "Events/Action")]
    public class ActionDefinition : SerializedScriptableObject
    {
        [field: SerializeField] public string Label { get; private set; } = "";
        [field: SerializeField] public string Description { get; private set; } = "";
        [field: SerializeField] public ICondition ShowCondition { get; private set; } = null;
        [field: SerializeField] public ICondition EnableCondition { get; private set; } = null;
        [field: SerializeField] public List<IEffect> Effects { get; private set; } = null;
    }
}
