using BumpySellotape.Events.Model.Effects.Text;
using UnityEngine.UIElements;

namespace BumpySellotape.Events.Controller
{
    public class CutsceneEventTextManager : VisualElement, IEventTextManager
    {
        private Label label;

        public CutsceneEventTextManager()
        {
            AddToClassList("eventText");

            label = new Label();
            label.AddToClassList("eventTextContent");
            Add(label);
        }

        void IEventTextManager.AddEventText(DisplayText displayText)
        {
            label.text = displayText.Text;
        }
    }
}