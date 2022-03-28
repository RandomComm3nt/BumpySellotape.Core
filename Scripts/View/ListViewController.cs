using BumpySellotape.Core.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace BumpySellotape.Core.View
{

    public abstract class ListViewController : VisualElementController
    {
        public ListViewController(VisualElement visualElement)
            : base(visualElement)
        {
        }

        public abstract void OnItemClicked(object content);
    }

    public abstract class ListViewItemController<T>
    {
        public ListViewController ListViewController { get; private set; }

        public T BoundItem { get; private set; }
        public VisualElement VisualElement{ get; private set; }

        public void SetVisualElement(VisualElement visualElement, ListViewController listViewController)
        {
            VisualElement = visualElement;
            visualElement.userData = this;
            ListViewController = listViewController;
            GetReferences();
        }

        public void BindItem(T item)
        {
            BoundItem = item;
            UpdateDisplay();
        }

        public abstract void GetReferences();
        public abstract void UpdateDisplay();
    }

    public sealed class ListViewController<TContent, TItem> : ListViewController
        where TItem : ListViewItemController<TContent>, new()
        where TContent : class
    {
        private readonly VisualTreeAsset listItemAsset;
        private readonly List<TContent> itemList;
        public event SimpleEventHandler<TContent> ItemClicked;
        public event SimpleEventHandler<TContent> SelectionChangedSingle;
        public event SimpleEventHandler<IEnumerable<TContent>> SelectionChangedMultiple;

        private ListView ListView => VisualElement as ListView;

        public ListViewController(VisualElement visualElement, VisualTreeAsset listItemAsset, List<TContent> itemList)
            : base(visualElement)
        {
            this.listItemAsset = listItemAsset;
            this.itemList = itemList;
            ListView.makeItem = MakeListItem;
            ListView.bindItem = BindListItem;
            ListView.itemsSource = itemList;
            ListView.onSelectionChange += OnSelectionChange;
        }

        private VisualElement MakeListItem()
        {
            var newListEntry = listItemAsset.Instantiate();
            var newListEntryController = new TItem();
            newListEntryController.SetVisualElement(newListEntry, this);

            return newListEntry;
        }

        private void BindListItem(VisualElement element, int i)
        {
            (element.userData as TItem).BindItem(itemList[i]);
        }

        private void OnSelectionChange(IEnumerable<object> obj)
        {
            if (ListView.selectionType == SelectionType.Single)
                SelectionChangedSingle?.Invoke(obj.FirstOrDefault() as TContent);
            else
                SelectionChangedMultiple?.Invoke(obj.Select(o => o as TContent));
        }

        public override void OnItemClicked(object content)
        {
            ItemClicked?.Invoke(content as TContent);
        }
    }
}