namespace BumpySellotape.Events.Model.Conditions
{
    public interface ICondition
    {
        bool Evaluate(EvaluationContext evaluationContext);

        string Label { get; }
    }

    public interface IScopeCondition : ICondition
    {
        bool Evaluate(ScopeEvaluationContext evaluationContext);
    }
}
