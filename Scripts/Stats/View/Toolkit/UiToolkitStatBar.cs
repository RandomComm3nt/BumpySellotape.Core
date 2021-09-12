using BumpySellotape.Core.Stats.Controller;
using UnityEngine.UIElements;

namespace BumpySellotape.Core.Stats.View.Toolkit
{
    public class UiToolkitStatBar : VisualElement
    {
        private readonly Stat stat;
        private readonly ProgressBar bar;

        public UiToolkitStatBar(Stat stat)
        {
            this.stat = stat;
            AddToClassList("statBar");

            bar = new ProgressBar();
            bar.title = "Test";
            Add(bar);

            stat.OnValueChanged += UpdateValues;
            UpdateValues(0f);
        }

        private void UpdateValues(float value)
        {
            //bar.value = stat.ValuePercent;
        }
    }
}
