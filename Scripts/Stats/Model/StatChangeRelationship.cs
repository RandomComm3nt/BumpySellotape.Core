using BumpySellotape.Core.DateAndTime;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [Serializable]
    public class StatChangeRelationship
    {
        [field: SerializeField] public TimeInterval TimeInterval { get; private set; }
        [field: SerializeField] public StatType DeltaStat { get; private set; }
    }
}