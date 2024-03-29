﻿using BumpySellotape.Core.Stats.Controller;
using UnityEngine.UIElements;

namespace BumpySellotape.Core.Stats.View.Toolkit
{
    public class UiToolkitStatBar : VisualElement
    {
        private readonly Stat stat;
        private readonly CustomProgressBar bar;

        public UiToolkitStatBar(Stat stat)
        {
            this.stat = stat;
            AddToClassList("statBar");
            AddToClassList($"statBar_{stat.StatType.name}");

            bar = new();

            stat.ValueChanged += UpdateValues;
            UpdateValues(0f);
        }

        private void UpdateValues(float value)
        {
            bar.UpdateFillPercent(stat.ValuePercent);
        }
    }
}
