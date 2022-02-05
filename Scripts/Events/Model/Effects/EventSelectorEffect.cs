using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class EventSelectorEffect : IEffect
    {
        private enum SelectionType
        {
            Priority = 0,
            Weighted = 1,
        }

        [SerializeField] private SelectionType selectionType;

        string IEffect.Label => $"{selectionType} Event Selector";

        void IEffect.Process(ProcessingContext processingContext)
        {
            throw new System.NotImplementedException();
        }
    }
}