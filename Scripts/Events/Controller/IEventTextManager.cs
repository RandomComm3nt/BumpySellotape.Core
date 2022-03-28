using BumpySellotape.Core.Events.Model.Effects.Choices;
using BumpySellotape.Events.Model.Effects.Text;
using System.Collections.Generic;

namespace BumpySellotape.Events.Controller
{
    public interface IEventTextManager
    {
        public void AddEventText(DisplayText displayText);
        public void AppendText(DisplayText displayText);
        public void DisplayOptions(List<EvaluatedEventOption> eventOptions);
    }
}
