using BumpySellotape.Events.Model.Nodes;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class PlayCutsceneEffect : IEffect
    {
        [SerializeField] private EventNode sceneEvent = null;
        [SerializeField] private GameObject sceneObject = null;

        string IEffect.Label => "Play Scene - " + (sceneEvent ? sceneEvent.name : "");

        void IEffect.Process(ProcessingContext processingContext)
        {
            processingContext.GameController.EnterCutscene(sceneEvent, sceneObject);
        }
    }
}