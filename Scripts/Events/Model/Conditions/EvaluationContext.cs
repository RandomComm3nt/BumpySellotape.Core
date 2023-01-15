using BumpySellotape.Core;
using BumpySellotape.Core.Events.Model.Effects;
using System.Collections.Generic;

namespace BumpySellotape.Events.Model.Conditions
{
    public class EvaluationContext
    {

        public List<ParameterisedCalculationFactor> parameters = new();
        public bool isLoggingEnabled = false;
        public SystemLinks SystemLinks { get; protected set; } = new();
    }
}
