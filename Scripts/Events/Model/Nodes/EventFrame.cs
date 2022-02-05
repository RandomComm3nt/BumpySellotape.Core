using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Events.Model.Nodes
{
    public class EventFrame
    {
        public bool IsEmpty => eventBlocks.Count == 0;

        [SerializeField] [HideReferenceObjectPicker] private List<IEffect> eventBlocks = new List<IEffect>();

        public void Process(ProcessingContext processingContext)
        {
            eventBlocks.ForEach(eb => eb.Process(processingContext));
        }
    }
}
