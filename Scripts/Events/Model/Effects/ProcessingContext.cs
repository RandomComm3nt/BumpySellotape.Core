using BumpySellotape.Events.Controller;
using BumpySellotape.Events.Model.Conditions;
using BumpySellotape.Events.Model.Nodes;
using System.Collections.Generic;

namespace BumpySellotape.Events.Model.Effects
{
    public class ProcessingContext : EvaluationContext
    {
        //public List<InteractionEventOption> eventOptions = new List<InteractionEventOption>();

        //public string eventTitle;
        //private string eventText = "";
        //public InteractionWindow interactionWindow;

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

        /*
        public string EventText
        {
            get => eventText; set
            {
                eventText = value;
                OnContextUpdated?.Invoke(this);
            }
        }

        public delegate void ContextUpdated(ProcessingContext context);
        public event ContextUpdated OnContextUpdated;

        public void AddEndEventOption()
        {
            if (eventOptions.Count == 0)
            {
                eventOptions.Add(new InteractionEventOption("Continue"));
                OnContextUpdated?.Invoke(this);
            }
        }
        */
    }
}
