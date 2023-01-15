using BumpySellotape.Events.Controller;
using BumpySellotape.Events.Model.Conditions;
using BumpySellotape.Events.Model.Nodes;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class ProcessingContext : EvaluationContext
    {
        public List<EventFrame> queuedFrames;
        public List<IEffect> effectsToProcess = new ();

        /// <summary>
        /// If set to true, no further effects will be run
        /// </summary>
        public bool cancelEvent = false;

        /// <summary>
        /// Set to true to notify the event trigger that the action should be cancelled
        /// </summary>
        public bool cancelEventTrigger = false;

        public bool logDebugMessages = false;

        public bool isWaitingToContinue = false;

        public bool HasQueuedFrames => queuedFrames?.Count > 0;

        public GameController GameController { get; }

        public ProcessingContext(GameController gameController)
        {
            GameController = gameController;
        }

        public void ProcessNextEffect()
        {
            isWaitingToContinue = false;

            if (effectsToProcess.Count == 0 || cancelEvent)
                return;

            var effect = effectsToProcess[0];
            effectsToProcess.RemoveAt(0);

            effect.Process(this);
            if (!isWaitingToContinue)
                ProcessNextEffect();
        }

        public void Log(string message)
        {
            if (isLoggingEnabled)
                Debug.Log(message);
        }
    }
}
