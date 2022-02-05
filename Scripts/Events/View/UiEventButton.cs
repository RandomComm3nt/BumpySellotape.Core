using BumpySellotape.Events.Controller;
using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Events.View
{
    public class UiEventButton : SerializedMonoBehaviour
    {
        [SerializeField] [HideReferenceObjectPicker] private List<IEffect> eventBlocks = new List<IEffect>();

        public void Click()
        {
            var processingContext = new ProcessingContext(FindObjectOfType<GameController>()); // TECH DEBT
            eventBlocks.ForEach(eb => eb.Process(processingContext));
        }
    }
}
