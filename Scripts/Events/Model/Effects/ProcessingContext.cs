using BumpySellotape.Events.Controller;
using BumpySellotape.Events.Model.Conditions;
using BumpySellotape.Events.Model.Nodes;
using System.Collections.Generic;

namespace BumpySellotape.Events.Model.Effects
{
    public class ProcessingContext : EvaluationContext
    {
        public bool isLoggingEnabled = false;
        public List<EventFrame> queuedFrames;

        /// <summary>
        /// If set to true, no further effects will be run
        /// </summary>
        public bool cancelEvent = false;
        /// <summary>
        /// Set to true to notify the event trigger that the action should be cancelled
        /// </summary>
        public bool cancelEventTrigger = false;

        public bool HasQueuedFrames => queuedFrames?.Count > 0;

        public GameController GameController { get; }

        public ProcessingContext(GameController gameController)
        {
            GameController = gameController;
        }
    }
}
