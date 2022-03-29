using BumpySellotape.Events.Controller;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects.Text
{
    public class AddTextEffect : IEffect
    {
        [SerializeField, HideLabel, FoldoutGroup("$" + nameof(Label))] private DisplayText displayText = new ();
        [SerializeField, FoldoutGroup("$" + nameof(Label))] private bool append = false;

        public string Label => $"Add Text: {displayText.Text}";

        public void Process(ProcessingContext processingContext)
        {
            IEventTextManager eventTextManager = processingContext.SystemLinks.GetSystemSafe<IEventTextManager>();
            if (append)
                eventTextManager.AppendText(displayText);
            else
                eventTextManager.AddEventText(displayText);
        }
    }
}
