using BumpySellotape.Core.Tagging;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Traits.Model
{
    [CreateAssetMenu(menuName = "Common/Traits/TraitType")]
    public class TraitType : SerializedScriptableObject
    {
        [field: SerializeField] public bool Hidden { get; private set; } = false;
        [SerializeField] [HideIf("Hidden")] private string traitName = "";
        [SerializeField] [HideIf("Hidden")] [Multiline(2)] private string description = "";
        [SerializeField] private List<TraitStatModifier> statModifiers = new();

        [field: SerializeField] public bool IsStackable { get; }
        [field: SerializeField, ShowIf(nameof(IsStackable))] public int MaxStacks { get; } = 100;

        [field: OnInspectorInit("@TagList.tagDictionaryName = \"Trait Tags\"")]
        [field: SerializeField] public TagList TagList { get; } = new TagList();
        [field: SerializeField, ListDrawerSettings(CustomAddFunction = "@new StackChangeRule()")] public List<StackChangeRule> StackChangeRules { get; } = new List<StackChangeRule>();
        
        public string TraitName => traitName.IsNullOrWhitespace() ? name : traitName;
        public string Description => description;
        public List<TraitStatModifier> StatModifiers => statModifiers;
    }
}
