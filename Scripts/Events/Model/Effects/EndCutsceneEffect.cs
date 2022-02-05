using BumpySellotape.Events.Model.Nodes;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class EndCutsceneEffect : IEffect
    {
        [SerializeField] private EventNode nextEventNode = null;

        string IEffect.Label => "End Cutscene";

        void IEffect.Process(ProcessingContext processingContext)
        {
            processingContext.GameController.ExitCutscene(nextEventNode);
        }
    }
}