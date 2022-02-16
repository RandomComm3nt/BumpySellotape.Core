using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    public interface INicheEffect
    {
        void Process(ProcessingContext processingContext);
    }

    public class NicheEffect : IEffect
    {
        [SerializeField, FoldoutGroup("@" + nameof(Label))] private INicheEffect effect;

        public string Label => "Run Niche Effect";

        public void Process(ProcessingContext processingContext)
        {
            effect.Process(processingContext);
        }
    }
}