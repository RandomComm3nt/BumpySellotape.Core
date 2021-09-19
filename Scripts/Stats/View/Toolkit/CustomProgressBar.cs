using UnityEngine.UIElements;

namespace BumpySellotape.Core.Stats.View.Toolkit
{
    public class CustomProgressBar : VisualElement
    {
        private readonly VisualElement background;
        private readonly VisualElement overlay;
        public float Value { get; set; } = 100f;

        public CustomProgressBar()
        {
            background = new VisualElement();
            background.AddToClassList("progressBar_background");
            Add(background);

            overlay = new VisualElement();
            overlay.AddToClassList("progressBar_overlay");
            background.Add(overlay);
            UpdateFillPercent(Value);
        }

        public void UpdateFillPercent(float p)
        {
            overlay.style.width = new StyleLength(Length.Percent(p));
        }

        #region UXML
        public new class UxmlFactory : UxmlFactory<CustomProgressBar, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits {
            UxmlFloatAttributeDescription valueAttribute = new UxmlFloatAttributeDescription { name = "value", defaultValue = 100f };


            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                CustomProgressBar ate = ve as CustomProgressBar;

                ate.Value = valueAttribute.GetValueFromBag(bag, cc);
                ate.UpdateFillPercent(ate.Value);
            }
        }
        #endregion
    }
}
