using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class AdvanceTimeEffect : IEffect
    {
        [SerializeField, FoldoutGroup("@" + nameof(Label))] private int minutes = 60;

        public string Label => $"Advance time by {minutes} minutes";

        void IEffect.Process(ProcessingContext processingContext)
        {
            throw new System.NotImplementedException();
        }
    }
}