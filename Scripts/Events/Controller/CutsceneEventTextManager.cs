using BumpySellotape.Core.Events.Model.Effects.Choices;
using BumpySellotape.Events.Model.Effects.Text;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace BumpySellotape.Events.Controller
{
    public class CutsceneEventTextManager : VisualElement, IEventTextManager
    {
        private readonly Label label;

        public CutsceneEventTextManager()
        {
            AddToClassList("eventText");

            label = new Label();
            label.AddToClassList("eventTextContent");
            Add(label);
        }

        public void DisplayOptions(List<EvaluatedEventOption> eventOptions)
        {
            throw new System.NotImplementedException();
        }

        void IEventTextManager.AddEventText(DisplayText displayText)
        {
            label.text = displayText.Text;
        }

        void IEventTextManager.AppendText(DisplayText displayText)
        {
            label.text += displayText.Text;
        }
    }
}