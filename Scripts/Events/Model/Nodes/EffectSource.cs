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
        }

        [SerializeField] private EffectSourceType effectSourceType;
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.Effect)] private IEffect effect;
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.Frame)] private EventFrame eventFrame = new();
        [SerializeField, ShowIf(nameof(effectSourceType), EffectSourceType.Node)] private EventNode eventNode;

        private IEffect Source =>
            effectSourceType switch
            {
                EffectSourceType.Effect => effect,
                EffectSourceType.Frame => eventFrame,
                EffectSourceType.Node => eventNode,
                _ => throw new NotImplementedException(),
            };

        string IEffect.Label => Source?.Label ?? $"[{effectSourceType}]";

        public void Process(ProcessingContext processingContext)
        {
            Source.Process(processingContext);
        }
    }
}
