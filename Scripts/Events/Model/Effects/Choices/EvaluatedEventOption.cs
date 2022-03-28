using BumpySellotape.Events.Model.Conditions;
using System.Linq;

namespace BumpySellotape.Core.Events.Model.Effects.Choices
{
    public class EvaluatedEventOption
    {
        public EventOption EventOption { get; private set; }
        public bool IsAvailable { get; private set; }
        public string NotAvailableText { get; private set; }

        public EvaluatedEventOption(EventOption eventOption, EvaluationContext evaluationContext)
        {
            EventOption = eventOption;
            var notMetConditions = eventOption.AvailableConditions.Where(c => !c.Evaluate(evaluationContext)).ToList();
            IsAvailable = notMetConditions.Count == 0;
            notMetConditions.Select(c => $"<li>{c.ConditionNotMetText}</li>").Aggregate("", (total, next) => $"{total}/r/n{next}");
        }
    }
}