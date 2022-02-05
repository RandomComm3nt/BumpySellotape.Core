using BumpySellotape.Events.View;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects
{
    public class AddObjectToSceneEffect : IEffect
    {
        [SerializeField] private ScreenManager.UiLayer layer = default;
        [SerializeField] private GameObject objectPrefab = default;

        string IEffect.Label => "Add Scene Object";

        void IEffect.Process(ProcessingContext processingContext)
        {
            processingContext.GameController.ScreenManager.AddObject(objectPrefab, layer);
        }

    }
}
