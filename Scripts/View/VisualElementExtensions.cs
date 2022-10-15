using UnityEngine.UIElements;

#nullable enable

namespace BumpySellotape.Core.View
{
    public static class VisualElementExtensions
    {
        public static void SetParent(this VisualElement element, VisualElement? newParent)
        {
            if (element.parent != null)
                element.parent.Remove(element);

            if (newParent != null)
            {
                newParent.Add(element);
            }
        }

        public static void Hide(this VisualElement element)
        {
            element.style.display = DisplayStyle.None;
        }

        public static void Show(this VisualElement element)
        {
            element.style.display = DisplayStyle.Flex;
        }
    }
}