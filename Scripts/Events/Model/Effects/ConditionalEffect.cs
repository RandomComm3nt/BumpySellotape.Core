using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class ConditionalEffect : IEffect
    {
        [SerializeField] [FoldoutGroup("@Label")] [HideReferenceObjectPicker] private List<ICondition> conditionList = new ();
        [SerializeField] [FoldoutGroup("@Label")] [HideReferenceObjectPicker] private List<IEffect> ifEffects = new ();
        [SerializeField] [FoldoutGroup("@Label")] [HideReferenceObjectPicker] private List<IEffect> elseEffects = new ();

        private string Label => $"IF {ConditionLabel} ...{(elseEffects.Count > 0 ? " ELSE ..." : "")}";

        string IEffect.Label => throw new System.NotImplementedException();

        private string ConditionLabel => conditionList.Count == 1 ? conditionList[0].Label : "";

        void IEffect.Process(ProcessingContext processingContext)
        {
            if (processingContext.isLoggingEnabled)
                Debug.Log($"Assessing {conditionList.Count} criteria for block \"{Label}\"");
            if (conditionList.All(c => c.Evaluate(processingContext)))
            {
                if (processingContext.isLoggingEnabled)
                    Debug.Log($"Criteria met");
                ifEffects.ForEach(b => b.Process(processingContext));
            }
            else
            {
                if (processingContext.isLoggingEnabled)
                    Debug.Log($"Criteria not met");
                elseEffects.ForEach(b => b.Process(processingContext));
            }
        }
    }
}
