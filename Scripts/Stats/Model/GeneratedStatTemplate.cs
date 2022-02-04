using BumpySellotape.Core.Stats.Controller;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [Serializable, HideReferenceObjectPicker]
    public class GeneratedStatTemplate
    {
        [SerializeField] private StatType statType = null;
        [SerializeField] private Vector2 valueRange = new Vector2(0, 100);

        public StatType StatType => statType;
        public Vector2 ValueRange => valueRange;

        public float RollValue() => UnityEngine.Random.Range(valueRange.x, valueRange.y);

        public Stat Generate(StatCollection statCollection)
        {
            var s = new Stat(statType, statCollection);
            float value = RollValue();
            s.SetVariable(value, StatVariable.Value);
            //if (statType.DriftType != DriftType.NoDrift)
            //    s.SetValue(value, StatVariable.DriftTarget);
            return s;
        }
    }
}
