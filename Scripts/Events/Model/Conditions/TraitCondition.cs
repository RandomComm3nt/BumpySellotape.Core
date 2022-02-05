using BumpySellotape.Core.Tagging;
using BumpySellotape.Core.Traits.Controller;
using BumpySellotape.Core.Traits.Model;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Events.Model.Conditions
{
    public class TraitCondition : ICondition
    {
        [SerializeField, FoldoutGroup("$Label")] private bool invertCondition = false;
        [SerializeField, FoldoutGroup("$Label")] private List<TraitType> traitTypes = new List<TraitType>();
        [OnInspectorInit("@tagList.tagDictionaryName = \"Trait Tags\"")]
        [SerializeField, FoldoutGroup("$Label"), HideLabel] private TagList tagList = new TagList();

        public string Label => invertCondition ? "Does not have trait" : "Has trait";

        bool ICondition.Evaluate(EvaluationContext evaluationContext)
        {
            var traitCollection = evaluationContext.SystemLinks.GetSystemOrNull<TraitCollection>();
            if (traitCollection != null)
            {
                if (traitCollection.Traits.Any(t => traitTypes.Any(tt => tt.TraitName == t.TraitType.TraitName) || tagList.Intersects(t.TraitType.TagList)))
                    return !invertCondition;
            }
            return invertCondition;
        }
    }
}
