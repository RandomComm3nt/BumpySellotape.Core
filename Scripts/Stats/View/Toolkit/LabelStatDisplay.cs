using BumpySellotape.Core.Stats.Controller;
using UnityEngine.UIElements;

namespace BumpySellotape.Core.Stats.View.Toolkit
{
    public class LabelStatDisplay : StatDisplayBase
    {
        private readonly Label label;

        public LabelStatDisplay(Label visualElement, Stat stat) : base(visualElement, stat)
        {
            label = visualElement;
        }

        protected override void UpdateDisplay()
        {
            label.text = stat.Value.ToString();
        }
    }
}