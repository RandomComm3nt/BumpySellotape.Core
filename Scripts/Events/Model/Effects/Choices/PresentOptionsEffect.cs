using BumpySellotape.Events.Controller;
using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects.Choices
{
    public class PresentOptionsEffect : IEffect
    {
        [SerializeField, ListDrawerSettings(CustomAddFunction = nameof(AddEventOption))] private List<EventOption> options = new();

        public string Label => throw new System.NotImplementedException();

        public void Process(ProcessingContext processingContext)
        {
            var eventOptions = options
                .Where(o => o.DisplayConditions.All(c => c.Evaluate(processingContext)))
                .Select(o => new EvaluatedEventOption(o, processingContext))
                .ToList();

            IEventTextManager eventTextManager = processingContext.SystemLinks.GetSystemSafe<IEventTextManager>();
            eventTextManager.DisplayOptions(eventOptions);
        }

        private EventOption AddEventOption() => new();
    }
}