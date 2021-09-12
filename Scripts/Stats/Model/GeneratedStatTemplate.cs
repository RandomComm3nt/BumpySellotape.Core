﻿using System;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [Serializable]
    public class GeneratedStatTemplate
    {
        [SerializeField] private StatType statType = null;
        [SerializeField] private Vector2 valueRange = new Vector2(0, 100);

        public StatType StatType => statType;
        public Vector2 ValueRange => valueRange;

        public float RollValue() => UnityEngine.Random.Range(valueRange.x, valueRange.y);

        public Stat Generate()
        {
            var s = new Stat(statType);
            float value = RollValue();
            s.SetVariable(value, StatVariable.Value);
            //if (statType.DriftType != DriftType.NoDrift)
            //    s.SetValue(value, StatVariable.DriftTarget);
            return s;
        }
    }
}
