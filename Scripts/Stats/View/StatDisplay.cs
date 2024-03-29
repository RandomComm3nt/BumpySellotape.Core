﻿using BumpySellotape.Core.Stats.Controller;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace BumpySellotape.Core.Stats.View
{
    public class StatDisplay : MonoBehaviour
    {
        [SerializeField] private bool splitTextFields;
        [SerializeField, ShowIf("splitTextFields")] private TextMeshProUGUI labelText;
        [SerializeField] private TextMeshProUGUI valueLabel = null;
        [SerializeField] private StatBar valueStatBar = null;
        [SerializeField] private bool showMaxValue = false;

        private Stat stat;

        public virtual StatDisplay Initialise(Stat stat)
        {
            this.stat = stat;
            stat.ValueChanged += UpdateValues;
            UpdateValues();
            return this;
        }

        public void Destroy()
        {
            stat.ValueChanged -= UpdateValues;
            Destroy(gameObject);
        }

        private void UpdateValues(float delta = 0f)
        {
            if (splitTextFields)
            {
                labelText.text = stat.StatType.DisplayName;
                valueLabel.text = stat.Value.ToString("##0") + (showMaxValue ? "/" + stat.RawMaxValue.ToString("##0") : "");
            }
            else if (valueLabel)
            {
                valueLabel.text = stat.Value.ToString("##0") + (showMaxValue ? "/" + stat.RawMaxValue.ToString("##0") : "");
            }
            if (valueStatBar && stat.StatType.DisplayType == Model.StatDisplayType.Bar)
                valueStatBar.Draw(stat.Value, stat.RawMaxValue);
        }
    }
}
