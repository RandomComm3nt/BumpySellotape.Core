using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [CreateAssetMenu(menuName = "Common/Stats/Stat Type")]
    public class StatType : ScriptableObject
    {
        [SerializeField] private StatDisplayType displayType = StatDisplayType.Hidden;
        [SerializeField] [HideIf("Hidden")] private string displayName = "";
        [Tooltip("If the stat is dynamic it will always be calculated when required and will not have a stored value")]
        [SerializeField] private bool dynamic = false;
        //[Tooltip("If the stat is targeted it will exist on a per-character basis")]
        //[SerializeField] private bool targeted = false;
        //[SerializeField] [HideIf("dynamic")] private DriftType driftType = DriftType.NoDrift;
        //[SerializeField] [HideIf("dynamic")] [HideIf("driftType", DriftType.NoDrift)] private float driftRatePerDay = 0f;

        //[SerializeField] [ShowIf("dynamic")] private bool derivedStat = false;
        //[SerializeField] [ShowIf("derivedStat")] private float baseValue = 0f;
        //[SerializeField] [ShowIf("derivedStat")] private List<DerivedStatFactor> derivedStatFactors = new List<DerivedStatFactor>();

        [field: SerializeField] public float DefaultValue { get; private set; } = 0f;
        [field: SerializeField] public float DefaultMinValue { get; private set; } = 0f;
        [field: SerializeField] public float DefaultMaxValue { get; private set; } = 100f;
        [field: SerializeField] public float HardMinValue { get; private set; } = 0f;
        [field: SerializeField] public float HardMaxValue { get; private set; } = 100f;

        public StatDisplayType DisplayType => displayType;
        public bool Hidden => displayType == StatDisplayType.Hidden;
        public string DisplayName => displayName;
        public bool Dynamic => dynamic;
        //public bool Targeted => targeted;
        //public DriftType DriftType => driftType;
        //public float DriftRatePerDay => driftRatePerDay;

        //public bool DerivedStat => derivedStat;
        //public float BaseValue => baseValue;
        // public List<DerivedStatFactor> DerivedStatFactors => derivedStatFactors;
    }
}