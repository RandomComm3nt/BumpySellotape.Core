using BumpySellotape.Core.Traits.Model;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [Serializable]
    public class StatThresholdTrait
    {
        [SerializeField, HorizontalGroup(GroupID = "Min"), LabelText("Min Threshold")] private bool hasMin = true;
        [SerializeField, HorizontalGroup(GroupID = "Min"), HideLabel, ShowIf(nameof(hasMin))] private float minThreshold = 0f;
        [SerializeField, HorizontalGroup(GroupID = "Min"), LabelText("Inc."), LabelWidth(30), ShowIf(nameof(hasMin))] private bool minInclusive = true;
        [SerializeField, HorizontalGroup(GroupID = "Max"), LabelText("Max Threshold")] private bool hasMax = true;
        [SerializeField, HorizontalGroup(GroupID = "Max"), HideLabel, ShowIf(nameof(hasMax))] private float maxThreshold = 100f;
        [SerializeField, HorizontalGroup(GroupID = "Max"), LabelText("Inc."), LabelWidth(30), ShowIf(nameof(hasMax))] private bool maxInclusive = true;

        /// <summary>
        /// The minimum value of the stat for which the trait should be active, inclusive
        /// </summary>
        public float MinThreshold => hasMin ? minThreshold + (minInclusive ? 0f : Mathf.Epsilon) : float.MinValue;

        /// <summary>
        /// The maximum value of the stat for which the trait should be active, inclusive
        /// </summary>
        public float MaxThreshold => hasMax ? maxThreshold - (maxInclusive ? 0f : Mathf.Epsilon) : float.MaxValue;
        [field: SerializeField] public TraitType TraitType { get; private set; }
    }
}