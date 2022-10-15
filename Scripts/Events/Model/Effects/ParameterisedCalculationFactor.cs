using BumpySellotape.Core.Model.Effects;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    public class ParameterisedCalculationFactor : CalculationFactor
    {
        [HideInInspector, NonSerialized] public List<string> parameters;
        [ValueDropdown("parameters"), PropertyOrder(-1), HideLabel(), SuffixLabel(":"), HorizontalGroup("HGroup")] public string key;

    }
}
