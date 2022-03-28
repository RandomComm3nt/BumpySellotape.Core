namespace BumpySellotape.Events.Model.Conditions
{
    public class AlwaysTrueCondition : ICondition
    {
        public string ConditionNotMetText => throw new System.NotImplementedException();

        string ICondition.Label => "Always";

        bool ICondition.Evaluate(EvaluationContext evaluationContext)
        {
            return true;
        }
    }
}
