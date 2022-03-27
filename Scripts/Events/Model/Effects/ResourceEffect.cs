using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Events.Model.Effects
{
    public class ResourceEffect : IEffect
    {
        public enum EffectType
        {
            Add = 0,
            Remove,
            Set,
        }

        [SerializeField, FoldoutGroup("$" + nameof(Label))] private EffectType effectType;
        [SerializeField, FoldoutGroup("$" + nameof(Label))] private StatType statType;
        [SerializeField, FoldoutGroup("$" + nameof(Label)), Min(0f)] private int value;

        public string Label => $"{effectType}, {statType?.name}, {value}";

        public void Process(ProcessingContext processingContext)
        {
            var stat = processingContext.SystemLinks.GetSystemSafe<StatCollection>().GetStatSafe(statType);
            switch (effectType)
            {
                case EffectType.Add:
                    stat.ChangeValue(value);
                    break;
                case EffectType.Remove:
                    stat.ChangeValue(-value);
                    break;
                case EffectType.Set:
                    stat.SetVariable(value);
                    break;
            }
        }
    }
}