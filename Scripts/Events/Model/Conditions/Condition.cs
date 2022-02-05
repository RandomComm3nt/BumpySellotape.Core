using BumpySellotape.Events.Model.Scopes;
using System;

namespace BumpySellotape.Events.Model.Conditions
{
    public abstract class Condition
    {
        public abstract bool CheckCondition(Scope scope);

        public virtual string DisplayLabel => "[Condition]";
    }

    public abstract class Condition<TScope> : Condition
        where TScope : Scope
    {
        public override bool CheckCondition(Scope scope)
        {
            if (scope is TScope s)
            {
                return CheckConditionInternal(s);
            }
            throw new Exception("Input was not of correct type");
        }

        protected abstract bool CheckConditionInternal(TScope scope);
    }
}
