namespace BumpySellotape.Events.Model.Conditions
{
    public class AlwaysTrueCondition : ICondition
    {
        string ICondition.Label => "Always";

        bool ICondition.Evaluate(EvaluationContext evaluationContext)
        {
            return true;
        }
    }
}
