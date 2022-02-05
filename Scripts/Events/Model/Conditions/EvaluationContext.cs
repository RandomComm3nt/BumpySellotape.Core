using BumpySellotape.Core;

namespace BumpySellotape.Events.Model.Conditions
{
    public class EvaluationContext
    {
        public SystemLinks SystemLinks { get; protected set; } = new();
    }
}
