using BumpySellotape.Core.Stats.Model;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Controller
{
    public class StatCollection
    {
        private Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();
        private List<IStatModifyingSystem> statModifyingSystems = new List<IStatModifyingSystem>();

        public List<Stat> AllStats => stats.Values.ToList();

        public delegate void AnyStatChanged();
        public event AnyStatChanged OnAnyStatChanged;

        public bool GetStat(StatType statType, out Stat stat)
        {
            return stats.TryGetValue(statType, out stat);
        }

        public Stat GetStatSafe(StatType statType)
        {
            if (stats.TryGetValue(statType, out var stat))
                return stat;
            throw new Exception($"Stat {statType} not found");
        }

        public void GenerateFromTemplates(List<GeneratedStatTemplate> statTemplates)
        {
            stats = statTemplates.ToDictionary(t => t.StatType, t => t.Generate());
            stats.Values.ForEach(s => s.OnValueChanged += StatChanged);
        }

        private void StatChanged(float delta)
        {
            OnAnyStatChanged?.Invoke();
        }

        public float GetDynamicStatValue(StatType statType)
        {
            return 0f;
        }

        public float GetStatValue(StatType statType)
        {
            return GetStat(statType, out var s) ? s.Value : statType.DefaultValue;
        }

        public void AddStatModifyingSystem(IStatModifyingSystem statModifyingSystem)
        {
            statModifyingSystems.Add(statModifyingSystem);
        }

        public float GetModifiedStatVariable(StatType statType, StatVariable statVariable)
        {
            GetStat(statType, out var stat);
            var systems = statModifyingSystems.OrderBy(system => system.Priority);
            float baseValue = 0, baseMinValue = 0f, baseMaxValue = 0f;
            switch (statVariable)
            {
                case StatVariable.Value:
                    baseValue = stat?.Value ?? statType.DefaultValue;
                    baseMinValue = stat?.MinValue ?? statType.DefaultMinValue;
                    baseMaxValue = stat?.MaxValue ?? statType.DefaultMaxValue;
                    break;
                case StatVariable.MinValue:
                    baseValue = stat?.MinValue ?? statType.DefaultMinValue;
                    break;
                case StatVariable.MaxValue:
                    baseValue = stat?.MaxValue ?? statType.DefaultMaxValue;
                    break;
            }

            foreach (var s in systems)
            {
                baseValue = s.ModifyStatValue(statType, statVariable, baseValue);
            }

            if (statVariable == StatVariable.Value)
            {
                foreach (var s in systems)
                {
                    baseMinValue = s.ModifyStatValue(statType, statVariable, baseMinValue);
                    baseMaxValue = s.ModifyStatValue(statType, statVariable, baseMaxValue);
                }
                baseValue = Mathf.Clamp(baseValue, baseMinValue, baseMaxValue);
            }

            return baseValue;
        }
    }
}
