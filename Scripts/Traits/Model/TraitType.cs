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
        //[SerializeField] private TraitValueType traitValueType = TraitValueType.Flag;
        [field: SerializeField] public bool Hidden { get; private set; } = false;
        [SerializeField] [HideIf("Hidden")] private string traitName = "";
        [SerializeField] [HideIf("Hidden")] [Multiline(2)] private string description = "";
        [SerializeField] private List<TraitStatModifier> statModifiers = new List<TraitStatModifier>();
        //[SerializeField] [ShowIf("traitValueType", TraitValueType.Stack)] private int maxStacks = 100;

        [field: OnInspectorInit("@TagList.tagDictionaryName = \"Trait Tags\"")]
        [field: SerializeField] public TagList TagList { get; } = new TagList();
        
        public string TraitName => traitName.IsNullOrWhitespace() ? name : traitName;
        public string Description => description;
        public List<TraitStatModifier> StatModifiers => statModifiers;
    }
}
