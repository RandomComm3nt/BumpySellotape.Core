using BumpySellotape.Events.Model.Effects;
using BumpySellotape.Events.Model.Nodes;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Nodes
{
    [HideReferenceObjectPicker]
    public class EffectSource : IEffect
    {
        public enum EffectSourceType
        {
            Effect = 0,
            Frame,
            Node,
            None,
            FrameList,
        }

        [SerializeField] private EffectSourceType effectSourceType = EffectSourceType.None;
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.Effect)] private IEffect effect;
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.Frame), HideLabel] private EventFrame eventFrame = new();
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.FrameList), HideLabel, HideReferenceObjectPicker] private EventFrameList eventFrameList = new();
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.Node)] private EventNode eventNode;

        private IEffect Source =>
            effectSourceType switch
            {
                EffectSourceType.Effect => effect,
                EffectSourceType.Frame => eventFrame,
                EffectSourceType.FrameList => eventFrameList,
                EffectSourceType.Node => eventNode,
                EffectSourceType.None => null,
                _ => throw new NotImplementedException(),
            };

        public string Label => Source?.Label ?? $"[{effectSourceType}]";

        public void Process(ProcessingContext processingContext)
        {
            if (effectSourceType == EffectSourceType.None)
                return;
            Source.Process(processingContext);
        }
    }
}
