using UnityEngine;
using UnityEngine.UI;

namespace BumpySellotape.Core.Stats.View
{
    public class FillStatBar : StatBar
    {
        [SerializeField] private Image image;

        public override void Draw(float value, float maxValue)
        {
            image.fillAmount = value / maxValue;
        }
    }
}
