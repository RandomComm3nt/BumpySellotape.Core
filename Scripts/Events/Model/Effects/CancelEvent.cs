using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    public class CancelEvent : IEffect
    {
        [SerializeField, FoldoutGroup("@" + nameof(Label))] private bool stopFurtherEffects = false;
        [SerializeField] private bool cancelEventTrigger = false;

        public string Label => "Cancel Event";

        void IEffect.Process(ProcessingContext processingContext)
        {
            processingContext.cancelEvent |= stopFurtherEffects;
            processingContext.cancelEventTrigger |= cancelEventTrigger;
        }
    }
}