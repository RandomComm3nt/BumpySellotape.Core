using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Events.Model.Nodes
{
    public class EventFrameList : IEffect
    {
        public string Label => "[Event Frames]";

        [SerializeField, HideReferenceObjectPicker, ListDrawerSettings(CustomAddFunction = nameof(AddFrame))] private List<EventFrame> eventFrames = new() { new EventFrame() };

        public void Process(ProcessingContext processingContext)
        {
            eventFrames[0].Process(processingContext);
            if (eventFrames.Count > 1)
                processingContext.queuedFrames = eventFrames.Skip(1).ToList();
        }

        private EventFrame AddFrame()
        {
            return new EventFrame();
        }
    }
}
