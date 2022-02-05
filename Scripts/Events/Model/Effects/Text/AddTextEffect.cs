using BumpySellotape.Events.Controller;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects.Text
{
    public class AddTextEffect : IEffect
    {
        [SerializeField] private DisplayText displayText = new DisplayText();

        public string Label => "Add Text";

        public void Process(ProcessingContext processingContext)
        {
            processingContext.SystemLinks.GetSystemSafe<IEventTextManager>().AddEventText(displayText);
        }
    }
}
