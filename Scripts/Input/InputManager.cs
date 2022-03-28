using System;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        private readonly List<(object screen, Type requiredClass, object initialisationData)> requiredHandlerStack = new();
        private readonly Dictionary<Type, InputHandler> inputHandlers = new();
        private InputHandler currentHandler;

        public void SetInputHandler<THandler, TController>()
            where THandler : InputHandler<TController>
            where TController : class
        {
            var go = new GameObject(typeof(THandler).Name);
            go.transform.SetParent(transform);
            go.SetActive(false);
            inputHandlers.Add(typeof(THandler), go.AddComponent<THandler>());
        }

        private void ActivateInputHandler(Type requiredClass, object initialisationData)
        {
            if (currentHandler)
                currentHandler.gameObject.SetActive(false);

            currentHandler = inputHandlers[requiredClass];
            currentHandler.gameObject.SetActive(true);
            currentHandler.Initialise(initialisationData);
        }

        public void AddRequiredInputHandler(object screen, Type requiredClass, object initialisationData)
        {
            var i = requiredHandlerStack.FindIndex(tuple => tuple.screen == screen);
            if (i < 0)
            {
                requiredHandlerStack.Add((screen, requiredClass, initialisationData));
                ActivateInputHandler(requiredClass, initialisationData);
            }
        }

        public void RemoveRequiredInputHandler(object screen)
        {
            var i = requiredHandlerStack.FindIndex(tuple => tuple.screen == screen);
            if (i >= 0)
            {
                if (i == requiredHandlerStack.Count - 1)
                    ActivateInputHandler(requiredHandlerStack[i - 1].requiredClass, requiredHandlerStack[i - 1].initialisationData);
                requiredHandlerStack.RemoveAt(i);
            }
        }
    }
}