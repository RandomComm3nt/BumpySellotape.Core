using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace BumpySellotape.Events.Controller
{
    public class CutsceneManager : MonoBehaviour, IBackgroundRenderer
    {
        private GameObject loadedSceneObject;
        private VisualElement background;
        private CutsceneEventTextManager eventTextManager;
        [SerializeField] private GameController gameController = null;
        [SerializeField] private UIDocument uiDocument = null;

        public IEventTextManager EventTextManager => eventTextManager;

        private void Awake()
        {
            var root = uiDocument.rootVisualElement;
            root.AddToClassList("cutscene");
            background = new VisualElement();
            background.AddToClassList("background");
            root.Add(background);
            eventTextManager = new CutsceneEventTextManager();
            root.Add(eventTextManager);
        }

        public void StartCutscene(GameObject sceneObject)
        {
            gameObject.SetActive(true);
            if (sceneObject)
                loadedSceneObject = Instantiate(sceneObject, transform);
        }

        public void UnloadCutscene()
        {
            gameObject.SetActive(false);
            Destroy(loadedSceneObject);
        }

        void IBackgroundRenderer.SetBackground(Sprite sprite)
        {
            background.style.backgroundImage = new StyleBackground(sprite);
        }

        public void OnAdvanceText()
        {
            gameController.EventManager.AdvanceFrame();
        }
    }
}