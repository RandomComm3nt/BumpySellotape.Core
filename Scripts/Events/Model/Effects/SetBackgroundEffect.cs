using BumpySellotape.Events.Controller;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class SetBackgroundEffect : IEffect
    {
        [SerializeField] private Sprite sprite = null;

        string IEffect.Label => "Set Background";

        void IEffect.Process(ProcessingContext processingContext)
        {
            var renderer = processingContext.SystemLinks.GetSystemOrNull<IBackgroundRenderer>();
            renderer.SetBackground(sprite);
        }
    }
}