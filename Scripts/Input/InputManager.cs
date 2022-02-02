using UnityEngine;
using UnityEngine.InputSystem;

namespace BumpySellotape.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        private GameObject currentHandler;

        public InputHandler<TController> SetInputHandler<THandler, TController>(TController controller)
            where THandler : InputHandler<TController>
        {
            if (currentHandler)
                Destroy(currentHandler);

            currentHandler = new GameObject(typeof(THandler).Name);
            var handler = currentHandler.AddComponent<THandler>();
            handler.Initialise(controller);
            currentHandler.transform.SetParent(transform);
            GetComponent<PlayerInput>().SwitchCurrentActionMap(handler.ActionMap);

            return handler;
        }
    }
}