using System;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Events.View
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private Transform sceneTransform = default;
        /*
        private CombatGameController combatGameController;

        [SerializeField] private OverworldScreen overworldScreen;
        [SerializeField] private EncounterScreen encounterScreen;
        [SerializeField] private UnlockTraitsScreen unlockTraitsScreen;
        [field: SerializeField] public ActorDisplay PlayerDisplay { get; private set; }

        public void Initialise(CombatGameController combatGameController)
        {
            this.combatGameController = combatGameController;
            PlayerDisplay.Initialise(combatGameController.TurnSystem.CurrentTurnActor);
        }

        public void StartEncounter(EncounterTemplate encounterTemplate)
        {
            overworldScreen.gameObject.SetActive(false);
            encounterScreen.gameObject.SetActive(true);
            encounterScreen.StartEncounter(combatGameController, encounterTemplate);
        }

        public void OpenTraitsScreen()
        {
            unlockTraitsScreen.gameObject.SetActive(true);
            overworldScreen.gameObject.SetActive(false);
        }
        */

        private List<GameObject> objectsOnScreen = new List<GameObject>();

        public void AddObject(GameObject prefab, UiLayer uiLayer)
        {
            var parent = uiLayer switch
            {
                UiLayer.Hud => transform,
                UiLayer.Scene => sceneTransform,
                _ => throw new NotImplementedException(),
            };
            var o = Instantiate(prefab, parent);
            objectsOnScreen.Add(o);
        }

        public void ClearScreen()
        {
            foreach (var o in objectsOnScreen)
                Destroy(o.gameObject);
            objectsOnScreen = new List<GameObject>();
        }

        public enum UiLayer
        {
            Hud = 0,
            Scene
        }
    }
}
