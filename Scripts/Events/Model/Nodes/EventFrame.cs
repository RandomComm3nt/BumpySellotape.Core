using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Events.Model.Nodes
{
    [HideReferenceObjectPicker]
    public class EventFrame : IEffect
    {
        public bool IsEmpty => eventBlocks.Count == 0;

        public string Label => $"Frame - {eventBlocks.Count} effects";

        [SerializeField] [HideReferenceObjectPicker] private List<IEffect> eventBlocks = new();

        public void Process(ProcessingContext processingContext)
        {
            processingContext.effectsToProcess.InsertRange(0, eventBlocks);
        }
    }
}
