using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Stats.View
{
    public class StatBar : MonoBehaviour
    {
        [SerializeField] private RectTransform barTransform = null;

        [Button]
        public virtual void Draw(float value, float maxValue)
        {
            barTransform.anchorMax = new Vector2(1, Mathf.Clamp(value / maxValue, 0.05f, 1f));
        }
    }
}
