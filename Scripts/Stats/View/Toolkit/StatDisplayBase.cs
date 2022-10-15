using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.View;
using UnityEngine.UIElements;

namespace BumpySellotape.Core.Stats.View.Toolkit
{
    public class StatDisplayBase : VisualElementController
    {
        protected readonly Stat stat;

        public StatDisplayBase(VisualElement visualElement, Stat stat) : base(visualElement)
        {
            this.stat = stat;
            stat.ValueChanged += Stat_ValueChanged;
        }

        private void Stat_ValueChanged(float delta)
        {
            UpdateDisplay();
        }

        protected virtual void UpdateDisplay()
        {

        }
    }
}