using BumpySellotape.Events.Model.Nodes;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class GoToNodeEffect : IEffect
    {
        [SerializeField] private EventNode eventNode;

        string IEffect.Label => "Goto " + (eventNode ? eventNode.name : "-");

        void IEffect.Process(ProcessingContext processingContext)
        {
            eventNode.Process(processingContext);
        }
    }
}