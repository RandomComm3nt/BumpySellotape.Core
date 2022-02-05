using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Events.Model.Nodes
{
    [CreateAssetMenu(menuName = "Events/Event Node")]
    public class EventNode : SerializedScriptableObject
    {
        private bool HideEventBlocks => eventFrames != null && eventFrames.Count > 0 && !eventFrames[0].IsEmpty;
        [SerializeField] [HideReferenceObjectPicker] [HideIf(nameof(HideEventBlocks))] [InfoBox("Deprecated, use frames instead")] private List<IEffect> eventBlocks = new();
        [SerializeField, HideReferenceObjectPicker, ListDrawerSettings(CustomAddFunction = nameof(AddFrame))] private List<EventFrame> eventFrames = new() { new EventFrame() };

        public void Process(ProcessingContext processingContext)
        {
            if (HideEventBlocks)
            {
                eventFrames[0].Process(processingContext);
                if (eventFrames.Count > 1)
                    processingContext.queuedFrames = eventFrames.Skip(1).ToList();
            }
            else
                eventBlocks.ForEach(eb => eb.Process(processingContext));
        }

        private EventFrame AddFrame()
        {
            return new EventFrame();
        }
    }
}
