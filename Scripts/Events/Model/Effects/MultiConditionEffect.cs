﻿using BumpySellotape.Core.Events.Model.Nodes;
using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    public class MultiConditionEffect : IEffect
    {
        [SerializeField, HideReferenceObjectPicker, ListDrawerSettings(CustomAddFunction = nameof(GetNewConditionOption))] private List<ConditionOption> options = new();
        [SerializeField] private EffectSource defaultEffect = new();

        public string Label => throw new System.NotImplementedException();

        public void Process(ProcessingContext processingContext)
        {
            foreach (var o in options)
            {
                if (o.Condition == null || o.Condition.Evaluate(processingContext))
                {
                    o.Effect.Process(processingContext);
                    return;
                }
            }

            defaultEffect.Process(processingContext);
        }

        private ConditionOption GetNewConditionOption() => new();
    }
}
