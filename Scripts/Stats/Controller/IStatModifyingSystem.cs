using BumpySellotape.Core.Stats.Model;

namespace BumpySellotape.Core.Stats.Controller
{
    public interface IStatModifyingSystem
    {
        public float Priority { get; }

        public float ModifyStatValue(StatType statType, StatVariable statVariable, float statValue);
    }
}
