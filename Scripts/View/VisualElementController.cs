using UnityEngine.UIElements;

namespace BumpySellotape.Core.View
{
    public class VisualElementController
    {
        public VisualElement VisualElement { get; private set; }

        public VisualElementController(VisualElement visualElement)
        {
            VisualElement = visualElement;
        }
    }
}